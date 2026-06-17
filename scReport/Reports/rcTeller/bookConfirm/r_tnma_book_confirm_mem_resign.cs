using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.bookConfirm
{
    public partial class r_tnma_book_confirm_mem_resign : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tnma_book_confirm_mem_resign()
        {
            InitializeComponent();
        }

        private void coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.bookConfirm.r_tnma_book_confirm_mem_resign_nest");
            sc.report.ofBeforePrint(this, sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        }
    }
}
