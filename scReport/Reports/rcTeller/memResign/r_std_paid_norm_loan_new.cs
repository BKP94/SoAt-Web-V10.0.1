using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memResign
{
    public partial class r_std_paid_norm_loan_new : DevExpress.XtraReports.UI.XtraReport
    {
        public r_std_paid_norm_loan_new()
        {
            InitializeComponent();
        }

        private void r_tnma_member_detail_nest_loan_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tnma_member_detail_nest_loan");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        }

        private void r_tnma_member_detail_nest_clearother_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tnma_member_detail_nest_clearother");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        }

        private void nest_member_detail_loan_ref_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tnma_member_detail_nest_loan_ref");

            var loanContractNo1 = this.GetCurrentColumnValue("LOAN_CONTRACT_NO");
            var loanContractNo2 = this.GetCurrentColumnValue("LOAN_CONTRACT_NO_2");

            sc.report.ofBeforePrint(this, (XRSubreport)sender, loanContractNo1);

        }
        private void r_tnma_member_detail_nest_loancoll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tnma_member_detail_nest_loancoll");
            var loanContractNo1 = this.GetCurrentColumnValue("LOAN_CONTRACT_NO");
            var loanContractNo2 = this.GetCurrentColumnValue("LOAN_CONTRACT_NO_2");

            sc.report.ofBeforePrint(this, (XRSubreport)sender, loanContractNo1);
        }

    }
}
