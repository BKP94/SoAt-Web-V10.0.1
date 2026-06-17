namespace scReport.Reports.rcTeller.loanapp
{
    partial class r_tge_loan_create_clr_sum_paid_multi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_tge_loan_create_clr_sum_paid_multi));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.c_mem_name = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_loan_objective_des = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_group_no = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_group_district_name = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_address_no = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_moo = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_road_soi = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_tambol = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_district_name = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_province_name = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_postcode = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_telephone = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_coll_name = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_road = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_soi = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_period_payment_amount_01 = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_period_payment_amount_02 = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_last_payment_amount_01 = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_last_payment_amount_02 = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_loan_installment_amount_01 = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_loan_installment_amount_02 = new DevExpress.XtraReports.UI.CalculatedField();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel8,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4});
            this.Detail.Dpi = 254F;
            this.Detail.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.Detail.HeightF = 74.78185F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.StylePriority.UseFont = false;
            this.Detail.StylePriority.UseTextAlignment = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.CanGrow = false;
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ITEM_AMOUNT", "{0:n2}")});
            this.xrLabel8.Dpi = 254F;
            this.xrLabel8.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(1334F, 7F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(220F, 60F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "xrLabel34";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel6
            // 
            this.xrLabel6.CanGrow = false;
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT", "{0:n2}")});
            this.xrLabel6.Dpi = 254F;
            this.xrLabel6.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(1121F, 7F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(209.9999F, 60F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "xrLabel34";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel5
            // 
            this.xrLabel5.CanGrow = false;
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT", "{0:n2}")});
            this.xrLabel5.Dpi = 254F;
            this.xrLabel5.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(908F, 7F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(210F, 60F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "xrLabel34";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.CanGrow = false;
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ITEM_TYPE_NAME")});
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 7F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(905F, 60F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "xrLabel34";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
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
            // c_mem_name
            // 
            this.c_mem_name.DataMember = "Query";
            this.c_mem_name.Expression = "\'                           \' + [MEMNAME]";
            this.c_mem_name.Name = "c_mem_name";
            // 
            // c_loan_objective_des
            // 
            this.c_loan_objective_des.DataMember = "Query";
            this.c_loan_objective_des.Expression = "Iif(IsNull( [LOAN_OBJECTIVE_DESCRIPTION] ),\'-\' , [LOAN_OBJECTIVE_DESCRIPTION] )";
            this.c_loan_objective_des.Name = "c_loan_objective_des";
            // 
            // c_group_no
            // 
            this.c_group_no.DataMember = "Query";
            this.c_group_no.Expression = "\'   \' + [MEMBER_GROUP_NAME]";
            this.c_group_no.Name = "c_group_no";
            // 
            // c_group_district_name
            // 
            this.c_group_district_name.DataMember = "Query";
            this.c_group_district_name.Expression = "\'  \' + Iif( [GROUP_DISTRICT_NAME] is null , \'-\' ,[GROUP_DISTRICT_NAME] )";
            this.c_group_district_name.Name = "c_group_district_name";
            // 
            // c_address_no
            // 
            this.c_address_no.DataMember = "Query";
            this.c_address_no.Expression = "Iif( [ADDRESS_NO] is null , \'-\' , [ADDRESS_NO] )";
            this.c_address_no.Name = "c_address_no";
            // 
            // c_moo
            // 
            this.c_moo.DataMember = "Query";
            this.c_moo.Expression = "Iif( [MOO] is null , \'-\' , [MOO] )";
            this.c_moo.Name = "c_moo";
            // 
            // c_road_soi
            // 
            this.c_road_soi.DataMember = "Query";
            this.c_road_soi.Expression = "Iif( [ROAD] is null , Iif( [ROAD] is null , \'-\' ,[ROAD] ) , Iif( [SOI] is null , " +
    "\'-\' , [SOI] ) )";
            this.c_road_soi.Name = "c_road_soi";
            // 
            // c_tambol
            // 
            this.c_tambol.DataMember = "Query";
            this.c_tambol.Expression = "Iif( [TAMBOL] is null , \'-\' , [TAMBOL] )";
            this.c_tambol.Name = "c_tambol";
            // 
            // c_district_name
            // 
            this.c_district_name.DataMember = "Query";
            this.c_district_name.Expression = "Iif( [DISTRICT_NAME] is null , \'-\' , [DISTRICT_NAME] )";
            this.c_district_name.Name = "c_district_name";
            // 
            // c_province_name
            // 
            this.c_province_name.DataMember = "Query";
            this.c_province_name.Expression = "Iif( [province_name] is null , \'-\' , [province_name] )";
            this.c_province_name.Name = "c_province_name";
            // 
            // c_postcode
            // 
            this.c_postcode.DataMember = "Query";
            this.c_postcode.Expression = "Iif( [POSTCODE] is null , \'-\' , [POSTCODE] )";
            this.c_postcode.Name = "c_postcode";
            // 
            // c_telephone
            // 
            this.c_telephone.DataMember = "Query";
            this.c_telephone.Expression = "Iif( [telephone] is null , \'-\' , [telephone] )";
            this.c_telephone.Name = "c_telephone";
            // 
            // c_coll_name
            // 
            this.c_coll_name.DataMember = "Query";
            this.c_coll_name.Expression = "\'            \' + [COLL_NAME]";
            this.c_coll_name.Name = "c_coll_name";
            // 
            // c_road
            // 
            this.c_road.DataMember = "Query";
            this.c_road.Expression = "Iif( [ROAD] is null , \'-\' ,[ROAD] )";
            this.c_road.Name = "c_road";
            // 
            // c_soi
            // 
            this.c_soi.DataMember = "Query";
            this.c_soi.Expression = "Iif( [SOI] is null , \'-\' , [SOI] )";
            this.c_soi.Name = "c_soi";
            // 
            // c_period_payment_amount_01
            // 
            this.c_period_payment_amount_01.DataMember = "Query";
            this.c_period_payment_amount_01.Expression = "Iif( [LOAN_PAYMENT_TYPE_CODE] = \'01\', [PERIOD_PAYMENT_AMOUNT] , \'\' )";
            this.c_period_payment_amount_01.Name = "c_period_payment_amount_01";
            // 
            // c_period_payment_amount_02
            // 
            this.c_period_payment_amount_02.DataMember = "Query";
            this.c_period_payment_amount_02.Expression = "Iif( [LOAN_PAYMENT_TYPE_CODE] = \'02\', [PERIOD_PAYMENT_AMOUNT] , \'\' )";
            this.c_period_payment_amount_02.Name = "c_period_payment_amount_02";
            // 
            // c_last_payment_amount_01
            // 
            this.c_last_payment_amount_01.DataMember = "Query";
            this.c_last_payment_amount_01.Expression = "Iif( [LOAN_PAYMENT_TYPE_CODE] = \'01\', [LAST_PAYMENT_AMOUNT] , \'\' )";
            this.c_last_payment_amount_01.Name = "c_last_payment_amount_01";
            // 
            // c_last_payment_amount_02
            // 
            this.c_last_payment_amount_02.DataMember = "Query";
            this.c_last_payment_amount_02.Expression = "Iif( [LOAN_PAYMENT_TYPE_CODE] = \'02\', [LAST_PAYMENT_AMOUNT] , \'\' )";
            this.c_last_payment_amount_02.Name = "c_last_payment_amount_02";
            // 
            // c_loan_installment_amount_01
            // 
            this.c_loan_installment_amount_01.DataMember = "Query";
            this.c_loan_installment_amount_01.Expression = "Iif( [LOAN_PAYMENT_TYPE_CODE] = \'01\', [LOAN_INSTALLMENT_AMOUNT] , \'\' )";
            this.c_loan_installment_amount_01.Name = "c_loan_installment_amount_01";
            // 
            // c_loan_installment_amount_02
            // 
            this.c_loan_installment_amount_02.DataMember = "Query";
            this.c_loan_installment_amount_02.Expression = "Iif( [LOAN_PAYMENT_TYPE_CODE] = \'02\', [LOAN_INSTALLMENT_AMOUNT] , \'\' )";
            this.c_loan_installment_amount_02.Name = "c_loan_installment_amount_02";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel7.CanGrow = false;
            this.xrLabel7.Dpi = 254F;
            this.xrLabel7.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(905F, 60F);
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "สรุปรายการหัก";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(908F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(210F, 60F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "เงินต้น";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel3.CanGrow = false;
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(1334F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(220F, 60F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "รวม";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel2.CanGrow = false;
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(1121F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(210F, 60F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "ดอกเบี้ย";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel9.CanGrow = false;
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT")});
            this.xrLabel9.Dpi = 254F;
            this.xrLabel9.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(908F, 6.000012F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(210F, 60F);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:n2}";
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel9.Summary = xrSummary1;
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel10.CanGrow = false;
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT")});
            this.xrLabel10.Dpi = 254F;
            this.xrLabel10.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(1121F, 6.000012F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(209.9999F, 60F);
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:n2}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel10.Summary = xrSummary2;
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel11.CanGrow = false;
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ITEM_AMOUNT")});
            this.xrLabel11.Dpi = 254F;
            this.xrLabel11.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(1334F, 6F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(220F, 60F);
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:n2}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel11.Summary = xrSummary3;
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel7,
            this.xrLabel1,
            this.xrLabel2,
            this.xrLabel3});
            this.ReportHeader.Dpi = 254F;
            this.ReportHeader.HeightF = 60F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel9,
            this.xrLabel10,
            this.xrLabel11});
            this.ReportFooter.Dpi = 254F;
            this.ReportFooter.HeightF = 67.00002F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // r_tge_loan_create_clr_sum_paid_multi
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.c_mem_name,
            this.c_loan_objective_des,
            this.c_group_no,
            this.c_group_district_name,
            this.c_address_no,
            this.c_moo,
            this.c_road_soi,
            this.c_tambol,
            this.c_district_name,
            this.c_province_name,
            this.c_postcode,
            this.c_telephone,
            this.c_coll_name,
            this.c_road,
            this.c_soi,
            this.c_period_payment_amount_01,
            this.c_period_payment_amount_02,
            this.c_last_payment_amount_01,
            this.c_last_payment_amount_02,
            this.c_loan_installment_amount_01,
            this.c_loan_installment_amount_02});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Dpi = 254F;
            this.Font = new System.Drawing.Font("BrowalliaUPC", 16F);
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageHeight = 2970;
            this.PageWidth = 2100;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 25F;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.CalculatedField c_mem_name;
        private DevExpress.XtraReports.UI.CalculatedField c_loan_objective_des;
        private DevExpress.XtraReports.UI.CalculatedField c_group_no;
        private DevExpress.XtraReports.UI.CalculatedField c_group_district_name;
        private DevExpress.XtraReports.UI.CalculatedField c_address_no;
        private DevExpress.XtraReports.UI.CalculatedField c_moo;
        private DevExpress.XtraReports.UI.CalculatedField c_road_soi;
        private DevExpress.XtraReports.UI.CalculatedField c_tambol;
        private DevExpress.XtraReports.UI.CalculatedField c_district_name;
        private DevExpress.XtraReports.UI.CalculatedField c_province_name;
        private DevExpress.XtraReports.UI.CalculatedField c_postcode;
        private DevExpress.XtraReports.UI.CalculatedField c_telephone;
        private DevExpress.XtraReports.UI.CalculatedField c_coll_name;
        private DevExpress.XtraReports.UI.CalculatedField c_road;
        private DevExpress.XtraReports.UI.CalculatedField c_soi;
        private DevExpress.XtraReports.UI.CalculatedField c_period_payment_amount_01;
        private DevExpress.XtraReports.UI.CalculatedField c_period_payment_amount_02;
        private DevExpress.XtraReports.UI.CalculatedField c_last_payment_amount_01;
        private DevExpress.XtraReports.UI.CalculatedField c_last_payment_amount_02;
        private DevExpress.XtraReports.UI.CalculatedField c_loan_installment_amount_01;
        private DevExpress.XtraReports.UI.CalculatedField c_loan_installment_amount_02;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
    }
}
