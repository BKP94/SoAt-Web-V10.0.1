using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memResign
{
    public partial class r_ktm_labour_resign_req : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_labour_resign_req()
        {
            InitializeComponent();
        }

        private void nest_resign_loan_old_mol_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_ktm_labour_resign_req_nest_resign_loan_old_mol");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("RESIGN_DOC_NO"));
        }

        private void nest_resign_lon_coll_name_mol_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memResign.r_ktm_labour_resign_req_nest_resign_lon_coll_name_mol");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }
    }
}
