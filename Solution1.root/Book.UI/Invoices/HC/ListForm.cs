using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.Invoices.HC
{
    public partial class ListForm : BaseListForm
    {
        public ListForm()
        {
            InitializeComponent();
            this.invoiceManager = new BL.InvoiceHCManager();
        }

        private void ListForm_Load(object sender, EventArgs e)
        {
        }

        protected override Form GetViewForm()
        {
            Model.InvoiceHC invoice = this.SelectedItem as Model.InvoiceHC;
            if (invoice != null)
                return new ViewForm(invoice.InvoiceId);

            return null;
        }

        protected override DevExpress.XtraReports.UI.XtraReport GetReport()
        {
            return new R02(this.bindingSource1.DataSource as IList<Model.InvoiceHC>);
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