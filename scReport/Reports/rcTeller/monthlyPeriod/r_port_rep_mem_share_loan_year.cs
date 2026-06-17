using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using DevExpress.DataAccess.Sql;

namespace scReport.Reports.rcTeller.monthlyPeriod
{
    public partial class r_port_rep_mem_share_loan_year : DevExpress.XtraReports.UI.XtraReport
    {
        private Dictionary<string, decimal> groupSums_emer = new Dictionary<string, decimal>();
        private Dictionary<string, decimal> groupSums_norm = new Dictionary<string, decimal>();
        private Dictionary<string, decimal> groupSums_spec = new Dictionary<string, decimal>();

        public r_port_rep_mem_share_loan_year()
        {
            InitializeComponent();
        }

        private void nest_a_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.monthlyPeriod.r_ktm_rep_mem_share_loan_year_nest_a");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBER_GROUP_CONTROL"), this.GetCurrentColumnValue("BALANCE_DATE"));

            var tmp = sc.value.toDecimal(this.GetCurrentColumnValue("EMER_BALANCE"));
        }

        private void nest_a_2(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.monthlyPeriod.r_ktm_rep_mem_share_loan_year_nest_a_2");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBER_GROUP_CONTROL"), this.GetCurrentColumnValue("BALANCE_DATE"));

        }

        private void nest_a_3(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setResource(sender, "scReport.Reports.rcTeller.monthlyPeriod.r_ktm_rep_mem_share_loan_year_nest_a_3");
            sc.report.ofBeforePrint(this, (XRSubreport)sender, this.GetCurrentColumnValue("MEMBER_GROUP_CONTROL"), this.GetCurrentColumnValue("BALANCE_DATE"));
        }


       private void GroupFooter1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var groupControl = sc.value.toString(this.GetCurrentColumnValue("MEMBER_GROUP_CONTROL"));
            /*
            //emer
            if (groupSums_emer.ContainsKey(groupControl))
            {
                var groupSum = sc.value.toDecimal(groupSums_emer[groupControl]);
                if (groupSum == 0)
                {
                    this.nest_a1.Visible = false;
                }
            }

            //norm
            if (groupSums_emer.ContainsKey(groupControl))
            {
                var groupSum = sc.value.toDecimal(groupSums_norm[groupControl]);
                if (groupSum == 0)
                {
                    this.nest_a2.Visible = false;
                }
            }
            
            //spec
            if (groupSums_emer.ContainsKey(groupControl))
            {
                var groupSum = sc.value.toDecimal(groupSums_spec[groupControl]);
                if (groupSum == 0)
                {
                    this.nest_a3.Visible = false;
                }
            }

            */
            
        }

        private void Detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // รับค่า member_group_control และ emer_balance
            var groupControl = sc.value.toString(this.GetCurrentColumnValue("MEMBER_GROUP_CONTROL"));
            var emerBalance = sc.value.toDecimal(this.GetCurrentColumnValue("EMER_BALANCE"));
            var normBalance = sc.value.toDecimal(this.GetCurrentColumnValue("NORM_BALANCE"));
            var specBalance = sc.value.toDecimal(this.GetCurrentColumnValue("SPEC_BALANCE"));
            
            //emer
            if (groupSums_emer.ContainsKey(groupControl))
            {
                groupSums_emer[groupControl] += emerBalance;
            }
            else
            {
                groupSums_emer[groupControl] = emerBalance;
            }
            
            //norm
            if (groupSums_norm.ContainsKey(groupControl))
            {
                groupSums_norm[groupControl] += normBalance; 
            }
            else
            {
                groupSums_norm[groupControl] = normBalance; 
            }
            
            //spec
            if (groupSums_spec.ContainsKey(groupControl))
            {
                groupSums_spec[groupControl] += specBalance; 
            }
            else
            {
                groupSums_spec[groupControl] = specBalance;
            }
        }
    }
}
