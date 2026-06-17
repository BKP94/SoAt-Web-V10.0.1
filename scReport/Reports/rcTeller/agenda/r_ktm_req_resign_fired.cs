using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.agenda
{
    public partial class r_ktm_req_resign_fired : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_req_resign_fired()
        {
            InitializeComponent();
        }

        private void nest_loan_conno_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.agenda.r_ktm_req_resign_nest_loan_con_no_with_blacklist");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("RESIGN_DOC_NO"));
        }

        private void nest_loan_coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.agenda.r_ktm_req_resign_nest_loan_coll");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("RESIGN_DOC_NO"));
        }
    }
}
