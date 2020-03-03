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
        /// �Ƿ��ǵ�һ�ҹ�Ӧ��
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

                //���½�ǩ����ͬ��Ӧ��
                this.xrLabel14.Text = supplier.SupplierFullName;
            }
            else
            {
                xrLabelCompanyInfoName.HeightF += 100;
                this.xrLabelCompanyInfoName.Text = companyName + "".PadLeft(40, ' ') + "(ӆ�΁�Դ��ALAN SAFETY COMPANY LIMITED)";

                //this.xrPanel1.LocationF.Y += 100;
                this.xrPanel1.LocationF = new PointF(this.xrPanel1.LocationF.X, this.xrPanel1.LocationF.Y + 100);

                //ת���������½ǵ�ǩ����ͬ��Ӧ��
                this.xrLabel15.Text = supplier.SupplierFullName;
            }

            this.lbl_Tel.Text = BL.Settings.CompanyPhone;
            this.lbl_Fax.Text = BL.Settings.CompanyFax;

            this.xrLabelData.Text = Properties.Resources.InvoiceCO;

            //��������Ϣ
            this.xrLabelCustomName.Text = supplier.SupplierFullName;

            //�͑���Ϣ
            if (this.invoice.Customer != null)
            {
                this.xrLabelCustomer.Text = this.invoice.Customer.CustomerFullName;
            }
            Model.InvoiceXO temp = this.invoiceXoManager.Get(this.invoice.InvoiceXOId);
            if (temp != null)
            {
                this.xrLabelInvoiceXOId.Text = temp.CustomerInvoiceXOId;
            }

            //������Ϣ
            this.xrLabelInvoiceDate.Text = this.invoice.InvoiceDate.Value.ToString("yyyy.MM.dd");
            this.xrLabelYJDate.Text = this.invoice.InvoiceYjrq == null ? "" : this.invoice.InvoiceYjrq.Value.ToString("yyyy.MM.dd");
            this.xrLabelInvoiceId.Text = this.invoice.InvoiceId;
            this.lbl_shipment.Text = this.invoice.Shipment;

            //��Ӌ
            this.TC_TotalQty.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_OrderQuantity);

            string currency = isFirstSupplier ? invoice.SupplierCurrency1 : invoice.SupplierCurrency2;
            this.TC_PriceUnit.Text = string.Format("({0})", Model.ExchangeRate.GetCurrencyENNameAndSign(currency));
            this.TC_TotalPrice.Text = Model.ExchangeRate.GetCurrencyENNameAndSign(currency);

            //����ǹ�Ӧ��2 ��ӡ�����ۣ���� * 0.7
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
                //�Ƚ������ұ��ת��Ϊ̨�ң��ڽ�̨��ת��Ϊ��Ӧ��1,��Ӧ��2 �ұ���
                decimal invoiceCurrencyToTaibiRate = exchangeRateManager.GetRateByDateAndCurrency(invoice.InvoiceDate.Value, invoice.Currency);
                invoiceCurrencyToTaibiRate = invoiceCurrencyToTaibiRate == 0 ? 1 : invoiceCurrencyToTaibiRate;

                if (currency.Contains("̨��") || currency.Contains("̨��"))
                {
                    foreach (var item in this.invoice.Details)
                    {
                        item.CurrencyPrice = item.InvoiceCODetailPrice.Value * invoiceCurrencyToTaibiRate;
                        item.CurrencyMoney = Math.Round(item.CurrencyPrice, 2, MidpointRounding.AwayFromZero) * (decimal)item.OrderQuantity.Value;
                    }

                    var taibiMoney = invoice.Details.Sum(d => d.CurrencyMoney);


                    this.lbl_TotalMoney.Text = "���~��Ӌ����̨��" + CmycurD(Math.Round(taibiMoney, 2, MidpointRounding.AwayFromZero));

                    if ((int)taibiMoney == taibiMoney)
                        this.lbl_TotalMoney.Text += "��";

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

                    this.lbl_TotalMoney.Text = string.Format("���~��Ӌ��{0}{1}{2}{3}{4}{5}�R�ʣ�{6}", currency, Model.ExchangeRate.GetCurrencyENNameAndSign(currency), supplierCurrencyMoney.ToString("N2"), "".PadLeft(20, ' '), invoice.InvoiceDate.Value.ToString("yyyy.MM.dd"), currency, taibiToSupplierCurrencyRate.ToString("0.####"));

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

            //��ϸ��Ϣ
            this.xrTableCellProductId.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_Inumber);
            this.TC_PRoduct_Id.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_Id);
            this.xrRichTextProductDescribe.DataBindings.Add("Rtf", this.DataSource, "Product." + Model.Product.PRO_ProductDescription);
            this.xrTableCellQuantity.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_OrderQuantity, "{0:N0}");

        }

        private string CmycurD(decimal num)
        {
            string str1 = "��Ҽ��������½��ƾ�";            //0-9����Ӧ�ĺ���
            string str2 = "�fǪ��ʰ��Ǫ��ʰ�fǪ��ʰ�A�Ƿ�"; //����λ����Ӧ�ĺ���
            string str3 = "";    //��ԭnumֵ��ȡ����ֵ
            string str4 = "";    //���ֵ��ַ�����ʽ
            string str5 = "";  //����Ҵ�д�����ʽ
            int i;    //ѭ������
            int j;    //num��ֵ����100���ַ�������
            string ch1 = "";    //���ֵĺ������
            string ch2 = "";    //����λ�ĺ��ֶ���
            int nzero = 0;  //����������������ֵ�Ǽ���
            int temp;            //��ԭnumֵ��ȡ����ֵ

            num = Math.Round(Math.Abs(num), 2, MidpointRounding.AwayFromZero);    //��numȡ����ֵ����������ȡ2λС��
            str4 = ((long)(num * 100)).ToString();        //��num��100��ת�����ַ�����ʽ
            j = str4.Length;      //�ҳ����λ
            if (j > 15) { return "���"; }
            str2 = str2.Substring(15 - j);   //ȡ����Ӧλ����str2��ֵ���磺200.55,jΪ5����str2=��ʰԪ�Ƿ�

            //ѭ��ȡ��ÿһλ��Ҫת����ֵ
            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1);          //ȡ����ת����ĳһλ��ֵ
                temp = Convert.ToInt32(str3);      //ת��Ϊ����
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //����ȡλ����ΪԪ�����ڡ������ϵ�����ʱ
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
                            ch1 = "��" + str1.Substring(temp * 1, 1);
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
                    //��λ�����ڣ��ڣ���Ԫλ�ȹؼ�λ
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "��" + str1.Substring(temp * 1, 1);
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
                    //�����λ����λ��Ԫλ�������д��
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;

                if (i == j - 1 && str3 == "0")
                {
                    //���һλ���֣�Ϊ0ʱ�����ϡ�����
                    //str5 = str5 + '��';
                }
            }
            if (num == 0)
            {
                str5 = "��";
            }
            return str5;
        }
    }
}
