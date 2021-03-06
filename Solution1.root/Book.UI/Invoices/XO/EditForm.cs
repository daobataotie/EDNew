using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Book.UI.Settings.BasicData.Employees;
using System.Reflection;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Columns;
using System.Linq;
using Book.UI.ExcelClass;

namespace Book.UI.Invoices.XO
{
    public partial class EditForm : BaseEditForm
    {
        IList<Model.Product> productDetail = new List<Model.Product>();     //不需要
        protected BL.InvoiceXOManager invoiceManager = new Book.BL.InvoiceXOManager();
        protected BL.InvoiceXODetailManager invoiceDetailManager = new Book.BL.InvoiceXODetailManager();
        protected BL.InvoiceXJDetailManager invoiceXJDetailManager = new Book.BL.InvoiceXJDetailManager();
        protected BL.InvoiceXJManager invoiceXJManager = new Book.BL.InvoiceXJManager();
        protected BL.ProductManager productManager = new Book.BL.ProductManager();
        protected BL.ProductUnitManager productUnitManager = new Book.BL.ProductUnitManager();
        private BL.CustomerManager CustomerManager = new Book.BL.CustomerManager();
        private BL.ExchangeRateManager exchangeRateManager = new Book.BL.ExchangeRateManager();
        private Model.InvoiceXO invoice;
        private Model.InvoiceXJ invoicexj;
        private IList<Model.Product> productlook = new List<Model.Product>();
        //设置tag 确定在gridView1_CellValueChanged事件执行后执行gridView1_RowCountChanged中UpdateMoneyFields()
        int tags = 0;
        private const int SISHEWURU_WEISHU = 3;
        int LastFlag = 0; //页面载入时是否执行 last方法
        string InvoiceCusID = "";  //初始訂單號，保存時判斷訂單號是否修改過

        public EditForm()
        {
            InitializeComponent();

            this.requireValueExceptions.Add("Id", new AA(Properties.Resources.RequireDataForId, this.textEditInvoiceId));
            this.requireValueExceptions.Add("Date", new AA(Properties.Resources.RequireDataOfInvoiceDate, this.dateEditInvoiceDate));
            this.requireValueExceptions.Add("Employee0", new AA(Properties.Resources.RequiredDataOfEmployee0, this.buttonEditEmployee));
            this.requireValueExceptions.Add("Details", new AA(Properties.Resources.RequireDataForDetails, this.gridControl1));

            this.requireValueExceptions.Add("quantity", new AA("數量不能為0", this.gridControl1));
            this.requireValueExceptions.Add("Company", new AA(Properties.Resources.RequireDataForCompany, this.newChooseCustomer1));
            this.requireValueExceptions.Add(Model.InvoiceXO.PRO_InvoiceYjrq, new AA("請選擇預交日期！", this.dateEditYJRQ));
            this.invalidValueExceptions.Add(Model.InvoiceXO.PROPERTY_INVOICEID, new AA(Properties.Resources.EntityExists, this.textEditInvoiceId));
            this.requireValueExceptions.Add("Customer", new AA("商品未核准完", this.gridControl1));
            this.requireValueExceptions.Add(Model.InvoiceXO.PRO_CustomerInvoiceXOId, new AA(Properties.Resources.RequireCusXoId, this.textEditCustomerInvoiceXOID));
            this.invalidValueExceptions.Add(Model.InvoiceXO.PRO_CustomerInvoiceXOId, new AA(Properties.Resources.InvalidCusXoId, this.textEditCustomerInvoiceXOID));
            this.requireValueExceptions.Add(Model.InvoiceXO.PRO_Currency, new AA("請選擇貨幣種類", this.cob_Currency));

            //this.requireValueExceptions.Add(Model.InvoiceXO.PRO_CustomerInvoiceXOId,new AA())
            this.action = "view";
            this.newChooseCustomer1.Choose = new Settings.BasicData.Customs.ChooseCustoms();
            this.newChooseCustomer2.Choose = new Settings.BasicData.Customs.ChooseCustoms();
            this.buttonEditEmployee.Choose = new ChooseEmployee();
            //this.buttonEditEmployee1.Choose = new ChooseEmployee();
            this.buttonEditEmployee2.Choose = new ChooseEmployee();
            this.newChooseContorlEmp4.Choose = new ChooseEmployee();
            // this.newChooseXSCustomer.Choose = new Settings.BasicData.Customs.ChooseCustoms();
            this.EmpAudit.Choose = new ChooseEmployee();

            this.ncc_Supplier.Choose = new Settings.BasicData.Supplier.ChooseSupplier();

            this.gridView1.GroupPanelText = "如商品不需要生產排程，請取消“需排程”選擇狀態。";

            productlook = this.productManager.GetProductBaseInfo();
            this.bindingSourceproduct.DataSource = productlook;
        }

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

        public EditForm(Model.InvoiceXO invoice)
            : this()
        {
            if (invoice == null)
                throw new ArithmeticException("invoiceid");
            this.invoice = invoice;
            this.action = "view";
            if (this.action == "view")
                LastFlag = 1;
        }

        public EditForm(Model.InvoiceXJ invoice)
            : this()
        {
            this.invoicexj = this.invoiceXJManager.Get(invoice.InvoiceId);
            this.action = "insert";
            if (this.action == "view")
                LastFlag = 1;
        }

        public EditForm(IList<Model.ProformaInvoiceDetail> list)
            : this()
        {
            this.action = "insert";

            this.invoice = new Model.InvoiceXO();
            this.invoice.InvoiceId = this.invoiceManager.GetId(DateTime.Now);
            this.invoice.InvoiceDate = DateTime.Now;
            this.invoice.IsClose = false;
            this.invoice.Employee0 = BL.V.ActiveOperator.Employee;
            this.invoice.Details = new List<Model.InvoiceXODetail>();

            Model.InvoiceXODetail detail = null;
            if (list != null)
            {
                this.invoice.Customer = invoice.xocustomer = list.Count > 0 ? list[0].ProformaInvoice.Customer : null;

                foreach (var item in list)
                {
                    detail = new Book.Model.InvoiceXODetail();
                    detail.InvoiceXODetailId = Guid.NewGuid().ToString();
                    detail.Invoice = this.invoice;
                    detail.Inumber = this.invoice.Details.Count + 1;
                    detail.InvoiceId = this.invoice.InvoiceId;
                    detail.Product = item.Product;
                    detail.ProductId = item.ProductId;
                    detail.InvoiceXODetailQuantity = item.Quantity;
                    detail.InvoiceXODetailPrice = item.UnitPrice;
                    detail.InvoiceXODetailMoney = item.Amount;
                    detail.InvoiceProductUnit = item.Unit;

                    this.invoice.Details.Add(detail);
                }

                this.bindingSource1.DataSource = this.invoice.Details;
                this.gridControl1.RefreshDataSource();
            }

            LastFlag = 1;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            GetXo();
            this.bindingSourceCustomer.DataSource = new BL.CustomerManager().Select();
        }

        protected override string tableCode()
        {
            return "InvoiceXO";
        }

        protected override int AuditState()
        {
            return this.invoice.AuditState.HasValue ? this.invoice.AuditState.Value : 0;
        }

