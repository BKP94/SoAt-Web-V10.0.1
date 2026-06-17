using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanapp
{
    public partial class r_krabi_app_pay_norm : DevExpress.XtraReports.UI.XtraReport
    {
        public r_krabi_app_pay_norm()
        {
            InitializeComponent();
        }
        private void norm_1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var loan_contract_no = sc.value.toString(this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));

            sc.report.setNestReport(this, sender, "scReport.Reports.rcTeller.loanapp.r_krabi_app_pay_norm_nest_norm_1",
                @"
and sc_com_m_receipt.loan_contract_no = {0}", loan_contract_no);
        }

        private void norm_2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var loan_contract_no = sc.value.toString(this.GetCurrentColumnValue("LOAN_CONTRACT_NO"));

            sc.report.setNestReport(this, sender, "scReport.Reports.rcTeller.loanapp.r_krabi_app_pay_norm_nest_norm_2",
                @"
and sc_lon_m_contract_multi_paid.loan_contract_no = {0}", loan_contract_no);
        }
    }
}
