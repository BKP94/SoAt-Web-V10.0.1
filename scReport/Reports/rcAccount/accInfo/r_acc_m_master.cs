using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcAccount.accInfo
{
    public partial class r_acc_m_master : DevExpress.XtraReports.UI.XtraReport
    {
        public r_acc_m_master()
        {
            InitializeComponent();
        }

        private void xrLabel10_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //srvReport.setNumDuplicateRow(this, "account_group_name", null, sender);
            //srvReport.setHideDuplicateRow(this, "account_group_name", null, sender);
        }

    }
}
