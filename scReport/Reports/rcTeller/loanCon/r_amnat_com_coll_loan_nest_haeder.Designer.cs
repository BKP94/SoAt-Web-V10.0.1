namespace scReport.Reports.rcTeller.loanCon
{
    partial class r_amnat_com_coll_loan_nest_haeder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_amnat_com_coll_loan_nest_haeder));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.coll1 = new DevExpress.XtraReports.UI.FormattingRule();
            this.coll2 = new DevExpress.XtraReports.UI.FormattingRule();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.c_memname = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_add_guarantor = new DevExpress.XtraReports.UI.CalculatedField();
            this.xrLabel129 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel124 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel118 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel112 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel129,
            this.xrLabel124,
            this.xrLabel118,
            this.xrLabel112});
            this.Detail.Dpi = 254F;
            this.Detail.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.Detail.HeightF = 93.21333F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("REF_OWN_NO", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.Detail.StylePriority.UseFont = false;
            this.Detail.StylePriority.UseTextAlignment = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // coll1
            // 
            this.coll1.Condition = "Iif( [COLLATERAL_NO] = \'1\' , True , False )";
            this.coll1.Name = "coll1";
            // 
            // coll2
            // 
            this.coll2.Condition = "[COLLATERAL_NO] = \'2\'";
            this.coll2.Name = "coll2";
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
            // c_memname
            // 
            this.c_memname.DataMember = "Query";
            this.c_memname.Expression = "\'             \' +[MEMNAME_GUARANTOR]";
            this.c_memname.Name = "c_memname";
            // 
            // c_add_guarantor
            // 
            this.c_add_guarantor.DataMember = "Query";
            this.c_add_guarantor.Expression = "\'             \' +[ADD_GUARANTOR]";
            this.c_add_guarantor.Name = "c_add_guarantor";
            // 
            // xrLabel129
            // 
            this.xrLabel129.AutoWidth = true;
            this.xrLabel129.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel129.CanGrow = false;
            this.xrLabel129.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.TEL_GUARANTOR")});
            this.xrLabel129.Dpi = 254F;
            this.xrLabel129.Font = new System.Drawing.Font("BrowalliaUPC", 16F);
            this.xrLabel129.LocationFloat = new DevExpress.Utils.PointFloat(1310.796F, 0F);
            this.xrLabel129.Name = "xrLabel129";
            this.xrLabel129.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel129.SizeF = new System.Drawing.SizeF(376.7938F, 93.21332F);
            this.xrLabel129.StylePriority.UseBorders = false;
            this.xrLabel129.StylePriority.UseFont = false;
            this.xrLabel129.StylePriority.UseTextAlignment = false;
            this.xrLabel129.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel124
            // 
            this.xrLabel124.AutoWidth = true;
            this.xrLabel124.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel124.CanGrow = false;
            this.xrLabel124.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ADD_GUARANTOR")});
            this.xrLabel124.Dpi = 254F;
            this.xrLabel124.Font = new System.Drawing.Font("BrowalliaUPC", 16F);
            this.xrLabel124.LocationFloat = new DevExpress.Utils.PointFloat(785.764F, 0.0001912368F);
            this.xrLabel124.Name = "xrLabel124";
            this.xrLabel124.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel124.SizeF = new System.Drawing.SizeF(520.032F, 93.21313F);
            this.xrLabel124.StylePriority.UseBorders = false;
            this.xrLabel124.StylePriority.UseFont = false;
            this.xrLabel124.StylePriority.UseTextAlignment = false;
            this.xrLabel124.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel118
            // 
            this.xrLabel118.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel118.CanGrow = false;
            this.xrLabel118.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.REF_OWN_NO")});
            this.xrLabel118.Dpi = 254F;
            this.xrLabel118.Font = new System.Drawing.Font("BrowalliaUPC", 16F);
            this.xrLabel118.LocationFloat = new DevExpress.Utils.PointFloat(526.8073F, 0F);
            this.xrLabel118.Name = "xrLabel118";
            this.xrLabel118.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel118.SizeF = new System.Drawing.SizeF(253.9568F, 93.21332F);
            this.xrLabel118.StylePriority.UseBorders = false;
            this.xrLabel118.StylePriority.UseFont = false;
            this.xrLabel118.StylePriority.UseTextAlignment = false;
            this.xrLabel118.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel112
            // 
            this.xrLabel112.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel112.CanGrow = false;
            this.xrLabel112.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MEMNAME_GUARANTOR")});
            this.xrLabel112.Dpi = 254F;
            this.xrLabel112.Font = new System.Drawing.Font("BrowalliaUPC", 16F);
            this.xrLabel112.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel112.Name = "xrLabel112";
            this.xrLabel112.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel112.SizeF = new System.Drawing.SizeF(521.8071F, 93.21332F);
            this.xrLabel112.StylePriority.UseBorders = false;
            this.xrLabel112.StylePriority.UseFont = false;
            this.xrLabel112.StylePriority.UseTextAlignment = false;
            this.xrLabel112.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // r_amnat_com_coll_loan_nest_haeder
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.c_memname,
            this.c_add_guarantor});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Dpi = 254F;
            this.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.coll1,
            this.coll2});
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
        private DevExpress.XtraReports.UI.FormattingRule coll1;
        private DevExpress.XtraReports.UI.FormattingRule coll2;
        private DevExpress.XtraReports.UI.CalculatedField c_memname;
        private DevExpress.XtraReports.UI.CalculatedField c_add_guarantor;
        private DevExpress.XtraReports.UI.XRLabel xrLabel129;
        private DevExpress.XtraReports.UI.XRLabel xrLabel124;
        private DevExpress.XtraReports.UI.XRLabel xrLabel118;
        private DevExpress.XtraReports.UI.XRLabel xrLabel112;
    }
}
