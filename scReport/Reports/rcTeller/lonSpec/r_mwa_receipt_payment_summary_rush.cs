using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.lonSpec
{
    public partial class r_mwa_receipt_payment_summary_rush : DevExpress.XtraReports.UI.XtraReport
    {
        public r_mwa_receipt_payment_summary_rush()
        {
            InitializeComponent();
        }

        private void sum_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonSpec.r_mwa_receipt_payment_summary_rush_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("RECEIPT_DATE") ,this.GetCurrentColumnValue("BRANCH_ID") ,this.GetCurrentColumnValue("MONEY_TYPE_ID"));
        }
    }
}
