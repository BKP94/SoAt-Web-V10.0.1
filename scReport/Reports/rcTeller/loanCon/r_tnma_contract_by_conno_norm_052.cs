using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanCon
{
    public partial class r_tnma_contract_by_conno_norm_052 : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tnma_contract_by_conno_norm_052()
        {
            InitializeComponent();
        }

        //private void r_nest_coll_BeforePrint_1(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    sc.report.setResource(sender, "scReport.Reports.rcTeller.loanCon.r_tnma_contract_by_conno_norm_nest_05");
        //    sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        //}

        //private void r_nest_coll1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    sc.report.setResource(sender, "scReport.Reports.rcTeller.loanCon.r_tnma_contract_by_conno_norm_nest_051");
        //    sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        //}

        //private void r_nest_coll1_BeforePrint_1(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    sc.report.setResource(sender, "scReport.Reports.rcTeller.loanCon.r_tnma_contract_by_conno_norm_nest_05");
        //    sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        //}

        private void r_nest_coll_list_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanCon.r_tnma_contract_by_conno_norm_051_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        }

        private void r_nest_coll_list_next_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanCon.r_tnma_contract_by_conno_norm_05_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        }

        private void r_nest_coll_oth_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanCon.r_tnma_contract_by_conno_norm_oth_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        }
    }
}
