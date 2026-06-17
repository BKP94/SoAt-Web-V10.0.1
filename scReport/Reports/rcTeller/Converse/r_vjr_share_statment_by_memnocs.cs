using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.Converse
{
    public partial class r_vjr_share_statment_by_memnocs : DevExpress.XtraReports.UI.XtraReport
    {
        public r_vjr_share_statment_by_memnocs()
        {
            InitializeComponent();
        }

        private void share_holding_detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.Converse.r_vjr_share_statment_by_memnocs_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"), this.GetCurrentColumnValue("DATEFROM"), this.GetCurrentColumnValue("DATETO"));
        }
    }
}
