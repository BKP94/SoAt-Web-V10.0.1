using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.lonSpec
{
    public partial class r_ktm_receipt_payment_mobile : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_receipt_payment_mobile()
        {
            InitializeComponent();
        }

        private void sum_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonSpec.r_ktm_receipt_payment_mobile_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("RECEIPT_DATE") ,this.GetCurrentColumnValue("BRANCH_ID"));
        }

        private void verify_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonSpec.r_ktm_receipt_payment_mobile_nest_verify");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("RECEIPT_DATE"), this.GetCurrentColumnValue("BRANCH_ID"));
        }
    }
}
