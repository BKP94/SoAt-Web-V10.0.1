using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memMovegroup
{
    public partial class r_tnma_app_trans_group_loanshare : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tnma_app_trans_group_loanshare()
        {
            InitializeComponent();
        }

        private void nest_loan_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memMovegroup.r_tnma_app_trans_group_loanshare_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void nest_loangroup_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memMovegroup.r_tnma_app_trans_group_loangroup_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBER_GROUP_CONTROL"));
        }
    }
}
