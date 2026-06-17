namespace scReport.Reports.rcTeller.lonSpec
{
    partial class r_ktm_receipt_payment_sum_clr_atm
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
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_ktm_receipt_payment_sum_clr_atm));
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.receipt_no = new DevExpress.XtraReports.UI.FormattingRule();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.t_header_publish_date = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.t_header_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.t_header_2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.c_money_type = new DevExpress.XtraReports.UI.CalculatedField();
            this.calculatedField3 = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_net = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_trim_entry_item = new DevExpress.XtraReports.UI.CalculatedField();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.cash = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.c_branch = new DevExpress.XtraReports.UI.CalculatedField();
            this.calculatedField6 = new DevExpress.XtraReports.UI.CalculatedField();
            this.xrCrossBandBox1 = new DevExpress.XtraReports.UI.XRCrossBandBox();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrCrossBandBox5 = new DevExpress.XtraReports.UI.XRCrossBandBox();
            this.xrCrossBandBox7 = new DevExpress.XtraReports.UI.XRCrossBandBox();
            this.xrCrossBandBox8 = new DevExpress.XtraReports.UI.XRCrossBandBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel16,
            this.xrLabel20,
            this.xrLabel22,
            this.xrLabel23});
            this.Detail.Dpi = 100F;
            this.Detail.Font = new System.Drawing.Font("BrowalliaUPC", 12F);
            this.Detail.HeightF = 25.00004F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("RECEIPT_DATE", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("CASE_ITEM_TYPE_NAME", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("LOAN_TYPE_DES", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.Detail.StylePriority.UseFont = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel16
            // 
            this.xrLabel16.CanGrow = false;
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.CASE_ITEM_TYPE_NAME")});
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(29.81771F, 0F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.ProcessDuplicatesMode = DevExpress.XtraReports.UI.ProcessDuplicatesMode.Merge;
            this.xrLabel16.SizeF = new System.Drawing.SizeF(306.6405F, 25F);
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:#,#}.";
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            this.xrLabel16.Summary = xrSummary1;
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel20
            // 
            this.xrLabel20.CanGrow = false;
            this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT", "{0:n2}")});
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(338.5417F, 0F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.ProcessDuplicatesMode = DevExpress.XtraReports.UI.ProcessDuplicatesMode.Merge;
            this.xrLabel20.SizeF = new System.Drawing.SizeF(160.4167F, 25F);
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel22
            // 
            this.xrLabel22.CanGrow = false;
            this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT", "{0:n2}")});
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(501.0417F, 0F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(147.9166F, 25F);
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "xrLabel22";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel23
            // 
            this.xrLabel23.CanGrow = false;
            this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ITEM_AMOUNT", "{0:n2}")});
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(651.0417F, 0F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(147.9166F, 25F);
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "xrLabel23";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // receipt_no
            // 
            this.receipt_no.Condition = "Iif( [RECEIPT_STATUS] = \'0\' , False , True )";
            // 
            // 
            // 
            this.receipt_no.Formatting.Font = new System.Drawing.Font("BrowalliaUPC", 12F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receipt_no.Formatting.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.receipt_no.Name = "receipt_no";
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
            this.BottomMargin.HeightF = 42.23493F;
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
            this.xrLabel33,
            this.xrLabel15,
            this.t_header_publish_date,
            this.xrPageInfo3,
            this.t_header_1,
            this.t_header_2});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.PageHeader.HeightF = 112.5F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.StylePriority.UseFont = false;
            // 
            // xrLabel33
            // 
            this.xrLabel33.CanGrow = false;
            this.xrLabel33.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.RECEIPT_DATE", "วันที่  {0:dd/MM/yyyy}")});
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("BrowalliaUPC", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(0F, 75F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(405.1845F, 37.5F);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel15
            // 
            this.xrLabel15.CanGrow = false;
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_branch")});
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("BrowalliaUPC", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(471.8751F, 75F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(328.125F, 37.5F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // t_header_publish_date
            // 
            this.t_header_publish_date.Dpi = 100F;
            this.t_header_publish_date.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.t_header_publish_date.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.t_header_publish_date.Name = "t_header_publish_date";
            this.t_header_publish_date.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t_header_publish_date.SizeF = new System.Drawing.SizeF(337.5F, 25F);
            this.t_header_publish_date.StylePriority.UseFont = false;
            this.t_header_publish_date.StylePriority.UseTextAlignment = false;
            this.t_header_publish_date.Text = "t_header_publish_date";
            this.t_header_publish_date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo3
            // 
            this.xrPageInfo3.Dpi = 100F;
            this.xrPageInfo3.Font = new System.Drawing.Font("BrowalliaUPC", 14F, System.Drawing.FontStyle.Bold);
            this.xrPageInfo3.Format = "หน้า {0}/ {1}";
            this.xrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(337.5F, 0F);
            this.xrPageInfo3.Name = "xrPageInfo3";
            this.xrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo3.SizeF = new System.Drawing.SizeF(462.5001F, 25F);
            this.xrPageInfo3.StylePriority.UseFont = false;
            this.xrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // t_header_1
            // 
            this.t_header_1.Dpi = 100F;
            this.t_header_1.Font = new System.Drawing.Font("BrowalliaUPC", 14F, System.Drawing.FontStyle.Bold);
            this.t_header_1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.t_header_1.Name = "t_header_1";
            this.t_header_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t_header_1.SizeF = new System.Drawing.SizeF(800.0001F, 25F);
            this.t_header_1.StylePriority.UseFont = false;
            this.t_header_1.StylePriority.UseTextAlignment = false;
            this.t_header_1.Text = "t_header_1 <sc_cnt_m_coop.coop_name>";
            this.t_header_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // t_header_2
            // 
            this.t_header_2.Dpi = 100F;
            this.t_header_2.Font = new System.Drawing.Font("BrowalliaUPC", 14F, System.Drawing.FontStyle.Bold);
            this.t_header_2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50F);
            this.t_header_2.Name = "t_header_2";
            this.t_header_2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t_header_2.SizeF = new System.Drawing.SizeF(800.0001F, 25F);
            this.t_header_2.StylePriority.UseFont = false;
            this.t_header_2.StylePriority.UseTextAlignment = false;
            this.t_header_2.Text = "t_header_2 <si_rep_reps.rep_text>";
            this.t_header_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel9.CanGrow = false;
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("BrowalliaUPC", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(650.0001F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(150F, 30.00002F);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "สุทธิ";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel8.CanGrow = false;
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("BrowalliaUPC", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(500.0001F, 3.178914E-05F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(149.9999F, 30F);
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "ดอกเบี้ย";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel7.CanGrow = false;
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("BrowalliaUPC", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(337.5001F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(162.5F, 30F);
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "เงินต้น";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel6.CanGrow = false;
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("BrowalliaUPC", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.ForeColor = System.Drawing.Color.Black;
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(12.5F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(325F, 30F);
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseForeColor = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "ประเภท";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("RECEIPT_DATE", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 32F;
            this.GroupHeader1.Level = 1;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // c_money_type
            // 
            this.c_money_type.DataMember = "Query";
            this.c_money_type.Expression = "\'ประเภท\' + \'  \' +  Trim([MONEY_TYPE_ID]) + \' : \' + Trim([MONEY_TYPE_NAME])";
            this.c_money_type.Name = "c_money_type";
            // 
            // calculatedField3
            // 
            this.calculatedField3.DataMember = "Query";
            this.calculatedField3.DisplayName = "c_seq";
            this.calculatedField3.Name = "calculatedField3";
            // 
            // c_net
            // 
            this.c_net.DataMember = "Query";
            this.c_net.Expression = "Iif([RECEIPT_STATUS] = \'0\' , ToDecimal([ITEM_AMOUNT]) , \'ยกเลิก\' + Iif([RECEIPT_D" +
    "ATE] <> [CANCEL_DATE] , [TDATE_CANCEL_DATE] + \' \' +  \'by\' + \' \' + Trim([CANCEL_I" +
    "D]) , \'\'  ) )";
            this.c_net.Name = "c_net";
            // 
            // c_trim_entry_item
            // 
            this.c_trim_entry_item.DataMember = "Query";
            this.c_trim_entry_item.Expression = "Trim([ENTRY_ID])";
            this.c_trim_entry_item.Name = "c_trim_entry_item";
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel36,
            this.cash,
            this.xrLabel31,
            this.xrLabel30,
            this.xrLabel28,
            this.xrLabel14});
            this.GroupFooter2.Dpi = 100F;
            this.GroupFooter2.Font = new System.Drawing.Font("BrowalliaUPC", 12F);
            this.GroupFooter2.HeightF = 431.2346F;
            this.GroupFooter2.Name = "GroupFooter2";
            this.GroupFooter2.StylePriority.UseFont = false;
            // 
            // xrLabel36
            // 
            this.xrLabel36.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel36.CanGrow = false;
            this.xrLabel36.Dpi = 100F;
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(12.5F, 0F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.ProcessDuplicatesMode = DevExpress.XtraReports.UI.ProcessDuplicatesMode.Merge;
            this.xrLabel36.SizeF = new System.Drawing.SizeF(34.58333F, 30F);
            this.xrLabel36.StylePriority.UseBorders = false;
            this.xrLabel36.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:n2}";
            xrSummary2.IgnoreNullValues = true;
            this.xrLabel36.Summary = xrSummary2;
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // cash
            // 
            this.cash.Dpi = 100F;
            this.cash.LocationFloat = new DevExpress.Utils.PointFloat(13.54167F, 37.5F);
            this.cash.Name = "cash";
            this.cash.SizeF = new System.Drawing.SizeF(526.8475F, 383.7346F);
            this.cash.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.cash_BeforePrint);
            // 
            // xrLabel31
            // 
            this.xrLabel31.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel31.CanGrow = false;
            this.xrLabel31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ITEM_AMOUNT")});
            this.xrLabel31.Dpi = 100F;
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(650F, 3.051758E-05F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.ProcessDuplicatesMode = DevExpress.XtraReports.UI.ProcessDuplicatesMode.Merge;
            this.xrLabel31.SizeF = new System.Drawing.SizeF(150F, 29.99997F);
            this.xrLabel31.StylePriority.UseBorders = false;
            this.xrLabel31.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:n2}";
            xrSummary3.IgnoreNullValues = true;
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel31.Summary = xrSummary3;
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel30
            // 
            this.xrLabel30.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel30.CanGrow = false;
            this.xrLabel30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT")});
            this.xrLabel30.Dpi = 100F;
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(500F, 0F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.ProcessDuplicatesMode = DevExpress.XtraReports.UI.ProcessDuplicatesMode.Merge;
            this.xrLabel30.SizeF = new System.Drawing.SizeF(150F, 30F);
            this.xrLabel30.StylePriority.UseBorders = false;
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            xrSummary4.FormatString = "{0:n2}";
            xrSummary4.IgnoreNullValues = true;
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel30.Summary = xrSummary4;
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel28
            // 
            this.xrLabel28.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel28.CanGrow = false;
            this.xrLabel28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT")});
            this.xrLabel28.Dpi = 100F;
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(337.5F, 2.445318E-05F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.ProcessDuplicatesMode = DevExpress.XtraReports.UI.ProcessDuplicatesMode.Merge;
            this.xrLabel28.SizeF = new System.Drawing.SizeF(162.5F, 30F);
            this.xrLabel28.StylePriority.UseBorders = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            xrSummary5.FormatString = "{0:n2}";
            xrSummary5.IgnoreNullValues = true;
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel28.Summary = xrSummary5;
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel14.CanGrow = false;
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.RECEIPT_DATE", "รวมหักกลบ วันที่ {0:dd/MM/yyyy}")});
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(47.08333F, 0F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(290.4167F, 30F);
            this.xrLabel14.StylePriority.UseBorders = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // c_branch
            // 
            this.c_branch.DataMember = "Query";
            this.c_branch.Expression = "\'สาขา\' + \'  \' + [BRANCH_ID] + \' : \' + [BRANCH_NAME]";
            this.c_branch.Name = "c_branch";
            // 
            // calculatedField6
            // 
            this.calculatedField6.DataMember = "Query";
            this.calculatedField6.DisplayName = "c_money_trans_return";
            this.calculatedField6.Expression = "Iif([RECEIPT_STATUS] = \'0\', [MONEY_TRANS_RETURN] , 0 )";
            this.calculatedField6.Name = "calculatedField6";
            // 
            // xrCrossBandBox1
            // 
            this.xrCrossBandBox1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrCrossBandBox1.BorderWidth = 1F;
            this.xrCrossBandBox1.Dpi = 100F;
            this.xrCrossBandBox1.EndBand = this.GroupFooter2;
            this.xrCrossBandBox1.EndPointFloat = new DevExpress.Utils.PointFloat(12.5F, 0F);
            this.xrCrossBandBox1.LocationFloat = new DevExpress.Utils.PointFloat(12.5F, 29.99999F);
            this.xrCrossBandBox1.Name = "xrCrossBandBox1";
            this.xrCrossBandBox1.StartBand = this.GroupHeader1;
            this.xrCrossBandBox1.StartPointFloat = new DevExpress.Utils.PointFloat(12.5F, 29.99999F);
            this.xrCrossBandBox1.WidthF = 325F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.Expanded = false;
            this.GroupFooter1.HeightF = 0F;
            this.GroupFooter1.Level = 1;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // xrCrossBandBox5
            // 
            this.xrCrossBandBox5.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.xrCrossBandBox5.BorderWidth = 1F;
            this.xrCrossBandBox5.Dpi = 100F;
            this.xrCrossBandBox5.EndBand = this.GroupFooter2;
            this.xrCrossBandBox5.EndPointFloat = new DevExpress.Utils.PointFloat(337.5F, 0F);
            this.xrCrossBandBox5.LocationFloat = new DevExpress.Utils.PointFloat(337.5F, 29.99999F);
            this.xrCrossBandBox5.Name = "xrCrossBandBox5";
            this.xrCrossBandBox5.StartBand = this.GroupHeader1;
            this.xrCrossBandBox5.StartPointFloat = new DevExpress.Utils.PointFloat(337.5F, 29.99999F);
            this.xrCrossBandBox5.WidthF = 162.5001F;
            // 
            // xrCrossBandBox7
            // 
            this.xrCrossBandBox7.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.xrCrossBandBox7.BorderWidth = 1F;
            this.xrCrossBandBox7.Dpi = 100F;
            this.xrCrossBandBox7.EndBand = this.GroupFooter2;
            this.xrCrossBandBox7.EndPointFloat = new DevExpress.Utils.PointFloat(500F, 0F);
            this.xrCrossBandBox7.LocationFloat = new DevExpress.Utils.PointFloat(500F, 29.99999F);
            this.xrCrossBandBox7.Name = "xrCrossBandBox7";
            this.xrCrossBandBox7.StartBand = this.GroupHeader1;
            this.xrCrossBandBox7.StartPointFloat = new DevExpress.Utils.PointFloat(500F, 29.99999F);
            this.xrCrossBandBox7.WidthF = 150F;
            // 
            // xrCrossBandBox8
            // 
            this.xrCrossBandBox8.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.xrCrossBandBox8.BorderWidth = 1F;
            this.xrCrossBandBox8.Dpi = 100F;
            this.xrCrossBandBox8.EndBand = this.GroupFooter2;
            this.xrCrossBandBox8.EndPointFloat = new DevExpress.Utils.PointFloat(650F, 0F);
            this.xrCrossBandBox8.LocationFloat = new DevExpress.Utils.PointFloat(650F, 30.02451F);
            this.xrCrossBandBox8.Name = "xrCrossBandBox8";
            this.xrCrossBandBox8.StartBand = this.GroupHeader1;
            this.xrCrossBandBox8.StartPointFloat = new DevExpress.Utils.PointFloat(650F, 30.02451F);
            this.xrCrossBandBox8.WidthF = 150F;
            // 
            // r_ktm_receipt_payment_sum_clr_atm
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.GroupHeader1,
            this.GroupFooter2,
            this.GroupFooter1});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.c_money_type,
            this.calculatedField3,
            this.c_net,
            this.calculatedField6,
            this.c_trim_entry_item,
            this.c_branch});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.CrossBandControls.AddRange(new DevExpress.XtraReports.UI.XRCrossBandControl[] {
            this.xrCrossBandBox8,
            this.xrCrossBandBox7,
            this.xrCrossBandBox5,
            this.xrCrossBandBox1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.receipt_no});
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 42);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel t_header_publish_date;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo3;
        private DevExpress.XtraReports.UI.XRLabel t_header_1;
        private DevExpress.XtraReports.UI.XRLabel t_header_2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.CalculatedField c_money_type;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRLabel xrLabel23;
        private DevExpress.XtraReports.UI.CalculatedField calculatedField3;
        private DevExpress.XtraReports.UI.CalculatedField c_net;
        private DevExpress.XtraReports.UI.CalculatedField c_trim_entry_item;
        private DevExpress.XtraReports.UI.FormattingRule receipt_no;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.CalculatedField c_branch;
        private DevExpress.XtraReports.UI.XRLabel xrLabel33;
        private DevExpress.XtraReports.UI.XRLabel xrLabel28;
        private DevExpress.XtraReports.UI.XRLabel xrLabel30;
        private DevExpress.XtraReports.UI.XRLabel xrLabel31;
        private DevExpress.XtraReports.UI.CalculatedField calculatedField6;
        private DevExpress.XtraReports.UI.XRCrossBandBox xrCrossBandBox1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRCrossBandBox xrCrossBandBox5;
        private DevExpress.XtraReports.UI.XRCrossBandBox xrCrossBandBox7;
        private DevExpress.XtraReports.UI.XRCrossBandBox xrCrossBandBox8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel36;
        private DevExpress.XtraReports.UI.XRSubreport cash;
    }
}
