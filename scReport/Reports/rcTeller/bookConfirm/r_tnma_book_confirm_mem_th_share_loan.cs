using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.bookConfirm
{
    public partial class r_tnma_book_confirm_mem_th_share_loan : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tnma_book_confirm_mem_th_share_loan()
        {
            InitializeComponent();
        }

        private void loan_nest_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.bookConfirm.r_tnma_book_confirm_mem_th_share_loan_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }
    }
}
