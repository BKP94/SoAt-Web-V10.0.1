using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanRequest
{
    public partial class r_tge_loan_app_sum : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tge_loan_app_sum()
        {
            InitializeComponent();
        }

        private void CLR_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanRequest.r_tge_loan_app_sum_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BEGINING_OF_CONTRACT"));
        }
    }
}
