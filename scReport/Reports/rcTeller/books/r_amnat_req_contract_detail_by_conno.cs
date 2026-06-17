using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.books
{
    public partial class r_amnat_req_contract_detail_by_conno : DevExpress.XtraReports.UI.XtraReport
    {
        public r_amnat_req_contract_detail_by_conno()
        {
            InitializeComponent();
        }

        private void coll_1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.books.r_amnat_req_contract_detail_by_conno_nest");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("REF_OWN_NO_1") ,this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void coll_2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.books.r_amnat_req_contract_detail_by_conno_nest_coll_2");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("REF_OWN_NO_2"), this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void coll_3_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.books.r_amnat_req_contract_detail_by_conno_nest_coll_3");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("REF_OWN_NO_3"),this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void coll_4_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.books.r_amnat_req_contract_detail_by_conno_nest_coll_4");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("REF_OWN_NO_4"), this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void coll_5_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.books.r_amnat_req_contract_detail_by_conno_nest_coll_5");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("REF_OWN_NO_5"), this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }
    }
}
