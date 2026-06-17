using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.lonPaid
{
    public partial class r_tnma_loan_paid_sum : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tnma_loan_paid_sum()
        {
            InitializeComponent();
        }

        private void clr_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonPaid.r_port_loan_paid_sum_nest_clr");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BEGINING_OF_CONTRACT"), this.GetCurrentColumnValue("LOAN_TYPE"));
        }

        private void clr_sum_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonPaid.r_port_loan_paid_sum_nest_clr_sum");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BEGINING_OF_CONTRACT"));
        }

        private void chq_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var cheque_amount = sc.value.toDecimal(this.GetCurrentColumnValue("CHEQUE_AMOUNT"));

            var check_nest = cheque_amount;

            if (check_nest == 0)
            {
                ;
            }
            else
            {
                sc.report.setResource(sender, "scReport.Reports.rcTeller.lonPaid.r_port_loan_paid_sum_nest_chq");
                sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BEGINING_OF_CONTRACT"));
            }
        }
    }
}
