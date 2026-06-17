namespace scReport.Reports.rcTeller.memStockdue
{
    partial class r_ktm_member_record_nest_share
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_ktm_member_record_nest_share));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel98 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel97 = new DevExpress.XtraReports.UI.XRLabel();
            this.f_share_int = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrLabel96 = new DevExpress.XtraReports.UI.XRLabel();
            this.f_share_decr = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrLabel60 = new DevExpress.XtraReports.UI.XRLabel();
            this.f_period = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrLabel54 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel53 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel98,
            this.xrLabel97,
            this.xrLabel96,
            this.xrLabel60,
            this.xrLabel54,
            this.xrLabel53,
            this.xrLabel52});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel98
            // 
            this.xrLabel98.CanGrow = false;
            this.xrLabel98.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.SHARE_STOCK", "{0:n2}")});
            this.xrLabel98.Dpi = 100F;
            this.xrLabel98.LocationFloat = new DevExpress.Utils.PointFloat(412.5F, 0F);
            this.xrLabel98.Name = "xrLabel98";
            this.xrLabel98.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel98.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel98.StylePriority.UseTextAlignment = false;
            this.xrLabel98.Text = "xrLabel7";
            this.xrLabel98.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel97
            // 
            this.xrLabel97.CanGrow = false;
            this.xrLabel97.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.SHARE_INCR", "{0:n2}")});
            this.xrLabel97.Dpi = 100F;
            this.xrLabel97.FormattingRules.Add(this.f_share_int);
            this.xrLabel97.LocationFloat = new DevExpress.Utils.PointFloat(337.5F, 0F);
            this.xrLabel97.Name = "xrLabel97";
            this.xrLabel97.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel97.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel97.StylePriority.UseTextAlignment = false;
            this.xrLabel97.Text = "xrLabel6";
            this.xrLabel97.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // f_share_int
            // 
            this.f_share_int.Condition = "Iif( [SHARE_VALUE] > 0 and [SIGN_FLAG] = 1 , true , false )";
            this.f_share_int.Name = "f_share_int";
            // 
            // xrLabel96
            // 
            this.xrLabel96.CanGrow = false;
            this.xrLabel96.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.SHARE_DECR", "{0:n2}")});
            this.xrLabel96.Dpi = 100F;
            this.xrLabel96.FormattingRules.Add(this.f_share_decr);
            this.xrLabel96.LocationFloat = new DevExpress.Utils.PointFloat(250F, 0F);
            this.xrLabel96.Name = "xrLabel96";
            this.xrLabel96.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel96.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel96.StylePriority.UseTextAlignment = false;
            this.xrLabel96.Text = "xrLabel5";
            this.xrLabel96.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // f_share_decr
            // 
            this.f_share_decr.Condition = "Iif( [SHARE_VALUE] > 0 and [SIGN_FLAG] = -1 , true , false )";
            this.f_share_decr.Name = "f_share_decr";
            // 
            // xrLabel60
            // 
            this.xrLabel60.CanGrow = false;
            this.xrLabel60.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PERIOD")});
            this.xrLabel60.Dpi = 100F;
            this.xrLabel60.FormattingRules.Add(this.f_period);
            this.xrLabel60.LocationFloat = new DevExpress.Utils.PointFloat(225F, 0F);
            this.xrLabel60.Name = "xrLabel60";
            this.xrLabel60.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel60.SizeF = new System.Drawing.SizeF(25F, 25F);
            this.xrLabel60.StylePriority.UseTextAlignment = false;
            this.xrLabel60.Text = "xrLabel4";
            this.xrLabel60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // f_period
            // 
            this.f_period.Condition = "Iif( [DOC_NO] [0] = [DOC_NO] [-1] , true , false )";
            this.f_period.Name = "f_period";
            // 
            // xrLabel54
            // 
            this.xrLabel54.CanGrow = false;
            this.xrLabel54.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.DOC_NO")});
            this.xrLabel54.Dpi = 100F;
            this.xrLabel54.ForeColor = System.Drawing.Color.Black;
            this.xrLabel54.LocationFloat = new DevExpress.Utils.PointFloat(125F, 0F);
            this.xrLabel54.Name = "xrLabel54";
            this.xrLabel54.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel54.ProcessDuplicatesMode = DevExpress.XtraReports.UI.ProcessDuplicatesMode.Merge;
            this.xrLabel54.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel54.StylePriority.UseForeColor = false;
            this.xrLabel54.Text = "xrLabel3";
            // 
            // xrLabel53
            // 
            this.xrLabel53.CanGrow = false;
            this.xrLabel53.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ITEM_TYPE")});
            this.xrLabel53.Dpi = 100F;
            this.xrLabel53.LocationFloat = new DevExpress.Utils.PointFloat(75F, 0F);
            this.xrLabel53.Name = "xrLabel53";
            this.xrLabel53.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel53.SizeF = new System.Drawing.SizeF(50F, 25F);
            this.xrLabel53.Text = "xrLabel2";
            // 
            // xrLabel52
            // 
            this.xrLabel52.CanGrow = false;
            this.xrLabel52.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.OPERATE_DATE", "{0:dd/MM/yyyy}")});
            this.xrLabel52.Dpi = 100F;
            this.xrLabel52.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel52.Name = "xrLabel52";
            this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel52.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel52.Text = "xrLabel1";
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
            // r_ktm_member_record_nest_share
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
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.f_share_decr,
            this.f_share_int,
            this.f_period});
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
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
        private DevExpress.XtraReports.UI.XRLabel xrLabel98;
        private DevExpress.XtraReports.UI.XRLabel xrLabel97;
        private DevExpress.XtraReports.UI.XRLabel xrLabel96;
        private DevExpress.XtraReports.UI.XRLabel xrLabel60;
        private DevExpress.XtraReports.UI.XRLabel xrLabel54;
        private DevExpress.XtraReports.UI.XRLabel xrLabel53;
        private DevExpress.XtraReports.UI.XRLabel xrLabel52;
        private DevExpress.XtraReports.UI.FormattingRule f_share_decr;
        private DevExpress.XtraReports.UI.FormattingRule f_share_int;
        private DevExpress.XtraReports.UI.FormattingRule f_period;
    }
}
