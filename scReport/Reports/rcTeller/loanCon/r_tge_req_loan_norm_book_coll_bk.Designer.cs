namespace scReport.Reports.rcTeller.loanCon
{
    partial class r_tge_req_loan_norm_book_coll_bk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_tge_req_loan_norm_book_coll_bk));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
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
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.calculatedField1 = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel3,
            this.xrLabel4,
            this.xrLabel5,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLabel9,
            this.xrLabel10,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel13});
            this.Detail.Dpi = 254F;
            this.Detail.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.Detail.HeightF = 1543.627F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            this.Detail.StylePriority.UseFont = false;
            this.Detail.StylePriority.UseTextAlignment = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.CanGrow = false;
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MEMNAME")});
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(579.0084F, 218.1999F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(563.89F, 55F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "xrLabel1";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.CanGrow = false;
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.COLLATERAL_DESCRIPTION")});
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(227.7933F, 306.1999F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(563.89F, 55F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "xrLabel1";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.CanGrow = false;
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.POSITION")});
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(122.2599F, 398.1999F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(563.89F, 55F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "xrLabel1";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.CanGrow = false;
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.GROUP_NAME")});
            this.xrLabel5.Dpi = 254F;
            this.xrLabel5.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(936.1899F, 398.1999F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(881.3883F, 55.00009F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "xrLabel1";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.CanGrow = false;
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.REF_OWN_NO")});
            this.xrLabel7.Dpi = 254F;
            this.xrLabel7.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(1043.01F, 306.1998F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(182.8884F, 55.00005F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "xrLabel1";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.CanGrow = false;
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.AGE_COLL")});
            this.xrLabel8.Dpi = 254F;
            this.xrLabel8.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(1339.16F, 306.1999F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(125.7384F, 55.00005F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "xrLabel1";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel9
            // 
            this.xrLabel9.CanGrow = false;
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ID_CARD")});
            this.xrLabel9.Dpi = 254F;
            this.xrLabel9.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(1699.935F, 306.1999F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(377.3215F, 55.00006F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "xrLabel1";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.CanGrow = false;
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MEMBER_ADDRESS")});
            this.xrLabel10.Dpi = 254F;
            this.xrLabel10.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(143.1266F, 486.9999F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(1929.13F, 55F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "xrLabel1";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel12
            // 
            this.xrLabel12.CanGrow = false;
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MEMNAME")});
            this.xrLabel12.Dpi = 254F;
            this.xrLabel12.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(239.7933F, 623.9999F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(563.89F, 55F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "xrLabel1";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.CanGrow = false;
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LOAN_REQUEST_AMOUNT", "{0:#,#}")});
            this.xrLabel11.Dpi = 254F;
            this.xrLabel11.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(1694.935F, 623.9999F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(263.33F, 55.00003F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "xrLabel1";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.CanGrow = false;
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.calculatedField1")});
            this.xrLabel13.Dpi = 254F;
            this.xrLabel13.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(35.74323F, 721.9999F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(709.94F, 55F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "xrLabel1";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            // GroupHeader1
            // 
            this.GroupHeader1.Dpi = 254F;
            this.GroupHeader1.Expanded = false;
            this.GroupHeader1.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("LOAN_REQUESTMENT_NO", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 152.3999F;
            this.GroupHeader1.KeepTogether = true;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.StylePriority.UseFont = false;
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
            // GroupFooter1
            // 
            this.GroupFooter1.Dpi = 254F;
            this.GroupFooter1.Expanded = false;
            this.GroupFooter1.HeightF = 254F;
            this.GroupFooter1.KeepTogether = true;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // calculatedField1
            // 
            this.calculatedField1.DataMember = "Query";
            this.calculatedField1.DisplayName = "C_LOAN_REQUEST_AMOUNT_THAI";
            this.calculatedField1.Expression = "\'( \' + [LOAN_REQUEST_AMOUNT_THAI] + \' )\'";
            this.calculatedField1.Name = "calculatedField1";
            // 
            // r_tge_req_loan_norm_book_coll_bk
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupFooter1});
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
            this.c_loan_installment_amount_02,
            this.calculatedField1});
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
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
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
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.CalculatedField calculatedField1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
    }
}
