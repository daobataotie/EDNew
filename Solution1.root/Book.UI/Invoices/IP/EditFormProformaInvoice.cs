using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Book.UI.Settings.BasicData.Employees;
using System.Linq;
using DevExpress.XtraGrid.Columns;

namespace Book.UI.Invoices.IP
{
    public partial class EditFormProformaInvoice : BaseEditForm
    {
        Model.ProformaInvoice proformaInvoice = new Model.ProformaInvoice();
        BL.ProformaInvoiceManager proformaInvoiceManager = new Book.BL.ProformaInvoiceManager();
        BL.ProductManager productManager = new Book.BL.ProductManager();

        public EditFormProformaInvoice()
        {
            InitializeComponent();

            this.requireValueExceptions.Add(Model.ProformaInvoice.PRO_PO, new AA("PO 不能為空！", this.txt_PONo));
            this.requireValueExceptions.Add(Model.ProformaInvoice.PRO_InvoiceDate, new AA("Date 不能為空！", this.Date_InvoiceDate));
            this.requireValueExceptions.Add(Model.ProformaInvoice.PRO_CustomerId, new AA("TO 不能為空！", this.ncc_Customer));

            this.action = "view";

            this.ncc_Customer.Choose = new Settings.BasicData.Customs.ChooseCustoms();
            this.bindingSourceBank.DataSource = new BL.BankManager().Select();


            this.repositoryItemSearchLookUpEdit1.DisplayMember = "Id";
            this.repositoryItemSearchLookUpEdit1.ValueMember = "ProductId";
            this.repositoryItemSearchLookUpEdit1.View.Columns.Add(new GridColumn() { FieldName = "Id", Caption = "商品編號", Width = 150, Visible = true, VisibleIndex = 0 });
            this.repositoryItemSearchLookUpEdit1.View.Columns.Add(new GridColumn() { FieldName = "ProductName", Caption = "商品名稱", Width = 150, Visible = true, VisibleIndex = 1 });
            this.repositoryItemSearchLookUpEdit1.View.Columns.Add(new GridColumn() { FieldName = "CustomerProductName", Caption = "客戶貨品名稱", Width = 150, Visible = true, VisibleIndex = 2 });
            this.repositoryItemSearchLookUpEdit1.View.Columns.Add(new GridColumn() { FieldName = "ProductVersion", Caption = "版本", Width = 50, Visible = true, VisibleIndex = 3 });

            this.repositoryItemSearchLookUpEdit2.DisplayMember = "ProductName";
            this.repositoryItemSearchLookUpEdit2.ValueMember = "ProductId";
            this.repositoryItemSearchLookUpEdit2.View.Columns.Add(new GridColumn() { FieldName = "Id", Caption = "商品編號", Width = 150, Visible = true, VisibleIndex = 0 });
            this.repositoryItemSearchLookUpEdit2.View.Columns.Add(new GridColumn() { FieldName = "ProductName", Caption = "商品名稱", Width = 150, Visible = true, VisibleIndex = 1 });
            this.repositoryItemSearchLookUpEdit2.View.Columns.Add(new GridColumn() { FieldName = "CustomerProductName", Caption = "客戶貨品名稱", Width = 150, Visible = true, VisibleIndex = 2 });
            this.repositoryItemSearchLookUpEdit2.View.Columns.Add(new GridColumn() { FieldName = "ProductVersion", Caption = "版本", Width = 50, Visible = true, VisibleIndex = 3 });

            this.repositoryItemSearchLookUpEdit1.DataSource = productManager.SelectProductForXO();
            this.repositoryItemSearchLookUpEdit2.DataSource = productManager.SelectProductForXO();
        }

        int LastFlag = 0; //页面载 入时是否执行 last方法
        public EditFormProformaInvoice(string invoiceId)
            : this()
        {
            this.proformaInvoice = this.proformaInvoiceManager.Get(invoiceId);
            if (this.proformaInvoice == null)
                throw new ArithmeticException("invoiceid");
            this.action = "view";
            if (this.action == "view")
                LastFlag = 1;
        }

