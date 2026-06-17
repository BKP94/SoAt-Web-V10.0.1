using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.monthlyPeriod
{
    public partial class r_mwa_rep_mem_share_loan_year_salary : DevExpress.XtraReports.UI.XtraReport
    {
        public r_mwa_rep_mem_share_loan_year_salary()
        {
            InitializeComponent();
        }

        private void coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.monthlyPeriod.r_mwa_rep_mem_share_loan_year_salary_nest_coll");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO") ,this.GetCurrentColumnValue("BALANCE_DATE"),this.GetCurrentColumnValue("CHECK_NEST"));
        }
    }
}
