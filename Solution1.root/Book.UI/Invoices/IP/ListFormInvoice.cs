using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.Invoices.IP
{
    public partial class ListFormInvoice : BaseListForm
    {
        BL.PackingInvoiceHeaderManager packingInvoiceHeaderManager = new Book.BL.PackingInvoiceHeaderManager();

        public ListFormInvoice()
        {
            InitializeComponent();

            //this.bindingSourceCustomer.DataSource = new BL.CustomerManager().Query("select CustomerId,CustomerFullName,CustomerAddress,* from Customer", 30, "CustomerName").Tables[0];
            this.bindingSourcePort.DataSource = new BL.PortManager().Select();
        }

        protected override Form GetViewForm()
        {
            Model.PackingInvoiceHeader invoice = this.SelectedItem as Model.PackingInvoiceHeader;
            if (invoice != null)
                return new EditFormInvoice(invoice.InvoiceNo);

            return null;
        }

        protected override void LoadInvoices(DateTime datetime1, DateTime datetime2)
        {
            this.bindingSource1.DataSource = packingInvoiceHeaderManager.SelectByCondition(DateTime.Now.AddMonths(-1), DateTime.Now, "");

            this.gridControl1.RefreshDataSource();
        }

        protected override void ShowSearchForm()
        {
            ConditionForm f = new ConditionForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                this.bindingSource1.DataSource = packingInvoiceHeaderManager.SelectByCondition(f.StartDate, f.EndDate, f.CustomerId);
                this.gridControl1.RefreshDataSource();
            }
            this.barStaticItem1.Caption = string.Format("{0}项", this.bindingSource1.Count);
            f.Dispose();
            GC.Collect();
        }

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            if (this.bindingSource1.Current != null)
            {
                EditFormInvoice f = new EditFormInvoice(this.bindingSource1.Current as Model.PackingInvoiceHeader);
                f.ShowDialog();
            }
        }
    }
}