using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanapp
{
    public partial class r_ktm_loan_app : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_loan_app()
        {
            InitializeComponent();
        }

        private void paid_coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanapp.r_ktm_loan_paid_coll_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        }

        private void old_loan_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanapp.r_ktm_loan_req_old_loan_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_REQUESTMENT_NO"));
        }

        private void paid_mpaid_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanapp.r_ktm_loan_paid_mpaid_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
           
        }
    }
}
