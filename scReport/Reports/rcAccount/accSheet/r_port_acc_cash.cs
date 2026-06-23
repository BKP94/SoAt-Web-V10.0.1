using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcAccount.accSheet
{
    public partial class r_port_acc_cash : DevExpress.XtraReports.UI.XtraReport
    {
        public r_port_acc_cash()
        {
            InitializeComponent();
        }

        private void acc_cash_nest_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcAccount.accSheet.r_port_acc_cash_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("START_DATE"), this.GetCurrentColumnValue("END_DATE"));
        }
    }
}
