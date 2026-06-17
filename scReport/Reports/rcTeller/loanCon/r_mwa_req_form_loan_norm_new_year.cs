using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanCon
{
    public partial class r_mwa_req_form_loan_norm_new_year : DevExpress.XtraReports.UI.XtraReport
    {
        public r_mwa_req_form_loan_norm_new_year()
        {
            InitializeComponent();
        }

        private void debt_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanCon.r_mwa_req_form_loan_norm_new_year_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_REQUESTMENT_NO"));
        }
    }
}
