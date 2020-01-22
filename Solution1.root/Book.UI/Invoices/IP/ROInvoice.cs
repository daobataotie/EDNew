using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
using System.Globalization;

namespace Book.UI.Invoices.IP
{
    public partial class ROInvoice : DevExpress.XtraReports.UI.XtraReport
    {
        public ROInvoice(Model.PackingInvoiceHeader invoiceList)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(invoiceList.Unit))
                this.xrTableCell5.Text = string.Format("Quantity ({0})", invoiceList.Unit);

            this.DataSource = invoiceList.Details;

            this.lbl_PackingNo.Text = invoiceList.InvoiceNo;
            this.lbl_PackingDate.Text = invoiceList.InvoiceDate.Value.ToString("yyyy/MM/dd");
            this.lbl_CustomerFullName.Text = invoiceList.CustomerFullName;
            this.lbl_address.Text = invoiceList.CustomerAddress;
            this.lbl_PerSS.Text = invoiceList.PerSS;
            if (invoiceList.SailingOnOrAbout != null)
                this.lbl_SailingDate.Text = invoiceList.SailingOnOrAbout.Value.ToString("yyyy-MM-dd");
            if (invoiceList.FromPort != null)
                this.lbl_From.Text = invoiceList.FromPort.PortName;
            if (invoiceList.ToPort != null)
                this.lbl_TO.Text = invoiceList.ToPort.PortName;

            this.lbl_InvoiceOf.Text = invoiceList.PackingListOf;
            this.lbl_Attn.Text = invoiceList.Attn;
            this.lbl_Term.Text = invoiceList.Term;
            this.lbl_ShippedBy.Text = invoiceList.ShippedBy;
            this.lbl_ShipTo.Text = invoiceList.ShipToAddress;

            this.lbl_TotalEnglish.Text = invoiceList.TotalEnglish;

            if (invoiceList.Bank != null)
            {
                this.lbl_BankName.Text = invoiceList.Bank.BankName;
                this.lbl_BankAddress.Text = invoiceList.Bank.BankAddress;
                this.lbl_BankPhone.Text = invoiceList.Bank.BankPhone;
                this.lbl_BankFax.Text = invoiceList.Bank.Fax;
                this.lbl_BankAccountNo.Text = invoiceList.Bank.Id;
                this.lbl_BankSwiftCode.Text = invoiceList.Bank.SWIFTCode;
            }

            if (!string.IsNullOrEmpty(invoiceList.Unit))
                this.lbl_TotalQTY.Text = invoiceList.Details.Sum(P => P.Quantity).Value.ToString("0.##") + " " + invoiceList.Unit;
            else
                this.lbl_TotalQTY.Text = invoiceList.Details.Sum(P => P.Quantity).Value.ToString("0.##") + " PCS";

            if (invoiceList.Details != null && invoiceList.Details.Count > 0)
            {
                string currency = new BL.InvoiceXOManager().GetCurrencyByInvoiceId(invoiceList.Details[0].InvoiceXODetail.InvoiceId);
                string currencyENName = Model.ExchangeRate.GetCurrencyENName(currency);
                string currencySign = Model.ExchangeRate.GetCurrencySignByCNName(currency);
                this.xrTableCell6.Text = "Amount     (" + currencyENName + ")";
                this.TCUnitPriceCurrency.Text = currencySign;
                this.TCAmountCurrency.Text = currencySign;
                this.lbl_TotalAmount.Text = currencyENName + " " + invoiceList.Details.Sum(P => P.Amount).Value.ToString("0.00");
            }

            TC_No.DataBindings.Add("Text", this.DataSource, Model.PackingInvoiceDetail.PRO_Number);
            TC_PONO.DataBindings.Add("Text", this.DataSource, Model.PackingInvoiceDetail.PRO_PONo);
            TC_ProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            TCQTY.DataBindings.Add("Text", this.DataSource, Model.PackingInvoiceDetail.PRO_ShowQty, "{0:0.##}");
            TC_UnitPrice.DataBindings.Add("Text", this.DataSource, Model.PackingInvoiceDetail.PRO_UnitPrice, "{0:0.00}");
            TC_Amount.DataBindings.Add("Text", this.DataSource, Model.PackingInvoiceDetail.PRO_Amount, "{0:0.00}");

        }
    }
}
