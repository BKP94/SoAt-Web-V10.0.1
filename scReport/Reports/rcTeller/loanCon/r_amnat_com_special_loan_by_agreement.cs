using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanCon
{
    public partial class r_amnat_com_special_loan_by_agreement : DevExpress.XtraReports.UI.XtraReport
    {
        public r_amnat_com_special_loan_by_agreement()
        {
            InitializeComponent();
        }

        private void name_1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanCon.r_amnat_com_special_loan_by_agreement_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"), this.GetCurrentColumnValue("LOAN_REQUESTMENT_NO"));
        }
    }
}
