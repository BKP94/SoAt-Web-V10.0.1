using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.revAnaly
{
    public partial class r_ktm_share_del_det : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_share_del_det()
        {
            InitializeComponent();
        }

        private void det_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, ("scReport.Reports.rcTeller.revAnaly.r_ktm_share_del_det_nest"));
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }
    }
}
