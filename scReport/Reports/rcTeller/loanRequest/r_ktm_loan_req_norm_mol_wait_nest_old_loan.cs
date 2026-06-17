using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanRequest
{
    public partial class r_ktm_loan_req_norm_mol_wait_nest_old_loan : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_loan_req_norm_mol_wait_nest_old_loan()
        {
            InitializeComponent();
        }

        private void monthly_pay_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRCheckBox checkBox = ((XRCheckBox)sender);

            string currentState = Convert.ToString(checkBox.Report.GetCurrentColumnValue("CLEAR_TARGET"));
            if (currentState == "1")
            {
                checkBox.Checked = true;
            }
            else
                checkBox.Checked = false;
        }
    }
}
