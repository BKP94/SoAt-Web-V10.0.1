#!/usr/bin/env bash
# Migrate one legacy rcTeller report folder -> scReport/Reports/rcTeller/<menu>
# + copy its repQuery XML tree. Transformation rules (verified against pilot):
#   .cs           : namespace rcTeller. -> scReport.Reports.rcTeller.
#                   "rcTeller.         -> "scReport.Reports.rcTeller.   (setResource string literals)
#                   drop  using System.Web*   (confirmed unused)
#   .Designer.cs  : namespace rename (above)
#                   System.Drawing.Printing.PaperKind -> DevExpress.Drawing.Printing.DXPaperKind
#   .resx         : copy as-is
set -euo pipefail

MENU="$1"
SRC="C:/SoAt_PEAN/rcTeller/$MENU"
DST="C:/Project_SoAt/SoAt_WebApp/scReport/Reports/rcTeller/$MENU"
RQ_SRC="C:/SoAt_PEAN/repQuery/rcTeller/$MENU"
RQ_DST="C:/Project_SoAt/SoAt_WebApp/scReport/repQuery/rcTeller/$MENU"

mkdir -p "$DST"

n_cs=0; n_resx=0
# ใช้ sed ชุดเดียวกับ .cs ทุกไฟล์ (ทั้ง Designer.cs และ logic .cs) — กฎทุกข้อเจาะจงพอจนไม่ชนกัน
# และ endDay พิสูจน์แล้วว่า PaperKind/BeforePrint delegate โผล่ในไฟล์ logic ได้ ไม่ใช่แค่ Designer
#   namespace/literal : rcTeller. -> scReport.Reports.rcTeller.
#   net10/DX25.2      : PaperKind, BeforePrint/AfterPrint delegate type, StringTrimming, DashStyle, CheckState->Checked
#   BeforePrint arg   : PrintEventArgs -> CancelEventArgs (name-agnostic; FQ ก่อน bare). AfterPrint ใช้ EventHandler/EventArgs ไม่โดน
#   drop  using System.Web*
for f in "$SRC"/*.cs; do
  [ -e "$f" ] || continue
  base=$(basename "$f")
  out="$DST/$base"
  sed -e 's/namespace rcTeller\./namespace scReport.Reports.rcTeller./' \
      -e 's/"rcTeller\./"scReport.Reports.rcTeller./g' \
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

# repQuery XML (copy as-is; SQL Oracle->PG migrated lazily per report on first open)
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
