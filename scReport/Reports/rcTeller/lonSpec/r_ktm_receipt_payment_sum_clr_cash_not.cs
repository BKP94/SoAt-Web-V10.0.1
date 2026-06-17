using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.lonSpec
{
    public partial class r_ktm_receipt_payment_sum_clr_cash_not : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_receipt_payment_sum_clr_cash_not()
        {
            InitializeComponent();
        }

        private void cash_not_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonSpec.r_ktm_receipt_payment_sum_clr_cash_not_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("RECEIPT_DATE"), this.GetCurrentColumnValue("BRANCH_ID"));
        }
    }
}
