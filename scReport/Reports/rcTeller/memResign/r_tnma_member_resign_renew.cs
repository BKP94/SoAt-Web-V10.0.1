using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memResign
{
    public partial class r_tnma_member_resign_renew : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tnma_member_resign_renew()
        {
            InitializeComponent();
        }

        private void nest_isr_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tnma_member_resign_renew_nest_isr2");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void nest_lonem_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tnma_member_resign_renew_nest_lonem");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void nest_lonnm_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tnma_member_resign_renew_nest_lonnm");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void nest_lonsp_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tnma_member_resign_renew_nest_lonsp");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void nest_loanall_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
        //    sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tnma_member_resign_renew_nest_lonall");
        //    sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue(""), this.GetCurrentColumnValue(""));
        }

        private void nest_loan_coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tnma_member_resign_renew_nest_loncoll");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void nes_loanallnew_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
                sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tnma_member_resign_renew_nest_lonallnew");
                sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue(""), this.GetCurrentColumnValue(""));
        }

        private void nest_ref_mem_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tnma_member_resign_renew_nest_memref");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }
    }
}
