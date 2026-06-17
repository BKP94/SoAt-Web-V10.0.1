using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memDetail
{
    public partial class r_tnma_loan_fee_group : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tnma_loan_fee_group()
        {
            InitializeComponent();
        }

        private void sum_nest_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memDetail.r_tnma_loan_fee_group_nest");

            var membergroupNo1 = this.GetCurrentColumnValue("MEMBER_GROUP_NO");
            var LoantypeNo1 = this.GetCurrentColumnValue("LOAN_TYPE");

            sc.report.ofBeforePrint(this, (XRSubreport)sender, membergroupNo1 , LoantypeNo1);
        }
    }
}
