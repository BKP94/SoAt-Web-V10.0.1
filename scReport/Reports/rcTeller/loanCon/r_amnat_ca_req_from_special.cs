using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.loanCon
{
    public partial class r_amnat_ca_req_from_special : DevExpress.XtraReports.UI.XtraReport
    {
        public r_amnat_ca_req_from_special ()
        {
            InitializeComponent();
        }

        private void history_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.loanCon.r_amnat_ca_req_from_special_nest_history");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_REQUESTMENT_NO"));
        }

            private void coll_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
                sc.report.setResource(sender, "scReport.Reports.rcTeller.loanCon.r_amnat_ca_req_from_special_nest_coll");
                sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("LOAN_REQUESTMENT_NO"));
            
        }
    }
 }
    

