using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memDetail
{
    public partial class r_amnat_member_detail : DevExpress.XtraReports.UI.XtraReport
    {
        public r_amnat_member_detail()
        {
            InitializeComponent();
        }

        private void coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memDetail.r_amnat_member_detail_coll_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }
    }
}
