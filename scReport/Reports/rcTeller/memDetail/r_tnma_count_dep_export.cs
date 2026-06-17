using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memDetail
{
    public partial class r_tnma_count_dep_export : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tnma_count_dep_export()
        {
            InitializeComponent();
        }

        private void sumdep_nest_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memDetail.r_tnma_count_dep_export_nestdep");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("]CONFIRM_DATE"));
        }
    }
}
