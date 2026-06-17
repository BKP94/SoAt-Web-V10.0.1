using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.endDay
{
    public partial class r_tge_day_balance_at_date : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tge_day_balance_at_date()
        {
            InitializeComponent();
        }

        private void nest_day_balance_by_type_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.endDay.r_tge_day_balance_by_loan_code_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("CONFIRM_DATE"));
        }

       
    }
}
