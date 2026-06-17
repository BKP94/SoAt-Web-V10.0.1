using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.admin
{
    public partial class r_ktm_book_trans_loan_list_2 : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_book_trans_loan_list_2()
        {
            InitializeComponent();
        }

        private void coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.admin.r_ktm_book_trans_loan_list_2_nest_coll");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"), this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }
    }
}
