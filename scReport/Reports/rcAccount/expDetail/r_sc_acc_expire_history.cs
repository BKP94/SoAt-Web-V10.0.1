using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcAccount.expDetail
{
    public partial class r_sc_acc_expire_history : DevExpress.XtraReports.UI.XtraReport
    {
        public r_sc_acc_expire_history()
        {
            InitializeComponent();
        }

        private void expire_history_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcAccount.expDetail.r_sc_acc_expire_history_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MATERIAL_ID"));
        }
    }
}
