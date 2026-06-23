using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcAccount.accmoneysheet
{
    public partial class r_accmoneysheet_asset : DevExpress.XtraReports.UI.XtraReport
    {
        public r_accmoneysheet_asset()
        {
            InitializeComponent();
        }

        private void asset_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcAccount.accmoneysheet.r_accmoneysheet_asset_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MONEYSHEET_CODE"));
        }

        private void debt_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcAccount.accmoneysheet.r_accmoneysheet_asset_nest_debt");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MONEYSHEET_CODE"));
        }

        private void Cooperative_capital_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcAccount.accmoneysheet.r_accmoneysheet_asset_nest_Cooperative_capital");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MONEYSHEET_CODE"));
        }
    }
}
