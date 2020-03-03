using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;

namespace Book.UI.Invoices.CO
{
    public partial class R01 : DevExpress.XtraReports.UI.XtraReport
    {
        private BL.InvoiceCOManager invoiceCGManager = new Book.BL.InvoiceCOManager();
        private BL.InvoiceCODetailManager invoiceCGDetailManager = new Book.BL.InvoiceCODetailManager();
        private BL.InvoiceXOManager invoiceXoManager = new BL.InvoiceXOManager();
        private Model.InvoiceCO invoice;
        int pp = 0;
        private BL.ExchangeRateManager exchangeRateManager = new Book.BL.ExchangeRateManager();

        /// <summary>
        /// 是否是第一家供应商
        /// </summary>
        bool isFirstSupplier = true;

        public R01(string invoiceid, string companyName, Model.Supplier supplier)
        {
            InitializeComponent();

            isFirstSupplier = string.IsNullOrEmpty(companyName) ? true : false;

            this.invoice = this.invoiceCGManager.Get(invoiceid);

            if (this.invoice == null)
                return;

            this.DataSource = this.invoice.Details;

            //CompanyInfo            
            if (isFirstSupplier)
            {
                this.xrLabelCompanyInfoName.Text = "ALAN SAFETY COMPANY LIMITED";

                //左下角签名档同供应商
                this.xrLabel14.Text = supplier.SupplierFullName;
            }
            else
            {
                xrLabelCompanyInfoName.HeightF += 100;
                this.xrLabelCompanyInfoName.Text = companyName + "".PadLeft(40, ' ') + "(訂單來源：ALAN SAFETY COMPANY LIMITED)";

                //this.xrPanel1.LocationF.Y += 100;
                this.xrPanel1.LocationF = new PointF(this.xrPanel1.LocationF.X, this.xrPanel1.LocationF.Y + 100);

                //转单单据右下角的签名档同供应商
                this.xrLabel15.Text = supplier.SupplierFullName;
            }

            this.lbl_Tel.Text = BL.Settings.CompanyPhone;
            this.lbl_Fax.Text = BL.Settings.CompanyFax;

            this.xrLabelData.Text = Properties.Resources.InvoiceCO;

            //供應商信息
            this.xrLabelCustomName.Text = supplier.SupplierFullName;

            //客戶信息
            if (this.invoice.Customer != null)
            {
                this.xrLabelCustomer.Text = this.invoice.Customer.CustomerFullName;
            }
            Model.InvoiceXO temp = this.invoiceXoManager.Get(this.invoice.InvoiceXOId);
            if (temp != null)
            {
                this.xrLabelInvoiceXOId.Text = temp.CustomerInvoiceXOId;
            }

            //单据信息
            this.xrLabelInvoiceDate.Text = this.invoice.InvoiceDate.Value.ToString("yyyy.MM.dd");
            this.xrLabelYJDate.Text = this.invoice.InvoiceYjrq == null ? "" : this.invoice.InvoiceYjrq.Value.ToString("yyyy.MM.dd");
            this.xrLabelInvoiceId.Text = this.invoice.InvoiceId;
            this.lbl_shipment.Text = this.invoice.Shipment;

            //總計
            this.TC_TotalQty.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_OrderQuantity);

            string currency = isFirstSupplier ? invoice.SupplierCurrency1 : invoice.SupplierCurrency2;
            this.TC_PriceUnit.Text = string.Format("({0})", Model.ExchangeRate.GetCurrencyENNameAndSign(currency));
            this.TC_TotalPrice.Text = Model.ExchangeRate.GetCurrencyENNameAndSign(currency);

            //如果是供应商2 打印，单价，金额 * 0.7
            if (!isFirstSupplier)
            {
                foreach (var item in this.invoice.Details)
                {
                    item.InvoiceCODetailPrice = item.InvoiceCODetailPrice * 0.7m;
                    item.InvoiceCODetailMoney = Math.Round(item.InvoiceCODetailPrice.Value, 2, MidpointRounding.AwayFromZero) * (decimal)item.OrderQuantity.Value;
                }
            }


