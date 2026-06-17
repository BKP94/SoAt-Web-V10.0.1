namespace scReport.Reports.rcTeller.loanCon
{
    partial class r_tnma_period_advance_norm_สง
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_tnma_period_advance_norm_สง));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.r_nest_priod_advance = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.c_period_01 = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_installment_01 = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_last_payment_01 = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_period_02 = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_installment_02 = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel1,
            this.xrLabel3,
            this.xrLabel23,
            this.xrLabel24,
            this.xrLabel17,
            this.xrLabel18,
            this.xrLabel2,
            this.r_nest_priod_advance,
            this.xrLabel21});
            this.Detail.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.Detail.HeightF = 1200F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseFont = false;
            this.Detail.StylePriority.UseTextAlignment = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.CanGrow = false;
            this.xrLabel5.Font = new System.Drawing.Font("BrowalliaUPC", 12F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(359.3203F, 208.5F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(147.5F, 20F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel5.WordWrap = false;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MEMBERSHIP_NO")});
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(148.0303F, 102.3033F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel4.Text = "xrLabel4";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MEMNAME")});
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(427.573F, 73.30334F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(208.3333F, 23F);
            this.xrLabel1.Text = "xrLabel1";
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LOAN_INSTALLMENT_AMOUNT", "{0:#,#}")});
            this.xrLabel3.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(245.8939F, 992.8787F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(72.72733F, 22.99994F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "xrLabel21";
            this.xrLabel3.WordWrap = false;
            // 
            // xrLabel23
            // 
            this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.START_KEEP_DATE_THAI")});
            this.xrLabel23.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(314.1583F, 962.8787F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.Text = "xrLabel23";
            this.xrLabel23.WordWrap = false;
            // 
            // xrLabel24
            // 
            this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.BEGINING_OF_CONTRACT_DATE")});
            this.xrLabel24.Font = new System.Drawing.Font("Browallia New", 14F);
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(43.05552F, 127.3033F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(166.4648F, 23F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.Text = "xrLabel24";
            // 
            // xrLabel17
            // 
            this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LOAN_APPROVE_AMOUNT_THAI")});
            this.xrLabel17.Font = new System.Drawing.Font("Browallia New", 14F);
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(494.8687F, 127.3033F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(255.679F, 23.00002F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.Text = "xrLabel17";
            this.xrLabel17.WordWrap = false;
            // 
            // xrLabel18
            // 
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LOAN_APPROVE_AMOUNT", "{0:n2}")});
            this.xrLabel18.Font = new System.Drawing.Font("Browallia New", 14F);
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(287.4355F, 127.3033F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(146.1538F, 23F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.Text = "xrLabel18";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LOAN_CONTRACT_NO")});
            this.xrLabel2.Font = new System.Drawing.Font("Browallia New", 14F);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(663.0477F, 102.3033F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // r_nest_priod_advance
            // 
            this.r_nest_priod_advance.LocationFloat = new DevExpress.Utils.PointFloat(359.3203F, 228.5F);
            this.r_nest_priod_advance.Name = "r_nest_priod_advance";
            this.r_nest_priod_advance.SizeF = new System.Drawing.SizeF(155F, 721.8787F);
            this.r_nest_priod_advance.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.r_nest_priod_advance_BeforePrint);
            // 
            // xrLabel21
            // 
            this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LOAN_INSTALLMENT_AMOUNT", "{0:#,#}")});
            this.xrLabel21.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(676.0781F, 152.3034F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(71.96967F, 23F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.Text = "xrLabel21";
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 22F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 18F;
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
            // c_period_01
            // 
            this.c_period_01.DataMember = "Query";
            this.c_period_01.Expression = "Iif([LOAN_PAYMENT_TYPE_CODE] = \'01\', [PERIOD_PAYMENT_AMOUNT] , \'\')";
            this.c_period_01.Name = "c_period_01";
            // 
            // c_installment_01
            // 
            this.c_installment_01.DataMember = "Query";
            this.c_installment_01.Expression = "Iif([LOAN_PAYMENT_TYPE_CODE] = \'01\', [LOAN_INSTALLMENT_AMOUNT] , \'\')";
            this.c_installment_01.Name = "c_installment_01";
            // 
            // c_last_payment_01
            // 
            this.c_last_payment_01.DataMember = "Query";
            this.c_last_payment_01.Expression = "Iif([LOAN_PAYMENT_TYPE_CODE] = \'01\', [LAST_PAYMENT_AMOUNT] ,\'\' )";
            this.c_last_payment_01.Name = "c_last_payment_01";
            // 
            // c_period_02
            // 
            this.c_period_02.DataMember = "Query";
            this.c_period_02.Expression = "Iif([LOAN_PAYMENT_TYPE_CODE] = \'02\', [PERIOD_PAYMENT_AMOUNT] , \'\')";
            this.c_period_02.Name = "c_period_02";
            // 
            // c_installment_02
            // 
            this.c_installment_02.DataMember = "Query";
            this.c_installment_02.Expression = "Iif([LOAN_PAYMENT_TYPE_CODE] = \'02\', [LOAN_INSTALLMENT_AMOUNT] , \'\')";
            this.c_installment_02.Name = "c_installment_02";
            // 
            // r_tnma_period_advance_norm_สง
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.c_period_01,
            this.c_installment_01,
            this.c_last_payment_01,
            this.c_period_02,
            this.c_installment_02});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.Margins = new System.Drawing.Printing.Margins(25, 25, 22, 18);
            this.PageHeight = 1400;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.Legal;
            this.Version = "17.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRSubreport r_nest_priod_advance;
        private DevExpress.XtraReports.UI.CalculatedField c_period_01;
        private DevExpress.XtraReports.UI.CalculatedField c_installment_01;
        private DevExpress.XtraReports.UI.CalculatedField c_last_payment_01;
        private DevExpress.XtraReports.UI.CalculatedField c_period_02;
        private DevExpress.XtraReports.UI.CalculatedField c_installment_02;
        private DevExpress.XtraReports.UI.XRLabel xrLabel23;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        private DevExpress.XtraReports.UI.XRLabel xrLabel24;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
    }
}