        public EditFormProformaInvoice(Model.ProformaInvoice invoice)
            : this()
        {
            if (invoice == null)
                throw new ArithmeticException("invoiceid");
            this.proformaInvoice = invoice;
            this.action = "view";
            if (this.action == "view")
                LastFlag = 1;
        }


        public override Book.Model.Invoice Invoice
        {
            get
            {
                return proformaInvoice;
            }
            set
            {
                if (value is Model.ProformaInvoice)
                {
                    proformaInvoice = this.proformaInvoiceManager.Get((value as Model.ProformaInvoice).PO);
                }
            }
        }


        protected override void AddNew()
        {
            this.proformaInvoice = new Book.Model.ProformaInvoice();
            proformaInvoice.InvoiceDate = DateTime.Now;


            this.action = "insert";
        }

        public override void Refresh()
        {
            if (this.proformaInvoice == null)
                this.AddNew();
            else
            {
                if (this.action == "view")  //打印時去掉PLTNO，修改時刷新一下顯示出來
                {
                    this.proformaInvoice = this.proformaInvoiceManager.GetDetail(this.proformaInvoice.PO);
                }
            }

            this.txt_PONo.Text = this.proformaInvoice.PO;
            this.Date_InvoiceDate.EditValue = this.proformaInvoice.InvoiceDate;
            this.ncc_Customer.EditValue = this.proformaInvoice.Customer;
            if (this.ncc_Customer.EditValue != null)
            {
                this.txt_CustomerAddress.Text = this.proformaInvoice.Customer.CustomerAddress;
                this.txt_Tel.Text = this.proformaInvoice.Customer.CustomerPhone;
                this.txt_Attn.Text = this.proformaInvoice.Customer.CustomerContact;
                this.txt_TERM.Text = this.proformaInvoice.Customer.TradingCondition;
                this.txt_PaymentTerm.Text = this.proformaInvoice.Customer.PayCondition;
            }
            else
            {
                this.txt_CustomerAddress.Text = "";
                this.txt_Tel.Text = "";
                this.txt_Attn.Text = "";
                this.txt_TERM.Text = "";
                this.txt_PaymentTerm.Text = "";

            }
            this.txt_DeliveryTo.EditValue = this.proformaInvoice.DeliveryTo;
            this.txt_Attn.Text = this.proformaInvoice.Attn;
            this.cob_Currency.Text = this.proformaInvoice.Currency;
            this.txt_Remark.Text = this.proformaInvoice.Remark;
            this.txt_Deliverydate.Text = this.proformaInvoice.DeliveryDate;
            this.lue_AccountName.EditValue = this.proformaInvoice.BankId;
            this.me_ShippimgMark.Text = this.proformaInvoice.ShippimgMark;

            switch (this.action)
            {
                case "insert":
                    this.gridView3.OptionsBehavior.Editable = true;
                    break;
                case "update":
                    this.gridView3.OptionsBehavior.Editable = true;
                    break;
                default:
                    this.gridView3.OptionsBehavior.Editable = false;
                    break;
            }

            this.bindingSourceDetail.DataSource = this.proformaInvoice.Details;

            base.Refresh();

            if (this.action == "update")
                this.txt_PONo.Properties.ReadOnly = true;
        }

