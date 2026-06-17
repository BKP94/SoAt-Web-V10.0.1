using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.admin
{
    public partial class r_ktm_book_check_debt_3 : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_book_check_debt_3()
        {
            InitializeComponent();
        }

        private void coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.admin.r_ktm_book_check_debt_3_nest_coll");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }
    }
}
