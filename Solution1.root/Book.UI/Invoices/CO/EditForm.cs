﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Book.UI.Settings.BasicData.Employees;
namespace Book.UI.Invoices.CO
{
    public partial class EditForm : BaseEditForm
    {
        protected BL.InvoiceCOManager invoiceManager = new Book.BL.InvoiceCOManager();
        protected BL.InvoiceCODetailManager invoiceDetailManager = new Book.BL.InvoiceCODetailManager();
        protected BL.InvoiceCJDetailManager invoiceCJDetailManager = new Book.BL.InvoiceCJDetailManager();
        protected BL.InvoiceCJManager invoiceCJManager = new Book.BL.InvoiceCJManager();
        protected BL.ProductManager productManager = new Book.BL.ProductManager();
        private Model.InvoiceCO invoice;
        private Model.InvoiceCJ invoicecj;
        private BL.SupplierProductManager supplierProductManager = new Book.BL.SupplierProductManager();
        private BL.InvoiceCGManager invoiceCGManager = new Book.BL.InvoiceCGManager();
        private BL.InvoiceCGDetailManager invoiceCGDetailManager = new Book.BL.InvoiceCGDetailManager();
        private BL.ExchangeRateManager exchangeRateManager = new Book.BL.ExchangeRateManager();

        //四射五入保留位数 
        private const int SISHEWURU_WEISHU = 3;

        #region Constructors
        public EditForm()
        {
            InitializeComponent();

            this.requireValueExceptions.Add("Id", new AA(Properties.Resources.RequireDataForId, this.textEditInvoiceId));
            this.requireValueExceptions.Add("Date", new AA(Properties.Resources.RequireDataOfInvoiceDate, this.dateEditInvoiceDate));
            this.requireValueExceptions.Add("Employee0", new AA(Properties.Resources.RequiredDataOfEmployee0, this.buttonEditEmployee));
            this.requireValueExceptions.Add("Details", new AA(Properties.Resources.RequireDataForDetails, this.gridControl1));
            this.requireValueExceptions.Add("Company", new AA(Properties.Resources.RequireDataForCompany, this.ncc_Supplier1));
            //  this.requireValueExceptions.Add("Price", new AA(Properties.Resources.RequirePrice, this.gridControl1));

            this.invalidValueExceptions.Add(Model.InvoiceCO.PROPERTY_INVOICEID, new AA(Properties.Resources.EntityExists, this.textEditInvoiceId));

            this.ncc_Supplier1.Choose = new Book.UI.Settings.BasicData.Supplier.ChooseSupplier();
            //2019年12月28日19:37:35
            this.ncc_Supplier2.Choose = new Settings.BasicData.Supplier.ChooseSupplier();

            this.buttonEditEmployee.Choose = new ChooseEmployee();
            this.buttonEditEmployee1.Choose = new ChooseEmployee();
            this.buttonEditEmployee2.Choose = new ChooseEmployee();
            this.newChooseCustomer.Choose = new Settings.BasicData.Customs.ChooseCustoms();
            //this.newChooseContorlAtCurrencyCate.Choose = new Accounting.CurrencyCategory.ChooseAtCurrencyCategory();
            this.EmpAudit.Choose = new ChooseEmployee();
            this.bindingSourceWorkHouse.DataSource = new BL.WorkHouseManager().Select();
            this.action = "view";

            //if (BL.Settings.authorityOperationId.Contains(BL.V.ActiveOperator.OperatorsId))
            //{
            //    this.colInvoiceCODetailMoney.Visible = true;
            //    this.colInvoiceCODetailPrice.Visible = true;
            //}
            //else
            //{
            //    this.colInvoiceCODetailMoney.Visible = false;
            //    this.colInvoiceCODetailPrice.Visible = false;
            //}
        }

        private Model.InvoiceXO _invoiceXO;
        public EditForm(Model.InvoiceXO invoiceXO)
            : this()
        {
            _invoiceXO = invoiceXO;
            this.action = "insert";

        }

        int LastFlag = 0;
        public EditForm(string invoiceId)
            : this()
        {
            this.invoice = this.invoiceManager.Get(invoiceId);
            if (this.invoice == null)
                throw new ArithmeticException("invoiceid");
            this.action = "view";
            if (this.action == "view")
                LastFlag = 1;
        }

        public EditForm(Model.InvoiceCO invoiceco)
            : this()
        {
            if (invoiceco == null)
                throw new ArithmeticException("invoiceid");
            this.invoice = invoiceco;
            this.action = "view";
            if (this.action == "view")
                LastFlag = 1;
        }

        public EditForm(Model.InvoiceCJ invoice)
            : this()
        {
            this.invoicecj = this.invoiceCJManager.Get(invoice.InvoiceId);
            this.action = "insert";
        }
        #endregion

        #region Form Load
        private void EditForm_Load(object sender, EventArgs e)
        {
            //string sql = "SELECT productid,id,productname FROM product WHERE IsCustomerProduct IS NULL OR IsCustomerProduct =0";
            //this.bindingSource2.DataSource = this.productManager.DataReaderBind<Model.Product>(sql, null, CommandType.Text);
            // this.bindingSource2.DataSource = this.productManager.SelectNotCustomer();
            GetCo();
        }

        protected override string tableCode()
        {
            return "InvoiceCO";
        }

        protected override int AuditState()
        {
            return this.invoice.AuditState.HasValue ? this.invoice.AuditState.Value : 0;
        }

        protected override string getName()
        {
            string formName = this.GetType().FullName;
            formName = formName.Substring(formName.IndexOf('.') + 1).Substring(formName.Substring(formName.IndexOf('.') + 1).IndexOf('.') + 1);
            return formName;
        }
        #endregion