        protected override void Save(Helper.InvoiceStatus status)
        {
            if (!this.gridView3.PostEditor() || !this.gridView3.UpdateCurrentRow())
                return;

            this.proformaInvoice.PO = this.txt_PONo.Text.Trim();
            if (this.Date_InvoiceDate.EditValue != null)
                this.proformaInvoice.InvoiceDate = this.Date_InvoiceDate.DateTime;
            if (this.ncc_Customer.EditValue != null)
            {
                this.proformaInvoice.CustomerId = (this.ncc_Customer.EditValue as Model.Customer).CustomerId;
                this.proformaInvoice.Customer = this.ncc_Customer.EditValue as Model.Customer;
            }
            this.proformaInvoice.DeliveryTo = this.txt_DeliveryTo.Text;
            this.proformaInvoice.Attn = this.txt_Attn.Text;
            this.proformaInvoice.Currency = this.cob_Currency.Text;
            this.proformaInvoice.Remark = this.txt_Remark.Text;
            this.proformaInvoice.DeliveryDate = this.txt_Deliverydate.Text;
            this.proformaInvoice.BankId = this.lue_AccountName.EditValue == null ? null : this.lue_AccountName.EditValue.ToString();
            this.proformaInvoice.ShippimgMark = this.me_ShippimgMark.Text;

            if (this.action == "insert")
                this.proformaInvoiceManager.Insert(this.proformaInvoice);
            if (this.action == "update")
                this.proformaInvoiceManager.Update(this.proformaInvoice);
        }

        protected override void MoveLast()
        {
            if (this.LastFlag == 1)
            {
                this.LastFlag = 0;
                return;
            }
            this.proformaInvoice = this.proformaInvoiceManager.GetLast();
        }

        protected override void MoveFirst()
        {
            this.proformaInvoice = this.proformaInvoiceManager.GetFirst();
        }

        protected override void MovePrev()
        {
            Model.ProformaInvoice model = this.proformaInvoiceManager.GetPrev(this.proformaInvoice);
            if (model == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);
            this.proformaInvoice = model;
        }

        protected override void MoveNext()
        {
            Model.ProformaInvoice model = this.proformaInvoiceManager.GetNext(this.proformaInvoice);
            if (model == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);
            this.proformaInvoice = model;
        }

        protected override bool HasRows()
        {
            return this.proformaInvoiceManager.HasRows();
        }

        protected override bool HasRowsPrev()
        {
            return this.proformaInvoiceManager.HasRowsBefore(this.proformaInvoice);
        }

        protected override bool HasRowsNext()
        {
            return this.proformaInvoiceManager.HasRowsAfter(this.proformaInvoice);
        }

        protected override void Delete()
        {
            //if (this._invoicePacking == null)
            //    return;
            //if (MessageBox.Show(Properties.Resources.ConfirmToDelete, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    this._invoicePackingManager.Delete(this._invoicePacking.InvoicePackingId);
            //    this._invoicePacking = this._invoicePackingManager.GetNext(this._invoicePacking);
            //    if (this._invoicePacking == null)
            //        this._invoicePacking = this._invoicePackingManager.GetLast();
            //}
        }

        protected override void TurnNull()
        {
            if (this.proformaInvoice == null)
                return;
            if (MessageBox.Show(Properties.Resources.ConfirmToDelete, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.proformaInvoiceManager.Delete(this.proformaInvoice.PO);
                this.proformaInvoice = this.proformaInvoiceManager.GetNext(this.proformaInvoice);
                if (this.proformaInvoice == null)
                    this.proformaInvoice = this.proformaInvoiceManager.GetLast();
            }
        }

        public override BaseListForm GetListForm()
        {
            return new ListFormProformaInvoice();
        }

        protected override DevExpress.XtraReports.UI.XtraReport GetReport()
        {
            return new ROProformaInvoice(this.proformaInvoice);
        }

        /// <summary>
        /// 添加客户订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string tableCode()
        {
            return "ProformaInvoice";
        }

        protected override int AuditState()
        {
            return this.proformaInvoice.AuditState.HasValue ? this.proformaInvoice.AuditState.Value : 0;
        }

        private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "gridColumn10")
            {
                Model.ProformaInvoiceDetail detail = this.bindingSourceDetail.Current as Model.ProformaInvoiceDetail;
                if (detail != null)
                {
                    decimal price = 0;
                    decimal.TryParse((e.Value == null ? "0" : e.Value.ToString()), out price);
                    detail.Amount = detail.Quantity * price;

                    this.gridControl3.RefreshDataSource();
                }
            }
            else if (e.Column.Name == "gridColumn9")
            {
                Model.ProformaInvoiceDetail detail = this.bindingSourceDetail.Current as Model.ProformaInvoiceDetail;
                if (detail != null)
                {
                    decimal qty = 0;
                    decimal.TryParse((e.Value == null ? "0" : e.Value.ToString()), out qty);
                    detail.Amount = detail.UnitPrice * qty;

                    this.gridControl3.RefreshDataSource();
                }
            }
        }

