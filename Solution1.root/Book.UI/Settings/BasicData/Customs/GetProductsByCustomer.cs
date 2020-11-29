using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.Settings.BasicData.Customs
{
    public partial class GetProductsByCustomer : DevExpress.XtraEditors.XtraForm
    {
        BL.ProductManager productManager = new Book.BL.ProductManager();

        public GetProductsByCustomer(Model.Customer customer)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;

            this.Text = customer.CustomerFullName + "-商品";

            var list = productManager.GetProductsByCustomerId(customer.CustomerId);
            this.bindingSource1.DataSource = list;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (this.bindingSource1.Current == null)
                return;

            Model.Product product = productManager.Get((this.bindingSource1.Current as Model.Product).ProductId);

            Products.EditForm f = new Book.UI.Settings.BasicData.Products.EditForm(product, "view");
            f.ShowDialog();
        }
    }
}