using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memDetail
{
    public partial class r_amnat_form_paymentvoucher : DevExpress.XtraReports.UI.XtraReport
    {
        public r_amnat_form_paymentvoucher()
        {
            InitializeComponent();
        }

        private void payment_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memDetail.r_amnat_form_paymentvoucher_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("VOURCHER_NO"));
        }
    }

}


