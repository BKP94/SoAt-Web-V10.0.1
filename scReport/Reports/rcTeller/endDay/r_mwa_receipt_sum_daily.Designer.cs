namespace scReport.Reports.rcTeller.endDay
{
    partial class r_mwa_receipt_sum_daily
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_mwa_receipt_sum_daily));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.adding_loan = new DevExpress.XtraReports.UI.XRSubreport();
            this.payment_loan = new DevExpress.XtraReports.UI.XRSubreport();
            this.shrfee = new DevExpress.XtraReports.UI.XRSubreport();
            this.receive_loan = new DevExpress.XtraReports.UI.XRSubreport();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.t_header_2 = new DevExpress.XtraReports.UI.XRLabel();
            this.t_header_3 = new DevExpress.XtraReports.UI.XRLabel();
            this.t_header_publish_date = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.t_header_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.adding_loan,
            this.payment_loan,
            this.shrfee,
            this.receive_loan});
            this.Detail.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.Detail.HeightF = 156.9444F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseFont = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // adding_loan
            // 
            this.adding_loan.LocationFloat = new DevExpress.Utils.PointFloat(0F, 125.6944F);
            this.adding_loan.Name = "adding_loan";
            this.adding_loan.SizeF = new System.Drawing.SizeF(1129F, 31.25F);
            this.adding_loan.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.adding_loan_BeforePrint);
            // 
            // payment_loan
            // 
            this.payment_loan.LocationFloat = new DevExpress.Utils.PointFloat(0F, 84.5F);
            this.payment_loan.Name = "payment_loan";
            this.payment_loan.SizeF = new System.Drawing.SizeF(1129F, 31.24998F);
            this.payment_loan.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.payment_loan_BeforePrint);
            // 
            // shrfee
            // 
            this.shrfee.LocationFloat = new DevExpress.Utils.PointFloat(0.0001412851F, 0F);
            this.shrfee.Name = "shrfee";
            this.shrfee.SizeF = new System.Drawing.SizeF(1129F, 31.25F);
            this.shrfee.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.shrfee_BeforePrint);
            // 
            // receive_loan
            // 
            this.receive_loan.LocationFloat = new DevExpress.Utils.PointFloat(0F, 41.24998F);
            this.receive_loan.Name = "receive_loan";
            this.receive_loan.SizeF = new System.Drawing.SizeF(1129F, 31.24999F);
            this.receive_loan.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.receive_loan_BeforePrint);
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
            this.BottomMargin.HeightF = 50F;
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
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel1,
            this.t_header_2,
            this.t_header_3,
            this.t_header_publish_date,
            this.xrPageInfo3,
            this.t_header_1});
            this.PageHeader.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.PageHeader.HeightF = 148.4028F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.StylePriority.UseFont = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("BrowalliaUPC", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 118.4028F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(46.28F, 30F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "วันที่ :";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.RECEIPT_TDATE")});
            this.xrLabel1.Font = new System.Drawing.Font("BrowalliaUPC", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(46.28F, 118.4028F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(402.3311F, 30F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "xrLabel7";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // t_header_2
            // 
            this.t_header_2.Font = new System.Drawing.Font("BrowalliaUPC", 16F, System.Drawing.FontStyle.Bold);
            this.t_header_2.LocationFloat = new DevExpress.Utils.PointFloat(0.0001412851F, 52.42682F);
            this.t_header_2.Name = "t_header_2";
            this.t_header_2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t_header_2.SizeF = new System.Drawing.SizeF(1129F, 29.16666F);
            this.t_header_2.StylePriority.UseFont = false;
            this.t_header_2.StylePriority.UseTextAlignment = false;
            this.t_header_2.Text = "t_header_2 <si_rep_reps.rep_text>";
            this.t_header_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // t_header_3
            // 
            this.t_header_3.Font = new System.Drawing.Font("BrowalliaUPC", 16F, System.Drawing.FontStyle.Bold);
            this.t_header_3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 81.59348F);
            this.t_header_3.Name = "t_header_3";
            this.t_header_3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t_header_3.SizeF = new System.Drawing.SizeF(1129F, 27.08333F);
            this.t_header_3.StylePriority.UseFont = false;
            this.t_header_3.StylePriority.UseTextAlignment = false;
            this.t_header_3.Text = "t_header_3";
            this.t_header_3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // t_header_publish_date
            // 
            this.t_header_publish_date.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.t_header_publish_date.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.t_header_publish_date.Name = "t_header_publish_date";
            this.t_header_publish_date.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t_header_publish_date.SizeF = new System.Drawing.SizeF(448.6111F, 28.89614F);
            this.t_header_publish_date.StylePriority.UseFont = false;
            this.t_header_publish_date.StylePriority.UseTextAlignment = false;
            this.t_header_publish_date.Text = "t_header_reportid<รหัสรายงาน>";
            this.t_header_publish_date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo3
            // 
            this.xrPageInfo3.Font = new System.Drawing.Font("BrowalliaUPC", 12F, System.Drawing.FontStyle.Bold);
            this.xrPageInfo3.Format = "หน้า {0}/ {1}";
            this.xrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(824.313F, 0F);
            this.xrPageInfo3.Name = "xrPageInfo3";
            this.xrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo3.SizeF = new System.Drawing.SizeF(304.687F, 28.89614F);
            this.xrPageInfo3.StylePriority.UseFont = false;
            this.xrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // t_header_1
            // 
            this.t_header_1.Font = new System.Drawing.Font("BrowalliaUPC", 16F, System.Drawing.FontStyle.Bold);
            this.t_header_1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 28.89616F);
            this.t_header_1.Name = "t_header_1";
            this.t_header_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t_header_1.SizeF = new System.Drawing.SizeF(1129F, 23.53067F);
            this.t_header_1.StylePriority.UseFont = false;
            this.t_header_1.StylePriority.UseTextAlignment = false;
            this.t_header_1.Text = "t_header_1 <sc_cnt_m_coop.coop_name>";
            this.t_header_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Expanded = false;
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("C_RECEIPTDATE", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 14.82372F;
            this.GroupHeader1.KeepTogether = true;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Expanded = false;
            this.GroupFooter1.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.GroupFooter1.HeightF = 15.625F;
            this.GroupFooter1.KeepTogether = true;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.StylePriority.UseFont = false;
            // 
            // r_mwa_receipt_sum_daily
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.GroupHeader1,
            this.GroupFooter1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("BrowalliaUPC", 16F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(30, 0, 22, 50);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.Version = "17.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel t_header_2;
        private DevExpress.XtraReports.UI.XRLabel t_header_3;
        private DevExpress.XtraReports.UI.XRLabel t_header_publish_date;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo3;
        private DevExpress.XtraReports.UI.XRLabel t_header_1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRSubreport shrfee;
        private DevExpress.XtraReports.UI.XRSubreport receive_loan;
        private DevExpress.XtraReports.UI.XRSubreport payment_loan;
        private DevExpress.XtraReports.UI.XRSubreport adding_loan;
    }
}
