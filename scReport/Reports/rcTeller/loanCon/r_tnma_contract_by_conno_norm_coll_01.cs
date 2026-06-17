using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanCon
{
    public partial class r_tnma_contract_by_conno_norm_coll_01 : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tnma_contract_by_conno_norm_coll_01()
        {
            InitializeComponent();
        }

        private void nest_coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanCon.r_tnma_contract_by_conno_norm_coll_01_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"), this.GetCurrentColumnValue("REF_OWN_NO"));
        }
    }
}