        private void buttonEditEmployee_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ChooseEmployeeForm f = new ChooseEmployeeForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                (sender as ButtonEdit).EditValue = f.SelectedItem;
            }
        }

        //private void buttonEditCompany_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    ChooseCustoms f = new ChooseCustoms();
        //    if (f.ShowDialog(this) == DialogResult.OK)
        //    {
        //        (sender as ButtonEdit).EditValue = f.SelectedItem;
        //    }
        //}

        private void simpleButtonAppend_Click(object sender, EventArgs e)
        {
            Book.UI.Invoices.ChooseProductForm f = new Book.UI.Invoices.ChooseProductForm();

            if (f.ShowDialog(this) == DialogResult.OK)
            {

                if (this.invoice.Details.Count > 0 && string.IsNullOrEmpty(this.invoice.Details[0].ProductId))
                    this.invoice.Details.RemoveAt(0);
                Model.InvoiceXODetail detail = null;
                if (ChooseProductForm.ProductList != null || ChooseProductForm.ProductList.Count > 0)
                {
                    foreach (Model.Product product in ChooseProductForm.ProductList)
                    {
                        detail = new Book.Model.InvoiceXODetail();
                        detail.InvoiceXODetailId = Guid.NewGuid().ToString();
                        detail.Inumber = this.invoice.Details.Count + 1;
                        detail.Invoice = this.invoice;
                        if (product != null)
                            detail.ProductId = product.ProductId;
                        detail.InvoiceXODetailQuantity = 0;
                        detail.InvoiceXODetailPrice = decimal.Zero;
                        detail.InvoiceXODetailMoney = decimal.Zero;
                        detail.InvoiceAllowance = 0;
                        detail.InvoiceXODetailNote = product.ProductDescription;
                        if (product.SellUnit != null)
                            detail.InvoiceProductUnit = product.SellUnit.CnName;
                        detail.Product = product;

                        detail.IsNeedMPS = true;
                        if (product != null)
                        {
                            detail.ProductId = product.ProductId;
                        }
                        this.invoice.Details.Add(detail);

                        //int flag = 0;
                        //IList<string> id = new List<string>();

                        //foreach (Model.Product products in productDetail)
                        //{
                        //    if (id.Contains(products.ProductId)) continue;
                        //    id.Add(products.ProductId);
                        //}
                        //foreach (Model.Product products in productDetail)
                        //{
                        //    if (id.Contains(detail.ProductId))
                        //    {
                        //        flag = 1;
                        //        break;
                        //    }
                        //}
                        //if (flag == 0)
                        //    productlook.Add(detail.Product);
                    }
                }
                if (ChooseProductForm.ProductList == null || ChooseProductForm.ProductList.Count == 0)
                {
                    Model.Product product = f.SelectedItem as Model.Product;
                    detail = new Book.Model.InvoiceXODetail();
                    detail.InvoiceXODetailId = Guid.NewGuid().ToString();
                    detail.Inumber = this.invoice.Details.Count + 1;
                    detail.Invoice = this.invoice;
                    if (product != null)
                        detail.ProductId = product.ProductId;
                    detail.InvoiceXODetailQuantity = 0;
                    detail.InvoiceXODetailPrice = decimal.Zero;
                    detail.InvoiceXODetailMoney = decimal.Zero;
                    detail.InvoiceAllowance = 0;
                    detail.InvoiceXODetailNote = product.ProductDescription;
                    if (product.SellUnit != null)
                        detail.InvoiceProductUnit = product.SellUnit.CnName;
                    detail.Product = product;

                    detail.IsNeedMPS = true;
                    if (product != null)
                    {
                        detail.ProductId = product.ProductId;
                    }
                    this.invoice.Details.Add(detail);

                    //int flag = 0;
                    //IList<string> id = new List<string>();

                    //foreach (Model.Product products in productDetail)
                    //{
                    //    if (id.Contains(products.ProductId)) continue;
                    //    id.Add(products.ProductId);
                    //}
                    //foreach (Model.Product products in productDetail)
                    //{
                    //    if (id.Contains(detail.ProductId))
                    //    {
                    //        flag = 1;
                    //        break;
                    //    }
                    //}
                    //if (flag == 0)
                    //    productlook.Add(detail.Product);

                }
                //this.bindingSourceproduct.DataSource = productlook;

                this.gridControl1.RefreshDataSource();
                this.bindingSource1.Position = this.bindingSource1.IndexOf(detail);
            }
            f.Dispose();
            System.GC.Collect();
        }

        private void simpleButtonRemove_Click(object sender, EventArgs e)
        {
            if (this.bindingSource1.Current != null)
            {
                this.invoice.Details.Remove(this.bindingSource1.Current as Model.InvoiceXODetail);
                if (this.invoice.Details.Count == 0)
                {
                    Model.InvoiceXODetail detail = new Model.InvoiceXODetail();
                    detail.InvoiceXODetailId = Guid.NewGuid().ToString();
                    detail.Inumber = this.invoice.Details.Count + 1;
                    detail.InvoiceXODetailMoney = 0;
                    detail.InvoiceXODetailNote = "";
                    detail.InvoiceXODetailPrice = 0;
                    detail.InvoiceXODetailQuantity = 0;
                    detail.InvoiceXODetailQuantity0 = 0;
                    detail.InvoiceProductUnit = "";
                    // detail.PrimaryKey = new Book.Model.CustomerProducts();
                    detail.Product = new Book.Model.Product();
                    this.invoice.Details.Add(detail);
                    this.bindingSource1.Position = this.bindingSource1.IndexOf(detail);
                }
                this.gridControl1.RefreshDataSource();
                UpdateMoneyFields();
            }
        }

        protected override void Save(Helper.InvoiceStatus status)
        {

            if (!this.gridView1.PostEditor() || !this.gridView1.UpdateCurrentRow())
                return;
            this.invoice.InvoiceStatus = (int)status;
            this.invoice.InvoiceId = this.textEditInvoiceId.Text;
            this.invoice.InvoiceDate = this.dateEditInvoiceDate.DateTime;
            this.invoice.Employee0 = this.buttonEditEmployee.EditValue as Model.Employee;
            this.invoice.InvoiceNote = this.textEditNote.Text;
            //客户
            if (this.newChooseCustomer1.EditValue != null)
            {
                this.invoice.Customer = newChooseCustomer1.EditValue as Model.Customer;
                this.invoice.CustomerId = this.invoice.Customer.CustomerId;
            }
            else
                this.invoice.CustomerId = null;
            //出货客户
            if (this.newChooseCustomer2.EditValue != null)
            {
                this.invoice.xocustomer = newChooseCustomer2.EditValue as Model.Customer;
                this.invoice.xocustomerId = this.invoice.xocustomer.CustomerId;
            }
            else
                this.invoice.xocustomerId = null;


            this.invoice.InvoiceLRTime = DateTime.Now;

            this.invoice.InvoiceTax = decimal.Parse(string.IsNullOrEmpty(this.calcEditInvoiceTax1xset.Text) ? "0" : this.calcEditInvoiceTax1xset.Text);
            this.invoice.InvoiceTaxrate = double.Parse(string.IsNullOrEmpty(this.spinEditInvoiceTaxRate1.Text) ? "0" : this.spinEditInvoiceTaxRate1.Text);
            this.invoice.InvoiceTotal = decimal.Parse(string.IsNullOrEmpty(this.calcEditInvoiceTotal0xset.Text) ? "0" : this.calcEditInvoiceTotal0xset.Text);
            this.invoice.InvoiceHeji = decimal.Parse(string.IsNullOrEmpty(this.calcEditInvoiceTotalxset.Text) ? "0" : this.calcEditInvoiceTotalxset.Text);

            this.invoice.InvoiceCPBH = this.textEditInvoiceCphm.Text;
            this.invoice.InvoiceKSLB = this.comboBoxEditInvoiceKslb.Text;
            this.invoice.InvoiceKLFS = this.comboBoxEditInvoiceKlfs.Text;
            this.invoice.InvoiceKPLS = this.comboBoxEditInvoiceFpls.Text;
            this.invoice.InvoiceFPJE = this.spinEditInvoiceFpje.Value;
            this.invoice.InvoiceFPBH = this.textEditInvoiceFpbh.Text;
            this.invoice.InvoicePayDate = DateTime.Now.AddDays(7).Date; ;
            this.invoice.InvoiceDiscount = this.spinEditInvoiceZKE.Value;
            this.invoice.InvoiceNote = this.textEditNote.Text;
            this.invoice.InvoiceReceiveable = decimal.Parse(this.spinEditInvoiceOwed.Text);
            this.invoice.CustomerInvoiceXOId = this.textEditCustomerInvoiceXOID.Text;
            this.invoice.CustomerLotNumber = this.textEditLotNumber.Text;

            if (global::Helper.DateTimeParse.DateTimeEquls(this.dateEditYJRQ.DateTime, new DateTime()))
            {
                throw new Helper.RequireValueException(Model.InvoiceXO.PRO_InvoiceYjrq);
            }
            else
            {
                this.invoice.InvoiceYjrq = this.dateEditYJRQ.DateTime;
            }

            if (global::Helper.DateTimeParse.DateTimeEquls(this.dateEditFPDate.DateTime, new DateTime()))
            {
                this.invoice.InvoiceFPDate = global::Helper.DateTimeParse.NullDate;
            }
            else
            {
                this.invoice.InvoiceFPDate = this.dateEditFPDate.DateTime;
            }

            //this.invoice.Employee1 = this.buttonEditEmployee1.EditValue as Model.Employee;
            this.invoice.Employee2 = this.buttonEditEmployee2.EditValue as Model.Employee;
            this.invoice.AuditState = this.saveAuditState;
            this.invoice.IsForeigntrade = this.checkEditIsForeigntrade.Checked;
            this.invoice.Currency = this.cob_Currency.Text;

            if (string.IsNullOrEmpty(this.invoice.CustomerInvoiceXOId))
            {
                throw new Helper.RequireValueException(Model.InvoiceXO.PRO_CustomerInvoiceXOId);
            }
            string strCusXoId = this.textEditCustomerInvoiceXOID.Text;
            string strsql = string.Empty;
            this.invoice.CustomerMarks = this.richTextBoxCustomerMarks.Rtf;
            this.invoice.Supplier = this.ncc_Supplier.EditValue as Model.Supplier;
            this.invoice.SupplierId = this.invoice.Supplier == null ? null : this.invoice.Supplier.SupplierId;

            //修改未出货数量
            if (this.action == "update")
            {
                foreach (var item in this.invoice.Details)
                {
                    item.InvoiceXODetailQuantity0 = Convert.ToDouble(item.InvoiceXODetailQuantity) - Convert.ToDouble(item.InvoiceXODetailBeenQuantity);
                }

                if (this.InvoiceCusID != this.invoice.CustomerInvoiceXOId)  //訂單號有變，修改對應的單據
                {
                    this.invoiceManager.UpdateRelationInvoiceCusID(this.InvoiceCusID, this.invoice.CustomerInvoiceXOId);
                }
            }

            switch (this.action)
            {
                case "insert":
                    strsql = "SELECT 1 FROM InvoiceXO WHERE CustomerInvoiceXOId = '" + strCusXoId + "'";
                    if (this.invoiceManager.JudgeValueExists(strsql))
                    {
                        throw new Helper.InvalidValueException(Model.InvoiceXO.PRO_CustomerInvoiceXOId);
                    }
                    this.invoiceManager.Insert(this.invoice);
                    break;

                case "update":
                    strsql = "SELECT 1 FROM InvoiceXO WHERE CustomerInvoiceXOId = '" + strCusXoId + "' AND InvoiceId <> '" + this.invoice.InvoiceId + "'";
                    if (this.invoiceManager.JudgeValueExists(strsql))
                    {
                        throw new Helper.InvalidValueException(Model.InvoiceXO.PRO_CustomerInvoiceXOId);
                    }
                    this.invoice.Employee4 = BL.V.ActiveOperator.Employee;
                    this.invoice.Employee4Id = BL.V.ActiveOperator.EmployeeId;
                    this.invoice.UpdateTime = DateTime.Now;
                    this.invoiceManager.Update(this.invoice);
                    break;
            }
        }

        protected override string getName()
        {
            string formName = this.GetType().FullName;
            formName = formName.Substring(formName.IndexOf('.') + 1).Substring(formName.Substring(formName.IndexOf('.') + 1).IndexOf('.') + 1);
            return formName;
        }

        protected override void Delete()
        {

            this.invoiceManager.Delete(this.invoice.InvoiceId);
        }

        public override BaseListForm GetListForm()
        {
            return new ListForm();
        }

        public override Book.Model.Invoice Invoice
        {
            get
            {
                return invoice;
            }
            set
            {
                if (value is Model.InvoiceXO)
                {
                    invoice = invoiceManager.Get((value as Model.InvoiceXO).InvoiceId);
                }
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == this.colProductId || e.Column == this.colProduct || e.Column == this.gridColumnCustomProduct)
            {
                Model.InvoiceXODetail detail = this.gridView1.GetRow(e.RowHandle) as Model.InvoiceXODetail;
                if (detail != null)
                {
                    // Model.CustomerProducts p = customerProductsManager.Get(e.Value.ToString());
                    Model.Product p = this.productManager.Get(e.Value.ToString());
                    if (p != null)
                    {
                        detail.InvoiceXODetailId = Guid.NewGuid().ToString();
                        detail.InvoiceXODetailMoney = 0;
                        //if (this.productManager.Get(p.CustomerBeforeProductId) != null)
                        //    detail.InvoiceXODetailNote = this.productManager.Get(p.CustomerBeforeProductId).ProductDescription;
                        //计算单价
                        //string PriceRange = (new BL.CustomerProductPriceManager()).SelectPriceByProductId((detail.ProductId));
                        //string[] PriAndRange = (PriceRange != null && PriceRange != "") ? PriceRange.Split(',') : null;
                        //if (PriAndRange != null)
                        //{
                        //    foreach (string strPAR in PriAndRange)
                        //    {
                        //        double mQuanStart = double.Parse((strPAR.Split('/')[0] != null && strPAR.Split('/')[0] != "") ? strPAR.Split('/')[0] : "0");
                        //        double mQuanEnd = double.Parse((strPAR.Split('/')[1] != null && strPAR.Split('/')[1] != "") ? strPAR.Split('/')[1] : "0");
                        //        if (detail.InvoiceXODetailQuantity <= 0)
                        //        {
                        //            detail.InvoiceXODetailPrice = 0;
                        //            this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXODetailPrice, 0);
                        //            break;
                        //        }
                        //        if (detail.InvoiceXODetailQuantity >= mQuanStart && detail.InvoiceXODetailQuantity <= mQuanEnd)
                        //        {
                        //            detail.InvoiceXODetailPrice = decimal.Parse((strPAR.Split('/')[2] != null && strPAR.Split('/')[2] != "") ? strPAR.Split('/')[2] : "0");
                        //            string mDJ = (strPAR.Split('/')[2] != null && strPAR.Split('/')[2] != "") ? strPAR.Split('/')[2] : "0";
                        //            this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXODetailPrice, mDJ);
                        //            break;
                        //        }
                        //    }
                        //}

                        detail.InvoiceXODetailPrice = 0;
                        detail.InvoiceXODetailQuantity = 0;
                        detail.InvoiceXODetailQuantity0 = 0;
                        //detail.PrimaryKey = p;
                        //detail.PrimaryKeyId = p.PrimaryKeyId;
                        detail.Product = p;
                        detail.ProductId = p.ProductId;
                        if (p.SellUnit != null)
                            detail.InvoiceProductUnit = p.SellUnit.CnName;
                        detail.InvoiceXODetailNote = "";
                        this.bindingSource1.Position = this.bindingSource1.IndexOf(detail);
                    }
                }
                this.gridControl1.RefreshDataSource();
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            tags = 1;

            if (e.Column == this.colInvoiceXODetailPrice || e.Column == this.colInvoiceXODetailQuantity || e.Column == this.gridColumnZR || e.Column == this.gridColumnZS)
            {
                decimal price = decimal.Zero;
                decimal quantity = decimal.Zero;
                decimal zherang = decimal.Zero;
                if (e.Column == this.colInvoiceXODetailPrice)
                {
                    decimal.TryParse(e.Value == null ? "0" : e.Value.ToString(), out price);

                    decimal.TryParse(this.gridView1.GetRowCellValue(e.RowHandle, this.colInvoiceXODetailQuantity).ToString(), out quantity);
                    if (this.gridView1.GetRowCellValue(e.RowHandle, this.gridColumnZR) == null)
                        this.gridView1.SetRowCellValue(e.RowHandle, this.gridColumnZR, 0);
                    decimal.TryParse(this.gridView1.GetRowCellValue(e.RowHandle, this.gridColumnZR).ToString(), out zherang);
                }
                if (e.Column == this.colInvoiceXODetailQuantity)
                {
                    decimal.TryParse(e.Value.ToString(), out quantity);
                    decimal.TryParse(this.gridView1.GetRowCellValue(e.RowHandle, this.colInvoiceXODetailPrice).ToString(), out price);
                    if (this.gridView1.GetRowCellValue(e.RowHandle, this.gridColumnZR) == null)
                        this.gridView1.SetRowCellValue(e.RowHandle, this.gridColumnZR, 0);

                    decimal.TryParse(this.gridView1.GetRowCellValue(e.RowHandle, this.gridColumnZR).ToString(), out zherang);

                    //Model.Product product = (this.bindingSource1.Current as Model.InvoiceXODetail).Product;

                    // 价格区间查询（2013.3.15）
                    //string PriceRange = (new BL.CustomerProductPriceManager()).SelectPriceByProductId((this.bindingSource1.Current as Model.InvoiceXODetail).ProductId);

                    //string[] PriAndRange = (PriceRange != null && PriceRange != "") ? PriceRange.Split(',') : null;
                    //if (PriAndRange != null)
                    //{
                    //    foreach (string strPAR in PriAndRange)
                    //    {
                    //        decimal mQuanStart = decimal.Parse((strPAR.Split('/')[0] != null && strPAR.Split('/')[0] != "") ? strPAR.Split('/')[0] : "0");
                    //        decimal mQuanEnd = decimal.Parse((strPAR.Split('/')[1] != null && strPAR.Split('/')[1] != "") ? strPAR.Split('/')[1] : "0");
                    //        if (quantity <= 0)
                    //        {
                    //            price = 0;
                    //            this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXODetailPrice, 0);
                    //            break;
                    //        }
                    //        if (quantity >= mQuanStart && quantity <= mQuanEnd)
                    //        {
                    //            price = decimal.Parse((strPAR.Split('/')[2] != null && strPAR.Split('/')[2] != "") ? strPAR.Split('/')[2] : "0");
                    //            string mDJ =          (strPAR.Split('/')[2] != null && strPAR.Split('/')[2] != "") ? strPAR.Split('/')[2] : "0";
                    //            this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXODetailPrice, mDJ);
                    //            break;
                    //        }
                    //    }
                    //}

                    Model.InvoiceXODetail invoiceXOdetail = this.bindingSource1.Current as Model.InvoiceXODetail;
                    if (invoiceXOdetail.Product != null && !string.IsNullOrEmpty(invoiceXOdetail.Product.XOPriceAndRange))
                    {
                        price = BL.SupplierProductManager.CountPrice(invoiceXOdetail.Product.XOPriceAndRange, (double)quantity);


                        if (!string.IsNullOrEmpty(invoiceXOdetail.Product.XOCurrency) &&
                            !string.IsNullOrEmpty(this.cob_Currency.Text) &&
                            invoiceXOdetail.Product.XOCurrency != cob_Currency.Text &&
                            this.dateEditInvoiceDate.EditValue != null)
                        {
                            decimal productCurrencyToTaibiRate = exchangeRateManager.GetRateByDateAndCurrency(this.dateEditInvoiceDate.DateTime, invoiceXOdetail.Product.XOCurrency);
                            productCurrencyToTaibiRate = productCurrencyToTaibiRate == 0 ? 1 : productCurrencyToTaibiRate;

                            decimal taibiCurrencyToInvoiceRate = exchangeRateManager.GetRateByDateAndCurrency(this.dateEditInvoiceDate.DateTime, cob_Currency.Text);
                            taibiCurrencyToInvoiceRate = taibiCurrencyToInvoiceRate == 0 ? 1 : taibiCurrencyToInvoiceRate;

                            price = price * productCurrencyToTaibiRate / taibiCurrencyToInvoiceRate;
                        }

                        this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXODetailPrice, price);
                    }

                }

                if (e.Column == this.gridColumnZR)
                {
                    decimal.TryParse(e.Value.ToString(), out zherang);
                    decimal.TryParse(this.gridView1.GetRowCellValue(e.RowHandle, this.colInvoiceXODetailPrice).ToString(), out price);
                    decimal.TryParse(this.gridView1.GetRowCellValue(e.RowHandle, this.colInvoiceXODetailQuantity).ToString(), out quantity);
                }
                if (e.Column == this.gridColumnZS)
                {
                    //  if ((bool)e.Value)//赠送
                    // {
                    this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXODetailMoneyxset, 0);
                    this.gridView1.SetRowCellValue(e.RowHandle, this.gridColumn2, 0);
                    //  }
                    //else
                    //{
                    //    this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXODetailPrice, decimal.Zero);
                    //    this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXODetailMoney, decimal.Zero);
                    //}
                }

                if (e.Column != this.gridColumnZS)
                {
                    zherang = this.GetDecimal(zherang, BL.V.SetDataFormat.XSJEXiao.Value);
                    price = this.GetDecimal(price, BL.V.SetDataFormat.XSDJXiao.Value);
                    this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXODetailMoneyxset, this.GetDecimal(price * quantity - zherang, BL.V.SetDataFormat.XSJEXiao.Value));
                    this.gridView1.SetRowCellValue(e.RowHandle, this.gridColumn2, this.GetDecimal(price * quantity - zherang, BL.V.SetDataFormat.XSJEXiao.Value));
                }


                this.UpdateMoneyFields();
            }
            else if (e.Column.Name == "colProduct" || e.Column.Name == "colProductId")
            {
                Model.InvoiceXODetail detail = this.bindingSource1.Current as Model.InvoiceXODetail;
                if (detail != null)
                {
                    detail.Product = productManager.Get(detail.ProductId);
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

        protected override void AddNew()
        {
            if (LastFlag == 1) { LastFlag = 0; return; }

            this.invoice = new Model.InvoiceXO();

            this.invoice.InvoiceId = this.invoiceManager.GetNewId();
            this.invoice.InvoiceDate = DateTime.Now;
            this.invoice.IsClose = false;
            this.invoice.Employee0 = BL.V.ActiveOperator.Employee;
            this.invoice.Details = new List<Model.InvoiceXODetail>();

            if (this.invoicexj != null)
            {
                this.invoice.Employee0 = this.invoicexj.Employee0;
                this.invoice.Employee0Id = this.invoicexj.Employee0Id;
                this.invoice.InvoiceAbstract = this.invoicexj.InvoiceAbstract;
                this.invoice.InvoiceNote = this.invoicexj.InvoiceNote;
                this.invoice.Customer = this.invoicexj.Customer;
                this.invoice.CustomerId = this.invoicexj.CustomerId;

                this.invoice.xocustomer = this.invoice.Customer;
                if (this.invoice.xocustomer != null)
                    this.invoice.xocustomerId = this.invoice.xocustomer.CustomerId;


                // this.invoice.InvoiceTotal = this.invoicexj.InvoiceTotal;                
                this.invoicexj.Details = this.invoiceXJDetailManager.Select(this.invoicexj);
                this.invoice.InvoiceHeji = this.invoice.InvoiceHeji == null ? 0 : this.invoice.InvoiceHeji;
                foreach (Model.InvoiceXJDetail xjdetail in this.invoicexj.Details)
                {
                    Model.InvoiceXODetail xodetail = new Book.Model.InvoiceXODetail();
                    xodetail.InvoiceId = this.invoice.InvoiceId;
                    xodetail.Inumber = this.invoice.Details.Count + 1;
                    xodetail.InvoiceXODetailId = Guid.NewGuid().ToString();
                    xodetail.InvoiceXODetailMoney = xjdetail.InvoiceXJDetailMoney;
                    xodetail.InvoiceXODetailNote = xjdetail.InvoiceXJDetailNote;
                    xodetail.InvoiceXODetailPrice = xjdetail.InvoiceXJDetailPrice;
                    xodetail.InvoiceXODetailQuantity = xjdetail.InvoiceXJDetailQuantity;
                    xodetail.TotalMoney = xodetail.InvoiceXODetailMoney;

                    xodetail.Product = xjdetail.Product;
                    xodetail.ProductId = xodetail.Product.ProductId;
                    xodetail.IsCustomerProduct = xjdetail.Product.IsCustomerProduct;
                    xodetail.InvoiceAllowance = xjdetail.InvoiceAllowance;
                    xodetail.Islargess = xjdetail.Islargess;

                    if (xjdetail.Islargess != null && xjdetail.Islargess.Value)
                    {
                        xodetail.InvoiceXODetailPrice = 0;
                        xodetail.TotalMoney = 0;
                    }
                    //xodetail.PrimaryKey = xjdetail.PrimaryKey;
                    //xodetail.PrimaryKeyId = xjdetail.PrimaryKeyId;
                    xodetail.InvoiceProductUnit = xjdetail.InvoiceProductUnit;
                    invoice.InvoiceHeji += xodetail.InvoiceXODetailMoney;// (xodetail.InvoiceXODetailPrice * decimal.Parse(xodetail.InvoiceXODetailQuantity.ToString()));                    
                    this.invoice.Details.Add(xodetail);
                }
                invoice.InvoiceHeji = this.GetDecimal(invoice.InvoiceHeji.HasValue ? invoice.InvoiceHeji.Value : 0, BL.V.SetDataFormat.XSDJXiao.Value);
                this.invoice.InvoiceTotal = invoice.InvoiceHeji;
            }
            if (this.action == "insert" && this.invoice.Details.Count == 0)
            {
                Model.InvoiceXODetail detail = new Model.InvoiceXODetail();
                detail.Inumber = this.invoice.Details.Count + 1;
                detail.InvoiceXODetailId = Guid.NewGuid().ToString();
                detail.InvoiceId = this.invoice.InvoiceId;
                detail.InvoiceXODetailMoney = 0;
                detail.InvoiceXODetailNote = "";
                detail.InvoiceXODetailPrice = 0;
                detail.InvoiceXODetailQuantity = 1;
                detail.InvoiceAllowance = 0;
                detail.TotalMoney = 0;
                // detail.PrimaryKey = new Book.Model.CustomerProducts();
                detail.Product = new Book.Model.Product();
                this.invoice.Details.Add(detail);
                this.bindingSource1.Position = this.bindingSource1.IndexOf(detail);
            }
            //productlook.Clear();
        }

        protected override void MoveNext()
        {
            Model.InvoiceXO invoice = this.invoiceManager.GetNext(this.invoice);
            if (invoice == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);

            this.invoice = this.invoiceManager.Get(invoice.InvoiceId);
        }

        protected override void MovePrev()
        {
            Model.InvoiceXO invoice = this.invoiceManager.GetPrev(this.invoice);
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
                this.invoice = new Book.Model.InvoiceXO();
                this.action = "insert";
            }
            else
            {
                if (this.action == "view")
                    this.invoice = this.invoiceManager.Get(invoice.InvoiceId);
            }
            //// this.bindingSourceproduct.DataSource = this.productManager.Select(this.invoice.xocustomer);
            // if (this.invoice.Customer != null)//
            // {
            if (this.action == "view")
                this.barButtonItemCO.Enabled = true;
            else
                this.barButtonItemCO.Enabled = false;
            this.updateCaption();
            this.newChooseCustomer2.EditValue = this.invoice.xocustomer;
            this.newChooseCustomer1.EditValue = this.invoice.Customer;
            IList<string> id = new List<string>();
            //foreach (Model.Product products in productlook)
            //{
            //    if (id.Contains(products.ProductId)) continue;
            //    id.Add(products.ProductId);
            //}
            //foreach (Model.InvoiceXODetail xodetail in this.invoice.Details)
            //{
            //    if (id.Contains(xodetail.ProductId))
            //        continue;
            //    productlook.Add(xodetail.Product);
            //}
            //this.bindingSourceproduct.DataSource = productlook;
            //if (this.lookUpEdit3.EditValue != null)
            //{

            //    productlook = this.productManager.SelectProductByCustomer(this.CustomerManager.Get(this.lookUpEdit3.EditValue.ToString()));
            //    this.bindingSourceproduct.DataSource = productlook;

            //}
            // }
            this.textEditInvoiceId.EditValue = this.invoice.InvoiceId;
            this.dateEditInvoiceDate.DateTime = this.invoice.InvoiceDate.Value;
            this.buttonEditEmployee.EditValue = this.invoice.Employee0;
            //  this.buttonEditCompany.EditValue = this.invoice.Customer;
            //this.textEditAbstract.EditValue = this.invoice.InvoiceAbstract;
            this.textEditNote.EditValue = this.invoice.InvoiceNote;
            this.calcEditInvoiceTotal0xset.Text = string.IsNullOrEmpty(this.invoice.InvoiceTotal.ToString()) ? "0" : this.invoice.InvoiceTotal.ToString();
            this.calcEditInvoiceTotalxset.Text = this.invoice.InvoiceHeji.ToString();
            this.calcEditInvoiceTax1xset.EditValue = string.IsNullOrEmpty(this.invoice.InvoiceTax.ToString()) ? "0" : this.invoice.InvoiceTax.ToString();
            this.spinEditInvoiceTaxRate1.Value = decimal.Parse(this.invoice.InvoiceTaxrate == null ? "5" : this.invoice.InvoiceTaxrate.ToString());
            this.textEditInvoiceCphm.Text = this.invoice.InvoiceCPBH;
            this.comboBoxEditInvoiceKslb.Text = this.invoice.InvoiceKSLB;
            this.comboBoxEditInvoiceKlfs.Text = this.invoice.InvoiceKLFS;
            this.comboBoxEditInvoiceFpls.Text = this.invoice.InvoiceKPLS;
            this.spinEditInvoiceFpje.Value = decimal.Parse(this.invoice.InvoiceFPJE == null ? "0" : this.invoice.InvoiceFPJE.ToString());
            this.textEditInvoiceFpbh.Text = this.invoice.InvoiceFPBH;
            this.textEditLotNumber.Text = this.invoice.CustomerLotNumber;
            //if(this.invoice.InvoicePayDate!=null)
            //   this.dateEditFPDate.DateTime = this.invoice.InvoiceFPDate == null ? DateTime.Now.AddDays(3) : this.invoice.InvoiceFPDate.Value;
            if (global::Helper.DateTimeParse.DateTimeEquls(this.invoice.InvoiceFPDate, global::Helper.DateTimeParse.NullDate))
                this.dateEditFPDate.EditValue = null;
            else
                this.dateEditFPDate.EditValue = this.invoice.InvoiceFPDate;
            if (global::Helper.DateTimeParse.DateTimeEquls(this.invoice.InvoiceYjrq, global::Helper.DateTimeParse.NullDate))
                this.dateEditYJRQ.EditValue = null;
            else
                this.dateEditYJRQ.EditValue = this.invoice.InvoiceYjrq;



            this.spinEditInvoiceZKE.Value = decimal.Parse(this.invoice.InvoiceDiscount == null ? "0" : this.invoice.InvoiceDiscount.ToString());
            this.textEditNote.Text = this.invoice.InvoiceNote;
            this.spinEditInvoiceOwed.Text = this.invoice.InvoiceReceiveable.ToString();
            //if (this.invoice.InvoiceYjrq!=null)
            //    this.dateEditYJRQ.DateTime = this.invoice.InvoiceYjrq == null ? DateTime.Now.AddDays(3) : this.invoice.InvoiceYjrq.Value;    
            this.textEditCustomerInvoiceXOID.Text = this.invoice.CustomerInvoiceXOId;
            this.InvoiceCusID = this.invoice.CustomerInvoiceXOId;
            //this.buttonEditEmployee1.EditValue = BL.V.ActiveOperator.Employee;
            this.buttonEditEmployee2.EditValue = this.invoice.Employee2;
            this.newChooseContorlEmp4.EditValue = this.invoice.Employee4;
            if (this.invoice.UpdateTime != null)
                this.dateEditUpdateTime.DateTime = this.invoice.UpdateTime.Value;
            this.newChooseContorlEmp4.Enabled = false;

            this.EmpAudit.EditValue = this.invoice.AuditEmp;
            this.textEditAuditState.Text = this.invoice.AuditStateName;

            this.cob_Currency.Text = this.invoice.Currency;
            this.checkEditIsForeigntrade.Checked = this.invoice.IsForeigntrade.HasValue ? this.invoice.IsForeigntrade.Value : false;
            this.richTextBoxCustomerMarks.Rtf = this.invoice.CustomerMarks;
            this.ncc_Supplier.EditValue = this.invoice.Supplier;

            this.bindingSource1.DataSource = this.invoice.Details;

            base.Refresh();

            this.btn_UpdatePrice.Enabled = true;
            this.textEditInvoiceId.Properties.ReadOnly = true;
            //this.buttonEditEmployee.Enabled = false;
            //this.buttonEditEmployee1.Enabled = false;
            if (this.action == "view")
            {
                this.gridView1.OptionsBehavior.Editable = true;
                this.gridColumn5.OptionsColumn.AllowEdit = true;
                this.gridColumn1.OptionsColumn.AllowEdit = false;
                this.gridColumn10.OptionsColumn.AllowEdit = false;
                this.gridColumn11.OptionsColumn.AllowEdit = false;
                this.gridColumn12.OptionsColumn.AllowEdit = false;
                this.gridColumn2.OptionsColumn.AllowEdit = false;
                this.gridColumn3.OptionsColumn.AllowEdit = false;
                this.gridColumn4.OptionsColumn.AllowEdit = false;
                this.colInvoiceXODetailMoneyxset.OptionsColumn.AllowEdit = false;
                this.colInvoiceXODetailNote.OptionsColumn.AllowEdit = false;
                this.colInvoiceXODetailPrice.OptionsColumn.AllowEdit = false;
                this.colInvoiceXODetailQuantity.OptionsColumn.AllowEdit = false;
                this.colProduct.OptionsColumn.AllowEdit = false;
                this.colProductId.OptionsColumn.AllowEdit = false;
                this.gridColumn6.OptionsColumn.AllowEdit = false;
                this.gridColumn7.OptionsColumn.AllowEdit = false;
                this.gridColumn8.OptionsColumn.AllowEdit = false;
                this.gridColumn9.OptionsColumn.AllowEdit = false;
                this.gridColumnCustomProduct.OptionsColumn.AllowEdit = false;
                this.gridColumnVersion.OptionsColumn.AllowEdit = false;
                this.gridColumnZR.OptionsColumn.AllowEdit = false;
                this.gridColumnZS.OptionsColumn.AllowEdit = false;
            }
            else
            {
                this.gridColumn5.OptionsColumn.AllowEdit = true;
                this.gridColumn1.OptionsColumn.AllowEdit = true;
                this.gridColumn11.OptionsColumn.AllowEdit = true;
                this.gridColumn2.OptionsColumn.AllowEdit = true;
                this.gridColumn3.OptionsColumn.AllowEdit = true;
                this.gridColumn4.OptionsColumn.AllowEdit = true;
                this.colInvoiceXODetailMoneyxset.OptionsColumn.AllowEdit = true;
                this.colInvoiceXODetailNote.OptionsColumn.AllowEdit = true;
                this.colInvoiceXODetailPrice.OptionsColumn.AllowEdit = true;
                this.colInvoiceXODetailQuantity.OptionsColumn.AllowEdit = true;
                this.colProduct.OptionsColumn.AllowEdit = false;
                this.colProductId.OptionsColumn.AllowEdit = true;
                this.gridColumn6.OptionsColumn.AllowEdit = true;
                this.gridColumn7.OptionsColumn.AllowEdit = true;
                this.gridColumn8.OptionsColumn.AllowEdit = true;
                //this.gridColumn9.OptionsColumn.AllowEdit = true;
                //this.gridColumn10.OptionsColumn.AllowEdit = true;
                //this.gridColumn12.OptionsColumn.AllowEdit = true;
                this.gridColumnCustomProduct.OptionsColumn.AllowEdit = true;
                this.gridColumnVersion.OptionsColumn.AllowEdit = true;
                this.gridColumnZR.OptionsColumn.AllowEdit = true;
                this.gridColumnZS.OptionsColumn.AllowEdit = true;
            }
        }

        protected override DevExpress.XtraReports.UI.XtraReport GetReport()
        {
            return new R01(this.invoice.InvoiceId);
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

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //转单
            string tag = (string)e.Item.Tag;
            switch (tag)
            {
                case "XS":
                    Operations.Open("invoices.xs.edit1", this.MdiParent, this.invoice);
                    break;
            }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (this.gridView1.FocusedColumn.Name == "gridColumn1")
            {
                if (this.gridView1.FocusedColumn.ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemComboBox)
                {
                    //Model.CustomerProducts p = (this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as Model.InvoiceXODetail).PrimaryKey;
                    Model.Product p = (this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as Model.InvoiceXODetail).Product;
                    this.repositoryItemComboBox1.Items.Clear();
                    if (p == null)
                        return;
                    if (!string.IsNullOrEmpty(p.BasedUnitGroupId))
                    {
                        Model.UnitGroup ug = new BL.UnitGroupManager().Get(p.BasedUnitGroupId);
                        IList<Model.ProductUnit> units = productUnitManager.Select(ug);
                        foreach (Model.ProductUnit ut in units)
                        {
                            this.repositoryItemComboBox1.Items.Add(ut.CnName);
                        }
                    }
                }
            }
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            if (tags == 1)
                this.UpdateMoneyFields();
        }

        protected override void IMECtrl()
        {
            Book.UI.Tools.IMEControl.IMECtrl(new Control[] { this.gridControl1, this.textEditInvoiceId, this.textEditCustomerInvoiceXOID, this });
        }

        private bool CanAdd(IList<Model.InvoiceXODetail> list)
        {
            foreach (Model.InvoiceXODetail detail in list)
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
                        Model.InvoiceXODetail detail = new Model.InvoiceXODetail();
                        detail.InvoiceXODetailId = Guid.NewGuid().ToString();
                        detail.Inumber = this.invoice.Details.Count + 1;
                        detail.InvoiceXODetailMoney = 0;
                        detail.InvoiceXODetailNote = "";
                        detail.InvoiceXODetailPrice = 0;
                        detail.InvoiceXODetailQuantity = 0;
                        detail.InvoiceXODetailQuantity0 = 0;
                        detail.InvoiceProductUnit = "";
                        // detail.PrimaryKey = new Book.Model.CustomerProducts();
                        detail.Product = new Book.Model.Product();
                        this.invoice.Details.Add(detail);
                        //this.bindingSource1.Position = this.bindingSource1.IndexOf(detail);
                    }
                }
                if (e.KeyData == Keys.Delete)
                {
                    this.simpleButtonRemove.PerformClick();
                }
                this.gridControl1.RefreshDataSource();
            }
        }

        //0 免税 1 外加 -1 内含 
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
            //double taxrate = double.Parse(this.spinEditInvoiceTaxRate1.Text); //税率
            //double ta = (taxrate + 100) / 100;

            //foreach (Model.InvoiceXODetail detail in this.invoice.Details)
            //{
            //    if (detail.Product == null || string.IsNullOrEmpty(detail.Product.ProductId)) continue;
            //    if (flag == 1)
            //    {
            //        detail.InvoiceXODetailPrice = detail.TotalMoney / decimal.Parse(detail.InvoiceXODetailQuantity.ToString());
            //    }
            //    else
            //    {
            //        detail.InvoiceXODetailPrice = detail.TotalMoney / decimal.Parse(detail.InvoiceXODetailQuantity.ToString()) / decimal.Parse(ta.ToString());
            //    }
            //    detail.InvoiceXODetailMoney =global::Helper.DateTimeParse.GetSiSheWuRu(  decimal.Parse(detail.InvoiceXODetailQuantity.ToString()) * detail.InvoiceXODetailPrice.Value,0);
            //}
            //this.spinEditInvoiceTaxRate1.Properties.Buttons[1].Enabled = flag == 1 ? false : true;
            this.spinEditInvoiceTaxRate1.Properties.Buttons[2].Enabled = flag == -1 ? false : true;
            this.UpdateMoneyFields();
        }

        private void UpdateMoneyFields()
        {
            decimal yse = 0;//应收额                      

            foreach (Model.InvoiceXODetail detail in this.invoice.Details)
            {
                if (detail.TotalMoney == null)
                    detail.TotalMoney = 0;
                yse += detail.TotalMoney.Value;

            }
            yse = this.GetDecimal(yse, BL.V.SetDataFormat.XSZJXiao.Value);
            if (this.action != "view")
            {
                if (flag == 0)
                {
                    this.calcEditInvoiceTotalxset.EditValue = yse;
                    this.calcEditInvoiceTax1xset.EditValue = 0;
                    this.calcEditInvoiceTotal0xset.EditValue = yse;
                    this.comboBoxEditInvoiceKslb.SelectedIndex = 2;
                }
                else if (flag == 1)
                {
                    this.calcEditInvoiceTotalxset.EditValue = yse;
                    this.calcEditInvoiceTax1xset.EditValue = this.GetDecimal(yse * this.spinEditInvoiceTaxRate1.Value / 100, BL.V.SetDataFormat.XSZJXiao.Value);
                    this.calcEditInvoiceTotal0xset.EditValue = yse + decimal.Parse(this.calcEditInvoiceTax1xset.EditValue.ToString());
                    this.comboBoxEditInvoiceKslb.SelectedIndex = 1;
                }
                else
                {
                    this.calcEditInvoiceTotal0xset.EditValue = yse;
                    this.calcEditInvoiceTotalxset.EditValue = this.GetDecimal(yse * 100 / (100 + this.spinEditInvoiceTaxRate1.Value), BL.V.SetDataFormat.XSZJXiao.Value);
                    this.calcEditInvoiceTax1xset.EditValue = decimal.Parse(this.calcEditInvoiceTotal0xset.EditValue.ToString()) - decimal.Parse(this.calcEditInvoiceTotalxset.EditValue.ToString());
                    this.comboBoxEditInvoiceKslb.SelectedIndex = 0;
                }
            }
            spinEditInvoiceFpje.EditValue = this.calcEditInvoiceTotal0xset.EditValue;
            //this.gridControl1.RefreshDataSource();
        }

        private void spinEditInvoiceTaxRate1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int index = e.Button.Index;
            switch (index)
            {
                case 1:
                    flag = 1;
                    TaxMethod();
                    break;
                case 2:
                    flag = -1;
                    TaxMethod();
                    break;
                default:
                    this.spinEditInvoiceTaxRate1.Properties.Buttons[1].Enabled = true;
                    this.spinEditInvoiceTaxRate1.Properties.Buttons[2].Enabled = true;
                    TaxMethod();
                    break;
            }
        }

        private void spinEditInvoiceZKE_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            this.spinEditInvoiceOwed.EditValue = decimal.Parse(this.calcEditInvoiceTotal0xset.EditValue.ToString()) - this.spinEditInvoiceZKE.Value - this.spinEditYiShou.Value;
        }

        private void spinEditYiShou_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            this.spinEditInvoiceOwed.EditValue = decimal.Parse(this.calcEditInvoiceTotal0xset.EditValue.ToString()) - this.spinEditInvoiceZKE.Value - this.spinEditYiShou.Value;
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.ListSourceRowIndex < 0) return;
            IList<Model.InvoiceXODetail> details = this.bindingSource1.DataSource as IList<Model.InvoiceXODetail>;
            if (details == null || details.Count < 1) return;
            // Model.CustomerProducts product = details[e.ListSourceRowIndex].PrimaryKey;
            Model.Product product = details[e.ListSourceRowIndex].Product;
            if (product == null) return;
            switch (e.Column.Name)
            {
                case "gridColumnCustomProduct":
                    e.DisplayText = product.CustomerProductName;
                    break;
                case "gridColumnVersion":
                    e.DisplayText = product.ProductVersion;
                    break;
            }

        }

        //private void buttonEditCompany_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (this.lookUpEdit3.EditValue != null)
        //    {
        //        //this.bindingSourceproduct.DataSource = this.customerProductsManager.Select(this.buttonEditXSCustomer.EditValue as Model.Customer);
        //        this.bindingSourceproduct.DataSource = this.productManager.Select(this.buttonEditXSCustomer.EditValue as Model.Customer);
        //    }
        //    else
        //    {
        //        this.bindingSourceproduct.Clear();
        //        IList<Model.InvoiceXODetail> list = this.bindingSource1.DataSource as IList<Model.InvoiceXODetail>;
        //        if (list == null)
        //            return;
        //        foreach (Model.InvoiceXODetail detail in list)
        //        {
        //            //detail.PrimaryKeyId = null;
        //            //detail.PrimaryKey = null;
        //            detail.Product = null;
        //            detail.ProductId = null;
        //            detail.InvoiceProductUnit = "";
        //        }

        //        this.gridControl1.RefreshDataSource();
        //    }
        //}

        //private void buttonEditXSCustomer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    Invoices.ChooseCustoms f = new Book.UI.Invoices.ChooseCustoms();
        //    if (f.ShowDialog(this) == DialogResult.OK)
        //    {
        //        this.lookUpEdit3.EditValue = f.SelectedItem as Model.Customer;
        //        this.invoice.xocustomer = f.SelectedItem as Model.Customer;
        //        this.bindingSourceproduct.DataSource = this.productManager.Select(this.invoice.xocustomer);


        //    }
        //}

        //private void buttonEditCustomer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    Invoices.ChooseCustoms f = new Book.UI.Invoices.ChooseCustoms();
        //    if (f.ShowDialog(this) == DialogResult.OK)
        //    {
        //        this.lookUpEdit1.EditValue = f.SelectedItem as Model.Customer;

        //        this.invoice.Customer = f.SelectedItem as Model.Customer;

        //         if(this.buttonEditXSCustomer.EditValue==null)
        //        this.buttonEditXSCustomer.EditValue = f.SelectedItem as Model.Customer;
        //         this.invoice.xocustomer = f.SelectedItem as Model.Customer;


        //    }
        //}

        /// <summary>
        /// 查询销售订单 中所有货品  求出所有货品所需采购数量 =订单数量-库存数量 
        /// </summary>
        public void getProductNeedCOQuantity()
        {

            this.invoice.Details = this.invoiceDetailManager.Select(this.invoice, false);

            //  for
            //this.productDetail=




        }

        private void GetXo()
        {
            //int co1 = 0;
            //int co2 = 0;
            //IList<Model.Role> roleList = BL.V.RoleList;
            //if (roleList != null && roleList.Count > 0)
            //{


            //    for (int i = 0; i < roleList.Count; i++)
            //    {
            //        if (roleList[i].IsXOPrice == true)
            //        {
            //            co1 = 1;
            //        }
            //        if (roleList[i].IsXOQuantity == true)
            //        {
            //            co2 = 1;
            //        }
            //    }

            //    if (co1 == 1)
            //    {
            //        this.colInvoiceXODetailPrice.Visible = true;
            //        this.colInvoiceXODetailMoney.Visible = true;
            //        co1 = 0;
            //    }
            //    else
            //    {
            //        this.colInvoiceXODetailPrice.Visible = false;
            //        this.colInvoiceXODetailMoney.Visible = false;
            //    }
            //    if (co2 == 1)
            //    {
            //        this.colInvoiceXODetailQuantity.Visible = true;
            //        this.colInvoiceXODetailMoney.Visible = true;
            //        co2 = 0;
            //    }
            //    else
            //    {
            //        this.colInvoiceXODetailQuantity.Visible = false;
            //        this.colInvoiceXODetailMoney.Visible = false;
            //    }
            //}

        }

        //private void dateEditInvoiceDate_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (this.action == "insert") { this.textEditInvoiceId.EditValue = this.invoiceManager.GetNewId(this.dateEditInvoiceDate.DateTime); }
        //}

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView view = this.gridView1;
            this.saveFileDialog1.Filter = "PDF file|*.pdf";
            if (this.saveFileDialog1.ShowDialog(this) != DialogResult.OK)
                return;

            string file = this.saveFileDialog1.FileName;
            this.ExportToPdf(file);

        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView view = this.gridView1;
            this.saveFileDialog1.Filter = "Excel file|*.xls";
            if (this.saveFileDialog1.ShowDialog(this) != DialogResult.OK)
                return;

            string file = this.saveFileDialog1.FileName;
            view.GridControl.ExportToXls(file);
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView view = this.gridView1;
            this.saveFileDialog1.Filter = "Word file|*.doc";
            if (this.saveFileDialog1.ShowDialog(this) != DialogResult.OK)
                return;

            string file = this.saveFileDialog1.FileName;
            view.GridControl.ExportToRtf(file);
        }

        public void ExportToPdf(string file)
        {
            System.Drawing.Font fhead = new System.Drawing.Font("DFKai-SB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            System.Drawing.Font fcontent = new System.Drawing.Font("DFKai-SB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            System.Drawing.Font tmpHead = null;
            System.Drawing.Font tmpContent = null;
            if (this.gridView1.Columns.Count > 0)
            {
                tmpHead = this.gridView1.Columns[0].AppearanceHeader.Font;
                tmpContent = this.gridView1.Columns[0].AppearanceCell.Font;
            }
            foreach (GridColumn column in this.gridView1.Columns)
            {
                column.AppearanceHeader.Font = fhead;
                column.AppearanceCell.Font = fcontent;
            }

            PrintingSystem system = new PrintingSystem();
            PrintableComponentLink link = new PrintableComponentLink(system);
            try
            {
                link.Component = this.gridView1.GridControl;
                link.Landscape = true;
                link.PaperKind = System.Drawing.Printing.PaperKind.A4;
                link.Margins = new System.Drawing.Printing.Margins(30, 30, 50, 50);
                link.CreateDocument();
                //link.PrintingSystem.Document.PrintingSystem.PageMargins.Bottom = 10;
                //link.PrintingSystem.Document.PrintingSystem.PageMargins.Left = 1000;
                //link.PrintingSystem.Document.PrintingSystem.PageMargins.Right = 10;
                //link.PrintingSystem.Document.PrintingSystem.PageMargins.Top = 30;
                //PdfDocumentOptions pdo = new PdfDocumentOptions();
                //pdo.Author = "author";
                //pdo.Keywords = "keywords";
                //pdo.Subject = "subject";
                //pdo.Title = "title";
                //pdo.Application = "application";
                PdfExportOptions op = new PdfExportOptions();
                op.DocumentOptions.Author = "author";
                op.DocumentOptions.Keywords = "keywords";
                op.DocumentOptions.Subject = "subject";
                op.DocumentOptions.Title = "title";
                op.DocumentOptions.Application = "application";
                op.ImageQuality = PdfJpegImageQuality.Highest;

                link.PrintingSystem.ExportToPdf(file, op);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                system = null;
                link = null;
                foreach (GridColumn column in this.gridView1.Columns)
                {
                    column.AppearanceHeader.Font = tmpHead;
                    column.AppearanceCell.Font = tmpContent;
                }
            }
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
                // invoice.InvoiceCPBH = null;
                this.invoice.JieAnDate = DateTime.Now;
                invoice.IsNotAutoClose = true;
                this.invoiceManager.UpdateAccess(this.invoice);
                new BL.PronoteHeaderManager().UpdateHeaderIsClseByXOId(this.invoice.InvoiceId, true);
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
                this.barButtonItemJieAn.Caption = "取消結案";
            else
                this.barButtonItemJieAn.Caption = "強制結案";
            this.barButtonItemJieAn.Enabled = this.action == "view" ? true : false;
        }

        private void newChooseCustomer1_EditValueChanged(object sender, EventArgs e)
        {
            if (this.newChooseCustomer1.EditValue != null && this.newChooseCustomer2.EditValue == null)
            {
                this.newChooseCustomer2.EditValue = newChooseCustomer1.EditValue;

            }
        }

        private void newChooseCustomer2_EditValueChanged(object sender, EventArgs e)
        {
            if (this.newChooseCustomer2.EditValue != null && this.action != "view")
            {
                //productlook = this.productManager.SelectProductByCustomer(newChooseCustomer2.EditValue as Model.Customer);
                //this.bindingSourceproduct.DataSource = productlook;
            }
            //if (this.lookUpEdit3.EditValue != null)
            //{               
            //    this.bindingSourceproduct.DataSource = this.productManager.SelectProductByCustomer(this.CustomerManager.Get( this.lookUpEdit3.EditValue.ToString()));
            //}
            //else
            //{
            //    this.bindingSourceproduct.Clear();
            //    IList<Model.InvoiceXODetail> list = this.bindingSource1.DataSource as IList<Model.InvoiceXODetail>;
            //    if (list == null)
            //        return;
            //    foreach (Model.InvoiceXODetail detail in list)
            //    {
            //        //detail.PrimaryKeyId = null;
            //        //detail.PrimaryKey = null;
            //        detail.Product = null;
            //        detail.ProductId = null;
            //        detail.InvoiceProductUnit = "";
            //    }

            //    this.gridControl1.RefreshDataSource();
            //}

        }

        private void btn_ChooseCustomerMarks_Click(object sender, EventArgs e)
        {
            if (this.newChooseCustomer2.EditValue == null)
            {
                MessageBox.Show("請先選擇出貨客戶！");
                return;
            }
            //if (f.ShowDialog(this) == DialogResult.OK)
            //{
            //if (this.newChooseCustomer2.EditValue != null)
            //    this.richTextBoxCustomerMarks.Rtf = (new BL.CustomerManager()).Select((this.newChooseCustomer2.EditValue  as Model.Customer).CustomerId).;
            //
            IList<marks> list = new List<marks>();
            Model.Customer model = this.newChooseCustomer2.EditValue as Model.Customer;

            marks mark = null;
            if (model.Marks1 != null)
            {
                mark = new marks();
                mark.Id = "1";
                mark.Mark = model.Marks1;
                list.Add(mark);
            }
            if (model.Marks2 != null)
            {
                mark = new marks();
                mark.Id = "2";
                mark.Mark = model.Marks2;
                list.Add(mark);
            }
            if (model.Marks3 != null)
            {
                mark = new marks();
                mark.Id = "3";
                mark.Mark = model.Marks3;
                list.Add(mark);
            }

            Settings.BasicData.Customs.ChooseCustomerMarksForm f = new Book.UI.Settings.BasicData.Customs.ChooseCustomerMarksForm(list);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                this.richTextBoxCustomerMarks.Rtf = (f.SelectedItem as marks).Mark;
            }
        }

        public class marks
        {
            public string Id { get; set; }
            public string Mark { get; set; }
        }

        //形成采购单
        private void barButtonItemCO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CO.EditForm f = new CO.EditForm(this.invoice);
            f.Show();

        }

        private void simpleInputExcle_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExcelClass1 ec = new ExcelClass1();
                ec.Open(openFileDialog1.FileName);

                action = "insert";

                Microsoft.Office.Interop.Excel.Worksheet ss = (Microsoft.Office.Interop.Excel.Worksheet)ec.wb.Worksheets[1];

                Model.InvoiceXO xo = new Book.Model.InvoiceXO();
                xo.InvoiceId = this.invoiceManager.GetNewId();
                xo.InvoiceDate = DateTime.Now;
                xo.IsClose = false;
                xo.Employee0 = BL.V.ActiveOperator.Employee;
                xo.Details = new List<Model.InvoiceXODetail>();

                xo.CustomerInvoiceXOId = ((Microsoft.Office.Interop.Excel.Range)ss.Cells[3, 2]).Text.ToString();
                xo.CustomerLotNumber = ((Microsoft.Office.Interop.Excel.Range)ss.Cells[4, 2]).Text.ToString();
                xo.xocustomer = this.CustomerManager.SelectByIdAndFullName(((Microsoft.Office.Interop.Excel.Range)ss.Cells[2, 3]).Text.ToString(), ((Microsoft.Office.Interop.Excel.Range)ss.Cells[2, 2]).Text.ToString());

                Model.InvoiceXODetail detail;
                this.invoice.Details.Clear();
                for (int i = 6; i < 100; i++) //第六行开始Detail
                {
                    detail = new Book.Model.InvoiceXODetail();
                    if (string.IsNullOrEmpty(((Microsoft.Office.Interop.Excel.Range)ss.Cells[i, 1]).Text.ToString()))
                        break;
                    detail.InvoiceXODetailId = Guid.NewGuid().ToString();
                    detail.InvoiceId = xo.InvoiceId;
                    detail.Inumber = this.invoice.Details.Count + 1;
                    detail.Product = this.productManager.SelectByIdAndName(((Microsoft.Office.Interop.Excel.Range)ss.Cells[i, 1]).Text.ToString(), ((Microsoft.Office.Interop.Excel.Range)ss.Cells[i, 2]).Text.ToString());
                    if (detail.Product != null)
                        detail.ProductId = detail.Product.ProductId;
                    else
                    {
                        MessageBox.Show("無此商品，\r編號：" + ((Microsoft.Office.Interop.Excel.Range)ss.Cells[i, 1]).Text.ToString() + "\r名稱：" + ((Microsoft.Office.Interop.Excel.Range)ss.Cells[i, 2]).Text.ToString() + "\r請查證或新建此商品。");
                        return;
                    }
                    detail.InvoiceProductUnit = ((Microsoft.Office.Interop.Excel.Range)ss.Cells[i, 3]).Text.ToString();
                    detail.InvoiceXODetailQuantity = Convert.ToDouble(((Microsoft.Office.Interop.Excel.Range)ss.Cells[i, 4]).Text.ToString());
                    detail.InvoiceXODetailPrice = Convert.ToDecimal(((Microsoft.Office.Interop.Excel.Range)ss.Cells[i, 5]).Text.ToString());
                    detail.InvoiceXODetailMoney = Convert.ToDecimal(detail.InvoiceXODetailQuantity) * detail.InvoiceXODetailPrice;
                    detail.TotalMoney = detail.InvoiceXODetailMoney;
                    detail.InvoiceAllowance = 0;

                    xo.Details.Add(detail);
                }
                this.invoice = xo;
                this.Refresh();
                UpdateMoneyFields();
            }
        }

        private void btn_MPS_Click(object sender, EventArgs e)
        {
            if (this.action != "view")
            {
                MessageBox.Show("請先保存單據！", this.Text, MessageBoxButtons.OK);
                return;
            }

            IList<Model.InvoiceXODetail> list = this.bindingSource1.DataSource as List<Model.InvoiceXODetail>;
            if (list != null)
            {
                var detailIds = from n in list
                                where n.IsConfirmed == true
                                select n.InvoiceXODetailId;
                if (detailIds != null && detailIds.Count() > 0)
                {
                    //多这些步骤是为了每次排单时刷新一次数据
                    this.Refresh();

                    list = this.bindingSource1.DataSource as List<Model.InvoiceXODetail>;
                    var details = list.Where(L => detailIds.Contains(L.InvoiceXODetailId));

                    foreach (Model.InvoiceXODetail item in details)
                    {
                        if (item.InvoiceMPSQuantity >= item.InvoiceXODetailQuantity)
                        {
                            MessageBox.Show("序號：" + item.Inumber.ToString() + "已排單，請勿重複排單", this.Text, MessageBoxButtons.OK);
                            return;
                            //else
                            //    break;
                        }
                        if (!(bool)item.IsNeedMPS)
                        {
                            if (MessageBox.Show("序號：" + item.Inumber.ToString() + "不需要生產排程，是否繼續", this.Text, MessageBoxButtons.YesNo) == DialogResult.No)
                                return;
                            else
                                break;
                        }
                    }
                    produceManager.MPSheader.EditForm mps = new Book.UI.produceManager.MPSheader.EditForm(details.ToList());
                    mps.Show(this);
                    foreach (var item in details)
                    {
                        item.IsConfirmed = false;
                    }
                    //this.gridControl1.RefreshDataSource();
                    this.Refresh();
                }
                else
                {
                    MessageBox.Show("請選擇要排程的商品！", this.Text, MessageBoxButtons.OK);
                    return;
                }
            }
        }

        private void dateEditInvoiceDate_EditValueChanged(object sender, EventArgs e)
        {
            CountProPriceAndMoney();

        }

        private void cob_Currency_EditValueChanged(object sender, EventArgs e)
        {
            CountProPriceAndMoney();
        }

        private void CountProPriceAndMoney()
        {
            if (!string.IsNullOrEmpty(this.cob_Currency.Text) && this.dateEditInvoiceDate.EditValue != null && this.action != "view")
            {
                foreach (var item in invoice.Details)
                {
                    item.InvoiceXODetailPrice = BL.SupplierProductManager.CountPrice(item.Product.XOPriceAndRange, Convert.ToDouble(item.InvoiceXODetailQuantity));

                    if (!string.IsNullOrEmpty(item.Product.XOCurrency) && item.Product.XOCurrency != this.cob_Currency.Text)
                    {
                        decimal productCurrencyToTaibiRate = exchangeRateManager.GetRateByDateAndCurrency(this.dateEditInvoiceDate.DateTime, item.Product.XOCurrency);
                        productCurrencyToTaibiRate = productCurrencyToTaibiRate == 0 ? 1 : productCurrencyToTaibiRate;

                        decimal taibiCurrencyToInvoiceRate = exchangeRateManager.GetRateByDateAndCurrency(this.dateEditInvoiceDate.DateTime, cob_Currency.Text);
                        taibiCurrencyToInvoiceRate = taibiCurrencyToInvoiceRate == 0 ? 1 : taibiCurrencyToInvoiceRate;

                        item.InvoiceXODetailPrice = item.InvoiceXODetailPrice * productCurrencyToTaibiRate / taibiCurrencyToInvoiceRate;
                    }

                    item.InvoiceXODetailMoney = Convert.ToDecimal(item.InvoiceXODetailQuantity) * item.InvoiceXODetailPrice;
                    item.TotalMoney = item.InvoiceXODetailMoney;
                }

                UpdateMoneyFields();
                this.gridControl1.RefreshDataSource();
            }
        }

        //廈門訂單通知
        private void bar_PrintXiamen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            R01_Xiamen ro= new R01_Xiamen(this.invoice.InvoiceId);
            ro.ShowPreviewDialog();
        }
    }
}