using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.endDay
{
    public partial class r_mwa_receipt_sum_daily : DevExpress.XtraReports.UI.XtraReport
    {
        public r_mwa_receipt_sum_daily()
        {
            InitializeComponent();
        }

        private void shrfee_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {

            sc.report.setResource(sender, "scReport.Reports.rcTeller.endDay.r_mwa_receipt_sum_daily_nest_shrfee");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("C_RECEIPTDATE"));
        }

        private void receive_loan_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.endDay.r_mwa_receipt_sum_daily_nest_receive_loan");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("C_RECEIPTDATE"));
        }

        private void payment_loan_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.endDay.r_mwa_receipt_sum_daily_nest_payment_loan");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("C_RECEIPTDATE"));
        }

        private void adding_loan_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.endDay.r_mwa_receipt_sum_daily_nest_adding_loan");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("C_RECEIPTDATE"));
        }
    }
}
