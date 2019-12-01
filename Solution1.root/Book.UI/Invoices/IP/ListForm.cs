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
    public partial class ListForm : BaseListForm
    {
        BL.PackingListHeaderManager packingListHeaderManager = new Book.BL.PackingListHeaderManager();

        public ListForm()
        {
            InitializeComponent();

            //this.bindingSourceCustomer.DataSource = new BL.CustomerManager().Query("select CustomerId,CustomerFullName,CustomerAddress,* from Customer", 30, "CustomerName").Tables[0];
            this.bindingSourcePort.DataSource = new BL.PortManager().Select();
        }

        public Model.PackingListHeader SelectItem { get; set; }

        protected override Form GetViewForm()
        {
            Model.PackingListHeader invoice = this.SelectedItem as Model.PackingListHeader;
            if (invoice != null)
                return new EditForm(invoice.PackingNo);

            return null;
        }

        protected override void LoadInvoices(DateTime datetime1, DateTime datetime2)
        {
            this.bindingSource1.DataSource = packingListHeaderManager.SelectByCondition(DateTime.Now.AddMonths(-1), DateTime.Now, "");

            this.gridControl1.RefreshDataSource();
        }

        protected override void ShowSearchForm()
        {
            ConditionForm f = new ConditionForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                this.bindingSource1.DataSource = packingListHeaderManager.SelectByCondition(f.StartDate, f.EndDate, f.CustomerId);
                this.gridControl1.RefreshDataSource();
            }
            this.barStaticItem1.Caption = string.Format("{0}项", this.bindingSource1.Count);
            f.Dispose();
            GC.Collect();
        }

        protected override void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.bindingSource1.Current != null)
            {
                EditForm f = new EditForm(this.bindingSource1.Current as Model.PackingListHeader);
                f.ShowDialog();
            }
        }

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            if (this.bindingSource1.Current != null)
            {
                EditForm f = new EditForm(this.bindingSource1.Current as Model.PackingListHeader);
                f.ShowDialog();
            }
        }
    }
}