using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanRequest
{
    public partial class r_ktm_atm_loan_req_approve_by_group : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_atm_loan_req_approve_by_group()
        {
            InitializeComponent();
        }

        private void old_loan_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanRequest.r_ktm_atm_loan_req_month_by_date_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_REQUESTMENT_NO"));
        }
    }
}
