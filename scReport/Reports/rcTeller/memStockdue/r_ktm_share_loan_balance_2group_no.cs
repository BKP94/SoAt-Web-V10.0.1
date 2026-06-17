using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memStockdue
{
    public partial class r_ktm_share_loan_balance_2group_no : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_share_loan_balance_2group_no()
        {
            InitializeComponent();
        }


        void ofLoadMember(object sender, string loan_group_code)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memStockdue.r_ktm_share_loan_balance_2group_no_nest_conno");
            sc.report.dataBind(this, sender, null, this.GetCurrentColumnValue("MEMBERSHIP_NO"), loan_group_code);
        }
        private void m01_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoadMember(sender, "01");
        }
        private void m02_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoadMember(sender, "02");
        }
        private void m03_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoadMember(sender, "03");
        }

        void ofLoadGroupno(object sender, string sqlWhere, params object[] args)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.memStockdue.r_ktm_share_loan_balance_2group_no_nest_grpno");
            sc.report.dataBind(this, sender, sqlWhere, args);
        }
        private void g01_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoadGroupno(sender, "and sc_mem_m_membership_registered.member_group_no = {1}", "01", this.GetCurrentColumnValue("member_group_no".ToUpper()));
        }
        private void g02_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoadGroupno(sender, "and sc_mem_m_membership_registered.member_group_no = {1}", "02", this.GetCurrentColumnValue("member_group_no".ToUpper()));
        }
        private void g03_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoadGroupno(sender, "and sc_mem_m_membership_registered.member_group_no = {1}", "03", this.GetCurrentColumnValue("member_group_no".ToUpper()));
        }


        private void s03_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoadGroupno(sender, null, "03");
        }
        private void s02_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoadGroupno(sender, null, "02");
        }
        private void s01_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoadGroupno(sender, null, "01");
        }
    }
}
