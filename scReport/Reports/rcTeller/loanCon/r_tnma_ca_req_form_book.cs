using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanCon
{
    public partial class r_tnma_ca_req_form_book : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tnma_ca_req_form_book()
        {
            InitializeComponent();
        }

        private void r_tnma_ca_req_book_realamount_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var loan_requestment_no = sc.value.toString(this.GetCurrentColumnValue("LOAN_REQUESTMENT_NO"));
            /*sc.report._nestReplace = vals;
            sc.report.setNestReport(this, sender, "scReport.Reports.rcTeller.loanCon.r_tnma_ca_req_book_realamount");
            vals.Add("!loan_requestment_no!", loan_requestment_no);*/
        }
    }
}
