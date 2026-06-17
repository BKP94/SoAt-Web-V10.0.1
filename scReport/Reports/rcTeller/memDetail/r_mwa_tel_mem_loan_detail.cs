using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memDetail
{
    public partial class r_mwa_tel_mem_loan_detail : DevExpress.XtraReports.UI.XtraReport
    {
        public r_mwa_tel_mem_loan_detail()
        {
            InitializeComponent();
        }
        private void nestdetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memDetail.r_mwa_tel_mem_loan_detail_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        }
    }
}
