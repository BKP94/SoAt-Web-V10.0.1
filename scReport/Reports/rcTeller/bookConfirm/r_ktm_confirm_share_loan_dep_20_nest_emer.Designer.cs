namespace scReport.Reports.rcTeller.bookConfirm
{
    partial class r_ktm_confirm_share_loan_dep_20_nest_emer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_ktm_confirm_share_loan_dep_20_nest_emer));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel57 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel58 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.c_emer_balance = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_spec_balance = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_norm_balance = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel57,
            this.xrLabel58});
            this.Detail.Dpi = 100F;
            this.Detail.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseFont = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel57
            // 
            this.xrLabel57.CanGrow = false;
            this.xrLabel57.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.EMER_CONTRACT")});
            this.xrLabel57.Dpi = 100F;
            this.xrLabel57.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel57.Name = "xrLabel57";
            this.xrLabel57.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel57.SizeF = new System.Drawing.SizeF(95.95964F, 23F);
            this.xrLabel57.StylePriority.UseTextAlignment = false;
            this.xrLabel57.Text = "xrLabel1";
            this.xrLabel57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel58
            // 
            this.xrLabel58.CanGrow = false;
            this.xrLabel58.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_emer_balance", "{0:n2}")});
            this.xrLabel58.Dpi = 100F;
            this.xrLabel58.LocationFloat = new DevExpress.Utils.PointFloat(98.32185F, 0F);
            this.xrLabel58.Name = "xrLabel58";
            this.xrLabel58.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel58.SizeF = new System.Drawing.SizeF(89.66042F, 23F);
            this.xrLabel58.StylePriority.UseTextAlignment = false;
            this.xrLabel58.Text = "xrLabel2";
            this.xrLabel58.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            customSqlQuery1.Sql = "select\tsc_cls_confirm_data.data_refno as emer_contract ,\r\n        sc_cls_confirm_" +
    "data.data_balance as emer_balance\r\n         from\tsc_cls_confirm_data ,\r\n        " +
    " sc_lon_m_rule\r\n         where 1 = 2";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // c_emer_balance
            // 
            this.c_emer_balance.DataMember = "Query";
            this.c_emer_balance.Expression = "Iif( [EMER_BALANCE] = \'0\', \'\' ,[EMER_BALANCE] )";
            this.c_emer_balance.Name = "c_emer_balance";
            // 
            // c_spec_balance
            // 
            this.c_spec_balance.DataMember = "Query";
            this.c_spec_balance.Expression = "Iif( [SPEC_BALANCE] = \'0\', \'\' , [SPEC_BALANCE] )";
            this.c_spec_balance.Name = "c_spec_balance";
            // 
            // c_norm_balance
            // 
            this.c_norm_balance.DataMember = "Query";
            this.c_norm_balance.Expression = "Iif( [NORM_BALANCE] = \'0\', \'\' , [NORM_BALANCE] )";
            this.c_norm_balance.Name = "c_norm_balance";
            // 
            // r_ktm_confirm_share_loan_dep_nest_emer
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.c_emer_balance,
            this.c_norm_balance,
            this.c_spec_balance});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Margins = new System.Drawing.Printing.Margins(0, 634, 0, 0);
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
        private DevExpress.XtraReports.UI.CalculatedField c_emer_balance;
        private DevExpress.XtraReports.UI.CalculatedField c_spec_balance;
        private DevExpress.XtraReports.UI.XRLabel xrLabel57;
        private DevExpress.XtraReports.UI.XRLabel xrLabel58;
        private DevExpress.XtraReports.UI.CalculatedField c_norm_balance;
    }
}
