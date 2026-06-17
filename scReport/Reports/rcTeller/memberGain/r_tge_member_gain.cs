using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memberGain
{
    public partial class r_tge_member_gain : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tge_member_gain()
        {
            InitializeComponent();
        }

        private void gain_name_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memberGain.r_tge_member_gain_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("CHANGE_DOC_NO"));
        }
    }
}
