using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.lonPaid
{
    public partial class r_mwa_loan_paid_atm : DevExpress.XtraReports.UI.XtraReport
    {
        public r_mwa_loan_paid_atm()
        {
            InitializeComponent();
        }

        private void loan_old_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonPaid.r_mwa_loan_paid_atm_nest_loan_old");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        }

        private void paid_cash_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonPaid.r_mwa_loan_paid_atm_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BEGINING_OF_CONTRACT"));
        }
    }
}
