using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanRequest
{
    public partial class r_ktm_loan_req_month_by_entry_id : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_loan_req_month_by_entry_id()
        {
            InitializeComponent();
        }

        private void old_loan_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanRequest.r_ktm_loan_req_month_by_entry_id_nest_old_loan");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_REQUESTMENT_NO"));
        }

        private void coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanRequest.r_ktm_loan_req_month_by_entry_id_nest_coll");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_REQUESTMENT_NO"));
        }
    }
}
