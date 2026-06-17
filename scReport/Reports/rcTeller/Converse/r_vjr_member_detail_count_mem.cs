using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.Converse
{
    public partial class r_vjr_member_detail_count_mem : DevExpress.XtraReports.UI.XtraReport
    {
        public r_vjr_member_detail_count_mem()
        {
            InitializeComponent();
        }

        private void nest_sum_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.Converse.r_vjr_member_detail_count_mem_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }
    }
}