        //选择客户订单
        private void btn_ChooseInvoiceXO_Click(object sender, EventArgs e)
        {
            if (this.ncc_Customer.EditValue == null)
            {
                MessageBox.Show("請先選擇客戶", "提示", MessageBoxButtons.OK);
                return;
            }

            XS.SearcharInvoiceXSForm f = new Book.UI.Invoices.XS.SearcharInvoiceXSForm(this.ncc_Customer.EditValue as Model.Customer);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                if (f.key != null && f.key.Count > 0)
                {
                    if (!string.IsNullOrEmpty(f.key[0].Invoice.Currency))
                    
                    {
                        this.cob_Currency.Text = Model.ExchangeRate.GetCurrencyENName(f.key[0].Invoice.Currency);
                    }

                    Model.ProformaInvoiceDetail proformaInvoiceDetail = null;

                    foreach (Model.InvoiceXODetail detail in f.key)
                    {
                        proformaInvoiceDetail = new Book.Model.ProformaInvoiceDetail();
                        proformaInvoiceDetail.ProformaInvoiceDetailId = Guid.NewGuid().ToString();
                        proformaInvoiceDetail.ProformaInvoiceId = this.proformaInvoice.PO;
                        proformaInvoiceDetail.ProductId = detail.ProductId;
                        proformaInvoiceDetail.Product = detail.Product;
                        proformaInvoiceDetail.Quantity = Convert.ToInt32(detail.InvoiceXODetailQuantity);
                        proformaInvoiceDetail.UnitPrice = detail.InvoiceXODetailPrice;
                        proformaInvoiceDetail.Amount = proformaInvoiceDetail.Quantity * proformaInvoiceDetail.UnitPrice;
                        proformaInvoiceDetail.Unit = "PCS";

                        this.proformaInvoice.Details.Add(proformaInvoiceDetail);
                    }

                    this.CombineSameItem();

                    if (this.proformaInvoice.Details != null && this.proformaInvoice.Details.Count > 0)
                        this.proformaInvoice.Details.ToList().ForEach(D => D.Number = (this.proformaInvoice.Details.IndexOf(D) + 1));

                    this.bindingSourceDetail.DataSource = this.proformaInvoice.Details;
                    this.gridControl3.RefreshDataSource();
                }
            }             

            if (this.proformaInvoice.Details != null && this.proformaInvoice.Details.Count > 0)
                this.proformaInvoice.Details.ToList().ForEach(D => D.Number = (this.proformaInvoice.Details.IndexOf(D) + 1));

