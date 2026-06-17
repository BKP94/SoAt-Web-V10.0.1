using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.lonPaid
{
    public partial class r_amnat_loan_paid_cash_not_by_fin_trd : DevExpress.XtraReports.UI.XtraReport
    {
        public r_amnat_loan_paid_cash_not_by_fin_trd()
        {
            InitializeComponent();
        }

        private void loan_old_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonPaid.r_amnat_loan_paid_cash_not_by_fin_nest_loan_old");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        }

        private void paid_cash_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonPaid.r_amnat_loan_paid_cash_not_by_fin_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BEGINING_OF_CONTRACT"), this.GetCurrentColumnValue("TYPE_PAY_MONEY"));
        }

        private void paid_mpaid_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonPaid.r_amnat_loan_paid_cash_not_by_fin_nest_paid");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        }


        private void fee_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonPaid.r_amnat_loan_paid_cash_not_by_fin_nest_fee");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_REQUESTMENT_NO"), this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        }

        private void paid_type_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonPaid.r_amnat_loan_paid_cash_not_by_fin_nest_paidtype");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BEGINING_OF_CONTRACT"));
        }
        
        private void paid_cash_loan_type_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonPaid.r_amnat_loan_paid_cash_not_by_fin_nest_loan_type");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BEGINING_OF_CONTRACT"), this.GetCurrentColumnValue("TYPE_PAY_MONEY"), this.GetCurrentColumnValue("LOAN_TYPE"));
        }

        private void paid_type_loan_type_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonPaid.r_amnat_loan_paid_cash_not_by_fin_nest_paidtypel");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BEGINING_OF_CONTRACT"), this.GetCurrentColumnValue("LOAN_TYPE"));
        }
    }
}
