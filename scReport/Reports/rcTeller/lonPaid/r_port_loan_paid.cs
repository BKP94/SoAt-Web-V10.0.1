using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.lonPaid
{
    public partial class r_port_loan_paid : DevExpress.XtraReports.UI.XtraReport
    {
        public r_port_loan_paid()
        {
            InitializeComponent();
        }

        private void nest_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.lonPaid.r_port_loan_paid_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("BEGINING_OF_CONTRACT"), this.GetCurrentColumnValue("LOAN_TYPE"), this.GetCurrentColumnValue("DOCUMENT_GROUP"), this.GetCurrentColumnValue("DOCUMENT_STATUS"));
        }
    }
}
