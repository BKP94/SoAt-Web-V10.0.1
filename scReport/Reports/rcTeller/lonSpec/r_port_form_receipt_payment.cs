using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.lonSpec
{
    public partial class r_port_form_receipt_payment : DevExpress.XtraReports.UI.XtraReport
    {
        public r_port_form_receipt_payment()
        {
            InitializeComponent();
        }

        private void det_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonSpec.r_port_form_receipt_payment_nest_det");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("VOURCHER_NO"));
        }

        private void sum_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonSpec.r_port_form_receipt_payment_nest_sum");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("VOURCHER_NO"));
        }
    }
}
