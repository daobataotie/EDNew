using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;

namespace Book.UI.Invoices.XO
{
    public partial class SearchInvoiceByData : DevExpress.XtraEditors.XtraForm
    {
        public List<Model.Product> Products = new List<Book.Model.Product>();

        public string ProductNames { get; set; }
        public string ProductIds { get; set; }

        public SearchInvoiceByData()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            date_Start.DateTime = DateTime.Now.AddMonths(-1);
            date_End.DateTime = DateTime.Now;

            ncc_Customer.Choose = new Settings.BasicData.Customs.ChooseCustoms();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (date_Start.EditValue == null || date_End.EditValue == null)
            {
                MessageBox.Show("日期區間不完整！", this.Text, MessageBoxButtons.OK);
                return;
            }

            try
            {
                ROSearchInvoiceByData ro = new ROSearchInvoiceByData(date_Start.DateTime, date_End.DateTime, ncc_Customer.EditValue as Model.Customer, ProductIds);

                ro.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK);
                return;
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Product_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //Invoices.ChooseProductForm form = new Invoices.ChooseProductForm();
            //if (form.ShowDialog(this) == DialogResult.OK)
            //{
            //    this.btn_Product.EditValue = form.SelectedItem as Model.Product;
            //}
            //form.Dispose();
            //GC.Collect();

            Settings.BasicData.Products.ChooseProductsForm f = new Book.UI.Settings.BasicData.Products.ChooseProductsForm(Products);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                this.Products = f.Products.Where(P => P.Checked == true).ToList();

                ProductNames = "";
                ProductIds = "";
                foreach (var item in Products)
                {
                    ProductNames += item.ProductName + ",";
                    ProductIds += "'" + item.ProductId + "',";
                }

                ProductNames = ProductNames.TrimEnd(',');
                ProductIds = ProductIds.TrimEnd(',');

                this.btn_Product.Text = this.ProductNames;
            }
        }
    }
}