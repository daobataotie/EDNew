using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;

namespace Book.UI.Settings.BasicData.Products
{
    public partial class ChooseProductsForm : DevExpress.XtraEditors.XtraForm
    {
        public List<Model.Product> Products = new List<Book.Model.Product>();

        public ChooseProductsForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterParent;
            this.gridControl1.DataSource = Products = new BL.ProductManager().GetAllProducts_Fast().ToList();
        }

        public ChooseProductsForm(List<Model.Product> list)
            : this()
        {
            if (list != null && list.Count > 0)
            {
                Products.Intersect(list, new ProductComparer()).ToList().ForEach(C => C.Checked = true);
                this.gridControl1.RefreshDataSource();
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkAll_CheckStateChanged(object sender, EventArgs e)
        {
            var list = this.gridView1.DataController.GetAllFilteredAndSortedRows();

            foreach (Model.Product item in list)
            {
                //Products.First(c => c.CustomerId == item.CustomerId).IsChecked = checkAll.Checked;
                item.Checked = checkAll.Checked;
            }

            this.gridControl1.RefreshDataSource();
        }
    }

    public class ProductComparer : IEqualityComparer<Model.Product>
    {
        public bool Equals(Model.Product x, Model.Product y)
        {
            if (Object.ReferenceEquals(x, y))
                return true;
            return x != null && y != null && x.ProductId == y.ProductId;
        }

        public int GetHashCode(Model.Product obj)
        {
            return obj.ProductId.GetHashCode();
        }
    }
}