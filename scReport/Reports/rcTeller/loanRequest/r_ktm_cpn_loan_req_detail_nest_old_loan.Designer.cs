namespace scReport.Reports.rcTeller.loanRequest
{
    partial class r_ktm_cpn_loan_req_detail_nest_old_loan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_ktm_cpn_loan_req_detail_nest_old_loan));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.monthly_pay = new DevExpress.XtraReports.UI.XRCheckBox();
            this.clear_target = new DevExpress.XtraReports.UI.FormattingRule();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.c_last_period = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_principal = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_interst_amont = new DevExpress.XtraReports.UI.CalculatedField();
            this.xrLabel70 = new DevExpress.XtraReports.UI.XRLabel();
            this.clear_not = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.c_principal_balance_of_loan = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_clear_target = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_text = new DevExpress.XtraReports.UI.CalculatedField();
            this.calculatedField1 = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1,
            this.monthly_pay});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.CanGrow = false;
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LOAN_TYPE")});
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(55F, 25F);
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "xrLabel2";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.CanGrow = false;
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_last_period", "{0:#,#0}")});
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(56.99997F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(30F, 25F);
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "xrLabel2";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.CanGrow = false;
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_principal", "{0:n2}")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(89.41666F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(89F, 25F);
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_interst_amont", "{0:n2}")});
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(181.0832F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(55.00012F, 25F);
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "xrLabel2";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // monthly_pay
            // 
            this.monthly_pay.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.monthly_pay.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("CheckState", null, "Query.MONTHLY_PAY")});
            this.monthly_pay.Dpi = 100F;
            this.monthly_pay.ForeColor = System.Drawing.Color.Red;
            this.monthly_pay.FormattingRules.Add(this.clear_target);
            this.monthly_pay.LocationFloat = new DevExpress.Utils.PointFloat(256.8332F, 0F);
            this.monthly_pay.Name = "monthly_pay";
            this.monthly_pay.SizeF = new System.Drawing.SizeF(56.24994F, 25F);
            this.monthly_pay.StylePriority.UseBorders = false;
            this.monthly_pay.StylePriority.UseForeColor = false;
            this.monthly_pay.StylePriority.UseTextAlignment = false;
            this.monthly_pay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.monthly_pay.Visible = false;
            this.monthly_pay.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.monthly_pay_BeforePrint);
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
            this.c_principal.Expression = "Iif([CLEAR_TARGET] = \'1\' , [PRINCIPAL_BALANCE_OF_LOAN] , [PRINCIPAL_OF_LOAN] )";
            this.c_principal.Name = "c_principal";
            // 
            // c_interst_amont
            // 
            this.c_interst_amont.DataMember = "Query";
            this.c_interst_amont.Expression = "Iif([CLEAR_TARGET] = \'1\', [INTEREST_AMOUNT] , 0 )";
            this.c_interst_amont.Name = "c_interst_amont";
            // 
            // xrLabel70
            // 
            this.xrLabel70.BorderColor = System.Drawing.Color.Gray;
            this.xrLabel70.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel70.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel70.CanGrow = false;
            this.xrLabel70.Dpi = 100F;
            this.xrLabel70.FormattingRules.Add(this.clear_not);
            this.xrLabel70.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel70.Name = "xrLabel70";
            this.xrLabel70.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel70.SizeF = new System.Drawing.SizeF(313.0831F, 5.625F);
            this.xrLabel70.StylePriority.UseBorderColor = false;
            this.xrLabel70.StylePriority.UseBorderDashStyle = false;
            this.xrLabel70.StylePriority.UseBorders = false;
            this.xrLabel70.StylePriority.UseTextAlignment = false;
            this.xrLabel70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
            // xrLabel5
            // 
            this.xrLabel5.CanGrow = false;
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_text")});
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 5.624994F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(86.99997F, 25F);
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.CanGrow = false;
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_principal_balance_of_loan")});
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(89.41666F, 5.624994F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(89F, 25F);
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:n2}";
            xrSummary1.IgnoreNullValues = true;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel6.Summary = xrSummary1;
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel70,
            this.xrLabel6,
            this.xrLabel5});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 41.87499F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel10
            // 
            this.xrLabel10.BorderColor = System.Drawing.Color.Gray;
            this.xrLabel10.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel10.CanGrow = false;
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.FormattingRules.Add(this.clear_target);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(0F, 36.24999F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(313.0831F, 5.625F);
            this.xrLabel10.StylePriority.UseBorderColor = false;
            this.xrLabel10.StylePriority.UseBorderDashStyle = false;
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.BorderColor = System.Drawing.Color.Gray;
            this.xrLabel9.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel9.CanGrow = false;
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.FormattingRules.Add(this.clear_target);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 30.62499F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(313.0831F, 5.625F);
            this.xrLabel9.StylePriority.UseBorderColor = false;
            this.xrLabel9.StylePriority.UseBorderDashStyle = false;
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.CanGrow = false;
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_clear_target")});
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(238.0832F, 5.624994F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(74.99988F, 25F);
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:n2}";
            xrSummary2.IgnoreNullValues = true;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel8.Summary = xrSummary2;
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.CanGrow = false;
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_interst_amont")});
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(181.0832F, 5.625F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(55.00012F, 25F);
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:n2}";
            xrSummary3.IgnoreNullValues = true;
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel7.Summary = xrSummary3;
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // c_principal_balance_of_loan
            // 
            this.c_principal_balance_of_loan.DataMember = "Query";
            this.c_principal_balance_of_loan.Expression = "Iif([CLEAR_TARGET] = \'1\' , [PRINCIPAL_BALANCE_OF_LOAN] , 0 )";
            this.c_principal_balance_of_loan.Name = "c_principal_balance_of_loan";
            // 
            // c_clear_target
            // 
            this.c_clear_target.DataMember = "Query";
            this.c_clear_target.Expression = "[c_principal_balance_of_loan] + [c_interst_amont]";
            this.c_clear_target.Name = "c_clear_target";
            // 
            // c_text
            // 
            this.c_text.DataMember = "Query";
            this.c_text.Expression = "Iif([CLEAR_TARGET] = \'1\', \'รวมหักกลบ\' , \'\' )";
            this.c_text.Name = "c_text";
            // 
            // calculatedField1
            // 
            this.calculatedField1.DataMember = "Query";
            this.calculatedField1.Expression = "Iif(IsNull([CLEAR_TARGET]), 0 ,1 )";
            this.calculatedField1.Name = "calculatedField1";
            // 
            // r_ktm_cpn_loan_req_detail_nest_old_loan
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.c_last_period,
            this.c_principal,
            this.c_interst_amont,
            this.c_principal_balance_of_loan,
            this.c_clear_target,
            this.c_text,
            this.calculatedField1});
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
        private DevExpress.XtraReports.UI.CalculatedField c_interst_amont;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel70;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.CalculatedField c_principal_balance_of_loan;
        private DevExpress.XtraReports.UI.CalculatedField c_clear_target;
        private DevExpress.XtraReports.UI.XRCheckBox monthly_pay;
        private DevExpress.XtraReports.UI.FormattingRule clear_target;
        private DevExpress.XtraReports.UI.FormattingRule clear_not;
        private DevExpress.XtraReports.UI.CalculatedField c_text;
        private DevExpress.XtraReports.UI.CalculatedField calculatedField1;
    }
}
