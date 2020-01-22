using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.Invoices.XO
{
    public partial class R01 : DevExpress.XtraReports.UI.XtraReport
    {
        private BL.InvoiceXOManager invoiceXOManager = new Book.BL.InvoiceXOManager();
        private BL.InvoiceXODetailManager invoiceXODetailManager = new Book.BL.InvoiceXODetailManager();
        private Model.InvoiceXO invoice;
        int pp = 0;
        public R01(string invoiceid)
        {
            InitializeComponent();

            this.invoice = this.invoiceXOManager.Get(invoiceid);

            if (this.invoice == null)
                return;

            this.invoice.Details = this.invoiceXODetailManager.Select(this.invoice, false);

            this.DataSource = this.invoice.Details;

            //CompanyInfo            
            this.xrLabelCompanyInfoName.Text = "ALAN SAFETY CO., LTD(久綺有限公司)";
            this.xrLabelData.Text = "客戶訂單通知";
            this.xrLabelPrintDate.Text += DateTime.Now.ToShortDateString();

            //供應商信息
            if (invoice.Supplier != null)
            {
                this.lbl_SupplierName.Text = this.invoice.Supplier.SupplierFullName;
                this.lbl_SupplierFax.Text = this.invoice.Supplier.SupplierFax;
            }

            //单据信息
            this.xrLabelInvoiceDate.Text = this.invoice.InvoiceDate.Value.ToString("yyyy-MM-dd");
            this.xrLabelInvoiceId.Text = this.invoice.InvoiceId;
            this.xrLabelEmp.Text += this.invoice.Employee0 == null ? "" : this.invoice.Employee0.EmployeeName;
            this.xrLabel25.Text += this.invoice.AuditEmp == null ? "" : this.invoice.AuditEmp.EmployeeName;
            this.xrLabelNote.Text = this.invoice.InvoiceNote;
            this.xrLabelCustomerXOId.Text = this.invoice.CustomerInvoiceXOId;
            this.xrLabelXScustomer.Text = this.invoice.xocustomer.CustomerFullName;
            this.xrLabelYJRQ.Text = this.invoice.InvoiceYjrq.Value.ToString("yyyy-MM-dd");
            this.xrLabelUnit.Text = this.invoice.Details[0].InvoiceProductUnit;

            this.xrLabelCount.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceXODetailQuantity, "{0:0.##}");

            //明细信息
            this.xrTableCellProductId.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_Inumber);
            this.xrTableCellProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            this.xrTableCellProductUnit.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceProductUnit);
            this.xrTableCellQuantity.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceXODetailQuantity, "{0:0.##}");
            //this.TCProductRemark.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_Remark);
            this.xrRichText1.DataBindings.Add("Rtf", this.DataSource, "Product." + Model.Product.PRO_ProductDescription);
        }

    }
}
