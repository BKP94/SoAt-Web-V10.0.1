namespace scReport.Reports.rcTeller.admin
{
    partial class r_tnma_member_book_return_one_month_nest_1
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
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_tnma_member_book_return_one_month_nest_1));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.c_coop_address_1 = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_coop_address_2 = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_mem_name_book = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_mem_address_1 = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_mem_address_2 = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_ppm_unkep_pay = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
            this.Detail.HeightF = 26F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.CanGrow = false;
            this.xrLabel5.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(356.7361F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(43.26389F, 26F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "บาท";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel5.WordWrap = false;
            // 
            // xrLabel4
            // 
            this.xrLabel4.CanGrow = false;
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.AFTER_UNKEEP_AMOUNT", "{0:n2}")});
            this.xrLabel4.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(251.6667F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(105.0694F, 26F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel4.WordWrap = false;
            // 
            // xrLabel3
            // 
            this.xrLabel3.CanGrow = false;
            this.xrLabel3.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(188.6111F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(63.05557F, 26F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "จำนวน";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel3.WordWrap = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.CanGrow = false;
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PROC_DETAIL")});
            this.xrLabel2.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(27.97221F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(160.6389F, 26F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.WordWrap = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(27.97221F, 26F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:#,#}";
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel1.Summary = xrSummary1;
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabel1.WordWrap = false;
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
            // c_coop_address_1
            // 
            this.c_coop_address_1.DataMember = "Query";
            this.c_coop_address_1.Expression = "[COOP_ADDRESS] + \' หมู่ \' + [COOP_MUU] + \' ถ. \' + [COOP_ROAD] + \' ต. \' + [COOP_TU" +
    "MBOL_NAME]";
            this.c_coop_address_1.Name = "c_coop_address_1";
            // 
            // c_coop_address_2
            // 
            this.c_coop_address_2.DataMember = "Query";
            this.c_coop_address_2.Expression = "\'อ. \' + [COOP_DISTRICT_NAME] + \' จ. \' + [COOP_PROVINCE_NAME] + \' \' + [COOP_POSTCO" +
    "DE]";
            this.c_coop_address_2.Name = "c_coop_address_2";
            // 
            // c_mem_name_book
            // 
            this.c_mem_name_book.DataMember = "Query";
            this.c_mem_name_book.Expression = "[MEM_NAME] + \' ( \' + [MEMBERSHIP_NO] + \' - \' + [MEMBER_GROUP_NO] + \' ) \'";
            this.c_mem_name_book.Name = "c_mem_name_book";
            // 
            // c_mem_address_1
            // 
            this.c_mem_address_1.DataMember = "Query";
            this.c_mem_address_1.Expression = "[ADDRESS_PRES_ADDRESS_NO] +  [ADDRESS_PRES_MOO] +  [ADDRESS_PRES_ROAD]  + [ADDRES" +
    "S_PRES_TAMBOL]";
            this.c_mem_address_1.Name = "c_mem_address_1";
            // 
            // c_mem_address_2
            // 
            this.c_mem_address_2.DataMember = "Query";
            this.c_mem_address_2.Expression = "[ADDRESS_PRES_DISTRICT] + [ADDRESS_PRES_PROVINCE] + \' \' + [ADDRESS_PRES_POST]";
            this.c_mem_address_2.Name = "c_mem_address_2";
            // 
            // c_ppm_unkep_pay
            // 
            this.c_ppm_unkep_pay.DataMember = "Query";
            this.c_ppm_unkep_pay.Expression = "\'ประจำเดือน \' + [RECEIVE_MONTH] + \' \' + [RECEIVE_YEAR] +   \' ขาดส่งเป็นจำนวนเงินท" +
    "ั้งสิ้น \' + [KEP_PPM_AMOUNT] + \' บาท ตามรายละเอียดดังต่อไปนี้\'";
            this.c_ppm_unkep_pay.Name = "c_ppm_unkep_pay";
            // 
            // r_tnma_member_book_return_one_month_nest_1
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.c_coop_address_1,
            this.c_coop_address_2,
            this.c_mem_name_book,
            this.c_mem_address_1,
            this.c_mem_address_2,
            this.c_ppm_unkep_pay});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("AngsanaUPC", 14F);
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageHeight = 1169;
            this.PageWidth = 403;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.Custom;
            this.Version = "17.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.CalculatedField c_coop_address_1;
        private DevExpress.XtraReports.UI.CalculatedField c_coop_address_2;
        private DevExpress.XtraReports.UI.CalculatedField c_mem_name_book;
        private DevExpress.XtraReports.UI.CalculatedField c_mem_address_1;
        private DevExpress.XtraReports.UI.CalculatedField c_mem_address_2;
        private DevExpress.XtraReports.UI.CalculatedField c_ppm_unkep_pay;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
    }
}
