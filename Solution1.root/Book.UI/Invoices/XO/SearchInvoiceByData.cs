using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.Invoices.XO
{
    public partial class SearchInvoiceByData : DevExpress.XtraEditors.XtraForm
    {
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
                ROSearchInvoiceByData ro = new ROSearchInvoiceByData(date_Start.DateTime, date_End.DateTime, ncc_Customer.EditValue as Model.Customer, btn_Product.EditValue as Model.Product);

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
            Invoices.ChooseProductForm form = new Invoices.ChooseProductForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.btn_Product.EditValue = form.SelectedItem as Model.Product;
            }
            form.Dispose();
            GC.Collect();
        }
    }
}