using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcAccount.invest
{
    public partial class r_invest_lon_sum_at_date : DevExpress.XtraReports.UI.XtraReport
    {
        public r_invest_lon_sum_at_date()
        {
            InitializeComponent();
        }

        private void sum_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcAccount.invest.r_invest_lon_sum_at_date_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BALANCE_DATE"));
        }

        private void fund_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcAccount.invest.r_invest_lon_sum_at_date_nest_fund");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BALANCE_DATE"));
        }
    }
}
