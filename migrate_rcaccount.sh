#!/usr/bin/env bash
# Migrate one legacy rcAccount report folder -> scReport/Reports/rcAccount/<menu>
# + copy its repQuery XML tree. Same transform rules as migrate_rcteller.sh
# (8 net10/DX25.2 compat sed rules + namespace/literal rewrite rcAccount.->scReport.Reports.rcAccount.)
# SQL Oracle->PG migrated lazily per report (function-first sweep, phase 2).
set -euo pipefail

MENU="$1"
SRC="C:/SoAt_PEAN/rcAccount/$MENU"
DST="C:/Project_SoAt/SoAt_WebApp/scReport/Reports/rcAccount/$MENU"
RQ_SRC="C:/SoAt_PEAN/repQuery/rcAccount/$MENU"
RQ_DST="C:/Project_SoAt/SoAt_WebApp/scReport/repQuery/rcAccount/$MENU"

mkdir -p "$DST"

n_cs=0; n_resx=0
for f in "$SRC"/*.cs; do
  [ -e "$f" ] || continue
  base=$(basename "$f")
  out="$DST/$base"
  sed -e 's/namespace rcAccount\./namespace scReport.Reports.rcAccount./' \
      -e 's/"rcAccount\./"scReport.Reports.rcAccount./g' \
      -e 's/System\.Drawing\.Printing\.PaperKind/DevExpress.Drawing.Printing.DXPaperKind/g' \
      -e 's/\.BeforePrint += new System\.Drawing\.Printing\.PrintEventHandler/.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler/g' \
      -e 's/\.AfterPrint += new System\.Drawing\.Printing\.PrintEventHandler/.AfterPrint += new DevExpress.XtraReports.UI.AfterPrintEventHandler/g' \
      -e 's/System\.Drawing\.StringTrimming/DevExpress.Drawing.DXStringTrimming/g' \
      -e 's/System\.Drawing\.Drawing2D\.DashStyle/DevExpress.Drawing.DXDashStyle/g' \
      -e 's/\.CheckState = System\.Windows\.Forms\.CheckState\.Checked/.Checked = true/g' \
      -e 's/\.CheckState = System\.Windows\.Forms\.CheckState\.Unchecked/.Checked = false/g' \
      -e 's/(object sender, System\.Drawing\.Printing\.PrintEventArgs e)/(object sender, System.ComponentModel.CancelEventArgs e)/g' \
      -e 's/(object sender, PrintEventArgs e)/(object sender, System.ComponentModel.CancelEventArgs e)/g' \
      -e '/using System\.Web/d' \
      "$f" > "$out"
  n_cs=$((n_cs+1))
done

for f in "$SRC"/*.resx; do
  [ -e "$f" ] || continue
  cp "$f" "$DST/$(basename "$f")"
  n_resx=$((n_resx+1))
done

n_xml=0
if [ -d "$RQ_SRC" ]; then
  mkdir -p "$RQ_DST"
  for f in "$RQ_SRC"/*.xml; do
    [ -e "$f" ] || continue
    cp "$f" "$RQ_DST/$(basename "$f")"
    n_xml=$((n_xml+1))
  done
fi

echo "menu=$MENU  cs_files=$n_cs  resx=$n_resx  repQuery_xml=$n_xml"
