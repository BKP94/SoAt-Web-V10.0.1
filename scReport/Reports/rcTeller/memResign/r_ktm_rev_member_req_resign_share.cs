using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memResign
{
    public partial class r_ktm_rev_member_req_resign_share : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_rev_member_req_resign_share()
        {
            InitializeComponent();
        }

        private void nest_resign_coll_mem_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_ktm_rev_member_req_resign_share_nest_coll_mem");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("REF_OWN_NO"));
        }
    }
}
