using DevExpress.XtraReports.UI;
using System.Drawing.Printing;

namespace scReport.Reports.rcTeller.lonSpec
{
    public partial class r_amnat_monthly_pay_receipt : XtraReport
    {
        public r_amnat_monthly_pay_receipt()
        {
            InitializeComponent();
        }

        private void del_1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonSpec.r_amnat_monthly_pay_receipt_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"), this.GetCurrentColumnValue("RECEIVE_YEAR"), this.GetCurrentColumnValue("RECEIVE_MONTH"));
        }
    }
}
