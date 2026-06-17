using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanRequest
{
    public partial class r_ktm_sakol_req_form_02_nest_history : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_sakol_req_form_02_nest_history()
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
