using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanRequest
{
    public partial class r_ktm_sakol_req_form_02 : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_sakol_req_form_02()
        {
            InitializeComponent();
        }

        private void fee_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanRequest.r_ktm_sakol_req_form_02_nest_fee");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_REQUESTMENT_NO"));
        }

        private void paid_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanRequest.r_ktm_sakol_req_form_02_nest_paid");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_REQUESTMENT_NO"));
        }
    }
}
