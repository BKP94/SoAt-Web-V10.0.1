using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memDetail
{
    public partial class r_book_share_loan_deposit_atdate_dep : DevExpress.XtraReports.UI.XtraReport
    {
        public r_book_share_loan_deposit_atdate_dep()
        {
            InitializeComponent();
        }

        private void xrSubreport1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memDetail.r_book_share_loan_deposit_atdate_dep_nest");
            sc.report.ofBeforePrint(this, sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void xrSubreport_dep_2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memDetail.r_book_share_loan_deposit_atdate_dep_nest_02");
            sc.report.ofBeforePrint(this, sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void xrSubreport_sum_dep_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memDetail.r_book_share_loan_deposit_atdate_dep_nest_03");
            sc.report.ofBeforePrint(this, sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }
    }
}
