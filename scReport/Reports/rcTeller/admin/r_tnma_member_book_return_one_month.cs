using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.admin
{
    public partial class r_tnma_member_book_return_one_month : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tnma_member_book_return_one_month()
        {
            InitializeComponent();
        }

        private void keeping_type_group_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.admin.r_tnma_member_book_return_one_month_nest_1");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }
    }
}
