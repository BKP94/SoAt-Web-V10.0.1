using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memColl
{
    public partial class r_ktm_coll : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_coll()
        {
            InitializeComponent();
        }

        private void old_collateral_name_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memColl.r_ktm_coll_nest_old_coll_detail");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("CHANGE_DOC_NO"));
        }

        private void new_coll_name_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memColl.r_ktm_coll_nest_new_coll_detail");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("CHANGE_DOC_NO"));
        }
    }
}
