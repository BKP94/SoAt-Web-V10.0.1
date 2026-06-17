using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.monthlyPeriod
{
    public partial class r_mwa_max_lon_50 : DevExpress.XtraReports.UI.XtraReport
    {
        public r_mwa_max_lon_50()
        {
            InitializeComponent();
        }

        private void sum_all_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.monthlyPeriod.r_mwa_max_lon_50_nest_sum");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("CONFIRM_DATE"));
        }
    }
}
