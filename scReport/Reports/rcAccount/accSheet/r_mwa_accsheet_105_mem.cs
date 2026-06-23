using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcAccount.accSheet
{
    public partial class r_mwa_accsheet_105_mem : DevExpress.XtraReports.UI.XtraReport
    {
        public r_mwa_accsheet_105_mem()
        {
            InitializeComponent();
        }
        private void count_mem_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcAccount.accSheet.r_mwa_accsheet_105_mem_nest_mem");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("OPERATE_DATE"));
        }
    }
}
