using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.monthlyPeriod
{
    public partial class r_krabi_sum_sh_loan_balance : DevExpress.XtraReports.UI.XtraReport
    {
        public r_krabi_sum_sh_loan_balance()
        {
            InitializeComponent();
        }

        private void norm_balance_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.monthlyPeriod.r_krabi_sum_sh_loan_balance_nest_norm");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBER_GROUP_NO"), this.GetCurrentColumnValue("BALANCE_DATE"));
        }

        private void emer_balance_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.monthlyPeriod.r_krabi_sum_sh_loan_balance_nest_emer");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBER_GROUP_NO"), this.GetCurrentColumnValue("BALANCE_DATE"));
        }

        private void special_balance_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.monthlyPeriod.r_krabi_sum_sh_loan_balance_nest_spec");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBER_GROUP_NO"), this.GetCurrentColumnValue("BALANCE_DATE"));
        }
    }
}
