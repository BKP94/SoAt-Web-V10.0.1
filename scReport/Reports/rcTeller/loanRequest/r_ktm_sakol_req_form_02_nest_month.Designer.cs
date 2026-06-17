namespace scReport.Reports.rcTeller.loanRequest
{
    partial class r_ktm_sakol_req_form_02_nest_month
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_ktm_sakol_req_form_02_nest_month));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.type_pay_monery = new DevExpress.XtraReports.UI.FormattingRule();
            this.c_trim_loan_contract_no = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_period = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_type_code = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_monthly_pay = new DevExpress.XtraReports.UI.CalculatedField();
            this.xrLabel84 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel83 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel82 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel87 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel86 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel84,
            this.xrLabel83,
            this.xrLabel82,
            this.xrLabel87,
            this.xrLabel86});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 28.92159F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("FEE_DES", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
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
            // type_pay_monery
            // 
            this.type_pay_monery.Condition = "Iif([TYPE_PAY_MONEY] = \'TRB\' or [TYPE_PAY_MONEY] = \'TRD\', True ,False )";
            this.type_pay_monery.Name = "type_pay_monery";
            // 
            // c_trim_loan_contract_no
            // 
            this.c_trim_loan_contract_no.DataMember = "Query";
            this.c_trim_loan_contract_no.Expression = "Trim([LOAN_CONTRACT_NO])";
            this.c_trim_loan_contract_no.Name = "c_trim_loan_contract_no";
            // 
            // c_period
            // 
            this.c_period.DataMember = "Query";
            this.c_period.Expression = "([LAST_PERIOD] + Iif([PENDING_AMOUNT] > 0 , 1 , 0 )) + Iif([ATM_STATUS] = \'1\' , \'" +
    "\' , \'/\' + [LOAN_INSTALLMENT] )";
            this.c_period.Name = "c_period";
            // 
            // c_type_code
            // 
            this.c_type_code.DataMember = "Query";
            this.c_type_code.Expression = "Iif([LOAN_PAYMENT_TYPE_CODE] = \'01\' , \'คงต้น\' , \'คงยอด\' )";
            this.c_type_code.Name = "c_type_code";
            // 
            // c_monthly_pay
            // 
            this.c_monthly_pay.DataMember = "Query";
            this.c_monthly_pay.Expression = "[MONTHLY_PAY_P] + [MONTHLY_PAY_I]";
            this.c_monthly_pay.Name = "c_monthly_pay";
            // 
            // xrLabel84
            // 
            this.xrLabel84.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel84.CanGrow = false;
            this.xrLabel84.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_monthly_pay", "{0:n2}")});
            this.xrLabel84.Dpi = 100F;
            this.xrLabel84.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel84.ForeColor = System.Drawing.Color.Red;
            this.xrLabel84.LocationFloat = new DevExpress.Utils.PointFloat(280.0858F, 0F);
            this.xrLabel84.Name = "xrLabel84";
            this.xrLabel84.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel84.SizeF = new System.Drawing.SizeF(86.4584F, 28.92159F);
            this.xrLabel84.StylePriority.UseBorders = false;
            this.xrLabel84.StylePriority.UseFont = false;
            this.xrLabel84.StylePriority.UseForeColor = false;
            this.xrLabel84.StylePriority.UseTextAlignment = false;
            this.xrLabel84.Text = "xrLabel2";
            this.xrLabel84.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel83
            // 
            this.xrLabel83.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel83.CanGrow = false;
            this.xrLabel83.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_type_code")});
            this.xrLabel83.Dpi = 100F;
            this.xrLabel83.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel83.ForeColor = System.Drawing.Color.Red;
            this.xrLabel83.LocationFloat = new DevExpress.Utils.PointFloat(172.4607F, 0F);
            this.xrLabel83.Name = "xrLabel83";
            this.xrLabel83.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel83.SizeF = new System.Drawing.SizeF(107.6251F, 28.92159F);
            this.xrLabel83.StylePriority.UseBorders = false;
            this.xrLabel83.StylePriority.UseFont = false;
            this.xrLabel83.StylePriority.UseForeColor = false;
            this.xrLabel83.StylePriority.UseTextAlignment = false;
            this.xrLabel83.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel82
            // 
            this.xrLabel82.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel82.CanGrow = false;
            this.xrLabel82.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MONTHLY_PAY_P", "{0:n2}")});
            this.xrLabel82.Dpi = 100F;
            this.xrLabel82.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel82.ForeColor = System.Drawing.Color.Red;
            this.xrLabel82.LocationFloat = new DevExpress.Utils.PointFloat(120.0857F, 0F);
            this.xrLabel82.Name = "xrLabel82";
            this.xrLabel82.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel82.SizeF = new System.Drawing.SizeF(52.37494F, 28.92159F);
            this.xrLabel82.StylePriority.UseBorders = false;
            this.xrLabel82.StylePriority.UseFont = false;
            this.xrLabel82.StylePriority.UseForeColor = false;
            this.xrLabel82.StylePriority.UseTextAlignment = false;
            this.xrLabel82.Text = "xrLabel2";
            this.xrLabel82.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel87
            // 
            this.xrLabel87.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel87.CanGrow = false;
            this.xrLabel87.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_period")});
            this.xrLabel87.Dpi = 100F;
            this.xrLabel87.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel87.ForeColor = System.Drawing.Color.Red;
            this.xrLabel87.LocationFloat = new DevExpress.Utils.PointFloat(78.0858F, 0F);
            this.xrLabel87.Name = "xrLabel87";
            this.xrLabel87.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel87.SizeF = new System.Drawing.SizeF(41.99998F, 28.92159F);
            this.xrLabel87.StylePriority.UseBorders = false;
            this.xrLabel87.StylePriority.UseFont = false;
            this.xrLabel87.StylePriority.UseForeColor = false;
            this.xrLabel87.StylePriority.UseTextAlignment = false;
            this.xrLabel87.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel86
            // 
            this.xrLabel86.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel86.CanGrow = false;
            this.xrLabel86.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_trim_loan_contract_no")});
            this.xrLabel86.Dpi = 100F;
            this.xrLabel86.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel86.ForeColor = System.Drawing.Color.Red;
            this.xrLabel86.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel86.Name = "xrLabel86";
            this.xrLabel86.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel86.SizeF = new System.Drawing.SizeF(78.08581F, 28.92159F);
            this.xrLabel86.StylePriority.UseBorders = false;
            this.xrLabel86.StylePriority.UseFont = false;
            this.xrLabel86.StylePriority.UseForeColor = false;
            this.xrLabel86.StylePriority.UseTextAlignment = false;
            this.xrLabel86.Text = "xrLabel2";
            this.xrLabel86.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // r_ktm_sakol_req_form_02_nest_month
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.c_trim_loan_contract_no,
            this.c_period,
            this.c_type_code,
            this.c_monthly_pay});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("AngsanaUPC", 12F);
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.type_pay_monery});
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
        private DevExpress.XtraReports.UI.FormattingRule type_pay_monery;
        private DevExpress.XtraReports.UI.CalculatedField c_trim_loan_contract_no;
        private DevExpress.XtraReports.UI.CalculatedField c_period;
        private DevExpress.XtraReports.UI.CalculatedField c_type_code;
        private DevExpress.XtraReports.UI.CalculatedField c_monthly_pay;
        private DevExpress.XtraReports.UI.XRLabel xrLabel84;
        private DevExpress.XtraReports.UI.XRLabel xrLabel83;
        private DevExpress.XtraReports.UI.XRLabel xrLabel82;
        private DevExpress.XtraReports.UI.XRLabel xrLabel87;
        private DevExpress.XtraReports.UI.XRLabel xrLabel86;
    }
}
