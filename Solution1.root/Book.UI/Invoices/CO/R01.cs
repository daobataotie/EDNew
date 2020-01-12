using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.Invoices.CO
{
    public partial class R01 : DevExpress.XtraReports.UI.XtraReport
    {
        private BL.InvoiceCOManager invoiceCGManager = new Book.BL.InvoiceCOManager();
        private BL.InvoiceCODetailManager invoiceCGDetailManager = new Book.BL.InvoiceCODetailManager();
        private BL.InvoiceXOManager invoiceXoManager = new BL.InvoiceXOManager();
        private Model.InvoiceCO invoice;
        int pp = 0;
        public R01(string invoiceid, string companyName, Model.Supplier supplier)
        {
            InitializeComponent();

            this.invoice = this.invoiceCGManager.Get(invoiceid);


            if (this.invoice == null)
                return;

            // this.invoice.Details = this.invoiceCGDetailManager.Select(this.invoice);
            this.DataSource = this.invoice.Details;
            this.xrBarCode1.Text = this.invoice.InvoiceId;

            //CompanyInfo            
            //this.xrLabelCompanyInfoName.Text = BL.Settings.CompanyChineseName;
            if (string.IsNullOrEmpty(companyName))
                this.xrLabelCompanyInfoName.Text = "ALAN SAFETY COMPANY LIMITED";
            else
            {
                xrLabelCompanyInfoName.HeightF += 100;
                this.xrLabelCompanyInfoName.Text = companyName + "".PadLeft(40, ' ') + "(訂單來源：ALAN SAFETY COMPANY LIMITED)";
            }


            this.xrLabelData.Text = Properties.Resources.InvoiceCO;
            this.xrLabelPrintDate.Text += DateTime.Now.ToShortDateString();

            //供應商信息
            //this.xrLabelCustomName.Text = this.invoice.Supplier.SupplierShortName;
            //this.xrLabelLianluoName.Text = this.invoice.Supplier.SupplierContact;
            //this.xrLabelCustomFax.Text = this.invoice.Supplier.SupplierFax;
            //this.xrLabelCustomTel.Text = string.IsNullOrEmpty(this.invoice.Supplier.SupplierPhone1) ? this.invoice.Supplier.SupplierPhone2 : this.invoice.Supplier.SupplierPhone1;
            //this.xrLabelTongYiNo.Text = this.invoice.Supplier.SupplierNumber;
            this.xrLabelCustomName.Text = supplier.SupplierFullName;
            this.xrLabelLianluoName.Text = supplier.SupplierContact;
            this.xrLabelCustomFax.Text = supplier.SupplierFax;
            this.xrLabelCustomTel.Text = string.IsNullOrEmpty(supplier.SupplierPhone1) ? supplier.SupplierPhone2 : supplier.SupplierPhone1;
            this.xrLabelTongYiNo.Text = supplier.SupplierNumber;

            //客戶信息
            if (this.invoice.Customer != null)
            {
                this.xrLabelCustomer.Text = this.invoice.Customer.CustomerFullName;
                this.xrLabelJianCe.Text = this.invoice.Customer.CheckedStandard;
                this.lblFP.Text = this.invoice.Customer.CustomerFP;
            }
            //单据信息
            this.xrLabelInvoiceDate.Text = this.invoice.InvoiceDate.Value.ToShortDateString();
            this.xrLabelYJDate.Text = this.invoice.InvoiceYjrq == null ? "" : this.invoice.InvoiceYjrq.Value.ToShortDateString();
            this.xrLabelInvoiceId.Text = this.invoice.InvoiceId;
            this.xrLabel25.Text += this.invoice.AuditEmp == null ? "" : this.invoice.AuditEmp.EmployeeName;
            this.xrLabelYeWuName.Text = this.invoice.Employee0 == null ? "" : this.invoice.Employee0.EmployeeName;
            this.xrLabelTotal1.Text = global::Helper.DateTimeParse.GetSiSheWuRu(this.invoice.InvoiceTotal.Value, BL.V.SetDataFormat.CGZJXiao.Value).ToString();
            this.xrLabelNote.Text = this.invoice.InvoiceNote;
            //this.lblBiBie.Text = this.invoice.AtCurrencyCategory == null ? "" : this.invoice.AtCurrencyCategory.ToString();
            this.lblBiBie.Text = this.invoice.Currency;
            Model.InvoiceXO temp = this.invoiceXoManager.Get(this.invoice.InvoiceXOId);
            if (temp != null)
            {
                this.xrLabelInvoiceXOId.Text = temp.CustomerInvoiceXOId;

            }
            this.xrLabelPiHao.Text = this.invoice.SupplierLotNumber;

            //明细信息
            this.xrTableCellProductId.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_Inumber);
            this.xrTableCellProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            //this.xrTableCellProductGuige.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductSpecification);
            this.xrTableCellQuantity.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_InvoiceProductUnit);
            this.xrTableCellProductUnit.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_OrderQuantity);
            this.xrTableCellUintPrice.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_InvoiceCODetailPrice, "{0:0.00}");
            this.xrTableCellMoney.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_InvoiceCODetailMoney, "{0:0.00}");
            //this.xrTableCellNetWeight.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_GrossWeight, "{0:0}");
            //this.xrTableCellGrossWeight.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_NetWeight, "{0:0}");
            //this.xrTableCellBulk.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_Bulk, "{0:0}");
            this.xrRichTextProductDescribe.DataBindings.Add("Rtf", this.DataSource, "Product." + Model.Product.PRO_ProductDescription);
            this.xrLabelDetailDesc.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_InvoiceCODetailNote);
        }

    }
}
