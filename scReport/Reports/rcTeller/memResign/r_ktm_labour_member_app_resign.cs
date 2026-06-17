using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memResign
{
    public partial class r_ktm_labour_member_app_resign : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_labour_member_app_resign()
        {
            InitializeComponent();
        }

        private void nest_tnl_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_ktm_labour_member_app_resign_nest_tnl");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        
        }
    }
}
