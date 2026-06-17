using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.admin
{
    public partial class r_ktm_mem_book_pay_return1_dropshr : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ktm_mem_book_pay_return1_dropshr()
        {
            InitializeComponent();
        }

        private void return_loan_det_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcTeller.admin.r_ktm_mem_book_pay_return1_dropshr_nest_loan"), null, this.GetCurrentColumnValue("RECEIVE_YEAR")
               , this.GetCurrentColumnValue("RECEIVE_MONTH"), this.GetCurrentColumnValue("MEMBERSHIP_NO"), this.GetCurrentColumnValue("SEQ_NO"));
        }
    }
}
