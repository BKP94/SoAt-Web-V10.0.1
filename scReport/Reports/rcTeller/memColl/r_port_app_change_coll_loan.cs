using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memColl
{
    public partial class r_port_app_change_coll_loan : DevExpress.XtraReports.UI.XtraReport
    {
        public r_port_app_change_coll_loan()
        {
            InitializeComponent();
        }

        private void old_collateral_name_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memColl.r_port_app_change_coll_loan_old_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("CHANGE_DOC_NO"));
        }
    }
}
