using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.lonPaid
{
    public partial class r_port_loan_paid_sum_by_month : DevExpress.XtraReports.UI.XtraReport
    {
        public r_port_loan_paid_sum_by_month()
        {
            InitializeComponent();
        }

        private void sum_nest_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonPaid.r_port_loan_paid_sum_by_month_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("REP_YEAR"), this.GetCurrentColumnValue("REP_MONTH"));
        }
    }
}
