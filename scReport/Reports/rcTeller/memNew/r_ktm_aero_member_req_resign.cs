using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memNew
{
    public partial class r_ktm_aero_member_req_resign : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_aero_member_req_resign()
        {
            InitializeComponent();
        }

        private void coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memNew.r_ktm_aero_member_req_resign_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("REF_OWN_NO"));
        }
    }
}
