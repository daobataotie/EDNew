using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Book.UI.Invoices.XO
{
    public partial class ROSearchInvoiceByData : DevExpress.XtraReports.UI.XtraReport
    {
        public ROSearchInvoiceByData(DateTime startDate, DateTime endDate, Model.Customer customer, Model.Product product)
        {
            InitializeComponent();

            string customerId = customer == null ? null : customer.CustomerId;
            string productId = product == null ? null : product.ProductId;

            DataTable dt = new BL.InvoiceXODetailManager().SearchInvoiceByData(startDate, endDate, customerId, productId);
            if (dt == null || dt.Rows.Count == 0)
            {
                throw new Exception("無數據！");
            }

            lbl_CompanyName.Text = BL.Settings.CompanyChineseName;
            lbl_ReportDate.Text += DateTime.Now.ToString("yyyy-MM-dd");
            lbl_DateRange.Text = string.Format("{0} ~ {1}", startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
            lbl_Customer.Text = customer == null ? null : customer.CustomerFullName;
            lbl_Product.Text = product == null ? null : product.ProductName;
            DataSource = dt;

            TCId.DataBindings.Add("Text", DataSource, "Id");
            TCProductName.DataBindings.Add("Text", DataSource, "ProductName");
            TCCustomerProductName.DataBindings.Add("Text", DataSource, "CustomerProductName");
            TCQty.DataBindings.Add("Text", DataSource, "Qty");
        }

    }
}
