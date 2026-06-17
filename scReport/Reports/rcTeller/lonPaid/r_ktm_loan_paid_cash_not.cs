using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.lonPaid
{
    public partial class r_ktm_loan_paid_cash_not : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_loan_paid_cash_not()
        {
            InitializeComponent();
        }

        private void loan_old_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonPaid.r_ktm_loan_paid_cash_not_nest_loan_old");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        }

        private void paid_cash_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonPaid.r_ktm_loan_paid_cash_not_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BEGINING_OF_CONTRACT"),this.GetCurrentColumnValue("BRANCH_ID"), this.GetCurrentColumnValue("LOAN_TYPE"));
        }

        private void paid_mpaid_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonPaid.r_ktm_loan_paid_cash_not_nest_paid_mpaid");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        }

        private void loan_old_LocationChanged(object sender, ChangeEventArgs e)
        {

        }
    }
}
