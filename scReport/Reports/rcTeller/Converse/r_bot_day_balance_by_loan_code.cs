using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.Converse
{
    public partial class r_bot_day_balance_by_loan_code : DevExpress.XtraReports.UI.XtraReport
    {
        public r_bot_day_balance_by_loan_code()
        {
            InitializeComponent();
        }

        private void nest_day_balance_by_type_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.Converse.r_bot_day_balance_by_loan_code_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue(""));
        }

        private void nest_sex_count_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.Converse.r_bot_day_balance_by_loan_code_nest_sex_count");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue(""));
        }

        private void nest_day_balance_count_mem_loan_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.Converse.r_bot_day_balance_by_loan_code_nest_count_mem_loan");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue(""));
        }
    }
}
