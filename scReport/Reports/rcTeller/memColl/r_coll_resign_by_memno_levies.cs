using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memColl
{
    public partial class r_coll_resign_by_memno_levies : DevExpress.XtraReports.UI.XtraReport
    {
        public r_coll_resign_by_memno_levies()
        {
            InitializeComponent();
        }

        private void coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memColl.r_coll_resign_by_memno_levies_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));
        }
    }
}
