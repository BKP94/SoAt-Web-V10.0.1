using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.admin
{
    public partial class r_tnma_coll_book_return_one_month : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tnma_coll_book_return_one_month()
        {
            InitializeComponent();
        }

        private void coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.admin.r_ktm_book_alert_mem_loan_1_nest_coll");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"), this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }
    }
}
