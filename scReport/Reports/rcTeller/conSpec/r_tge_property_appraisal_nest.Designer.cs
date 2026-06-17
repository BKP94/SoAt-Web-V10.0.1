namespace scReport.Reports.rcTeller.conSpec
{
    partial class r_tge_property_appraisal_nest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_tge_property_appraisal_nest));
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel87 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel88 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel89 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel90 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel91 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel92 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel93 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel228 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel229 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel230 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel261 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel262 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel272 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel87,
            this.xrLabel88,
            this.xrLabel89,
            this.xrLabel90,
            this.xrLabel91,
            this.xrLabel92,
            this.xrLabel93,
            this.xrLabel228,
            this.xrLabel229,
            this.xrLabel230,
            this.xrLabel261,
            this.xrLabel262,
            this.xrLabel272});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 60F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel87
            // 
            this.xrLabel87.Dpi = 100F;
            this.xrLabel87.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel87.LocationFloat = new DevExpress.Utils.PointFloat(0F, 30F);
            this.xrLabel87.Name = "xrLabel87";
            this.xrLabel87.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel87.SizeF = new System.Drawing.SizeF(152.6314F, 30F);
            this.xrLabel87.StylePriority.UseFont = false;
            this.xrLabel87.StylePriority.UseTextAlignment = false;
            this.xrLabel87.Text = "เป็นเงิน";
            this.xrLabel87.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel87.WordWrap = false;
            // 
            // xrLabel88
            // 
            this.xrLabel88.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.SEQ_NO")});
            this.xrLabel88.Dpi = 100F;
            this.xrLabel88.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel88.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel88.Name = "xrLabel88";
            this.xrLabel88.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel88.SizeF = new System.Drawing.SizeF(152.6314F, 30F);
            this.xrLabel88.StylePriority.UseFont = false;
            this.xrLabel88.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "เนื้อที่ใช้สอย หลังที่ {0:#,#}";
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            xrSummary1.IgnoreNullValues = true;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel88.Summary = xrSummary1;
            this.xrLabel88.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel88.WordWrap = false;
            // 
            // xrLabel89
            // 
            this.xrLabel89.Dpi = 100F;
            this.xrLabel89.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel89.LocationFloat = new DevExpress.Utils.PointFloat(398.024F, 30F);
            this.xrLabel89.Name = "xrLabel89";
            this.xrLabel89.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel89.SizeF = new System.Drawing.SizeF(32.43054F, 30F);
            this.xrLabel89.StylePriority.UseFont = false;
            this.xrLabel89.StylePriority.UseTextAlignment = false;
            this.xrLabel89.Text = "บาท";
            this.xrLabel89.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel89.WordWrap = false;
            // 
            // xrLabel90
            // 
            this.xrLabel90.Dpi = 100F;
            this.xrLabel90.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel90.LocationFloat = new DevExpress.Utils.PointFloat(398.0241F, 0F);
            this.xrLabel90.Name = "xrLabel90";
            this.xrLabel90.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel90.SizeF = new System.Drawing.SizeF(79.035F, 30F);
            this.xrLabel90.StylePriority.UseFont = false;
            this.xrLabel90.StylePriority.UseTextAlignment = false;
            this.xrLabel90.Text = "ตารางเมตร";
            this.xrLabel90.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel90.WordWrap = false;
            // 
            // xrLabel91
            // 
            this.xrLabel91.Dpi = 100F;
            this.xrLabel91.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel91.LocationFloat = new DevExpress.Utils.PointFloat(519.3055F, 0F);
            this.xrLabel91.Name = "xrLabel91";
            this.xrLabel91.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel91.SizeF = new System.Drawing.SizeF(118.8257F, 30F);
            this.xrLabel91.StylePriority.UseFont = false;
            this.xrLabel91.StylePriority.UseTextAlignment = false;
            this.xrLabel91.Text = "คิดตารางเมตรละ";
            this.xrLabel91.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel91.WordWrap = false;
            // 
            // xrLabel92
            // 
            this.xrLabel92.Dpi = 100F;
            this.xrLabel92.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel92.LocationFloat = new DevExpress.Utils.PointFloat(757.4564F, 0F);
            this.xrLabel92.Name = "xrLabel92";
            this.xrLabel92.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel92.SizeF = new System.Drawing.SizeF(32.43054F, 30F);
            this.xrLabel92.StylePriority.UseFont = false;
            this.xrLabel92.StylePriority.UseTextAlignment = false;
            this.xrLabel92.Text = "บาท";
            this.xrLabel92.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel92.WordWrap = false;
            // 
            // xrLabel93
            // 
            this.xrLabel93.Dpi = 100F;
            this.xrLabel93.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel93.LocationFloat = new DevExpress.Utils.PointFloat(757.4564F, 30F);
            this.xrLabel93.Name = "xrLabel93";
            this.xrLabel93.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel93.SizeF = new System.Drawing.SizeF(32.43054F, 30F);
            this.xrLabel93.StylePriority.UseFont = false;
            this.xrLabel93.StylePriority.UseTextAlignment = false;
            this.xrLabel93.Text = "บาท";
            this.xrLabel93.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel93.WordWrap = false;
            // 
            // xrLabel228
            // 
            this.xrLabel228.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.HOUSE_SQUARE", "{0:n2}")});
            this.xrLabel228.Dpi = 100F;
            this.xrLabel228.Font = new System.Drawing.Font("AngsanaUPC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel228.LocationFloat = new DevExpress.Utils.PointFloat(152.6314F, 0F);
            this.xrLabel228.Name = "xrLabel228";
            this.xrLabel228.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel228.SizeF = new System.Drawing.SizeF(242.3926F, 30F);
            this.xrLabel228.StylePriority.UseFont = false;
            this.xrLabel228.StylePriority.UseTextAlignment = false;
            this.xrLabel228.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel228.WordWrap = false;
            // 
            // xrLabel229
            // 
            this.xrLabel229.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.HOUSE_COOP_AMOUNT", "{0:n2}")});
            this.xrLabel229.Dpi = 100F;
            this.xrLabel229.Font = new System.Drawing.Font("AngsanaUPC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel229.LocationFloat = new DevExpress.Utils.PointFloat(152.6314F, 30F);
            this.xrLabel229.Name = "xrLabel229";
            this.xrLabel229.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel229.SizeF = new System.Drawing.SizeF(242.3926F, 30F);
            this.xrLabel229.StylePriority.UseFont = false;
            this.xrLabel229.StylePriority.UseTextAlignment = false;
            this.xrLabel229.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel229.WordWrap = false;
            // 
            // xrLabel230
            // 
            this.xrLabel230.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.HOUSE_COOP", "{0:n2}")});
            this.xrLabel230.Dpi = 100F;
            this.xrLabel230.Font = new System.Drawing.Font("AngsanaUPC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel230.LocationFloat = new DevExpress.Utils.PointFloat(638.1312F, 0F);
            this.xrLabel230.Name = "xrLabel230";
            this.xrLabel230.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel230.SizeF = new System.Drawing.SizeF(119.3251F, 30F);
            this.xrLabel230.StylePriority.UseFont = false;
            this.xrLabel230.StylePriority.UseTextAlignment = false;
            this.xrLabel230.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel230.WordWrap = false;
            // 
            // xrLabel261
            // 
            this.xrLabel261.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.HOUSE_RATE", "{0}% ")});
            this.xrLabel261.Dpi = 100F;
            this.xrLabel261.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel261.LocationFloat = new DevExpress.Utils.PointFloat(518.3504F, 30F);
            this.xrLabel261.Name = "xrLabel261";
            this.xrLabel261.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel261.SizeF = new System.Drawing.SizeF(56.23273F, 30F);
            this.xrLabel261.StylePriority.UseFont = false;
            this.xrLabel261.StylePriority.UseTextAlignment = false;
            this.xrLabel261.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel261.WordWrap = false;
            // 
            // xrLabel262
            // 
            this.xrLabel262.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.HOUSE_COOP_RATE_AMOUNT", "{0:n2}")});
            this.xrLabel262.Dpi = 100F;
            this.xrLabel262.Font = new System.Drawing.Font("AngsanaUPC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel262.LocationFloat = new DevExpress.Utils.PointFloat(588.2373F, 30F);
            this.xrLabel262.Name = "xrLabel262";
            this.xrLabel262.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel262.SizeF = new System.Drawing.SizeF(169.2188F, 30F);
            this.xrLabel262.StylePriority.UseFont = false;
            this.xrLabel262.StylePriority.UseTextAlignment = false;
            this.xrLabel262.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel262.WordWrap = false;
            // 
            // xrLabel272
            // 
            this.xrLabel272.Dpi = 100F;
            this.xrLabel272.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel272.LocationFloat = new DevExpress.Utils.PointFloat(574.5833F, 30F);
            this.xrLabel272.Name = "xrLabel272";
            this.xrLabel272.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel272.SizeF = new System.Drawing.SizeF(13.65417F, 30F);
            this.xrLabel272.StylePriority.UseFont = false;
            this.xrLabel272.StylePriority.UseTextAlignment = false;
            this.xrLabel272.Text = "=";
            this.xrLabel272.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel272.WordWrap = false;
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
            this.GroupHeader1.Expanded = false;
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("DOC_NO", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 100F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrLabel1,
            this.xrLabel2});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 30F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.HOUSE_COOP_RATE_AMOUNT")});
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("AngsanaUPC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(588.2374F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(169.2188F, 30F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:n2}";
            xrSummary2.IgnoreNullValues = true;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel1.Summary = xrSummary2;
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel1.WordWrap = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(757.4565F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(32.43054F, 30F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "บาท";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel2.WordWrap = false;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(519.3055F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(68.93201F, 30F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "รวมเงิน";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel3.WordWrap = false;
            // 
            // r_tge_property_appraisal_nest
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupFooter1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
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
        private DevExpress.XtraReports.UI.XRLabel xrLabel87;
        private DevExpress.XtraReports.UI.XRLabel xrLabel88;
        private DevExpress.XtraReports.UI.XRLabel xrLabel89;
        private DevExpress.XtraReports.UI.XRLabel xrLabel90;
        private DevExpress.XtraReports.UI.XRLabel xrLabel91;
        private DevExpress.XtraReports.UI.XRLabel xrLabel92;
        private DevExpress.XtraReports.UI.XRLabel xrLabel93;
        private DevExpress.XtraReports.UI.XRLabel xrLabel228;
        private DevExpress.XtraReports.UI.XRLabel xrLabel229;
        private DevExpress.XtraReports.UI.XRLabel xrLabel230;
        private DevExpress.XtraReports.UI.XRLabel xrLabel261;
        private DevExpress.XtraReports.UI.XRLabel xrLabel262;
        private DevExpress.XtraReports.UI.XRLabel xrLabel272;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
    }
}
