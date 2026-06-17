using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.monthlyPeriod
{
    public partial class r_ktm_rep_mem_share_loan_year : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_rep_mem_share_loan_year()
        {
            InitializeComponent();
        }

        private void nest_a_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.monthlyPeriod.r_ktm_rep_mem_share_loan_year_nest_a");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BALANCE_DATE"), this.GetCurrentColumnValue("LOAN_GROUP_CODE"));
        }

        private void nest_b_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.monthlyPeriod.r_ktm_rep_mem_share_loan_year_nest_b");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BALANCE_DATE"), this.GetCurrentColumnValue("LOAN_GROUP_CODE"));
        }

        private void nest_c_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.monthlyPeriod.r_ktm_rep_mem_share_loan_year_nest_c");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BALANCE_DATE"), this.GetCurrentColumnValue("LOAN_GROUP_CODE"));
        }
    }
}
