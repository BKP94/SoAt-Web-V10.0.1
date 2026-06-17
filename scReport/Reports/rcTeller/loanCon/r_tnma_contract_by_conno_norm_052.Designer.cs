namespace scReport.Reports.rcTeller.loanCon
{
    partial class r_tnma_contract_by_conno_norm_052
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_tnma_contract_by_conno_norm_052));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.r_nest_coll_oth = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.r_nest_coll_list_next = new DevExpress.XtraReports.UI.XRSubreport();
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
            this.r_nest_coll_oth,
            this.xrLabel24,
            this.xrLabel1,
            this.xrLabel4,
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLabel9,
            this.xrLabel10,
            this.xrLabel11,
            this.xrLabel12,
            this.xrLabel13,
            this.xrLabel14,
            this.xrLabel25,
            this.xrLabel23,
            this.xrLabel21,
            this.xrLabel20,
            this.xrLabel19,
            this.xrLabel17,
            this.xrLabel18,
            this.xrLabel16,
            this.xrLabel15,
            this.xrLabel3,
            this.xrLabel2,
            this.r_nest_coll_list_next});
            this.Detail.Font = new System.Drawing.Font("Browallia New", 12F);
            this.Detail.HeightF = 1200F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseFont = false;
            this.Detail.StylePriority.UseTextAlignment = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // r_nest_coll_oth
            // 
            this.r_nest_coll_oth.LocationFloat = new DevExpress.Utils.PointFloat(328.18F, 17.29999F);
            this.r_nest_coll_oth.Name = "r_nest_coll_oth";
            this.r_nest_coll_oth.SizeF = new System.Drawing.SizeF(461F, 32F);
            this.r_nest_coll_oth.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.r_nest_coll_oth_BeforePrint);
            // 
            // xrLabel24
            // 
            this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.BEGINING_OF_CONTRACT_DATE")});
            this.xrLabel24.Font = new System.Drawing.Font("BrowalliaUPC", 13F);
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(514.71F, 199.62F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.NullValueText = "null";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(166.4648F, 22.99998F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.Text = "xrLabel24";
            this.xrLabel24.WordWrap = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MEMNAME")});
            this.xrLabel1.Font = new System.Drawing.Font("BrowalliaUPC", 13F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(66.06F, 220.62F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.NullValueText = "null";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(288.8887F, 22.99998F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel1.WordWrap = false;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MEMBERSHIP_NO")});
            this.xrLabel4.Font = new System.Drawing.Font("BrowalliaUPC", 13F);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(482.68F, 220.62F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.NullValueText = "null";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(99.99994F, 23.00003F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "xrLabel3";
            this.xrLabel4.WordWrap = false;
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.POSITION")});
            this.xrLabel5.Font = new System.Drawing.Font("BrowalliaUPC", 13F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(33F, 243.62F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.NullValueText = "null";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(170.9401F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.WordWrap = false;
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MEMBER_GROUP_NAME")});
            this.xrLabel6.Font = new System.Drawing.Font("BrowalliaUPC", 13F);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(319.31F, 243.62F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.NullValueText = "null";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(233.3759F, 23F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.WordWrap = false;
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.GROUP_DISTRICT")});
            this.xrLabel7.Font = new System.Drawing.Font("BrowalliaUPC", 13F);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(20.15F, 266.62F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.NullValueText = "null";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(171.7948F, 22.99997F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "xrLabel7";
            this.xrLabel7.WordWrap = false;
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PROVINCE_ADDR")});
            this.xrLabel8.Font = new System.Drawing.Font("BrowalliaUPC", 13F);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(191.9448F, 266.62F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.NullValueText = "null";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(127.3652F, 22.99997F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "xrLabel8";
            this.xrLabel8.WordWrap = false;
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ADDRESS_NO")});
            this.xrLabel9.Font = new System.Drawing.Font("BrowalliaUPC", 13F);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(437.78F, 266.62F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.NullValueText = "null";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(52.99149F, 23.00003F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.Text = "xrLabel9";
            this.xrLabel9.WordWrap = false;
            // 
            // xrLabel10
            // 
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MOO")});
            this.xrLabel10.Font = new System.Drawing.Font("BrowalliaUPC", 13F);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(504.79F, 266.62F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.NullValueText = "null";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(59F, 23F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.Text = "xrLabel10";
            this.xrLabel10.WordWrap = false;
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ROAD")});
            this.xrLabel11.Font = new System.Drawing.Font("BrowalliaUPC", 13F);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(598F, 266.62F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.NullValueText = "null";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(156.1972F, 23.00003F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.Text = "xrLabel11";
            this.xrLabel11.WordWrap = false;
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.TAMBOL")});
            this.xrLabel12.Font = new System.Drawing.Font("BrowalliaUPC", 13F);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(66.06F, 289.62F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.NullValueText = "null";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(146.1537F, 23F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.Text = "xrLabel12";
            this.xrLabel12.WordWrap = false;
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.DISTRICT")});
            this.xrLabel13.Font = new System.Drawing.Font("BrowalliaUPC", 13F);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(289.84F, 289.62F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.NullValueText = "null";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(194.4654F, 23F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.Text = "xrLabel13";
            this.xrLabel13.WordWrap = false;
            // 
            // xrLabel14
            // 
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PROVINCE")});
            this.xrLabel14.Font = new System.Drawing.Font("BrowalliaUPC", 13F);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(552.09F, 289.62F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.NullValueText = "null";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(179.0886F, 23.00003F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.Text = "xrLabel14";
            this.xrLabel14.WordWrap = false;
            // 
            // xrLabel25
            // 
            this.xrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.START_KEEP_DATE_THAI_YEAR")});
            this.xrLabel25.Font = new System.Drawing.Font("BrowalliaUPC", 12F);
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(392.1537F, 507.833F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.NullValueText = "null";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.Text = "xrLabel25";
            this.xrLabel25.WordWrap = false;
            // 
            // xrLabel23
            // 
            this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.START_KEEP_DATE_THAI")});
            this.xrLabel23.Font = new System.Drawing.Font("BrowalliaUPC", 12F);
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(292.1537F, 507.833F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.NullValueText = "null";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.Text = "xrLabel23";
            this.xrLabel23.WordWrap = false;
            // 
            // xrLabel21
            // 
            this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LOAN_INSTALLMENT_AMOUNT", "{0:#,#}")});
            this.xrLabel21.Font = new System.Drawing.Font("BrowalliaUPC", 12F);
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(33F, 507.8331F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.NullValueText = "null";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.Text = "xrLabel21";
            this.xrLabel21.WordWrap = false;
            // 
            // xrLabel20
            // 
            this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PERIOD_PAYMENT_AMOUNT", "{0:n2}")});
            this.xrLabel20.Font = new System.Drawing.Font("BrowalliaUPC", 12F);
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(651.3638F, 484.8332F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.NullValueText = "null";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(80.83337F, 22.99997F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.Text = "xrLabel20";
            this.xrLabel20.WordWrap = false;
            // 
            // xrLabel19
            // 
            this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INT_RATE")});
            this.xrLabel19.Font = new System.Drawing.Font("BrowalliaUPC", 13F);
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(383.06F, 410.62F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.NullValueText = "null";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(89.74358F, 22.99997F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.Text = "xrLabel19";
            this.xrLabel19.WordWrap = false;
            // 
            // xrLabel17
            // 
            this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LOAN_APPROVE_AMOUNT_THAI")});
            this.xrLabel17.Font = new System.Drawing.Font("BrowalliaUPC", 13F);
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(444.33F, 361.62F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.NullValueText = "null";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(274.47F, 23F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.Text = "xrLabel17";
            this.xrLabel17.WordWrap = false;
            // 
            // xrLabel18
            // 
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LOAN_APPROVE_AMOUNT", "{0:n2}")});
            this.xrLabel18.Font = new System.Drawing.Font("BrowalliaUPC", 13F);
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(298.18F, 361.62F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.NullValueText = "null";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(146.1538F, 23F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.Text = "xrLabel18";
            this.xrLabel18.WordWrap = false;
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.TELEPHONE")});
            this.xrLabel16.Font = new System.Drawing.Font("BrowalliaUPC", 13F);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(204.79F, 312.62F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.NullValueText = "null";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(146.1536F, 23F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.Text = "xrLabel16";
            this.xrLabel16.WordWrap = false;
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.POSTCODE")});
            this.xrLabel15.Font = new System.Drawing.Font("BrowalliaUPC", 13F);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(66.06F, 312.62F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.NullValueText = "null";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.Text = "xrLabel15";
            this.xrLabel15.WordWrap = false;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MEMBERSHIP_NO")});
            this.xrLabel3.Font = new System.Drawing.Font("BrowalliaUPC", 13F);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(640.18F, 177.97F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.NullValueText = "null";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "xrLabel3";
            this.xrLabel3.WordWrap = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.LOAN_CONTRACT_NO")});
            this.xrLabel2.Font = new System.Drawing.Font("BrowalliaUPC", 13F);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(462.46F, 177.97F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.NullValueText = "null";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel2.WordWrap = false;
            // 
            // r_nest_coll_list_next
            // 
            this.r_nest_coll_list_next.LocationFloat = new DevExpress.Utils.PointFloat(328.18F, 36.3F);
            this.r_nest_coll_list_next.Name = "r_nest_coll_list_next";
            this.r_nest_coll_list_next.SizeF = new System.Drawing.SizeF(420F, 108F);
            this.r_nest_coll_list_next.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.r_nest_coll_list_next_BeforePrint);
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
            // r_tnma_contract_by_conno_norm_052
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
            this.Margins = new System.Drawing.Printing.Margins(25, 18, 0, 18);
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
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        private DevExpress.XtraReports.UI.XRSubreport r_nest_coll_list_next;
        private DevExpress.XtraReports.UI.CalculatedField c_period_01;
        private DevExpress.XtraReports.UI.CalculatedField c_installment_01;
        private DevExpress.XtraReports.UI.CalculatedField c_last_payment_01;
        private DevExpress.XtraReports.UI.CalculatedField c_period_02;
        private DevExpress.XtraReports.UI.CalculatedField c_installment_02;
        private DevExpress.XtraReports.UI.XRLabel xrLabel25;
        private DevExpress.XtraReports.UI.XRLabel xrLabel23;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel24;
        private DevExpress.XtraReports.UI.XRSubreport r_nest_coll_oth;
    }
}
