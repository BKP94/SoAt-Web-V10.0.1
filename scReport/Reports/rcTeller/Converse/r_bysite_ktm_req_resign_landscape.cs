using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.Converse
{
    public partial class r_bysite_ktm_req_resign_landscape : DevExpress.XtraReports.UI.XtraReport
    {
        public r_bysite_ktm_req_resign_landscape()
        {
            InitializeComponent();
        }

        private void req_resign_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.Converse.r_bysite_ktm_req_resign_landscape_nest_req_resign");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("RESIGN_DOC_NO"));
        }

        private void req_resign_sum_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.Converse.r_bysite_ktm_req_resign_landscape_nest_req_resign_sum");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("RESIGN_DOC_NO"));
        }
    }
}
