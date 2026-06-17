using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.lonSpec
{
    public partial class r_tnma_finance_payment_tran : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tnma_finance_payment_tran()
        {
            InitializeComponent();
        }

        void ofLoaddetail(object sender, string loan_group_code)
        {
            sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcTeller.lonSpec.r_tnma_finance_payment_nest"), null, this.GetCurrentColumnValue("RECEIPT_NO"), loan_group_code);
        }

        private void d01_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoaddetail(sender, "01");
        }

        private void d02_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoaddetail(sender, "02");
        }

        private void d03_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoaddetail(sender, "03");
        }

        private void sum_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonSpec.r_ktm_receipt_payment_nest_2");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("RECEIPT_DATE"), this.GetCurrentColumnValue("BRANCH_ID"));
        }

        private void sum1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonSpec.r_ktm_receipt_payment_nest");
            var tmp = this.GetCurrentColumnValue("BANK_FIN");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("RECEIPT_DATE"), this.GetCurrentColumnValue("BRANCH_ID"), this.GetCurrentColumnValue("MONEY_TYPE_ID") , this.GetCurrentColumnValue("BANK_FIN"));
        }

        private void sum_loan_code_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonSpec.r_tnma_receipt_payment_lon_code_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("RECEIPT_DATE"), this.GetCurrentColumnValue("BRANCH_ID"));

        }

        private void sum2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonSpec.r_ktm_receipt_payment_nest3");
            var tmp = this.GetCurrentColumnValue("BANK_FIN");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("RECEIPT_DATE"), this.GetCurrentColumnValue("BRANCH_ID"), this.GetCurrentColumnValue("MONEY_TYPE_ID"), this.GetCurrentColumnValue("BANK_FIN"));
        }

        private void sum3_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonSpec.r_ktm_receipt_payment_nest_4");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("RECEIPT_DATE"), this.GetCurrentColumnValue("BRANCH_ID"));
        }
    }
}
