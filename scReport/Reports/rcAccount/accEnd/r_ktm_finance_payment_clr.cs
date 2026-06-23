using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for r_finance_payment
/// </summary>
namespace scReport.Reports.rcAccount.accEnd
{
    public class r_ktm_finance_payment_clr : DevExpress.XtraReports.UI.XtraReport
    {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private PageHeaderBand PageHeader;
        private PageFooterBand PageFooter;
        private GroupFooterBand GroupFooter1;
        private GroupFooterBand GroupFooter2;
        private CalculatedField sum;
        private CalculatedField sum_int;
        private ReportFooterBand ReportFooter;
        private CalculatedField sum_principal_amount;
        private CalculatedField sum_interest;
        private CalculatedField c_conno1_close;
        private CalculatedField c_conno1_still;
        private CalculatedField c_emer_balance_close;
        private CalculatedField c_emer_balance_still;
        private CalculatedField c_emer_int_close;
        private CalculatedField c_conno2_close;
        private CalculatedField c_conno2_still;
        private CalculatedField c_norm_balance_close;
        private CalculatedField c_norm_balance_still;
        private CalculatedField c_norm_int_close;
        private CalculatedField c_norm_int_still;
        private CalculatedField c_conno3_close;
        private CalculatedField c_conno3_still;
        private CalculatedField c_spec_balance_close;
        private CalculatedField c_spec_balance_still;
        private CalculatedField c_spec_int_close;
        private CalculatedField c_spec_int_still;
        private CalculatedField c_other_payments;
        private CalculatedField total;
        private CalculatedField calculatedField1;
        private CalculatedField c_emer_int_still;
        private GroupHeaderBand GroupHeader1;
        private FormattingRule formattingRule2;
        private FormattingRule formattingRule3;
        private FormattingRule formattingRule4;
        private CalculatedField C_p_1_in;
        private CalculatedField C_p_2_in;
        private CalculatedField C_p_3_in;
        private CalculatedField C_p_1_out;
        private CalculatedField C_p_2_out;
        private CalculatedField C_p_3_out;
        private CalculatedField C_i_1_in;
        private CalculatedField C_i_2_in;
        private CalculatedField C_i_3_in;
        private CalculatedField C_i_1_out;
        private CalculatedField C_i_2_out;
        private CalculatedField C_i_3_out;
        private CalculatedField c_fee_new;
        private GroupHeaderBand GroupHeader2;
        private XRLabel xrLabel7;
        private XRLabel xrLabel25;
        private XRLabel xrLabel24;
        private XRLabel xrLabel6;
        private XRLabel xrLabel5;
        private XRLabel xrLabel3;
        private XRLabel xrLabel2;
        private XRLabel xrLabel1;
        private XRLabel xrLabel12;
        private XRLabel xrLabel11;
        private XRLabel xrLabel10;
        private XRLabel xrLabel9;
        private XRLabel xrLabel17;
        private XRLabel xrLabel19;
        private XRLabel xrLabel26;
        private XRLabel xrLabel4;
        private XRLabel t_header_publish_date;
        private XRLabel t_header_1;
        private XRLabel t_header_2;
        private XRLabel t_header_3;
        private XRPageInfo xrPageInfo3;
        private XRLabel xrLabel16;
        private XRLabel xrLabel20;
        private XRLabel xrLabel18;
        private XRLabel xrLabel21;
        private XRLabel xrLabel23;
        private XRLabel xrLabel22;
        private XRLabel xrLabel64;
        private XRLabel xrLabel8;
        private XRLabel xrLabel66;
        private XRSubreport d01;
        private XRLabel xrLabel15;
        private XRLabel xrLabel141;
        private XRSubreport d03;
        private XRSubreport d02;
        private XRLabel xrLabel14;
        private XRLabel xrLabel27;
        private XRLabel xrLabel29;
        private XRLabel xrLabel30;
        private XRLabel xrLabel31;
        private XRLabel xrLabel41;
        private XRLabel xrLabel42;
        private XRLabel xrLabel28;
        private XRLabel xrLabel65;
        private XRLabel xrLabel179;
        private XRLabel xrLabel195;
        private XRLabel xrLabel194;
        private XRLabel xrLabel193;
        private XRLabel xrLabel192;
        private XRLabel xrLabel191;
        private XRLabel xrLabel190;
        private XRLabel xrLabel189;
        private XRLabel xrLabel188;
        private XRLabel xrLabel187;
        private XRLabel xrLabel186;
        private XRLabel xrLabel185;
        private XRLabel xrLabel184;
        private XRLabel xrLabel183;
        private XRLabel xrLabel182;
        private XRLabel xrLabel181;
        private XRLabel xrLabel180;
        private XRLabel xrLabel79;
        private XRLabel xrLabel58;
        private XRLabel xrLabel57;
        private XRLabel xrLabel56;
        private XRLabel xrLabel55;
        private XRLabel xrLabel48;
        private XRLabel xrLabel51;
        private XRLabel xrLabel54;
        private XRLabel xrLabel52;
        private XRLabel xrLabel53;
        private XRLabel xrLabel49;
        private XRLabel xrLabel50;
        private XRLabel xrLabel47;
        private XRLabel xrLabel46;
        private XRLabel xrLabel45;
        private XRLabel xrLabel44;
        private XRLabel xrLabel146;
        private XRLabel xrLabel95;
        private XRLabel xrLabel94;
        private XRLabel xrLabel93;
        private XRLabel xrLabel92;
        private XRLabel xrLabel91;
        private XRLabel xrLabel90;
        private XRLabel xrLabel89;
        private XRLabel xrLabel88;
        private XRLabel xrLabel87;
        private XRLabel xrLabel86;
        private XRLabel xrLabel85;
        private XRLabel xrLabel84;
        private XRLabel xrLabel83;
        private XRLabel xrLabel82;
        private XRLabel xrLabel81;
        private XRLabel xrLabel80;
        private XRLabel xrLabel147;
        private XRLabel xrLabel59;
        private XRLabel xrLabel60;
        private XRLabel xrLabel61;
        private XRLabel xrLabel62;
        private XRLabel xrLabel63;
        private XRLabel xrLabel13;
        private XRLabel xrLabel33;
        private XRLabel xrLabel34;
        private XRLabel xrLabel67;
        private XRLabel xrLabel68;
        private XRLabel xrLabel69;
        private XRLabel xrLabel70;
        private XRLabel xrLabel71;
        private XRLabel xrLabel72;
        private XRLabel xrLabel73;
        private XRLabel xrLabel74;
        private XRLabel xrLabel75;
        private XRLabel xrLabel76;
        private XRLabel xrLabel77;
        private XRLabel xrLabel78;
        private XRLabel xrLabel96;
        private XRLabel xrLabel97;
        private XRSubreport nest_emer_sum;
        private XRSubreport nest_norm_sum;
        private XRSubreport nest_spec_sum;
        private XRSubreport loan_code;
        private XRLabel xrLabel37;
        private XRLabel xrLabel38;
        private XRLabel xrLabel140;
        private XRLabel xrLabel153;
        private XRLabel xrLabel152;
        private XRLabel xrLabel151;
        private XRLabel xrLabel150;
        private XRLabel xrLabel149;
        private XRLabel xrLabel177;
        private XRLabel xrLabel178;
        private XRLabel xrLabel134;
        private XRLabel xrLabel40;
        private XRLabel xrLabel39;
        private XRLabel xrLabel36;
        private XRLabel xrLabel137;
        private XRLabel xrLabel136;
        private XRLabel xrLabel135;
        private XRLabel xrLabel43;
        private XRLabel xrLabel142;
        private XRLabel xrLabel139;
        private XRLabel xrLabel138;
        private XRLabel xrLabel35;
        private XRPageInfo xrPageInfo1;
        private XRLabel xrLabel98;
        private XRLabel xrLabel99;
        private XRLabel xrLabel100;
        private XRLabel xrLabel101;
        private XRLabel xrLabel113;
        private XRLabel xrLabel32;
        private XRLabel xrLabel112;
        private XRLabel xrLabel111;
        private XRLabel xrLabel110;
        private XRLabel xrLabel109;
        private XRLabel xrLabel108;
        private XRLabel xrLabel107;
        private XRLabel xrLabel106;
        private XRLabel xrLabel105;
        private XRLabel xrLabel104;
        private XRLabel xrLabel103;
        private XRLabel xrLabel102;
        private XRLabel xrLabel148;
        private XRLabel t_soat;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public r_ktm_finance_payment_clr()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_ktm_finance_payment_clr));
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary10 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary11 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary12 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary13 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary14 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary15 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary16 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary17 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary18 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary19 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary20 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary21 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary22 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary23 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary24 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary25 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary26 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary27 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary28 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary29 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary30 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary31 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary32 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary33 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary34 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary35 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary36 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary37 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary38 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary39 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary40 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary41 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary42 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary43 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary44 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary45 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary46 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary47 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary48 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary49 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary50 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary51 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary52 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary53 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary54 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary55 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary56 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary57 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary58 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary59 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary60 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary61 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary62 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary63 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary64 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary65 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary66 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary67 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary68 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary69 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary70 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary71 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary72 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary73 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.d01 = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel141 = new DevExpress.XtraReports.UI.XRLabel();
            this.d03 = new DevExpress.XtraReports.UI.XRSubreport();
            this.d02 = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel65 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.t_header_publish_date = new DevExpress.XtraReports.UI.XRLabel();
            this.t_header_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.t_header_2 = new DevExpress.XtraReports.UI.XRLabel();
            this.t_header_3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel64 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel98 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel99 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel100 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel101 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel113 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel112 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel111 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel110 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel109 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel108 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel107 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel106 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel105 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel104 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel103 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel102 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel148 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel179 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel195 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel194 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel193 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel192 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel191 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel190 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel189 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel188 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel187 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel186 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel185 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel184 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel183 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel182 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel181 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel180 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel79 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel58 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel57 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel56 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel55 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel48 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel51 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel54 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel53 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel49 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel50 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel146 = new DevExpress.XtraReports.UI.XRLabel();
            this.sum = new DevExpress.XtraReports.UI.CalculatedField();
            this.sum_int = new DevExpress.XtraReports.UI.CalculatedField();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel59 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel60 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel61 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel62 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel63 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel67 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel68 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel69 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel70 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel71 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel72 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel73 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel74 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel75 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel76 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel77 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel78 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel96 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel97 = new DevExpress.XtraReports.UI.XRLabel();
            this.nest_emer_sum = new DevExpress.XtraReports.UI.XRSubreport();
            this.nest_norm_sum = new DevExpress.XtraReports.UI.XRSubreport();
            this.nest_spec_sum = new DevExpress.XtraReports.UI.XRSubreport();
            this.loan_code = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel140 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel153 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel152 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel151 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel150 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel149 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel177 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel178 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel134 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel137 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel136 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel135 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel142 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel139 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel138 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel95 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel94 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel93 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel92 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel91 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel90 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel89 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel88 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel87 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel86 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel85 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel84 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel83 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel82 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel81 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel80 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel147 = new DevExpress.XtraReports.UI.XRLabel();
            this.formattingRule4 = new DevExpress.XtraReports.UI.FormattingRule();
            this.formattingRule2 = new DevExpress.XtraReports.UI.FormattingRule();
            this.formattingRule3 = new DevExpress.XtraReports.UI.FormattingRule();
            this.sum_principal_amount = new DevExpress.XtraReports.UI.CalculatedField();
            this.sum_interest = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_conno1_close = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_conno1_still = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_emer_balance_close = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_emer_balance_still = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_emer_int_close = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_conno2_close = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_conno2_still = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_norm_balance_close = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_norm_balance_still = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_norm_int_close = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_norm_int_still = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_conno3_close = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_conno3_still = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_spec_balance_close = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_spec_balance_still = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_spec_int_close = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_spec_int_still = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_other_payments = new DevExpress.XtraReports.UI.CalculatedField();
            this.total = new DevExpress.XtraReports.UI.CalculatedField();
            this.calculatedField1 = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_emer_int_still = new DevExpress.XtraReports.UI.CalculatedField();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_p_1_in = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_p_2_in = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_p_3_in = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_p_1_out = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_p_2_out = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_p_3_out = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_i_1_in = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_i_2_in = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_i_3_in = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_i_1_out = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_i_2_out = new DevExpress.XtraReports.UI.CalculatedField();
            this.C_i_3_out = new DevExpress.XtraReports.UI.CalculatedField();
            this.c_fee_new = new DevExpress.XtraReports.UI.CalculatedField();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel66 = new DevExpress.XtraReports.UI.XRLabel();
            this.t_soat = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.d01,
            this.xrLabel15,
            this.xrLabel141,
            this.d03,
            this.d02,
            this.xrLabel14,
            this.xrLabel27,
            this.xrLabel29,
            this.xrLabel30,
            this.xrLabel31,
            this.xrLabel41,
            this.xrLabel42,
            this.xrLabel28,
            this.xrLabel65});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 25F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // d01
            // 
            this.d01.Dpi = 100F;
            this.d01.LocationFloat = new DevExpress.Utils.PointFloat(662.5F, 0F);
            this.d01.Name = "d01";
            this.d01.SizeF = new System.Drawing.SizeF(262.5F, 25F);
            this.d01.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.d01_BeforePrint);
            // 
            // xrLabel15
            // 
            this.xrLabel15.CanGrow = false;
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.RECEIPT_NO")});
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(25F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel141
            // 
            this.xrLabel141.CanGrow = false;
            this.xrLabel141.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.S_ITEM_AMOUNT", "{0:n2}")});
            this.xrLabel141.Dpi = 100F;
            this.xrLabel141.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel141.LocationFloat = new DevExpress.Utils.PointFloat(1450F, 0F);
            this.xrLabel141.Name = "xrLabel141";
            this.xrLabel141.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel141.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel141.StylePriority.UseFont = false;
            this.xrLabel141.StylePriority.UseTextAlignment = false;
            this.xrLabel141.Text = "xrLabel141";
            this.xrLabel141.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // d03
            // 
            this.d03.Dpi = 100F;
            this.d03.LocationFloat = new DevExpress.Utils.PointFloat(1187.5F, 0F);
            this.d03.Name = "d03";
            this.d03.SizeF = new System.Drawing.SizeF(262.5F, 25F);
            this.d03.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.d03_BeforePrint);
            // 
            // d02
            // 
            this.d02.Dpi = 100F;
            this.d02.LocationFloat = new DevExpress.Utils.PointFloat(925F, 0F);
            this.d02.Name = "d02";
            this.d02.SizeF = new System.Drawing.SizeF(262.5F, 25F);
            this.d02.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.d02_BeforePrint);
            // 
            // xrLabel14
            // 
            this.xrLabel14.CanGrow = false;
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(25F, 25F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0}.";
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            xrSummary1.IgnoreNullValues = true;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel14.Summary = xrSummary1;
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel27
            // 
            this.xrLabel27.CanGrow = false;
            this.xrLabel27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MEMBER_NAME")});
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("AngsanaUPC", 13F);
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(175F, 0F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(162.5F, 25F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel29
            // 
            this.xrLabel29.CanGrow = false;
            this.xrLabel29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FUND_NEW", "{0:#,##0.00;,#,##0.00;\'\'}")});
            this.xrLabel29.Dpi = 100F;
            this.xrLabel29.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(337.5F, 0F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            this.xrLabel29.Text = "xrLabel29";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel30
            // 
            this.xrLabel30.CanGrow = false;
            this.xrLabel30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.BY_SHARE", "{0:#,##0.00;,#,##0.00;\'\'}")});
            this.xrLabel30.Dpi = 100F;
            this.xrLabel30.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(437.5F, 0F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            this.xrLabel30.Text = "xrLabel30";
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel31
            // 
            this.xrLabel31.CanGrow = false;
            this.xrLabel31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FREE_AMOUNT", "{0:#,##0.00;,#,##0.00;\'-\'}")});
            this.xrLabel31.Dpi = 100F;
            this.xrLabel31.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(525F, 0F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.StylePriority.UseTextAlignment = false;
            this.xrLabel31.Text = "xrLabel31";
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel41
            // 
            this.xrLabel41.CanGrow = false;
            this.xrLabel41.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ENTRY_ID")});
            this.xrLabel41.Dpi = 100F;
            this.xrLabel41.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(1662.5F, 0F);
            this.xrLabel41.Name = "xrLabel41";
            this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel41.SizeF = new System.Drawing.SizeF(62.5F, 25F);
            this.xrLabel41.StylePriority.UseFont = false;
            this.xrLabel41.StylePriority.UseTextAlignment = false;
            this.xrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel42
            // 
            this.xrLabel42.CanGrow = false;
            this.xrLabel42.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.C_DEP", "{0:n2}")});
            this.xrLabel42.Dpi = 100F;
            this.xrLabel42.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(1562.5F, 0F);
            this.xrLabel42.Name = "xrLabel42";
            this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel42.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel42.StylePriority.UseFont = false;
            this.xrLabel42.StylePriority.UseTextAlignment = false;
            this.xrLabel42.Text = "xrLabel42";
            this.xrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel28
            // 
            this.xrLabel28.CanGrow = false;
            this.xrLabel28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FEE", "{0:#,#}")});
            this.xrLabel28.Dpi = 100F;
            this.xrLabel28.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(600F, 0F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(62.5F, 25F);
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "xrLabel28";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel65
            // 
            this.xrLabel65.CanGrow = false;
            this.xrLabel65.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MEMBER_GROUP_NO")});
            this.xrLabel65.Dpi = 100F;
            this.xrLabel65.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel65.LocationFloat = new DevExpress.Utils.PointFloat(112.5F, 0F);
            this.xrLabel65.Name = "xrLabel65";
            this.xrLabel65.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel65.SizeF = new System.Drawing.SizeF(62.5F, 25F);
            this.xrLabel65.StylePriority.UseFont = false;
            this.xrLabel65.StylePriority.UseTextAlignment = false;
            this.xrLabel65.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            this.BottomMargin.HeightF = 190F;
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
            this.xrLabel7,
            this.xrLabel25,
            this.xrLabel24,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel17,
            this.xrLabel19,
            this.xrLabel26,
            this.xrLabel4,
            this.t_header_publish_date,
            this.t_header_1,
            this.t_header_2,
            this.t_header_3,
            this.xrPageInfo3,
            this.xrLabel16,
            this.xrLabel20,
            this.xrLabel18,
            this.xrLabel21,
            this.xrLabel23,
            this.xrLabel22,
            this.xrLabel64});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 200F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel7.CanGrow = false;
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(662.5F, 125F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(262.5F, 37.5F);
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "เงินกู้ฉุกเฉิน";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel25
            // 
            this.xrLabel25.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel25.CanGrow = false;
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(1662.5F, 162.5F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(62.5F, 37.5F);
            this.xrLabel25.StylePriority.UseBorders = false;
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.Text = "ผู้บันทึก";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel24
            // 
            this.xrLabel24.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel24.CanGrow = false;
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel24.ForeColor = System.Drawing.Color.Black;
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(1562.5F, 162.5F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(100F, 37.5F);
            this.xrLabel24.StylePriority.UseBorders = false;
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.StylePriority.UseForeColor = false;
            this.xrLabel24.StylePriority.UseTextAlignment = false;
            this.xrLabel24.Text = "เงินฝาก";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel6.CanGrow = false;
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(437.5F, 162.5F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(87.5F, 37.5F);
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "ซื้อหุ้นพิเศษ";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel5.CanGrow = false;
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(337.5F, 162.5F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(100F, 37.5F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "กองทุนใหม่";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel3.CanGrow = false;
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(175F, 162.5F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(162.5F, 37.5F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "ชื่อ - นามสกุล";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel2.CanGrow = false;
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(25F, 162.5F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(87.5F, 37.5F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "เลขที่ใบเสร็จ";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 162.5F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(25F, 37.5F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "ที่";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel12.CanGrow = false;
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(525F, 162.5F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(75F, 37.5F);
            this.xrLabel12.StylePriority.UseBorders = false;
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "ฌาปนกิจ";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel11.CanGrow = false;
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(662.5F, 162.5F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(87.5F, 37.5F);
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "เลขที่สัญญา";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel10.CanGrow = false;
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(750F, 162.5F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(100F, 37.5F);
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "เงินต้น";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel9.CanGrow = false;
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(850F, 162.5F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(75F, 37.5F);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "ดอกเบี้ย";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel17
            // 
            this.xrLabel17.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel17.CanGrow = false;
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(1450F, 162.5F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(112.5F, 37.5F);
            this.xrLabel17.StylePriority.UseBorders = false;
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "รวมเงิน";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel19
            // 
            this.xrLabel19.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel19.CanGrow = false;
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(925F, 125F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(262.5F, 37.5F);
            this.xrLabel19.StylePriority.UseBorders = false;
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "เงินกู้สามัญ";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel26
            // 
            this.xrLabel26.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel26.CanGrow = false;
            this.xrLabel26.Dpi = 100F;
            this.xrLabel26.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(1187.5F, 125F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(262.5F, 37.5F);
            this.xrLabel26.StylePriority.UseBorders = false;
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.StylePriority.UseTextAlignment = false;
            this.xrLabel26.Text = "เงินกู้พิเศษ";
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel4.CanGrow = false;
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(600F, 162.5F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(62.5F, 37.5F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "ค่าธน.";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // t_header_publish_date
            // 
            this.t_header_publish_date.Dpi = 100F;
            this.t_header_publish_date.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.t_header_publish_date.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.t_header_publish_date.Name = "t_header_publish_date";
            this.t_header_publish_date.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t_header_publish_date.SizeF = new System.Drawing.SizeF(1012.5F, 25F);
            this.t_header_publish_date.StylePriority.UseFont = false;
            this.t_header_publish_date.StylePriority.UseTextAlignment = false;
            this.t_header_publish_date.Text = "t_header_publish_date";
            this.t_header_publish_date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // t_header_1
            // 
            this.t_header_1.Dpi = 100F;
            this.t_header_1.Font = new System.Drawing.Font("AngsanaUPC", 16F, System.Drawing.FontStyle.Bold);
            this.t_header_1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.t_header_1.Name = "t_header_1";
            this.t_header_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t_header_1.SizeF = new System.Drawing.SizeF(1725F, 25F);
            this.t_header_1.StylePriority.UseFont = false;
            this.t_header_1.StylePriority.UseTextAlignment = false;
            this.t_header_1.Text = "t_header_1 <sc_cnt_m_coop.coop_name>";
            this.t_header_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // t_header_2
            // 
            this.t_header_2.Dpi = 100F;
            this.t_header_2.Font = new System.Drawing.Font("AngsanaUPC", 16F, System.Drawing.FontStyle.Bold);
            this.t_header_2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50F);
            this.t_header_2.Name = "t_header_2";
            this.t_header_2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t_header_2.SizeF = new System.Drawing.SizeF(1725F, 25F);
            this.t_header_2.StylePriority.UseFont = false;
            this.t_header_2.StylePriority.UseTextAlignment = false;
            this.t_header_2.Text = "t_header_2 <si_rep_reps.rep_text>";
            this.t_header_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // t_header_3
            // 
            this.t_header_3.Dpi = 100F;
            this.t_header_3.Font = new System.Drawing.Font("AngsanaUPC", 16F, System.Drawing.FontStyle.Bold);
            this.t_header_3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 75.00002F);
            this.t_header_3.Name = "t_header_3";
            this.t_header_3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t_header_3.SizeF = new System.Drawing.SizeF(1725F, 25F);
            this.t_header_3.StylePriority.UseFont = false;
            this.t_header_3.StylePriority.UseTextAlignment = false;
            this.t_header_3.Text = "t_header_3";
            this.t_header_3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPageInfo3
            // 
            this.xrPageInfo3.Dpi = 100F;
            this.xrPageInfo3.Font = new System.Drawing.Font("AngsanaUPC", 16F, System.Drawing.FontStyle.Bold);
            this.xrPageInfo3.ForeColor = System.Drawing.Color.Black;
            this.xrPageInfo3.Format = "หน้า {0}/ {1}";
            this.xrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(1012.5F, 0F);
            this.xrPageInfo3.Name = "xrPageInfo3";
            this.xrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo3.SizeF = new System.Drawing.SizeF(712.5F, 25F);
            this.xrPageInfo3.StylePriority.UseFont = false;
            this.xrPageInfo3.StylePriority.UseForeColor = false;
            this.xrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel16.CanGrow = false;
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(112.5F, 162.5F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(62.5F, 37.5F);
            this.xrLabel16.StylePriority.UseBorders = false;
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "หน่วย";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel20.CanGrow = false;
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(1112.5F, 162.5F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(75F, 37.5F);
            this.xrLabel20.StylePriority.UseBorders = false;
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "ดอกเบี้ย";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel18.CanGrow = false;
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(1012.5F, 162.5F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(100F, 37.5F);
            this.xrLabel18.StylePriority.UseBorders = false;
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "เงินต้น";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel21
            // 
            this.xrLabel21.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel21.CanGrow = false;
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(925F, 162.5F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(87.5F, 37.5F);
            this.xrLabel21.StylePriority.UseBorders = false;
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "เลขที่สัญญา";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel23
            // 
            this.xrLabel23.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel23.CanGrow = false;
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(1375F, 162.5F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(75F, 37.5F);
            this.xrLabel23.StylePriority.UseBorders = false;
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "ดอกเบี้ย";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel22
            // 
            this.xrLabel22.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel22.CanGrow = false;
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(1275F, 162.5F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(100F, 37.5F);
            this.xrLabel22.StylePriority.UseBorders = false;
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "เงินต้น";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel64
            // 
            this.xrLabel64.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel64.CanGrow = false;
            this.xrLabel64.Dpi = 100F;
            this.xrLabel64.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel64.LocationFloat = new DevExpress.Utils.PointFloat(1187.5F, 162.5F);
            this.xrLabel64.Name = "xrLabel64";
            this.xrLabel64.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel64.SizeF = new System.Drawing.SizeF(87.5F, 37.5F);
            this.xrLabel64.StylePriority.UseBorders = false;
            this.xrLabel64.StylePriority.UseFont = false;
            this.xrLabel64.StylePriority.UseTextAlignment = false;
            this.xrLabel64.Text = "เลขที่สัญญา";
            this.xrLabel64.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.t_soat,
            this.xrPageInfo1,
            this.xrLabel98,
            this.xrLabel99,
            this.xrLabel100,
            this.xrLabel101,
            this.xrLabel113,
            this.xrLabel32,
            this.xrLabel112,
            this.xrLabel111,
            this.xrLabel110,
            this.xrLabel109,
            this.xrLabel108,
            this.xrLabel107,
            this.xrLabel106,
            this.xrLabel105,
            this.xrLabel104,
            this.xrLabel103,
            this.xrLabel102,
            this.xrLabel148});
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 69.5F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrPageInfo1.Format = "รวมหน้า {0}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(112.5F, 37.5F);
            this.xrPageInfo1.StylePriority.UseBorders = false;
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel98
            // 
            this.xrLabel98.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel98.CanGrow = false;
            this.xrLabel98.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MEMBER_GROUP_NO")});
            this.xrLabel98.Dpi = 100F;
            this.xrLabel98.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel98.LocationFloat = new DevExpress.Utils.PointFloat(250F, 0F);
            this.xrLabel98.Name = "xrLabel98";
            this.xrLabel98.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel98.SizeF = new System.Drawing.SizeF(75F, 37.5F);
            this.xrLabel98.StylePriority.UseBorders = false;
            this.xrLabel98.StylePriority.UseFont = false;
            this.xrLabel98.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:#,0} หน่วย";
            xrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.DCount;
            xrSummary2.IgnoreNullValues = true;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
            this.xrLabel98.Summary = xrSummary2;
            this.xrLabel98.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel99
            // 
            this.xrLabel99.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel99.CanGrow = false;
            this.xrLabel99.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FUND_NEW")});
            this.xrLabel99.Dpi = 100F;
            this.xrLabel99.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel99.LocationFloat = new DevExpress.Utils.PointFloat(325F, 0F);
            this.xrLabel99.Name = "xrLabel99";
            this.xrLabel99.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel99.SizeF = new System.Drawing.SizeF(100F, 37.5F);
            this.xrLabel99.StylePriority.UseBorders = false;
            this.xrLabel99.StylePriority.UseFont = false;
            this.xrLabel99.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:n2}";
            xrSummary3.Func = DevExpress.XtraReports.UI.SummaryFunc.RunningSum;
            xrSummary3.IgnoreNullValues = true;
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
            this.xrLabel99.Summary = xrSummary3;
            this.xrLabel99.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel100
            // 
            this.xrLabel100.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel100.CanGrow = false;
            this.xrLabel100.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.BY_SHARE")});
            this.xrLabel100.Dpi = 100F;
            this.xrLabel100.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel100.LocationFloat = new DevExpress.Utils.PointFloat(425F, 0F);
            this.xrLabel100.Name = "xrLabel100";
            this.xrLabel100.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel100.SizeF = new System.Drawing.SizeF(87.5F, 37.5F);
            this.xrLabel100.StylePriority.UseBorders = false;
            this.xrLabel100.StylePriority.UseFont = false;
            this.xrLabel100.StylePriority.UseTextAlignment = false;
            xrSummary4.FormatString = "{0:n2}";
            xrSummary4.Func = DevExpress.XtraReports.UI.SummaryFunc.RunningSum;
            xrSummary4.IgnoreNullValues = true;
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
            this.xrLabel100.Summary = xrSummary4;
            this.xrLabel100.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel101
            // 
            this.xrLabel101.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel101.CanGrow = false;
            this.xrLabel101.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.CREM_AMOUNT")});
            this.xrLabel101.Dpi = 100F;
            this.xrLabel101.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel101.LocationFloat = new DevExpress.Utils.PointFloat(512.5F, 0F);
            this.xrLabel101.Name = "xrLabel101";
            this.xrLabel101.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel101.SizeF = new System.Drawing.SizeF(75F, 37.5F);
            this.xrLabel101.StylePriority.UseBorders = false;
            this.xrLabel101.StylePriority.UseFont = false;
            this.xrLabel101.StylePriority.UseTextAlignment = false;
            xrSummary5.FormatString = "{0:n2}";
            xrSummary5.Func = DevExpress.XtraReports.UI.SummaryFunc.RunningSum;
            xrSummary5.IgnoreNullValues = true;
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
            this.xrLabel101.Summary = xrSummary5;
            this.xrLabel101.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel113
            // 
            this.xrLabel113.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel113.CanGrow = false;
            this.xrLabel113.Dpi = 100F;
            this.xrLabel113.Font = new System.Drawing.Font("CordiaUPC", 10.5F);
            this.xrLabel113.LocationFloat = new DevExpress.Utils.PointFloat(1662.5F, 0F);
            this.xrLabel113.Name = "xrLabel113";
            this.xrLabel113.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel113.SizeF = new System.Drawing.SizeF(62.5F, 37.5F);
            this.xrLabel113.StylePriority.UseBorders = false;
            this.xrLabel113.StylePriority.UseFont = false;
            this.xrLabel113.StylePriority.UseTextAlignment = false;
            xrSummary6.FormatString = "{0:n2}";
            xrSummary6.Func = DevExpress.XtraReports.UI.SummaryFunc.RunningSum;
            xrSummary6.IgnoreNullValues = true;
            this.xrLabel113.Summary = xrSummary6;
            this.xrLabel113.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel32
            // 
            this.xrLabel32.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel32.CanGrow = false;
            this.xrLabel32.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MEMBERSHIP_NO")});
            this.xrLabel32.Dpi = 100F;
            this.xrLabel32.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(112.5F, 0F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(137.5F, 37.5F);
            this.xrLabel32.StylePriority.UseBorders = false;
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            xrSummary7.FormatString = "{0:#,#} ราย";
            xrSummary7.Func = DevExpress.XtraReports.UI.SummaryFunc.DCount;
            xrSummary7.IgnoreNullValues = true;
            xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
            this.xrLabel32.Summary = xrSummary7;
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel112
            // 
            this.xrLabel112.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel112.CanGrow = false;
            this.xrLabel112.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.C_DEP")});
            this.xrLabel112.Dpi = 100F;
            this.xrLabel112.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel112.LocationFloat = new DevExpress.Utils.PointFloat(1562.5F, 0F);
            this.xrLabel112.Name = "xrLabel112";
            this.xrLabel112.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel112.SizeF = new System.Drawing.SizeF(100F, 37.5F);
            this.xrLabel112.StylePriority.UseBorders = false;
            this.xrLabel112.StylePriority.UseFont = false;
            this.xrLabel112.StylePriority.UseTextAlignment = false;
            xrSummary8.FormatString = "{0:n2}";
            xrSummary8.Func = DevExpress.XtraReports.UI.SummaryFunc.RunningSum;
            xrSummary8.IgnoreNullValues = true;
            xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
            this.xrLabel112.Summary = xrSummary8;
            this.xrLabel112.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel111
            // 
            this.xrLabel111.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel111.CanGrow = false;
            this.xrLabel111.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.S_ITEM_AMOUNT")});
            this.xrLabel111.Dpi = 100F;
            this.xrLabel111.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel111.ForeColor = System.Drawing.Color.Black;
            this.xrLabel111.LocationFloat = new DevExpress.Utils.PointFloat(1450F, 0F);
            this.xrLabel111.Name = "xrLabel111";
            this.xrLabel111.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel111.SizeF = new System.Drawing.SizeF(112.5F, 37.5F);
            this.xrLabel111.StylePriority.UseBorders = false;
            this.xrLabel111.StylePriority.UseFont = false;
            this.xrLabel111.StylePriority.UseForeColor = false;
            this.xrLabel111.StylePriority.UseTextAlignment = false;
            xrSummary9.FormatString = "{0:n2}";
            xrSummary9.Func = DevExpress.XtraReports.UI.SummaryFunc.RunningSum;
            xrSummary9.IgnoreNullValues = true;
            xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
            this.xrLabel111.Summary = xrSummary9;
            this.xrLabel111.Text = "ห";
            this.xrLabel111.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel111.WordWrap = false;
            // 
            // xrLabel110
            // 
            this.xrLabel110.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel110.CanGrow = false;
            this.xrLabel110.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT_03")});
            this.xrLabel110.Dpi = 100F;
            this.xrLabel110.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel110.ForeColor = System.Drawing.Color.Black;
            this.xrLabel110.LocationFloat = new DevExpress.Utils.PointFloat(1375F, 0F);
            this.xrLabel110.Name = "xrLabel110";
            this.xrLabel110.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel110.SizeF = new System.Drawing.SizeF(75F, 37.5F);
            this.xrLabel110.StylePriority.UseBorders = false;
            this.xrLabel110.StylePriority.UseFont = false;
            this.xrLabel110.StylePriority.UseForeColor = false;
            this.xrLabel110.StylePriority.UseTextAlignment = false;
            xrSummary10.FormatString = "{0:n2}";
            xrSummary10.Func = DevExpress.XtraReports.UI.SummaryFunc.RunningSum;
            xrSummary10.IgnoreNullValues = true;
            xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
            this.xrLabel110.Summary = xrSummary10;
            this.xrLabel110.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel110.WordWrap = false;
            // 
            // xrLabel109
            // 
            this.xrLabel109.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel109.CanGrow = false;
            this.xrLabel109.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT_03")});
            this.xrLabel109.Dpi = 100F;
            this.xrLabel109.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel109.ForeColor = System.Drawing.Color.Black;
            this.xrLabel109.LocationFloat = new DevExpress.Utils.PointFloat(1275F, 0F);
            this.xrLabel109.Name = "xrLabel109";
            this.xrLabel109.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel109.SizeF = new System.Drawing.SizeF(100F, 37.5F);
            this.xrLabel109.StylePriority.UseBorders = false;
            this.xrLabel109.StylePriority.UseFont = false;
            this.xrLabel109.StylePriority.UseForeColor = false;
            this.xrLabel109.StylePriority.UseTextAlignment = false;
            xrSummary11.FormatString = "{0:n2}";
            xrSummary11.Func = DevExpress.XtraReports.UI.SummaryFunc.RunningSum;
            xrSummary11.IgnoreNullValues = true;
            xrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
            this.xrLabel109.Summary = xrSummary11;
            this.xrLabel109.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel109.WordWrap = false;
            // 
            // xrLabel108
            // 
            this.xrLabel108.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel108.CanGrow = false;
            this.xrLabel108.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.COUNT_03")});
            this.xrLabel108.Dpi = 100F;
            this.xrLabel108.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel108.ForeColor = System.Drawing.Color.Black;
            this.xrLabel108.LocationFloat = new DevExpress.Utils.PointFloat(1187.5F, 0F);
            this.xrLabel108.Name = "xrLabel108";
            this.xrLabel108.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel108.SizeF = new System.Drawing.SizeF(87.5F, 37.5F);
            this.xrLabel108.StylePriority.UseBorders = false;
            this.xrLabel108.StylePriority.UseFont = false;
            this.xrLabel108.StylePriority.UseForeColor = false;
            this.xrLabel108.StylePriority.UseTextAlignment = false;
            xrSummary12.FormatString = "{0:#,0} ราย";
            xrSummary12.Func = DevExpress.XtraReports.UI.SummaryFunc.RunningSum;
            xrSummary12.IgnoreNullValues = true;
            xrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
            this.xrLabel108.Summary = xrSummary12;
            this.xrLabel108.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel108.WordWrap = false;
            // 
            // xrLabel107
            // 
            this.xrLabel107.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel107.CanGrow = false;
            this.xrLabel107.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT_02")});
            this.xrLabel107.Dpi = 100F;
            this.xrLabel107.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel107.ForeColor = System.Drawing.Color.Black;
            this.xrLabel107.LocationFloat = new DevExpress.Utils.PointFloat(1112.5F, 0F);
            this.xrLabel107.Name = "xrLabel107";
            this.xrLabel107.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel107.SizeF = new System.Drawing.SizeF(75F, 37.5F);
            this.xrLabel107.StylePriority.UseBorders = false;
            this.xrLabel107.StylePriority.UseFont = false;
            this.xrLabel107.StylePriority.UseForeColor = false;
            this.xrLabel107.StylePriority.UseTextAlignment = false;
            xrSummary13.FormatString = "{0:n2}";
            xrSummary13.Func = DevExpress.XtraReports.UI.SummaryFunc.RunningSum;
            xrSummary13.IgnoreNullValues = true;
            xrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
            this.xrLabel107.Summary = xrSummary13;
            this.xrLabel107.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel107.WordWrap = false;
            // 
            // xrLabel106
            // 
            this.xrLabel106.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel106.CanGrow = false;
            this.xrLabel106.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT_02")});
            this.xrLabel106.Dpi = 100F;
            this.xrLabel106.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel106.ForeColor = System.Drawing.Color.Black;
            this.xrLabel106.LocationFloat = new DevExpress.Utils.PointFloat(1012.5F, 0F);
            this.xrLabel106.Name = "xrLabel106";
            this.xrLabel106.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel106.SizeF = new System.Drawing.SizeF(100F, 37.5F);
            this.xrLabel106.StylePriority.UseBorders = false;
            this.xrLabel106.StylePriority.UseFont = false;
            this.xrLabel106.StylePriority.UseForeColor = false;
            this.xrLabel106.StylePriority.UseTextAlignment = false;
            xrSummary14.FormatString = "{0:n2}";
            xrSummary14.Func = DevExpress.XtraReports.UI.SummaryFunc.RunningSum;
            xrSummary14.IgnoreNullValues = true;
            xrSummary14.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
            this.xrLabel106.Summary = xrSummary14;
            this.xrLabel106.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel106.WordWrap = false;
            // 
            // xrLabel105
            // 
            this.xrLabel105.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel105.CanGrow = false;
            this.xrLabel105.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.COUNT_02")});
            this.xrLabel105.Dpi = 100F;
            this.xrLabel105.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel105.ForeColor = System.Drawing.Color.Black;
            this.xrLabel105.LocationFloat = new DevExpress.Utils.PointFloat(925F, 0F);
            this.xrLabel105.Name = "xrLabel105";
            this.xrLabel105.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel105.SizeF = new System.Drawing.SizeF(87.5F, 37.5F);
            this.xrLabel105.StylePriority.UseBorders = false;
            this.xrLabel105.StylePriority.UseFont = false;
            this.xrLabel105.StylePriority.UseForeColor = false;
            this.xrLabel105.StylePriority.UseTextAlignment = false;
            xrSummary15.FormatString = "{0:#,0} ราย";
            xrSummary15.Func = DevExpress.XtraReports.UI.SummaryFunc.RunningSum;
            xrSummary15.IgnoreNullValues = true;
            xrSummary15.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
            this.xrLabel105.Summary = xrSummary15;
            this.xrLabel105.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel105.WordWrap = false;
            // 
            // xrLabel104
            // 
            this.xrLabel104.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel104.CanGrow = false;
            this.xrLabel104.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT_01")});
            this.xrLabel104.Dpi = 100F;
            this.xrLabel104.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel104.ForeColor = System.Drawing.Color.Black;
            this.xrLabel104.LocationFloat = new DevExpress.Utils.PointFloat(850F, 0F);
            this.xrLabel104.Name = "xrLabel104";
            this.xrLabel104.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel104.SizeF = new System.Drawing.SizeF(75F, 37.5F);
            this.xrLabel104.StylePriority.UseBorders = false;
            this.xrLabel104.StylePriority.UseFont = false;
            this.xrLabel104.StylePriority.UseForeColor = false;
            this.xrLabel104.StylePriority.UseTextAlignment = false;
            xrSummary16.FormatString = "{0:n2}";
            xrSummary16.Func = DevExpress.XtraReports.UI.SummaryFunc.RunningSum;
            xrSummary16.IgnoreNullValues = true;
            xrSummary16.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
            this.xrLabel104.Summary = xrSummary16;
            this.xrLabel104.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel104.WordWrap = false;
            // 
            // xrLabel103
            // 
            this.xrLabel103.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel103.CanGrow = false;
            this.xrLabel103.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT_01")});
            this.xrLabel103.Dpi = 100F;
            this.xrLabel103.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel103.ForeColor = System.Drawing.Color.Black;
            this.xrLabel103.LocationFloat = new DevExpress.Utils.PointFloat(750F, 0F);
            this.xrLabel103.Name = "xrLabel103";
            this.xrLabel103.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel103.SizeF = new System.Drawing.SizeF(100F, 37.5F);
            this.xrLabel103.StylePriority.UseBorders = false;
            this.xrLabel103.StylePriority.UseFont = false;
            this.xrLabel103.StylePriority.UseForeColor = false;
            this.xrLabel103.StylePriority.UseTextAlignment = false;
            xrSummary17.FormatString = "{0:n2}";
            xrSummary17.Func = DevExpress.XtraReports.UI.SummaryFunc.RunningSum;
            xrSummary17.IgnoreNullValues = true;
            xrSummary17.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
            this.xrLabel103.Summary = xrSummary17;
            this.xrLabel103.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel102
            // 
            this.xrLabel102.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel102.CanGrow = false;
            this.xrLabel102.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.COUNT_01")});
            this.xrLabel102.Dpi = 100F;
            this.xrLabel102.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel102.ForeColor = System.Drawing.Color.Black;
            this.xrLabel102.LocationFloat = new DevExpress.Utils.PointFloat(662.5F, 0F);
            this.xrLabel102.Name = "xrLabel102";
            this.xrLabel102.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel102.SizeF = new System.Drawing.SizeF(87.5F, 37.5F);
            this.xrLabel102.StylePriority.UseBorders = false;
            this.xrLabel102.StylePriority.UseFont = false;
            this.xrLabel102.StylePriority.UseForeColor = false;
            this.xrLabel102.StylePriority.UseTextAlignment = false;
            xrSummary18.FormatString = "{0:#,0} ราย";
            xrSummary18.Func = DevExpress.XtraReports.UI.SummaryFunc.RunningSum;
            xrSummary18.IgnoreNullValues = true;
            xrSummary18.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
            this.xrLabel102.Summary = xrSummary18;
            this.xrLabel102.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel148
            // 
            this.xrLabel148.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel148.CanGrow = false;
            this.xrLabel148.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FEE")});
            this.xrLabel148.Dpi = 100F;
            this.xrLabel148.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel148.LocationFloat = new DevExpress.Utils.PointFloat(587.5F, 0F);
            this.xrLabel148.Name = "xrLabel148";
            this.xrLabel148.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel148.SizeF = new System.Drawing.SizeF(75F, 37.5F);
            this.xrLabel148.StylePriority.UseBorders = false;
            this.xrLabel148.StylePriority.UseFont = false;
            this.xrLabel148.StylePriority.UseTextAlignment = false;
            xrSummary19.FormatString = "{0:n2}";
            xrSummary19.Func = DevExpress.XtraReports.UI.SummaryFunc.RunningSum;
            xrSummary19.IgnoreNullValues = true;
            xrSummary19.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
            this.xrLabel148.Summary = xrSummary19;
            this.xrLabel148.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel179,
            this.xrLabel195,
            this.xrLabel194,
            this.xrLabel193,
            this.xrLabel192,
            this.xrLabel191,
            this.xrLabel190,
            this.xrLabel189,
            this.xrLabel188,
            this.xrLabel187,
            this.xrLabel186,
            this.xrLabel185,
            this.xrLabel184,
            this.xrLabel183,
            this.xrLabel182,
            this.xrLabel181,
            this.xrLabel180});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 37.5F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.StylePriority.UseTextAlignment = false;
            this.GroupFooter1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel179
            // 
            this.xrLabel179.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel179.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel179.CanGrow = false;
            this.xrLabel179.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MEMBER_GROUP_TYPE", "รวม Teller : {0}")});
            this.xrLabel179.Dpi = 100F;
            this.xrLabel179.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel179.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel179.Name = "xrLabel179";
            this.xrLabel179.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel179.SizeF = new System.Drawing.SizeF(337.5F, 37.5F);
            this.xrLabel179.StylePriority.UseBorderDashStyle = false;
            this.xrLabel179.StylePriority.UseBorders = false;
            this.xrLabel179.StylePriority.UseFont = false;
            this.xrLabel179.StylePriority.UseTextAlignment = false;
            this.xrLabel179.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel195
            // 
            this.xrLabel195.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel195.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel195.CanGrow = false;
            this.xrLabel195.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FEE")});
            this.xrLabel195.Dpi = 100F;
            this.xrLabel195.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel195.LocationFloat = new DevExpress.Utils.PointFloat(599.9999F, 0F);
            this.xrLabel195.Name = "xrLabel195";
            this.xrLabel195.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel195.SizeF = new System.Drawing.SizeF(62.5F, 37.5F);
            this.xrLabel195.StylePriority.UseBorderDashStyle = false;
            this.xrLabel195.StylePriority.UseBorders = false;
            this.xrLabel195.StylePriority.UseFont = false;
            this.xrLabel195.StylePriority.UseTextAlignment = false;
            xrSummary20.FormatString = "{0:#,##0.00;,#,##0.00;-}";
            xrSummary20.IgnoreNullValues = true;
            xrSummary20.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel195.Summary = xrSummary20;
            this.xrLabel195.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel195.WordWrap = false;
            // 
            // xrLabel194
            // 
            this.xrLabel194.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel194.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel194.CanGrow = false;
            this.xrLabel194.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FUND_NEW")});
            this.xrLabel194.Dpi = 100F;
            this.xrLabel194.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel194.LocationFloat = new DevExpress.Utils.PointFloat(337.5F, 0F);
            this.xrLabel194.Name = "xrLabel194";
            this.xrLabel194.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel194.SizeF = new System.Drawing.SizeF(100F, 37.5F);
            this.xrLabel194.StylePriority.UseBorderDashStyle = false;
            this.xrLabel194.StylePriority.UseBorders = false;
            this.xrLabel194.StylePriority.UseFont = false;
            this.xrLabel194.StylePriority.UseTextAlignment = false;
            xrSummary21.FormatString = "{0:#,##0.00;,#,##0.00;-}";
            xrSummary21.IgnoreNullValues = true;
            xrSummary21.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel194.Summary = xrSummary21;
            this.xrLabel194.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel194.WordWrap = false;
            // 
            // xrLabel193
            // 
            this.xrLabel193.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel193.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel193.CanGrow = false;
            this.xrLabel193.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.BY_SHARE")});
            this.xrLabel193.Dpi = 100F;
            this.xrLabel193.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel193.LocationFloat = new DevExpress.Utils.PointFloat(437.5F, 0F);
            this.xrLabel193.Name = "xrLabel193";
            this.xrLabel193.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel193.SizeF = new System.Drawing.SizeF(87.5F, 37.5F);
            this.xrLabel193.StylePriority.UseBorderDashStyle = false;
            this.xrLabel193.StylePriority.UseBorders = false;
            this.xrLabel193.StylePriority.UseFont = false;
            this.xrLabel193.StylePriority.UseTextAlignment = false;
            xrSummary22.FormatString = "{0:#,##0.00;,#,##0.00;-}";
            xrSummary22.IgnoreNullValues = true;
            xrSummary22.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel193.Summary = xrSummary22;
            this.xrLabel193.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel193.WordWrap = false;
            // 
            // xrLabel192
            // 
            this.xrLabel192.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel192.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel192.CanGrow = false;
            this.xrLabel192.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FREE_AMOUNT")});
            this.xrLabel192.Dpi = 100F;
            this.xrLabel192.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel192.LocationFloat = new DevExpress.Utils.PointFloat(524.9999F, 0F);
            this.xrLabel192.Name = "xrLabel192";
            this.xrLabel192.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel192.SizeF = new System.Drawing.SizeF(75F, 37.5F);
            this.xrLabel192.StylePriority.UseBorderDashStyle = false;
            this.xrLabel192.StylePriority.UseBorders = false;
            this.xrLabel192.StylePriority.UseFont = false;
            this.xrLabel192.StylePriority.UseTextAlignment = false;
            xrSummary23.FormatString = "{0:#,##0.00;,#,##0.00;-}";
            xrSummary23.IgnoreNullValues = true;
            xrSummary23.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel192.Summary = xrSummary23;
            this.xrLabel192.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel192.WordWrap = false;
            // 
            // xrLabel191
            // 
            this.xrLabel191.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel191.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel191.CanGrow = false;
            this.xrLabel191.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT_01")});
            this.xrLabel191.Dpi = 100F;
            this.xrLabel191.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel191.ForeColor = System.Drawing.Color.Black;
            this.xrLabel191.LocationFloat = new DevExpress.Utils.PointFloat(849.9999F, 0F);
            this.xrLabel191.Name = "xrLabel191";
            this.xrLabel191.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel191.SizeF = new System.Drawing.SizeF(75F, 37.5F);
            this.xrLabel191.StylePriority.UseBorderDashStyle = false;
            this.xrLabel191.StylePriority.UseBorders = false;
            this.xrLabel191.StylePriority.UseFont = false;
            this.xrLabel191.StylePriority.UseForeColor = false;
            this.xrLabel191.StylePriority.UseTextAlignment = false;
            xrSummary24.FormatString = "{0:n2}";
            xrSummary24.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel191.Summary = xrSummary24;
            this.xrLabel191.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel190
            // 
            this.xrLabel190.BackColor = System.Drawing.Color.White;
            this.xrLabel190.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel190.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel190.CanGrow = false;
            this.xrLabel190.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT_01")});
            this.xrLabel190.Dpi = 100F;
            this.xrLabel190.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel190.ForeColor = System.Drawing.Color.Black;
            this.xrLabel190.LocationFloat = new DevExpress.Utils.PointFloat(749.9999F, 0F);
            this.xrLabel190.Name = "xrLabel190";
            this.xrLabel190.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel190.SizeF = new System.Drawing.SizeF(100F, 37.5F);
            this.xrLabel190.StylePriority.UseBackColor = false;
            this.xrLabel190.StylePriority.UseBorderDashStyle = false;
            this.xrLabel190.StylePriority.UseBorders = false;
            this.xrLabel190.StylePriority.UseFont = false;
            this.xrLabel190.StylePriority.UseForeColor = false;
            this.xrLabel190.StylePriority.UseTextAlignment = false;
            xrSummary25.FormatString = "{0:n2}";
            xrSummary25.IgnoreNullValues = true;
            xrSummary25.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel190.Summary = xrSummary25;
            this.xrLabel190.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel189
            // 
            this.xrLabel189.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel189.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel189.CanGrow = false;
            this.xrLabel189.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT_02")});
            this.xrLabel189.Dpi = 100F;
            this.xrLabel189.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel189.ForeColor = System.Drawing.Color.Black;
            this.xrLabel189.LocationFloat = new DevExpress.Utils.PointFloat(1012.5F, 0F);
            this.xrLabel189.Name = "xrLabel189";
            this.xrLabel189.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel189.SizeF = new System.Drawing.SizeF(100F, 37.5F);
            this.xrLabel189.StylePriority.UseBorderDashStyle = false;
            this.xrLabel189.StylePriority.UseBorders = false;
            this.xrLabel189.StylePriority.UseFont = false;
            this.xrLabel189.StylePriority.UseForeColor = false;
            this.xrLabel189.StylePriority.UseTextAlignment = false;
            xrSummary26.FormatString = "{0:n2}";
            xrSummary26.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel189.Summary = xrSummary26;
            this.xrLabel189.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel189.WordWrap = false;
            // 
            // xrLabel188
            // 
            this.xrLabel188.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel188.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel188.CanGrow = false;
            this.xrLabel188.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT_02")});
            this.xrLabel188.Dpi = 100F;
            this.xrLabel188.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel188.ForeColor = System.Drawing.Color.Black;
            this.xrLabel188.LocationFloat = new DevExpress.Utils.PointFloat(1112.5F, 0F);
            this.xrLabel188.Name = "xrLabel188";
            this.xrLabel188.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel188.SizeF = new System.Drawing.SizeF(75F, 37.5F);
            this.xrLabel188.StylePriority.UseBorderDashStyle = false;
            this.xrLabel188.StylePriority.UseBorders = false;
            this.xrLabel188.StylePriority.UseFont = false;
            this.xrLabel188.StylePriority.UseForeColor = false;
            this.xrLabel188.StylePriority.UseTextAlignment = false;
            xrSummary27.FormatString = "{0:n2}";
            xrSummary27.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel188.Summary = xrSummary27;
            this.xrLabel188.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel188.WordWrap = false;
            // 
            // xrLabel187
            // 
            this.xrLabel187.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel187.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel187.CanGrow = false;
            this.xrLabel187.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.COUNT_03")});
            this.xrLabel187.Dpi = 100F;
            this.xrLabel187.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel187.ForeColor = System.Drawing.Color.Black;
            this.xrLabel187.LocationFloat = new DevExpress.Utils.PointFloat(1187.5F, 0F);
            this.xrLabel187.Name = "xrLabel187";
            this.xrLabel187.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel187.SizeF = new System.Drawing.SizeF(87.5F, 37.5F);
            this.xrLabel187.StylePriority.UseBorderDashStyle = false;
            this.xrLabel187.StylePriority.UseBorders = false;
            this.xrLabel187.StylePriority.UseFont = false;
            this.xrLabel187.StylePriority.UseForeColor = false;
            this.xrLabel187.StylePriority.UseTextAlignment = false;
            xrSummary28.FormatString = "{0:#,0} ราย";
            xrSummary28.IgnoreNullValues = true;
            xrSummary28.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel187.Summary = xrSummary28;
            this.xrLabel187.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel187.WordWrap = false;
            // 
            // xrLabel186
            // 
            this.xrLabel186.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel186.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel186.CanGrow = false;
            this.xrLabel186.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.COUNT_02")});
            this.xrLabel186.Dpi = 100F;
            this.xrLabel186.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel186.ForeColor = System.Drawing.Color.Black;
            this.xrLabel186.LocationFloat = new DevExpress.Utils.PointFloat(924.9999F, 0F);
            this.xrLabel186.Name = "xrLabel186";
            this.xrLabel186.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel186.SizeF = new System.Drawing.SizeF(87.5F, 37.5F);
            this.xrLabel186.StylePriority.UseBorderDashStyle = false;
            this.xrLabel186.StylePriority.UseBorders = false;
            this.xrLabel186.StylePriority.UseFont = false;
            this.xrLabel186.StylePriority.UseForeColor = false;
            this.xrLabel186.StylePriority.UseTextAlignment = false;
            xrSummary29.FormatString = "{0:#,0} ราย";
            xrSummary29.IgnoreNullValues = true;
            xrSummary29.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel186.Summary = xrSummary29;
            this.xrLabel186.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel186.WordWrap = false;
            // 
            // xrLabel185
            // 
            this.xrLabel185.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel185.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel185.CanGrow = false;
            this.xrLabel185.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.COUNT_01")});
            this.xrLabel185.Dpi = 100F;
            this.xrLabel185.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel185.ForeColor = System.Drawing.Color.Black;
            this.xrLabel185.LocationFloat = new DevExpress.Utils.PointFloat(662.4999F, 0F);
            this.xrLabel185.Name = "xrLabel185";
            this.xrLabel185.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel185.SizeF = new System.Drawing.SizeF(87.5F, 37.5F);
            this.xrLabel185.StylePriority.UseBorderDashStyle = false;
            this.xrLabel185.StylePriority.UseBorders = false;
            this.xrLabel185.StylePriority.UseFont = false;
            this.xrLabel185.StylePriority.UseForeColor = false;
            this.xrLabel185.StylePriority.UseTextAlignment = false;
            xrSummary30.FormatString = "{0:#,0} ราย";
            xrSummary30.IgnoreNullValues = true;
            xrSummary30.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel185.Summary = xrSummary30;
            this.xrLabel185.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel185.WordWrap = false;
            // 
            // xrLabel184
            // 
            this.xrLabel184.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel184.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel184.CanGrow = false;
            this.xrLabel184.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT_03")});
            this.xrLabel184.Dpi = 100F;
            this.xrLabel184.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel184.ForeColor = System.Drawing.Color.Black;
            this.xrLabel184.LocationFloat = new DevExpress.Utils.PointFloat(1275F, 0F);
            this.xrLabel184.Name = "xrLabel184";
            this.xrLabel184.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel184.SizeF = new System.Drawing.SizeF(100F, 37.5F);
            this.xrLabel184.StylePriority.UseBorderDashStyle = false;
            this.xrLabel184.StylePriority.UseBorders = false;
            this.xrLabel184.StylePriority.UseFont = false;
            this.xrLabel184.StylePriority.UseForeColor = false;
            this.xrLabel184.StylePriority.UseTextAlignment = false;
            xrSummary31.FormatString = "{0:n2}";
            xrSummary31.IgnoreNullValues = true;
            xrSummary31.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel184.Summary = xrSummary31;
            this.xrLabel184.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel184.WordWrap = false;
            // 
            // xrLabel183
            // 
            this.xrLabel183.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel183.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel183.CanGrow = false;
            this.xrLabel183.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT_03")});
            this.xrLabel183.Dpi = 100F;
            this.xrLabel183.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel183.ForeColor = System.Drawing.Color.Black;
            this.xrLabel183.LocationFloat = new DevExpress.Utils.PointFloat(1375F, 0F);
            this.xrLabel183.Name = "xrLabel183";
            this.xrLabel183.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel183.SizeF = new System.Drawing.SizeF(75F, 37.5F);
            this.xrLabel183.StylePriority.UseBorderDashStyle = false;
            this.xrLabel183.StylePriority.UseBorders = false;
            this.xrLabel183.StylePriority.UseFont = false;
            this.xrLabel183.StylePriority.UseForeColor = false;
            this.xrLabel183.StylePriority.UseTextAlignment = false;
            xrSummary32.FormatString = "{0:n2}";
            xrSummary32.IgnoreNullValues = true;
            xrSummary32.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel183.Summary = xrSummary32;
            this.xrLabel183.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel182
            // 
            this.xrLabel182.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel182.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel182.CanGrow = false;
            this.xrLabel182.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.S_ITEM_AMOUNT")});
            this.xrLabel182.Dpi = 100F;
            this.xrLabel182.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel182.ForeColor = System.Drawing.Color.Black;
            this.xrLabel182.LocationFloat = new DevExpress.Utils.PointFloat(1450F, 0F);
            this.xrLabel182.Name = "xrLabel182";
            this.xrLabel182.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel182.SizeF = new System.Drawing.SizeF(112.5F, 37.5F);
            this.xrLabel182.StylePriority.UseBorderDashStyle = false;
            this.xrLabel182.StylePriority.UseBorders = false;
            this.xrLabel182.StylePriority.UseFont = false;
            this.xrLabel182.StylePriority.UseForeColor = false;
            this.xrLabel182.StylePriority.UseTextAlignment = false;
            xrSummary33.FormatString = "{0:n2}";
            xrSummary33.IgnoreNullValues = true;
            xrSummary33.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel182.Summary = xrSummary33;
            this.xrLabel182.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel181
            // 
            this.xrLabel181.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel181.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel181.CanGrow = false;
            this.xrLabel181.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.C_DEP")});
            this.xrLabel181.Dpi = 100F;
            this.xrLabel181.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel181.LocationFloat = new DevExpress.Utils.PointFloat(1562.5F, 0F);
            this.xrLabel181.Name = "xrLabel181";
            this.xrLabel181.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel181.SizeF = new System.Drawing.SizeF(100F, 37.5F);
            this.xrLabel181.StylePriority.UseBorderDashStyle = false;
            this.xrLabel181.StylePriority.UseBorders = false;
            this.xrLabel181.StylePriority.UseFont = false;
            this.xrLabel181.StylePriority.UseTextAlignment = false;
            xrSummary34.FormatString = "{0:n2}";
            xrSummary34.IgnoreNullValues = true;
            xrSummary34.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel181.Summary = xrSummary34;
            this.xrLabel181.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel180
            // 
            this.xrLabel180.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel180.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel180.CanGrow = false;
            this.xrLabel180.Dpi = 100F;
            this.xrLabel180.Font = new System.Drawing.Font("CordiaUPC", 10.5F);
            this.xrLabel180.LocationFloat = new DevExpress.Utils.PointFloat(1662.5F, 0F);
            this.xrLabel180.Name = "xrLabel180";
            this.xrLabel180.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel180.SizeF = new System.Drawing.SizeF(62.5F, 37.5F);
            this.xrLabel180.StylePriority.UseBorderDashStyle = false;
            this.xrLabel180.StylePriority.UseBorders = false;
            this.xrLabel180.StylePriority.UseFont = false;
            this.xrLabel180.WordWrap = false;
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel79,
            this.xrLabel58,
            this.xrLabel57,
            this.xrLabel56,
            this.xrLabel55,
            this.xrLabel48,
            this.xrLabel51,
            this.xrLabel54,
            this.xrLabel52,
            this.xrLabel53,
            this.xrLabel49,
            this.xrLabel50,
            this.xrLabel47,
            this.xrLabel46,
            this.xrLabel45,
            this.xrLabel44,
            this.xrLabel146});
            this.GroupFooter2.Dpi = 100F;
            this.GroupFooter2.HeightF = 37.5F;
            this.GroupFooter2.KeepTogether = true;
            this.GroupFooter2.Level = 1;
            this.GroupFooter2.Name = "GroupFooter2";
            this.GroupFooter2.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            this.GroupFooter2.RepeatEveryPage = true;
            // 
            // xrLabel79
            // 
            this.xrLabel79.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel79.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel79.CanGrow = false;
            this.xrLabel79.Dpi = 100F;
            this.xrLabel79.Font = new System.Drawing.Font("CordiaUPC", 10.5F);
            this.xrLabel79.LocationFloat = new DevExpress.Utils.PointFloat(1662.5F, 0F);
            this.xrLabel79.Name = "xrLabel79";
            this.xrLabel79.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel79.SizeF = new System.Drawing.SizeF(62.5F, 37.5F);
            this.xrLabel79.StylePriority.UseBorderDashStyle = false;
            this.xrLabel79.StylePriority.UseBorders = false;
            this.xrLabel79.StylePriority.UseFont = false;
            this.xrLabel79.WordWrap = false;
            // 
            // xrLabel58
            // 
            this.xrLabel58.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel58.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel58.CanGrow = false;
            this.xrLabel58.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.C_DEP")});
            this.xrLabel58.Dpi = 100F;
            this.xrLabel58.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel58.LocationFloat = new DevExpress.Utils.PointFloat(1562.5F, 0F);
            this.xrLabel58.Name = "xrLabel58";
            this.xrLabel58.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel58.SizeF = new System.Drawing.SizeF(100F, 37.5F);
            this.xrLabel58.StylePriority.UseBorderDashStyle = false;
            this.xrLabel58.StylePriority.UseBorders = false;
            this.xrLabel58.StylePriority.UseFont = false;
            this.xrLabel58.StylePriority.UseTextAlignment = false;
            xrSummary35.FormatString = "{0:n2}";
            xrSummary35.IgnoreNullValues = true;
            xrSummary35.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel58.Summary = xrSummary35;
            this.xrLabel58.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel57
            // 
            this.xrLabel57.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel57.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel57.CanGrow = false;
            this.xrLabel57.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.S_ITEM_AMOUNT")});
            this.xrLabel57.Dpi = 100F;
            this.xrLabel57.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel57.ForeColor = System.Drawing.Color.Black;
            this.xrLabel57.LocationFloat = new DevExpress.Utils.PointFloat(1450F, 0F);
            this.xrLabel57.Name = "xrLabel57";
            this.xrLabel57.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel57.SizeF = new System.Drawing.SizeF(112.5F, 37.5F);
            this.xrLabel57.StylePriority.UseBorderDashStyle = false;
            this.xrLabel57.StylePriority.UseBorders = false;
            this.xrLabel57.StylePriority.UseFont = false;
            this.xrLabel57.StylePriority.UseForeColor = false;
            this.xrLabel57.StylePriority.UseTextAlignment = false;
            xrSummary36.FormatString = "{0:n2}";
            xrSummary36.IgnoreNullValues = true;
            xrSummary36.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel57.Summary = xrSummary36;
            this.xrLabel57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel56
            // 
            this.xrLabel56.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel56.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel56.CanGrow = false;
            this.xrLabel56.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT_03")});
            this.xrLabel56.Dpi = 100F;
            this.xrLabel56.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel56.ForeColor = System.Drawing.Color.Black;
            this.xrLabel56.LocationFloat = new DevExpress.Utils.PointFloat(1375F, 0F);
            this.xrLabel56.Name = "xrLabel56";
            this.xrLabel56.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel56.SizeF = new System.Drawing.SizeF(75F, 37.5F);
            this.xrLabel56.StylePriority.UseBorderDashStyle = false;
            this.xrLabel56.StylePriority.UseBorders = false;
            this.xrLabel56.StylePriority.UseFont = false;
            this.xrLabel56.StylePriority.UseForeColor = false;
            this.xrLabel56.StylePriority.UseTextAlignment = false;
            xrSummary37.FormatString = "{0:n2}";
            xrSummary37.IgnoreNullValues = true;
            xrSummary37.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel56.Summary = xrSummary37;
            this.xrLabel56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel55
            // 
            this.xrLabel55.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel55.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel55.CanGrow = false;
            this.xrLabel55.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT_03")});
            this.xrLabel55.Dpi = 100F;
            this.xrLabel55.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel55.ForeColor = System.Drawing.Color.Black;
            this.xrLabel55.LocationFloat = new DevExpress.Utils.PointFloat(1275F, 0F);
            this.xrLabel55.Name = "xrLabel55";
            this.xrLabel55.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel55.SizeF = new System.Drawing.SizeF(100F, 37.5F);
            this.xrLabel55.StylePriority.UseBorderDashStyle = false;
            this.xrLabel55.StylePriority.UseBorders = false;
            this.xrLabel55.StylePriority.UseFont = false;
            this.xrLabel55.StylePriority.UseForeColor = false;
            this.xrLabel55.StylePriority.UseTextAlignment = false;
            xrSummary38.FormatString = "{0:n2}";
            xrSummary38.IgnoreNullValues = true;
            xrSummary38.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel55.Summary = xrSummary38;
            this.xrLabel55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel55.WordWrap = false;
            // 
            // xrLabel48
            // 
            this.xrLabel48.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel48.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel48.CanGrow = false;
            this.xrLabel48.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.COUNT_01")});
            this.xrLabel48.Dpi = 100F;
            this.xrLabel48.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel48.ForeColor = System.Drawing.Color.Black;
            this.xrLabel48.LocationFloat = new DevExpress.Utils.PointFloat(662.5F, 0F);
            this.xrLabel48.Name = "xrLabel48";
            this.xrLabel48.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel48.SizeF = new System.Drawing.SizeF(87.5F, 37.5F);
            this.xrLabel48.StylePriority.UseBorderDashStyle = false;
            this.xrLabel48.StylePriority.UseBorders = false;
            this.xrLabel48.StylePriority.UseFont = false;
            this.xrLabel48.StylePriority.UseForeColor = false;
            this.xrLabel48.StylePriority.UseTextAlignment = false;
            xrSummary39.FormatString = "{0:#,0} ราย";
            xrSummary39.IgnoreNullValues = true;
            xrSummary39.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel48.Summary = xrSummary39;
            this.xrLabel48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel48.WordWrap = false;
            // 
            // xrLabel51
            // 
            this.xrLabel51.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel51.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel51.CanGrow = false;
            this.xrLabel51.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.COUNT_02")});
            this.xrLabel51.Dpi = 100F;
            this.xrLabel51.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel51.ForeColor = System.Drawing.Color.Black;
            this.xrLabel51.LocationFloat = new DevExpress.Utils.PointFloat(925F, 0F);
            this.xrLabel51.Name = "xrLabel51";
            this.xrLabel51.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel51.SizeF = new System.Drawing.SizeF(87.5F, 37.5F);
            this.xrLabel51.StylePriority.UseBorderDashStyle = false;
            this.xrLabel51.StylePriority.UseBorders = false;
            this.xrLabel51.StylePriority.UseFont = false;
            this.xrLabel51.StylePriority.UseForeColor = false;
            this.xrLabel51.StylePriority.UseTextAlignment = false;
            xrSummary40.FormatString = "{0:#,0} ราย";
            xrSummary40.IgnoreNullValues = true;
            xrSummary40.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel51.Summary = xrSummary40;
            this.xrLabel51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel51.WordWrap = false;
            // 
            // xrLabel54
            // 
            this.xrLabel54.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel54.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel54.CanGrow = false;
            this.xrLabel54.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.COUNT_03")});
            this.xrLabel54.Dpi = 100F;
            this.xrLabel54.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel54.ForeColor = System.Drawing.Color.Black;
            this.xrLabel54.LocationFloat = new DevExpress.Utils.PointFloat(1187.5F, 0F);
            this.xrLabel54.Name = "xrLabel54";
            this.xrLabel54.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel54.SizeF = new System.Drawing.SizeF(87.5F, 37.5F);
            this.xrLabel54.StylePriority.UseBorderDashStyle = false;
            this.xrLabel54.StylePriority.UseBorders = false;
            this.xrLabel54.StylePriority.UseFont = false;
            this.xrLabel54.StylePriority.UseForeColor = false;
            this.xrLabel54.StylePriority.UseTextAlignment = false;
            xrSummary41.FormatString = "{0:#,0} ราย";
            xrSummary41.IgnoreNullValues = true;
            xrSummary41.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel54.Summary = xrSummary41;
            this.xrLabel54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel54.WordWrap = false;
            // 
            // xrLabel52
            // 
            this.xrLabel52.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel52.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel52.CanGrow = false;
            this.xrLabel52.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT_02")});
            this.xrLabel52.Dpi = 100F;
            this.xrLabel52.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel52.ForeColor = System.Drawing.Color.Black;
            this.xrLabel52.LocationFloat = new DevExpress.Utils.PointFloat(1112.5F, 0F);
            this.xrLabel52.Name = "xrLabel52";
            this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel52.SizeF = new System.Drawing.SizeF(75F, 37.5F);
            this.xrLabel52.StylePriority.UseBorderDashStyle = false;
            this.xrLabel52.StylePriority.UseBorders = false;
            this.xrLabel52.StylePriority.UseFont = false;
            this.xrLabel52.StylePriority.UseForeColor = false;
            this.xrLabel52.StylePriority.UseTextAlignment = false;
            xrSummary42.FormatString = "{0:n2}";
            xrSummary42.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel52.Summary = xrSummary42;
            this.xrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel52.WordWrap = false;
            // 
            // xrLabel53
            // 
            this.xrLabel53.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel53.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel53.CanGrow = false;
            this.xrLabel53.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT_02")});
            this.xrLabel53.Dpi = 100F;
            this.xrLabel53.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel53.ForeColor = System.Drawing.Color.Black;
            this.xrLabel53.LocationFloat = new DevExpress.Utils.PointFloat(1012.5F, 0F);
            this.xrLabel53.Name = "xrLabel53";
            this.xrLabel53.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel53.SizeF = new System.Drawing.SizeF(100F, 37.5F);
            this.xrLabel53.StylePriority.UseBorderDashStyle = false;
            this.xrLabel53.StylePriority.UseBorders = false;
            this.xrLabel53.StylePriority.UseFont = false;
            this.xrLabel53.StylePriority.UseForeColor = false;
            this.xrLabel53.StylePriority.UseTextAlignment = false;
            xrSummary43.FormatString = "{0:n2}";
            xrSummary43.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel53.Summary = xrSummary43;
            this.xrLabel53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel53.WordWrap = false;
            // 
            // xrLabel49
            // 
            this.xrLabel49.BackColor = System.Drawing.Color.White;
            this.xrLabel49.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel49.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel49.CanGrow = false;
            this.xrLabel49.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT_01")});
            this.xrLabel49.Dpi = 100F;
            this.xrLabel49.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel49.ForeColor = System.Drawing.Color.Black;
            this.xrLabel49.LocationFloat = new DevExpress.Utils.PointFloat(750F, 0F);
            this.xrLabel49.Name = "xrLabel49";
            this.xrLabel49.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel49.SizeF = new System.Drawing.SizeF(100F, 37.5F);
            this.xrLabel49.StylePriority.UseBackColor = false;
            this.xrLabel49.StylePriority.UseBorderDashStyle = false;
            this.xrLabel49.StylePriority.UseBorders = false;
            this.xrLabel49.StylePriority.UseFont = false;
            this.xrLabel49.StylePriority.UseForeColor = false;
            this.xrLabel49.StylePriority.UseTextAlignment = false;
            xrSummary44.FormatString = "{0:n2}";
            xrSummary44.IgnoreNullValues = true;
            xrSummary44.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel49.Summary = xrSummary44;
            this.xrLabel49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel50
            // 
            this.xrLabel50.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel50.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel50.CanGrow = false;
            this.xrLabel50.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT_01")});
            this.xrLabel50.Dpi = 100F;
            this.xrLabel50.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel50.ForeColor = System.Drawing.Color.Black;
            this.xrLabel50.LocationFloat = new DevExpress.Utils.PointFloat(850F, 0F);
            this.xrLabel50.Name = "xrLabel50";
            this.xrLabel50.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel50.SizeF = new System.Drawing.SizeF(75F, 37.5F);
            this.xrLabel50.StylePriority.UseBorderDashStyle = false;
            this.xrLabel50.StylePriority.UseBorders = false;
            this.xrLabel50.StylePriority.UseFont = false;
            this.xrLabel50.StylePriority.UseForeColor = false;
            this.xrLabel50.StylePriority.UseTextAlignment = false;
            xrSummary45.FormatString = "{0:n2}";
            xrSummary45.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel50.Summary = xrSummary45;
            this.xrLabel50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel47
            // 
            this.xrLabel47.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel47.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel47.CanGrow = false;
            this.xrLabel47.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FREE_AMOUNT")});
            this.xrLabel47.Dpi = 100F;
            this.xrLabel47.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel47.LocationFloat = new DevExpress.Utils.PointFloat(525F, 0F);
            this.xrLabel47.Name = "xrLabel47";
            this.xrLabel47.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel47.SizeF = new System.Drawing.SizeF(75F, 37.5F);
            this.xrLabel47.StylePriority.UseBorderDashStyle = false;
            this.xrLabel47.StylePriority.UseBorders = false;
            this.xrLabel47.StylePriority.UseFont = false;
            this.xrLabel47.StylePriority.UseTextAlignment = false;
            xrSummary46.FormatString = "{0:#,##0.00;,#,##0.00;-}";
            xrSummary46.IgnoreNullValues = true;
            xrSummary46.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel47.Summary = xrSummary46;
            this.xrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel47.WordWrap = false;
            // 
            // xrLabel46
            // 
            this.xrLabel46.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel46.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel46.CanGrow = false;
            this.xrLabel46.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.BY_SHARE")});
            this.xrLabel46.Dpi = 100F;
            this.xrLabel46.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(437.5F, 0F);
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(87.5F, 37.5F);
            this.xrLabel46.StylePriority.UseBorderDashStyle = false;
            this.xrLabel46.StylePriority.UseBorders = false;
            this.xrLabel46.StylePriority.UseFont = false;
            this.xrLabel46.StylePriority.UseTextAlignment = false;
            xrSummary47.FormatString = "{0:#,##0.00;,#,##0.00;-}";
            xrSummary47.IgnoreNullValues = true;
            xrSummary47.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel46.Summary = xrSummary47;
            this.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel46.WordWrap = false;
            // 
            // xrLabel45
            // 
            this.xrLabel45.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel45.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel45.CanGrow = false;
            this.xrLabel45.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FUND_NEW")});
            this.xrLabel45.Dpi = 100F;
            this.xrLabel45.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(337.5F, 0F);
            this.xrLabel45.Name = "xrLabel45";
            this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel45.SizeF = new System.Drawing.SizeF(100F, 37.5F);
            this.xrLabel45.StylePriority.UseBorderDashStyle = false;
            this.xrLabel45.StylePriority.UseBorders = false;
            this.xrLabel45.StylePriority.UseFont = false;
            this.xrLabel45.StylePriority.UseTextAlignment = false;
            xrSummary48.FormatString = "{0:#,##0.00;,#,##0.00;-}";
            xrSummary48.IgnoreNullValues = true;
            xrSummary48.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel45.Summary = xrSummary48;
            this.xrLabel45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel45.WordWrap = false;
            // 
            // xrLabel44
            // 
            this.xrLabel44.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel44.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel44.CanGrow = false;
            this.xrLabel44.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.RECEIPT_DATE", "รวมการชำระพิเศษในวันที่  : {0:dd/MM/yyyy}")});
            this.xrLabel44.Dpi = 100F;
            this.xrLabel44.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel44.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel44.Name = "xrLabel44";
            this.xrLabel44.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel44.SizeF = new System.Drawing.SizeF(337.5F, 37.5F);
            this.xrLabel44.StylePriority.UseBorderDashStyle = false;
            this.xrLabel44.StylePriority.UseBorders = false;
            this.xrLabel44.StylePriority.UseFont = false;
            this.xrLabel44.StylePriority.UseTextAlignment = false;
            this.xrLabel44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel146
            // 
            this.xrLabel146.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel146.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel146.CanGrow = false;
            this.xrLabel146.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FEE")});
            this.xrLabel146.Dpi = 100F;
            this.xrLabel146.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel146.LocationFloat = new DevExpress.Utils.PointFloat(600F, 0F);
            this.xrLabel146.Name = "xrLabel146";
            this.xrLabel146.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel146.SizeF = new System.Drawing.SizeF(62.5F, 37.5F);
            this.xrLabel146.StylePriority.UseBorderDashStyle = false;
            this.xrLabel146.StylePriority.UseBorders = false;
            this.xrLabel146.StylePriority.UseFont = false;
            this.xrLabel146.StylePriority.UseTextAlignment = false;
            xrSummary49.FormatString = "{0:#,##0.00;,#,##0.00;-}";
            xrSummary49.IgnoreNullValues = true;
            xrSummary49.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel146.Summary = xrSummary49;
            this.xrLabel146.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel146.WordWrap = false;
            // 
            // sum
            // 
            this.sum.DataMember = "Query";
            this.sum.Expression = "[EMER_PRINCIPAL] + [NORM_PRINCIPAL] + [SPEC_PRINCIPAL]";
            this.sum.Name = "sum";
            // 
            // sum_int
            // 
            this.sum_int.DataMember = "Query";
            this.sum_int.Expression = "[EMER_INTEREST] + [NORM_INTEREST] + [SPEC_INTEREST]";
            this.sum_int.Name = "sum_int";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel59,
            this.xrLabel60,
            this.xrLabel61,
            this.xrLabel62,
            this.xrLabel63,
            this.xrLabel13,
            this.xrLabel33,
            this.xrLabel34,
            this.xrLabel67,
            this.xrLabel68,
            this.xrLabel69,
            this.xrLabel70,
            this.xrLabel71,
            this.xrLabel72,
            this.xrLabel73,
            this.xrLabel74,
            this.xrLabel75,
            this.xrLabel76,
            this.xrLabel77,
            this.xrLabel78,
            this.xrLabel96,
            this.xrLabel97,
            this.nest_emer_sum,
            this.nest_norm_sum,
            this.nest_spec_sum,
            this.loan_code,
            this.xrLabel37,
            this.xrLabel38,
            this.xrLabel140,
            this.xrLabel153,
            this.xrLabel152,
            this.xrLabel151,
            this.xrLabel150,
            this.xrLabel149,
            this.xrLabel177,
            this.xrLabel178,
            this.xrLabel134,
            this.xrLabel40,
            this.xrLabel39,
            this.xrLabel36,
            this.xrLabel137,
            this.xrLabel136,
            this.xrLabel135,
            this.xrLabel43,
            this.xrLabel142,
            this.xrLabel139,
            this.xrLabel138,
            this.xrLabel35,
            this.xrLabel95,
            this.xrLabel94,
            this.xrLabel93,
            this.xrLabel92,
            this.xrLabel91,
            this.xrLabel90,
            this.xrLabel89,
            this.xrLabel88,
            this.xrLabel87,
            this.xrLabel86,
            this.xrLabel85,
            this.xrLabel84,
            this.xrLabel83,
            this.xrLabel82,
            this.xrLabel81,
            this.xrLabel80,
            this.xrLabel147});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.Font = new System.Drawing.Font("BrowalliaUPC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportFooter.HeightF = 298.75F;
            this.ReportFooter.KeepTogether = true;
            this.ReportFooter.LockedInUserDesigner = true;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.StylePriority.UseFont = false;
            this.ReportFooter.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.ReportFooter_BeforePrint);
            // 
            // xrLabel59
            // 
            this.xrLabel59.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel59.CanGrow = false;
            this.xrLabel59.Dpi = 100F;
            this.xrLabel59.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel59.LocationFloat = new DevExpress.Utils.PointFloat(1387.5F, 48.74999F);
            this.xrLabel59.Name = "xrLabel59";
            this.xrLabel59.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel59.SizeF = new System.Drawing.SizeF(300F, 37.5F);
            this.xrLabel59.StylePriority.UseBorders = false;
            this.xrLabel59.StylePriority.UseFont = false;
            this.xrLabel59.StylePriority.UseTextAlignment = false;
            this.xrLabel59.Text = "สรุป";
            this.xrLabel59.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel60
            // 
            this.xrLabel60.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel60.CanGrow = false;
            this.xrLabel60.Dpi = 100F;
            this.xrLabel60.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel60.LocationFloat = new DevExpress.Utils.PointFloat(1387.5F, 86.24998F);
            this.xrLabel60.Name = "xrLabel60";
            this.xrLabel60.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel60.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel60.StylePriority.UseBorders = false;
            this.xrLabel60.StylePriority.UseFont = false;
            this.xrLabel60.StylePriority.UseTextAlignment = false;
            this.xrLabel60.Text = "ประเภท";
            this.xrLabel60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel61
            // 
            this.xrLabel61.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel61.CanGrow = false;
            this.xrLabel61.Dpi = 100F;
            this.xrLabel61.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel61.LocationFloat = new DevExpress.Utils.PointFloat(1475F, 86.24998F);
            this.xrLabel61.Name = "xrLabel61";
            this.xrLabel61.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel61.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel61.StylePriority.UseBorders = false;
            this.xrLabel61.StylePriority.UseFont = false;
            this.xrLabel61.StylePriority.UseTextAlignment = false;
            this.xrLabel61.Text = "เงินต้น";
            this.xrLabel61.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel62
            // 
            this.xrLabel62.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel62.CanGrow = false;
            this.xrLabel62.Dpi = 100F;
            this.xrLabel62.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel62.LocationFloat = new DevExpress.Utils.PointFloat(1587.5F, 86.24998F);
            this.xrLabel62.Name = "xrLabel62";
            this.xrLabel62.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel62.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel62.StylePriority.UseBorders = false;
            this.xrLabel62.StylePriority.UseFont = false;
            this.xrLabel62.StylePriority.UseTextAlignment = false;
            this.xrLabel62.Text = "ดอกเบี้ย";
            this.xrLabel62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel63
            // 
            this.xrLabel63.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel63.CanGrow = false;
            this.xrLabel63.Dpi = 100F;
            this.xrLabel63.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel63.LocationFloat = new DevExpress.Utils.PointFloat(1387.5F, 111.25F);
            this.xrLabel63.Name = "xrLabel63";
            this.xrLabel63.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel63.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel63.StylePriority.UseBorders = false;
            this.xrLabel63.StylePriority.UseFont = false;
            this.xrLabel63.StylePriority.UseTextAlignment = false;
            this.xrLabel63.Text = "เงินกู้ฉุกเฉิน";
            this.xrLabel63.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel13.CanGrow = false;
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(1387.5F, 136.25F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel13.StylePriority.UseBorders = false;
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "เงินกู้สามัญ";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel33
            // 
            this.xrLabel33.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel33.CanGrow = false;
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(1387.5F, 161.25F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel33.StylePriority.UseBorders = false;
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "เงินกู้พิเศษ";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel34
            // 
            this.xrLabel34.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel34.CanGrow = false;
            this.xrLabel34.Dpi = 100F;
            this.xrLabel34.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(1387.5F, 211.25F);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel34.StylePriority.UseBorders = false;
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.StylePriority.UseTextAlignment = false;
            this.xrLabel34.Text = "ซื้อหุ้น";
            this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel67
            // 
            this.xrLabel67.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel67.CanGrow = false;
            this.xrLabel67.Dpi = 100F;
            this.xrLabel67.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel67.LocationFloat = new DevExpress.Utils.PointFloat(1387.5F, 248.75F);
            this.xrLabel67.Name = "xrLabel67";
            this.xrLabel67.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel67.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel67.StylePriority.UseBorders = false;
            this.xrLabel67.StylePriority.UseFont = false;
            this.xrLabel67.StylePriority.UseTextAlignment = false;
            this.xrLabel67.Text = "ชำระอื่น ๆ";
            this.xrLabel67.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel68
            // 
            this.xrLabel68.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel68.CanGrow = false;
            this.xrLabel68.Dpi = 100F;
            this.xrLabel68.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel68.LocationFloat = new DevExpress.Utils.PointFloat(1387.5F, 186.25F);
            this.xrLabel68.Name = "xrLabel68";
            this.xrLabel68.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel68.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel68.StylePriority.UseBorders = false;
            this.xrLabel68.StylePriority.UseFont = false;
            // 
            // xrLabel69
            // 
            this.xrLabel69.CanGrow = false;
            this.xrLabel69.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT_01")});
            this.xrLabel69.Dpi = 100F;
            this.xrLabel69.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel69.LocationFloat = new DevExpress.Utils.PointFloat(1475F, 111.25F);
            this.xrLabel69.Name = "xrLabel69";
            this.xrLabel69.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel69.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel69.StylePriority.UseFont = false;
            this.xrLabel69.StylePriority.UseTextAlignment = false;
            xrSummary50.FormatString = "{0:n2}";
            xrSummary50.IgnoreNullValues = true;
            xrSummary50.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel69.Summary = xrSummary50;
            this.xrLabel69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel70
            // 
            this.xrLabel70.CanGrow = false;
            this.xrLabel70.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT_02")});
            this.xrLabel70.Dpi = 100F;
            this.xrLabel70.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel70.LocationFloat = new DevExpress.Utils.PointFloat(1475F, 136.25F);
            this.xrLabel70.Name = "xrLabel70";
            this.xrLabel70.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel70.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel70.StylePriority.UseFont = false;
            this.xrLabel70.StylePriority.UseTextAlignment = false;
            xrSummary51.FormatString = "{0:n2}";
            xrSummary51.IgnoreNullValues = true;
            xrSummary51.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel70.Summary = xrSummary51;
            this.xrLabel70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel71
            // 
            this.xrLabel71.CanGrow = false;
            this.xrLabel71.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT_03")});
            this.xrLabel71.Dpi = 100F;
            this.xrLabel71.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel71.LocationFloat = new DevExpress.Utils.PointFloat(1475F, 161.25F);
            this.xrLabel71.Name = "xrLabel71";
            this.xrLabel71.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel71.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel71.StylePriority.UseFont = false;
            this.xrLabel71.StylePriority.UseTextAlignment = false;
            xrSummary52.FormatString = "{0:n2}";
            xrSummary52.IgnoreNullValues = true;
            xrSummary52.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel71.Summary = xrSummary52;
            this.xrLabel71.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel72
            // 
            this.xrLabel72.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel72.CanGrow = false;
            this.xrLabel72.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.sum_principal_amount", "{0:n2}")});
            this.xrLabel72.Dpi = 100F;
            this.xrLabel72.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel72.LocationFloat = new DevExpress.Utils.PointFloat(1475F, 186.25F);
            this.xrLabel72.Name = "xrLabel72";
            this.xrLabel72.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel72.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel72.StylePriority.UseBorders = false;
            this.xrLabel72.StylePriority.UseFont = false;
            this.xrLabel72.StylePriority.UseTextAlignment = false;
            this.xrLabel72.Text = "xrLabel72";
            this.xrLabel72.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel73
            // 
            this.xrLabel73.CanGrow = false;
            this.xrLabel73.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.BY_SHARE")});
            this.xrLabel73.Dpi = 100F;
            this.xrLabel73.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel73.LocationFloat = new DevExpress.Utils.PointFloat(1475F, 211.25F);
            this.xrLabel73.Name = "xrLabel73";
            this.xrLabel73.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel73.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel73.StylePriority.UseFont = false;
            this.xrLabel73.StylePriority.UseTextAlignment = false;
            xrSummary53.FormatString = "{0:n2}";
            xrSummary53.IgnoreNullValues = true;
            xrSummary53.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel73.Summary = xrSummary53;
            this.xrLabel73.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel74
            // 
            this.xrLabel74.CanGrow = false;
            this.xrLabel74.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_other_payments")});
            this.xrLabel74.Dpi = 100F;
            this.xrLabel74.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel74.LocationFloat = new DevExpress.Utils.PointFloat(1475F, 248.75F);
            this.xrLabel74.Name = "xrLabel74";
            this.xrLabel74.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel74.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel74.StylePriority.UseFont = false;
            this.xrLabel74.StylePriority.UseTextAlignment = false;
            xrSummary54.FormatString = "{0:n2}";
            xrSummary54.IgnoreNullValues = true;
            xrSummary54.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel74.Summary = xrSummary54;
            this.xrLabel74.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel75
            // 
            this.xrLabel75.CanGrow = false;
            this.xrLabel75.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT_01")});
            this.xrLabel75.Dpi = 100F;
            this.xrLabel75.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel75.LocationFloat = new DevExpress.Utils.PointFloat(1587.5F, 111.25F);
            this.xrLabel75.Name = "xrLabel75";
            this.xrLabel75.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel75.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel75.StylePriority.UseFont = false;
            this.xrLabel75.StylePriority.UseTextAlignment = false;
            xrSummary55.FormatString = "{0:n2}";
            xrSummary55.IgnoreNullValues = true;
            xrSummary55.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel75.Summary = xrSummary55;
            this.xrLabel75.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel76
            // 
            this.xrLabel76.CanGrow = false;
            this.xrLabel76.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT_02")});
            this.xrLabel76.Dpi = 100F;
            this.xrLabel76.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel76.LocationFloat = new DevExpress.Utils.PointFloat(1587.5F, 136.25F);
            this.xrLabel76.Name = "xrLabel76";
            this.xrLabel76.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel76.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel76.StylePriority.UseFont = false;
            this.xrLabel76.StylePriority.UseTextAlignment = false;
            xrSummary56.FormatString = "{0:n2}";
            xrSummary56.IgnoreNullValues = true;
            xrSummary56.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel76.Summary = xrSummary56;
            this.xrLabel76.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel77
            // 
            this.xrLabel77.CanGrow = false;
            this.xrLabel77.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT_03")});
            this.xrLabel77.Dpi = 100F;
            this.xrLabel77.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel77.LocationFloat = new DevExpress.Utils.PointFloat(1587.5F, 161.25F);
            this.xrLabel77.Name = "xrLabel77";
            this.xrLabel77.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel77.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel77.StylePriority.UseFont = false;
            this.xrLabel77.StylePriority.UseTextAlignment = false;
            xrSummary57.FormatString = "{0:n2}";
            xrSummary57.IgnoreNullValues = true;
            xrSummary57.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel77.Summary = xrSummary57;
            this.xrLabel77.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel78
            // 
            this.xrLabel78.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel78.CanGrow = false;
            this.xrLabel78.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.sum_interest", "{0:n2}")});
            this.xrLabel78.Dpi = 100F;
            this.xrLabel78.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel78.LocationFloat = new DevExpress.Utils.PointFloat(1587.5F, 186.25F);
            this.xrLabel78.Name = "xrLabel78";
            this.xrLabel78.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel78.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel78.StylePriority.UseBorders = false;
            this.xrLabel78.StylePriority.UseFont = false;
            this.xrLabel78.StylePriority.UseTextAlignment = false;
            this.xrLabel78.Text = "xrLabel78";
            this.xrLabel78.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel96
            // 
            this.xrLabel96.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel96.CanGrow = false;
            this.xrLabel96.Dpi = 100F;
            this.xrLabel96.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel96.LocationFloat = new DevExpress.Utils.PointFloat(1587.5F, 211.25F);
            this.xrLabel96.Name = "xrLabel96";
            this.xrLabel96.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel96.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel96.StylePriority.UseBorders = false;
            this.xrLabel96.StylePriority.UseFont = false;
            // 
            // xrLabel97
            // 
            this.xrLabel97.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel97.CanGrow = false;
            this.xrLabel97.Dpi = 100F;
            this.xrLabel97.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel97.LocationFloat = new DevExpress.Utils.PointFloat(1587.5F, 248.75F);
            this.xrLabel97.Name = "xrLabel97";
            this.xrLabel97.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel97.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrLabel97.StylePriority.UseBorders = false;
            this.xrLabel97.StylePriority.UseFont = false;
            // 
            // nest_emer_sum
            // 
            this.nest_emer_sum.Dpi = 100F;
            this.nest_emer_sum.LocationFloat = new DevExpress.Utils.PointFloat(0F, 111.25F);
            this.nest_emer_sum.Name = "nest_emer_sum";
            this.nest_emer_sum.SizeF = new System.Drawing.SizeF(337.5F, 137.5F);
            this.nest_emer_sum.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.nest_emer_sum_BeforePrint);
            // 
            // nest_norm_sum
            // 
            this.nest_norm_sum.Dpi = 100F;
            this.nest_norm_sum.LocationFloat = new DevExpress.Utils.PointFloat(344.5F, 111.25F);
            this.nest_norm_sum.Name = "nest_norm_sum";
            this.nest_norm_sum.SizeF = new System.Drawing.SizeF(337.5F, 137.5F);
            this.nest_norm_sum.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.nest_norm_sum_BeforePrint);
            // 
            // nest_spec_sum
            // 
            this.nest_spec_sum.Dpi = 100F;
            this.nest_spec_sum.LocationFloat = new DevExpress.Utils.PointFloat(691F, 111.25F);
            this.nest_spec_sum.Name = "nest_spec_sum";
            this.nest_spec_sum.SizeF = new System.Drawing.SizeF(337.5F, 137.5F);
            this.nest_spec_sum.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.nest_spec_sum_BeforePrint);
            // 
            // loan_code
            // 
            this.loan_code.Dpi = 100F;
            this.loan_code.LocationFloat = new DevExpress.Utils.PointFloat(1039.5F, 111.25F);
            this.loan_code.Name = "loan_code";
            this.loan_code.SizeF = new System.Drawing.SizeF(337.5F, 137.5F);
            this.loan_code.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.loan_code_BeforePrint);
            // 
            // xrLabel37
            // 
            this.xrLabel37.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel37.CanGrow = false;
            this.xrLabel37.Dpi = 100F;
            this.xrLabel37.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(0F, 48.74999F);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(337.5F, 37.5F);
            this.xrLabel37.StylePriority.UseBorders = false;
            this.xrLabel37.StylePriority.UseFont = false;
            this.xrLabel37.StylePriority.UseTextAlignment = false;
            this.xrLabel37.Text = "สรุปการชำระตามหมวดเงินกู้ฉุกเฉิน";
            this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel38
            // 
            this.xrLabel38.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel38.CanGrow = false;
            this.xrLabel38.Dpi = 100F;
            this.xrLabel38.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(344.5F, 48.74999F);
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel38.SizeF = new System.Drawing.SizeF(337.5F, 37.5F);
            this.xrLabel38.StylePriority.UseBorders = false;
            this.xrLabel38.StylePriority.UseFont = false;
            this.xrLabel38.StylePriority.UseTextAlignment = false;
            this.xrLabel38.Text = "สรุปการชำระตามหมวดเงินกู้สามัญ";
            this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel140
            // 
            this.xrLabel140.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel140.CanGrow = false;
            this.xrLabel140.Dpi = 100F;
            this.xrLabel140.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel140.LocationFloat = new DevExpress.Utils.PointFloat(691F, 48.74999F);
            this.xrLabel140.Name = "xrLabel140";
            this.xrLabel140.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel140.SizeF = new System.Drawing.SizeF(337.5F, 37.5F);
            this.xrLabel140.StylePriority.UseBorders = false;
            this.xrLabel140.StylePriority.UseFont = false;
            this.xrLabel140.StylePriority.UseTextAlignment = false;
            this.xrLabel140.Text = "สรุปการชำระตามหมวดเงินกู้พิเศษ";
            this.xrLabel140.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel153
            // 
            this.xrLabel153.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel153.CanGrow = false;
            this.xrLabel153.Dpi = 100F;
            this.xrLabel153.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel153.LocationFloat = new DevExpress.Utils.PointFloat(1039.5F, 48.74999F);
            this.xrLabel153.Name = "xrLabel153";
            this.xrLabel153.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel153.SizeF = new System.Drawing.SizeF(337.5F, 37.5F);
            this.xrLabel153.StylePriority.UseBorders = false;
            this.xrLabel153.StylePriority.UseFont = false;
            this.xrLabel153.StylePriority.UseTextAlignment = false;
            this.xrLabel153.Text = "ลูกหนี้ไม่ปกติ";
            this.xrLabel153.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel152
            // 
            this.xrLabel152.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel152.CanGrow = false;
            this.xrLabel152.Dpi = 100F;
            this.xrLabel152.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel152.LocationFloat = new DevExpress.Utils.PointFloat(0F, 86.24998F);
            this.xrLabel152.Name = "xrLabel152";
            this.xrLabel152.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel152.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel152.StylePriority.UseBorders = false;
            this.xrLabel152.StylePriority.UseFont = false;
            this.xrLabel152.StylePriority.UseTextAlignment = false;
            this.xrLabel152.Text = "ประเภท";
            this.xrLabel152.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel151
            // 
            this.xrLabel151.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel151.CanGrow = false;
            this.xrLabel151.Dpi = 100F;
            this.xrLabel151.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel151.LocationFloat = new DevExpress.Utils.PointFloat(112.5F, 86.24998F);
            this.xrLabel151.Name = "xrLabel151";
            this.xrLabel151.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel151.SizeF = new System.Drawing.SizeF(62.5F, 25F);
            this.xrLabel151.StylePriority.UseBorders = false;
            this.xrLabel151.StylePriority.UseFont = false;
            this.xrLabel151.StylePriority.UseTextAlignment = false;
            this.xrLabel151.Text = "จน.";
            this.xrLabel151.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel150
            // 
            this.xrLabel150.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel150.CanGrow = false;
            this.xrLabel150.Dpi = 100F;
            this.xrLabel150.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel150.LocationFloat = new DevExpress.Utils.PointFloat(175F, 86.24998F);
            this.xrLabel150.Name = "xrLabel150";
            this.xrLabel150.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel150.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel150.StylePriority.UseBorders = false;
            this.xrLabel150.StylePriority.UseFont = false;
            this.xrLabel150.StylePriority.UseTextAlignment = false;
            this.xrLabel150.Text = "ต้นเงิน";
            this.xrLabel150.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel149
            // 
            this.xrLabel149.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel149.CanGrow = false;
            this.xrLabel149.Dpi = 100F;
            this.xrLabel149.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel149.LocationFloat = new DevExpress.Utils.PointFloat(262.5F, 86.24998F);
            this.xrLabel149.Name = "xrLabel149";
            this.xrLabel149.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel149.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel149.StylePriority.UseBorders = false;
            this.xrLabel149.StylePriority.UseFont = false;
            this.xrLabel149.StylePriority.UseTextAlignment = false;
            this.xrLabel149.Text = "ดอกเบี้ย";
            this.xrLabel149.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel177
            // 
            this.xrLabel177.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel177.CanGrow = false;
            this.xrLabel177.Dpi = 100F;
            this.xrLabel177.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel177.LocationFloat = new DevExpress.Utils.PointFloat(1387.5F, 273.75F);
            this.xrLabel177.Name = "xrLabel177";
            this.xrLabel177.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel177.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel177.StylePriority.UseBorders = false;
            this.xrLabel177.StylePriority.UseFont = false;
            this.xrLabel177.StylePriority.UseTextAlignment = false;
            this.xrLabel177.Text = "ธ/น  สมัคร";
            this.xrLabel177.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel178
            // 
            this.xrLabel178.CanGrow = false;
            this.xrLabel178.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.c_fee_new")});
            this.xrLabel178.Dpi = 100F;
            this.xrLabel178.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel178.LocationFloat = new DevExpress.Utils.PointFloat(1475F, 273.75F);
            this.xrLabel178.Name = "xrLabel178";
            this.xrLabel178.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel178.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel178.StylePriority.UseFont = false;
            this.xrLabel178.StylePriority.UseTextAlignment = false;
            xrSummary58.FormatString = "{0:n2}";
            xrSummary58.IgnoreNullValues = true;
            xrSummary58.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel178.Summary = xrSummary58;
            this.xrLabel178.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel134
            // 
            this.xrLabel134.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel134.CanGrow = false;
            this.xrLabel134.Dpi = 100F;
            this.xrLabel134.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel134.LocationFloat = new DevExpress.Utils.PointFloat(607F, 86.24998F);
            this.xrLabel134.Name = "xrLabel134";
            this.xrLabel134.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel134.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel134.StylePriority.UseBorders = false;
            this.xrLabel134.StylePriority.UseFont = false;
            this.xrLabel134.StylePriority.UseTextAlignment = false;
            this.xrLabel134.Text = "ดอกเบี้ย";
            this.xrLabel134.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel40
            // 
            this.xrLabel40.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel40.CanGrow = false;
            this.xrLabel40.Dpi = 100F;
            this.xrLabel40.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(519.5F, 86.24998F);
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel40.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel40.StylePriority.UseBorders = false;
            this.xrLabel40.StylePriority.UseFont = false;
            this.xrLabel40.StylePriority.UseTextAlignment = false;
            this.xrLabel40.Text = "ต้นเงิน";
            this.xrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel39
            // 
            this.xrLabel39.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel39.CanGrow = false;
            this.xrLabel39.Dpi = 100F;
            this.xrLabel39.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(457F, 86.24998F);
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(62.5F, 25F);
            this.xrLabel39.StylePriority.UseBorders = false;
            this.xrLabel39.StylePriority.UseFont = false;
            this.xrLabel39.StylePriority.UseTextAlignment = false;
            this.xrLabel39.Text = "จน.";
            this.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel36
            // 
            this.xrLabel36.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel36.CanGrow = false;
            this.xrLabel36.Dpi = 100F;
            this.xrLabel36.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(344.5F, 86.24998F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel36.StylePriority.UseBorders = false;
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.StylePriority.UseTextAlignment = false;
            this.xrLabel36.Text = "ประเภท";
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel137
            // 
            this.xrLabel137.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel137.CanGrow = false;
            this.xrLabel137.Dpi = 100F;
            this.xrLabel137.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel137.LocationFloat = new DevExpress.Utils.PointFloat(953.5F, 86.24998F);
            this.xrLabel137.Name = "xrLabel137";
            this.xrLabel137.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel137.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel137.StylePriority.UseBorders = false;
            this.xrLabel137.StylePriority.UseFont = false;
            this.xrLabel137.StylePriority.UseTextAlignment = false;
            this.xrLabel137.Text = "ดอกเบี้ย";
            this.xrLabel137.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel136
            // 
            this.xrLabel136.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel136.CanGrow = false;
            this.xrLabel136.Dpi = 100F;
            this.xrLabel136.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel136.LocationFloat = new DevExpress.Utils.PointFloat(866F, 86.24998F);
            this.xrLabel136.Name = "xrLabel136";
            this.xrLabel136.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel136.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel136.StylePriority.UseBorders = false;
            this.xrLabel136.StylePriority.UseFont = false;
            this.xrLabel136.StylePriority.UseTextAlignment = false;
            this.xrLabel136.Text = "ต้นเงิน";
            this.xrLabel136.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel135
            // 
            this.xrLabel135.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel135.CanGrow = false;
            this.xrLabel135.Dpi = 100F;
            this.xrLabel135.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel135.LocationFloat = new DevExpress.Utils.PointFloat(803.5F, 86.24998F);
            this.xrLabel135.Name = "xrLabel135";
            this.xrLabel135.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel135.SizeF = new System.Drawing.SizeF(62.5F, 25F);
            this.xrLabel135.StylePriority.UseBorders = false;
            this.xrLabel135.StylePriority.UseFont = false;
            this.xrLabel135.StylePriority.UseTextAlignment = false;
            this.xrLabel135.Text = "จน.";
            this.xrLabel135.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel43
            // 
            this.xrLabel43.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel43.CanGrow = false;
            this.xrLabel43.Dpi = 100F;
            this.xrLabel43.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel43.LocationFloat = new DevExpress.Utils.PointFloat(691F, 86.24998F);
            this.xrLabel43.Name = "xrLabel43";
            this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel43.SizeF = new System.Drawing.SizeF(112.5F, 25F);
            this.xrLabel43.StylePriority.UseBorders = false;
            this.xrLabel43.StylePriority.UseFont = false;
            this.xrLabel43.StylePriority.UseTextAlignment = false;
            this.xrLabel43.Text = "ประเภท";
            this.xrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel142
            // 
            this.xrLabel142.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel142.CanGrow = false;
            this.xrLabel142.Dpi = 100F;
            this.xrLabel142.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel142.LocationFloat = new DevExpress.Utils.PointFloat(1039.5F, 86.24998F);
            this.xrLabel142.Name = "xrLabel142";
            this.xrLabel142.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel142.SizeF = new System.Drawing.SizeF(135.4166F, 25F);
            this.xrLabel142.StylePriority.UseBorders = false;
            this.xrLabel142.StylePriority.UseFont = false;
            this.xrLabel142.StylePriority.UseTextAlignment = false;
            this.xrLabel142.Text = "ประเภท";
            this.xrLabel142.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel139
            // 
            this.xrLabel139.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel139.CanGrow = false;
            this.xrLabel139.Dpi = 100F;
            this.xrLabel139.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel139.LocationFloat = new DevExpress.Utils.PointFloat(1174.917F, 86.24998F);
            this.xrLabel139.Name = "xrLabel139";
            this.xrLabel139.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel139.SizeF = new System.Drawing.SizeF(39.58337F, 25F);
            this.xrLabel139.StylePriority.UseBorders = false;
            this.xrLabel139.StylePriority.UseFont = false;
            this.xrLabel139.StylePriority.UseTextAlignment = false;
            this.xrLabel139.Text = "จน.";
            this.xrLabel139.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel138
            // 
            this.xrLabel138.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel138.CanGrow = false;
            this.xrLabel138.Dpi = 100F;
            this.xrLabel138.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel138.LocationFloat = new DevExpress.Utils.PointFloat(1214.5F, 86.24998F);
            this.xrLabel138.Name = "xrLabel138";
            this.xrLabel138.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel138.SizeF = new System.Drawing.SizeF(87.5F, 25F);
            this.xrLabel138.StylePriority.UseBorders = false;
            this.xrLabel138.StylePriority.UseFont = false;
            this.xrLabel138.StylePriority.UseTextAlignment = false;
            this.xrLabel138.Text = "ต้นเงิน";
            this.xrLabel138.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel35
            // 
            this.xrLabel35.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel35.CanGrow = false;
            this.xrLabel35.Dpi = 100F;
            this.xrLabel35.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(1302F, 86.24998F);
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel35.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrLabel35.StylePriority.UseBorders = false;
            this.xrLabel35.StylePriority.UseFont = false;
            this.xrLabel35.StylePriority.UseTextAlignment = false;
            this.xrLabel35.Text = "ดอกเบี้ย";
            this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel95
            // 
            this.xrLabel95.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel95.CanGrow = false;
            this.xrLabel95.Dpi = 100F;
            this.xrLabel95.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel95.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel95.Name = "xrLabel95";
            this.xrLabel95.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel95.SizeF = new System.Drawing.SizeF(337.5F, 30F);
            this.xrLabel95.StylePriority.UseBorders = false;
            this.xrLabel95.StylePriority.UseFont = false;
            this.xrLabel95.StylePriority.UseTextAlignment = false;
            this.xrLabel95.Text = "รวม ทั้งหมด";
            this.xrLabel95.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel95.WordWrap = false;
            // 
            // xrLabel94
            // 
            this.xrLabel94.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel94.CanGrow = false;
            this.xrLabel94.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FUND_NEW")});
            this.xrLabel94.Dpi = 100F;
            this.xrLabel94.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel94.LocationFloat = new DevExpress.Utils.PointFloat(337.5F, 0F);
            this.xrLabel94.Name = "xrLabel94";
            this.xrLabel94.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel94.SizeF = new System.Drawing.SizeF(100F, 30F);
            this.xrLabel94.StylePriority.UseBorders = false;
            this.xrLabel94.StylePriority.UseFont = false;
            this.xrLabel94.StylePriority.UseTextAlignment = false;
            xrSummary59.FormatString = "{0:n2}";
            xrSummary59.IgnoreNullValues = true;
            xrSummary59.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel94.Summary = xrSummary59;
            this.xrLabel94.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel94.WordWrap = false;
            // 
            // xrLabel93
            // 
            this.xrLabel93.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel93.CanGrow = false;
            this.xrLabel93.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.BY_SHARE")});
            this.xrLabel93.Dpi = 100F;
            this.xrLabel93.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel93.LocationFloat = new DevExpress.Utils.PointFloat(437.5F, 0F);
            this.xrLabel93.Name = "xrLabel93";
            this.xrLabel93.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel93.SizeF = new System.Drawing.SizeF(87.5F, 30F);
            this.xrLabel93.StylePriority.UseBorders = false;
            this.xrLabel93.StylePriority.UseFont = false;
            this.xrLabel93.StylePriority.UseTextAlignment = false;
            xrSummary60.FormatString = "{0:n2}";
            xrSummary60.IgnoreNullValues = true;
            xrSummary60.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel93.Summary = xrSummary60;
            this.xrLabel93.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel92
            // 
            this.xrLabel92.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel92.CanGrow = false;
            this.xrLabel92.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FREE_AMOUNT")});
            this.xrLabel92.Dpi = 100F;
            this.xrLabel92.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel92.LocationFloat = new DevExpress.Utils.PointFloat(525F, 0F);
            this.xrLabel92.Name = "xrLabel92";
            this.xrLabel92.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel92.SizeF = new System.Drawing.SizeF(62.5F, 30F);
            this.xrLabel92.StylePriority.UseBorders = false;
            this.xrLabel92.StylePriority.UseFont = false;
            this.xrLabel92.StylePriority.UseTextAlignment = false;
            xrSummary61.FormatString = "{0:n2}";
            xrSummary61.IgnoreNullValues = true;
            xrSummary61.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel92.Summary = xrSummary61;
            this.xrLabel92.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel91
            // 
            this.xrLabel91.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel91.CanGrow = false;
            this.xrLabel91.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.COUNT_01")});
            this.xrLabel91.Dpi = 100F;
            this.xrLabel91.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel91.ForeColor = System.Drawing.Color.Black;
            this.xrLabel91.LocationFloat = new DevExpress.Utils.PointFloat(662.5F, 0F);
            this.xrLabel91.Name = "xrLabel91";
            this.xrLabel91.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel91.SizeF = new System.Drawing.SizeF(87.5F, 30F);
            this.xrLabel91.StylePriority.UseBorders = false;
            this.xrLabel91.StylePriority.UseFont = false;
            this.xrLabel91.StylePriority.UseForeColor = false;
            this.xrLabel91.StylePriority.UseTextAlignment = false;
            xrSummary62.FormatString = "{0:#,0} ราย";
            xrSummary62.IgnoreNullValues = true;
            xrSummary62.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel91.Summary = xrSummary62;
            this.xrLabel91.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel90
            // 
            this.xrLabel90.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel90.CanGrow = false;
            this.xrLabel90.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT_01")});
            this.xrLabel90.Dpi = 100F;
            this.xrLabel90.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel90.ForeColor = System.Drawing.Color.Black;
            this.xrLabel90.LocationFloat = new DevExpress.Utils.PointFloat(750F, 0F);
            this.xrLabel90.Name = "xrLabel90";
            this.xrLabel90.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel90.SizeF = new System.Drawing.SizeF(100F, 30F);
            this.xrLabel90.StylePriority.UseBorders = false;
            this.xrLabel90.StylePriority.UseFont = false;
            this.xrLabel90.StylePriority.UseForeColor = false;
            this.xrLabel90.StylePriority.UseTextAlignment = false;
            xrSummary63.FormatString = "{0:n2}";
            xrSummary63.IgnoreNullValues = true;
            xrSummary63.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel90.Summary = xrSummary63;
            this.xrLabel90.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel89
            // 
            this.xrLabel89.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel89.CanGrow = false;
            this.xrLabel89.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT_01")});
            this.xrLabel89.Dpi = 100F;
            this.xrLabel89.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel89.ForeColor = System.Drawing.Color.Black;
            this.xrLabel89.LocationFloat = new DevExpress.Utils.PointFloat(850F, 0F);
            this.xrLabel89.Name = "xrLabel89";
            this.xrLabel89.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel89.SizeF = new System.Drawing.SizeF(75F, 30F);
            this.xrLabel89.StylePriority.UseBorders = false;
            this.xrLabel89.StylePriority.UseFont = false;
            this.xrLabel89.StylePriority.UseForeColor = false;
            this.xrLabel89.StylePriority.UseTextAlignment = false;
            xrSummary64.FormatString = "{0:n2}";
            xrSummary64.IgnoreNullValues = true;
            xrSummary64.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel89.Summary = xrSummary64;
            this.xrLabel89.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel89.WordWrap = false;
            // 
            // xrLabel88
            // 
            this.xrLabel88.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel88.CanGrow = false;
            this.xrLabel88.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.COUNT_02")});
            this.xrLabel88.Dpi = 100F;
            this.xrLabel88.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel88.ForeColor = System.Drawing.Color.Black;
            this.xrLabel88.LocationFloat = new DevExpress.Utils.PointFloat(925F, 0F);
            this.xrLabel88.Name = "xrLabel88";
            this.xrLabel88.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel88.SizeF = new System.Drawing.SizeF(87.5F, 30F);
            this.xrLabel88.StylePriority.UseBorders = false;
            this.xrLabel88.StylePriority.UseFont = false;
            this.xrLabel88.StylePriority.UseForeColor = false;
            this.xrLabel88.StylePriority.UseTextAlignment = false;
            xrSummary65.FormatString = "{0:#,0} ราย";
            xrSummary65.IgnoreNullValues = true;
            xrSummary65.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel88.Summary = xrSummary65;
            this.xrLabel88.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel88.WordWrap = false;
            // 
            // xrLabel87
            // 
            this.xrLabel87.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel87.CanGrow = false;
            this.xrLabel87.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT_02")});
            this.xrLabel87.Dpi = 100F;
            this.xrLabel87.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel87.ForeColor = System.Drawing.Color.Black;
            this.xrLabel87.LocationFloat = new DevExpress.Utils.PointFloat(1012.5F, 0F);
            this.xrLabel87.Name = "xrLabel87";
            this.xrLabel87.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel87.SizeF = new System.Drawing.SizeF(100F, 30F);
            this.xrLabel87.StylePriority.UseBorders = false;
            this.xrLabel87.StylePriority.UseFont = false;
            this.xrLabel87.StylePriority.UseForeColor = false;
            this.xrLabel87.StylePriority.UseTextAlignment = false;
            xrSummary66.FormatString = "{0:n2}";
            xrSummary66.IgnoreNullValues = true;
            xrSummary66.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel87.Summary = xrSummary66;
            this.xrLabel87.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel87.WordWrap = false;
            // 
            // xrLabel86
            // 
            this.xrLabel86.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel86.CanGrow = false;
            this.xrLabel86.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT_02")});
            this.xrLabel86.Dpi = 100F;
            this.xrLabel86.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel86.ForeColor = System.Drawing.Color.Black;
            this.xrLabel86.LocationFloat = new DevExpress.Utils.PointFloat(1112.5F, 0F);
            this.xrLabel86.Name = "xrLabel86";
            this.xrLabel86.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel86.SizeF = new System.Drawing.SizeF(75F, 30F);
            this.xrLabel86.StylePriority.UseBorders = false;
            this.xrLabel86.StylePriority.UseFont = false;
            this.xrLabel86.StylePriority.UseForeColor = false;
            this.xrLabel86.StylePriority.UseTextAlignment = false;
            xrSummary67.FormatString = "{0:n2}";
            xrSummary67.IgnoreNullValues = true;
            xrSummary67.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel86.Summary = xrSummary67;
            this.xrLabel86.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel86.WordWrap = false;
            // 
            // xrLabel85
            // 
            this.xrLabel85.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel85.CanGrow = false;
            this.xrLabel85.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.COUNT_03")});
            this.xrLabel85.Dpi = 100F;
            this.xrLabel85.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel85.ForeColor = System.Drawing.Color.Black;
            this.xrLabel85.LocationFloat = new DevExpress.Utils.PointFloat(1187.5F, 0F);
            this.xrLabel85.Name = "xrLabel85";
            this.xrLabel85.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel85.SizeF = new System.Drawing.SizeF(87.5F, 30F);
            this.xrLabel85.StylePriority.UseBorders = false;
            this.xrLabel85.StylePriority.UseFont = false;
            this.xrLabel85.StylePriority.UseForeColor = false;
            this.xrLabel85.StylePriority.UseTextAlignment = false;
            xrSummary68.FormatString = "{0:#,0} ราย";
            xrSummary68.IgnoreNullValues = true;
            xrSummary68.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel85.Summary = xrSummary68;
            this.xrLabel85.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel85.WordWrap = false;
            // 
            // xrLabel84
            // 
            this.xrLabel84.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel84.CanGrow = false;
            this.xrLabel84.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRINCIPAL_AMOUNT_03")});
            this.xrLabel84.Dpi = 100F;
            this.xrLabel84.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel84.ForeColor = System.Drawing.Color.Black;
            this.xrLabel84.LocationFloat = new DevExpress.Utils.PointFloat(1275F, 0F);
            this.xrLabel84.Name = "xrLabel84";
            this.xrLabel84.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel84.SizeF = new System.Drawing.SizeF(100F, 30F);
            this.xrLabel84.StylePriority.UseBorders = false;
            this.xrLabel84.StylePriority.UseFont = false;
            this.xrLabel84.StylePriority.UseForeColor = false;
            this.xrLabel84.StylePriority.UseTextAlignment = false;
            xrSummary69.FormatString = "{0:n2}";
            xrSummary69.IgnoreNullValues = true;
            xrSummary69.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel84.Summary = xrSummary69;
            this.xrLabel84.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel84.WordWrap = false;
            // 
            // xrLabel83
            // 
            this.xrLabel83.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel83.CanGrow = false;
            this.xrLabel83.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.INTEREST_AMOUNT_03")});
            this.xrLabel83.Dpi = 100F;
            this.xrLabel83.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel83.ForeColor = System.Drawing.Color.Black;
            this.xrLabel83.LocationFloat = new DevExpress.Utils.PointFloat(1375F, 0F);
            this.xrLabel83.Name = "xrLabel83";
            this.xrLabel83.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel83.SizeF = new System.Drawing.SizeF(75F, 30F);
            this.xrLabel83.StylePriority.UseBorders = false;
            this.xrLabel83.StylePriority.UseFont = false;
            this.xrLabel83.StylePriority.UseForeColor = false;
            this.xrLabel83.StylePriority.UseTextAlignment = false;
            xrSummary70.FormatString = "{0:n2}";
            xrSummary70.IgnoreNullValues = true;
            xrSummary70.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel83.Summary = xrSummary70;
            this.xrLabel83.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel83.WordWrap = false;
            // 
            // xrLabel82
            // 
            this.xrLabel82.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel82.CanGrow = false;
            this.xrLabel82.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.S_ITEM_AMOUNT")});
            this.xrLabel82.Dpi = 100F;
            this.xrLabel82.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel82.ForeColor = System.Drawing.Color.Black;
            this.xrLabel82.LocationFloat = new DevExpress.Utils.PointFloat(1450F, 0F);
            this.xrLabel82.Name = "xrLabel82";
            this.xrLabel82.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel82.SizeF = new System.Drawing.SizeF(112.5F, 30F);
            this.xrLabel82.StylePriority.UseBorders = false;
            this.xrLabel82.StylePriority.UseFont = false;
            this.xrLabel82.StylePriority.UseForeColor = false;
            this.xrLabel82.StylePriority.UseTextAlignment = false;
            xrSummary71.FormatString = "{0:n2}";
            xrSummary71.IgnoreNullValues = true;
            xrSummary71.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel82.Summary = xrSummary71;
            this.xrLabel82.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel82.WordWrap = false;
            // 
            // xrLabel81
            // 
            this.xrLabel81.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel81.CanGrow = false;
            this.xrLabel81.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.C_DEP")});
            this.xrLabel81.Dpi = 100F;
            this.xrLabel81.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel81.LocationFloat = new DevExpress.Utils.PointFloat(1562.5F, 0F);
            this.xrLabel81.Name = "xrLabel81";
            this.xrLabel81.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel81.SizeF = new System.Drawing.SizeF(100F, 30F);
            this.xrLabel81.StylePriority.UseBorders = false;
            this.xrLabel81.StylePriority.UseFont = false;
            this.xrLabel81.StylePriority.UseTextAlignment = false;
            xrSummary72.FormatString = "{0:n2}";
            xrSummary72.IgnoreNullValues = true;
            xrSummary72.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel81.Summary = xrSummary72;
            this.xrLabel81.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel80
            // 
            this.xrLabel80.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel80.CanGrow = false;
            this.xrLabel80.Dpi = 100F;
            this.xrLabel80.Font = new System.Drawing.Font("CordiaUPC", 10.5F);
            this.xrLabel80.LocationFloat = new DevExpress.Utils.PointFloat(1662.5F, 0F);
            this.xrLabel80.Name = "xrLabel80";
            this.xrLabel80.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel80.SizeF = new System.Drawing.SizeF(62.5F, 30F);
            this.xrLabel80.StylePriority.UseBorders = false;
            this.xrLabel80.StylePriority.UseFont = false;
            this.xrLabel80.WordWrap = false;
            // 
            // xrLabel147
            // 
            this.xrLabel147.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel147.CanGrow = false;
            this.xrLabel147.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FEE")});
            this.xrLabel147.Dpi = 100F;
            this.xrLabel147.Font = new System.Drawing.Font("AngsanaUPC", 16F);
            this.xrLabel147.LocationFloat = new DevExpress.Utils.PointFloat(587.5F, 0F);
            this.xrLabel147.Name = "xrLabel147";
            this.xrLabel147.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel147.SizeF = new System.Drawing.SizeF(75F, 30F);
            this.xrLabel147.StylePriority.UseBorders = false;
            this.xrLabel147.StylePriority.UseFont = false;
            this.xrLabel147.StylePriority.UseTextAlignment = false;
            xrSummary73.FormatString = "{0:n2}";
            xrSummary73.IgnoreNullValues = true;
            xrSummary73.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel147.Summary = xrSummary73;
            this.xrLabel147.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // formattingRule4
            // 
            this.formattingRule4.Condition = "[RECEIPT_MODE]   != [R]";
            // 
            // 
            // 
            this.formattingRule4.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.formattingRule4.Name = "formattingRule4";
            // 
            // formattingRule2
            // 
            this.formattingRule2.Condition = "[RECEIPT_MONTH] == [MONTH_RECEIPT_DATE]";
            // 
            // 
            // 
            this.formattingRule2.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.formattingRule2.Name = "formattingRule2";
            // 
            // formattingRule3
            // 
            this.formattingRule3.Condition = "[MONTH_RECEIPT_DATE]  > [RECEIPT_MONTH]";
            // 
            // 
            // 
            this.formattingRule3.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.formattingRule3.Name = "formattingRule3";
            // 
            // sum_principal_amount
            // 
            this.sum_principal_amount.DataMember = "Query";
            this.sum_principal_amount.Expression = " ToDecimal(Sum([PRINCIPAL_AMOUNT_01]))  +  ToDecimal(Sum([PRINCIPAL_AMOUNT_02])) " +
    "+  ToDecimal(Sum([PRINCIPAL_AMOUNT_03]))";
            this.sum_principal_amount.Name = "sum_principal_amount";
            // 
            // sum_interest
            // 
            this.sum_interest.DataMember = "Query";
            this.sum_interest.Expression = "  ToDecimal(Sum([INTEREST_AMOUNT_01]))  +  ToDecimal(Sum([INTEREST_AMOUNT_02])) +" +
    "  ToDecimal(Sum([INTEREST_AMOUNT_03]))";
            this.sum_interest.Name = "sum_interest";
            // 
            // c_conno1_close
            // 
            this.c_conno1_close.DataMember = "Query";
            this.c_conno1_close.Expression = "Iif(  [PRINCIPAL_01] <= 0  ,0 ,1 )";
            this.c_conno1_close.Name = "c_conno1_close";
            // 
            // c_conno1_still
            // 
            this.c_conno1_still.DataMember = "Query";
            this.c_conno1_still.Expression = "Iif( [PRINCIPAL_01] > 0, 1 ,0 )";
            this.c_conno1_still.Name = "c_conno1_still";
            // 
            // c_emer_balance_close
            // 
            this.c_emer_balance_close.DataMember = "Query";
            this.c_emer_balance_close.Expression = "Iif([c_conno1_close] = 1, [PRINCIPAL_AMOUNT_01]  ,0 )";
            this.c_emer_balance_close.Name = "c_emer_balance_close";
            // 
            // c_emer_balance_still
            // 
            this.c_emer_balance_still.DataMember = "Query";
            this.c_emer_balance_still.Expression = "Iif([c_conno1_still] = 1, [PRINCIPAL_AMOUNT_01] ,0 )";
            this.c_emer_balance_still.Name = "c_emer_balance_still";
            // 
            // c_emer_int_close
            // 
            this.c_emer_int_close.DataMember = "Query";
            this.c_emer_int_close.Expression = "Iif([c_conno1_close] =1, [INTEREST_AMOUNT_01] ,0 )";
            this.c_emer_int_close.Name = "c_emer_int_close";
            // 
            // c_conno2_close
            // 
            this.c_conno2_close.DataMember = "Query";
            this.c_conno2_close.Expression = "Iif(  [PRINCIPAL_02] <= 0  ,0 ,1 )";
            this.c_conno2_close.Name = "c_conno2_close";
            // 
            // c_conno2_still
            // 
            this.c_conno2_still.DataMember = "Query";
            this.c_conno2_still.Expression = "Iif( [PRINCIPAL_02] > 0, 1 , 0 )";
            this.c_conno2_still.Name = "c_conno2_still";
            // 
            // c_norm_balance_close
            // 
            this.c_norm_balance_close.DataMember = "Query";
            this.c_norm_balance_close.Expression = "Iif([c_conno2_close] = 1 , [PRINCIPAL_AMOUNT_02] , 0 )";
            this.c_norm_balance_close.Name = "c_norm_balance_close";
            // 
            // c_norm_balance_still
            // 
            this.c_norm_balance_still.DataMember = "Query";
            this.c_norm_balance_still.Expression = "Iif( [COUNT_02] = 1, [PRINCIPAL_AMOUNT_02] ,0 )";
            this.c_norm_balance_still.Name = "c_norm_balance_still";
            // 
            // c_norm_int_close
            // 
            this.c_norm_int_close.DataMember = "Query";
            this.c_norm_int_close.Expression = "Iif([c_conno2_close] = 1 , [INTEREST_AMOUNT_02] , 0 )";
            this.c_norm_int_close.Name = "c_norm_int_close";
            // 
            // c_norm_int_still
            // 
            this.c_norm_int_still.DataMember = "Query";
            this.c_norm_int_still.Expression = "Iif([c_conno2_still] = 1, [INTEREST_AMOUNT_02] ,0 )";
            this.c_norm_int_still.Name = "c_norm_int_still";
            // 
            // c_conno3_close
            // 
            this.c_conno3_close.DataMember = "Query";
            this.c_conno3_close.Expression = "Iif(  [PRINCIPAL_03] <= 0  ,0 ,1 )";
            this.c_conno3_close.Name = "c_conno3_close";
            // 
            // c_conno3_still
            // 
            this.c_conno3_still.DataMember = "Query";
            this.c_conno3_still.Expression = "Iif( [PRINCIPAL_03] > 0, 1 ,0 )";
            this.c_conno3_still.Name = "c_conno3_still";
            // 
            // c_spec_balance_close
            // 
            this.c_spec_balance_close.DataMember = "Query";
            this.c_spec_balance_close.Expression = "Iif([c_conno3_close] = 1,[PRINCIPAL_AMOUNT_03],0 )";
            this.c_spec_balance_close.Name = "c_spec_balance_close";
            // 
            // c_spec_balance_still
            // 
            this.c_spec_balance_still.DataMember = "Query";
            this.c_spec_balance_still.Expression = "Iif([c_conno3_still] = 1, [PRINCIPAL_AMOUNT_03] ,0 )";
            this.c_spec_balance_still.Name = "c_spec_balance_still";
            // 
            // c_spec_int_close
            // 
            this.c_spec_int_close.DataMember = "Query";
            this.c_spec_int_close.Expression = "Iif([c_conno3_close] = 1, [INTEREST_AMOUNT_03] ,0 )";
            this.c_spec_int_close.Name = "c_spec_int_close";
            // 
            // c_spec_int_still
            // 
            this.c_spec_int_still.DataMember = "Query";
            this.c_spec_int_still.Expression = "Iif([c_conno3_still] = 1, [INTEREST_AMOUNT_03] ,0 )";
            this.c_spec_int_still.Name = "c_spec_int_still";
            // 
            // c_other_payments
            // 
            this.c_other_payments.DataMember = "Query";
            this.c_other_payments.Expression = "[FUND_NEW] +[FREE_AMOUNT]+[C_DEP]";
            this.c_other_payments.Name = "c_other_payments";
            // 
            // total
            // 
            this.total.DataMember = "Query";
            this.total.Expression = resources.GetString("total.Expression");
            this.total.Name = "total";
            // 
            // calculatedField1
            // 
            this.calculatedField1.DataMember = "Query";
            this.calculatedField1.Expression = resources.GetString("calculatedField1.Expression");
            this.calculatedField1.Name = "calculatedField1";
            // 
            // c_emer_int_still
            // 
            this.c_emer_int_still.DataMember = "Query";
            this.c_emer_int_still.Expression = "Iif([c_conno1_still] = 1, [INTEREST_AMOUNT_01] ,0 )";
            this.c_emer_int_still.Name = "c_emer_int_still";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel8});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("MEMBER_GROUP_TYPE", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 37.5F;
            this.GroupHeader1.KeepTogether = true;
            this.GroupHeader1.Level = 2;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            // 
            // xrLabel8
            // 
            this.xrLabel8.CanGrow = false;
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MEMBER_GROUP_TYPE", "Teller : {0}")});
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("AngsanaUPC", 16F, System.Drawing.FontStyle.Underline);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(112.5F, 37.5F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "xrLabel8";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // C_p_1_in
            // 
            this.C_p_1_in.DataMember = "Query";
            this.C_p_1_in.Expression = "Iif([MONTH_RECEIPT_DATE] == [RECEIPT_MONTH], [R_PRINCIPAL_AMOUNT_01] , 0)";
            this.C_p_1_in.Name = "C_p_1_in";
            // 
            // C_p_2_in
            // 
            this.C_p_2_in.DataMember = "Query";
            this.C_p_2_in.Expression = "Iif([MONTH_RECEIPT_DATE] == [RECEIPT_MONTH], [R_PRINCIPAL_AMOUNT_02] , 0)";
            this.C_p_2_in.Name = "C_p_2_in";
            // 
            // C_p_3_in
            // 
            this.C_p_3_in.DataMember = "Query";
            this.C_p_3_in.Expression = "Iif([MONTH_RECEIPT_DATE] == [RECEIPT_MONTH], [R_PRINCIPAL_AMOUNT_03], 0)";
            this.C_p_3_in.Name = "C_p_3_in";
            // 
            // C_p_1_out
            // 
            this.C_p_1_out.DataMember = "Query";
            this.C_p_1_out.Expression = "Iif([MONTH_RECEIPT_DATE]  >  [RECEIPT_MONTH], [R_PRINCIPAL_AMOUNT_01] , 0)";
            this.C_p_1_out.Name = "C_p_1_out";
            // 
            // C_p_2_out
            // 
            this.C_p_2_out.DataMember = "Query";
            this.C_p_2_out.Expression = "Iif([MONTH_RECEIPT_DATE]  >  [RECEIPT_MONTH], [R_PRINCIPAL_AMOUNT_02], 0)";
            this.C_p_2_out.Name = "C_p_2_out";
            // 
            // C_p_3_out
            // 
            this.C_p_3_out.DataMember = "Query";
            this.C_p_3_out.Expression = "Iif([MONTH_RECEIPT_DATE] >  [RECEIPT_MONTH], [R_PRINCIPAL_AMOUNT_03], 0)";
            this.C_p_3_out.Name = "C_p_3_out";
            // 
            // C_i_1_in
            // 
            this.C_i_1_in.DataMember = "Query";
            this.C_i_1_in.Expression = "Iif([MONTH_RECEIPT_DATE]   ==   [RECEIPT_MONTH], [R_INTEREST_AMOUNT_01], 0)";
            this.C_i_1_in.Name = "C_i_1_in";
            // 
            // C_i_2_in
            // 
            this.C_i_2_in.DataMember = "Query";
            this.C_i_2_in.Expression = "Iif([MONTH_RECEIPT_DATE]   ==   [RECEIPT_MONTH], [R_INTEREST_AMOUNT_02],0)";
            this.C_i_2_in.Name = "C_i_2_in";
            // 
            // C_i_3_in
            // 
            this.C_i_3_in.DataMember = "Query";
            this.C_i_3_in.Expression = "Iif([MONTH_RECEIPT_DATE]   ==   [RECEIPT_MONTH], [R_INTEREST_AMOUNT_03],0)";
            this.C_i_3_in.Name = "C_i_3_in";
            // 
            // C_i_1_out
            // 
            this.C_i_1_out.DataMember = "Query";
            this.C_i_1_out.Expression = "Iif([MONTH_RECEIPT_DATE]    >    [RECEIPT_MONTH], [R_INTEREST_AMOUNT_01], 0)";
            this.C_i_1_out.Name = "C_i_1_out";
            // 
            // C_i_2_out
            // 
            this.C_i_2_out.DataMember = "Query";
            this.C_i_2_out.Expression = "Iif([MONTH_RECEIPT_DATE]    >    [RECEIPT_MONTH], [R_INTEREST_AMOUNT_02],0)";
            this.C_i_2_out.Name = "C_i_2_out";
            // 
            // C_i_3_out
            // 
            this.C_i_3_out.DataMember = "Query";
            this.C_i_3_out.Expression = "Iif([MONTH_RECEIPT_DATE]    >    [RECEIPT_MONTH], [R_INTEREST_AMOUNT_03], 0)";
            this.C_i_3_out.Name = "C_i_3_out";
            // 
            // c_fee_new
            // 
            this.c_fee_new.DataMember = "Query";
            this.c_fee_new.Expression = "[FEE]";
            this.c_fee_new.Name = "c_fee_new";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel66});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("RECEIPT_DATE", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader2.HeightF = 37.5F;
            this.GroupHeader2.KeepTogether = true;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // xrLabel66
            // 
            this.xrLabel66.CanGrow = false;
            this.xrLabel66.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.RECEIPT_DATE", "วันที่  : {0:d MMMM yyyy}")});
            this.xrLabel66.Dpi = 100F;
            this.xrLabel66.Font = new System.Drawing.Font("AngsanaUPC", 16F, System.Drawing.FontStyle.Underline);
            this.xrLabel66.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel66.Name = "xrLabel66";
            this.xrLabel66.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel66.SizeF = new System.Drawing.SizeF(175F, 37.5F);
            this.xrLabel66.StylePriority.UseFont = false;
            // 
            // t_soat
            // 
            this.t_soat.Dpi = 100F;
            this.t_soat.Font = new System.Drawing.Font("BrowalliaUPC", 14F);
            this.t_soat.LocationFloat = new DevExpress.Utils.PointFloat(0F, 39.5F);
            this.t_soat.Name = "t_soat";
            this.t_soat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t_soat.SizeF = new System.Drawing.SizeF(1725F, 30F);
            this.t_soat.StylePriority.UseFont = false;
            this.t_soat.StylePriority.UseTextAlignment = false;
            this.t_soat.Text = "t_soat";
            this.t_soat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // r_ktm_finance_payment_clr
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.PageFooter,
            this.GroupFooter1,
            this.GroupFooter2,
            this.ReportFooter,
            this.GroupHeader1,
            this.GroupHeader2});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.sum,
            this.sum_int,
            this.sum_principal_amount,
            this.sum_interest,
            this.c_conno1_close,
            this.c_conno1_still,
            this.c_emer_balance_close,
            this.c_emer_balance_still,
            this.c_emer_int_close,
            this.c_emer_int_still,
            this.c_conno2_close,
            this.c_conno2_still,
            this.c_norm_balance_close,
            this.c_norm_balance_still,
            this.c_norm_int_close,
            this.c_norm_int_still,
            this.c_conno3_close,
            this.c_conno3_still,
            this.c_spec_balance_close,
            this.c_spec_balance_still,
            this.c_spec_int_close,
            this.c_spec_int_still,
            this.c_other_payments,
            this.total,
            this.calculatedField1,
            this.C_p_1_in,
            this.C_p_2_in,
            this.C_p_3_in,
            this.C_p_1_out,
            this.C_p_2_out,
            this.C_p_3_out,
            this.C_i_1_in,
            this.C_i_2_in,
            this.C_i_3_in,
            this.C_i_1_out,
            this.C_i_2_out,
            this.C_i_3_out,
            this.c_fee_new});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("AngsanaUPC", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.formattingRule2,
            this.formattingRule3,
            this.formattingRule4});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 190);
            this.PageHeight = 1268;
            this.PageWidth = 1752;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A3Extra;
            this.ScriptsSource = "\r\nprivate void xrLabel27_BeforePrint(object sender, System.Drawing.Printing.Print" +
    "EventArgs e) {\r\n }\r\n";
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion
        

        void ofLoaddetail(object sender, string loan_group_code)
        {
            sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcAccount.accEnd.r_ktm_finance_payment_clr_nest_pay_detail"),null, this.GetCurrentColumnValue("RECEIPT_NO"),loan_group_code);

        }

        private void d01_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoaddetail(sender, "01");
        }

        private void d02_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoaddetail(sender, "02");
        }

        private void d03_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoaddetail(sender, "03");
        }



        //  void ofLoadGroupno(object sender, string sqlWhere, params object[] args)
        // {
        //     sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcAccount.accEnd.r_ktm_finance_payment_nest_pay_group"));
        //     sc.report.dataBind(this, sender, sqlWhere, args);
        // }
        void ofLoadsum(object sender, string loan_group_code  ,string loan_code
            )
        {
            sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcAccount.accEnd.r_ktm_finance_payment_clr_nest_emer"),null,this.GetCurrentColumnValue("RECEIPT_NO"),loan_group_code,loan_code);
        }

        private void nest_emer_sum_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoadsum(sender, "01"  , "0");
        }

        private void nest_norm_sum_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoadsum(sender, "02" ,"0");
        }

        private void nest_spec_sum_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ofLoadsum(sender, "03" ,"0");
        }

        private void loan_code_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcAccount.accEnd.r_ktm_finance_payment_clr_nest_loan_code"));
        }

        private void nest_sum_balance_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcAccount.accEnd.r_ktm_finance_payment_clr_nest_sum_balance"),null, this.GetCurrentColumnValue("RECEIPT_DATE"));
        }

        private void nest_sum_balance_1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcAccount.accEnd.r_ktm_finance_payment_clr_nest_sum_balance1"),null, this.GetCurrentColumnValue("RECEIPT_DATE"));
        }

        private void nest_sum_balance_2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcAccount.accEnd.r_ktm_finance_payment_clr_nest_sum_balance2"),null, this.GetCurrentColumnValue("RECEIPT_DATE"));
        }

        private void nest_fund_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sc.report.setNestReport(this, sender, Type.GetType("scReport.Reports.rcAccount.accEnd.r_ktm_finance_payment_clr_nest_fund"),null, this.GetCurrentColumnValue("RECEIPT_DATE"));
        }

        private void ReportFooter_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
