using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Book.UI.Invoices.FT
{
    public partial class ListForm : BaseListForm
    {
        public ListForm()
        {
            InitializeComponent();
            this.invoiceManager = new BL.InvoiceFTManager();
        }

        private void ListForm_Load(object sender, EventArgs e)
        {  

        }

        protected override Form GetViewForm()
        {
            Model.InvoiceFT invoice = this.SelectedItem as Model.InvoiceFT;
            if (invoice != null)
                return new EditForm(invoice.InvoiceId);            

            return null;
        }

        protected override DevExpress.XtraReports.UI.XtraReport GetReport()
        {
            return new R02(this.bindingSource1.DataSource as IList<Model.InvoiceFT>);
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView MainView
        {
            get
            {
                return this.gridView1;
            }
        }
    }
}