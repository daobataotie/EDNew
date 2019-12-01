using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Book.UI.Invoices.XS
{
    public partial class R02 : DevExpress.XtraReports.UI.XtraReport
    {
        protected BL.InvoiceXSManager invoiceManager = new Book.BL.InvoiceXSManager();

        public R02(System.Collections.Generic.IList<Model.InvoiceXS> list)
        {
            InitializeComponent();

            if (list == null)
            {
                list = this.invoiceManager.Select(Helper.InvoiceStatus.Normal);
            }

            this.DataSource = list;

            this.xrTableCellCompany.DataBindings.Add("Text", this.DataSource, "Customer." + Model.Customer.PRO_CustomerShortName);
            this.xrTableCellDepot.DataBindings.Add("Text", this.DataSource, "Depot" + Model.Depot.PRO_DepotName);
            this.xrTableCellEmployee.DataBindings.Add("Text", this.DataSource, "Employee0." + Model.Employee.PROPERTY_EMPLOYEENAME);
            this.xrTableCellInvoiceDate.DataBindings.Add("Text", this.DataSource, Model.InvoiceXS.PROPERTY_INVOICEDATE);
            this.xrTableCellInvoiceId.DataBindings.Add("Text", this.DataSource, Model.InvoiceXS.PROPERTY_INVOICEID);
            
            this.xrTableCellNote.DataBindings.Add("Text", this.DataSource, Model.InvoiceXS.PROPERTY_INVOICENOTE);            
            
        }

        public R02(DataTable dt)
        {
            InitializeComponent();

            this.DataSource = dt;

            this.xrTableCellCompany.DataBindings.Add("Text", this.DataSource, "Customer");
            this.xrTableCellDepot.DataBindings.Add("Text", this.DataSource, "Depot");
            this.xrTableCellEmployee.DataBindings.Add("Text", this.DataSource, "Employee0.");
            this.xrTableCellInvoiceDate.DataBindings.Add("Text", this.DataSource, "InvoiceDate");
            this.xrTableCellInvoiceId.DataBindings.Add("Text", this.DataSource, "InvoiceId");
            this.xrTableCellNote.DataBindings.Add("Text", this.DataSource, "InvoiceNote");

        }

    }
}
