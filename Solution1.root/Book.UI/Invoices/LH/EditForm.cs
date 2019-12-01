using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.Invoices.LH
{
    public partial class EditForm : BaseEditForm
    {
        protected BL.InvoiceLHManager invoiceLHManager = new Book.BL.InvoiceLHManager();
        protected BL.InvoiceLHDetailManager invoiceLHDetailManager = new Book.BL.InvoiceLHDetailManager();

        protected Model.InvoiceLH invoice;
        int LastFlag = 0; //页面载入时是否执行 last方法

        #region Constructors

        public EditForm()
        {
            InitializeComponent();

            this.requireValueExceptions.Add(Model.InvoiceLH.PRO_InvoiceId, new AA(Properties.Resources.RequireDataForId, this.txt_InvoiceId));
            this.requireValueExceptions.Add(Model.InvoiceLH.PRO_InvoiceDate, new AA(Properties.Resources.DateIsNull, this.date_InvoiceDate));
            this.requireValueExceptions.Add(Model.InvoiceLH.PRO_CustomerId, new AA("客户不能为空", this.ncc_Customer));

            this.action = "view";
            this.ncc_Customer.Choose = new Settings.BasicData.Customs.ChooseCustoms();
            this.ncc_EmpCreater.Choose = new Settings.BasicData.Employees.ChooseEmployee();
            //this.ncc_EmpShengguan.Choose = new Settings.BasicData.Employees.ChooseEmployee();
            //this.ncc_EmpShechu.Choose = new Settings.BasicData.Employees.ChooseEmployee();
            //this.ncc_EmpPinjian.Choose = new Settings.BasicData.Employees.ChooseEmployee();
            //this.ncc_EmpDepot.Choose = new Settings.BasicData.Employees.ChooseEmployee();
            this.EmpAudit.Choose = new Settings.BasicData.Employees.ChooseEmployee();
        }

        public EditForm(string invoiceId)
            : this()
        {
            this.invoice = this.invoiceLHManager.Get(invoiceId);
            if (this.invoice == null)
                throw new ArithmeticException("invoiceid");
            this.action = "view";
            if (this.action == "view")
                LastFlag = 1;
        }

        public EditForm(Model.InvoiceLH invoiceLH)
            : this()
        {
            if (invoiceLH == null)
                throw new ArithmeticException("invoiceid");
            this.invoice = invoiceLH;
            this.action = "view";
            if (this.action == "view")
                LastFlag = 1;
        }

        #endregion

        private void EditForm_Load(object sender, EventArgs e)
        {
            this.bindingSourceConveyanceMethod.DataSource = new BL.ConveyanceMethodManager().Select();

            string sql = "select CnName from ProductUnit group by CnName";
            this.bindingSourceProductUnit.DataSource = invoiceLHManager.Query(sql, 100, "ProductUnit").Tables[0];
        }

        protected override string tableCode()
        {
            return "InvoiceLH";
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
                if (value is Model.InvoiceLH)
                {
                    invoice = invoiceLHManager.Get((value as Model.InvoiceLH).InvoiceId);
                }
            }
        }

        protected override void AddNew()
        {
            this.invoice = new Model.InvoiceLH();

            this.invoice.InvoiceId = this.invoiceLHManager.GetNewId(DateTime.Now);
            this.invoice.InvoiceDate = DateTime.Now;
            this.invoice.EmpCreater = BL.V.ActiveOperator.Employee;
        }

        protected override void MoveNext()
        {
            Model.InvoiceLH invoice = this.invoiceLHManager.GetNext(this.invoice);
            if (invoice == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);

            this.invoice = this.invoiceLHManager.Get(invoice.InvoiceId);
        }

        protected override void MovePrev()
        {
            Model.InvoiceLH invoice = this.invoiceLHManager.GetPrev(this.invoice);
            if (invoice == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);

            this.invoice = this.invoiceLHManager.Get(invoice.InvoiceId);
        }

        protected override void MoveFirst()
        {
            this.invoice = this.invoiceLHManager.Get(this.invoiceLHManager.GetFirst() == null ? "" : this.invoiceLHManager.GetFirst().InvoiceId);
        }

        protected override void MoveLast()
        {
            if (LastFlag == 1) { LastFlag = 0; return; }
            this.invoice = this.invoiceLHManager.Get(this.invoiceLHManager.GetLast() == null ? "" : this.invoiceLHManager.GetLast().InvoiceId);
        }

        protected override bool HasRows()
        {
            return this.invoiceLHManager.HasRows();
        }

        protected override bool HasRowsNext()
        {
            return this.invoiceLHManager.HasRowsAfter(this.invoice);
        }

        protected override bool HasRowsPrev()
        {
            return this.invoiceLHManager.HasRowsBefore(this.invoice);
        }

        public override void Refresh()
        {
            if (this.invoice == null)
            {
                this.invoice = new Book.Model.InvoiceLH();
                this.action = "insert";
            }
            else
            {
                if (this.action == "view")
                    this.invoice = this.invoiceLHManager.GetDetail(invoice.InvoiceId);
            }

            this.txt_InvoiceId.EditValue = this.invoice.InvoiceId;
            this.date_InvoiceDate.EditValue = this.invoice.InvoiceDate;
            this.ncc_Customer.EditValue = this.invoice.Customer;
            this.lue_ConveyanceMethod.EditValue = this.invoice.ConveyanceMethodId;
            this.ncc_EmpCreater.EditValue = this.invoice.EmpCreater;
            //this.ncc_EmpShengguan.EditValue = this.invoice.EmpShengguan;
            //this.ncc_EmpShechu.EditValue = this.invoice.EmpShechu;
            //this.ncc_EmpPinjian.EditValue = this.invoice.EmpPinjian;
            //this.ncc_EmpDepot.EditValue = this.invoice.EmpDepot;
            this.EmpAudit.EditValue = this.invoice.AuditEmp;
            this.textEditAuditState.Text = this.invoice.AuditStateName;

            this.bindingSourceDetail.DataSource = this.invoice.Detail;

            switch (this.action)
            {
                case "insert":
                    this.gridView1.OptionsBehavior.Editable = true;
                    break;

                case "update":
                    this.gridView1.OptionsBehavior.Editable = true;
                    break;

                case "view":
                    this.gridView1.OptionsBehavior.Editable = false;
                    break;
                default:
                    break;
            }
            base.Refresh();

            this.txt_InvoiceId.Properties.ReadOnly = true;
            this.ncc_EmpCreater.Enabled = false;
        }

        protected override void Save(Helper.InvoiceStatus status)
        {
            this.invoice.InvoiceStatus = (int)status;

            if (!this.gridView1.PostEditor() || !this.gridView1.UpdateCurrentRow())
                return;

            this.invoice.InvoiceId = this.txt_InvoiceId.Text;
            if (date_InvoiceDate.EditValue != null)
                this.invoice.InvoiceDate = date_InvoiceDate.DateTime;
            if (ncc_Customer.EditValue != null)
                this.invoice.CustomerId = (ncc_Customer.EditValue as Model.Customer).CustomerId;
            if (lue_ConveyanceMethod.EditValue != null)
                this.invoice.ConveyanceMethodId = lue_ConveyanceMethod.EditValue.ToString();
            if (ncc_EmpCreater.EditValue != null)
                this.invoice.EmpCreaterId = (ncc_EmpCreater.EditValue as Model.Employee).EmployeeId;
            //if (ncc_EmpShengguan.EditValue != null)
            //    this.invoice.EmpShengguanId = (ncc_EmpShengguan.EditValue as Model.Employee).EmployeeId;
            //if (ncc_EmpShechu.EditValue != null)
            //    this.invoice.EmpShechuId = (ncc_EmpShechu.EditValue as Model.Employee).EmployeeId;
            //if (ncc_EmpPinjian.EditValue != null)
            //    this.invoice.EmpPinjianId = (ncc_EmpPinjian.EditValue as Model.Employee).EmployeeId;
            //if (ncc_EmpDepot.EditValue != null)
            //    this.invoice.EmpDepotId = (ncc_EmpDepot.EditValue as Model.Employee).EmployeeId;
            this.invoice.AuditState = this.saveAuditState;

            switch (this.action)
            {
                case "insert":
                    this.invoiceLHManager.Insert(this.invoice);
                    break;

                case "update":
                    this.invoiceLHManager.Update(this.invoice);
                    break;
            }
        }

        protected override void TurnNull()
        {
            if (this.invoice == null)
                return;
            if (MessageBox.Show(Properties.Resources.ConfirmToDelete, this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            this.invoiceLHManager.Delete(this.invoice.InvoiceId);
            this.invoice = this.invoiceLHManager.GetNext(this.invoice);
            if (this.invoice == null)
            {
                this.invoice = this.invoiceLHManager.GetLast();
            }
        }

        protected override DevExpress.XtraReports.UI.XtraReport GetReport()
        {
            return new RO(this.invoice);
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (this.bindingSourceDetail.Current != null)
            {
                this.bindingSourceDetail.Remove(this.bindingSourceDetail.Current);
                //this.invoice.Detail.Remove(this.bindingSourceDetail.Current as Model.InvoiceLHDetail);

                this.gridControl1.RefreshDataSource();
            }
        }

        //選取客戶訂單
        private void barInvoiceXO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.action == "view")
                return;

            if (this.ncc_Customer.EditValue == null)
            {
                MessageBox.Show("請先選擇客戶", this.Text, MessageBoxButtons.OK);
                return;
            }

            XS.SearcharInvoiceXSForm f = new Book.UI.Invoices.XS.SearcharInvoiceXSForm(this.ncc_Customer.EditValue as Model.Customer);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                Model.InvoiceLHDetail model;
                foreach (var item in f.key)
                {
                    model = new Book.Model.InvoiceLHDetail();

                    model.InvoiceLHDetailId = Guid.NewGuid().ToString();
                    model.Number = this.invoice.Detail.Count + 1;
                    model.Product = item.Product;
                    model.ProductId = item.ProductId;
                    model.InvoiceXODetail = item;
                    model.InvoiceXODetailId = item.InvoiceXODetailId;
                    model.EstimateQty = Convert.ToDecimal(item.InvoiceXODetailQuantity);
                    model.ProductUnit = item.InvoiceProductUnit;

                    this.invoice.Detail.Add(model);
                }

                this.gridControl1.RefreshDataSource();
            }
        }

        private void ncc_Customer_EditValueChanged(object sender, EventArgs e)
        {
            //if (ncc_Customer.EditValue != null && this.action!="view")
            //{

            //    this.invoice.Detail.Clear();
            //    this.gridControl1.RefreshDataSource();
            // }
        }
    }
}