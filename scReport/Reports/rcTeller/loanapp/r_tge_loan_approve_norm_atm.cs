using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanapp
{
    public partial class r_tge_loan_approve_norm_atm : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tge_loan_approve_norm_atm()
        {
            InitializeComponent();
        }

        private void bank_atm_loan_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanapp.r_tge_loan_approve_norm_atm_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }
    }
}
