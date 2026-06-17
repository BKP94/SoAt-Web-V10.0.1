using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memResign
{
    public partial class r_tge_member_resign_coll_defect : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tge_member_resign_coll_defect()
        {
            InitializeComponent();
        }

        private void loan_coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tge_member_resign_coll_defect_nest_loan_coll");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void contract_coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_tge_member_resign_coll_defect_nest_contract_coll");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }
    }
}
