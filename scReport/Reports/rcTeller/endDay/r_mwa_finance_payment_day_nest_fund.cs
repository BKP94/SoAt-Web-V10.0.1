using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for r_finance_payment_fund
/// </summary>
namespace scReport.Reports.rcTeller.endDay
{
    public class r_mwa_finance_payment_day_nest_fund : DevExpress.XtraReports.UI.XtraReport
    {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private XRLabel xrLabel119;
        private XRLabel xrLabel118;
        private XRLabel xrLabel116;
        private XRLabel xrLabel117;
        private XRLabel xrLabel115;
        private ReportHeaderBand ReportHeader;
        private GroupFooterBand GroupFooter1;
        private GroupHeaderBand GroupHeader1;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public r_mwa_finance_payment_day_nest_fund()
        {
            InitializeComponent();
            //
            // TODO: Add constructor logic here
            //
        }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_mwa_finance_payment_day_nest_fund));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel119 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel118 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel116 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel117 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel115 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.Expanded = false;
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel119
            // 
            this.xrLabel119.CanGrow = false;
            this.xrLabel119.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_BALANCE_OF_LOAN")});
            this.xrLabel119.Dpi = 100F;
            this.xrLabel119.LocationFloat = new DevExpress.Utils.PointFloat(100F, 0F);
            this.xrLabel119.Name = "xrLabel119";
            this.xrLabel119.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel119.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel119.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:n2}";
            xrSummary1.IgnoreNullValues = true;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel119.Summary = xrSummary1;
            this.xrLabel119.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel118
            // 
            this.xrLabel118.CanGrow = false;
            this.xrLabel118.Dpi = 100F;
            this.xrLabel118.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel118.Name = "xrLabel118";
            this.xrLabel118.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel118.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel118.StylePriority.UseTextAlignment = false;
            this.xrLabel118.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel116
            // 
            this.xrLabel116.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel116.CanGrow = false;
            this.xrLabel116.Dpi = 100F;
            this.xrLabel116.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.xrLabel116.Name = "xrLabel116";
            this.xrLabel116.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel116.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel116.StylePriority.UseBorders = false;
            this.xrLabel116.StylePriority.UseTextAlignment = false;
            this.xrLabel116.Text = "ประเภท";
            this.xrLabel116.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel117
            // 
            this.xrLabel117.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel117.CanGrow = false;
            this.xrLabel117.Dpi = 100F;
            this.xrLabel117.Font = new System.Drawing.Font("BrowalliaUPC", 12F);
            this.xrLabel117.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel117.Name = "xrLabel117";
            this.xrLabel117.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel117.SizeF = new System.Drawing.SizeF(200F, 25F);
            this.xrLabel117.StylePriority.UseBorders = false;
            this.xrLabel117.StylePriority.UseFont = false;
            this.xrLabel117.StylePriority.UseTextAlignment = false;
            this.xrLabel117.Text = "ลูกหนี้กองทุนรับชำระ";
            this.xrLabel117.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel115
            // 
            this.xrLabel115.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel115.CanGrow = false;
            this.xrLabel115.Dpi = 100F;
            this.xrLabel115.LocationFloat = new DevExpress.Utils.PointFloat(100F, 25F);
            this.xrLabel115.Name = "xrLabel115";
            this.xrLabel115.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel115.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel115.StylePriority.UseBorders = false;
            this.xrLabel115.StylePriority.UseTextAlignment = false;
            this.xrLabel115.Text = "ต้นเงิน";
            this.xrLabel115.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel117,
            this.xrLabel116,
            this.xrLabel115});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 50F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel118,
            this.xrLabel119});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 25F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.Expanded = false;
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("LOAN_TYPE", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 100F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // r_finance_payment_fund
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.GroupFooter1,
            this.GroupHeader1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("BrowalliaUPC", 12F);
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion
    }
}
