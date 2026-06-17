namespace scReport.Reports.rcTeller.loanCon
{
    partial class r_mwa_book_loan_norm_nest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_mwa_book_loan_norm_nest));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.f_border = new DevExpress.XtraReports.UI.FormattingRule();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailCaption3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData3_Odd = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailCaptionBackground3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.c_name = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_mem_no = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_group = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_id_card = new DevExpress.XtraReports.UI.CalculatedField();
            this.xrLabel273 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel272 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel271 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel270 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel269 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel268 = new DevExpress.XtraReports.UI.XRLabel();
            this.c_id_card_08 = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_mem_no_08 = new DevExpress.XtraReports.UI.CalculatedField();
            this.calculatedField3 = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel273,
            this.xrLabel272,
            this.xrLabel271,
            this.xrLabel270,
            this.xrLabel269,
            this.xrLabel268});
            this.Detail.HeightF = 25.00051F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // f_border
            // 
            this.f_border.Condition = "Iif([COLLATERAL_TYPE_CODE] = \'03\',true,false)";
            this.f_border.DataMember = "Query";
            this.f_border.Formatting.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.f_border.Formatting.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.f_border.Name = "f_border";
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
            // c_name
            // 
            this.c_name.DataMember = "Query";
            this.c_name.Expression = "Iif([COLLATERAL_TYPE_CODE] =\'03\',\'เงินฝากในสหกรณ์ ชื่อบัญชี \'+[COLLATERAL_DESCRIP" +
    "TION],[COLLATERAL_DESCRIPTION])";
            this.c_name.Name = "c_name";
            // 
            // c_mem_no
            // 
            this.c_mem_no.DataMember = "Query";
            this.c_mem_no.Expression = "Iif([COLLATERAL_TYPE_CODE] =\'03\' ,\'เลขที่ \'+[REF_OWN_NO], \'สมาชิกเลขที่ \'+[REF_OW" +
    "N_NO])";
            this.c_mem_no.Name = "c_mem_no";
            // 
            // c_group
            // 
            this.c_group.DataMember = "Query";
            this.c_group.Expression = "Iif([COLLATERAL_TYPE_CODE] = \'03\',\'\',\'สังกัด \'+[MEMBER_GROUP_NAME])";
            this.c_group.Name = "c_group";
            // 
            // c_id_card
            // 
            this.c_id_card.DataMember = "Query";
            this.c_id_card.Expression = "Iif([COLLATERAL_TYPE_CODE] = \'03\',\'\',\'เลขที่บัตรประจำตัวประชาชน \'+[COLL_ID_CARD])" +
    "";
            this.c_id_card.Name = "c_id_card";
            // 
            // xrLabel273
            // 
            this.xrLabel273.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLabel273.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel273.CanGrow = false;
            this.xrLabel273.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_id_card_08")});
            this.xrLabel273.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel273.LocationFloat = new DevExpress.Utils.PointFloat(481.1452F, 0.0005086263F);
            this.xrLabel273.Name = "xrLabel273";
            this.xrLabel273.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel273.SizeF = new System.Drawing.SizeF(149.8961F, 22.99999F);
            this.xrLabel273.StylePriority.UseBorderDashStyle = false;
            this.xrLabel273.StylePriority.UseBorders = false;
            this.xrLabel273.StylePriority.UseFont = false;
            this.xrLabel273.StylePriority.UseTextAlignment = false;
            this.xrLabel273.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel273.WordWrap = false;
            // 
            // xrLabel272
            // 
            this.xrLabel272.CanGrow = false;
            this.xrLabel272.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel272.LocationFloat = new DevExpress.Utils.PointFloat(373.9243F, 0.0005086263F);
            this.xrLabel272.Name = "xrLabel272";
            this.xrLabel272.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel272.SizeF = new System.Drawing.SizeF(107.2209F, 24.99999F);
            this.xrLabel272.StylePriority.UseFont = false;
            this.xrLabel272.StylePriority.UseTextAlignment = false;
            this.xrLabel272.Text = "เลขที่บัตรประชาชน";
            this.xrLabel272.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel272.WordWrap = false;
            // 
            // xrLabel271
            // 
            this.xrLabel271.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLabel271.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel271.CanGrow = false;
            this.xrLabel271.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_mem_no_08")});
            this.xrLabel271.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel271.LocationFloat = new DevExpress.Utils.PointFloat(306.2363F, 0.0005086263F);
            this.xrLabel271.Name = "xrLabel271";
            this.xrLabel271.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel271.SizeF = new System.Drawing.SizeF(67.4162F, 23F);
            this.xrLabel271.StylePriority.UseBorderDashStyle = false;
            this.xrLabel271.StylePriority.UseBorders = false;
            this.xrLabel271.StylePriority.UseFont = false;
            this.xrLabel271.StylePriority.UseTextAlignment = false;
            this.xrLabel271.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel271.WordWrap = false;
            // 
            // xrLabel270
            // 
            this.xrLabel270.CanGrow = false;
            this.xrLabel270.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel270.LocationFloat = new DevExpress.Utils.PointFloat(236.6307F, 0.0005086263F);
            this.xrLabel270.Name = "xrLabel270";
            this.xrLabel270.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel270.SizeF = new System.Drawing.SizeF(69.60553F, 25F);
            this.xrLabel270.StylePriority.UseFont = false;
            this.xrLabel270.StylePriority.UseTextAlignment = false;
            this.xrLabel270.Text = "สมาชิกเลขที่";
            this.xrLabel270.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel270.WordWrap = false;
            // 
            // xrLabel269
            // 
            this.xrLabel269.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLabel269.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel269.CanGrow = false;
            this.xrLabel269.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.COLLATERAL_DESCRIPTION")});
            this.xrLabel269.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel269.LocationFloat = new DevExpress.Utils.PointFloat(20.07615F, 0.0002034505F);
            this.xrLabel269.Name = "xrLabel269";
            this.xrLabel269.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel269.SizeF = new System.Drawing.SizeF(216.5546F, 23F);
            this.xrLabel269.StylePriority.UseBorderDashStyle = false;
            this.xrLabel269.StylePriority.UseBorders = false;
            this.xrLabel269.StylePriority.UseFont = false;
            this.xrLabel269.StylePriority.UseTextAlignment = false;
            this.xrLabel269.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel269.WordWrap = false;
            // 
            // xrLabel268
            // 
            this.xrLabel268.CanGrow = false;
            this.xrLabel268.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.xrLabel268.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel268.Name = "xrLabel268";
            this.xrLabel268.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel268.SizeF = new System.Drawing.SizeF(20.07611F, 25.00001F);
            this.xrLabel268.StylePriority.UseFont = false;
            this.xrLabel268.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0}.";
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            xrSummary1.IgnoreNullValues = true;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel268.Summary = xrSummary1;
            this.xrLabel268.Text = "1. ";
            this.xrLabel268.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel268.WordWrap = false;
            // 
            // c_id_card_08
            // 
            this.c_id_card_08.DataMember = "Query";
            this.c_id_card_08.Expression = "Iif([COLLATERAL_TYPE_CODE] = \'08\',[REF_OWN_NO],[COLL_ID_CARD])";
            this.c_id_card_08.Name = "c_id_card_08";
            // 
            // c_mem_no_08
            // 
            this.c_mem_no_08.DataMember = "Query";
            this.c_mem_no_08.Expression = "Iif([COLLATERAL_TYPE_CODE] = \'08\',\'-\',[REF_OWN_NO])";
            this.c_mem_no_08.Name = "c_mem_no_08";
            // 
            // calculatedField3
            // 
            this.calculatedField3.DataMember = "Query";
            this.calculatedField3.Name = "calculatedField3";
            // 
            // r_mwa_book_loan_norm_nest
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.c_name,
            this.c_mem_no,
            this.c_group,
            this.c_id_card,
            this.c_id_card_08,
            this.c_mem_no_08,
            this.calculatedField3});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.f_border});
            this.Margins = new System.Drawing.Printing.Margins(30, 10, 0, 0);
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
        private DevExpress.XtraReports.UI.CalculatedField c_name;
        private DevExpress.XtraReports.UI.CalculatedField c_mem_no;
        private DevExpress.XtraReports.UI.CalculatedField c_group;
        private DevExpress.XtraReports.UI.FormattingRule f_border;
        private DevExpress.XtraReports.UI.CalculatedField c_id_card;
        private DevExpress.XtraReports.UI.XRLabel xrLabel273;
        private DevExpress.XtraReports.UI.XRLabel xrLabel272;
        private DevExpress.XtraReports.UI.XRLabel xrLabel271;
        private DevExpress.XtraReports.UI.XRLabel xrLabel270;
        private DevExpress.XtraReports.UI.XRLabel xrLabel269;
        private DevExpress.XtraReports.UI.XRLabel xrLabel268;
        private DevExpress.XtraReports.UI.CalculatedField c_id_card_08;
        private DevExpress.XtraReports.UI.CalculatedField c_mem_no_08;
        private DevExpress.XtraReports.UI.CalculatedField calculatedField3;
    }
}
