using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace rcContract.KTM
{
    public partial class r_member_record_by_mem : DevExpress.XtraReports.UI.XtraReport
    {
        public r_member_record_by_mem()
        {
            InitializeComponent();
        }

        private void record_share_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "rcContract.KTM.r_member_record_by_mem_nest_share");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO") ,this.GetCurrentColumnValue("OPERATE_DATE"));
        }
       
        private void record_emer_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "rcContract.KTM.r_member_record_by_mem_nest_emer");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"), this.GetCurrentColumnValue("LOAN_PAYMENT_DATE"));
        }

        private void emer2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "rcContract.KTM.r_member_record_by_mem_nest_ordinary");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"), this.GetCurrentColumnValue("LOAN_PAYMENT_DATE"));
        }

        private void coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "rcContract.KTM.r_member_record_by_mem_nest_coll");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("REF_OWN_NO"));
        }

        private void concern_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "rcContract.KTM.r_member_record_by_mem_nest_concem");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }

        private void record_return_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "rcContract.KTM.r_member_record_by_mem_nest_record_return");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBERSHIP_NO"));
        }
    }
}
