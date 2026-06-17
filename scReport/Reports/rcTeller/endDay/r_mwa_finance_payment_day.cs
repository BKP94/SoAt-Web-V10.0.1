using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for r_finance_payment
/// </summary>
namespace scReport.Reports.rcTeller.endDay
{
    public class r_mwa_finance_payment_day : DevExpress.XtraReports.UI.XtraReport
    {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private PageHeaderBand PageHeader;
        private CalculatedField sum;
        private CalculatedField sum_int;
        private ReportFooterBand ReportFooter;
        private XRLabel xrLabel62;
        private XRLabel xrLabel61;
        private XRLabel xrLabel60;
        private XRLabel xrLabel59;
        private XRLabel xrLabel67;
        private XRLabel xrLabel66;
        private XRLabel xrLabel65;
        private XRLabel xrLabel64;
        private XRLabel xrLabel63;
        private XRLabel xrLabel68;
        private XRLabel xrLabel74;
        private XRLabel xrLabel73;
        private XRLabel xrLabel72;
        private XRLabel xrLabel71;
        private XRLabel xrLabel70;
        private XRLabel xrLabel69;
        private CalculatedField sum_principal_amount;
        private XRLabel xrLabel97;
        private XRLabel xrLabel96;
        private XRLabel xrLabel78;
        private XRLabel xrLabel77;
        private XRLabel xrLabel76;
        private XRLabel xrLabel75;
        private CalculatedField sum_interest;
        private XRSubreport nest_emer_sum;
        private CalculatedField c_conno1_close;
        private CalculatedField c_conno1_still;
        private CalculatedField c_emer_balance_close;
        private CalculatedField c_emer_balance_still;
        private CalculatedField c_emer_int_close;
        private CalculatedField c_conno2_close;
        private CalculatedField c_conno2_still;
        private CalculatedField c_norm_balance_close;
        private CalculatedField c_norm_balance_still;
        private CalculatedField c_norm_int_close;
        private CalculatedField c_norm_int_still;
        private CalculatedField c_conno3_close;
        private CalculatedField c_conno3_still;
        private CalculatedField c_spec_balance_close;
        private CalculatedField c_spec_balance_still;
        private CalculatedField c_spec_int_close;
        private CalculatedField c_spec_int_still;
        private CalculatedField c_other_payments;
        private CalculatedField total;
        private CalculatedField calculatedField1;
        private XRSubreport nest_norm_sum;
        private XRSubreport nest_spec_sum;
        private XRSubreport loan_code;
        private CalculatedField c_emer_int_still;
        private XRPageInfo xrPageInfo3;
        private XRLabel t_header_3;
        private XRLabel t_header_2;
        private XRLabel t_header_1;
        private XRLabel t_header_publish_date;
        private XRLabel xrLabel140;
        private XRLabel xrLabel38;
        private XRLabel xrLabel37;
        private XRLabel xrLabel149;
        private XRLabel xrLabel150;
        private XRLabel xrLabel151;
        private XRLabel xrLabel152;
        private XRLabel xrLabel153;
        private FormattingRule formattingRule2;
        private FormattingRule formattingRule3;
        private FormattingRule formattingRule4;
        private CalculatedField C_p_1_in;
        private CalculatedField C_p_2_in;
        private CalculatedField C_p_3_in;
        private CalculatedField C_p_1_out;
        private CalculatedField C_p_2_out;
        private CalculatedField C_p_3_out;
        private CalculatedField C_i_1_in;
        private CalculatedField C_i_2_in;
        private CalculatedField C_i_3_in;
        private CalculatedField C_i_1_out;
        private CalculatedField C_i_2_out;
        private CalculatedField C_i_3_out;
        private XRLabel xrLabel177;
        private XRLabel xrLabel178;
        private CalculatedField c_fee_new;
        private XRLabel xrLabel36;
        private XRLabel xrLabel39;
        private XRLabel xrLabel40;
        private XRLabel xrLabel134;
        private XRLabel xrLabel43;
        private XRLabel xrLabel135;
        private XRLabel xrLabel136;
        private XRLabel xrLabel137;
        private XRLabel xrLabel33;
        private XRLabel xrLabel138;
        private XRLabel xrLabel139;
        private XRLabel xrLabel142;
        private XRLabel xrLabel6;
        private XRLabel xrLabel12;
        private XRLabel xrLabel30;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public r_mwa_finance_payment_day()
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
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_mwa_finance_payment_day));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary10 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary11 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.t_header_3 = new DevExpress.XtraReports.UI.XRLabel();
            this.t_header_2 = new DevExpress.XtraReports.UI.XRLabel();
            this.t_header_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.t_header_publish_date = new DevExpress.XtraReports.UI.XRLabel();
            this.sum = new DevExpress.XtraReports.UI.CalculatedField();
            this.sum_int = new DevExpress.XtraReports.UI.CalculatedField();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel138 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel139 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel142 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel135 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel136 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel137 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel134 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel178 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel177 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel149 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel150 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel151 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel152 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel153 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel140 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.loan_code = new DevExpress.XtraReports.UI.XRSubreport();
            this.nest_spec_sum = new DevExpress.XtraReports.UI.XRSubreport();
            this.nest_norm_sum = new DevExpress.XtraReports.UI.XRSubreport();
            this.nest_emer_sum = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrLabel97 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel96 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel78 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel77 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel76 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel75 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel74 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel73 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel72 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel71 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel70 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel69 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel68 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel67 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel66 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel65 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel64 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel63 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel62 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel61 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel60 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel59 = new DevExpress.XtraReports.UI.XRLabel();
            this.formattingRule4 = new DevExpress.XtraReports.UI.FormattingRule();
            this.formattingRule2 = new DevExpress.XtraReports.UI.FormattingRule();
            this.formattingRule3 = new DevExpress.XtraReports.UI.FormattingRule();
            this.sum_principal_amount = new DevExpress.XtraReports.UI.CalculatedField();
            this.sum_interest = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_conno1_close = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_conno1_still = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_emer_balance_close = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_emer_balance_still = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_emer_int_close = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_conno2_close = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_conno2_still = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_norm_balance_close = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_norm_balance_still = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_norm_int_close = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_norm_int_still = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_conno3_close = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_conno3_still = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_spec_balance_close = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_spec_balance_still = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_spec_int_close = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_spec_int_still = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_other_payments = new DevExpress.XtraReports.UI.CalculatedField();
            this.total = new DevExpress.XtraReports.UI.CalculatedField();
            this.calculatedField1 = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_emer_int_still = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_p_1_in = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_p_2_in = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_p_3_in = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_p_1_out = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_p_2_out = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_p_3_out = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_i_1_in = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_i_2_in = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_i_3_in = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_i_1_out = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_i_2_out = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_i_3_out = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_fee_new = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Expanded = false;
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 21.83338F;
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
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo3,
            this.t_header_3,
            this.t_header_2,
            this.t_header_1,
            this.t_header_publish_date});
            this.PageHeader.HeightF = 100F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrPageInfo3
            // 
            this.xrPageInfo3.Font = new System.Drawing.Font("AngsanaUPC", 16F, System.Drawing.FontStyle.Bold);
            this.xrPageInfo3.ForeColor = System.Drawing.Color.Black;
            this.xrPageInfo3.Format = "หน้า {0}/ {1}";
            this.xrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(1516.667F, 0F);
            this.xrPageInfo3.Name = "xrPageInfo3";
            this.xrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo3.SizeF = new System.Drawing.SizeF(208.3334F, 25F);
            this.xrPageInfo3.StylePriority.UseFont = false;
            this.xrPageInfo3.StylePriority.UseForeColor = false;
            this.xrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // t_header_3
            // 
            this.t_header_3.Font = new System.Drawing.Font("AngsanaUPC", 16F, System.Drawing.FontStyle.Bold);
            this.t_header_3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 75F);
            this.t_header_3.Name = "t_header_3";
            this.t_header_3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t_header_3.SizeF = new System.Drawing.SizeF(1725F, 25F);
            this.t_header_3.StylePriority.UseFont = false;
            this.t_header_3.StylePriority.UseTextAlignment = false;
            this.t_header_3.Text = "t_header_3";
            this.t_header_3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // t_header_2
            // 
            this.t_header_2.Font = new System.Drawing.Font("AngsanaUPC", 16F, System.Drawing.FontStyle.Bold);
            this.t_header_2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50F);
            this.t_header_2.Name = "t_header_2";
            this.t_header_2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t_header_2.SizeF = new System.Drawing.SizeF(1725F, 25F);
            this.t_header_2.StylePriority.UseFont = false;
            this.t_header_2.StylePriority.UseTextAlignment = false;
            this.t_header_2.Text = "t_header_2 <si_rep_reps.rep_text>";
            this.t_header_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // t_header_1
            // 
            this.t_header_1.Font = new System.Drawing.Font("AngsanaUPC", 16F, System.Drawing.FontStyle.Bold);
            this.t_header_1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.t_header_1.Name = "t_header_1";
            this.t_header_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t_header_1.SizeF = new System.Drawing.SizeF(1725F, 25F);
            this.t_header_1.StylePriority.UseFont = false;
            this.t_header_1.StylePriority.UseTextAlignment = false;
            this.t_header_1.Text = "t_header_1 <sc_cnt_m_coop.coop_name>";
            this.t_header_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // t_header_publish_date
            // 
            this.t_header_publish_date.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.t_header_publish_date.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.t_header_publish_date.Name = "t_header_publish_date";
            this.t_header_publish_date.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t_header_publish_date.SizeF = new System.Drawing.SizeF(1516.5F, 25F);
            this.t_header_publish_date.StylePriority.UseFont = false;
            this.t_header_publish_date.StylePriority.UseTextAlignment = false;
            this.t_header_publish_date.Text = "t_header_publish_date";
            this.t_header_publish_date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // sum
            // 
            this.sum.DataMember = "Query";
            this.sum.Expression = "[EMER_PRINCIPAL] + [NORM_PRINCIPAL] + [SPEC_PRINCIPAL]";
            this.sum.Name = "sum";
            // 
            // sum_int
            // 
            this.sum_int.DataMember = "Query";
            this.sum_int.Expression = "[EMER_INTEREST] + [NORM_INTEREST] + [SPEC_INTEREST]";
            this.sum_int.Name = "sum_int";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6,
            this.xrLabel12,
            this.xrLabel30,
            this.xrLabel33,
            this.xrLabel138,
            this.xrLabel139,
            this.xrLabel142,
            this.xrLabel43,
            this.xrLabel135,
            this.xrLabel136,
            this.xrLabel137,
            this.xrLabel36,
            this.xrLabel39,
            this.xrLabel40,
            this.xrLabel134,
            this.xrLabel178,
            this.xrLabel177,
            this.xrLabel149,
            this.xrLabel150,
            this.xrLabel151,
            this.xrLabel152,
            this.xrLabel153,
            this.xrLabel140,
            this.xrLabel38,
            this.xrLabel37,
            this.loan_code,
            this.nest_spec_sum,
            this.nest_norm_sum,
            this.nest_emer_sum,
            this.xrLabel97,
            this.xrLabel96,
            this.xrLabel78,
            this.xrLabel77,
            this.xrLabel76,
            this.xrLabel75,
            this.xrLabel74,
            this.xrLabel73,
            this.xrLabel72,
            this.xrLabel71,
            this.xrLabel70,
            this.xrLabel69,
            this.xrLabel68,
            this.xrLabel67,
            this.xrLabel66,
            this.xrLabel65,
            this.xrLabel64,
            this.xrLabel63,
            this.xrLabel62,
            this.xrLabel61,
            this.xrLabel60,
            this.xrLabel59});
            this.ReportFooter.Font = new System.Drawing.Font("BrowalliaUPC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportFooter.HeightF = 290.0833F;
            this.ReportFooter.KeepTogether = true;
            this.ReportFooter.LockedInUserDesigner = true;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.StylePriority.UseFont = false;
            this.ReportFooter.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.ReportFooter_BeforePrint);
            // 
            // xrLabel6
            // 
            this.xrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel6.CanGrow = false;
            this.xrLabel6.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(1387.5F, 137.5F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "ลูกหนี้ไม่ปกติ";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel12
            // 
            this.xrLabel12.CanGrow = false;
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LOAN_CODE_PRINCIPAL_AMOUNT")});
            this.xrLabel12.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(1475F, 137.5F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:n2}";
            xrSummary1.IgnoreNullValues = true;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel12.Summary = xrSummary1;
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel30
            // 
            this.xrLabel30.CanGrow = false;
            this.xrLabel30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LOAN_CODE_INTEREST_AMOUNT")});
            this.xrLabel30.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(1587.5F, 137.5F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:n2}";
            xrSummary2.IgnoreNullValues = true;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel30.Summary = xrSummary2;
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel33
            // 
            this.xrLabel33.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel33.CanGrow = false;
            this.xrLabel33.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(1302F, 37.5F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel33.StylePriority.UseBorders = false;
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "ดอกเบี้ย";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel138
            // 
            this.xrLabel138.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel138.CanGrow = false;
            this.xrLabel138.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel138.LocationFloat = new DevExpress.Utils.PointFloat(1214.5F, 37.5F);
            this.xrLabel138.Name = "xrLabel138";
            this.xrLabel138.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel138.SizeF = new System.Drawing.SizeF(87.49963F, 25F);
            this.xrLabel138.StylePriority.UseBorders = false;
            this.xrLabel138.StylePriority.UseFont = false;
            this.xrLabel138.StylePriority.UseTextAlignment = false;
            this.xrLabel138.Text = "ต้นเงิน";
            this.xrLabel138.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel139
            // 
            this.xrLabel139.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel139.CanGrow = false;
            this.xrLabel139.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel139.LocationFloat = new DevExpress.Utils.PointFloat(1174.917F, 37.5F);
            this.xrLabel139.Name = "xrLabel139";
            this.xrLabel139.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel139.SizeF = new System.Drawing.SizeF(39.58301F, 25F);
            this.xrLabel139.StylePriority.UseBorders = false;
            this.xrLabel139.StylePriority.UseFont = false;
            this.xrLabel139.StylePriority.UseTextAlignment = false;
            this.xrLabel139.Text = "จน.";
            this.xrLabel139.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel142
            // 
            this.xrLabel142.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel142.CanGrow = false;
            this.xrLabel142.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel142.LocationFloat = new DevExpress.Utils.PointFloat(1039.5F, 37.5F);
            this.xrLabel142.Name = "xrLabel142";
            this.xrLabel142.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel142.SizeF = new System.Drawing.SizeF(135.4166F, 25F);
            this.xrLabel142.StylePriority.UseBorders = false;
            this.xrLabel142.StylePriority.UseFont = false;
            this.xrLabel142.StylePriority.UseTextAlignment = false;
            this.xrLabel142.Text = "ประเภท";
            this.xrLabel142.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel43
            // 
            this.xrLabel43.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel43.CanGrow = false;
            this.xrLabel43.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel43.LocationFloat = new DevExpress.Utils.PointFloat(690.9999F, 37.5F);
            this.xrLabel43.Name = "xrLabel43";
            this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel43.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel43.StylePriority.UseBorders = false;
            this.xrLabel43.StylePriority.UseFont = false;
            this.xrLabel43.StylePriority.UseTextAlignment = false;
            this.xrLabel43.Text = "ประเภท";
            this.xrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel135
            // 
            this.xrLabel135.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel135.CanGrow = false;
            this.xrLabel135.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel135.LocationFloat = new DevExpress.Utils.PointFloat(803.4999F, 37.5F);
            this.xrLabel135.Name = "xrLabel135";
            this.xrLabel135.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel135.SizeF = new System.Drawing.SizeF(62.5F, 25F);
            this.xrLabel135.StylePriority.UseBorders = false;
            this.xrLabel135.StylePriority.UseFont = false;
            this.xrLabel135.StylePriority.UseTextAlignment = false;
            this.xrLabel135.Text = "จน.";
            this.xrLabel135.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel136
            // 
            this.xrLabel136.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel136.CanGrow = false;
            this.xrLabel136.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel136.LocationFloat = new DevExpress.Utils.PointFloat(865.9999F, 37.5F);
            this.xrLabel136.Name = "xrLabel136";
            this.xrLabel136.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel136.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel136.StylePriority.UseBorders = false;
            this.xrLabel136.StylePriority.UseFont = false;
            this.xrLabel136.StylePriority.UseTextAlignment = false;
            this.xrLabel136.Text = "ต้นเงิน";
            this.xrLabel136.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel137
            // 
            this.xrLabel137.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel137.CanGrow = false;
            this.xrLabel137.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel137.LocationFloat = new DevExpress.Utils.PointFloat(953.4999F, 37.5F);
            this.xrLabel137.Name = "xrLabel137";
            this.xrLabel137.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel137.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel137.StylePriority.UseBorders = false;
            this.xrLabel137.StylePriority.UseFont = false;
            this.xrLabel137.StylePriority.UseTextAlignment = false;
            this.xrLabel137.Text = "ดอกเบี้ย";
            this.xrLabel137.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel36
            // 
            this.xrLabel36.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel36.CanGrow = false;
            this.xrLabel36.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(344.5F, 37.5F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel36.StylePriority.UseBorders = false;
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.StylePriority.UseTextAlignment = false;
            this.xrLabel36.Text = "ประเภท";
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel39
            // 
            this.xrLabel39.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel39.CanGrow = false;
            this.xrLabel39.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(457F, 37.5F);
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(62.5F, 25F);
            this.xrLabel39.StylePriority.UseBorders = false;
            this.xrLabel39.StylePriority.UseFont = false;
            this.xrLabel39.StylePriority.UseTextAlignment = false;
            this.xrLabel39.Text = "จน.";
            this.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel40
            // 
            this.xrLabel40.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel40.CanGrow = false;
            this.xrLabel40.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(519.5F, 37.5F);
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel40.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel40.StylePriority.UseBorders = false;
            this.xrLabel40.StylePriority.UseFont = false;
            this.xrLabel40.StylePriority.UseTextAlignment = false;
            this.xrLabel40.Text = "ต้นเงิน";
            this.xrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel134
            // 
            this.xrLabel134.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel134.CanGrow = false;
            this.xrLabel134.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel134.LocationFloat = new DevExpress.Utils.PointFloat(607F, 37.5F);
            this.xrLabel134.Name = "xrLabel134";
            this.xrLabel134.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel134.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel134.StylePriority.UseBorders = false;
            this.xrLabel134.StylePriority.UseFont = false;
            this.xrLabel134.StylePriority.UseTextAlignment = false;
            this.xrLabel134.Text = "ดอกเบี้ย";
            this.xrLabel134.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel178
            // 
            this.xrLabel178.CanGrow = false;
            this.xrLabel178.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_fee_new")});
            this.xrLabel178.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel178.LocationFloat = new DevExpress.Utils.PointFloat(1475F, 250.5F);
            this.xrLabel178.Name = "xrLabel178";
            this.xrLabel178.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel178.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel178.StylePriority.UseFont = false;
            this.xrLabel178.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:n2}";
            xrSummary3.IgnoreNullValues = true;
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel178.Summary = xrSummary3;
            this.xrLabel178.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel177
            // 
            this.xrLabel177.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel177.CanGrow = false;
            this.xrLabel177.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel177.LocationFloat = new DevExpress.Utils.PointFloat(1387.5F, 250.5F);
            this.xrLabel177.Name = "xrLabel177";
            this.xrLabel177.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel177.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel177.StylePriority.UseBorders = false;
            this.xrLabel177.StylePriority.UseFont = false;
            this.xrLabel177.StylePriority.UseTextAlignment = false;
            this.xrLabel177.Text = "ธ/น  สมัคร";
            this.xrLabel177.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel149
            // 
            this.xrLabel149.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel149.CanGrow = false;
            this.xrLabel149.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel149.LocationFloat = new DevExpress.Utils.PointFloat(262.5F, 37.5F);
            this.xrLabel149.Name = "xrLabel149";
            this.xrLabel149.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel149.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel149.StylePriority.UseBorders = false;
            this.xrLabel149.StylePriority.UseFont = false;
            this.xrLabel149.StylePriority.UseTextAlignment = false;
            this.xrLabel149.Text = "ดอกเบี้ย";
            this.xrLabel149.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel150
            // 
            this.xrLabel150.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel150.CanGrow = false;
            this.xrLabel150.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel150.LocationFloat = new DevExpress.Utils.PointFloat(175F, 37.5F);
            this.xrLabel150.Name = "xrLabel150";
            this.xrLabel150.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel150.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel150.StylePriority.UseBorders = false;
            this.xrLabel150.StylePriority.UseFont = false;
            this.xrLabel150.StylePriority.UseTextAlignment = false;
            this.xrLabel150.Text = "ต้นเงิน";
            this.xrLabel150.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel151
            // 
            this.xrLabel151.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel151.CanGrow = false;
            this.xrLabel151.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel151.LocationFloat = new DevExpress.Utils.PointFloat(112.5F, 37.5F);
            this.xrLabel151.Name = "xrLabel151";
            this.xrLabel151.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel151.SizeF = new System.Drawing.SizeF(62.5F, 25F);
            this.xrLabel151.StylePriority.UseBorders = false;
            this.xrLabel151.StylePriority.UseFont = false;
            this.xrLabel151.StylePriority.UseTextAlignment = false;
            this.xrLabel151.Text = "จน.";
            this.xrLabel151.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel152
            // 
            this.xrLabel152.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel152.CanGrow = false;
            this.xrLabel152.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel152.LocationFloat = new DevExpress.Utils.PointFloat(0F, 37.5F);
            this.xrLabel152.Name = "xrLabel152";
            this.xrLabel152.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel152.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel152.StylePriority.UseBorders = false;
            this.xrLabel152.StylePriority.UseFont = false;
            this.xrLabel152.StylePriority.UseTextAlignment = false;
            this.xrLabel152.Text = "ประเภท";
            this.xrLabel152.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel153
            // 
            this.xrLabel153.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel153.CanGrow = false;
            this.xrLabel153.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel153.LocationFloat = new DevExpress.Utils.PointFloat(1039.5F, 0F);
            this.xrLabel153.Name = "xrLabel153";
            this.xrLabel153.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel153.SizeF = new System.Drawing.SizeF(337.5F, 37.5F);
            this.xrLabel153.StylePriority.UseBorders = false;
            this.xrLabel153.StylePriority.UseFont = false;
            this.xrLabel153.StylePriority.UseTextAlignment = false;
            this.xrLabel153.Text = "ลูกหนี้ไม่ปกติ";
            this.xrLabel153.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel140
            // 
            this.xrLabel140.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel140.CanGrow = false;
            this.xrLabel140.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel140.LocationFloat = new DevExpress.Utils.PointFloat(690.9999F, 0F);
            this.xrLabel140.Name = "xrLabel140";
            this.xrLabel140.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel140.SizeF = new System.Drawing.SizeF(337.5F, 37.5F);
            this.xrLabel140.StylePriority.UseBorders = false;
            this.xrLabel140.StylePriority.UseFont = false;
            this.xrLabel140.StylePriority.UseTextAlignment = false;
            this.xrLabel140.Text = "สรุปการชำระตามหมวดเงินกู้พิเศษ";
            this.xrLabel140.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel38
            // 
            this.xrLabel38.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel38.CanGrow = false;
            this.xrLabel38.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(344.5F, 0F);
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel38.SizeF = new System.Drawing.SizeF(337.5F, 37.5F);
            this.xrLabel38.StylePriority.UseBorders = false;
            this.xrLabel38.StylePriority.UseFont = false;
            this.xrLabel38.StylePriority.UseTextAlignment = false;
            this.xrLabel38.Text = "สรุปการชำระตามหมวดเงินกู้สามัญ";
            this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel37
            // 
            this.xrLabel37.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel37.CanGrow = false;
            this.xrLabel37.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(337.5F, 37.5F);
            this.xrLabel37.StylePriority.UseBorders = false;
            this.xrLabel37.StylePriority.UseFont = false;
            this.xrLabel37.StylePriority.UseTextAlignment = false;
            this.xrLabel37.Text = "สรุปการชำระตามหมวดเงินกู้ฉุกเฉิน";
            this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // loan_code
            // 
            this.loan_code.LocationFloat = new DevExpress.Utils.PointFloat(1039.5F, 62.5F);
            this.loan_code.Name = "loan_code";
            this.loan_code.SizeF = new System.Drawing.SizeF(337.5F, 137.5F);
            this.loan_code.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.loan_code_BeforePrint);
            // 
            // nest_spec_sum
            // 
            this.nest_spec_sum.LocationFloat = new DevExpress.Utils.PointFloat(690.9999F, 62.5F);
            this.nest_spec_sum.Name = "nest_spec_sum";
            this.nest_spec_sum.SizeF = new System.Drawing.SizeF(337.5F, 137.5F);
            this.nest_spec_sum.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.nest_spec_sum_BeforePrint);
            // 
            // nest_norm_sum
            // 
            this.nest_norm_sum.LocationFloat = new DevExpress.Utils.PointFloat(344.5F, 62.5F);
            this.nest_norm_sum.Name = "nest_norm_sum";
            this.nest_norm_sum.SizeF = new System.Drawing.SizeF(337.5F, 137.5F);
            this.nest_norm_sum.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.nest_norm_sum_BeforePrint);
            // 
            // nest_emer_sum
            // 
            this.nest_emer_sum.LocationFloat = new DevExpress.Utils.PointFloat(0F, 62.5F);
            this.nest_emer_sum.Name = "nest_emer_sum";
            this.nest_emer_sum.SizeF = new System.Drawing.SizeF(337.5F, 137.5F);
            this.nest_emer_sum.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.nest_emer_sum_BeforePrint);
            // 
            // xrLabel97
            // 
            this.xrLabel97.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel97.CanGrow = false;
            this.xrLabel97.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel97.LocationFloat = new DevExpress.Utils.PointFloat(1587.5F, 225.5F);
            this.xrLabel97.Name = "xrLabel97";
            this.xrLabel97.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel97.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel97.StylePriority.UseBorders = false;
            this.xrLabel97.StylePriority.UseFont = false;
            // 
            // xrLabel96
            // 
            this.xrLabel96.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel96.CanGrow = false;
            this.xrLabel96.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel96.LocationFloat = new DevExpress.Utils.PointFloat(1587.5F, 187.5F);
            this.xrLabel96.Name = "xrLabel96";
            this.xrLabel96.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel96.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel96.StylePriority.UseBorders = false;
            this.xrLabel96.StylePriority.UseFont = false;
            // 
            // xrLabel78
            // 
            this.xrLabel78.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel78.CanGrow = false;
            this.xrLabel78.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.sum_interest", "{0:n2}")});
            this.xrLabel78.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel78.LocationFloat = new DevExpress.Utils.PointFloat(1587.5F, 162.5F);
            this.xrLabel78.Name = "xrLabel78";
            this.xrLabel78.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel78.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel78.StylePriority.UseBorders = false;
            this.xrLabel78.StylePriority.UseFont = false;
            this.xrLabel78.StylePriority.UseTextAlignment = false;
            this.xrLabel78.Text = "xrLabel78";
            this.xrLabel78.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel77
            // 
            this.xrLabel77.CanGrow = false;
            this.xrLabel77.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT_03")});
            this.xrLabel77.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel77.LocationFloat = new DevExpress.Utils.PointFloat(1587.5F, 112.5F);
            this.xrLabel77.Name = "xrLabel77";
            this.xrLabel77.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel77.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel77.StylePriority.UseFont = false;
            this.xrLabel77.StylePriority.UseTextAlignment = false;
            xrSummary4.FormatString = "{0:n2}";
            xrSummary4.IgnoreNullValues = true;
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel77.Summary = xrSummary4;
            this.xrLabel77.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel76
            // 
            this.xrLabel76.CanGrow = false;
            this.xrLabel76.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT_02")});
            this.xrLabel76.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel76.LocationFloat = new DevExpress.Utils.PointFloat(1587.5F, 87.5F);
            this.xrLabel76.Name = "xrLabel76";
            this.xrLabel76.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel76.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel76.StylePriority.UseFont = false;
            this.xrLabel76.StylePriority.UseTextAlignment = false;
            xrSummary5.FormatString = "{0:n2}";
            xrSummary5.IgnoreNullValues = true;
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel76.Summary = xrSummary5;
            this.xrLabel76.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel75
            // 
            this.xrLabel75.CanGrow = false;
            this.xrLabel75.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT_01")});
            this.xrLabel75.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel75.LocationFloat = new DevExpress.Utils.PointFloat(1587.5F, 62.5F);
            this.xrLabel75.Name = "xrLabel75";
            this.xrLabel75.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel75.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel75.StylePriority.UseFont = false;
            this.xrLabel75.StylePriority.UseTextAlignment = false;
            xrSummary6.FormatString = "{0:n2}";
            xrSummary6.IgnoreNullValues = true;
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel75.Summary = xrSummary6;
            this.xrLabel75.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel74
            // 
            this.xrLabel74.CanGrow = false;
            this.xrLabel74.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_other_payments")});
            this.xrLabel74.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel74.LocationFloat = new DevExpress.Utils.PointFloat(1475F, 225.5F);
            this.xrLabel74.Name = "xrLabel74";
            this.xrLabel74.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel74.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel74.StylePriority.UseFont = false;
            this.xrLabel74.StylePriority.UseTextAlignment = false;
            xrSummary7.FormatString = "{0:n2}";
            xrSummary7.IgnoreNullValues = true;
            xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel74.Summary = xrSummary7;
            this.xrLabel74.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel73
            // 
            this.xrLabel73.CanGrow = false;
            this.xrLabel73.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.BY_SHARE")});
            this.xrLabel73.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel73.LocationFloat = new DevExpress.Utils.PointFloat(1475F, 187.5F);
            this.xrLabel73.Name = "xrLabel73";
            this.xrLabel73.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel73.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel73.StylePriority.UseFont = false;
            this.xrLabel73.StylePriority.UseTextAlignment = false;
            xrSummary8.FormatString = "{0:n2}";
            xrSummary8.IgnoreNullValues = true;
            xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel73.Summary = xrSummary8;
            this.xrLabel73.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel72
            // 
            this.xrLabel72.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel72.CanGrow = false;
            this.xrLabel72.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.sum_principal_amount", "{0:n2}")});
            this.xrLabel72.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel72.LocationFloat = new DevExpress.Utils.PointFloat(1475F, 162.5F);
            this.xrLabel72.Name = "xrLabel72";
            this.xrLabel72.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel72.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel72.StylePriority.UseBorders = false;
            this.xrLabel72.StylePriority.UseFont = false;
            this.xrLabel72.StylePriority.UseTextAlignment = false;
            this.xrLabel72.Text = "xrLabel72";
            this.xrLabel72.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel71
            // 
            this.xrLabel71.CanGrow = false;
            this.xrLabel71.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT_03")});
            this.xrLabel71.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel71.LocationFloat = new DevExpress.Utils.PointFloat(1475F, 112.5F);
            this.xrLabel71.Name = "xrLabel71";
            this.xrLabel71.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel71.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel71.StylePriority.UseFont = false;
            this.xrLabel71.StylePriority.UseTextAlignment = false;
            xrSummary9.FormatString = "{0:n2}";
            xrSummary9.IgnoreNullValues = true;
            xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel71.Summary = xrSummary9;
            this.xrLabel71.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel70
            // 
            this.xrLabel70.CanGrow = false;
            this.xrLabel70.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT_02")});
            this.xrLabel70.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel70.LocationFloat = new DevExpress.Utils.PointFloat(1475F, 87.5F);
            this.xrLabel70.Name = "xrLabel70";
            this.xrLabel70.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel70.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel70.StylePriority.UseFont = false;
            this.xrLabel70.StylePriority.UseTextAlignment = false;
            xrSummary10.FormatString = "{0:n2}";
            xrSummary10.IgnoreNullValues = true;
            xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel70.Summary = xrSummary10;
            this.xrLabel70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel69
            // 
            this.xrLabel69.CanGrow = false;
            this.xrLabel69.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT_01")});
            this.xrLabel69.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel69.LocationFloat = new DevExpress.Utils.PointFloat(1475F, 62.5F);
            this.xrLabel69.Name = "xrLabel69";
            this.xrLabel69.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel69.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel69.StylePriority.UseFont = false;
            this.xrLabel69.StylePriority.UseTextAlignment = false;
            xrSummary11.FormatString = "{0:n2}";
            xrSummary11.IgnoreNullValues = true;
            xrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel69.Summary = xrSummary11;
            this.xrLabel69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel68
            // 
            this.xrLabel68.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel68.CanGrow = false;
            this.xrLabel68.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel68.LocationFloat = new DevExpress.Utils.PointFloat(1387.5F, 162.5F);
            this.xrLabel68.Name = "xrLabel68";
            this.xrLabel68.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel68.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel68.StylePriority.UseBorders = false;
            this.xrLabel68.StylePriority.UseFont = false;
            // 
            // xrLabel67
            // 
            this.xrLabel67.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel67.CanGrow = false;
            this.xrLabel67.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel67.LocationFloat = new DevExpress.Utils.PointFloat(1387.5F, 225.5F);
            this.xrLabel67.Name = "xrLabel67";
            this.xrLabel67.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel67.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel67.StylePriority.UseBorders = false;
            this.xrLabel67.StylePriority.UseFont = false;
            this.xrLabel67.StylePriority.UseTextAlignment = false;
            this.xrLabel67.Text = "ชำระอื่น ๆ";
            this.xrLabel67.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel66
            // 
            this.xrLabel66.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel66.CanGrow = false;
            this.xrLabel66.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel66.LocationFloat = new DevExpress.Utils.PointFloat(1387.5F, 187.5F);
            this.xrLabel66.Name = "xrLabel66";
            this.xrLabel66.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel66.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel66.StylePriority.UseBorders = false;
            this.xrLabel66.StylePriority.UseFont = false;
            this.xrLabel66.StylePriority.UseTextAlignment = false;
            this.xrLabel66.Text = "ซื้อหุ้น";
            this.xrLabel66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel65
            // 
            this.xrLabel65.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel65.CanGrow = false;
            this.xrLabel65.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel65.LocationFloat = new DevExpress.Utils.PointFloat(1387.5F, 112.5F);
            this.xrLabel65.Name = "xrLabel65";
            this.xrLabel65.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel65.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel65.StylePriority.UseBorders = false;
            this.xrLabel65.StylePriority.UseFont = false;
            this.xrLabel65.StylePriority.UseTextAlignment = false;
            this.xrLabel65.Text = "เงินกู้พิเศษ";
            this.xrLabel65.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel64
            // 
            this.xrLabel64.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel64.CanGrow = false;
            this.xrLabel64.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel64.LocationFloat = new DevExpress.Utils.PointFloat(1387.5F, 87.5F);
            this.xrLabel64.Name = "xrLabel64";
            this.xrLabel64.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel64.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel64.StylePriority.UseBorders = false;
            this.xrLabel64.StylePriority.UseFont = false;
            this.xrLabel64.StylePriority.UseTextAlignment = false;
            this.xrLabel64.Text = "เงินกู้สามัญ";
            this.xrLabel64.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel63
            // 
            this.xrLabel63.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel63.CanGrow = false;
            this.xrLabel63.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel63.LocationFloat = new DevExpress.Utils.PointFloat(1387.5F, 62.5F);
            this.xrLabel63.Name = "xrLabel63";
            this.xrLabel63.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel63.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel63.StylePriority.UseBorders = false;
            this.xrLabel63.StylePriority.UseFont = false;
            this.xrLabel63.StylePriority.UseTextAlignment = false;
            this.xrLabel63.Text = "เงินกู้ฉุกเฉิน";
            this.xrLabel63.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel62
            // 
            this.xrLabel62.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel62.CanGrow = false;
            this.xrLabel62.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel62.LocationFloat = new DevExpress.Utils.PointFloat(1587.5F, 37.5F);
            this.xrLabel62.Name = "xrLabel62";
            this.xrLabel62.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel62.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel62.StylePriority.UseBorders = false;
            this.xrLabel62.StylePriority.UseFont = false;
            this.xrLabel62.StylePriority.UseTextAlignment = false;
            this.xrLabel62.Text = "ดอกเบี้ย";
            this.xrLabel62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel61
            // 
            this.xrLabel61.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel61.CanGrow = false;
            this.xrLabel61.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel61.LocationFloat = new DevExpress.Utils.PointFloat(1475F, 37.5F);
            this.xrLabel61.Name = "xrLabel61";
            this.xrLabel61.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel61.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel61.StylePriority.UseBorders = false;
            this.xrLabel61.StylePriority.UseFont = false;
            this.xrLabel61.StylePriority.UseTextAlignment = false;
            this.xrLabel61.Text = "เงินต้น";
            this.xrLabel61.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel60
            // 
            this.xrLabel60.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel60.CanGrow = false;
            this.xrLabel60.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel60.LocationFloat = new DevExpress.Utils.PointFloat(1387.5F, 37.5F);
            this.xrLabel60.Name = "xrLabel60";
            this.xrLabel60.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel60.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel60.StylePriority.UseBorders = false;
            this.xrLabel60.StylePriority.UseFont = false;
            this.xrLabel60.StylePriority.UseTextAlignment = false;
            this.xrLabel60.Text = "ประเภท";
            this.xrLabel60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel59
            // 
            this.xrLabel59.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel59.CanGrow = false;
            this.xrLabel59.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel59.LocationFloat = new DevExpress.Utils.PointFloat(1387.5F, 0F);
            this.xrLabel59.Name = "xrLabel59";
            this.xrLabel59.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel59.SizeF = new System.Drawing.SizeF(300F, 37.5F);
            this.xrLabel59.StylePriority.UseBorders = false;
            this.xrLabel59.StylePriority.UseFont = false;
            this.xrLabel59.StylePriority.UseTextAlignment = false;
            this.xrLabel59.Text = "สรุป";
            this.xrLabel59.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // formattingRule4
            // 
            this.formattingRule4.Condition = "[RECEIPT_MODE]   != [R]";
            this.formattingRule4.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.formattingRule4.Name = "formattingRule4";
            // 
            // formattingRule2
            // 
            this.formattingRule2.Condition = "[RECEIPT_MONTH] == [MONTH_RECEIPT_DATE]";
            this.formattingRule2.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.formattingRule2.Name = "formattingRule2";
            // 
            // formattingRule3
            // 
            this.formattingRule3.Condition = "[MONTH_RECEIPT_DATE]  > [RECEIPT_MONTH]";
            this.formattingRule3.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.formattingRule3.Name = "formattingRule3";
            // 
            // sum_principal_amount
            // 
            this.sum_principal_amount.DataMember = "Query";
            this.sum_principal_amount.Expression = " ToDecimal(Sum([PRINCIPAL_AMOUNT_01]))  +  ToDecimal(Sum([PRINCIPAL_AMOUNT_02])) " +
    "+  ToDecimal(Sum([PRINCIPAL_AMOUNT_03])) + \nToDecimal(Sum([LOAN_CODE_PRINCIPAL_A" +
    "MOUNT]))";
            this.sum_principal_amount.Name = "sum_principal_amount";
            // 
            // sum_interest
            // 
            this.sum_interest.DataMember = "Query";
            this.sum_interest.Expression = "  ToDecimal(Sum([INTEREST_AMOUNT_01]))  +  ToDecimal(Sum([INTEREST_AMOUNT_02])) +" +
    "  ToDecimal(Sum([INTEREST_AMOUNT_03])) +\nToDecimal(Sum([LOAN_CODE_INTEREST_AMOUN" +
    "T]))";
            this.sum_interest.Name = "sum_interest";
            // 
            // c_conno1_close
            // 
            this.c_conno1_close.DataMember = "Query";
            this.c_conno1_close.Expression = "Iif(  [PRINCIPAL_01] <= 0  ,0 ,1 )";
            this.c_conno1_close.Name = "c_conno1_close";
            // 
            // c_conno1_still
            // 
            this.c_conno1_still.DataMember = "Query";
            this.c_conno1_still.Expression = "Iif( [PRINCIPAL_01] > 0, 1 ,0 )";
            this.c_conno1_still.Name = "c_conno1_still";
            // 
            // c_emer_balance_close
            // 
            this.c_emer_balance_close.DataMember = "Query";
            this.c_emer_balance_close.Expression = "Iif([c_conno1_close] = 1, [PRINCIPAL_AMOUNT_01]  ,0 )";
            this.c_emer_balance_close.Name = "c_emer_balance_close";
            // 
            // c_emer_balance_still
            // 
            this.c_emer_balance_still.DataMember = "Query";
            this.c_emer_balance_still.Expression = "Iif([c_conno1_still] = 1, [PRINCIPAL_AMOUNT_01] ,0 )";
            this.c_emer_balance_still.Name = "c_emer_balance_still";
            // 
            // c_emer_int_close
            // 
            this.c_emer_int_close.DataMember = "Query";
            this.c_emer_int_close.Expression = "Iif([c_conno1_close] =1, [INTEREST_AMOUNT_01] ,0 )";
            this.c_emer_int_close.Name = "c_emer_int_close";
            // 
            // c_conno2_close
            // 
            this.c_conno2_close.DataMember = "Query";
            this.c_conno2_close.Expression = "Iif(  [PRINCIPAL_02] <= 0  ,0 ,1 )";
            this.c_conno2_close.Name = "c_conno2_close";
            // 
            // c_conno2_still
            // 
            this.c_conno2_still.DataMember = "Query";
            this.c_conno2_still.Expression = "Iif( [PRINCIPAL_02] > 0, 1 , 0 )";
            this.c_conno2_still.Name = "c_conno2_still";
            // 
            // c_norm_balance_close
            // 
            this.c_norm_balance_close.DataMember = "Query";
            this.c_norm_balance_close.Expression = "Iif([c_conno2_close] = 1 , [PRINCIPAL_AMOUNT_02] , 0 )";
            this.c_norm_balance_close.Name = "c_norm_balance_close";
            // 
            // c_norm_balance_still
            // 
            this.c_norm_balance_still.DataMember = "Query";
            this.c_norm_balance_still.Expression = "Iif( [COUNT_02] = 1, [PRINCIPAL_AMOUNT_02] ,0 )";
            this.c_norm_balance_still.Name = "c_norm_balance_still";
            // 
            // c_norm_int_close
            // 
            this.c_norm_int_close.DataMember = "Query";
            this.c_norm_int_close.Expression = "Iif([c_conno2_close] = 1 , [INTEREST_AMOUNT_02] , 0 )";
            this.c_norm_int_close.Name = "c_norm_int_close";
            // 
            // c_norm_int_still
            // 
            this.c_norm_int_still.DataMember = "Query";
            this.c_norm_int_still.Expression = "Iif([c_conno2_still] = 1, [INTEREST_AMOUNT_02] ,0 )";
            this.c_norm_int_still.Name = "c_norm_int_still";
            // 
            // c_conno3_close
            // 
            this.c_conno3_close.DataMember = "Query";
            this.c_conno3_close.Expression = "Iif(  [PRINCIPAL_03] <= 0  ,0 ,1 )";
            this.c_conno3_close.Name = "c_conno3_close";
            // 
            // c_conno3_still
            // 
            this.c_conno3_still.DataMember = "Query";
            this.c_conno3_still.Expression = "Iif( [PRINCIPAL_03] > 0, 1 ,0 )";
            this.c_conno3_still.Name = "c_conno3_still";
            // 
            // c_spec_balance_close
            // 
            this.c_spec_balance_close.DataMember = "Query";
            this.c_spec_balance_close.Expression = "Iif([c_conno3_close] = 1,[PRINCIPAL_AMOUNT_03],0 )";
            this.c_spec_balance_close.Name = "c_spec_balance_close";
            // 
            // c_spec_balance_still
            // 
            this.c_spec_balance_still.DataMember = "Query";
            this.c_spec_balance_still.Expression = "Iif([c_conno3_still] = 1, [PRINCIPAL_AMOUNT_03] ,0 )";
            this.c_spec_balance_still.Name = "c_spec_balance_still";
            // 
            // c_spec_int_close
            // 
            this.c_spec_int_close.DataMember = "Query";
            this.c_spec_int_close.Expression = "Iif([c_conno3_close] = 1, [INTEREST_AMOUNT_03] ,0 )";
            this.c_spec_int_close.Name = "c_spec_int_close";
            // 
            // c_spec_int_still
            // 
            this.c_spec_int_still.DataMember = "Query";
            this.c_spec_int_still.Expression = "Iif([c_conno3_still] = 1, [INTEREST_AMOUNT_03] ,0 )";
            this.c_spec_int_still.Name = "c_spec_int_still";
            // 
            // c_other_payments
            // 
            this.c_other_payments.DataMember = "Query";
            this.c_other_payments.Expression = "[FUND_NEW] +[FREE_AMOUNT]+[C_DEP]";
            this.c_other_payments.Name = "c_other_payments";
            // 
            // total
            // 
            this.total.DataMember = "Query";
            this.total.Expression = resources.GetString("total.Expression");
            this.total.Name = "total";
            // 
            // calculatedField1
            // 
            this.calculatedField1.DataMember = "Query";
            this.calculatedField1.Expression = resources.GetString("calculatedField1.Expression");
            this.calculatedField1.Name = "calculatedField1";
            // 
            // c_emer_int_still
            // 
            this.c_emer_int_still.DataMember = "Query";
            this.c_emer_int_still.Expression = "Iif([c_conno1_still] = 1, [INTEREST_AMOUNT_01] ,0 )";
            this.c_emer_int_still.Name = "c_emer_int_still";
            // 
            // C_p_1_in
            // 
            this.C_p_1_in.DataMember = "Query";
            this.C_p_1_in.Expression = "Iif([MONTH_RECEIPT_DATE] == [RECEIPT_MONTH], [R_PRINCIPAL_AMOUNT_01] , 0)";
            this.C_p_1_in.Name = "C_p_1_in";
            // 
            // C_p_2_in
            // 
            this.C_p_2_in.DataMember = "Query";
            this.C_p_2_in.Expression = "Iif([MONTH_RECEIPT_DATE] == [RECEIPT_MONTH], [R_PRINCIPAL_AMOUNT_02] , 0)";
            this.C_p_2_in.Name = "C_p_2_in";
            // 
            // C_p_3_in
            // 
            this.C_p_3_in.DataMember = "Query";
            this.C_p_3_in.Expression = "Iif([MONTH_RECEIPT_DATE] == [RECEIPT_MONTH], [R_PRINCIPAL_AMOUNT_03], 0)";
            this.C_p_3_in.Name = "C_p_3_in";
            // 
            // C_p_1_out
            // 
            this.C_p_1_out.DataMember = "Query";
            this.C_p_1_out.Expression = "Iif([MONTH_RECEIPT_DATE]  >  [RECEIPT_MONTH], [R_PRINCIPAL_AMOUNT_01] , 0)";
            this.C_p_1_out.Name = "C_p_1_out";
            // 
            // C_p_2_out
            // 
            this.C_p_2_out.DataMember = "Query";
            this.C_p_2_out.Expression = "Iif([MONTH_RECEIPT_DATE]  >  [RECEIPT_MONTH], [R_PRINCIPAL_AMOUNT_02], 0)";
            this.C_p_2_out.Name = "C_p_2_out";
            // 
            // C_p_3_out
            // 
            this.C_p_3_out.DataMember = "Query";
            this.C_p_3_out.Expression = "Iif([MONTH_RECEIPT_DATE] >  [RECEIPT_MONTH], [R_PRINCIPAL_AMOUNT_03], 0)";
            this.C_p_3_out.Name = "C_p_3_out";
            // 
            // C_i_1_in
            // 
            this.C_i_1_in.DataMember = "Query";
            this.C_i_1_in.Expression = "Iif([MONTH_RECEIPT_DATE]   ==   [RECEIPT_MONTH], [R_INTEREST_AMOUNT_01], 0)";
            this.C_i_1_in.Name = "C_i_1_in";
            // 
            // C_i_2_in
            // 
            this.C_i_2_in.DataMember = "Query";
            this.C_i_2_in.Expression = "Iif([MONTH_RECEIPT_DATE]   ==   [RECEIPT_MONTH], [R_INTEREST_AMOUNT_02],0)";
            this.C_i_2_in.Name = "C_i_2_in";
            // 
            // C_i_3_in
            // 
            this.C_i_3_in.DataMember = "Query";
            this.C_i_3_in.Expression = "Iif([MONTH_RECEIPT_DATE]   ==   [RECEIPT_MONTH], [R_INTEREST_AMOUNT_03],0)";
            this.C_i_3_in.Name = "C_i_3_in";
            // 
            // C_i_1_out
            // 
            this.C_i_1_out.DataMember = "Query";
            this.C_i_1_out.Expression = "Iif([MONTH_RECEIPT_DATE]    >    [RECEIPT_MONTH], [R_INTEREST_AMOUNT_01], 0)";
            this.C_i_1_out.Name = "C_i_1_out";
            // 
            // C_i_2_out
            // 
            this.C_i_2_out.DataMember = "Query";
            this.C_i_2_out.Expression = "Iif([MONTH_RECEIPT_DATE]    >    [RECEIPT_MONTH], [R_INTEREST_AMOUNT_02],0)";
            this.C_i_2_out.Name = "C_i_2_out";
            // 
            // C_i_3_out
            // 
            this.C_i_3_out.DataMember = "Query";
            this.C_i_3_out.Expression = "Iif([MONTH_RECEIPT_DATE]    >    [RECEIPT_MONTH], [R_INTEREST_AMOUNT_03], 0)";
            this.C_i_3_out.Name = "C_i_3_out";
            // 
            // c_fee_new
            // 
            this.c_fee_new.DataMember = "Query";
            this.c_fee_new.Expression = "[FEE]";
            this.c_fee_new.Name = "c_fee_new";
            // 
            // r_mwa_finance_payment_day
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.ReportFooter});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.sum,
            this.sum_int,
            this.sum_principal_amount,
            this.sum_interest,
            this.c_conno1_close,
            this.c_conno1_still,
            this.c_emer_balance_close,
            this.c_emer_balance_still,
            this.c_emer_int_close,
            this.c_emer_int_still,
            this.c_conno2_close,
            this.c_conno2_still,
            this.c_norm_balance_close,
            this.c_norm_balance_still,
            this.c_norm_int_close,
            this.c_norm_int_still,
            this.c_conno3_close,
            this.c_conno3_still,
            this.c_spec_balance_close,
            this.c_spec_balance_still,
            this.c_spec_int_close,
            this.c_spec_int_still,
            this.c_other_payments,
            this.total,
            this.calculatedField1,
            this.C_p_1_in,
            this.C_p_2_in,
            this.C_p_3_in,
            this.C_p_1_out,
            this.C_p_2_out,
            this.C_p_3_out,
            this.C_i_1_in,
            this.C_i_2_in,
            this.C_i_3_in,
            this.C_i_1_out,
            this.C_i_2_out,
            this.C_i_3_out,
            this.c_fee_new});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.formattingRule2,
            this.formattingRule3,
            this.formattingRule4});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 22);
            this.PageHeight = 1268;
            this.PageWidth = 1752;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A3Extra;
            this.ScriptsSource = "\r\nprivate void xrLabel27_BeforePrint(object sender, System.Drawing.Printing.Print" +
    "EventArgs e) {\r\n }\r\n";
            this.Version = "17.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion
        

        


        //  void ofLoadGroupno(object sender, string sqlWhere, params object[] args)
        // {
        //     sc.report.setNestReport(this, sender, Type.GetType("rcAccount.accEnd.r_ktm_finance_payment_nest_pay_group"));
        //     sc.report.dataBind(this, sender, sqlWhere, args);
        // }
        void ofLoadsum(object sender, string loan_group_code  ,string loan_code
            )
        {
            sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcTeller.endDay.r_mwa_finance_payment_day_nest_emer"),null,this.GetCurrentColumnValue("RECEIPT_NO"),loan_group_code,loan_code);
        }

        private void nest_emer_sum_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoadsum(sender, "01"  , "0");
        }

        private void nest_norm_sum_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoadsum(sender, "02" ,"0");
        }

        private void nest_spec_sum_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoadsum(sender, "03" ,"0");
        }

        private void loan_code_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcTeller.endDay.r_mwa_finance_payment_day_nest_loan_code"));
        }

        private void nest_sum_balance_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcTeller.endDay.r_mwa_finance_payment_day_nest_sum_balance"),null, this.GetCurrentColumnValue("RECEIPT_DATE"));
        }

        private void nest_sum_balance_1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcTeller.endDay.r_mwa_finance_payment_day_nest_sum_balance1"),null, this.GetCurrentColumnValue("RECEIPT_DATE"));
        }

        private void nest_sum_balance_2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcTeller.endDay.r_mwa_finance_payment_day_nest_sum_balance2"),null, this.GetCurrentColumnValue("RECEIPT_DATE"));
        }

        private void nest_fund_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcTeller.endDay.r_mwa_finance_payment_day_nest_fund"),null, this.GetCurrentColumnValue("RECEIPT_DATE"));
        }

        private void xrLabel85_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void ReportFooter_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
