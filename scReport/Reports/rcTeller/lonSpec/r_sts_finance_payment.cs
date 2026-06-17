using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.lonSpec
{
    public partial class r_sts_finance_payment : DevExpress.XtraReports.UI.XtraReport
    {
        public r_sts_finance_payment()
        {
            InitializeComponent();
        }

        void ofLoaddetail(object sender, string loan_group_code)
        {
            sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcTeller.lonSpec.r_sts_finance_payment_nest"), null, this.GetCurrentColumnValue("RECEIPT_NO"), loan_group_code);
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
    }
}
