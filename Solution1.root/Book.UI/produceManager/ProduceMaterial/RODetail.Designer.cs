﻿namespace Book.UI.produceManager.ProduceMaterial
{
    partial class RODetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RODetail));
            DevExpress.XtraPrinting.BarCode.EAN128Generator eaN128Generator1 = new DevExpress.XtraPrinting.BarCode.EAN128Generator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrSubreport1 = new DevExpress.XtraReports.UI.XRSubreport();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabelPiHao = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelSourceType = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelInvoiceSum = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelProduct = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelPronoteHeaderID = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelProduceMaterialId = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelInsertTime = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCodeProduceMaterialID = new DevExpress.XtraReports.UI.XRBarCode();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelDepartment = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelProduceMaterialDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelXOId = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelDataName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelCompanyInfoName = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabelCustomer = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreport1});
            resources.ApplyResources(this.Detail, "Detail");
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.StylePriority.UseTextAlignment = false;
            // 
            // xrSubreport1
            // 
            resources.ApplyResources(this.xrSubreport1, "xrSubreport1");
            this.xrSubreport1.Name = "xrSubreport1";
            this.xrSubreport1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.RO_BeforePrint);
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel13,
            this.xrLabelCustomer,
            this.xrLabelPiHao,
            this.xrLabel15,
            this.xrLabelSourceType,
            this.xrLabel14,
            this.xrLabelInvoiceSum,
            this.xrLabel10,
            this.xrLabel12,
            this.xrLabelProduct,
            this.xrLabelPronoteHeaderID,
            this.xrLabel8,
            this.xrLabelProduceMaterialId,
            this.xrLabel1,
            this.xrLabelInsertTime,
            this.xrLabel6,
            this.xrBarCodeProduceMaterialID,
            this.xrLabel3,
            this.xrLabelDepartment,
            this.xrLabel5,
            this.xrLabelProduceMaterialDate,
            this.xrLabelXOId,
            this.xrLabel4,
            this.xrLabelDataName,
            this.xrLabelCompanyInfoName});
            resources.ApplyResources(this.PageHeader, "PageHeader");
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            // 
            // xrLabelPiHao
            // 
            resources.ApplyResources(this.xrLabelPiHao, "xrLabelPiHao");
            this.xrLabelPiHao.Name = "xrLabelPiHao";
            this.xrLabelPiHao.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelPiHao.StylePriority.UseFont = false;
            this.xrLabelPiHao.StylePriority.UseTextAlignment = false;
            // 
            // xrLabel15
            // 
            resources.ApplyResources(this.xrLabel15, "xrLabel15");
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            // 
            // xrLabelSourceType
            // 
            resources.ApplyResources(this.xrLabelSourceType, "xrLabelSourceType");
            this.xrLabelSourceType.Name = "xrLabelSourceType";
            this.xrLabelSourceType.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelSourceType.StylePriority.UseFont = false;
            this.xrLabelSourceType.StylePriority.UseTextAlignment = false;
            // 
            // xrLabel14
            // 
            resources.ApplyResources(this.xrLabel14, "xrLabel14");
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            // 
            // xrLabelInvoiceSum
            // 
            resources.ApplyResources(this.xrLabelInvoiceSum, "xrLabelInvoiceSum");
            this.xrLabelInvoiceSum.Name = "xrLabelInvoiceSum";
            this.xrLabelInvoiceSum.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelInvoiceSum.StylePriority.UseFont = false;
            this.xrLabelInvoiceSum.StylePriority.UseTextAlignment = false;
            // 
            // xrLabel10
            // 
            resources.ApplyResources(this.xrLabel10, "xrLabel10");
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            // 
            // xrLabel12
            // 
            resources.ApplyResources(this.xrLabel12, "xrLabel12");
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            // 
            // xrLabelProduct
            // 
            resources.ApplyResources(this.xrLabelProduct, "xrLabelProduct");
            this.xrLabelProduct.Name = "xrLabelProduct";
            this.xrLabelProduct.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelProduct.StylePriority.UseFont = false;
            this.xrLabelProduct.StylePriority.UseTextAlignment = false;
            // 
            // xrLabelPronoteHeaderID
            // 
            resources.ApplyResources(this.xrLabelPronoteHeaderID, "xrLabelPronoteHeaderID");
            this.xrLabelPronoteHeaderID.Name = "xrLabelPronoteHeaderID";
            this.xrLabelPronoteHeaderID.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelPronoteHeaderID.StylePriority.UseFont = false;
            this.xrLabelPronoteHeaderID.StylePriority.UseTextAlignment = false;
            // 
            // xrLabel8
            // 
            resources.ApplyResources(this.xrLabel8, "xrLabel8");
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            // 
            // xrLabelProduceMaterialId
            // 
            resources.ApplyResources(this.xrLabelProduceMaterialId, "xrLabelProduceMaterialId");
            this.xrLabelProduceMaterialId.Name = "xrLabelProduceMaterialId";
            this.xrLabelProduceMaterialId.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelProduceMaterialId.StylePriority.UseFont = false;
            this.xrLabelProduceMaterialId.StylePriority.UseTextAlignment = false;
            // 
            // xrLabel1
            // 
            resources.ApplyResources(this.xrLabel1, "xrLabel1");
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            // 
            // xrLabelInsertTime
            // 
            resources.ApplyResources(this.xrLabelInsertTime, "xrLabelInsertTime");
            this.xrLabelInsertTime.Multiline = true;
            this.xrLabelInsertTime.Name = "xrLabelInsertTime";
            this.xrLabelInsertTime.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelInsertTime.StylePriority.UseFont = false;
            this.xrLabelInsertTime.StylePriority.UseTextAlignment = false;
            // 
            // xrLabel6
            // 
            resources.ApplyResources(this.xrLabel6, "xrLabel6");
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            // 
            // xrBarCodeProduceMaterialID
            // 
            this.xrBarCodeProduceMaterialID.AutoModule = true;
            resources.ApplyResources(this.xrBarCodeProduceMaterialID, "xrBarCodeProduceMaterialID");
            this.xrBarCodeProduceMaterialID.Module = 5.08F;
            this.xrBarCodeProduceMaterialID.Name = "xrBarCodeProduceMaterialID";
            this.xrBarCodeProduceMaterialID.Padding = new DevExpress.XtraPrinting.PaddingInfo(25, 25, 0, 0, 254F);
            eaN128Generator1.CharacterSet = DevExpress.XtraPrinting.BarCode.Code128Charset.CharsetAuto;
            this.xrBarCodeProduceMaterialID.Symbology = eaN128Generator1;
            // 
            // xrLabel3
            // 
            resources.ApplyResources(this.xrLabel3, "xrLabel3");
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            // 
            // xrLabelDepartment
            // 
            resources.ApplyResources(this.xrLabelDepartment, "xrLabelDepartment");
            this.xrLabelDepartment.Name = "xrLabelDepartment";
            this.xrLabelDepartment.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelDepartment.StylePriority.UseFont = false;
            this.xrLabelDepartment.StylePriority.UseTextAlignment = false;
            // 
            // xrLabel5
            // 
            resources.ApplyResources(this.xrLabel5, "xrLabel5");
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            // 
            // xrLabelProduceMaterialDate
            // 
            resources.ApplyResources(this.xrLabelProduceMaterialDate, "xrLabelProduceMaterialDate");
            this.xrLabelProduceMaterialDate.Name = "xrLabelProduceMaterialDate";
            this.xrLabelProduceMaterialDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelProduceMaterialDate.StylePriority.UseFont = false;
            this.xrLabelProduceMaterialDate.StylePriority.UseTextAlignment = false;
            // 
            // xrLabelXOId
            // 
            resources.ApplyResources(this.xrLabelXOId, "xrLabelXOId");
            this.xrLabelXOId.Name = "xrLabelXOId";
            this.xrLabelXOId.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelXOId.StylePriority.UseFont = false;
            this.xrLabelXOId.StylePriority.UseTextAlignment = false;
            // 
            // xrLabel4
            // 
            resources.ApplyResources(this.xrLabel4, "xrLabel4");
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            // 
            // xrLabelDataName
            // 
            resources.ApplyResources(this.xrLabelDataName, "xrLabelDataName");
            this.xrLabelDataName.Name = "xrLabelDataName";
            this.xrLabelDataName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelDataName.StylePriority.UseFont = false;
            this.xrLabelDataName.StylePriority.UseTextAlignment = false;
            // 
            // xrLabelCompanyInfoName
            // 
            resources.ApplyResources(this.xrLabelCompanyInfoName, "xrLabelCompanyInfoName");
            this.xrLabelCompanyInfoName.Name = "xrLabelCompanyInfoName";
            this.xrLabelCompanyInfoName.Padding = new DevExpress.XtraPrinting.PaddingInfo(13, 13, 0, 0, 254F);
            this.xrLabelCompanyInfoName.StylePriority.UseFont = false;
            this.xrLabelCompanyInfoName.StylePriority.UsePadding = false;
            this.xrLabelCompanyInfoName.StylePriority.UseTextAlignment = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2});
            resources.ApplyResources(this.PageFooter, "PageFooter");
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            // 
            // xrPageInfo2
            // 
            resources.ApplyResources(this.xrPageInfo2, "xrPageInfo2");
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrPageInfo2.StylePriority.UseTextAlignment = false;
            // 
            // ReportHeader
            // 
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            resources.ApplyResources(this.ReportFooter, "ReportFooter");
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.PrintAtBottom = true;
            // 
            // topMarginBand1
            // 
            resources.ApplyResources(this.topMarginBand1, "topMarginBand1");
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            resources.ApplyResources(this.bottomMarginBand1, "bottomMarginBand1");
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // GroupHeader1
            // 
            resources.ApplyResources(this.GroupHeader1, "GroupHeader1");
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            // 
            // xrLabelCustomer
            // 
            resources.ApplyResources(this.xrLabelCustomer, "xrLabelCustomer");
            this.xrLabelCustomer.Name = "xrLabelCustomer";
            this.xrLabelCustomer.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelCustomer.StylePriority.UseFont = false;
            this.xrLabelCustomer.StylePriority.UseTextAlignment = false;
            // 
            // xrLabel13
            // 
            resources.ApplyResources(this.xrLabel13, "xrLabel13");
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            // 
            // RODetail
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.ReportHeader,
            this.ReportFooter,
            this.topMarginBand1,
            this.bottomMarginBand1,
            this.GroupHeader1});
            resources.ApplyResources(this, "$this");
            this.Margins = new System.Drawing.Printing.Margins(150, 80, 79, 79);
            this.PageHeight = 1397;
            this.PageWidth = 2159;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Version = "10.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabelDataName;
        private DevExpress.XtraReports.UI.XRLabel xrLabelCompanyInfoName;
        private DevExpress.XtraReports.UI.XRLabel xrLabelProduceMaterialDate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabelDepartment;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabelXOId;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCodeProduceMaterialID;
        private DevExpress.XtraReports.UI.XRLabel xrLabelInsertTime;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabelProduceMaterialId;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabelPronoteHeaderID;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabelProduct;
        private DevExpress.XtraReports.UI.XRLabel xrLabelInvoiceSum;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabelSourceType;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabelPiHao;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRSubreport xrSubreport1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabelCustomer;
    }
}
