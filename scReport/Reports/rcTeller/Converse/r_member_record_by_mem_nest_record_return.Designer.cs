namespace rcContract.KTM
{
    partial class r_member_record_by_mem_nest_record_return
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_member_record_by_mem_nest_record_return));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
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
            this.xrLabel68});
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
            // xrLabel78
            // 
            this.xrLabel78.CanGrow = false;
            this.xrLabel78.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.SPEC_INT", "{0:n2}")});
            this.xrLabel78.Dpi = 100F;
            this.xrLabel78.LocationFloat = new DevExpress.Utils.PointFloat(537.5F, 0F);
            this.xrLabel78.Name = "xrLabel78";
            this.xrLabel78.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel78.SizeF = new System.Drawing.SizeF(50F, 25F);
            this.xrLabel78.StylePriority.UseTextAlignment = false;
            this.xrLabel78.Text = "xrLabel3";
            this.xrLabel78.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel77
            // 
            this.xrLabel77.CanGrow = false;
            this.xrLabel77.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.SPEC_AMT", "{0:n2}")});
            this.xrLabel77.Dpi = 100F;
            this.xrLabel77.LocationFloat = new DevExpress.Utils.PointFloat(487.5F, 0F);
            this.xrLabel77.Name = "xrLabel77";
            this.xrLabel77.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel77.SizeF = new System.Drawing.SizeF(50F, 25F);
            this.xrLabel77.StylePriority.UseTextAlignment = false;
            this.xrLabel77.Text = "xrLabel3";
            this.xrLabel77.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel76
            // 
            this.xrLabel76.CanGrow = false;
            this.xrLabel76.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.NORM_INT", "{0:n2}")});
            this.xrLabel76.Dpi = 100F;
            this.xrLabel76.LocationFloat = new DevExpress.Utils.PointFloat(437.5F, 0F);
            this.xrLabel76.Name = "xrLabel76";
            this.xrLabel76.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel76.SizeF = new System.Drawing.SizeF(50F, 25F);
            this.xrLabel76.StylePriority.UseTextAlignment = false;
            this.xrLabel76.Text = "xrLabel3";
            this.xrLabel76.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel75
            // 
            this.xrLabel75.CanGrow = false;
            this.xrLabel75.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.NORM_AMT", "{0:n2}")});
            this.xrLabel75.Dpi = 100F;
            this.xrLabel75.LocationFloat = new DevExpress.Utils.PointFloat(387.5F, 0F);
            this.xrLabel75.Name = "xrLabel75";
            this.xrLabel75.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel75.SizeF = new System.Drawing.SizeF(50F, 25F);
            this.xrLabel75.StylePriority.UseTextAlignment = false;
            this.xrLabel75.Text = "xrLabel3";
            this.xrLabel75.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel74
            // 
            this.xrLabel74.CanGrow = false;
            this.xrLabel74.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.EMER_INT", "{0:n2}")});
            this.xrLabel74.Dpi = 100F;
            this.xrLabel74.LocationFloat = new DevExpress.Utils.PointFloat(337.5F, 0F);
            this.xrLabel74.Name = "xrLabel74";
            this.xrLabel74.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel74.SizeF = new System.Drawing.SizeF(50F, 25F);
            this.xrLabel74.StylePriority.UseTextAlignment = false;
            this.xrLabel74.Text = "xrLabel3";
            this.xrLabel74.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel73
            // 
            this.xrLabel73.CanGrow = false;
            this.xrLabel73.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.EMER_AMT", "{0:n2}")});
            this.xrLabel73.Dpi = 100F;
            this.xrLabel73.LocationFloat = new DevExpress.Utils.PointFloat(287.5F, 0F);
            this.xrLabel73.Name = "xrLabel73";
            this.xrLabel73.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel73.SizeF = new System.Drawing.SizeF(50F, 25F);
            this.xrLabel73.StylePriority.UseTextAlignment = false;
            this.xrLabel73.Text = "xrLabel3";
            this.xrLabel73.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel72
            // 
            this.xrLabel72.CanGrow = false;
            this.xrLabel72.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.SHARE_AMOUNT", "{0:n2}")});
            this.xrLabel72.Dpi = 100F;
            this.xrLabel72.LocationFloat = new DevExpress.Utils.PointFloat(225F, 0F);
            this.xrLabel72.Name = "xrLabel72";
            this.xrLabel72.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel72.SizeF = new System.Drawing.SizeF(62.5F, 25F);
            this.xrLabel72.StylePriority.UseTextAlignment = false;
            this.xrLabel72.Text = "xrLabel3";
            this.xrLabel72.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel71
            // 
            this.xrLabel71.CanGrow = false;
            this.xrLabel71.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.RECEIPT_NO")});
            this.xrLabel71.Dpi = 100F;
            this.xrLabel71.LocationFloat = new DevExpress.Utils.PointFloat(162.5F, 0F);
            this.xrLabel71.Name = "xrLabel71";
            this.xrLabel71.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel71.SizeF = new System.Drawing.SizeF(62.5F, 25F);
            this.xrLabel71.StylePriority.UseTextAlignment = false;
            this.xrLabel71.Text = "xrLabel3";
            this.xrLabel71.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel70
            // 
            this.xrLabel70.CanGrow = false;
            this.xrLabel70.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.RET_DATE")});
            this.xrLabel70.Dpi = 100F;
            this.xrLabel70.LocationFloat = new DevExpress.Utils.PointFloat(100F, 0F);
            this.xrLabel70.Name = "xrLabel70";
            this.xrLabel70.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel70.SizeF = new System.Drawing.SizeF(62.5F, 25F);
            this.xrLabel70.StylePriority.UseTextAlignment = false;
            this.xrLabel70.Text = "xrLabel3";
            this.xrLabel70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel69
            // 
            this.xrLabel69.CanGrow = false;
            this.xrLabel69.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MONTH")});
            this.xrLabel69.Dpi = 100F;
            this.xrLabel69.LocationFloat = new DevExpress.Utils.PointFloat(50F, 0F);
            this.xrLabel69.Name = "xrLabel69";
            this.xrLabel69.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel69.SizeF = new System.Drawing.SizeF(50F, 25F);
            this.xrLabel69.StylePriority.UseTextAlignment = false;
            this.xrLabel69.Text = "xrLabel2";
            this.xrLabel69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel68
            // 
            this.xrLabel68.CanGrow = false;
            this.xrLabel68.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.YEAR")});
            this.xrLabel68.Dpi = 100F;
            this.xrLabel68.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel68.Name = "xrLabel68";
            this.xrLabel68.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel68.SizeF = new System.Drawing.SizeF(50F, 25F);
            this.xrLabel68.StylePriority.UseTextAlignment = false;
            this.xrLabel68.Text = "xrLabel1";
            this.xrLabel68.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // r_member_record_by_mem_nest_record_return
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("BrowalliaUPC", 12F);
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel78;
        private DevExpress.XtraReports.UI.XRLabel xrLabel77;
        private DevExpress.XtraReports.UI.XRLabel xrLabel76;
        private DevExpress.XtraReports.UI.XRLabel xrLabel75;
        private DevExpress.XtraReports.UI.XRLabel xrLabel74;
        private DevExpress.XtraReports.UI.XRLabel xrLabel73;
        private DevExpress.XtraReports.UI.XRLabel xrLabel72;
        private DevExpress.XtraReports.UI.XRLabel xrLabel71;
        private DevExpress.XtraReports.UI.XRLabel xrLabel70;
        private DevExpress.XtraReports.UI.XRLabel xrLabel69;
        private DevExpress.XtraReports.UI.XRLabel xrLabel68;
    }
}
