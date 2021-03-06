using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.Invoices.PT
{
    public partial class R02 : DevExpress.XtraReports.UI.XtraReport
    {
        protected BL.InvoicePTManager invoiceManager = new Book.BL.InvoicePTManager();

        public R02()
            : this(null)
        {

        }

        public R02(System.Collections.Generic.IList<Model.InvoicePTDetail> list)
        {
            InitializeComponent();

            //if (list == null)
            //{
            //    list = this.invoiceManager.Select(Helper.InvoiceStatus.Normal);
            //}

            this.DataSource = list;

            //this.xrTableCellAbstract.DataBindings.Add("Text", this.DataSource, "this.bindingSource1.DataSource" + Model.InvoicePT.PROPERTY_INVOICEABSTRACT);
            this.xrTableCellDepot0.DataBindings.Add("Text", this.DataSource, "Invoice.Depot." + Model.Depot.PRO_DepotName);
            this.xrTableCellDepot1.DataBindings.Add("Text", this.DataSource, "Invoice.DepotIn." + Model.Depot.PRO_DepotName);
            this.xrTableCellEmployee.DataBindings.Add("Text", this.DataSource, "Invoice.Employee0." + Model.Employee.PROPERTY_EMPLOYEENAME);
            this.xrTableCellInvoiceDate.DataBindings.Add("Text", this.DataSource, "Invoice." + Model.InvoicePT.PROPERTY_INVOICEDATE, "{0:yyyy-MM-dd}");
            this.xrTableCellInvoiceId.DataBindings.Add("Text", this.DataSource, "Invoice." + Model.InvoicePT.PROPERTY_INVOICEID);
            this.xrTableCellNote.DataBindings.Add("Text", this.DataSource, "Invoice." + Model.InvoicePT.PROPERTY_INVOICENOTE);
            this.TCProduct.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            this.TCQuantity.DataBindings.Add("Text", this.DataSource, Model.InvoicePTDetail.PROPERTY_INVOICEPTDETAILQUANTITY);
        }
    }
}
