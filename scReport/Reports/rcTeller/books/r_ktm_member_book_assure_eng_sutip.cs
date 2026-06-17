using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.books
{
    public partial class r_ktm_member_book_assure_eng_sutip : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_member_book_assure_eng_sutip()
        {
            InitializeComponent();
        }

        private void Cooperative_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.books.r_ktm_member_book_assure_eng_sutip_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void assure_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.books.r_ktm_member_book_assure_eng_sutip_nest_loan");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }
    }
}
