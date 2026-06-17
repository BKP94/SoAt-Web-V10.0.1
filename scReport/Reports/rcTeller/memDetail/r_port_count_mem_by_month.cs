using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memDetail
{
    public partial class r_port_count_mem_by_month : DevExpress.XtraReports.UI.XtraReport
    {
        public r_port_count_mem_by_month()
        {
            InitializeComponent();
        }

        private void nest_last_month_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memDetail.r_port_count_mem_by_month_nest_last");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("CONFIRM_DATE"));
        }

        private void nest_cause_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memDetail.r_port_count_mem_by_month_nest_cause");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("CONFIRM_DATE"));
        }
    }
}
