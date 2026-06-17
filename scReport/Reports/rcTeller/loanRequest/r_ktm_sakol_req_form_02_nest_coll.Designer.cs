namespace scReport.Reports.rcTeller.loanRequest
{
    partial class r_ktm_sakol_req_form_02_nest_coll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_ktm_sakol_req_form_02_nest_coll));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.c_text_salary = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_text_share_stock = new DevExpress.XtraReports.UI.CalculatedField();
            this.xrLabel83 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel84 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel90 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel89 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel82 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel88 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel87 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel86 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel83,
            this.xrLabel84,
            this.xrLabel90,
            this.xrLabel89,
            this.xrLabel82,
            this.xrLabel88,
            this.xrLabel87,
            this.xrLabel86});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 37.50006F;
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
            // c_text_salary
            // 
            this.c_text_salary.DataMember = "Query";
            this.c_text_salary.Expression = "Iif( [REF_OWN_NO] = \'null\', \'\' , \'ง/ด\' )";
            this.c_text_salary.Name = "c_text_salary";
            // 
            // c_text_share_stock
            // 
            this.c_text_share_stock.DataMember = "Query";
            this.c_text_share_stock.Expression = "Iif( [REF_OWN_NO] = \'null\', \'\' , \'หุ้น\' )";
            this.c_text_share_stock.Name = "c_text_share_stock";
            // 
            // xrLabel83
            // 
            this.xrLabel83.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel83.CanGrow = false;
            this.xrLabel83.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.SHARE_STOCK", "{0:n2}")});
            this.xrLabel83.Dpi = 100F;
            this.xrLabel83.LocationFloat = new DevExpress.Utils.PointFloat(548.0041F, 0F);
            this.xrLabel83.Name = "xrLabel83";
            this.xrLabel83.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel83.SizeF = new System.Drawing.SizeF(106.8334F, 37.5F);
            this.xrLabel83.StylePriority.UseBorders = false;
            this.xrLabel83.StylePriority.UseTextAlignment = false;
            this.xrLabel83.Text = "xrLabel2";
            this.xrLabel83.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel84
            // 
            this.xrLabel84.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel84.CanGrow = false;
            this.xrLabel84.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_text_share_stock")});
            this.xrLabel84.Dpi = 100F;
            this.xrLabel84.LocationFloat = new DevExpress.Utils.PointFloat(523.0041F, 6.357829E-05F);
            this.xrLabel84.Name = "xrLabel84";
            this.xrLabel84.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel84.SizeF = new System.Drawing.SizeF(25F, 37.5F);
            this.xrLabel84.StylePriority.UseBorders = false;
            this.xrLabel84.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:#,#}.";
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            this.xrLabel84.Summary = xrSummary1;
            this.xrLabel84.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel90
            // 
            this.xrLabel90.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel90.CanGrow = false;
            this.xrLabel90.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.SALARY", "{0:n2}")});
            this.xrLabel90.Dpi = 100F;
            this.xrLabel90.LocationFloat = new DevExpress.Utils.PointFloat(420.3373F, 6.357829E-05F);
            this.xrLabel90.Name = "xrLabel90";
            this.xrLabel90.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel90.SizeF = new System.Drawing.SizeF(102.6667F, 37.5F);
            this.xrLabel90.StylePriority.UseBorders = false;
            this.xrLabel90.StylePriority.UseTextAlignment = false;
            this.xrLabel90.Text = "xrLabel2";
            this.xrLabel90.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel89
            // 
            this.xrLabel89.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel89.CanGrow = false;
            this.xrLabel89.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_text")});
            this.xrLabel89.Dpi = 100F;
            this.xrLabel89.LocationFloat = new DevExpress.Utils.PointFloat(395.3373F, 6.357829E-05F);
            this.xrLabel89.Name = "xrLabel89";
            this.xrLabel89.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel89.SizeF = new System.Drawing.SizeF(25F, 37.5F);
            this.xrLabel89.StylePriority.UseBorders = false;
            this.xrLabel89.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:#,#}.";
            xrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            this.xrLabel89.Summary = xrSummary2;
            this.xrLabel89.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel82
            // 
            this.xrLabel82.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel82.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MEMBER_GROUP_NAME")});
            this.xrLabel82.Dpi = 100F;
            this.xrLabel82.LocationFloat = new DevExpress.Utils.PointFloat(229.8701F, 6.357829E-05F);
            this.xrLabel82.Name = "xrLabel82";
            this.xrLabel82.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel82.SizeF = new System.Drawing.SizeF(165.4673F, 37.5F);
            this.xrLabel82.StylePriority.UseBorders = false;
            this.xrLabel82.StylePriority.UseTextAlignment = false;
            this.xrLabel82.Text = "xrLabel2";
            this.xrLabel82.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel88
            // 
            this.xrLabel88.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel88.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MEMBERNAME")});
            this.xrLabel88.Dpi = 100F;
            this.xrLabel88.LocationFloat = new DevExpress.Utils.PointFloat(85F, 6.357829E-05F);
            this.xrLabel88.Name = "xrLabel88";
            this.xrLabel88.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel88.SizeF = new System.Drawing.SizeF(144.8701F, 37.5F);
            this.xrLabel88.StylePriority.UseBorders = false;
            this.xrLabel88.StylePriority.UseTextAlignment = false;
            this.xrLabel88.Text = "xrLabel2";
            this.xrLabel88.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel87
            // 
            this.xrLabel87.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel87.CanGrow = false;
            this.xrLabel87.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.REF_OWN_NO")});
            this.xrLabel87.Dpi = 100F;
            this.xrLabel87.LocationFloat = new DevExpress.Utils.PointFloat(25F, 6.357829E-05F);
            this.xrLabel87.Name = "xrLabel87";
            this.xrLabel87.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel87.SizeF = new System.Drawing.SizeF(60F, 37.5F);
            this.xrLabel87.StylePriority.UseBorders = false;
            this.xrLabel87.StylePriority.UseTextAlignment = false;
            this.xrLabel87.Text = "xrLabel2";
            this.xrLabel87.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel86
            // 
            this.xrLabel86.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel86.CanGrow = false;
            this.xrLabel86.Dpi = 100F;
            this.xrLabel86.LocationFloat = new DevExpress.Utils.PointFloat(0F, 6.357829E-05F);
            this.xrLabel86.Name = "xrLabel86";
            this.xrLabel86.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel86.SizeF = new System.Drawing.SizeF(25F, 37.5F);
            this.xrLabel86.StylePriority.UseBorders = false;
            this.xrLabel86.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:#,#}.";
            xrSummary3.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            xrSummary3.IgnoreNullValues = true;
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel86.Summary = xrSummary3;
            this.xrLabel86.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // r_ktm_sakol_req_form_02_nest_coll
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.c_text_salary,
            this.c_text_share_stock});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("AngsanaUPC", 13F);
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
        private DevExpress.XtraReports.UI.CalculatedField c_text_salary;
        private DevExpress.XtraReports.UI.CalculatedField c_text_share_stock;
        private DevExpress.XtraReports.UI.XRLabel xrLabel83;
        private DevExpress.XtraReports.UI.XRLabel xrLabel84;
        private DevExpress.XtraReports.UI.XRLabel xrLabel90;
        private DevExpress.XtraReports.UI.XRLabel xrLabel89;
        private DevExpress.XtraReports.UI.XRLabel xrLabel82;
        private DevExpress.XtraReports.UI.XRLabel xrLabel88;
        private DevExpress.XtraReports.UI.XRLabel xrLabel87;
        private DevExpress.XtraReports.UI.XRLabel xrLabel86;
    }
}
