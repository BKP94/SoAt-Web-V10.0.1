using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memResign
{
    public partial class r_ktm_member_resign_report : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_member_resign_report()
        {
            InitializeComponent();
        }

        private void coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_ktm_member_resign_report_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("APPROVE_DATE") , this.GetCurrentColumnValue("MEMBER_GROUP_TYPE"));
        }
    }
}
