using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.bookConfirm
{
    public partial class r_port_book_confirm_mem : DevExpress.XtraReports.UI.XtraReport
    {
        public r_port_book_confirm_mem()
        {
            InitializeComponent();
        }

        private void mem_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.bookConfirm.r_port_book_confirm_mem_nest_mem");
            sc.report.ofBeforePrint(this, sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"), this.GetCurrentColumnValue("CONFIRM_DATE"));
        }

        private void auditor_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.bookConfirm.r_port_book_confirm_mem_nest_auditor");
            sc.report.ofBeforePrint(this, sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"), this.GetCurrentColumnValue("CONFIRM_DATE"));
        }
    }
}
