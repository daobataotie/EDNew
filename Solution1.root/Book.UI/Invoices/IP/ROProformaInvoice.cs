using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
using System.Globalization;

namespace Book.UI.Invoices.IP
{
    public partial class ROProformaInvoice : DevExpress.XtraReports.UI.XtraReport
    {
        public ROProformaInvoice(Model.ProformaInvoice invoice)
        {
            InitializeComponent();

            this.DataSource = invoice.Details;

            //lbl_CompanyName.Text = BL.Settings.CompanyChineseName;
            this.lbl_PO.Text = invoice.PO;
            //this.lbl_InvoiceDate.Text = invoice.InvoiceDate.Value.ToString("yyyy-MM-dd");
            this.lbl_InvoiceDate.Text = invoice.InvoiceDate.Value.ToString("MMM-dd-yyyy", CultureInfo.CreateSpecificCulture("en-GB"));

            this.lbl_CustomerName.Text = invoice.Customer.CustomerFullName;
            this.lbl_CustomerAddress.Text = invoice.Customer.CustomerAddress;
            this.lbl_CustomerTel.Text = invoice.Customer.CustomerPhone;
            this.lbl_PaymentTerm.Text = invoice.Customer.PayCondition;

            this.lbl_Attn.Text = invoice.Attn;
            this.lbl_CustomerPONo.Text = invoice.CustomerPONo;
            this.lbl_SalesRep.Text = invoice.SalesRep;
            this.lbl_TotalEnglish.Text = invoice.TotalEnglish;
            this.lbl_GoodsReadyDate.Text = invoice.GOODSREADYDATE;
            this.lbl_CountryOfOrigin.Text = invoice.COUNTRYOFORIGIN;

            if (!string.IsNullOrEmpty(invoice.BankId))
            {
                Model.Bank bank = new BL.BankManager().Get(invoice.BankId);
                if (bank != null)
                {
                    this.lbl_BankName.Text = bank.BankName;
                    this.lbl_BankAddress.Text = bank.BankAddress;
                    this.lbl_BankTel.Text = bank.BankPhone;
                    this.lbl_BankFax.Text = bank.Fax;
                    this.lbl_SWIFTCode.Text = bank.SWIFTCode;
                    this.lbl_AccountNo.Text = bank.Id;
                }
            }
            this.lbl_CustomerSign.Text = invoice.Customer.CustomerFullName;

            string currencySign = invoice.Currency + Model.ExchangeRate.GetCurrencySignByENName(invoice.Currency);
            currencySign = (string.IsNullOrEmpty(currencySign) ? "USD$" : currencySign) + " ";

            if (invoice.Details != null && invoice.Details.Count > 0)
            {
                this.TC_TotalQty.Text = invoice.Details.Sum(P => P.Quantity).Value.ToString("N0");
                this.TC_TotalAmount.Text = currencySign + invoice.Details.Sum(D => D.Amount).Value.ToString("N3");
            }

            TC_ItemCode.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_Id);
            TC_Desc.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            TC_Qty.DataBindings.Add("Text", this.DataSource, Model.ProformaInvoiceDetail.PRO_Quantity, "{0:N0}");
            TC_UnitPrice.DataBindings.Add("Text", this.DataSource, Model.ProformaInvoiceDetail.PRO_UnitPrice, currencySign + "{0:N3}");
            TC_Amount.DataBindings.Add("Text", this.DataSource, Model.ProformaInvoiceDetail.PRO_Amount, currencySign + "{0:N3}");
        }

    }

}
