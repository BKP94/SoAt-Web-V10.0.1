using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanapp
{
    public partial class r_mwa_app_by_conno_rush : DevExpress.XtraReports.UI.XtraReport
    {
        public r_mwa_app_by_conno_rush()
        {
            InitializeComponent();
        }

        private void paid_coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanapp.r_mwa_app_by_conno_rush_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        }
    }
}
