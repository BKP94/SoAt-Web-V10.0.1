using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.bookConfirm
{
    public partial class r_tge_confirm_letter_address : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tge_confirm_letter_address()
        {
            InitializeComponent();
        }

        private void nest_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.bookConfirm.r_tge_confirm_letter_nest");
            sc.report.ofBeforePrint(this, sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"), this.GetCurrentColumnValue("CONFIRM_DATE"));
        }

        private void nest_2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.bookConfirm.r_tge_confirm_letter_nest");
            sc.report.ofBeforePrint(this, sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"), this.GetCurrentColumnValue("CONFIRM_DATE"));
        }
    }
}
