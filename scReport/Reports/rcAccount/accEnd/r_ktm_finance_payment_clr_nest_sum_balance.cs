using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for r_finance_payment_sum_balance
/// </summary>
namespace scReport.Reports.rcAccount.accEnd
{
    public class r_ktm_finance_payment_clr_nest_sum_balance : DevExpress.XtraReports.UI.XtraReport
    {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private CalculatedField c_sum_loan;
        private CalculatedField c_sum_in;
        private XRLabel xrLabel115;
        private XRLabel xrLabel130;
        private XRLabel xrLabel129;
        private XRLabel xrLabel128;
        private XRLabel xrLabel125;
        private XRLabel xrLabel122;
        private XRLabel xrLabel119;
        private XRLabel xrLabel116;
        private XRLabel xrLabel118;
        private XRLabel xrLabel120;
        private XRLabel xrLabel126;
        private XRLabel xrLabel123;
        private XRLabel xrLabel117;
        private XRLabel xrLabel127;
        private XRLabel xrLabel124;
        private XRLabel xrLabel121;
        private ReportHeaderBand ReportHeader;
        private ReportFooterBand ReportFooter;
        private CalculatedField c_emer_con_no;
        private CalculatedField c_emer_principal;
        private CalculatedField c_emer_interest;
        private CalculatedField c_norm_con_no;
        private CalculatedField c_norm_principal;
        private CalculatedField c_norm_interest;
        private CalculatedField c_spec_con_no;
        private CalculatedField c_spec_principal;
        private CalculatedField c_spec_interest;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public r_ktm_finance_payment_clr_nest_sum_balance()
        {
            InitializeComponent();
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_ktm_finance_payment_clr_nest_sum_balance));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel115 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel130 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel129 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel128 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel125 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel122 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel119 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel116 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel118 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel120 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel126 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel123 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel117 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel127 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel124 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel121 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.c_sum_loan = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_sum_in = new DevExpress.XtraReports.UI.CalculatedField();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.c_emer_con_no = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_emer_principal = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_emer_interest = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_norm_con_no = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_norm_principal = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_norm_interest = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_spec_con_no = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_spec_principal = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_spec_interest = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.Expanded = false;
            this.Detail.HeightF = 150F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel115
            // 
            this.xrLabel115.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel115.CanGrow = false;
            this.xrLabel115.Dpi = 100F;
            this.xrLabel115.Font = new System.Drawing.Font("BrowalliaUPC", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel115.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel115.Name = "xrLabel115";
            this.xrLabel115.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel115.SizeF = new System.Drawing.SizeF(375F, 25F);
            this.xrLabel115.StylePriority.UseBorders = false;
            this.xrLabel115.StylePriority.UseFont = false;
            this.xrLabel115.StylePriority.UseTextAlignment = false;
            this.xrLabel115.Text = "ยอดรวมรับชำระหนี้";
            this.xrLabel115.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel130
            // 
            this.xrLabel130.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Double;
            this.xrLabel130.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel130.BorderWidth = 3F;
            this.xrLabel130.CanGrow = false;
            this.xrLabel130.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_sum_in")});
            this.xrLabel130.Dpi = 100F;
            this.xrLabel130.LocationFloat = new DevExpress.Utils.PointFloat(299.9999F, 75F);
            this.xrLabel130.Name = "xrLabel130";
            this.xrLabel130.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel130.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel130.StylePriority.UseBorderDashStyle = false;
            this.xrLabel130.StylePriority.UseBorders = false;
            this.xrLabel130.StylePriority.UseBorderWidth = false;
            this.xrLabel130.StylePriority.UseTextAlignment = false;
            this.xrLabel130.Text = "xrLabel16";
            this.xrLabel130.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel129
            // 
            this.xrLabel129.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Double;
            this.xrLabel129.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel129.BorderWidth = 3F;
            this.xrLabel129.CanGrow = false;
            this.xrLabel129.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_sum_loan")});
            this.xrLabel129.Dpi = 100F;
            this.xrLabel129.LocationFloat = new DevExpress.Utils.PointFloat(224.9999F, 75F);
            this.xrLabel129.Name = "xrLabel129";
            this.xrLabel129.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel129.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel129.StylePriority.UseBorderDashStyle = false;
            this.xrLabel129.StylePriority.UseBorders = false;
            this.xrLabel129.StylePriority.UseBorderWidth = false;
            this.xrLabel129.StylePriority.UseTextAlignment = false;
            this.xrLabel129.Text = "xrLabel15";
            this.xrLabel129.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel128
            // 
            this.xrLabel128.CanGrow = false;
            this.xrLabel128.Dpi = 100F;
            this.xrLabel128.LocationFloat = new DevExpress.Utils.PointFloat(0F, 75F);
            this.xrLabel128.Multiline = true;
            this.xrLabel128.Name = "xrLabel128";
            this.xrLabel128.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel128.SizeF = new System.Drawing.SizeF(225F, 25F);
            this.xrLabel128.StylePriority.UseTextAlignment = false;
            this.xrLabel128.Text = "รวม\r\n";
            this.xrLabel128.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel125
            // 
            this.xrLabel125.CanGrow = false;
            this.xrLabel125.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_spec_con_no", "ประเภทเงินกู้พิเศษ {0:#,#} สัญญา")});
            this.xrLabel125.Dpi = 100F;
            this.xrLabel125.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50F);
            this.xrLabel125.Name = "xrLabel125";
            this.xrLabel125.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel125.SizeF = new System.Drawing.SizeF(225F, 25F);
            this.xrLabel125.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "ประเภทเงินกู้พิเศษ {0:#,#} สัญญา";
            this.xrLabel125.Summary = xrSummary1;
            this.xrLabel125.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel122
            // 
            this.xrLabel122.CanGrow = false;
            this.xrLabel122.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_norm_con_no", "ประเภทเงินกู้สามัญ {0:#,#} สัญญา")});
            this.xrLabel122.Dpi = 100F;
            this.xrLabel122.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.xrLabel122.Name = "xrLabel122";
            this.xrLabel122.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel122.SizeF = new System.Drawing.SizeF(225F, 25F);
            this.xrLabel122.StylePriority.UseTextAlignment = false;
            this.xrLabel122.Text = "xrLabel8";
            this.xrLabel122.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel119
            // 
            this.xrLabel119.CanGrow = false;
            this.xrLabel119.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_emer_con_no", "ประเภทเงินกู้ฉุกเฉิน {0:#,#} สัญญา")});
            this.xrLabel119.Dpi = 100F;
            this.xrLabel119.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel119.Name = "xrLabel119";
            this.xrLabel119.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel119.SizeF = new System.Drawing.SizeF(225F, 25F);
            this.xrLabel119.StylePriority.UseTextAlignment = false;
            this.xrLabel119.Text = "xrLabel3";
            this.xrLabel119.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel116
            // 
            this.xrLabel116.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel116.CanGrow = false;
            this.xrLabel116.Dpi = 100F;
            this.xrLabel116.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.xrLabel116.Name = "xrLabel116";
            this.xrLabel116.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel116.SizeF = new System.Drawing.SizeF(225F, 25F);
            this.xrLabel116.StylePriority.UseBorders = false;
            this.xrLabel116.StylePriority.UseTextAlignment = false;
            this.xrLabel116.Text = "ประเภท";
            this.xrLabel116.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel118
            // 
            this.xrLabel118.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel118.CanGrow = false;
            this.xrLabel118.Dpi = 100F;
            this.xrLabel118.LocationFloat = new DevExpress.Utils.PointFloat(225F, 25F);
            this.xrLabel118.Name = "xrLabel118";
            this.xrLabel118.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel118.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel118.StylePriority.UseBorders = false;
            this.xrLabel118.StylePriority.UseTextAlignment = false;
            this.xrLabel118.Text = "ต้นเงิน";
            this.xrLabel118.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel120
            // 
            this.xrLabel120.CanGrow = false;
            this.xrLabel120.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_emer_principal")});
            this.xrLabel120.Dpi = 100F;
            this.xrLabel120.LocationFloat = new DevExpress.Utils.PointFloat(224.9999F, 0F);
            this.xrLabel120.Name = "xrLabel120";
            this.xrLabel120.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel120.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel120.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:n2}";
            xrSummary2.IgnoreNullValues = true;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel120.Summary = xrSummary2;
            this.xrLabel120.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel126
            // 
            this.xrLabel126.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel126.CanGrow = false;
            this.xrLabel126.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_spec_principal")});
            this.xrLabel126.Dpi = 100F;
            this.xrLabel126.LocationFloat = new DevExpress.Utils.PointFloat(224.9999F, 50F);
            this.xrLabel126.Name = "xrLabel126";
            this.xrLabel126.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel126.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel126.StylePriority.UseBorders = false;
            this.xrLabel126.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:n2}";
            xrSummary3.IgnoreNullValues = true;
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel126.Summary = xrSummary3;
            this.xrLabel126.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel123
            // 
            this.xrLabel123.CanGrow = false;
            this.xrLabel123.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_norm_principal")});
            this.xrLabel123.Dpi = 100F;
            this.xrLabel123.LocationFloat = new DevExpress.Utils.PointFloat(224.9999F, 25F);
            this.xrLabel123.Name = "xrLabel123";
            this.xrLabel123.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel123.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel123.StylePriority.UseTextAlignment = false;
            xrSummary4.FormatString = "{0:n2}";
            xrSummary4.IgnoreNullValues = true;
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel123.Summary = xrSummary4;
            this.xrLabel123.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel117
            // 
            this.xrLabel117.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel117.CanGrow = false;
            this.xrLabel117.Dpi = 100F;
            this.xrLabel117.LocationFloat = new DevExpress.Utils.PointFloat(300F, 25F);
            this.xrLabel117.Name = "xrLabel117";
            this.xrLabel117.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel117.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel117.StylePriority.UseBorders = false;
            this.xrLabel117.StylePriority.UseTextAlignment = false;
            this.xrLabel117.Text = "ดอกเบี้ย";
            this.xrLabel117.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel127
            // 
            this.xrLabel127.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel127.CanGrow = false;
            this.xrLabel127.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_spec_interest")});
            this.xrLabel127.Dpi = 100F;
            this.xrLabel127.LocationFloat = new DevExpress.Utils.PointFloat(299.9999F, 50F);
            this.xrLabel127.Name = "xrLabel127";
            this.xrLabel127.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel127.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel127.StylePriority.UseBorders = false;
            this.xrLabel127.StylePriority.UseTextAlignment = false;
            xrSummary5.FormatString = "{0:n2}";
            xrSummary5.IgnoreNullValues = true;
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel127.Summary = xrSummary5;
            this.xrLabel127.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel124
            // 
            this.xrLabel124.CanGrow = false;
            this.xrLabel124.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_norm_interest")});
            this.xrLabel124.Dpi = 100F;
            this.xrLabel124.LocationFloat = new DevExpress.Utils.PointFloat(299.9999F, 25F);
            this.xrLabel124.Name = "xrLabel124";
            this.xrLabel124.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel124.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel124.StylePriority.UseTextAlignment = false;
            xrSummary6.FormatString = "{0:n2}";
            xrSummary6.IgnoreNullValues = true;
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel124.Summary = xrSummary6;
            this.xrLabel124.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel121
            // 
            this.xrLabel121.CanGrow = false;
            this.xrLabel121.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_emer_interest")});
            this.xrLabel121.Dpi = 100F;
            this.xrLabel121.LocationFloat = new DevExpress.Utils.PointFloat(299.9999F, 0F);
            this.xrLabel121.Name = "xrLabel121";
            this.xrLabel121.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel121.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel121.StylePriority.UseTextAlignment = false;
            xrSummary7.FormatString = "{0:n2}";
            xrSummary7.IgnoreNullValues = true;
            xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel121.Summary = xrSummary7;
            this.xrLabel121.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "repConnection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // c_sum_loan
            // 
            this.c_sum_loan.DataMember = "Query";
            this.c_sum_loan.Expression = "[EMER_PRINCIPAL] + [NORM_PRINCIPAL] + [SPEC_PRINCIPAL]";
            this.c_sum_loan.Name = "c_sum_loan";
            // 
            // c_sum_in
            // 
            this.c_sum_in.DataMember = "Query";
            this.c_sum_in.Expression = "[EMER_INTEREST] + [NORM_INTEREST] + [SPEC_INTEREST]";
            this.c_sum_in.Name = "c_sum_in";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel115,
            this.xrLabel118,
            this.xrLabel116,
            this.xrLabel117});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 50F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel119,
            this.xrLabel124,
            this.xrLabel127,
            this.xrLabel123,
            this.xrLabel126,
            this.xrLabel120,
            this.xrLabel121,
            this.xrLabel122,
            this.xrLabel125,
            this.xrLabel128,
            this.xrLabel129,
            this.xrLabel130});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 100F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // c_emer_con_no
            // 
            this.c_emer_con_no.DataMember = "Query";
            this.c_emer_con_no.Expression = "Iif(IsNull([LOAN_TYPE] = \'22\' ) , [SUB_COUNT] , 0 )";
            this.c_emer_con_no.Name = "c_emer_con_no";
            // 
            // c_emer_principal
            // 
            this.c_emer_principal.DataMember = "Query";
            this.c_emer_principal.Expression = "Iif(IsNull([LOAN_TYPE] = \'22\' ) , [PRINCIPAL_OF_LOAN] , 0 )";
            this.c_emer_principal.Name = "c_emer_principal";
            // 
            // c_emer_interest
            // 
            this.c_emer_interest.DataMember = "Query";
            this.c_emer_interest.Expression = "Iif(IsNull([LOAN_TYPE] = \'22\' ),  [INTEREST_AMOUNT] , 0 )";
            this.c_emer_interest.Name = "c_emer_interest";
            // 
            // c_norm_con_no
            // 
            this.c_norm_con_no.DataMember = "Query";
            this.c_norm_con_no.Expression = "Iif(IsNull([LOAN_TYPE] = \'24\' ), [SUB_COUNT] , 0 )";
            this.c_norm_con_no.Name = "c_norm_con_no";
            // 
            // c_norm_principal
            // 
            this.c_norm_principal.DataMember = "Query";
            this.c_norm_principal.Expression = "Iif(IsNull([LOAN_TYPE] = \'02\' ),  [PRINCIPAL_OF_LOAN] , 0 )";
            this.c_norm_principal.Name = "c_norm_principal";
            // 
            // c_norm_interest
            // 
            this.c_norm_interest.DataMember = "Query";
            this.c_norm_interest.Expression = "Iif(IsNull([LOAN_TYPE] = \'02\' ), [INTEREST_AMOUNT] , 0 )";
            this.c_norm_interest.Name = "c_norm_interest";
            // 
            // c_spec_con_no
            // 
            this.c_spec_con_no.DataMember = "Query";
            this.c_spec_con_no.Expression = "Iif(IsNull([LOAN_TYPE] = \'03\' ), [SUB_COUNT]  , 0 )";
            this.c_spec_con_no.Name = "c_spec_con_no";
            // 
            // c_spec_principal
            // 
            this.c_spec_principal.DataMember = "Query";
            this.c_spec_principal.Expression = "Iif(IsNull([LOAN_TYPE] = \'03\'), [PRINCIPAL_OF_LOAN] , 0 )";
            this.c_spec_principal.Name = "c_spec_principal";
            // 
            // c_spec_interest
            // 
            this.c_spec_interest.DataMember = "Query";
            this.c_spec_interest.Expression = "Iif(IsNull([LOAN_TYPE] = \'03\' ) , [INTEREST_AMOUNT] , 0 )";
            this.c_spec_interest.Name = "c_spec_interest";
            // 
            // r_finance_payment_sum_balance
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.c_sum_loan,
            this.c_sum_in,
            this.c_emer_con_no,
            this.c_emer_principal,
            this.c_emer_interest,
            this.c_norm_con_no,
            this.c_norm_principal,
            this.c_norm_interest,
            this.c_spec_con_no,
            this.c_spec_principal,
            this.c_spec_interest});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("BrowalliaUPC", 12F);
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion
    }
}
