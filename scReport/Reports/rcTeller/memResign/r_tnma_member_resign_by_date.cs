using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memResign
{
    public partial class r_tnma_member_resign_by_date : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tnma_member_resign_by_date()
        {
            InitializeComponent();
        }

        private void nest_resign_coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_ktm_aero_member_req_resign_nest_coll");
            //sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("REF_OWN_NO"));
        }
    }
}
