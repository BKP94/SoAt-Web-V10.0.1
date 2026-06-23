using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcAccount.invest
{
    public partial class r_invest_lon_sum : DevExpress.XtraReports.UI.XtraReport
    {
        public r_invest_lon_sum()
        {
            InitializeComponent();
        }

        private void nest_day_balance_by_type_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcAccount.invest.r_invest_lon_sum_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue(""));
        }

        private void nest_sex_count_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcAccount.invest.r_invest_lon_sum_nest_sex_count");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue(""));
        }

        private void nest_day_balance_count_mem_loan_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcAccount.invest.r_invest_lon_sum_nest_count_mem_loan");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue(""));
        }
    }
}
