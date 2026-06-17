using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanapp
{
    public partial class r_ktm_loan_wait_approved_cheuqe_conno : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_loan_wait_approved_cheuqe_conno()
        {
            InitializeComponent();
        }
        private void xrSubreport1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //srvReport.bindSubreport(this, (XRSubreport)sender);
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanapp.r_ktm_loan_wait_approved_cheuqe_conno_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_REQUESTMENT_NO"));

        }
    }
}
