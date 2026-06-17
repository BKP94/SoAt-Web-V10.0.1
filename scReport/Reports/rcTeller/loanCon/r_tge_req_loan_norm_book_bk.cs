using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanCon
{
    public partial class r_tge_req_loan_norm_book_bk : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tge_req_loan_norm_book_bk()
        {
            InitializeComponent();
        }

        private void xrSubreport1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanCon.r_tge_req_loan_norm_book_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_REQUESTMENT_NO"));
        }
    }
}

