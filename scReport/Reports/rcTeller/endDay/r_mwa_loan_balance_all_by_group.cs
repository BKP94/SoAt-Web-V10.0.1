using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.endDay
{
    public partial class r_mwa_loan_balance_all_by_group : DevExpress.XtraReports.UI.XtraReport
    {
        public r_mwa_loan_balance_all_by_group()
        {
            InitializeComponent();
        }

        private void fund_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.endDay.r_mwa_loan_balance_all_by_group_nest_fund");
        }

        private void speed_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.endDay.r_mwa_loan_balance_all_by_group_nest_speed");
        }
    }
}