            this.bindingSourceDetail.DataSource = this.proformaInvoice.Details;
            this.gridControl3.RefreshDataSource();

        }

        private void CombineSameItem()
        {
            //相同商品合并为一条
            List<Model.ProformaInvoiceDetail> list = new List<Book.Model.ProformaInvoiceDetail>();
            var group = this.proformaInvoice.Details.GroupBy(d => new { d.ProductId });
            foreach (var item in group)
            {
                Model.ProformaInvoiceDetail model = item.First();
                model.Quantity = item.Sum(d => d.Quantity);
                model.Amount = model.Quantity * model.UnitPrice;

                list.Add(model);
            }
            this.proformaInvoice.Details = list;
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (this.bindingSourceDetail.Current != null)
            {
                this.proformaInvoice.Details.Remove(this.bindingSourceDetail.Current as Model.ProformaInvoiceDetail);

                if (this.proformaInvoice.Details != null && this.proformaInvoice.Details.Count > 0)
                    this.proformaInvoice.Details.ToList().ForEach(D => D.Number = (this.proformaInvoice.Details.IndexOf(D) + 1));

                this.gridControl3.RefreshDataSource();
            }
        }

        private void ncc_Customer_EditValueChanged(object sender, EventArgs e)
        {
            if (this.ncc_Customer.EditValue != null)
            {
                Model.Customer customer = this.ncc_Customer.EditValue as Model.Customer;
                this.txt_CustomerAddress.Text = customer.CustomerAddress;
                this.txt_DeliveryTo.Text = customer.CustomerJinChuAddress;
                this.txt_Tel.Text = customer.CustomerPhone;
                this.txt_Attn.Text = customer.CustomerContact;
                this.txt_TERM.Text = customer.TradingCondition;
                this.txt_PaymentTerm.Text = customer.PayCondition;
            }
            else
            {
                this.txt_CustomerAddress.Text = "";
                this.txt_DeliveryTo.Text = "";
                this.txt_Tel.Text = "";
                this.txt_Attn.Text = "";
                this.txt_TERM.Text = "";
                this.txt_PaymentTerm.Text = "";

            }
        }

        private void lue_AccountName_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lue_AccountName.EditValue != null)
            {
                Model.Bank bank = (this.bindingSourceBank.DataSource as IList<Model.Bank>).First(B => B.BankId == this.lue_AccountName.EditValue.ToString());
                this.txt_AccountNo.Text = bank.Id;
                this.txt_BankName.Text = bank.BankName;
                this.txt_BankAddress.Text = bank.BankAddress;
                this.txt_SWIFTCode.Text = bank.SWIFTCode;
            }
            else
            {
                this.txt_AccountNo.Text = "";
                this.txt_BankName.Text = "";
                this.txt_BankAddress.Text = "";
                this.txt_SWIFTCode.Text = "";
            }
        }

        private void gridView3_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.action == "insert" || this.action == "update")
            {
                if (e.KeyData == Keys.Enter)
                {
                    if (this.CanAdd(this.proformaInvoice.Details))
                    {
                        Model.ProformaInvoiceDetail proformaInvoiceDetail = null;
                        proformaInvoiceDetail = new Book.Model.ProformaInvoiceDetail();
                        proformaInvoiceDetail.ProformaInvoiceDetailId = Guid.NewGuid().ToString();
                        proformaInvoiceDetail.ProformaInvoiceId = this.proformaInvoice.PO;
                        proformaInvoiceDetail.Quantity = 0;
                        proformaInvoiceDetail.UnitPrice = 0;
                        proformaInvoiceDetail.Amount = 0;
                        proformaInvoiceDetail.Unit = "PCS";

                        this.proformaInvoice.Details.Add(proformaInvoiceDetail);

                        this.CombineSameItem();

                        if (this.proformaInvoice.Details != null && this.proformaInvoice.Details.Count > 0)
                            this.proformaInvoice.Details.ToList().ForEach(D => D.Number = (this.proformaInvoice.Details.IndexOf(D) + 1));

                        this.gridControl3.RefreshDataSource();
                    }
                }

            }
        }

        private bool CanAdd(IList<Model.ProformaInvoiceDetail> list)
        {
            foreach (Model.ProformaInvoiceDetail detail in list)
            {
                if (detail.Product == null || string.IsNullOrEmpty(detail.Product.ProductId))
                    return false;
            }
            return true;
        }

        private void bar_GenerateXO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XO.EditForm f = new Book.UI.Invoices.XO.EditForm(this.proformaInvoice.Details);
            f.ShowDialog(this);
        }
    }
}
