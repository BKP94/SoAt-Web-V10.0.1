namespace scReport.Reports.rcTeller.memStockdue
{
    partial class r_ktm_member_record_nest_loan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_ktm_member_record_nest_loan));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
            this.c_sign_de = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_int = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_sign_1 = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_int_1 = new DevExpress.XtraReports.UI.CalculatedField();
            this.f_item_BF = new DevExpress.XtraReports.UI.FormattingRule();
            this.f_ref_loan_doc_no = new DevExpress.XtraReports.UI.FormattingRule();
            this.f_sign = new DevExpress.XtraReports.UI.FormattingRule();
            this.f_sign_de = new DevExpress.XtraReports.UI.FormattingRule();
            this.f_sign_1 = new DevExpress.XtraReports.UI.FormattingRule();
            this.c_int_lon = new DevExpress.XtraReports.UI.CalculatedField();
            this.f_int_lon = new DevExpress.XtraReports.UI.FormattingRule();
            this.c_Keep_it_money = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_ref_no = new DevExpress.XtraReports.UI.CalculatedField();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel53 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel54 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel96 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel60 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel97 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel98 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel99 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel100 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel101 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel102 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel103 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel104 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel53,
            this.xrLabel54,
            this.xrLabel96,
            this.xrLabel60,
            this.xrLabel97,
            this.xrLabel98,
            this.xrLabel99,
            this.xrLabel100,
            this.xrLabel101,
            this.xrLabel102,
            this.xrLabel103,
            this.xrLabel104});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            // GroupHeader1
            // 
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("LOAN_CONTRACT_NO", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 0F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel52});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 12.5F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // xrLabel52
            // 
            this.xrLabel52.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel52.CanGrow = false;
            this.xrLabel52.Dpi = 100F;
            this.xrLabel52.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel52.Name = "xrLabel52";
            this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel52.SizeF = new System.Drawing.SizeF(937.5F, 12.5F);
            this.xrLabel52.StylePriority.UseBorders = false;
            // 
            // c_sign_de
            // 
            this.c_sign_de.DataMember = "Query";
            this.c_sign_de.Expression = "Iif([SIGN_STATUS] = -1, [PAYMENT_AMOUNT] , 0 )";
            this.c_sign_de.Name = "c_sign_de";
            // 
            // c_int
            // 
            this.c_int.DataMember = "Query";
            this.c_int.Expression = "Iif([SIGN_STATUS] = -1 , [INTEREST_AMOUT] , 0 )";
            this.c_int.Name = "c_int";
            // 
            // c_sign_1
            // 
            this.c_sign_1.DataMember = "Query";
            this.c_sign_1.Expression = "Iif([SIGN_STATUS] = 1 , [PAYMENT_AMOUNT] , 0)";
            this.c_sign_1.Name = "c_sign_1";
            // 
            // c_int_1
            // 
            this.c_int_1.DataMember = "Query";
            this.c_int_1.Expression = "Iif([SIGN_STATUS] = 1 , [INTEREST_AMOUT] , 0 )";
            this.c_int_1.Name = "c_int_1";
            // 
            // f_item_BF
            // 
            this.f_item_BF.Condition = "Iif([ITEM_TYPE_CODE] = \'01\' or [ITEM_TYPE_CODE] = \'BF\', true , false )";
            this.f_item_BF.Name = "f_item_BF";
            // 
            // f_ref_loan_doc_no
            // 
            this.f_ref_loan_doc_no.Condition = "Iif([REF_LOAN_DOC_NO][0] = [REF_LOAN_DOC_NO][-1] , true ,false )";
            this.f_ref_loan_doc_no.Name = "f_ref_loan_doc_no";
            // 
            // f_sign
            // 
            this.f_sign.Condition = "Iif( [SIGN_STATUS] = \'-1 \', true , false )";
            this.f_sign.Name = "f_sign";
            // 
            // f_sign_de
            // 
            this.f_sign_de.Condition = "Iif( [SIGN_STATUS] = \'-1\', true , false )";
            this.f_sign_de.Name = "f_sign_de";
            // 
            // f_sign_1
            // 
            this.f_sign_1.Condition = "Iif( [SIGN_STATUS] = \'1\', true , false )";
            this.f_sign_1.Name = "f_sign_1";
            // 
            // c_int_lon
            // 
            this.c_int_lon.DataMember = "Query";
            this.c_int_lon.Expression = "Iif([LOAN_CONTRACT_NO] [0] = [LOAN_CONTRACT_NO] [-1] , Iif([REF_LOAN_DOC_NO] [0] " +
    "= [REF_LOAN_DOC_NO] [-1], [PAYMENT_AMOUNT] [-1]  - [PAYMENT_AMOUNT] [0] ,0 ) ,0 " +
    ")";
            this.c_int_lon.Name = "c_int_lon";
            // 
            // f_int_lon
            // 
            this.f_int_lon.Condition = "Iif([REF_LOAN_DOC_NO][0] = [REF_LOAN_DOC_NO][-1]  , true ,false )";
            this.f_int_lon.Name = "f_int_lon";
            // 
            // c_Keep_it_money
            // 
            this.c_Keep_it_money.DataMember = "Query";
            this.c_Keep_it_money.Expression = "Iif([LOAN_CONTRACT_NO] [0] = [LOAN_CONTRACT_NO] [-1] , Iif([REF_LOAN_DOC_NO] [0] " +
    "= [REF_LOAN_DOC_NO] [-1], [INTEREST_AMOUT] [-1]   - [INTEREST_AMOUT] [0], 0 ) , " +
    "0 )";
            this.c_Keep_it_money.Name = "c_Keep_it_money";
            // 
            // c_ref_no
            // 
            this.c_ref_no.DataMember = "Query";
            this.c_ref_no.Expression = "Iif([REF_LOAN_DOC_NO] [0] = [REF_LOAN_DOC_NO] [-1], \'\' , \'  \' + [REF_LOAN_DOC_NO]" +
    " )";
            this.c_ref_no.Name = "c_ref_no";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LOAN_CONTRACT_NO", "{0:dd/MM/yyyy}")});
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0.25F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ProcessDuplicatesMode = DevExpress.XtraReports.UI.ProcessDuplicatesMode.Merge;
            this.xrLabel1.SizeF = new System.Drawing.SizeF(68.75F, 25F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.Text = "xrLabel1";
            // 
            // xrLabel53
            // 
            this.xrLabel53.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel53.CanGrow = false;
            this.xrLabel53.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LOAN_PAYMENT_DATE", "{0:dd/MM/yyyy}")});
            this.xrLabel53.Dpi = 100F;
            this.xrLabel53.LocationFloat = new DevExpress.Utils.PointFloat(69.00006F, 0F);
            this.xrLabel53.Name = "xrLabel53";
            this.xrLabel53.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel53.SizeF = new System.Drawing.SizeF(62.49994F, 25F);
            this.xrLabel53.StylePriority.UseBorders = false;
            this.xrLabel53.StylePriority.UseTextAlignment = false;
            this.xrLabel53.Text = "xrLabel2";
            this.xrLabel53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel54
            // 
            this.xrLabel54.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel54.CanGrow = false;
            this.xrLabel54.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ITEM_TYPE_CODE", "{0:n2}")});
            this.xrLabel54.Dpi = 100F;
            this.xrLabel54.LocationFloat = new DevExpress.Utils.PointFloat(131.5F, 0F);
            this.xrLabel54.Name = "xrLabel54";
            this.xrLabel54.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel54.SizeF = new System.Drawing.SizeF(43.75F, 25F);
            this.xrLabel54.StylePriority.UseBorders = false;
            this.xrLabel54.StylePriority.UseTextAlignment = false;
            this.xrLabel54.Text = "xrLabel3";
            this.xrLabel54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel96
            // 
            this.xrLabel96.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel96.CanGrow = false;
            this.xrLabel96.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LOAN_APPROVE_AMOUNT", "{0:n2}")});
            this.xrLabel96.Dpi = 100F;
            this.xrLabel96.LocationFloat = new DevExpress.Utils.PointFloat(175.25F, 0F);
            this.xrLabel96.Name = "xrLabel96";
            this.xrLabel96.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel96.ProcessDuplicatesMode = DevExpress.XtraReports.UI.ProcessDuplicatesMode.Merge;
            this.xrLabel96.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel96.StylePriority.UseBorders = false;
            this.xrLabel96.StylePriority.UseTextAlignment = false;
            this.xrLabel96.Text = "xrLabel4";
            this.xrLabel96.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel60
            // 
            this.xrLabel60.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel60.CanGrow = false;
            this.xrLabel60.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PERIOD")});
            this.xrLabel60.Dpi = 100F;
            this.xrLabel60.LocationFloat = new DevExpress.Utils.PointFloat(262.75F, 0F);
            this.xrLabel60.Name = "xrLabel60";
            this.xrLabel60.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel60.SizeF = new System.Drawing.SizeF(50F, 25F);
            this.xrLabel60.StylePriority.UseBorders = false;
            this.xrLabel60.StylePriority.UseTextAlignment = false;
            this.xrLabel60.Text = "xrLabel6";
            this.xrLabel60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel97
            // 
            this.xrLabel97.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel97.CanGrow = false;
            this.xrLabel97.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_sign_de", "{0:n2}")});
            this.xrLabel97.Dpi = 100F;
            this.xrLabel97.LocationFloat = new DevExpress.Utils.PointFloat(312.75F, 0F);
            this.xrLabel97.Name = "xrLabel97";
            this.xrLabel97.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel97.SizeF = new System.Drawing.SizeF(85.41663F, 25F);
            this.xrLabel97.StylePriority.UseBorders = false;
            this.xrLabel97.StylePriority.UseTextAlignment = false;
            this.xrLabel97.Text = "xrLabel7";
            this.xrLabel97.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel98
            // 
            this.xrLabel98.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel98.CanGrow = false;
            this.xrLabel98.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_int", "{0:n2}")});
            this.xrLabel98.Dpi = 100F;
            this.xrLabel98.LocationFloat = new DevExpress.Utils.PointFloat(398.1666F, 0F);
            this.xrLabel98.Name = "xrLabel98";
            this.xrLabel98.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel98.SizeF = new System.Drawing.SizeF(62.5F, 25F);
            this.xrLabel98.StylePriority.UseBorders = false;
            this.xrLabel98.StylePriority.UseTextAlignment = false;
            this.xrLabel98.Text = "xrLabel8";
            this.xrLabel98.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel99
            // 
            this.xrLabel99.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel99.CanGrow = false;
            this.xrLabel99.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_sign_1", "{0:n2}")});
            this.xrLabel99.Dpi = 100F;
            this.xrLabel99.ForeColor = System.Drawing.Color.Black;
            this.xrLabel99.LocationFloat = new DevExpress.Utils.PointFloat(460.6666F, 0F);
            this.xrLabel99.Name = "xrLabel99";
            this.xrLabel99.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel99.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel99.StylePriority.UseBorders = false;
            this.xrLabel99.StylePriority.UseForeColor = false;
            this.xrLabel99.StylePriority.UseTextAlignment = false;
            this.xrLabel99.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel100
            // 
            this.xrLabel100.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel100.CanGrow = false;
            this.xrLabel100.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_int_1", "{0:n2}")});
            this.xrLabel100.Dpi = 100F;
            this.xrLabel100.ForeColor = System.Drawing.Color.Black;
            this.xrLabel100.LocationFloat = new DevExpress.Utils.PointFloat(535.6666F, 0F);
            this.xrLabel100.Name = "xrLabel100";
            this.xrLabel100.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel100.SizeF = new System.Drawing.SizeF(77.08337F, 25F);
            this.xrLabel100.StylePriority.UseBorders = false;
            this.xrLabel100.StylePriority.UseForeColor = false;
            this.xrLabel100.StylePriority.UseTextAlignment = false;
            this.xrLabel100.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel101
            // 
            this.xrLabel101.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel101.CanGrow = false;
            this.xrLabel101.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_int_lon", "{0:n2}")});
            this.xrLabel101.Dpi = 100F;
            this.xrLabel101.LocationFloat = new DevExpress.Utils.PointFloat(612.75F, 0F);
            this.xrLabel101.Name = "xrLabel101";
            this.xrLabel101.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel101.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel101.StylePriority.UseBorders = false;
            this.xrLabel101.StylePriority.UseTextAlignment = false;
            this.xrLabel101.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel102
            // 
            this.xrLabel102.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel102.CanGrow = false;
            this.xrLabel102.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_Keep_it_money", "{0:n2}")});
            this.xrLabel102.Dpi = 100F;
            this.xrLabel102.LocationFloat = new DevExpress.Utils.PointFloat(687.75F, 0F);
            this.xrLabel102.Name = "xrLabel102";
            this.xrLabel102.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel102.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel102.StylePriority.UseBorders = false;
            this.xrLabel102.StylePriority.UseTextAlignment = false;
            this.xrLabel102.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel103
            // 
            this.xrLabel103.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel103.CanGrow = false;
            this.xrLabel103.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_BALANCE", "{0:n2}")});
            this.xrLabel103.Dpi = 100F;
            this.xrLabel103.LocationFloat = new DevExpress.Utils.PointFloat(762.75F, 0F);
            this.xrLabel103.Name = "xrLabel103";
            this.xrLabel103.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel103.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel103.StylePriority.UseBorders = false;
            this.xrLabel103.StylePriority.UseTextAlignment = false;
            this.xrLabel103.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel104
            // 
            this.xrLabel104.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel104.CanGrow = false;
            this.xrLabel104.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.REF_LOAN_DOC_NO")});
            this.xrLabel104.Dpi = 100F;
            this.xrLabel104.LocationFloat = new DevExpress.Utils.PointFloat(850.25F, 0F);
            this.xrLabel104.Name = "xrLabel104";
            this.xrLabel104.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel104.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel104.StylePriority.UseBorders = false;
            this.xrLabel104.StylePriority.UseTextAlignment = false;
            this.xrLabel104.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // rd_skl_member_record_nest_loan
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupFooter1});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.c_sign_de,
            this.c_int,
            this.c_sign_1,
            this.c_int_1,
            this.c_int_lon,
            this.c_Keep_it_money,
            this.c_ref_no});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("BrowalliaUPC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.f_item_BF,
            this.f_ref_loan_doc_no,
            this.f_sign,
            this.f_sign_de,
            this.f_sign_1,
            this.f_int_lon});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(0, 231, 0, 0);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel52;
        private DevExpress.XtraReports.UI.CalculatedField c_sign_de;
        private DevExpress.XtraReports.UI.CalculatedField c_int;
        private DevExpress.XtraReports.UI.CalculatedField c_sign_1;
        private DevExpress.XtraReports.UI.CalculatedField c_int_1;
        private DevExpress.XtraReports.UI.FormattingRule f_item_BF;
        private DevExpress.XtraReports.UI.FormattingRule f_ref_loan_doc_no;
        private DevExpress.XtraReports.UI.FormattingRule f_sign;
        private DevExpress.XtraReports.UI.FormattingRule f_sign_de;
        private DevExpress.XtraReports.UI.FormattingRule f_sign_1;
        private DevExpress.XtraReports.UI.FormattingRule f_int_lon;
        private DevExpress.XtraReports.UI.CalculatedField c_int_lon;
        private DevExpress.XtraReports.UI.CalculatedField c_Keep_it_money;
        private DevExpress.XtraReports.UI.CalculatedField c_ref_no;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel53;
        private DevExpress.XtraReports.UI.XRLabel xrLabel54;
        private DevExpress.XtraReports.UI.XRLabel xrLabel96;
        private DevExpress.XtraReports.UI.XRLabel xrLabel60;
        private DevExpress.XtraReports.UI.XRLabel xrLabel97;
        private DevExpress.XtraReports.UI.XRLabel xrLabel98;
        private DevExpress.XtraReports.UI.XRLabel xrLabel99;
        private DevExpress.XtraReports.UI.XRLabel xrLabel100;
        private DevExpress.XtraReports.UI.XRLabel xrLabel101;
        private DevExpress.XtraReports.UI.XRLabel xrLabel102;
        private DevExpress.XtraReports.UI.XRLabel xrLabel103;
        private DevExpress.XtraReports.UI.XRLabel xrLabel104;
    }
}
