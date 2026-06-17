using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memResign
{
    public partial class r_tnma_member_detail_new1 : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tnma_member_detail_new1()
        {
            InitializeComponent();
        }

        private void nest_member_own_info_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tnma_member_detail_nest_member_own_info");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void nest_member_detail_loan_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tnma_member_detail_nest_member_detail_loan");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void nest_member_detail_loan_coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tnma_member_detail_nest_member_detail_loan_coll");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        }

        private void nest_member_detail_coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tnma_member_detail_nest_member_detail_coll");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void nest_member_detail_dep_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tnma_member_detail_nest_member_detail_dep");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void nest_member_detail_gain_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tnma_member_detail_nest_member_detail_gain");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void nest_member_detail_insure_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tnma_member_detail_nest_member_detail_insure");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void nest_member_refer_2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tnma_member_detail_nest_member_refer_2");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }
    }
}
