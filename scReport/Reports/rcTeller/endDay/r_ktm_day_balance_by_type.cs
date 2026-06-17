using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.endDay
{
    public partial class r_ktm_day_balance_by_type : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_day_balance_by_type()
        {
            InitializeComponent();
        }

        private void balance_by_type_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.endDay.r_ktm_day_balance_by_type_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue(""));
        }

        private void sex_count_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.endDay.r_ktm_day_balance_by_type_nest_sex_count");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue(""));
        }

        private void count_mem_loan_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.endDay.r_ktm_day_balance_by_type_nest_mem_loan");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue(""));
        }
    }
}
