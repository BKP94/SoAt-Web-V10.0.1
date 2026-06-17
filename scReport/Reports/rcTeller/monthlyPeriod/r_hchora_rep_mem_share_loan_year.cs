using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.monthlyPeriod
{
    public partial class r_hchora_rep_mem_share_loan_year : DevExpress.XtraReports.UI.XtraReport
    {
        public r_hchora_rep_mem_share_loan_year()
        {
            InitializeComponent();

        }

        private void nest_sum_emer_BeforePrint_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.monthlyPeriod.r_hchora_rep_mem_share_loan_year_nest_emer");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BALANCE_DATE"), this.GetCurrentColumnValue("LOAN_GROUP_CODE"), this.GetCurrentColumnValue("MEMBER_GROUP_NO"));
        }

        private void nest_sum_norm_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.monthlyPeriod.r_hchora_rep_mem_share_loan_year_nest_norm");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BALANCE_DATE"), this.GetCurrentColumnValue("LOAN_GROUP_CODE"), this.GetCurrentColumnValue("MEMBER_GROUP_NO"));
        }

        private void nest_sum_spec_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.monthlyPeriod.r_hchora_rep_mem_share_loan_year_nest_spec");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BALANCE_DATE"), this.GetCurrentColumnValue("LOAN_GROUP_CODE"), this.GetCurrentColumnValue("MEMBER_GROUP_NO"));
        }
    }
}
