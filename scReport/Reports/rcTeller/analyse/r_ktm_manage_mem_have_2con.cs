using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.analyse
{
    public partial class r_ktm_manage_mem_have_2con : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_manage_mem_have_2con()
        {
            InitializeComponent();
        }

        private void loan_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.analyse.r_ktm_manage_mem_have_2con_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"), this.GetCurrentColumnValue("LOAN_TYPE"));
        }
    }
}
