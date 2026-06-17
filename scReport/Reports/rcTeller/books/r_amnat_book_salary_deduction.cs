using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.books
{
    public partial class r_amnat_book_salary_deduction : DevExpress.XtraReports.UI.XtraReport
    {
        public r_amnat_book_salary_deduction()
        {
            InitializeComponent();
        }

        private void nest_coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.books.r_amnat_book_salary_deduction_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }
    }
}
