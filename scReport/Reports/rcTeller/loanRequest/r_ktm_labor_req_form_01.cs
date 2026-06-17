using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanRequest
{
    public partial class r_ktm_labor_req_form_01 : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_labor_req_form_01()
        {
            InitializeComponent();
        }

        private void month_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanRequest.r_ktm_sakol_req_form_02_nest_month");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_REQUESTMENT_NO"));
        }
    }
}
