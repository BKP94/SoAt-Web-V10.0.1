using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.bookConfirm
{
    public partial class r_ktm_confirm_share_loan_dep_20 : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_confirm_share_loan_dep_20()
        {
            InitializeComponent();
        }

        private void dep_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.bookConfirm.r_ktm_confirm_share_loan_dep_20_nest_dep");
            sc.report.ofBeforePrint(this, sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void emer_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.bookConfirm.r_ktm_confirm_share_loan_dep_20_nest_emer");
            sc.report.ofBeforePrint(this, sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void norm_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.bookConfirm.r_ktm_confirm_share_loan_dep_20_nest_norm");
            sc.report.ofBeforePrint(this, sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void spec_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.bookConfirm.r_ktm_confirm_share_loan_dep_20_nest_spec");
            sc.report.ofBeforePrint(this, sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }
    }
}
