using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memColl
{
    public partial class r_tnma_app_change_coll_loan_export : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tnma_app_change_coll_loan_export()
        {
            InitializeComponent();
        }

        private void old_collateral_name_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memColl.r_tnma_app_change_coll_loan_old_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("CHANGE_DOC_NO"));
        }

        private void new_coll_name_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memColl.r_tnma_app_change_coll_loan_new_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("CHANGE_DOC_NO"));
        }
    }
}
