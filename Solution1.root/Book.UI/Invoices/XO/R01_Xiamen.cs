using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;

namespace Book.UI.Invoices.XO
{
    public partial class R01_Xiamen : DevExpress.XtraReports.UI.XtraReport
    {
        private BL.InvoiceXOManager invoiceXOManager = new Book.BL.InvoiceXOManager();
        private BL.InvoiceXODetailManager invoiceXODetailManager = new Book.BL.InvoiceXODetailManager();
        private Model.InvoiceXO invoice;
        private BL.ExchangeRateManager exchangeRateManager = new Book.BL.ExchangeRateManager();

        public R01_Xiamen(string invoiceid)
        {
            InitializeComponent();

            this.invoice = this.invoiceXOManager.Get(invoiceid);

            if (this.invoice == null)
                return;

            //this.invoice.Details = this.invoiceXODetailManager.Select(this.invoice, false);
            decimal totalMoney = 0;
            List<string> proCurrencys = new List<string>();
            foreach (var item in this.invoice.Details)
            {
                decimal coPrice = 0;

                //先獲取商品的採購單價
                if (!string.IsNullOrEmpty(item.Product.PriceAndRange))
                    coPrice = BL.SupplierProductManager.CountPrice(item.Product.PriceAndRange, Convert.ToDouble(item.InvoiceXODetailQuantity));

                item.COPrice = coPrice;
                item.COMoney = coPrice * Convert.ToDecimal(item.InvoiceXODetailQuantity);
                item.COCurrencySign = Model.ExchangeRate.GetCurrencyENNameAndSign(item.Product.COCurrency);

                totalMoney += item.COMoney;
                proCurrencys.Add(item.COCurrencySign);
            }

            this.DataSource = this.invoice.Details;

            //CompanyInfo            
            this.xrLabelCompanyInfoName.Text = "ALAN SAFETY CO., LTD";
            this.xrLabelData.Text = "訂單通知";
            this.xrLabelPrintDate.Text += DateTime.Now.ToShortDateString();

            //供應商信息
            if (invoice.Supplier != null)
            {
                this.lbl_SupplierName.Text = this.invoice.Supplier.SupplierFullName;
                this.lbl_SupplierFax.Text = this.invoice.Supplier.SupplierFax;
            }

            //单据信息
            this.xrLabelInvoiceDate.Text = this.invoice.InvoiceDate.Value.ToString("yyyy-MM-dd");
            this.xrLabelInvoiceId.Text = this.invoice.InvoiceId;
            this.xrLabelEmp.Text += this.invoice.Employee0 == null ? "" : this.invoice.Employee0.EmployeeName;
            this.xrLabel25.Text += this.invoice.AuditEmp == null ? "" : this.invoice.AuditEmp.EmployeeName;
            this.xrLabelNote.Text = this.invoice.InvoiceNote;
            this.xrLabelCustomerXOId.Text = this.invoice.CustomerInvoiceXOId;
            this.xrLabelXScustomer.Text = this.invoice.xocustomer == null ? "" : this.invoice.xocustomer.CustomerFullName;
            this.xrLabelYJRQ.Text = this.invoice.InvoiceYjrq.Value.ToString("yyyy-MM-dd");
            this.xrLabelUnit.Text = this.invoice.Details[0].InvoiceProductUnit;

            this.xrLabelCount.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceXODetailQuantity, "{0:0.##}");

            //明细信息
            this.xrTableCellProductId.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_Inumber);
            //this.xrTableCellProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            this.xrTableCellProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_Id);
            this.xrTableCellQuantity.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceXODetailQuantity, "{0:0.##}");
            this.xrTableCellProductUnit.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceProductUnit);
            this.TC_COPrice.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_COPriceShow);
            this.TC_COMoney.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_COMoneyShow);
            //this.TCProductRemark.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_Remark);
            this.xrRichText1.DataBindings.Add("Rtf", this.DataSource, "Product." + Model.Product.PRO_ProductDescription);

            //假如一個訂單中商品的采購幣別不同，那麽匯總時不知道怎麽顯示，則爲空
            var currencySign = "";
            if (proCurrencys.Distinct().Count() == 1)
                currencySign = proCurrencys[0];
            this.lbl_TotalMoney.Text = currencySign + totalMoney.ToString("0.##");
        }

    }
}
