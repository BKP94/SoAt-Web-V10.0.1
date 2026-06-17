using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memStockdue
{
    public partial class r_ktm_member_record : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_member_record()
        {
            InitializeComponent();
        }
        private void nest_coll_AfterPrint(object sender, EventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memStockdue.r_ktm_member_record_nest_coll");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void nest_concern_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memStockdue.r_ktm_member_record_nest_concern");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void share_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memStockdue.r_ktm_member_record_nest_share");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO") ,this.GetCurrentColumnValue("ADTM_BDATE"),this.GetCurrentColumnValue("ADTM_EDATE"));
        }

        private void loan_BeforePrint(object sender, EventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memStockdue.r_ktm_member_record_nest_loan");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO") ,this.GetCurrentColumnValue("ADTM_BDATE"), this.GetCurrentColumnValue("ADTM_EDATE"));
        }
    }
}