            if (currency != null)
            {
                //先将订单币别金额，转换为台币，在将台币转换为供应商1,供应商2 币别金额
                decimal invoiceCurrencyToTaibiRate = exchangeRateManager.GetRateByDateAndCurrency(invoice.InvoiceDate.Value, invoice.Currency);
                invoiceCurrencyToTaibiRate = invoiceCurrencyToTaibiRate == 0 ? 1 : invoiceCurrencyToTaibiRate;

                if (currency.Contains("台幣") || currency.Contains("台币"))
                {
                    foreach (var item in this.invoice.Details)
                    {
                        item.CurrencyPrice = item.InvoiceCODetailPrice.Value * invoiceCurrencyToTaibiRate;
                        item.CurrencyMoney = Math.Round(item.CurrencyPrice, 2, MidpointRounding.AwayFromZero) * (decimal)item.OrderQuantity.Value;
                    }

                    var taibiMoney = invoice.Details.Sum(d => d.CurrencyMoney);


                    this.lbl_TotalMoney.Text = "金額總計：新台幣" + CmycurD(Math.Round(taibiMoney, 2, MidpointRounding.AwayFromZero));

                    if ((int)taibiMoney == taibiMoney)
                        this.lbl_TotalMoney.Text += "整";

                    this.TC_TotalMoney.Text = taibiMoney.ToString("N2");

                }
                else
                {
                    decimal taibiToSupplierCurrencyRate = exchangeRateManager.GetRateByDateAndCurrency(invoice.InvoiceDate.Value, currency);
                    taibiToSupplierCurrencyRate = taibiToSupplierCurrencyRate == 0 ? 1 : taibiToSupplierCurrencyRate;

                    foreach (var item in this.invoice.Details)
                    {
                        item.CurrencyPrice = item.InvoiceCODetailPrice.Value * invoiceCurrencyToTaibiRate / taibiToSupplierCurrencyRate;
                        item.CurrencyMoney = Math.Round(item.CurrencyPrice, 2, MidpointRounding.AwayFromZero) * (decimal)item.OrderQuantity.Value;
                    }

                    var supplierCurrencyMoney = invoice.Details.Sum(d => d.CurrencyMoney);

                    this.lbl_TotalMoney.Text = string.Format("金額總計：{0}{1}{2}{3}{4}{5}匯率：{6}", currency, Model.ExchangeRate.GetCurrencyENNameAndSign(currency), supplierCurrencyMoney.ToString("N2"), "".PadLeft(20, ' '), invoice.InvoiceDate.Value.ToString("yyyy.MM.dd"), currency, taibiToSupplierCurrencyRate.ToString("0.####"));

                    this.TC_TotalMoney.Text = supplierCurrencyMoney.ToString("N2");
                }

                this.xrTableCellUintPrice.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_CurrencyPrice, "{0:N2}");
                this.xrTableCellMoney.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_CurrencyMoney, "{0:N2}");
            }
            else
            {
                this.xrTableCellUintPrice.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_InvoiceCODetailPrice, "{0:N2}");
                this.xrTableCellMoney.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_InvoiceCODetailMoney, "{0:N2}");

                this.TC_TotalMoney.Text = this.invoice.InvoiceHeji.Value.ToString("N2");
            }


            this.xrLabelNote.Text = this.invoice.InvoiceNote;

            //明细信息
            this.xrTableCellProductId.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_Inumber);
            this.TC_PRoduct_Id.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_Id);
            this.xrRichTextProductDescribe.DataBindings.Add("Rtf", this.DataSource, "Product." + Model.Product.PRO_ProductDescription);
            this.xrTableCellQuantity.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_OrderQuantity, "{0:N0}");

        }

        private string CmycurD(decimal num)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖";            //0-9所对应的汉字
            string str2 = "萬仟佰拾亿仟佰拾萬仟佰拾圓角分"; //数字位所对应的汉字
            string str3 = "";    //从原num值中取出的值
            string str4 = "";    //数字的字符串形式
            string str5 = "";  //人民币大写金额形式
            int i;    //循环变量
            int j;    //num的值乘以100的字符串长度
            string ch1 = "";    //数字的汉语读法
            string ch2 = "";    //数字位的汉字读法
            int nzero = 0;  //用来计算连续的零值是几个
            int temp;            //从原num值中取出的值

            num = Math.Round(Math.Abs(num), 2, MidpointRounding.AwayFromZero);    //将num取绝对值并四舍五入取2位小数
            str4 = ((long)(num * 100)).ToString();        //将num乘100并转换成字符串形式
            j = str4.Length;      //找出最高位
            if (j > 15) { return "溢出"; }
            str2 = str2.Substring(15 - j);   //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分

            //循环取出每一位需要转换的值
            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1);          //取出需转换的某一位的值
                temp = Convert.ToInt32(str3);      //转换为数字
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //如果该位是亿位或元位，则必须写上
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;

                if (i == j - 1 && str3 == "0")
                {
                    //最后一位（分）为0时，加上“整”
                    //str5 = str5 + '整';
                }
            }
            if (num == 0)
            {
                str5 = "零";
            }
            return str5;
        }
    }
}
