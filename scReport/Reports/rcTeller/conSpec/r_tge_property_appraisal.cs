using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.conSpec
{
    public partial class r_tge_property_appraisal : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tge_property_appraisal()
        {
            InitializeComponent();
        }

        private void nest_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.conSpec.r_tge_property_appraisal_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("DOC_NO"));
        }
    }
}
