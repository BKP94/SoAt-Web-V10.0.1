namespace scReport.Reports.rcTeller.loanapp
{
    partial class r_ktm_loan_paid_cash_nest_loan_old_conno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_ktm_loan_paid_cash_nest_loan_old_conno));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel117 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel116 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel115 = new DevExpress.XtraReports.UI.XRLabel();
            this.visible_not_lon = new DevExpress.XtraReports.UI.FormattingRule();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.calculatedField1 = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel117,
            this.xrLabel116,
            this.xrLabel115});
            this.Detail.Font = new System.Drawing.Font("BrowalliaUPC", 12F);
            this.Detail.HeightF = 26.43F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("ACCOUNT_ID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.Detail.StylePriority.UseFont = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel117
            // 
            this.xrLabel117.CanGrow = false;
            this.xrLabel117.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT", "{0:n2}")});
            this.xrLabel117.Font = new System.Drawing.Font("BrowalliaUPC", 12F);
            this.xrLabel117.LocationFloat = new DevExpress.Utils.PointFloat(139.8611F, 0F);
            this.xrLabel117.Name = "xrLabel117";
            this.xrLabel117.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel117.SizeF = new System.Drawing.SizeF(71.31949F, 26.43F);
            this.xrLabel117.StylePriority.UseFont = false;
            this.xrLabel117.StylePriority.UseTextAlignment = false;
            this.xrLabel117.Text = "xrLabel3";
            this.xrLabel117.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel116
            // 
            this.xrLabel116.CanGrow = false;
            this.xrLabel116.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT", "{0:n2}")});
            this.xrLabel116.Font = new System.Drawing.Font("BrowalliaUPC", 12F);
            this.xrLabel116.LocationFloat = new DevExpress.Utils.PointFloat(75.00001F, 0F);
            this.xrLabel116.Name = "xrLabel116";
            this.xrLabel116.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel116.SizeF = new System.Drawing.SizeF(64.86111F, 26.43F);
            this.xrLabel116.StylePriority.UseFont = false;
            this.xrLabel116.StylePriority.UseTextAlignment = false;
            this.xrLabel116.Text = "xrLabel2";
            this.xrLabel116.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel115
            // 
            this.xrLabel115.CanGrow = false;
            this.xrLabel115.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.calculatedField1")});
            this.xrLabel115.Font = new System.Drawing.Font("BrowalliaUPC", 12F);
            this.xrLabel115.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel115.Name = "xrLabel115";
            this.xrLabel115.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel115.SizeF = new System.Drawing.SizeF(75F, 26.43F);
            this.xrLabel115.StylePriority.UseFont = false;
            this.xrLabel115.StylePriority.UseTextAlignment = false;
            this.xrLabel115.Text = "xrLabel1";
            this.xrLabel115.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // visible_not_lon
            // 
            this.visible_not_lon.Condition = "Iif(  [GROUP_ITEM] = \'LON\' , false , true )";
            this.visible_not_lon.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.visible_not_lon.Name = "visible_not_lon";
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
            // calculatedField1
            // 
            this.calculatedField1.DataMember = "Query";
            this.calculatedField1.DisplayName = "c_loan_contract_no";
            this.calculatedField1.Expression = "trim( [DESCRIPTION] )";
            this.calculatedField1.Name = "calculatedField1";
            // 
            // r_ktm_loan_paid_cash_nest_loan_old_conno
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.calculatedField1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("BrowalliaUPC", 12F);
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.visible_not_lon});
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.Version = "17.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.FormattingRule visible_not_lon;
        private DevExpress.XtraReports.UI.CalculatedField calculatedField1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel117;
        private DevExpress.XtraReports.UI.XRLabel xrLabel116;
        private DevExpress.XtraReports.UI.XRLabel xrLabel115;
    }
}
