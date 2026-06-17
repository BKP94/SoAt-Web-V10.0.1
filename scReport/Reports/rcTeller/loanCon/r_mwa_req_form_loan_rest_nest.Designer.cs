namespace scReport.Reports.rcTeller.loanCon
{
    partial class r_mwa_req_form_loan_rest_nest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_mwa_req_form_loan_rest_nest));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailCaption3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData3_Odd = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailCaptionBackground3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.xrLabel154 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel155 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel157 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel156 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel158 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel161 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel160 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel159 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel162 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel163 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel164 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel154,
            this.xrLabel155,
            this.xrLabel157,
            this.xrLabel156,
            this.xrLabel158,
            this.xrLabel161,
            this.xrLabel160,
            this.xrLabel159,
            this.xrLabel162,
            this.xrLabel163,
            this.xrLabel164});
            this.Detail.HeightF = 25.00001F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
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
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Tahoma", 14F);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.Title.Name = "Title";
            // 
            // DetailCaption3
            // 
            this.DetailCaption3.BackColor = System.Drawing.Color.Transparent;
            this.DetailCaption3.BorderColor = System.Drawing.Color.Transparent;
            this.DetailCaption3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DetailCaption3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.DetailCaption3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.DetailCaption3.Name = "DetailCaption3";
            this.DetailCaption3.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailCaption3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData3
            // 
            this.DetailData3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.DetailData3.ForeColor = System.Drawing.Color.Black;
            this.DetailData3.Name = "DetailData3";
            this.DetailData3.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData3_Odd
            // 
            this.DetailData3_Odd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.DetailData3_Odd.BorderColor = System.Drawing.Color.Transparent;
            this.DetailData3_Odd.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DetailData3_Odd.BorderWidth = 1F;
            this.DetailData3_Odd.Font = new System.Drawing.Font("Tahoma", 8F);
            this.DetailData3_Odd.ForeColor = System.Drawing.Color.Black;
            this.DetailData3_Odd.Name = "DetailData3_Odd";
            this.DetailData3_Odd.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData3_Odd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailCaptionBackground3
            // 
            this.DetailCaptionBackground3.BackColor = System.Drawing.Color.Transparent;
            this.DetailCaptionBackground3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.DetailCaptionBackground3.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.DetailCaptionBackground3.BorderWidth = 2F;
            this.DetailCaptionBackground3.Name = "DetailCaptionBackground3";
            // 
            // PageInfo
            // 
            this.PageInfo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.PageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.PageInfo.Name = "PageInfo";
            this.PageInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // xrLabel154
            // 
            this.xrLabel154.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel154.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel154.Name = "xrLabel154";
            this.xrLabel154.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel154.SizeF = new System.Drawing.SizeF(61.36706F, 25F);
            this.xrLabel154.StylePriority.UseFont = false;
            this.xrLabel154.StylePriority.UseTextAlignment = false;
            this.xrLabel154.Text = "หนังสือกู้ที่";
            this.xrLabel154.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel154.WordWrap = false;
            // 
            // xrLabel155
            // 
            this.xrLabel155.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLabel155.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel155.CanGrow = false;
            this.xrLabel155.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LOAN_CONTRACT_NO")});
            this.xrLabel155.Font = new System.Drawing.Font("AngsanaUPC", 13.8F);
            this.xrLabel155.LocationFloat = new DevExpress.Utils.PointFloat(61.36707F, 0F);
            this.xrLabel155.Name = "xrLabel155";
            this.xrLabel155.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel155.SizeF = new System.Drawing.SizeF(102.6065F, 23.00003F);
            this.xrLabel155.StylePriority.UseBorderDashStyle = false;
            this.xrLabel155.StylePriority.UseBorders = false;
            this.xrLabel155.StylePriority.UseFont = false;
            this.xrLabel155.StylePriority.UseTextAlignment = false;
            this.xrLabel155.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrLabel155.WordWrap = false;
            // 
            // xrLabel157
            // 
            this.xrLabel157.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLabel157.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel157.CanGrow = false;
            this.xrLabel157.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_OF_LOAN", "{0:n2}")});
            this.xrLabel157.Font = new System.Drawing.Font("AngsanaUPC", 13.8F);
            this.xrLabel157.LocationFloat = new DevExpress.Utils.PointFloat(227.9773F, 0F);
            this.xrLabel157.Name = "xrLabel157";
            this.xrLabel157.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel157.SizeF = new System.Drawing.SizeF(111.3599F, 23.00003F);
            this.xrLabel157.StylePriority.UseBorderDashStyle = false;
            this.xrLabel157.StylePriority.UseBorders = false;
            this.xrLabel157.StylePriority.UseFont = false;
            this.xrLabel157.StylePriority.UseTextAlignment = false;
            this.xrLabel157.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel157.WordWrap = false;
            // 
            // xrLabel156
            // 
            this.xrLabel156.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel156.LocationFloat = new DevExpress.Utils.PointFloat(163.9735F, 0F);
            this.xrLabel156.Name = "xrLabel156";
            this.xrLabel156.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel156.SizeF = new System.Drawing.SizeF(64.00381F, 25F);
            this.xrLabel156.StylePriority.UseFont = false;
            this.xrLabel156.StylePriority.UseTextAlignment = false;
            this.xrLabel156.Text = "หนี้คงเหลือ";
            this.xrLabel156.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel156.WordWrap = false;
            // 
            // xrLabel158
            // 
            this.xrLabel158.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel158.LocationFloat = new DevExpress.Utils.PointFloat(339.3373F, 0F);
            this.xrLabel158.Name = "xrLabel158";
            this.xrLabel158.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel158.SizeF = new System.Drawing.SizeF(27.92529F, 25.00001F);
            this.xrLabel158.StylePriority.UseFont = false;
            this.xrLabel158.StylePriority.UseTextAlignment = false;
            this.xrLabel158.Text = "บาท";
            this.xrLabel158.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel158.WordWrap = false;
            // 
            // xrLabel161
            // 
            this.xrLabel161.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel161.LocationFloat = new DevExpress.Utils.PointFloat(528.1133F, 0F);
            this.xrLabel161.Name = "xrLabel161";
            this.xrLabel161.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel161.SizeF = new System.Drawing.SizeF(27.92529F, 25.00001F);
            this.xrLabel161.StylePriority.UseFont = false;
            this.xrLabel161.StylePriority.UseTextAlignment = false;
            this.xrLabel161.Text = "บาท";
            this.xrLabel161.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel161.WordWrap = false;
            // 
            // xrLabel160
            // 
            this.xrLabel160.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel160.LocationFloat = new DevExpress.Utils.PointFloat(367.2627F, 0F);
            this.xrLabel160.Name = "xrLabel160";
            this.xrLabel160.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel160.SizeF = new System.Drawing.SizeF(46.00381F, 25F);
            this.xrLabel160.StylePriority.UseFont = false;
            this.xrLabel160.StylePriority.UseTextAlignment = false;
            this.xrLabel160.Text = "ดอกเบี้ย";
            this.xrLabel160.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel160.WordWrap = false;
            // 
            // xrLabel159
            // 
            this.xrLabel159.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLabel159.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel159.CanGrow = false;
            this.xrLabel159.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MONTHLY_PAY_I", "{0:n2}")});
            this.xrLabel159.Font = new System.Drawing.Font("AngsanaUPC", 13.8F);
            this.xrLabel159.LocationFloat = new DevExpress.Utils.PointFloat(413.2667F, 0F);
            this.xrLabel159.Name = "xrLabel159";
            this.xrLabel159.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel159.SizeF = new System.Drawing.SizeF(114.8467F, 23.00003F);
            this.xrLabel159.StylePriority.UseBorderDashStyle = false;
            this.xrLabel159.StylePriority.UseBorders = false;
            this.xrLabel159.StylePriority.UseFont = false;
            this.xrLabel159.StylePriority.UseTextAlignment = false;
            this.xrLabel159.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel159.WordWrap = false;
            // 
            // xrLabel162
            // 
            this.xrLabel162.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel162.LocationFloat = new DevExpress.Utils.PointFloat(556.0387F, 0F);
            this.xrLabel162.Name = "xrLabel162";
            this.xrLabel162.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel162.SizeF = new System.Drawing.SizeF(66.76709F, 25F);
            this.xrLabel162.StylePriority.UseFont = false;
            this.xrLabel162.StylePriority.UseTextAlignment = false;
            this.xrLabel162.Text = "ชำระมาแล้ว";
            this.xrLabel162.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel162.WordWrap = false;
            // 
            // xrLabel163
            // 
            this.xrLabel163.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLabel163.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel163.CanGrow = false;
            this.xrLabel163.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LAST_PERIOD")});
            this.xrLabel163.Font = new System.Drawing.Font("AngsanaUPC", 13.8F);
            this.xrLabel163.LocationFloat = new DevExpress.Utils.PointFloat(622.8057F, 0F);
            this.xrLabel163.Name = "xrLabel163";
            this.xrLabel163.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel163.SizeF = new System.Drawing.SizeF(73.51093F, 22.99997F);
            this.xrLabel163.StylePriority.UseBorderDashStyle = false;
            this.xrLabel163.StylePriority.UseBorders = false;
            this.xrLabel163.StylePriority.UseFont = false;
            this.xrLabel163.StylePriority.UseTextAlignment = false;
            this.xrLabel163.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrLabel163.WordWrap = false;
            // 
            // xrLabel164
            // 
            this.xrLabel164.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel164.LocationFloat = new DevExpress.Utils.PointFloat(696.3166F, 0F);
            this.xrLabel164.Name = "xrLabel164";
            this.xrLabel164.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel164.SizeF = new System.Drawing.SizeF(24.92529F, 25.00001F);
            this.xrLabel164.StylePriority.UseFont = false;
            this.xrLabel164.StylePriority.UseTextAlignment = false;
            this.xrLabel164.Text = "งวด";
            this.xrLabel164.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel164.WordWrap = false;
            // 
            // r_mwa_req_form_loan_rest_nest
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.DetailCaption3,
            this.DetailData3,
            this.DetailData3_Odd,
            this.DetailCaptionBackground3,
            this.PageInfo});
            this.Version = "17.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.XRControlStyle Title;
        private DevExpress.XtraReports.UI.XRControlStyle DetailCaption3;
        private DevExpress.XtraReports.UI.XRControlStyle DetailData3;
        private DevExpress.XtraReports.UI.XRControlStyle DetailData3_Odd;
        private DevExpress.XtraReports.UI.XRControlStyle DetailCaptionBackground3;
        private DevExpress.XtraReports.UI.XRControlStyle PageInfo;
        private DevExpress.XtraReports.UI.XRLabel xrLabel154;
        private DevExpress.XtraReports.UI.XRLabel xrLabel155;
        private DevExpress.XtraReports.UI.XRLabel xrLabel157;
        private DevExpress.XtraReports.UI.XRLabel xrLabel156;
        private DevExpress.XtraReports.UI.XRLabel xrLabel158;
        private DevExpress.XtraReports.UI.XRLabel xrLabel161;
        private DevExpress.XtraReports.UI.XRLabel xrLabel160;
        private DevExpress.XtraReports.UI.XRLabel xrLabel159;
        private DevExpress.XtraReports.UI.XRLabel xrLabel162;
        private DevExpress.XtraReports.UI.XRLabel xrLabel163;
        private DevExpress.XtraReports.UI.XRLabel xrLabel164;
    }
}
