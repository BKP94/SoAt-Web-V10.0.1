namespace scReport.Reports.rcTeller.loanRequest
{
    partial class r_ktm_loan_req_norm_mol_wait_nest_old_loan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_ktm_loan_req_norm_mol_wait_nest_old_loan));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.clear_target = new DevExpress.XtraReports.UI.FormattingRule();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.c_last_period = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_principal = new DevExpress.XtraReports.UI.CalculatedField();
            this.clear_not = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
            this.monthly_pay = new DevExpress.XtraReports.UI.XRCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel47,
            this.xrLabel46,
            this.xrLabel43,
            this.monthly_pay});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // clear_target
            // 
            this.clear_target.Condition = "Iif([CLEAR_TARGET] =  \'0\' , True ,False )";
            // 
            // 
            // 
            this.clear_target.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.clear_target.Name = "clear_target";
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
            // c_last_period
            // 
            this.c_last_period.DataMember = "Query";
            this.c_last_period.Expression = "[LAST_PERIOD] + \' \' + Iif([PENDING_AMOUNT] > 0 , 1 , 0 )";
            this.c_last_period.Name = "c_last_period";
            // 
            // c_principal
            // 
            this.c_principal.DataMember = "Query";
            this.c_principal.Expression = "Iif([CLEAR_TARGET] = \'1\' , [PRINCIPAL_BALANCE_OF_LOAN] , [PRINCIPAL_OF_LOAN]  - [" +
    "PENDING_AMOUNT] ) + Iif([CLEAR_TARGET] = \'1\' , [INTEREST_AMOUNT]  , 0 )";
            this.c_principal.Name = "c_principal";
            // 
            // clear_not
            // 
            this.clear_not.Condition = "Iif([CLEAR_TARGET] = \'1\', False ,True )";
            // 
            // 
            // 
            this.clear_not.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.clear_not.Name = "clear_not";
            // 
            // xrLabel47
            // 
            this.xrLabel47.CanGrow = false;
            this.xrLabel47.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LOAN_CONTRACT_NO")});
            this.xrLabel47.Dpi = 100F;
            this.xrLabel47.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel47.Name = "xrLabel47";
            this.xrLabel47.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel47.SizeF = new System.Drawing.SizeF(73F, 25F);
            this.xrLabel47.StylePriority.UseTextAlignment = false;
            this.xrLabel47.Text = "xrLabel2";
            this.xrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel46
            // 
            this.xrLabel46.CanGrow = false;
            this.xrLabel46.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_last_period", "{0:#,#0}")});
            this.xrLabel46.Dpi = 100F;
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(74.70862F, 0F);
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(28F, 25F);
            this.xrLabel46.StylePriority.UseTextAlignment = false;
            this.xrLabel46.Text = "xrLabel2";
            this.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel43
            // 
            this.xrLabel43.CanGrow = false;
            this.xrLabel43.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_principal", "{0:n2}")});
            this.xrLabel43.Dpi = 100F;
            this.xrLabel43.LocationFloat = new DevExpress.Utils.PointFloat(104.7086F, 0F);
            this.xrLabel43.Name = "xrLabel43";
            this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel43.SizeF = new System.Drawing.SizeF(87F, 25F);
            this.xrLabel43.StylePriority.UseTextAlignment = false;
            this.xrLabel43.Text = "xrLabel2";
            this.xrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // monthly_pay
            // 
            this.monthly_pay.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.monthly_pay.Dpi = 100F;
            this.monthly_pay.ForeColor = System.Drawing.Color.Red;
            this.monthly_pay.LocationFloat = new DevExpress.Utils.PointFloat(193.7086F, 0F);
            this.monthly_pay.Name = "monthly_pay";
            this.monthly_pay.SizeF = new System.Drawing.SizeF(55F, 25F);
            this.monthly_pay.StylePriority.UseBorders = false;
            this.monthly_pay.StylePriority.UseForeColor = false;
            this.monthly_pay.StylePriority.UseTextAlignment = false;
            this.monthly_pay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.monthly_pay.Visible = false;
            // 
            // r_ktm_loan_req_norm_mol_wait_nest_old_loan
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.c_last_period,
            this.c_principal});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("AngsanaUPC", 13F);
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.clear_target,
            this.clear_not});
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
        private DevExpress.XtraReports.UI.CalculatedField c_last_period;
        private DevExpress.XtraReports.UI.CalculatedField c_principal;
        private DevExpress.XtraReports.UI.FormattingRule clear_target;
        private DevExpress.XtraReports.UI.FormattingRule clear_not;
        private DevExpress.XtraReports.UI.XRLabel xrLabel47;
        private DevExpress.XtraReports.UI.XRLabel xrLabel46;
        private DevExpress.XtraReports.UI.XRLabel xrLabel43;
        private DevExpress.XtraReports.UI.XRCheckBox monthly_pay;
    }
}
