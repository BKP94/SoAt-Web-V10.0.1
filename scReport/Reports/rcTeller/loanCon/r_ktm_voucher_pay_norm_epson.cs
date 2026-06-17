using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanCon
{
    public partial class r_ktm_voucher_pay_norm_epson : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_voucher_pay_norm_epson()
        {
            InitializeComponent();
        }

        private void conno_nest_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanCon.r_ktm_voucher_pay_norm_epson_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_REQUESTMENT_NO"));
        }
    }
}