        #region Choose Object
        private void buttonEditEmployee_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ChooseEmployeeForm f = new ChooseEmployeeForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                (sender as ButtonEdit).EditValue = f.SelectedItem;
            }
        }

        private void buttonEditCompany_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ChooseSupplier f = new ChooseSupplier();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                (sender as ButtonEdit).EditValue = f.SelectedItem;
            }
        }
        #endregion

        private void simpleButtonAppend_Click(object sender, EventArgs e)
        {
            ChooseProductForm f = new ChooseProductForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {

                BL.SupplierProductManager supplierproductmanager = new Book.BL.SupplierProductManager();

                if (this.invoice.Details.Count > 0 && string.IsNullOrEmpty(this.invoice.Details[0].ProductId))
                    this.invoice.Details.RemoveAt(0);
                Model.InvoiceCODetail detail = null;
                if (ChooseProductForm.ProductList != null || ChooseProductForm.ProductList.Count > 0)
                {
                    foreach (Model.Product product in ChooseProductForm.ProductList)
                    {
                        detail = new Book.Model.InvoiceCODetail();
                        detail.Invoice = this.invoice;
                        detail.Inumber = this.invoice.Details.Count + 1;
                        detail.InvoiceCODetailId = Guid.NewGuid().ToString();
                        detail.Product = product;
                        detail.ProductId = product.ProductId;
                        detail.InvoiceCODetailMoney = decimal.Zero;
                        detail.InvoiceCODetailNote = "";
                        detail.InvoiceCODetailPrice = decimal.Zero;
                        //if (string.IsNullOrEmpty(detail.Product.SupplierId))
                        //{
                        //    detail.DetailsPriceRange = string.Empty;
                        //}
                        //else
                        //{
                        //    detail.DetailsPriceRange = supplierproductmanager.GetPriceRangeForSupAndProduct(detail.Product.SupplierId, detail.ProductId);
                        //}
                        //if ((this.buttonEditCompany.EditValue as Model.Supplier) == null && string.IsNullOrEmpty(detail.Product.SupplierId))
                        //    MessageBox.Show("廠商為空，不能計算商品單價！", this.Text);
                        //else
                        //{
                        //    if ((this.buttonEditCompany.EditValue as Model.Supplier) != null)
                        //        detail.DetailsPriceRange = this.supplierProductManager.GetPriceRangeForSupAndProduct((this.buttonEditCompany.EditValue as Model.Supplier).SupplierId, detail.ProductId);
                        //    else
                        //        detail.DetailsPriceRange = this.supplierProductManager.GetPriceRangeForSupAndProduct(detail.Product.SupplierId, detail.ProductId);
                        //}

                        detail.DetailsPriceRange = detail.Product.PriceAndRange;

                        detail.OrderQuantity = 0;
                        detail.ArrivalQuantity = 0;
                        detail.NoArrivalQuantity = 0;
                        if (detail.Product.BuyUnit != null)
                            detail.InvoiceProductUnit = detail.Product.BuyUnit.ToString();
                        this.invoice.Details.Add(detail);
                    }
                }
                if (ChooseProductForm.ProductList == null || ChooseProductForm.ProductList.Count == 0)
                {
                    detail = new Book.Model.InvoiceCODetail();
                    detail.Inumber = this.invoice.Details.Count + 1;
                    detail.Invoice = this.invoice;
                    detail.InvoiceCODetailId = Guid.NewGuid().ToString();
                    detail.Product = f.SelectedItem as Model.Product;
                    detail.ProductId = (f.SelectedItem as Model.Product).ProductId;
                    detail.InvoiceCODetailMoney = decimal.Zero;
                    detail.InvoiceCODetailNote = "";
                    detail.InvoiceCODetailPrice = decimal.Zero;

                    //if (string.IsNullOrEmpty(detail.Product.SupplierId))
                    //{
                    //    detail.DetailsPriceRange = string.Empty;
                    //}
                    //else
                    //{
                    //    detail.DetailsPriceRange = supplierproductmanager.GetPriceRangeForSupAndProduct(detail.Product.SupplierId, detail.ProductId);
                    //}
                    //if ((this.buttonEditCompany.EditValue as Model.Supplier) == null && string.IsNullOrEmpty(detail.Product.SupplierId))
                    //    MessageBox.Show("廠商為空，不能計算商品單價！", this.Text);
                    //else
                    //{
                    //    if ((this.buttonEditCompany.EditValue as Model.Supplier) != null)
                    //        detail.DetailsPriceRange = this.supplierProductManager.GetPriceRangeForSupAndProduct((this.buttonEditCompany.EditValue as Model.Supplier).SupplierId, detail.ProductId);
                    //    else
                    //        detail.DetailsPriceRange = this.supplierProductManager.GetPriceRangeForSupAndProduct(detail.Product.SupplierId, detail.ProductId);
                    //}

                    detail.DetailsPriceRange = detail.Product.PriceAndRange;
                    detail.OrderQuantity = 0;
                    detail.ArrivalQuantity = 0;
                    detail.NoArrivalQuantity = 0;
                    if (detail.Product.BuyUnit != null)
                        detail.InvoiceProductUnit = detail.Product.BuyUnit.ToString();
                    this.invoice.Details.Add(detail);
                }
                this.bindingSource1.Position = this.bindingSource1.IndexOf(detail);
                this.gridControl1.RefreshDataSource();
                //this.bindingSource2.DataSource = this.productManager.SelectNotCustomer();
            }
            f.Dispose();
            System.GC.Collect();
        }

        private void simpleButtonRemove_Click(object sender, EventArgs e)
        {
            if (this.bindingSource1.Current != null)
            {
                this.invoice.Details.Remove(this.bindingSource1.Current as Model.InvoiceCODetail);
                if (this.invoice.Details.Count == 0)
                {
                    Model.InvoiceCODetail detail = new Model.InvoiceCODetail();
                    detail.Inumber = this.invoice.Details.Count + 1;
                    detail.InvoiceCODetailId = Guid.NewGuid().ToString();
                    detail.InvoiceCODetailMoney = 0;
                    detail.InvoiceCODetailNote = "";
                    detail.InvoiceCODetailPrice = 0;
                    detail.NoArrivalQuantity = 1;
                    detail.ArrivalQuantity = 0;
                    detail.OrderQuantity = 1;
                    detail.InvoiceProductUnit = "";
                    detail.Product = new Book.Model.Product();
                    this.invoice.Details.Add(detail);
                    this.bindingSource1.Position = this.bindingSource1.IndexOf(detail);
                }
                this.gridControl1.RefreshDataSource();
                this.UpdateMoneyFields();
            }
        }

        protected override void Save(Helper.InvoiceStatus status)
        {
            if (!this.gridView1.PostEditor() || !this.gridView1.UpdateCurrentRow())
                return;
            this.invoice.InvoiceId = this.textEditInvoiceId.Text;
            this.invoice.InvoiceDate = this.dateEditInvoiceDate.DateTime;
            this.invoice.Supplier = this.ncc_Supplier1.EditValue as Model.Supplier;
            if (this.invoice.Supplier != null)
                this.invoice.SupplierId = this.invoice.Supplier.SupplierId;
            this.invoice.Supplier2 = this.ncc_Supplier2.EditValue as Model.Supplier;
            this.invoice.SupplierId2 = this.invoice.Supplier2 == null ? null : this.invoice.Supplier2.SupplierId;

            this.invoice.InvoiceNote = this.textEditNote.Text;
            this.invoice.InvoiceLRTime = DateTime.Now;
            this.invoice.InvoiceYjrq = this.dateEditInvoiceYjrq.DateTime.Date;
            this.invoice.InvoiceTaxrate = double.Parse(this.spinEditInvoiceTaxRate.Text);
            this.invoice.InvoiceTax = decimal.Parse(this.calcEditInvoiceTax.Text);
            this.invoice.InvoiceTotal = decimal.Parse(this.calcEditInvoiceTotal.Text);
            this.invoice.InvoiceHeji = decimal.Parse(this.calcEditInvoiceHeji.Text);
            this.invoice.InvoiceFPDate = this.dateEditFPDate.DateTime;
            this.invoice.InvoicePayable = this.spinEditInvoiceOwed.Value;
            this.invoice.InvoiceLRTime = DateTime.Now;
            this.invoice.InvoiceFPBH = this.textEditInvoiceFpbh.Text;
            this.invoice.InvoiceKSLB = this.comboBoxEditInvoiceKslb.Text;
            this.invoice.InvoiceKLFS = this.comboBoxEditInvoiceKlfs.Text;
            this.invoice.InvoiceKPLS = this.comboBoxEditInvoiceFpls.Text;
            this.invoice.InvoiceFPJE = decimal.Parse(string.IsNullOrEmpty(this.spinEditInvoiceFpje.Text) ? "0" : this.spinEditInvoiceFpje.Text);
            this.invoice.InvoiceCPBH = this.textEditInvoiceCphm.Text;
            this.invoice.InvoiceDiscount = this.spinEditInvoiceZKE.Value;
            this.invoice.InvoicePayable = decimal.Parse(string.IsNullOrEmpty(this.spinEditInvoiceOwed.Text) ? "0" : this.spinEditInvoiceOwed.Text);
            this.Invoice.Employee0 = this.buttonEditEmployee.EditValue as Model.Employee;
            this.invoice.Employee1 = this.buttonEditEmployee1.EditValue as Model.Employee;
            this.invoice.Customer = this.newChooseCustomer.EditValue as Model.Customer;
            //if (this.newChooseContorlAtCurrencyCate.EditValue != null)
            //{
            //    this.invoice.AtCurrencyCategory = this.newChooseContorlAtCurrencyCate.EditValue as Model.AtCurrencyCategory;

            //    this.invoice.AtCurrencyCategoryId = this.invoice.AtCurrencyCategory.AtCurrencyCategoryId;
            //}
            this.invoice.Currency = this.comboBoxEditCurrency.Text;

            if (this.invoice.Customer != null)
            {
                this.invoice.CustomerId = this.invoice.Customer.CustomerId;
            }
            // this.invoice.Employee2 = this.buttonEditEmployee2.EditValue as Model.Employee;
            this.invoice.InvoiceXOId = this.textEditInvoiceXOId.Text;
            this.invoice.InvoiceCustomXOId = this.textEditCustomerXOInvoiceId.Text;
            if (global::Helper.DateTimeParse.DateTimeEquls(this.dateEditInvoiceYjrq.DateTime, new DateTime()))
            {
                this.invoice.InvoiceYjrq = global::Helper.DateTimeParse.NullDate;
            }
            else
            {
                this.invoice.InvoiceYjrq = this.dateEditInvoiceYjrq.DateTime;
            }
            //this.invoice.Employee1 = BL.V.ActiveOperator;
            this.invoice.InvoiceStatus = (int)status;
            //批号
            this.invoice.SupplierLotNumber = this.txtSupplierLotNumber.Text;

            this.invoice.AuditState = this.saveAuditState;

            this.invoice.Shipment = this.txt_Shipment.Text;
            this.invoice.SupplierCurrency1 = this.cob_SupplierCurrency1.Text;
            this.invoice.SupplierCurrency2 = this.cob_SupplierCurrency2.Text;

            //修改未到货数量
            if (this.action == "update")
                foreach (var item in this.invoice.Details)
                {
                    item.NoArrivalQuantity = Convert.ToDouble(item.OrderQuantity) - Convert.ToDouble(item.ArrivalQuantity);
                }

            if (string.IsNullOrEmpty(this.invoice.Currency))
            {
                //MessageBox.Show("提示", "請輸入訂單幣別", MessageBoxButtons.OK);
                //return;

                throw new Exception("請輸入訂單幣別");
            }
            if (string.IsNullOrEmpty(this.invoice.SupplierCurrency1))
            {
                //MessageBox.Show("提示", "請輸入供應商1幣別", MessageBoxButtons.OK);
                //return;

                throw new Exception("請輸入供應商1幣別");
            }
            if (!string.IsNullOrEmpty(this.invoice.SupplierId2) && string.IsNullOrEmpty(this.invoice.SupplierCurrency2))
            {
                //MessageBox.Show("提示", "請輸入供應商1幣別", MessageBoxButtons.OK);
                //return;

                throw new Exception("請輸入供應商2幣別");
            }

            switch (this.action)
            {
                case "insert":
                    this.invoiceManager.Insert(this.invoice);
                    break;
                case "update":
                    this.invoiceManager.Update(this.invoice);
                    break;
            }

            //foreach (var item in this.invoice.Details)
            //{
            //    Model.InvoiceCGDetail cgDetail = this.invoiceCGDetailManager.SelectByCODetailId(item.InvoiceCODetailId);
            //    if (cgDetail != null)
            //    { 
            //    if(cgDetail.invoice)
            //    }
            //}
        }

        public override BaseListForm GetListForm()
        {
            return new ListForm();
        }

        protected override void Delete()
        {
            this.invoiceManager.Delete(this.invoice.InvoiceId);
        }

        public override Book.Model.Invoice Invoice
        {
            get
            {
                return invoice;
            }
            set
            {
                if (value is Model.InvoiceCO)
                {
                    invoice = invoiceManager.Get((value as Model.InvoiceCO).InvoiceId);
                }
            }
        }

        protected override void TurnNull()
        {
            if (this.invoice == null)
                return;
            if (MessageBox.Show(Properties.Resources.ConfirmToDelete, this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            this.invoiceManager.TurnNull(this.invoice.InvoiceId);
            this.invoice = this.invoiceManager.GetNext(this.invoice);
            if (this.invoice == null)
            {
                this.invoice = this.invoiceManager.GetLast();
            }
        }

        private void Total()
        {
            decimal total = decimal.Zero;

            foreach (Model.InvoiceCODetail detail in this.invoice.Details)
            {
                total += detail.InvoiceCODetailMoney.Value;
            }
            this.calcEditInvoiceHeji.EditValue = total;
        }

        protected override void AddNew()
        {
            this.invoice = new Model.InvoiceCO();
            this.invoice.InvoiceYjrq = DateTime.Now.AddDays(7).Date;
            this.invoice.InvoiceId = this.invoiceManager.GetNewId();
            this.invoice.InvoiceDate = DateTime.Now;
            this.invoice.IsClose = false;
            this.invoice.Details = new List<Model.InvoiceCODetail>();
            this.invoice.Employee0 = BL.V.ActiveOperator.Employee;
            this.invoice.Employee1 = BL.V.ActiveOperator.Employee;
            if (this.invoicecj != null)
            {
                this.invoice.Employee0 = BL.V.ActiveOperator.Employee;
                this.invoice.Employee0Id = BL.V.ActiveOperator.EmployeeId;

                this.invoice.InvoiceAbstract = this.invoicecj.InvoiceAbstract;
                this.invoice.InvoiceNote = this.invoicecj.InvoiceNote;
                this.invoice.Supplier = this.invoicecj.Supplier;
                this.invoice.SupplierId = this.invoicecj.SupplierId;
                this.invoice.InvoiceTotal = this.invoicecj.InvoiceTotal;
                this.invoice.InvoiceHeji = this.invoicecj.InvoiceTotal;

                this.invoicecj.Details = this.invoiceCJDetailManager.Select(this.invoicecj);

                foreach (Model.InvoiceCJDetail cjdetail in this.invoicecj.Details)
                {
                    Model.InvoiceCODetail codetail = new Book.Model.InvoiceCODetail();
                    codetail.InvoiceId = this.invoice.InvoiceId;
                    codetail.Inumber = this.invoice.Details.Count + 1;
                    codetail.InvoiceCODetailId = Guid.NewGuid().ToString();
                    codetail.InvoiceCODetailMoney = cjdetail.InvoiceCJDetailMoney;
                    codetail.TotalMoney = cjdetail.InvoiceCJDetailMoney;
                    codetail.InvoiceCODetailNote = cjdetail.InvoiceCJDetailNote;
                    codetail.InvoiceCODetailPrice = cjdetail.InvoiceCJDetailPrice;
                    codetail.OrderQuantity = cjdetail.InvoiceCJDetailQuantity;
                    codetail.Product = cjdetail.Product;
                    codetail.ProductId = cjdetail.ProductId;
                    codetail.InvoiceProductUnit = cjdetail.InvoiceProductUnit;
                    //codetail.InvoiceCODetailMoney = codetail.InvoiceCODetailPrice * decimal.Parse();           
                    this.invoice.Details.Add(codetail);

                }

            }
            if (this._invoiceXO != null)
            {
                this.invoice.Employee0 = BL.V.ActiveOperator.Employee;
                this.invoice.Employee0Id = BL.V.ActiveOperator.EmployeeId;

                this.invoice.InvoiceAbstract = this._invoiceXO.InvoiceAbstract;
                this.invoice.InvoiceNote = this._invoiceXO.InvoiceNote;


                this.invoice.InvoiceTotal = this._invoiceXO.InvoiceTotal;
                this.invoice.InvoiceHeji = this._invoiceXO.InvoiceHeji;



                foreach (Model.InvoiceXODetail xodetail in this._invoiceXO.Details)
                {
                    Model.InvoiceCODetail codetail = new Book.Model.InvoiceCODetail();
                    codetail.InvoiceId = this.invoice.InvoiceId;
                    codetail.Inumber = this.invoice.Details.Count + 1;
                    codetail.InvoiceCODetailId = Guid.NewGuid().ToString();
                    codetail.InvoiceCODetailMoney = xodetail.InvoiceXODetailMoney;
                    codetail.TotalMoney = xodetail.InvoiceXODetailMoney;
                    codetail.InvoiceCODetailNote = xodetail.InvoiceXODetailNote;
                    codetail.InvoiceCODetailPrice = xodetail.InvoiceXODetailPrice;
                    codetail.OrderQuantity = xodetail.InvoiceXODetailQuantity;
                    codetail.Product = xodetail.Product;
                    codetail.ProductId = xodetail.ProductId;
                    codetail.InvoiceProductUnit = xodetail.InvoiceProductUnit;
                    //codetail.InvoiceCODetailMoney = codetail.InvoiceCODetailPrice * decimal.Parse();           
                    this.invoice.Details.Add(codetail);

                }

            }
        }

        protected override void MoveNext()
        {
            Model.InvoiceCO invoice = this.invoiceManager.GetNext(this.invoice);
            if (invoice == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);

            this.invoice = this.invoiceManager.Get(invoice.InvoiceId);
        }

        protected override void MovePrev()
        {
            Model.InvoiceCO invoice = this.invoiceManager.GetPrev(this.invoice);
            if (invoice == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);

            this.invoice = this.invoiceManager.Get(invoice.InvoiceId);
        }

        protected override void MoveFirst()
        {
            this.invoice = this.invoiceManager.Get(this.invoiceManager.GetFirst() == null ? "" : this.invoiceManager.GetFirst().InvoiceId);
        }

        protected override void MoveLast()
        {
            if (LastFlag == 1) { LastFlag = 0; return; }
            this.invoice = this.invoiceManager.Get(this.invoiceManager.GetLast() == null ? "" : this.invoiceManager.GetLast().InvoiceId);
        }

        public override void Refresh()
        {
            if (this.invoice == null)
            {
                this.invoice = new Book.Model.InvoiceCO();
                this.action = "insert";
            }
            else
            {
                if (this.action == "view")
                    this.invoice = this.invoiceManager.Get(invoice.InvoiceId);
            }

            this.updateCaption();
            this.dateEditInvoiceYjrq.EditValue = this.invoice.InvoiceYjrq;
            this.textEditInvoiceId.EditValue = this.invoice.InvoiceId;
            this.dateEditInvoiceDate.DateTime = this.invoice.InvoiceDate.Value;
            this.buttonEditEmployee.EditValue = this.invoice.Employee0;
            this.buttonEditEmployee1.EditValue = this.invoice.Employee1;
            this.buttonEditEmployee2.EditValue = this.invoice.Employee2;
            this.ncc_Supplier1.EditValue = this.invoice.Supplier;
            this.textEditNote.EditValue = this.invoice.InvoiceNote;
            this.newChooseCustomer.EditValue = this.invoice.Customer;
            this.bindingSource1.DataSource = this.invoice.Details;
            this.EmpAudit.EditValue = this.invoice.AuditEmp;
            this.textEditAuditState.Text = this.invoice.AuditStateName;
            if (this.action == "insert" && this.invoice.Details.Count == 0)
            {
                Model.InvoiceCODetail detail = new Model.InvoiceCODetail();
                detail.InvoiceCODetailId = Guid.NewGuid().ToString();
                detail.InvoiceCODetailMoney = 0;
                detail.InvoiceCODetailNote = "";
                detail.InvoiceCODetailPrice = 0;
                detail.NoArrivalQuantity = 1;
                detail.ArrivalQuantity = 0;
                detail.OrderQuantity = 1;
                detail.InvoiceProductUnit = "";
                detail.Product = new Book.Model.Product();
                this.invoice.Details.Add(detail);
                this.bindingSource1.Position = this.bindingSource1.IndexOf(detail);
                this.gridControl1.RefreshDataSource();
            }

            this.spinEditInvoiceTaxRate.EditValue = this.invoice.InvoiceTaxrate == null ? 5 : this.invoice.InvoiceTaxrate;
            this.calcEditInvoiceHeji.EditValue = this.invoice.InvoiceHeji == null ? 0 : this.invoice.InvoiceHeji;
            this.calcEditInvoiceTax.EditValue = this.invoice.InvoiceTax == null ? 0 : this.invoice.InvoiceTax;
            this.calcEditInvoiceTotal.EditValue = this.invoice.InvoiceTotal == null ? 0 : this.invoice.InvoiceTotal;
            this.dateEditFPDate.DateTime = this.invoice.InvoiceFPDate == null ? DateTime.Now.AddDays(3) : this.invoice.InvoiceFPDate.Value;
            this.textEditInvoiceCphm.EditValue = this.invoice.InvoiceCPBH;
            this.comboBoxEditInvoiceKslb.EditValue = this.invoice.InvoiceKSLB;
            this.comboBoxEditInvoiceKlfs.Text = this.invoice.InvoiceKLFS;
            this.comboBoxEditInvoiceFpls.EditValue = this.invoice.InvoiceKPLS;
            this.spinEditInvoiceFpje.EditValue = this.invoice.InvoiceFPJE;
            this.textEditInvoiceFpbh.Text = this.invoice.InvoiceFPBH;
            //this.spinEditInvoiceOwed.EditValue = this.invoice.InvoicePayable;
            this.spinEditInvoiceZKE.EditValue = this.invoice.InvoiceDiscount;
            this.spinEditInvoiceOwed.EditValue = decimal.Parse(this.calcEditInvoiceTotal.EditValue.ToString()) - this.spinEditInvoiceZKE.Value - this.spinEditYifu.Value;
            this.buttonEditEmployee1.EditValue = this.invoice.Employee1;
            this.buttonEditEmployee2.EditValue = this.invoice.Employee2;
            this.textEditInvoiceXOId.Text = this.invoice.InvoiceXOId;
            Model.InvoiceXO xo = (new BL.InvoiceXOManager()).GetById(this.invoice.InvoiceXOId);
            if (xo != null)
            {
                this.textEditCustomerXOInvoiceId.Text = xo.CustomerInvoiceXOId;
                this.txtSupplierLotNumber.Text = xo.CustomerLotNumber;
            }
            else
            {
                this.textEditCustomerXOInvoiceId.Text = string.Empty;
                this.txtSupplierLotNumber.Text = string.Empty;
            }
            if (global::Helper.DateTimeParse.DateTimeEquls(this.invoice.InvoiceYjrq, global::Helper.DateTimeParse.NullDate))
            {
                this.dateEditInvoiceYjrq.EditValue = null;
            }
            else
            {
                this.dateEditInvoiceYjrq.EditValue = this.invoice.InvoiceYjrq;
            }

            //this.newChooseContorlAtCurrencyCate.EditValue = this.invoice.AtCurrencyCategory;
            this.comboBoxEditCurrency.EditValue = this.invoice.Currency;

            this.ncc_Supplier2.EditValue = this.invoice.Supplier2;
            this.txt_Shipment.Text = this.invoice.Shipment;
            this.cob_SupplierCurrency1.EditValue = this.invoice.SupplierCurrency1;
            this.cob_SupplierCurrency2.EditValue = this.invoice.SupplierCurrency2;

            base.Refresh();

            this.buttonEditEmployee.Enabled = false;
            this.buttonEditEmployee1.Enabled = false;
            this.barBtnUpdatePrice.Enabled = false;
            this.textEditInvoiceId.Properties.ReadOnly = true;
            this.textEditInvoiceXOId.Properties.ReadOnly = true;
            this.textEditCustomerXOInvoiceId.Properties.ReadOnly = true;
        }

        protected override DevExpress.XtraReports.UI.XtraReport GetReport()
        {
            //return new R01(this.invoice.InvoiceId);

            R01 r1 = new R01(this.invoice.InvoiceId, null, this.invoice.Supplier);
            r1.ShowPreview();

            if (this.invoice.Supplier2 != null)
            {
                R01 r2 = new R01(this.invoice.InvoiceId, this.invoice.Supplier.SupplierFullName, this.invoice.Supplier2);
                r2.ShowPreview();
            }

            return null;
        }

        protected override bool HasRows()
        {
            return this.invoiceManager.HasRows();
        }

        protected override bool HasRowsNext()
        {
            return this.invoiceManager.HasRowsAfter(this.invoice);
        }

        protected override bool HasRowsPrev()
        {
            return this.invoiceManager.HasRowsBefore(this.invoice);
        }

        private void dateEditInvoiceDate_Leave(object sender, EventArgs e)
        {
            //if (this.action == "insert") { this.textEditInvoiceId.EditValue = this.invoiceManager.GetNewId(this.dateEditInvoiceDate.DateTime); }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //蛌等測鎢
            string tag = (string)e.Item.Tag;
            switch (tag)
            {
                case "CG":
                    Operations.Open("invoices.cg.edit1", this.MdiParent, this.invoice);
                    break;
                default:
                    break;
            }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (this.gridView1.FocusedColumn.Name == "gridColumn1")
            {
                if (this.gridView1.FocusedColumn.ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemComboBox)
                {
                    Model.Product p = (this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as Model.InvoiceCODetail).Product;
                    this.repositoryItemComboBox1.Items.Clear();
                    if (!string.IsNullOrEmpty(p.BasedUnitGroupId))
                    {
                        BL.ProductUnitManager unitManager = new Book.BL.ProductUnitManager();
                        Model.UnitGroup ug = new BL.UnitGroupManager().Get(p.BasedUnitGroupId);
                        IList<Model.ProductUnit> unitList = unitManager.Select(ug);
                        foreach (Model.ProductUnit unit in unitList)
                        {
                            this.repositoryItemComboBox1.Items.Add(unit.CnName);
                        }
                    }
                }
            }
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            this.UpdateMoneyFields();
        }

        protected override void IMECtrl()
        {
            Book.UI.Tools.IMEControl.IMECtrl(new Control[] { this.gridControl1, this });
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == this.colInvoiceCODetailPrice || e.Column == this.colInvoiceCODetailQuantity)
            {
                decimal price = decimal.Zero;
                decimal quantity = decimal.Zero;

                if (e.Column == this.colInvoiceCODetailPrice)
                {
                    decimal.TryParse(e.Value == null ? "0" : e.Value.ToString(), out price);
                    decimal.TryParse(this.gridView1.GetRowCellValue(e.RowHandle, this.colInvoiceCODetailQuantity) == null ? "" : this.gridView1.GetRowCellValue(e.RowHandle, this.colInvoiceCODetailQuantity).ToString(), out quantity);
                }

                if (e.Column == this.colInvoiceCODetailQuantity)
                {
                    decimal.TryParse(e.Value == null ? "0" : e.Value.ToString(), out quantity);     //获得数量
                    Model.InvoiceCODetail invoicecodetail = this.bindingSource1.Current as Model.InvoiceCODetail;
                    //if (string.IsNullOrEmpty(invoicecodetail.DetailsPriceRange))
                    //{
                    //    if ((this.buttonEditCompany.EditValue as Model.Supplier) == null && string.IsNullOrEmpty(invoicecodetail.Product.SupplierId))
                    //        MessageBox.Show("廠商為空，不能計算商品單價！", this.Text);
                    //    else
                    //    {
                    //        if ((this.buttonEditCompany.EditValue as Model.Supplier) != null)
                    //            invoicecodetail.DetailsPriceRange = this.supplierProductManager.GetPriceRangeForSupAndProduct((this.buttonEditCompany.EditValue as Model.Supplier).SupplierId, invoicecodetail.ProductId);
                    //        else
                    //            invoicecodetail.DetailsPriceRange = this.supplierProductManager.GetPriceRangeForSupAndProduct(invoicecodetail.Product.SupplierId, invoicecodetail.ProductId);
                    //    }
                    //}

                    //if (string.IsNullOrEmpty(invoicecodetail.DetailsPriceRange))
                    invoicecodetail.DetailsPriceRange = invoicecodetail.Product.PriceAndRange;

                    if (string.IsNullOrEmpty(invoicecodetail.DetailsPriceRange))
                    {
                        decimal.TryParse(this.gridView1.GetRowCellValue(e.RowHandle, this.colInvoiceCODetailPrice) == null ? "0" : this.gridView1.GetRowCellValue(e.RowHandle, this.colInvoiceCODetailPrice).ToString(), out price); //获得单价
                    }
                    else
                    {
                        price = BL.SupplierProductManager.CountPrice(invoicecodetail.DetailsPriceRange, Convert.ToDouble(quantity));

                        //根據商品的採購幣別和訂單幣別換算訂單單價
                        if (this.dateEditInvoiceDate.EditValue != null && !string.IsNullOrEmpty(comboBoxEditCurrency.Text) && !string.IsNullOrEmpty(invoicecodetail.Product.COCurrency))
                        {
                            if (comboBoxEditCurrency.Text != invoicecodetail.Product.COCurrency)
                            {
                                decimal proCurrencyToTaibiRate = exchangeRateManager.GetRateByDateAndCurrency(this.dateEditInvoiceDate.DateTime, invoicecodetail.Product.COCurrency);
                                proCurrencyToTaibiRate = proCurrencyToTaibiRate == 0 ? 1 : proCurrencyToTaibiRate;

                                decimal taibiToInvoiceCurrencyRate = exchangeRateManager.GetRateByDateAndCurrency(this.dateEditInvoiceDate.DateTime, comboBoxEditCurrency.Text);
                                taibiToInvoiceCurrencyRate = taibiToInvoiceCurrencyRate == 0 ? 1 : taibiToInvoiceCurrencyRate;

                                price = price * proCurrencyToTaibiRate / taibiToInvoiceCurrencyRate;
                            }
                        }

                        this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceCODetailPrice, price);
                    }
                }

                price = this.GetDecimal(price, BL.V.SetDataFormat.CGDJXiao.Value);

                this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceCODetailMoney, GetDecimal(price * quantity, BL.V.SetDataFormat.CGJEXiao.Value));
                this.gridView1.SetRowCellValue(e.RowHandle, this.gridColumn2, GetDecimal(price * quantity, BL.V.SetDataFormat.CGJEXiao.Value));
                double taxrate = double.Parse(this.spinEditInvoiceTaxRate.Value.ToString()); //阭薹
                double ta = (taxrate + 100) / 100;

                this.UpdateMoneyFields();
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == this.colProductId)
            {
                Model.InvoiceCODetail detail = this.gridView1.GetRow(e.RowHandle) as Model.InvoiceCODetail;
                if (detail != null)
                {
                    Model.Product p = productManager.Get(e.Value.ToString());
                    if (p != null)
                    {
                        detail.InvoiceCODetailId = Guid.NewGuid().ToString();
                        detail.InvoiceCODetailMoney = 0;
                        detail.InvoiceCODetailNote = "";
                        detail.InvoiceCODetailPrice = 0;
                        detail.OrderQuantity = 0;
                        detail.Product = p;
                        detail.ProductId = p.ProductId;
                        detail.InvoiceProductUnit = p.BuyUnit == null ? "" : p.BuyUnit.CnName;
                        this.bindingSource1.Position = this.bindingSource1.IndexOf(detail);
                        this.gridControl1.RefreshDataSource();
                    }
                }
            }
        }

        private bool CanAdd(IList<Model.InvoiceCODetail> list)
        {
            foreach (Model.InvoiceCODetail detail in list)
            {
                if (detail.Product == null || string.IsNullOrEmpty(detail.Product.ProductId))
                    return false;
            }
            return true;
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {

            if (this.action == "insert" || this.action == "update")
            {
                if (this.CanAdd(this.invoice.Details))
                {
                    if (e.KeyData == Keys.Enter)
                    {
                        if (!this.gridView1.PostEditor() || !this.gridView1.UpdateCurrentRow())
                            return;
                        Model.InvoiceCODetail detail = new Model.InvoiceCODetail();
                        detail.InvoiceCODetailId = Guid.NewGuid().ToString();
                        detail.Inumber = this.invoice.Details.Count + 1;
                        detail.InvoiceCODetailMoney = 0;
                        detail.InvoiceCODetailNote = "";
                        detail.InvoiceCODetailPrice = 0;
                        detail.OrderQuantity = 0;
                        //detail.InvoiceCODetailQuantity0 = 0;
                        detail.InvoiceProductUnit = "";
                        detail.Product = new Book.Model.Product();
                        this.invoice.Details.Add(detail);
                        this.bindingSource1.Position = this.bindingSource1.IndexOf(detail);

                    }
                    if (e.KeyData == Keys.Delete)
                    {
                        this.simpleButtonRemove.PerformClick();
                    }
                    this.gridControl1.RefreshDataSource();
                }
            }
            return;
        }

        /// <summary>
        ///0 轎阭 1 俋樓 -1 囀漪 
        /// </summary>
        private int flag = 0;

        private void TaxMethod()
        {
            string message = "";
            if (flag == 0)
                return;
            if (flag == 1)
                message = Properties.Resources.WaiJiaShui;
            else
                message = Properties.Resources.NeiHanShui;
            if (MessageBox.Show(message, this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                return;
            double taxrate = double.Parse(this.spinEditInvoiceTaxRate.Text); //阭薹
            double ta = (taxrate + 100) / 100;

            //foreach (Model.InvoiceCODetail detail in this.invoice.Details)
            //{
            //    if (detail.Product == null || string.IsNullOrEmpty(detail.Product.ProductId)) continue;
            //    if (flag == 1)
            //    {
            //        // detail.InvoiceCODetailPrice = detail.TotalMoney / decimal.Parse(detail.OrderQuantity.ToString());
            //    }
            //    if (flag == 2)
            //    {
            //        detail.InvoiceCODetailPrice = detail.TotalMoney / decimal.Parse(detail.OrderQuantity.ToString()) / decimal.Parse(ta.ToString());
            //        detail.InvoiceCODetailMoney = decimal.Parse(detail.OrderQuantity.ToString()) * detail.InvoiceCODetailPrice;
            //    }

            //}
            this.spinEditInvoiceTaxRate.Properties.Buttons[1].Enabled = flag == 1 ? false : true;
            this.spinEditInvoiceTaxRate.Properties.Buttons[2].Enabled = flag == 2 ? false : true;
            this.UpdateMoneyFields();
        }

        private void spinEditInvoiceTaxRate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int index = e.Button.Index;
            switch (index)
            {
                case 1:

                    flag = 1;
                    TaxMethod();
                    break;
                case 2:
                    flag = 2;
                    TaxMethod();
                    break;
                default:
                    this.spinEditInvoiceTaxRate.Properties.Buttons[1].Enabled = true;
                    this.spinEditInvoiceTaxRate.Properties.Buttons[2].Enabled = true;
                    break;
            }

            this.gridControl1.RefreshDataSource();
        }

        private void UpdateMoneyFields()
        {
            decimal yse = 0;//茼彶塗      
            decimal tol = 0;

            foreach (Model.InvoiceCODetail detail in this.invoice.Details)
            {
                if (detail.InvoiceCODetailMoney == null)
                    detail.InvoiceCODetailMoney = 0;
                //if (detail.InvoiceCODetailMoney.Value.ToString().IndexOf('.') >= 0)
                //{
                //    if (Convert.ToInt32(detail.InvoiceCODetailMoney.ToString().Substring(detail.InvoiceCODetailMoney.ToString().IndexOf(".") + 1, 1)) >= 5)
                //        detail.InvoiceCODetailMoney = (int)detail.InvoiceCODetailMoney.Value + 1;
                //    else
                //        detail.InvoiceCODetailMoney = (int)detail.InvoiceCODetailMoney.Value;
                //}
                yse += detail.InvoiceCODetailMoney.Value;
                if (detail.TotalMoney == null)
                    detail.TotalMoney = 0;
                //if (detail.TotalMoney.Value.ToString().IndexOf('.') >= 0)
                //{
                //    if (Convert.ToInt32(detail.TotalMoney.ToString().Substring(detail.TotalMoney.ToString().IndexOf(".") + 1, 1)) >= 5)
                //        detail.TotalMoney = (int)detail.TotalMoney.Value + 1;
                //    else
                //        detail.TotalMoney = (int)detail.TotalMoney.Value;
                //}
                //  tol += detail.TotalMoney.Value;

            }
            yse = this.GetDecimal(yse, BL.V.SetDataFormat.CGZJXiao.Value);


            if (this.action != "view")
            {
                if (flag == 0)
                {
                    this.calcEditInvoiceHeji.EditValue = yse;
                    this.calcEditInvoiceTax.EditValue = 0;
                    this.calcEditInvoiceTotal.EditValue = yse;
                    this.comboBoxEditInvoiceKslb.SelectedIndex = 2;
                }
                else if (flag == 1)
                {
                    this.calcEditInvoiceHeji.EditValue = yse;
                    this.calcEditInvoiceTax.EditValue = this.GetDecimal(yse * this.spinEditInvoiceTaxRate.Value / 100, BL.V.SetDataFormat.CGZJXiao.Value);
                    this.calcEditInvoiceTotal.EditValue = yse + decimal.Parse(this.calcEditInvoiceTax.Text);
                    this.comboBoxEditInvoiceKslb.SelectedIndex = 1;
                }
                else
                {
                    this.calcEditInvoiceTotal.EditValue = yse;
                    //this.calcEditInvoiceHeji.EditValue = yse;
                    // this.calcEditInvoiceHeji.EditValue = yse * 100 / (100 + this.spinEditInvoiceTaxRate.Value);
                    this.calcEditInvoiceHeji.EditValue = this.GetDecimal(yse * 100 / (100 + this.spinEditInvoiceTaxRate.Value), BL.V.SetDataFormat.CGZJXiao.Value);
                    this.calcEditInvoiceTax.EditValue = yse - Convert.ToDecimal(this.calcEditInvoiceHeji.EditValue);


                    this.comboBoxEditInvoiceKslb.SelectedIndex = 0;
                }
            }
            spinEditInvoiceFpje.EditValue = this.calcEditInvoiceTotal.EditValue;
        }

        private void spinEditInvoiceZKE_EditValueChanged(object sender, EventArgs e)
        {
            this.spinEditInvoiceOwed.EditValue = decimal.Parse(this.calcEditInvoiceTotal.EditValue.ToString()) - this.spinEditInvoiceZKE.Value - this.spinEditYifu.Value;
        }

        private void spinEditYifu_EditValueChanged(object sender, EventArgs e)
        {
            this.spinEditInvoiceOwed.EditValue = decimal.Parse(this.calcEditInvoiceTotal.EditValue.ToString()) - this.spinEditInvoiceZKE.Value - this.spinEditYifu.Value;
        }

        protected override void Undo()
        {
            base.Undo();
            this.flag = 0;
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.ListSourceRowIndex < 0) return;
            IList<Model.InvoiceCODetail> details = this.bindingSource1.DataSource as IList<Model.InvoiceCODetail>;
            if (details == null || details.Count < 1) return;
            Model.Product detail = details[e.ListSourceRowIndex].Product;
            if (detail == null) return;
            switch (e.Column.Name)
            {
                //case "colProductId":

                //    e.DisplayText = string.IsNullOrEmpty(detail.Id) ? "" : detail.Id;
                //    break;
                case "gridColumnStocksQuantity":
                    e.DisplayText = detail.StocksQuantity == null ? "0" : detail.StocksQuantity.ToString();
                    break;
                case "gridColumn14":
                    if (details[e.ListSourceRowIndex].Invoice != null)
                        e.DisplayText = (new BL.InvoiceXOManager()).SelectInvoiceYjrq(details[e.ListSourceRowIndex].Invoice.InvoiceXOId);
                    break;
                default:
                    break;
            }
        }

        private void spinEditInvoiceTaxRate_EditValueChanged(object sender, EventArgs e)
        {
            if (flag == 2)
            {
                // flags=1;
                double taxrate = double.Parse(this.spinEditInvoiceTaxRate.Value.ToString()); //阭薹
                double ta = (taxrate + 100) / 100;


                foreach (Model.InvoiceCODetail detail in this.invoice.Details)
                {
                    if (detail.OrderQuantity != null && detail.OrderQuantity != 0)
                    {
                        detail.InvoiceCODetailPrice = detail.TotalMoney / decimal.Parse(detail.OrderQuantity.ToString()) / decimal.Parse(ta.ToString());

                        detail.InvoiceCODetailMoney = decimal.Parse(detail.OrderQuantity.ToString()) * detail.InvoiceCODetailPrice;
                    }
                }
            }
            gridControl1.RefreshDataSource();
            this.UpdateMoneyFields();

        }

        //private void dateEditInvoiceDate_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (this.action == "insert") { this.textEditInvoiceId.EditValue = this.invoiceManager.GetNewId(this.dateEditInvoiceDate.DateTime); }
        //}

        private void repositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //  this.gridView1.CellValueChanged += new  DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView1_CellValueChanged); 
            //if (e.Column == this.colProductId)
            //{
            //    Model.InvoiceCODetail detail = this.gridView1.GetRow(e.RowHandle) as Model.InvoiceCODetail;
            //    if (detail != null)
            //    {
            //        Model.Product p = productManager.Get(e.Value.ToString());
            //        if (p != null)
            //        {
            //            detail.InvoiceCODetailId = Guid.NewGuid().ToString();
            //            detail.InvoiceCODetailMoney = 0;
            //            detail.InvoiceCODetailNote = "";
            //            detail.InvoiceCODetailPrice = 0;
            //            detail.OrderQuantity = 1;
            //            detail.Product = p;
            //            detail.ProductId = p.ProductId;
            //            detail.InvoiceProductUnit = p.DepotUnit == null ? "" : p.DepotUnit.CnName;
            //        }
            //        this.bindingSource1.Position = this.bindingSource1.IndexOf(detail);
            //    }
            //    this.gridControl1.RefreshDataSource();
            //}
        }

        private void GetCo()
        {
            int co1 = 0;
            int co2 = 0;
            IList<Model.Role> roleList = BL.V.RoleList;
            if (roleList != null && roleList.Count > 0)
            {
                for (int i = 0; i < roleList.Count; i++)
                {
                    if (roleList[i].IsCOPrice == true)
                    {
                        co1 = 1;
                    }
                    if (roleList[i].IsCOCount == true)
                    {
                        co2 = 1;

                    }
                }
                if (co1 == 1)
                {
                    this.colInvoiceCODetailPrice.Visible = true;
                    this.colInvoiceCODetailMoney.Visible = true;
                    co1 = 0;
                }
                else
                {
                    this.colInvoiceCODetailPrice.Visible = false;
                    this.colInvoiceCODetailMoney.Visible = false;
                }
                if (co2 == 1)
                {
                    this.colInvoiceCODetailQuantity.Visible = true;
                    //this.colInvoiceCODetailMoney.Visible = true;
                    co2 = 0;
                }
                else
                {
                    this.colInvoiceCODetailQuantity.Visible = false;
                    //this.colInvoiceCODetailMoney.Visible = false;
                }
            }
        }

        private void repositoryItemLookUpEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            //// this.gridControl1.RefreshDataSource();
            //int a=  this.bindingSource1.IndexOf(this.bindingSource1.Current as Model.InvoiceCODetail);
            //Model.InvoiceCODetail detail = this.gridView1.GetRow(a) as Model.InvoiceCODetail;

            //if (detail != null)
            //{
            //    if (this.gridView1.GetRowCellValue(a, this.colProductId.Name) == null) return;
            //    Model.Product p = productManager.Get(this.gridView1.GetRowCellValue(a, this.colProductId.Name).ToString());
            //    if (p != null)
            //    {
            //        detail.InvoiceCODetailId = Guid.NewGuid().ToString();
            //        detail.InvoiceCODetailMoney = 0;
            //        detail.InvoiceCODetailNote = "";
            //        detail.InvoiceCODetailPrice = 0;
            //        detail.OrderQuantity = 1;
            //        detail.Product = p;
            //        detail.ProductId = p.ProductId;
            //        detail.InvoiceProductUnit = p.DepotUnit == null ? "" : p.DepotUnit.CnName;
            //    }
            //    this.bindingSource1.Position = this.bindingSource1.IndexOf(detail);
            //}
            //this.gridControl1.RefreshDataSource();
            //   this.gridView1.CellValueChanging;// += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView1_CellValueChanged); 
        }

        //选择销售订单
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Book.UI.produceManager.createProduce.EditForm f = new Book.UI.produceManager.createProduce.EditForm("co");
            if (f.ShowDialog(this) != DialogResult.OK) return;
            if (f.SelectList == null || f.SelectList.Count == 0) return;
            if (this.invoice.Details.Count > 0 && string.IsNullOrEmpty(this.invoice.Details[0].ProductId))
                this.invoice.Details.RemoveAt(0);
            //this.mpsheader.Details.Clear();
            this.textEditInvoiceXOId.Text = f.SelectList[0].InvoiceId;
            this.textEditCustomerXOInvoiceId.Text = f.SelectList[0].Invoice.CustomerInvoiceXOId;
            this.newChooseCustomer.EditValue = f.SelectList[0].Invoice.xocustomer;
            this.ncc_Supplier1.EditValue = f.SelectList[0].Product.Supplier;
            this.txtSupplierLotNumber.Text = f.SelectList[0].Invoice.CustomerLotNumber;
            this.comboBoxEditCurrency.EditValue = f.SelectList[0].Invoice.Currency;
            this.ncc_Supplier1.EditValue = f.SelectList[0].Invoice.Supplier;

            foreach (Model.InvoiceXODetail xodetail in f.SelectList)
            {
                Model.InvoiceCODetail detail = new Book.Model.InvoiceCODetail();
                detail.InvoiceCODetailId = Guid.NewGuid().ToString();
                detail.Product = xodetail.Product;
                detail.Invoice = this.invoice;
                detail.Inumber = this.invoice.Details.Count + 1;
                detail.ProductId = xodetail.ProductId;
                detail.InvoiceProductUnit = xodetail.InvoiceProductUnit;
                detail.OrderQuantity = xodetail.InvoiceXODetailQuantity;
                detail.NoArrivalQuantity = detail.OrderQuantity;
                detail.ArrivalQuantity = 0;
                detail.InvoiceCODetailNote = "";
                detail.Remark = xodetail.Remark;
                //if (string.IsNullOrEmpty(detail.Product.SupplierId))
                //{
                //    detail.InvoiceCODetailPrice = 0;
                //    detail.DetailsPriceRange = string.Empty;
                //}
                //else
                //{
                //detail.DetailsPriceRange = new BL.SupplierProductManager().GetPriceRangeForSupAndProduct(detail.Product.SupplierId, detail.ProductId);
                //if ((this.buttonEditCompany.EditValue as Model.Supplier) == null && string.IsNullOrEmpty(detail.Product.SupplierId))
                //    MessageBox.Show("廠商為空，不能計算商品單價！", this.Text);
                //else
                //{
                //    if ((this.buttonEditCompany.EditValue as Model.Supplier) != null)
                //        detail.DetailsPriceRange = this.supplierProductManager.GetPriceRangeForSupAndProduct((this.buttonEditCompany.EditValue as Model.Supplier).SupplierId, detail.ProductId);
                //    else
                //        detail.DetailsPriceRange = this.supplierProductManager.GetPriceRangeForSupAndProduct(detail.Product.SupplierId, detail.ProductId);
                //}
                //detail.InvoiceCODetailPrice = BL.SupplierProductManager.CountPrice(detail.DetailsPriceRange, detail.OrderQuantity.HasValue ? detail.OrderQuantity.Value : 0);
                //}

                //detail.InvoiceCODetailPrice = xodetail.InvoiceXODetailPrice;   改拉商品的采购单价
                detail.DetailsPriceRange = detail.Product.PriceAndRange;
                if (!string.IsNullOrEmpty(detail.DetailsPriceRange))
                {
                    detail.InvoiceCODetailPrice = BL.SupplierProductManager.CountPrice(detail.DetailsPriceRange, Convert.ToDouble(detail.OrderQuantity));
                }
                else
                    detail.InvoiceCODetailPrice = 0;

                //根據商品的採購幣別和訂單幣別換算訂單單價
                if (this.dateEditInvoiceDate.EditValue != null && !string.IsNullOrEmpty(f.SelectList[0].Invoice.Currency) && !string.IsNullOrEmpty(detail.Product.COCurrency))
                {
                    if (f.SelectList[0].Invoice.Currency != detail.Product.COCurrency)
                    {
                        decimal proCurrencyToTaibiRate = exchangeRateManager.GetRateByDateAndCurrency(this.dateEditInvoiceDate.DateTime, detail.Product.COCurrency);
                        proCurrencyToTaibiRate = proCurrencyToTaibiRate == 0 ? 1 : proCurrencyToTaibiRate;

                        decimal taibiToInvoiceCurrencyRate = exchangeRateManager.GetRateByDateAndCurrency(this.dateEditInvoiceDate.DateTime, f.SelectList[0].Invoice.Currency);
                        taibiToInvoiceCurrencyRate = taibiToInvoiceCurrencyRate == 0 ? 1 : taibiToInvoiceCurrencyRate;

                        detail.InvoiceCODetailPrice = detail.InvoiceCODetailPrice * proCurrencyToTaibiRate / taibiToInvoiceCurrencyRate;
                    }
                }


                detail.InvoiceCODetailMoney = Convert.ToDecimal(detail.OrderQuantity) * Convert.ToDecimal(detail.InvoiceCODetailPrice);
                this.invoice.Details.Add(detail);
            }
            this.gridControl1.RefreshDataSource();
            this.UpdateMoneyFields();

        }

        private void barButtonItemJieAn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.invoice == null) return;
            if (!this.invoice.IsClose.Value)
            {
                if (MessageBox.Show("是否強制結案?", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
            }
            if (this.invoice.IsClose.Value)
            {
                if (MessageBox.Show("是否取消結案?", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
            }
            this.invoice.IsClose = !this.invoice.IsClose;
            try
            {
                BL.V.BeginTransaction();
                this.invoiceManager.UpdateAccess(this.invoice);
                foreach (Model.InvoiceCODetail item in this.invoice.Details)
                {
                    if (string.IsNullOrEmpty(item.ProductId)) return;
                    if (this.invoice.IsClose.Value)
                        this.invoiceManager.UpdateSql("update product set OrderOnWayQuantity=OrderOnWayQuantity-" + (item.NoArrivalQuantity.HasValue ? item.NoArrivalQuantity : 0) + " where productid='" + item.ProductId + "'");
                    if (!this.invoice.IsClose.Value)
                        this.invoiceManager.UpdateSql("update product set OrderOnWayQuantity=OrderOnWayQuantity+" + (item.NoArrivalQuantity.HasValue ? item.NoArrivalQuantity : 0) + " where productid='" + item.ProductId + "'");

                }
                BL.V.CommitTransaction();
                MessageBox.Show("操作成功", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.updateCaption();
            }
            catch (Exception ex)
            {
                BL.V.RollbackTransaction();
                this.invoice.IsClose = !this.invoice.IsClose;
                throw ex;
            }
        }

        //更新結案顯示值
        private void updateCaption()
        {

            if (this.invoice.IsClose == null)
                this.invoice.IsClose = false;
            if (this.invoice.IsClose.Value)
                this.barButtonItem3.Caption = "取消結案";
            else
                this.barButtonItem3.Caption = "強制結案";
            this.barButtonItem3.Enabled = this.action == "view" ? true : false;
        }

        private void btn_GetNewPrice_Click(object sender, EventArgs e)
        {
            foreach (var item in invoice.Details)
            {
                //if ((this.buttonEditCompany.EditValue as Model.Supplier) == null && string.IsNullOrEmpty(item.Product.SupplierId))
                //    MessageBox.Show("廠商為空，不能計算商品單價！", this.Text);
                //else
                //{
                //    if ((this.buttonEditCompany.EditValue as Model.Supplier) != null)
                //        item.DetailsPriceRange = this.supplierProductManager.GetPriceRangeForSupAndProduct((this.buttonEditCompany.EditValue as Model.Supplier).SupplierId, item.ProductId);
                //    else
                //        item.DetailsPriceRange = this.supplierProductManager.GetPriceRangeForSupAndProduct(item.Product.SupplierId, item.ProductId);
                //}
                ////}
                if (string.IsNullOrEmpty(item.DetailsPriceRange))
                    item.DetailsPriceRange = item.Product.PriceAndRange;

                if (string.IsNullOrEmpty(item.DetailsPriceRange))
                {
                    continue;
                }
                else
                {
                    item.InvoiceCODetailPrice = BL.SupplierProductManager.CountPrice(item.DetailsPriceRange, Convert.ToDouble(item.OrderQuantity));
                }
                item.InvoiceCODetailMoney = item.InvoiceCODetailPrice * Convert.ToDecimal(item.OrderQuantity);
            }
            this.gridControl1.RefreshDataSource();
            this.UpdateMoneyFields();
        }

        private void ncc_Supplier2_EditValueChanged(object sender, EventArgs e)
        {
            if (ncc_Supplier2.EditValue == null)
                return;

            if (this.ncc_Supplier1.EditValue == null)
            {
                MessageBox.Show("請先選擇供應商", "提示", MessageBoxButtons.OK);
                ncc_Supplier2.EditValue = null;
                return;
            }
        }

        private void dateEditInvoiceDate_EditValueChanged(object sender, EventArgs e)
        {
            CountProPriceAndMoney();
        }

        private void comboBoxEditCurrency_EditValueChanged(object sender, EventArgs e)
        {
            CountProPriceAndMoney();
        }

        private void CountProPriceAndMoney()
        {
            //根據商品的採購幣別和訂單幣別換算訂單單價
            if (this.dateEditInvoiceDate.EditValue != null && !string.IsNullOrEmpty(comboBoxEditCurrency.Text) && this.action != "view")
            {
                foreach (var detail in invoice.Details)
                {
                    detail.InvoiceCODetailPrice = BL.SupplierProductManager.CountPrice(detail.Product.PriceAndRange, Convert.ToDouble(detail.OrderQuantity));

                    if (!string.IsNullOrEmpty(detail.Product.COCurrency) && comboBoxEditCurrency.Text != detail.Product.COCurrency)
                    {
                        decimal proCurrencyToTaibiRate = exchangeRateManager.GetRateByDateAndCurrency(this.dateEditInvoiceDate.DateTime, detail.Product.COCurrency);
                        proCurrencyToTaibiRate = proCurrencyToTaibiRate == 0 ? 1 : proCurrencyToTaibiRate;

                        decimal taibiToInvoiceCurrencyRate = exchangeRateManager.GetRateByDateAndCurrency(this.dateEditInvoiceDate.DateTime, comboBoxEditCurrency.Text);
                        taibiToInvoiceCurrencyRate = taibiToInvoiceCurrencyRate == 0 ? 1 : taibiToInvoiceCurrencyRate;

                        detail.InvoiceCODetailPrice = detail.InvoiceCODetailPrice * proCurrencyToTaibiRate / taibiToInvoiceCurrencyRate;
                    }

                    detail.InvoiceCODetailMoney = Convert.ToDecimal(detail.OrderQuantity) * detail.InvoiceCODetailPrice;
                }

                this.UpdateMoneyFields();
                this.gridControl1.RefreshDataSource();
            }
        }
    }
}