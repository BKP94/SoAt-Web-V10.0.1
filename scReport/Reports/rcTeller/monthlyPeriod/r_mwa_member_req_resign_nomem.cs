using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.monthlyPeriod
{
    public partial class r_mwa_member_req_resign_nomem : DevExpress.XtraReports.UI.XtraReport
    {
        public r_mwa_member_req_resign_nomem()
        {
            InitializeComponent();
        }

        private void loan_resign_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var principal_balance = sc.value.toString(this.GetCurrentColumnValue("PRINCIPAL_BALANCE"));

            if(principal_balance == "0")
            {
                sc.report.setResource(sender, "scReport.Reports.rcTeller.monthlyPeriod.r_mwa_member_req_resign_nomem_nest_text");
                sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("RESIGN_DOC_NO"));
            }
            else
            {
                sc.report.setResource(sender, "scReport.Reports.rcTeller.monthlyPeriod.r_mwa_member_req_resign_nomem_nest_loan");
                sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("RESIGN_DOC_NO"));
            }
            
        }

        private void resign_coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var coll_amount = sc.value.toString(this.GetCurrentColumnValue("COLL_AMOUNT"));

            if(coll_amount == "0")
            {
                sc.report.setResource(sender, "scReport.Reports.rcTeller.monthlyPeriod.r_mwa_member_req_resign_nomem_nest_text_resige");
                sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("RESIGN_DOC_NO"));
            }
            else
            {
                sc.report.setResource(sender, "scReport.Reports.rcTeller.monthlyPeriod.r_mwa_member_req_resign_nomem_nest_resign_loncoll");
                sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("RESIGN_DOC_NO"));
            }
        }
    }
}
