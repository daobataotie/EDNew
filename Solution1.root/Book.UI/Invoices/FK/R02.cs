using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.Invoices.FK
{
    public partial class R02 : DevExpress.XtraReports.UI.XtraReport
    {
        protected BL.InvoiceFKManager invoiceManager = new Book.BL.InvoiceFKManager();

        public R02()
           : this(null)
        {
            
        }
        public R02(System.Collections.Generic.IList<Model.InvoiceFK> list)
        {
            InitializeComponent();

            if (list == null)
                list = this.invoiceManager.Select(Helper.InvoiceStatus.Normal);

            this.DataSource = list;

            this.xrTableCellAbstract.DataBindings.Add("Text", this.DataSource, Model.InvoiceFK.PROPERTY_INVOICEABSTRACT);
            this.xrTableCellAccount.DataBindings.Add("Text", this.DataSource, "Account." + Model.Account.PROPERTY_ACCOUNTNAME);
            //this.xrTableCellCompany.DataBindings.Add("Text", this.DataSource, "Company." + Model.Company.PROPERTY_COMPANYNAME0);
            this.xrTableCellInvoiceDate.DataBindings.Add("Text", this.DataSource, Model.InvoiceFK.PROPERTY_INVOICEDATE);
            this.xrTableCellInvoiceId.DataBindings.Add("Text", this.DataSource, Model.InvoiceFK.PROPERTY_INVOICEID);
            this.xrTableCellNote.DataBindings.Add("Text", this.DataSource, Model.InvoiceFK.PROPERTY_INVOICENOTE);
            this.xrTableCellTotal.DataBindings.Add("Text", this.DataSource, Model.InvoiceFK.PROPERTY_INVOICETOTAL);
        }
    }
}
