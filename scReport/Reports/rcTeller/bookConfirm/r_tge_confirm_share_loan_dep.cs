using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.bookConfirm
{
    public partial class r_tge_confirm_share_loan_dep : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tge_confirm_share_loan_dep()
        {
            InitializeComponent();
        }

        private void emer_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.bookConfirm.r_tge_confirm_share_loan_dep_nest_emer");
            sc.report.ofBeforePrint(this, sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"), this.GetCurrentColumnValue("CONFIRM_DATE"));
        }

        private void norm_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.bookConfirm.r_tge_confirm_share_loan_dep_nest_norm");
            sc.report.ofBeforePrint(this, sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"), this.GetCurrentColumnValue("CONFIRM_DATE"));
        }

        private void spec_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.bookConfirm.r_tge_confirm_share_loan_dep_nest_spec");
            sc.report.ofBeforePrint(this, sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"), this.GetCurrentColumnValue("CONFIRM_DATE"));
        }

        private void krongkarn_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.bookConfirm.r_tge_confirm_share_loan_dep_nest_krongkarn");
            sc.report.ofBeforePrint(this, sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"), this.GetCurrentColumnValue("CONFIRM_DATE"));
        }

        private void dep_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.bookConfirm.r_tge_confirm_share_loan_dep_nest_dep");
            sc.report.ofBeforePrint(this, sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"), this.GetCurrentColumnValue("CONFIRM_DATE"));
        }
    }
}
