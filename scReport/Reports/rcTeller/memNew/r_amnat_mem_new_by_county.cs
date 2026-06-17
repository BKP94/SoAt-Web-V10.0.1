using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace scReport.Reports.rcTeller.memNew
{
    public partial class r_amnat_mem_new_by_county : DevExpress.XtraReports.UI.XtraReport
    {
        public r_amnat_mem_new_by_county()
        {
            InitializeComponent();
        }

        double countVal = 0;

        private void xrLabel22_SummaryReset(object sender, EventArgs e)
        {
            countVal = 0;
        }

        private void xrLabel22_SummaryRowChanged(object sender, EventArgs e)
        {
            var mem_typ_control = sc.value.toString(GetCurrentColumnValue("MEMTYPE_CONTROL"));
            var group_position = sc.value.toString(GetCurrentColumnValue("GROUP_POSITION"));
            if (mem_typ_control == "01")
            {
                if (group_position == "01")
                {
                    countVal += 1;
                }
            }
            else if(mem_typ_control == "02")
            {
                if(group_position == "03")
                {
                    countVal += 1;
                }
            }
        }

        private void xrLabel22_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = sc.value.toString(countVal);
            e.Handled = true;
        }

        double countVal2 = 0;
        private void xrLabel25_SummaryReset(object sender, EventArgs e)
        {
            countVal2 = 0;
        }

        private void xrLabel25_SummaryRowChanged(object sender, EventArgs e)
        {
            var mem_typ_control = sc.value.toString(GetCurrentColumnValue("MEMTYPE_CONTROL"));
            var group_position = sc.value.toString(GetCurrentColumnValue("GROUP_POSITION"));
            if (mem_typ_control == "01")
            {
                if (group_position == "05" || group_position == "02")
                {
                    countVal2 += 1;
                }
            }
            else if (mem_typ_control == "02")
            {
                if (group_position == "08" || group_position == "09" || group_position == "10")
                {
                    countVal2 += 1;
                }
            }
        }

        private void xrLabel25_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = sc.value.toString(countVal2);
            e.Handled = true;
        }
    }
}
