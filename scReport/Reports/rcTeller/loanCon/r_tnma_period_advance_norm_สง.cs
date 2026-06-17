using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanCon
{
    public partial class r_tnma_period_advance_norm_สง : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tnma_period_advance_norm_สง()
        {
            InitializeComponent();
        }



        private void r_nest_priod_advance_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanCon.r_tnma_period_advance_norm_สง_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        }
    }
}
