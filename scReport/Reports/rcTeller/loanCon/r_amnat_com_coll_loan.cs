using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanCon
{
    public partial class r_amnat_com_coll_loan : DevExpress.XtraReports.UI.XtraReport
    {
        public r_amnat_com_coll_loan()
        {
            InitializeComponent();
        }

        private void of_colllat_no(object sender, string collateral_no)
        {
            sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcTeller.loanCon.r_amnat_com_coll_loan_nest_haeder"),
            null, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"), collateral_no);
        }
        private void coll_name_1_1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            of_colllat_no(sender, "1");
        }
        private void coll_name_1_2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            of_colllat_no(sender, "2");
        }
        private void coll_name_1_3_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            of_colllat_no(sender, "3");
        }
        private void coll_name_1_4_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            of_colllat_no(sender, "4");
        }
        private void coll_name_1_5_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            of_colllat_no(sender, "5");
        }


        private void of_coll_seq_no(object sender, string seq_no)
        {
            sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcTeller.loanCon.r_amnat_com_coll_loan_nest_guarantor_1"),
            null, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"), seq_no);
        }
        private void coll_name_2_1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            of_coll_seq_no(sender, "1");
        }
        private void coll_name_2_2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            of_coll_seq_no(sender, "2");
        }
        private void coll_name_2_3_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            of_coll_seq_no(sender, "3");
        }



        private void of_coll_name_2(object sender, string seq_no)
        {
            sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcTeller.loanCon.r_amnat_com_coll_loan_nest_guarantor_2"),
            null, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"), seq_no);
        }
        private void coll_name_3_1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            of_coll_name_2(sender, "4");
        }
        private void coll_name_3_2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            of_coll_name_2(sender, "5");
        }



        private void of_count(object sender, string collateral_no)
        {
            sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcTeller.loanCon.r_amnat_com_coll_loan_nest_footer"),
            null, this.GetCurrentColumnValue("LOAN_CONTRACT_NO"), collateral_no);
        }
        private void coll_name_4_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            of_count(sender, "1");
        }

        private void coll_2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            of_count(sender, "2");
        }

        private void coll_3_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            of_count(sender, "3");
        }

        private void coll_4_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            of_count(sender, "4");
        }

        private void coll_5_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            of_count(sender, "5");
        }
    }
}

