using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.admin
{
    public partial class r_ktm_member_book_trans_loan_to_coll01 : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_member_book_trans_loan_to_coll01()
        {
            InitializeComponent();
        }

        private void coll_name_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.admin.r_ktm_member_book_trans_loan_to_coll01_nest_coll_name");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("TRANSFER_DOC_NO"));
        }

        private void coll_receive_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.admin.r_ktm_member_book_trans_loan_to_coll01_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("TRANSFER_DOC_NO"));
        }
    }
}
