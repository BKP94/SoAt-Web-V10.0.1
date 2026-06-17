namespace scReport.Reports.rcTeller.memDetail
{
    partial class r_amnat_form_paymentvoucher_nest_two
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
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_amnat_form_paymentvoucher_nest_two));
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel142 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel76 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.xrLabel137 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel138 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel139 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel140 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel144 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel145 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.c_vourcher_name = new DevExpress.XtraReports.UI.CalculatedField();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel142,
            this.xrLabel76,
            this.xrLabel1});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 28.55659F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.AutoWidth = true;
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.CanGrow = false;
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MEMBER_NAME")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("BrowalliaUPC", 16F);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(35.12587F, 0.0001764622F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(350.9118F, 28.55548F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel142
            // 
            this.xrLabel142.AutoWidth = true;
            this.xrLabel142.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel142.CanGrow = false;
            this.xrLabel142.Dpi = 100F;
            this.xrLabel142.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.xrLabel142.LocationFloat = new DevExpress.Utils.PointFloat(507.071F, 0.0009342117F);
            this.xrLabel142.Name = "xrLabel142";
            this.xrLabel142.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel142.SizeF = new System.Drawing.SizeF(139.9729F, 28.55565F);
            this.xrLabel142.StylePriority.UseBorders = false;
            this.xrLabel142.StylePriority.UseFont = false;
            this.xrLabel142.StylePriority.UseTextAlignment = false;
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            xrSummary1.IgnoreNullValues = true;
            this.xrLabel142.Summary = xrSummary1;
            this.xrLabel142.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel76
            // 
            this.xrLabel76.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel76.CanGrow = false;
            this.xrLabel76.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ITEM_AMOUNT", "{0:#,#}")});
            this.xrLabel76.Dpi = 100F;
            this.xrLabel76.Font = new System.Drawing.Font("BrowalliaUPC", 16F);
            this.xrLabel76.LocationFloat = new DevExpress.Utils.PointFloat(386.0377F, 0.0009342117F);
            this.xrLabel76.Name = "xrLabel76";
            this.xrLabel76.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel76.SizeF = new System.Drawing.SizeF(121.0334F, 28.55504F);
            this.xrLabel76.StylePriority.UseBorders = false;
            this.xrLabel76.StylePriority.UseFont = false;
            this.xrLabel76.StylePriority.UseTextAlignment = false;
            this.xrLabel76.Text = "xrLabel76";
            this.xrLabel76.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("BrowalliaUPC", 16F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0.0009342117F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(35.12587F, 28.55504F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            xrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            xrSummary2.IgnoreNullValues = true;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel1.Summary = xrSummary2;
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
            // xrLabel137
            // 
            this.xrLabel137.AutoWidth = true;
            this.xrLabel137.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel137.CanGrow = false;
            this.xrLabel137.Dpi = 100F;
            this.xrLabel137.Font = new System.Drawing.Font("BrowalliaUPC", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel137.LocationFloat = new DevExpress.Utils.PointFloat(35.12587F, 0F);
            this.xrLabel137.Name = "xrLabel137";
            this.xrLabel137.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel137.SizeF = new System.Drawing.SizeF(350.9118F, 28.5556F);
            this.xrLabel137.StylePriority.UseBorders = false;
            this.xrLabel137.StylePriority.UseFont = false;
            this.xrLabel137.StylePriority.UseTextAlignment = false;
            this.xrLabel137.Text = "รายการ";
            this.xrLabel137.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel138
            // 
            this.xrLabel138.AutoWidth = true;
            this.xrLabel138.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel138.CanGrow = false;
            this.xrLabel138.Dpi = 100F;
            this.xrLabel138.Font = new System.Drawing.Font("BrowalliaUPC", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel138.LocationFloat = new DevExpress.Utils.PointFloat(386.0377F, 0F);
            this.xrLabel138.Name = "xrLabel138";
            this.xrLabel138.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel138.SizeF = new System.Drawing.SizeF(121.0334F, 28.55557F);
            this.xrLabel138.StylePriority.UseBorders = false;
            this.xrLabel138.StylePriority.UseFont = false;
            this.xrLabel138.StylePriority.UseTextAlignment = false;
            this.xrLabel138.Text = "จำนวนเงิน";
            this.xrLabel138.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel139
            // 
            this.xrLabel139.AutoWidth = true;
            this.xrLabel139.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel139.CanGrow = false;
            this.xrLabel139.Dpi = 100F;
            this.xrLabel139.Font = new System.Drawing.Font("BrowalliaUPC", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel139.LocationFloat = new DevExpress.Utils.PointFloat(507.0711F, 0.0004878661F);
            this.xrLabel139.Name = "xrLabel139";
            this.xrLabel139.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel139.SizeF = new System.Drawing.SizeF(139.9728F, 28.55505F);
            this.xrLabel139.StylePriority.UseBorders = false;
            this.xrLabel139.StylePriority.UseFont = false;
            this.xrLabel139.StylePriority.UseTextAlignment = false;
            this.xrLabel139.Text = "หมายเหตุ/ลายมือชื่อ";
            this.xrLabel139.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel140
            // 
            this.xrLabel140.AutoWidth = true;
            this.xrLabel140.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
            | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel140.CanGrow = false;
            this.xrLabel140.Dpi = 100F;
            this.xrLabel140.Font = new System.Drawing.Font("BrowalliaUPC", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel140.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel140.Name = "xrLabel140";
            this.xrLabel140.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel140.SizeF = new System.Drawing.SizeF(35.12588F, 28.55554F);
            this.xrLabel140.StylePriority.UseBorders = false;
            this.xrLabel140.StylePriority.UseFont = false;
            this.xrLabel140.StylePriority.UseTextAlignment = false;
            xrSummary3.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            xrSummary3.IgnoreNullValues = true;
            this.xrLabel140.Summary = xrSummary3;
            this.xrLabel140.Text = "ที่";
            this.xrLabel140.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel144
            // 
            this.xrLabel144.AutoWidth = true;
            this.xrLabel144.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel144.CanGrow = false;
            this.xrLabel144.Dpi = 100F;
            this.xrLabel144.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.xrLabel144.LocationFloat = new DevExpress.Utils.PointFloat(507.071F, 9.342116E-05F);
            this.xrLabel144.Name = "xrLabel144";
            this.xrLabel144.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel144.SizeF = new System.Drawing.SizeF(139.973F, 28.55554F);
            this.xrLabel144.StylePriority.UseBorders = false;
            this.xrLabel144.StylePriority.UseFont = false;
            this.xrLabel144.StylePriority.UseTextAlignment = false;
            xrSummary4.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            xrSummary4.IgnoreNullValues = true;
            this.xrLabel144.Summary = xrSummary4;
            this.xrLabel144.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel145
            // 
            this.xrLabel145.AutoWidth = true;
            this.xrLabel145.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel145.CanGrow = false;
            this.xrLabel145.Dpi = 100F;
            this.xrLabel145.Font = new System.Drawing.Font("BrowalliaUPC", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel145.LocationFloat = new DevExpress.Utils.PointFloat(0F, 6.228078E-05F);
            this.xrLabel145.Name = "xrLabel145";
            this.xrLabel145.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel145.SizeF = new System.Drawing.SizeF(386.0377F, 28.55548F);
            this.xrLabel145.StylePriority.UseBorders = false;
            this.xrLabel145.StylePriority.UseFont = false;
            this.xrLabel145.StylePriority.UseTextAlignment = false;
            xrSummary5.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            xrSummary5.IgnoreNullValues = true;
            this.xrLabel145.Summary = xrSummary5;
            this.xrLabel145.Text = "รวม";
            this.xrLabel145.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrLabel145,
            this.xrLabel144});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 28.55563F;
            this.ReportFooter.KeepTogether = true;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel3.CanGrow = false;
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ITEM_AMOUNT")});
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("BrowalliaUPC", 16F);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(386.0377F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(121.0333F, 28.55563F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            xrSummary6.FormatString = "{0:n2}";
            xrSummary6.IgnoreNullValues = true;
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel3.Summary = xrSummary6;
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // c_vourcher_name
            // 
            this.c_vourcher_name.DataMember = "Query";
            this.c_vourcher_name.DisplayName = "c_vourcher_name";
            this.c_vourcher_name.Expression = "\'  \' + [VOURCHER_NAME]";
            this.c_vourcher_name.Name = "c_vourcher_name";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel139,
            this.xrLabel138,
            this.xrLabel137,
            this.xrLabel140});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 28.5556F;
            this.ReportHeader.KeepTogether = true;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // r_amnat_form_paymentvoucher_nest
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter,
            this.ReportHeader});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.c_vourcher_name});
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
        private DevExpress.XtraReports.UI.XRLabel xrLabel76;
        private DevExpress.XtraReports.UI.XRLabel xrLabel137;
        private DevExpress.XtraReports.UI.XRLabel xrLabel138;
        private DevExpress.XtraReports.UI.XRLabel xrLabel139;
        private DevExpress.XtraReports.UI.XRLabel xrLabel140;
        private DevExpress.XtraReports.UI.XRLabel xrLabel142;
        private DevExpress.XtraReports.UI.XRLabel xrLabel144;
        private DevExpress.XtraReports.UI.XRLabel xrLabel145;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.CalculatedField c_vourcher_name;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
    }
}
