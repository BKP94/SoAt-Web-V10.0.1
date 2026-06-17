using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.agenda
{
    public partial class r_ktm_req_resign_normal : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_req_resign_normal()
        {
            InitializeComponent();
        }

        private void r_ktm_req_resign_dead_nest_loan_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.agenda.r_ktm_req_resign_dead_net_loan_con_no");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("RESIGN_DOC_NO"));
        }

        decimal sum_diff_paid_coop;
        decimal sum_diff_paid_member;

        private void xrLabel27_SummaryReset(object sender, EventArgs e)
        {
            sum_diff_paid_coop = 0;
        }

        private void xrLabel27_SummaryRowChanged(object sender, EventArgs e)
        {
            var diff_share = sc.value.toDecimal(GetCurrentColumnValue("DIFFERENT_SHARELOAN"));
            if(diff_share > 0)
            {
                sum_diff_paid_member += diff_share;
            }
        }

        private void xrLabel27_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = sc.value.toString(sum_diff_paid_member);
            e.Handled = true;
        }

        private void xrLabel28_SummaryReset(object sender, EventArgs e)
        {
            sum_diff_paid_coop = 0;
        }

        private void xrLabel28_SummaryRowChanged(object sender, EventArgs e)
        {
            var diff_share = sc.value.toDecimal(GetCurrentColumnValue("DIFFERENT_SHARELOAN"));
            if (diff_share <= 0)
            {
                sum_diff_paid_coop += diff_share;
            }
        }

        private void xrLabel28_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = sc.value.toString(sum_diff_paid_coop * (-1));
            e.Handled = true;
        }

        private void nest_sum_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.agenda.r_ktm_req_resign_normal_nest_sum");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMTYPE_CONTROL"));
        }
    }
}
