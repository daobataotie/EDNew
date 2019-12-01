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
    public partial class ListFormProformaInvoice : BaseListForm
    {
        BL.ProformaInvoiceManager proformaInvoiceManager = new Book.BL.ProformaInvoiceManager();

        public ListFormProformaInvoice()
        {
            InitializeComponent();
        }

        protected override Form GetViewForm()
        {
            Model.ProformaInvoice invoice = this.SelectedItem as Model.ProformaInvoice;
            if (invoice != null)
                return new EditFormProformaInvoice(invoice.PO);

            return null;
        }

        protected override void LoadInvoices(DateTime datetime1, DateTime datetime2)
        {
            this.bindingSource1.DataSource = proformaInvoiceManager.SelectByCondition(DateTime.Now.AddMonths(-1), DateTime.Now, "");

            this.gridControl1.RefreshDataSource();
        }

        protected override void ShowSearchForm()
        {
            ConditionForm f = new ConditionForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                this.bindingSource1.DataSource = proformaInvoiceManager.SelectByCondition(f.StartDate, f.EndDate, f.CustomerId);
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
                EditFormProformaInvoice f = new EditFormProformaInvoice(this.bindingSource1.Current as Model.ProformaInvoice);
                f.ShowDialog();
            }
        }
    }
}