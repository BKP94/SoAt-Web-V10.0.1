using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.books
{
    public partial class r_ktm_book_shrlon_stroiet_wvo : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_book_shrlon_stroiet_wvo()
        {
            InitializeComponent();
        }

        private void loan_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.books.r_ktm_book_shrlon_stroiet_wvo_nest_loan");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void dep_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.books.r_ktm_book_shrlon_stroiet_wvo_nest_dep");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void share_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.books.r_ktm_book_shrlon_stroiet_wvo_nest_share");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }
    }
}
