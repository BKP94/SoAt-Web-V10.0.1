using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanapp
{
    public partial class r_tge_loan_registered : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tge_loan_registered()
        {
            InitializeComponent();

        }
            private void xrSubreport1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
            {
                sc.report.setResource(sender, "scReport.Reports.rcTeller.loanapp.r_tge_loan_create_clr");
                sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
            }

        private void xrSubreport3_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanapp.r_tge_loan_create_coll");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        }
        private void xrSubreport2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanapp.r_tge_loan_create_mpaid");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        
        }
    }
}


