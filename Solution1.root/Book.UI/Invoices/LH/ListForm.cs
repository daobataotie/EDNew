using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.Invoices.LH
{
    public partial class ListForm : BaseListForm
    {
        BL.InvoiceLHDetailManager invoiceLHDetailManager = new Book.BL.InvoiceLHDetailManager();

        public ListForm()
        {
            InitializeComponent();
        }

        protected override Form GetViewForm()
        {
            Model.InvoiceLHDetail detail = this.bindingSource1.Current as Model.InvoiceLHDetail;
            if (detail != null)
                return new EditForm(detail.InvoiceLHId);
            //        return new ViewForm(invoice.InvoiceId);

            return null;
        }

        protected override DevExpress.XtraReports.UI.XtraReport GetReport()
        {
            //return new R02(this.bindingSource1.DataSource as IList<Model.InvoiceXO>);
            IList<Model.InvoiceLHDetail> list = this.bindingSource1.DataSource as IList<Model.InvoiceLHDetail>;
            if (list == null || list.Count == 0)
            {
                MessageBox.Show("無數據！", this.Text, MessageBoxButtons.OK);
                return null;
            }
            return new ROList(list);
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
            {
                this.bindingSource1.DataSource = invoiceLHDetailManager.SelectByCondition(f.StartDate, f.EndDate, f.CustomerId);
                this.gridControl1.RefreshDataSource();
            }

            f.Dispose();
            GC.Collect();
            this.barStaticItem1.Caption = string.Format("{0}项", this.bindingSource1.Count);
        }
    }
}