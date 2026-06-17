using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.books
{
    public partial class r_amnat_debt_collection_book : DevExpress.XtraReports.UI.XtraReport
    {
        public r_amnat_debt_collection_book()
        {
            InitializeComponent();
        }

        private void rep_1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.books.r_amnat_debt_collection_book_nest"); 
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"), this.GetCurrentColumnValue("RECEIVE_YEAR"), this.GetCurrentColumnValue("RECEIVE_MONTH"));
        }
    }
}
