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

            lbl_CompanyName.Text = BL.Settings.CompanyChineseName;
            this.lbl_PO.Text = invoice.PO;
            //this.lbl_InvoiceDate.Text = invoice.InvoiceDate.Value.ToString("yyyy-MM-dd");
            this.lbl_InvoiceDate.Text = invoice.InvoiceDate.Value.ToString("MMM-dd-yyyy",CultureInfo.CreateSpecificCulture("en-GB"));
            this.lbl_CustomerName.Text = invoice.Customer.CustomerFullName;
            this.lbl_CustomerAddress.Text = invoice.Customer.CustomerAddress;
            this.lbl_DeliveryTO.Text = invoice.DeliveryTo;
            this.lbl_Tel.Text = invoice.Customer.CustomerPhone;
            this.lbl_Attn.Text = invoice.Attn;
            this.lbl_Term.Text = invoice.Customer.TradingCondition;
            this.lbl_PINO.Text = invoice.PO;
            this.lbl_Currency.Text = invoice.Currency;

            this.lbl_Remark.Text = invoice.Remark;
            this.lbl_DeliveryDate.Text = invoice.DeliveryDate;
            this.lbl_PaymentTerm.Text = invoice.Customer.PayCondition;
            if (!string.IsNullOrEmpty(invoice.BankId))
            {
                Model.Bank bank = new BL.BankManager().Get(invoice.BankId);
                if (bank != null)
                {
                    this.lbl_AccountName.Text = bank.Description;
                    this.lbl_AccountNo.Text = bank.Id;
                    this.lbl_BankName.Text = bank.BankName;
                    this.lbl_BankAddress.Text = bank.BankAddress;
                    this.lbl_SWIFTCode.Text = bank.SWIFTCode;
                }
            }
            this.lbl_ShippingMark.Text = invoice.ShippimgMark;
            this.lbl_CustomerSign.Text = invoice.Customer.CustomerFullName;

            string currencySign = this.GetCurrencyCode(invoice.Currency) + " ";

            if (invoice.Details != null && invoice.Details.Count > 0)
            {
                this.TC_TotalQty.Text = invoice.Details.Sum(P => P.Quantity).Value.ToString("N0");
                this.TC_TotalUnit.Text = invoice.Details[0].Unit;
                this.TC_TotalAmount.Text = currencySign + invoice.Details.Sum(D => D.Amount).Value.ToString("N2");
            }

            TC_No.DataBindings.Add("Text", this.DataSource, Model.ProformaInvoiceDetail.PRO_Number);
            TC_ItemCode.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_CustomerProductName);
            TC_Desc.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            TC_Qty.DataBindings.Add("Text", this.DataSource, Model.ProformaInvoiceDetail.PRO_Quantity, "{0:N0}");
            TC_Unit.DataBindings.Add("Text", this.DataSource, Model.ProformaInvoiceDetail.PRO_Unit);
            TC_UnitPrice.DataBindings.Add("Text", this.DataSource, Model.ProformaInvoiceDetail.PRO_UnitPrice, currencySign + "{0:0.00}");
            TC_Amount.DataBindings.Add("Text", this.DataSource, Model.ProformaInvoiceDetail.PRO_Amount, currencySign + "{0:N2}");
        }

        private string GetCurrencyCode(string currency)
        {
            string str = "";
            switch (currency)
            {
                case "RMB":
                    str = "¥";
                    break;
                case "NTD":
                    str = "NT$";
                    break;
                case "USD":
                    str = "$";
                    break;
                case "EURO":
                    str = "€";
                    break;
                case "JYP":
                    str = "¥";
                    break;
                default:
                    break;
            }
            return str;
        }
    }

}
