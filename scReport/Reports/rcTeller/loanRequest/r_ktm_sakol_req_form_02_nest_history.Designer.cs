namespace scReport.Reports.rcTeller.loanRequest
{
    partial class r_ktm_sakol_req_form_02_nest_history
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_ktm_sakol_req_form_02_nest_history));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel85 = new DevExpress.XtraReports.UI.XRLabel();
            this.monthly_pay = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel82 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel83 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel84 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel86 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel87 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel88 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel89 = new DevExpress.XtraReports.UI.XRLabel();
            this.clear_target = new DevExpress.XtraReports.UI.FormattingRule();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.c_total_old_loan = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_total_old_int = new DevExpress.XtraReports.UI.CalculatedField();
            this.clear_not = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.c_total_old_loan_sum = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_text = new DevExpress.XtraReports.UI.CalculatedField();
            this.calculatedField1 = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_loan_installment = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_balance = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel85,
            this.monthly_pay,
            this.xrLabel82,
            this.xrLabel83,
            this.xrLabel84,
            this.xrLabel86,
            this.xrLabel87,
            this.xrLabel88,
            this.xrLabel89});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 37.50005F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel85
            // 
            this.xrLabel85.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel85.CanGrow = false;
            this.xrLabel85.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LOAN_TYPE")});
            this.xrLabel85.Dpi = 100F;
            this.xrLabel85.LocationFloat = new DevExpress.Utils.PointFloat(7.629395E-06F, 0F);
            this.xrLabel85.Name = "xrLabel85";
            this.xrLabel85.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel85.SizeF = new System.Drawing.SizeF(104.2402F, 37.50005F);
            this.xrLabel85.StylePriority.UseBorders = false;
            this.xrLabel85.StylePriority.UseTextAlignment = false;
            this.xrLabel85.Text = "xrLabel2";
            this.xrLabel85.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // monthly_pay
            // 
            this.monthly_pay.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.monthly_pay.Dpi = 100F;
            this.monthly_pay.ForeColor = System.Drawing.Color.Red;
            this.monthly_pay.LocationFloat = new DevExpress.Utils.PointFloat(415.5025F, 4.768372E-05F);
            this.monthly_pay.Name = "monthly_pay";
            this.monthly_pay.SizeF = new System.Drawing.SizeF(48.0195F, 37.5F);
            this.monthly_pay.StylePriority.UseBorders = false;
            this.monthly_pay.StylePriority.UseForeColor = false;
            this.monthly_pay.StylePriority.UseTextAlignment = false;
            this.monthly_pay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.monthly_pay.Visible = false;
            // 
            // xrLabel82
            // 
            this.xrLabel82.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel82.CanGrow = false;
            this.xrLabel82.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_loan_installment")});
            this.xrLabel82.Dpi = 100F;
            this.xrLabel82.LocationFloat = new DevExpress.Utils.PointFloat(246.2034F, 4.768372E-05F);
            this.xrLabel82.Name = "xrLabel82";
            this.xrLabel82.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel82.SizeF = new System.Drawing.SizeF(42.53424F, 37.5F);
            this.xrLabel82.StylePriority.UseBorders = false;
            this.xrLabel82.StylePriority.UseTextAlignment = false;
            this.xrLabel82.Text = "xrLabel2";
            this.xrLabel82.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel83
            // 
            this.xrLabel83.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel83.CanGrow = false;
            this.xrLabel83.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PERIOD_PAYMENT_AMOUNT", "{0:n2}")});
            this.xrLabel83.Dpi = 100F;
            this.xrLabel83.LocationFloat = new DevExpress.Utils.PointFloat(181.1152F, 4.768372E-05F);
            this.xrLabel83.Name = "xrLabel83";
            this.xrLabel83.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel83.SizeF = new System.Drawing.SizeF(65.08821F, 37.5F);
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
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LOAN_APPROVE_AMOUNT", "{0:n2}")});
            this.xrLabel84.Dpi = 100F;
            this.xrLabel84.LocationFloat = new DevExpress.Utils.PointFloat(104.2402F, 4.768372E-05F);
            this.xrLabel84.Name = "xrLabel84";
            this.xrLabel84.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel84.SizeF = new System.Drawing.SizeF(76.87501F, 37.5F);
            this.xrLabel84.StylePriority.UseBorders = false;
            this.xrLabel84.StylePriority.UseTextAlignment = false;
            this.xrLabel84.Text = "xrLabel2";
            this.xrLabel84.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel86
            // 
            this.xrLabel86.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel86.CanGrow = false;
            this.xrLabel86.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_balance", "{0:n2}")});
            this.xrLabel86.Dpi = 100F;
            this.xrLabel86.LocationFloat = new DevExpress.Utils.PointFloat(288.7377F, 0F);
            this.xrLabel86.Name = "xrLabel86";
            this.xrLabel86.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel86.SizeF = new System.Drawing.SizeF(109.6961F, 37.50005F);
            this.xrLabel86.StylePriority.UseBorders = false;
            this.xrLabel86.StylePriority.UseTextAlignment = false;
            this.xrLabel86.Text = "xrLabel2";
            this.xrLabel86.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel87
            // 
            this.xrLabel87.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel87.CanGrow = false;
            this.xrLabel87.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_total_old_loan", "{0:n2}")});
            this.xrLabel87.Dpi = 100F;
            this.xrLabel87.LocationFloat = new DevExpress.Utils.PointFloat(463.522F, 4.768372E-05F);
            this.xrLabel87.Name = "xrLabel87";
            this.xrLabel87.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel87.SizeF = new System.Drawing.SizeF(67.19598F, 37.5F);
            this.xrLabel87.StylePriority.UseBorders = false;
            this.xrLabel87.StylePriority.UseTextAlignment = false;
            this.xrLabel87.Text = "xrLabel2";
            this.xrLabel87.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel88
            // 
            this.xrLabel88.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel88.CanGrow = false;
            this.xrLabel88.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_total_old_int", "{0:n2}")});
            this.xrLabel88.Dpi = 100F;
            this.xrLabel88.LocationFloat = new DevExpress.Utils.PointFloat(530.718F, 4.768372E-05F);
            this.xrLabel88.Name = "xrLabel88";
            this.xrLabel88.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel88.SizeF = new System.Drawing.SizeF(67.19598F, 37.5F);
            this.xrLabel88.StylePriority.UseBorders = false;
            this.xrLabel88.StylePriority.UseTextAlignment = false;
            this.xrLabel88.Text = "xrLabel2";
            this.xrLabel88.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel89
            // 
            this.xrLabel89.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel89.CanGrow = false;
            this.xrLabel89.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_total_old_loan_sum", "{0:n2}")});
            this.xrLabel89.Dpi = 100F;
            this.xrLabel89.LocationFloat = new DevExpress.Utils.PointFloat(597.914F, 4.768372E-05F);
            this.xrLabel89.Name = "xrLabel89";
            this.xrLabel89.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel89.SizeF = new System.Drawing.SizeF(72.18127F, 37.5F);
            this.xrLabel89.StylePriority.UseBorders = false;
            this.xrLabel89.StylePriority.UseTextAlignment = false;
            this.xrLabel89.Text = "xrLabel2";
            this.xrLabel89.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            // c_total_old_loan
            // 
            this.c_total_old_loan.DataMember = "Query";
            this.c_total_old_loan.Expression = "Iif([CLEAR_TARGET] =  \'0\' , 0 , [PRINCIPAL_BALANCE] )";
            this.c_total_old_loan.Name = "c_total_old_loan";
            // 
            // c_total_old_int
            // 
            this.c_total_old_int.DataMember = "Query";
            this.c_total_old_int.Expression = "Iif([CLEAR_TARGET] = \'0\', 0 ,[INTEREST_AMOUNT] )";
            this.c_total_old_int.Name = "c_total_old_int";
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
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_balance")});
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(288.7376F, 5F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(109.6961F, 37.5F);
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel6
            // 
            this.xrLabel6.CanGrow = false;
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_total_old_loan")});
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(463.522F, 5F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(67.19598F, 37.5F);
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:n2}";
            xrSummary1.IgnoreNullValues = true;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel6.Summary = xrSummary1;
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel8});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 47.5F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel4
            // 
            this.xrLabel4.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Double;
            this.xrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel4.BorderWidth = 3F;
            this.xrLabel4.CanGrow = false;
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(463.522F, 42.5F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(206.5733F, 5F);
            this.xrLabel4.StylePriority.UseBorderDashStyle = false;
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseBorderWidth = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel3.CanGrow = false;
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(463.522F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(206.5733F, 5F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Double;
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel2.BorderWidth = 3F;
            this.xrLabel2.CanGrow = false;
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(288.7377F, 42.5F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(109.6961F, 5F);
            this.xrLabel2.StylePriority.UseBorderDashStyle = false;
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseBorderWidth = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(288.7376F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(109.6961F, 5F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.CanGrow = false;
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_total_old_loan_sum")});
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(597.9141F, 5F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(72.18127F, 37.5F);
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:n2}";
            xrSummary3.IgnoreNullValues = true;
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel8.Summary = xrSummary3;
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.CanGrow = false;
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_total_old_int")});
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(530.718F, 5F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(67.19604F, 37.5F);
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:n2}";
            xrSummary2.IgnoreNullValues = true;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel7.Summary = xrSummary2;
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // c_total_old_loan_sum
            // 
            this.c_total_old_loan_sum.DataMember = "Query";
            this.c_total_old_loan_sum.Expression = "Iif([CLEAR_TARGET] = \'0\' , 0  , [PRINCIPAL_BALANCE] + [INTEREST_AMOUNT] )";
            this.c_total_old_loan_sum.Name = "c_total_old_loan_sum";
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
            // c_loan_installment
            // 
            this.c_loan_installment.DataMember = "Query";
            this.c_loan_installment.Expression = "([LAST_PERIOD] + Iif([PENDING_AMOUNT] > 0 , 1 , 0 )) + \'/\' + [LOAN_INSTALLMENT]";
            this.c_loan_installment.Name = "c_loan_installment";
            // 
            // c_balance
            // 
            this.c_balance.DataMember = "Query";
            this.c_balance.Expression = "Iif([CLEAR_TARGET] = \'0\' , [PRINCIPAL_OF_LOAN] - [PENDING_AMOUNT] , [PRINCIPAL_BA" +
    "LANCE] )";
            this.c_balance.Name = "c_balance";
            // 
            // r_ktm_sakol_req_form_02_nest_history
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.c_total_old_loan,
            this.c_total_old_int,
            this.c_total_old_loan_sum,
            this.c_text,
            this.calculatedField1,
            this.c_loan_installment,
            this.c_balance});
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
        private DevExpress.XtraReports.UI.CalculatedField c_total_old_loan;
        private DevExpress.XtraReports.UI.CalculatedField c_total_old_int;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.CalculatedField c_total_old_loan_sum;
        private DevExpress.XtraReports.UI.FormattingRule clear_target;
        private DevExpress.XtraReports.UI.FormattingRule clear_not;
        private DevExpress.XtraReports.UI.CalculatedField c_text;
        private DevExpress.XtraReports.UI.CalculatedField calculatedField1;
        private DevExpress.XtraReports.UI.CalculatedField c_loan_installment;
        private DevExpress.XtraReports.UI.CalculatedField c_balance;
        private DevExpress.XtraReports.UI.XRCheckBox monthly_pay;
        private DevExpress.XtraReports.UI.XRLabel xrLabel82;
        private DevExpress.XtraReports.UI.XRLabel xrLabel83;
        private DevExpress.XtraReports.UI.XRLabel xrLabel84;
        private DevExpress.XtraReports.UI.XRLabel xrLabel86;
        private DevExpress.XtraReports.UI.XRLabel xrLabel87;
        private DevExpress.XtraReports.UI.XRLabel xrLabel88;
        private DevExpress.XtraReports.UI.XRLabel xrLabel89;
        private DevExpress.XtraReports.UI.XRLabel xrLabel85;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
    }
}
