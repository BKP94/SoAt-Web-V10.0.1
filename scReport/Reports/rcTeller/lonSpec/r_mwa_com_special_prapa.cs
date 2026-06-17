using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.lonSpec
{
    public partial class r_mwa_com_special_prapa : DevExpress.XtraReports.UI.XtraReport
    {
        public r_mwa_com_special_prapa()
        {
            InitializeComponent();
        }

        private void loan_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonSpec.r_mwa_com_special_prapa_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("RECEIPT_NO"));
        }
    }
}
