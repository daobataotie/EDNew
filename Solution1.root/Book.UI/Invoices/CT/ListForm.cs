using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Book.UI.Invoices.CT
{
    public partial class ListForm : BaseListForm
    {
        BL.InvoiceCTManager manager = new Book.BL.InvoiceCTManager();
        public ListForm()
        {
            InitializeComponent();
            this.invoiceManager = new BL.InvoiceCTManager();
        }

        private void ListForm_Load(object sender, EventArgs e)
        {

        }

        protected override Form GetViewForm()
        {
            Model.InvoiceCT invoice = this.SelectedItem as Model.InvoiceCT;
            if (invoice != null)
                //return new ViewForm(invoice.InvoiceId);
                return new EditForm(invoice);
            return null;
        }

        protected override DevExpress.XtraReports.UI.XtraReport GetReport()
        {
            return new R02(this.bindingSource1.DataSource as IList<Model.InvoiceCT>);
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView MainView
        {
            get
            {
                return this.gridView1;
            }
        }

        protected override void ShowSearchForm()
        {
            ConditionForm f = new ConditionForm();
            if (f.ShowDialog(this) == DialogResult.OK)
                this.bindingSource1.DataSource = manager.SelectByCondition(f.condition.StartDate, f.condition.EndDate, f.condition.StartCTId, f.condition.EndCTId, f.condition.StartCOId, f.condition.EndCOId, f.condition.CusId, f.condition.SupplierId);
            this.barStaticItem1.Caption = this.bindingSource1.Count.ToString() + "�";
        }
    }
}