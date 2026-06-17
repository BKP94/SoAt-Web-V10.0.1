namespace scReport.Reports.rcTeller.loanapp
{
    partial class r_tge_loan_create_share_clr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_tge_loan_create_share_clr));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
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
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel29,
            this.xrLabel30,
            this.xrLabel32,
            this.xrLabel31});
            this.Detail.Dpi = 254F;
            this.Detail.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.Detail.HeightF = 71.11993F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.StylePriority.UseFont = false;
            this.Detail.StylePriority.UseTextAlignment = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            // xrLabel29
            // 
            this.xrLabel29.CanGrow = false;
            this.xrLabel29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.DESCRIPTION")});
            this.xrLabel29.Dpi = 254F;
            this.xrLabel29.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(449.8036F, 71.11993F);
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            this.xrLabel29.Text = "xrLabel34";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel30
            // 
            this.xrLabel30.CanGrow = false;
            this.xrLabel30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT", "{0:n2}")});
            this.xrLabel30.Dpi = 254F;
            this.xrLabel30.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(457.4234F, 0F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(271.5935F, 71.11993F);
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            this.xrLabel30.Text = "xrLabel34";
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel32
            // 
            this.xrLabel32.CanGrow = false;
            this.xrLabel32.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ITEM_AMOUNT", "{0:n2}")});
            this.xrLabel32.Dpi = 254F;
            this.xrLabel32.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(972.2715F, 0F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(267.6082F, 71.11993F);
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            this.xrLabel32.Text = "xrLabel34";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel31
            // 
            this.xrLabel31.CanGrow = false;
            this.xrLabel31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT", "{0:n2}")});
            this.xrLabel31.Dpi = 254F;
            this.xrLabel31.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(736.6369F, 0F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(228.0146F, 71.11993F);
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.StylePriority.UseTextAlignment = false;
            this.xrLabel31.Text = "xrLabel34";
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // r_tge_loan_create_share_clr
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
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
        private DevExpress.XtraReports.UI.XRLabel xrLabel29;
        private DevExpress.XtraReports.UI.XRLabel xrLabel30;
        private DevExpress.XtraReports.UI.XRLabel xrLabel32;
        private DevExpress.XtraReports.UI.XRLabel xrLabel31;
    }
}
