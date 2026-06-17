using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memColl
{
    public partial class r_ktm_trans_loan_to_coll_receive : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_trans_loan_to_coll_receive()
        {
            InitializeComponent();
        }

        private void coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memColl.r_ktm_trans_loan_to_coll_receive_nest_coll");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("TRANSFER_DOC_NO"));
        }
    }
}
