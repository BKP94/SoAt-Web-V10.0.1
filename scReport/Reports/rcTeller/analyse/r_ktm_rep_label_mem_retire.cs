using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.analyse
{
    public partial class r_ktm_rep_label_mem_retire : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_rep_label_mem_retire()
        {
            InitializeComponent();
        }

        private void xrSubreport1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.analyse.r_ktm_rep_label_mem_retire_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMNO_1"));
        }

        private void xrSubreport2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.analyse.r_ktm_rep_label_mem_retire_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMNO_2"));
        }
    }
}
