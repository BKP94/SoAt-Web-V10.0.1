using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.monthlyPeriod
{
    public partial class r_ktm_mem_share_loan_bal1c_sum : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_mem_share_loan_bal1c_sum()
        {
            InitializeComponent();
        }

        private void sum_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.monthlyPeriod.r_ktm_mem_share_loan_bal1c_sum_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BALANCE_DATE"));
        }

        private void fund_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.monthlyPeriod.r_ktm_mem_share_loan_bal1c_sum_nest_fund");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BALANCE_DATE"));
        }
    }
}
