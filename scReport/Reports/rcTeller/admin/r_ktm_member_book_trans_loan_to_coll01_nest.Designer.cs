namespace scReport.Reports.rcTeller.admin
{
    partial class r_ktm_member_book_trans_loan_to_coll01_nest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_ktm_member_book_trans_loan_to_coll01_nest));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel63 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel62 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel60 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel61 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel63,
            this.xrLabel62,
            this.xrLabel60,
            this.xrLabel61});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 32.18504F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel63
            // 
            this.xrLabel63.BorderColor = System.Drawing.Color.Aqua;
            this.xrLabel63.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLabel63.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel63.CanGrow = false;
            this.xrLabel63.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.BEGINING_OF_CONTRACT", "{0:d MMMM yyyy}")});
            this.xrLabel63.Dpi = 100F;
            this.xrLabel63.LocationFloat = new DevExpress.Utils.PointFloat(421.011F, 0F);
            this.xrLabel63.Name = "xrLabel63";
            this.xrLabel63.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel63.SizeF = new System.Drawing.SizeF(240.8274F, 32.18504F);
            this.xrLabel63.StylePriority.UseBorderColor = false;
            this.xrLabel63.StylePriority.UseBorderDashStyle = false;
            this.xrLabel63.StylePriority.UseBorders = false;
            this.xrLabel63.StylePriority.UseTextAlignment = false;
            this.xrLabel63.Text = "xrLabel1";
            this.xrLabel63.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel62
            // 
            this.xrLabel62.CanGrow = false;
            this.xrLabel62.Dpi = 100F;
            this.xrLabel62.LocationFloat = new DevExpress.Utils.PointFloat(364.2525F, 0F);
            this.xrLabel62.Name = "xrLabel62";
            this.xrLabel62.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel62.SizeF = new System.Drawing.SizeF(56.75845F, 32.18504F);
            this.xrLabel62.StylePriority.UseTextAlignment = false;
            this.xrLabel62.Text = "ลงวันที่";
            this.xrLabel62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel60
            // 
            this.xrLabel60.BorderColor = System.Drawing.Color.Aqua;
            this.xrLabel60.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLabel60.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel60.CanGrow = false;
            this.xrLabel60.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.COLLATERAL_NAME")});
            this.xrLabel60.Dpi = 100F;
            this.xrLabel60.LocationFloat = new DevExpress.Utils.PointFloat(160.9251F, 0F);
            this.xrLabel60.Name = "xrLabel60";
            this.xrLabel60.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel60.SizeF = new System.Drawing.SizeF(203.3272F, 32.18504F);
            this.xrLabel60.StylePriority.UseBorderColor = false;
            this.xrLabel60.StylePriority.UseBorderDashStyle = false;
            this.xrLabel60.StylePriority.UseBorders = false;
            this.xrLabel60.StylePriority.UseTextAlignment = false;
            this.xrLabel60.Text = "xrLabel1";
            this.xrLabel60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel61
            // 
            this.xrLabel61.CanGrow = false;
            this.xrLabel61.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ROW_MEMNO", "{0:#,#}.  หนังสือค้ำประกันของ")});
            this.xrLabel61.Dpi = 100F;
            this.xrLabel61.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel61.Name = "xrLabel61";
            this.xrLabel61.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel61.SizeF = new System.Drawing.SizeF(160.9251F, 32.18504F);
            this.xrLabel61.StylePriority.UseTextAlignment = false;
            this.xrLabel61.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            // r_ktm_member_book_trans_loan_to_coll01_nest
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("BrowalliaUPC", 16F);
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
        private DevExpress.XtraReports.UI.XRLabel xrLabel63;
        private DevExpress.XtraReports.UI.XRLabel xrLabel62;
        private DevExpress.XtraReports.UI.XRLabel xrLabel60;
        private DevExpress.XtraReports.UI.XRLabel xrLabel61;
    }
}
