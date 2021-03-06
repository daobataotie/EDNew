﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Book.UI.Settings.BasicData.Employees;
using Book.UI.Invoices;
using System.Reflection;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Columns;

namespace Book.UI.produceManager.MPSheader
{
    /*----------------------------------------------------------------
   // Copyright (C) 2008 - 2010   咸阳飛馳軟件有限公司
   //                     版權所有 圍著必究
   // 功能描述: 生产计划
   // 编 码 人: 马艳军             完成时间:2010-3-28
   // 修改原因：
   // 修 改 人:                          修改时间:
   // 修改原因：
   // 修 改 人:                          修改时间:
   //----------------------------------------------------------------*/

    public partial class EditForm : Settings.BasicData.BaseEditForm
    {
        //设置静态字段 在选择销售订单页面赋值
        //  public static IList<Model.InvoiceXODetail> _InvoiceXO = new List<Model.InvoiceXODetail>();
        //标致是否是保存后 执行 TREELIST事件的
        private int flag = 0;
        private int tag = 0; //值等于1时，窗体加载时action=“insert”不回家再AddNew（）；方法
        Model.MPSheader mpsheader = new Book.Model.MPSheader();
        BL.MPSheaderManager mpsheaderManager = new Book.BL.MPSheaderManager();
        BL.MPSdetailsManager mpsdetailManager = new Book.BL.MPSdetailsManager();
        Model.Product product = new Book.Model.Product();
        Model.SalesFordetails _salesFordetails = new Book.Model.SalesFordetails();
        protected BL.ProductManager productManager = new Book.BL.ProductManager();
        //销售单model
        IList<Model.InvoiceXO> invoiceXODeteil = new List<Model.InvoiceXO>();
        //销售详细model
        IList<Model.InvoiceXODetail> invoiceXODeteils = new List<Model.InvoiceXODetail>();
        BL.SalesFordetailsManager salesFordetailsManager = new Book.BL.SalesFordetailsManager();
        BL.MRSHeaderManager mRSHeaderManager = new Book.BL.MRSHeaderManager();
        BL.BomComponentInfoManager bomComponentinfoManager = new BL.BomComponentInfoManager();
        BL.BomParentPartInfoManager BomparentManager = new Book.BL.BomParentPartInfoManager();
        BL.BomPackageDetailsManager bomPackageDetailsManager = new BL.BomPackageDetailsManager();
        BL.InvoiceXOManager invoiceXOManager = new Book.BL.InvoiceXOManager();
        BL.ProductUnitManager productUnitManager = new BL.ProductUnitManager();

        public EditForm()
        {
            InitializeComponent();
            this.requireValueExceptions.Add(Model.MPSheader.PRO_Id, new AA(Properties.Resources.RequireDataForId, this.textMPSheaderId));
            //this.requireValueExceptions.Add(Model.MPSheader.PRO_MPSheaderName, new AA(Properties.Resources.RequireDataForNames, this.textMPSheaderName));
            this.requireValueExceptions.Add(Model.MPSheader.PRO_MPSStartDate, new AA(Properties.Resources.RequireMPSStartDate, this.dateMPSStartDate));
            this.requireValueExceptions.Add(Model.MPSheader.PRO_MPSEndDate, new AA(Properties.Resources.RequireMPSEndDate, this.dateMPSEndDate));
            this.invalidValueExceptions.Add(Model.MPSheader.PRO_Id, new AA(Properties.Resources.EntityExists, this.textMPSheaderId));
            this.action = "view";
            this.newChooseEmployee1.Choose = new ChooseEmployee();
            this.newChooseEmployee0.Choose = new ChooseEmployee();
            this.newChooseContorlCustomer.Choose = new Settings.BasicData.Customs.ChooseCustoms();
            this.EmpAudit.Choose = new ChooseEmployee();

        }

        public EditForm(Model.MPSheader mpsheader)
            : this()
        {
            this.mpsheader = mpsheader;
            this.mpsheader.Details = this.mpsdetailManager.Select(mpsheader);
            this.action = "update";
        }

        public EditForm(Model.MPSheader mpsheader, string action)
            : this()
        {
            this.mpsheader = mpsheader;
            this.mpsheader.Details = this.mpsdetailManager.Select(mpsheader);
            this.action = action;
        }

        public EditForm(List<Model.InvoiceXODetail> list)
            : this()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            this.AddNew();
            this.tag = 1;
            this.action = "insert";

            this.mpsheader.Details.Clear();
            this.mpsheader.InvoiceXOId = list[0].InvoiceId;
            //this.textEditPiHao.Text = list[0].Invoice.CustomerLotNumber;
            //this.textEditCustomerXOId.Text = list[0].Invoice.CustomerInvoiceXOId;
            //this.newChooseContorlCustomer.EditValue = list[0].Invoice.xocustomer;
            this.mpsheader.MPSEndDate = list[0].Invoice.InvoiceYjrq.Value;

            foreach (Model.InvoiceXODetail xodetail in list)
            {
                Model.MPSdetails mpsDetail = new Book.Model.MPSdetails();
                mpsDetail.MPSdetailsId = Guid.NewGuid().ToString();
                mpsDetail.Inumber = this.mpsheader.Details.Count + 1;
                mpsDetail.Product = xodetail.Product;
                mpsDetail.ProductId = xodetail.Product.ProductId;
                mpsDetail.ProductUnit = xodetail.InvoiceProductUnit;
                //考虑成品 库存,安全库存,已出货数量,
                //计划数量=订单数量-未出货数量-库存+安全库存
                xodetail.InvoiceMPSQuantity = xodetail.InvoiceMPSQuantity == null ? 0 : xodetail.InvoiceMPSQuantity;
                //double? quantity = xodetail.InvoiceXODetailQuantity - xodetail.InvoiceXODetailBeenQuantity;
                //if (quantity <= 0 || quantity - xodetail.InvoiceMPSQuantity - (xodetail.Product.StocksQuantity == null ? 0 : xodetail.Product.StocksQuantity) + (xodetail.Product.SafeStock == null ? 0 : xodetail.Product.SafeStock) <= 0)
                //    mpsDetail.MPSdetailssum = 0;
                //else if (xodetail.Product.MpsStockQuantity != null && xodetail.Product.MpsStockQuantity != 0)
                //{
                //    quantity = quantity - xodetail.InvoiceMPSQuantity;
                //}
                //else
                //{
                //    quantity = quantity - xodetail.InvoiceMPSQuantity - (xodetail.Product.StocksQuantity == null ? 0 : xodetail.Product.StocksQuantity) + (xodetail.Product.SafeStock == null ? 0 : xodetail.Product.SafeStock);
                //}

                mpsDetail.MPSdetailssum = xodetail.InvoiceXODetailQuantity - xodetail.InvoiceMPSQuantity;//quantity;
                mpsDetail.InvoiceXODetailSum = xodetail.InvoiceXODetailQuantity;
                //轉換單位
                if (!string.IsNullOrEmpty(mpsDetail.ProductUnit))
                {
                    mpsDetail.ProductStock = this.productUnitManager.ConvertUnit(xodetail.Product.BasedUnitGroupId, xodetail.Product.DepotUnit == null ? "" : xodetail.Product.DepotUnit.CnName, mpsDetail.ProductUnit, xodetail.Product.StocksQuantity.HasValue ? xodetail.Product.StocksQuantity.Value : 0);
                }
                //xodetail.Product.StocksQuantity == null ? 0 : xodetail.Product.StocksQuantity;
                mpsDetail.MPSdetailsdes = string.Empty;
                mpsDetail.MPSheader = this.mpsheader;
                mpsDetail.MPSheaderId = this.mpsheader.MPSheaderId;
                mpsDetail.InvoiceXOId = xodetail.InvoiceId;
                mpsDetail.Customer = xodetail.Invoice.Customer;
                mpsDetail.CustomerInvoiceXOId = xodetail.Invoice.CustomerInvoiceXOId;
                mpsDetail.CustomerId = xodetail.Invoice.Customer.CustomerId;
                mpsDetail.InvoiceXODetailId = xodetail.InvoiceXODetailId;

                //if (this.mpsheader == null)
                // mpsheader = new Book.Model.MPSheader();
                this.mpsheader.Details.Add(mpsDetail);
            }
            this.gridControl1.RefreshDataSource();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }

        protected override void Save()
        {
            //this.mpsheader.MPSheaderState = this.textMPSheaderState.Text;
            this.mpsheader.Id = this.textMPSheaderId.Text;
            // this.mpsheader.MPSheaderName = this.textMPSheaderName.Text;
            this.mpsheader.InvoiceXOId = this.textEditXOId.Text;
            if (global::Helper.DateTimeParse.DateTimeEquls(this.dateMPSStartDate.DateTime, new DateTime()))
            {
                this.mpsheader.MPSStartDate = null;
            }
            else
            {
                this.mpsheader.MPSStartDate = this.dateMPSStartDate.DateTime;
            }
            if (global::Helper.DateTimeParse.DateTimeEquls(this.dateMPSEndDate.DateTime, new DateTime()))
            {
                this.mpsheader.MPSEndDate = global::Helper.DateTimeParse.EndDate;
            }
            else
            {
                this.mpsheader.MPSEndDate = this.dateMPSEndDate.DateTime;
            }

            this.mpsheader.MPSheaderDesc = this.textMPSheaderDesc.Text;

            this.mpsheader.Employee0 = (this.newChooseEmployee0.EditValue as Model.Employee);
            this.mpsheader.Employee1 = (this.newChooseEmployee1.EditValue as Model.Employee);

            if (this.mpsheader.Employee0 != null)
            {
                this.mpsheader.Employee0Id = this.mpsheader.Employee0.EmployeeId;
            }
            if (this.mpsheader.Employee1 != null)
            {
                this.mpsheader.Employee1Id = this.mpsheader.Employee1.EmployeeId;
            }
            this.mpsheader.AuditState = this.saveAuditState;

            if (!this.gridView1.PostEditor() || !this.gridView1.UpdateCurrentRow())
                return;

            switch (this.action)
            {
                case "insert":
                    this.mpsheaderManager.Insert(this.mpsheader);
                    break;

                case "update":
                    this.mpsheaderManager.Update(this.mpsheader);
                    break;
            }

            flag = 1;
            //TreeLoad();
            this.DialogResult = DialogResult.OK;
        }

        protected override void Delete()
        {
            if (this.mpsheader == null)
                return;
            if (MessageBox.Show(Properties.Resources.ConfirmToDelete, this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            // try
            //{
            this.mpsheaderManager.Delete(this.mpsheader);
            this.mpsheader = this.mpsheaderManager.GetNext(this.mpsheader);
            if (this.mpsheader == null)
            {
                this.mpsheader = this.mpsheaderManager.GetLast();
            }
            // TreeLoad();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.ListSourceRowIndex < 0) return;
            IList<Model.MPSdetails> details = this.bindingSourceDetails.DataSource as IList<Model.MPSdetails>;
            if (details == null || details.Count < 1) return;
            Model.Product detail = details[e.ListSourceRowIndex].Product;
            if (detail == null) return;
            switch (e.Column.Name)
            {
                case "ColProductId":
                    e.DisplayText = detail.Id;
                    break;
                case "ColCustomProduct":
                    e.DisplayText = detail.CustomerProductName;
                    break;

            }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (this.action == "insert" || this.action == "update")
            {
                if (this.gridView1.FocusedColumn.Name == "gridColumnProductUnit")
                {

                    if (this.gridView1.FocusedColumn.ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemComboBox)
                    {
                        Model.Product p = (this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as Model.MPSdetails).Product;

                        this.repositoryItemComboBox1.Items.Clear();
                        if (p != null)
                        {
                            if (!string.IsNullOrEmpty(p.BasedUnitGroupId))
                            {
                                BL.ProductUnitManager manager = new Book.BL.ProductUnitManager();
                                IList<Model.ProductUnit> unitList = manager.Select(p.BasedUnitGroup);
                                foreach (Model.ProductUnit item in unitList)
                                {
                                    this.repositoryItemComboBox1.Items.Add(item.CnName);
                                }

                            }
                        }

                    }
                }
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == this.ColProductId || e.Column == this.ColCustomProduct || e.Column == this.ColProduct)
            {
                Model.MPSdetails detail = this.gridView1.GetRow(e.RowHandle) as Model.MPSdetails;
                if (detail != null)
                {
                    Model.Product p = productManager.Get(e.Value.ToString());
                    detail.MPSdetailsId = Guid.NewGuid().ToString();
                    detail.MPSdetailsdes = "";
                    detail.MPSdetailssum = 0;
                    detail.Product = p;
                    detail.ProductId = p.ProductId;
                    if (p.MainUnit != null)
                        detail.ProductUnit = p.MainUnit.CnName;
                    detail.CustomerId = null;
                    detail.InvoiceXOId = null;
                    detail.ProductStock = p.StocksQuantity;
                    detail.ProductSpecification = p.IsCustomerProduct != null && p.IsCustomerProduct.Value ? this.productManager.Get(p.CustomerBeforeProductId).ProductSpecification : p.ProductSpecification;
                    detail.InvoiceXODetailId = "";
                    detail.InvoiceXODetailSum = 0;
                    detail.CustomerInvoiceXOId = "";
                    detail.Customer = null;
                    this.bindingSourceDetails.Position = this.bindingSourceDetails.IndexOf(detail);
                }
                this.gridControl1.RefreshDataSource();
            }
            if (e.Column == this.gridColumnProductUnit)
            {
                Model.MPSdetails detail = this.gridView1.GetRow(e.RowHandle) as Model.MPSdetails;
                if (detail != null)
                {
                    detail.ProductStock = this.productUnitManager.ConvertUnit(detail.Product.BasedUnitGroupId, detail.Product.DepotUnit == null ? "" : detail.Product.DepotUnit.CnName, e.Value.ToString(), detail.Product.StocksQuantity.HasValue ? detail.Product.StocksQuantity.Value : 0);
                    this.bindingSourceDetails.Position = this.bindingSourceDetails.IndexOf(detail);
                }
                this.gridControl1.RefreshDataSource();
            }
        }

        protected override DevExpress.XtraReports.UI.XtraReport GetReport()
        {
            return new RO1(mpsheader.MPSheaderId);
        }

        public override void Refresh()
        {

            ///
            flag = 0;
            if (this.mpsheader == null)
            {
                this.AddNew();
                this.action = "insert";
            }
            else
            {
                if (this.action == "view")
                {
                    this.mpsheader = this.mpsheaderManager.GetDetails(mpsheader.MPSheaderId);
                    if (this.mpsheader == null)
                    {
                        this.AddNew();
                        this.action = "insert";
                    }
                }

            }
            if (this.mpsheader.IsBuildMRP == true && this.action == "update")
            {
                this.action = "view";
                MessageBox.Show("已經生成物料需求，不能修改！", this.Text, MessageBoxButtons.OK);
            }
            this.textMPSheaderId.Text = this.mpsheader.MPSheaderId;
            //this.textMPSheaderName.Text = this.mpsheader.MPSheaderName;
            this.textMPSheaderDesc.Text = this.mpsheader.MPSheaderDesc;
            if (!string.IsNullOrEmpty(this.mpsheader.InvoiceXOId))
            {
                Model.InvoiceXO invoiceXO = this.invoiceXOManager.Get(this.mpsheader.InvoiceXOId);
                if (invoiceXO != null)
                {
                    this.textEditXOId.Text = invoiceXO.InvoiceId;
                    this.textEditCustomerXOId.Text = invoiceXO.CustomerInvoiceXOId;
                    this.newChooseContorlCustomer.EditValue = invoiceXO.xocustomer;
                    this.textEditPiHao.Text = invoiceXO.CustomerLotNumber;
                }
                else
                {
                    this.textEditXOId.Text = string.Empty;
                    this.textEditCustomerXOId.Text = string.Empty;
                    this.newChooseContorlCustomer.EditValue = null;
                    this.textEditPiHao.Text = string.Empty;
                }
            }
            else
            {
                this.textEditXOId.Text = string.Empty;
                this.textEditCustomerXOId.Text = string.Empty;
                this.newChooseContorlCustomer.EditValue = null;
                this.textEditPiHao.Text = string.Empty;
            }
            if (global::Helper.DateTimeParse.DateTimeEquls(this.mpsheader.MPSStartDate, global::Helper.DateTimeParse.NullDate))
            {
                this.dateMPSStartDate.EditValue = null;
            }
            else
            {
                this.dateMPSStartDate.EditValue = this.mpsheader.MPSStartDate;
            }
            if (global::Helper.DateTimeParse.DateTimeEquls(this.mpsheader.MPSEndDate, global::Helper.DateTimeParse.NullDate))
            {
                this.dateMPSEndDate.EditValue = null;
            }
            else
            {
                this.dateMPSEndDate.EditValue = this.mpsheader.MPSEndDate;
            }
            this.newChooseEmployee0.EditValue = this.mpsheader.Employee0;
            this.newChooseEmployee1.EditValue = this.mpsheader.Employee1;

            this.EmpAudit.EditValue = this.mpsheader.AuditEmp;
            this.textEditAuditState.Text = this.GetAuditName(this.mpsheader.AuditState);

            this.bindingSourceDetails.DataSource = this.mpsheader.Details;

            switch (this.action)
            {
                case "insert":
                    this.textMPSheaderId.Properties.ReadOnly = false;
                    //this.textMPSheaderName.Properties.ReadOnly = false;

                    this.textMPSheaderDesc.Properties.ReadOnly = false;


                    this.dateMPSStartDate.Properties.ReadOnly = false;
                    this.dateMPSEndDate.Properties.ReadOnly = false;

                    this.newChooseEmployee1.ButtonReadOnly = false;
                    this.newChooseEmployee1.ShowButton = true;

                    this.newChooseEmployee0.ButtonReadOnly = false;
                    this.newChooseEmployee0.ShowButton = true;
                    this.gridView1.OptionsBehavior.Editable = true;

                    this.repositoryItemComboBox1.ReadOnly = false;


                    this.simpleButton1.Enabled = true;
                    this.simpleButton2.Enabled = true;
                    this.simpleButtonXO.Enabled = true;
                    break;

                case "update":
                    this.textMPSheaderId.Properties.ReadOnly = false;
                    // this.textMPSheaderName.Properties.ReadOnly = false;

                    this.textMPSheaderDesc.Properties.ReadOnly = false;


                    this.dateMPSStartDate.Properties.ReadOnly = false;
                    this.dateMPSEndDate.Properties.ReadOnly = false;

                    this.newChooseEmployee1.ButtonReadOnly = false;
                    this.newChooseEmployee1.ShowButton = true;

                    this.newChooseEmployee0.ButtonReadOnly = false;
                    this.newChooseEmployee0.ShowButton = true;
                    this.gridView1.OptionsBehavior.Editable = true;

                    this.repositoryItemComboBox1.ReadOnly = false;

                    this.simpleButton1.Enabled = true;
                    this.simpleButton2.Enabled = true;
                    this.simpleButtonXO.Enabled = true;
                    break;

                case "view":
                    this.textMPSheaderId.Properties.ReadOnly = true;
                    // this.textMPSheaderName.Properties.ReadOnly = true;

                    this.textMPSheaderDesc.Properties.ReadOnly = true;


                    this.dateMPSStartDate.Properties.ReadOnly = true;
                    this.dateMPSEndDate.Properties.ReadOnly = true;

                    this.newChooseEmployee1.ButtonReadOnly = true;
                    this.newChooseEmployee1.ShowButton = false;

                    this.newChooseEmployee0.ButtonReadOnly = true;
                    this.newChooseEmployee0.ShowButton = false;

                    this.gridView1.OptionsBehavior.Editable = false;


                    this.simpleButton1.Enabled = false;
                    this.simpleButton2.Enabled = false;
                    this.simpleButtonXO.Enabled = false;
                    break;

                default:
                    break;
            }

            base.Refresh();
            if (this.mpsheader.IsBuildMRP == true || this.action != "view")
            {
                this.simpleButton3.Enabled = false;
            }
            else
                this.simpleButton3.Enabled = true;

            this.textMPSheaderId.Properties.ReadOnly = true;
        }

        protected override void MoveNext()
        {
            Model.MPSheader mpsheader = this.mpsheaderManager.GetNext(this.mpsheader);
            if (mpsheader == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);
            this.mpsheader = this.mpsheaderManager.Get(mpsheader.MPSheaderId);
        }

        protected override void MovePrev()
        {
            Model.MPSheader mpsheader = this.mpsheaderManager.GetPrev(this.mpsheader);
            if (mpsheader == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);
            this.mpsheader = this.mpsheaderManager.Get(mpsheader.MPSheaderId);
        }

        protected override void MoveFirst()
        {
            this.mpsheader = this.mpsheaderManager.Get(this.mpsheaderManager.GetFirst() == null ? "" : this.mpsheaderManager.GetFirst().MPSheaderId);
        }

        protected override bool SetColumnNumber()
        {
            return true;
        }

        protected override void MoveLast()
        {
            //if (mpsheader == null)
            {
                this.mpsheader = this.mpsheaderManager.Get(this.mpsheaderManager.GetLast() == null ? "" : this.mpsheaderManager.GetLast().MPSheaderId);
            }
        }

        protected override bool HasRows()
        {
            return this.mpsheaderManager.HasRows();
        }

        protected override bool HasRowsNext()
        {
            return this.mpsheaderManager.HasRowsAfter(this.mpsheader);
        }

        protected override bool HasRowsPrev()
        {
            return this.mpsheaderManager.HasRowsBefore(this.mpsheader);
        }

        protected override void AddNew()
        {
            //  _iXOs.Clear();
            if (this.tag == 1)
            {
                tag = 0;
                return;
            }
            this.mpsheader = new Model.MPSheader();
            this.mpsheader.MPSheaderId = this.mpsheaderManager.GetId();//  Guid.NewGuid().ToString();
            this.mpsheader.Employee0 = BL.V.ActiveOperator.Employee;
            this.mpsheader.MPSStartDate = DateTime.Now;
            this.mpsheader.Details = new List<Model.MPSdetails>();
            //if (this.action == "insert")
            //{
            //    Model.MPSdetails detail = new Model.MPSdetails();
            //    detail.MPSdetailsId = Guid.NewGuid().ToString();
            //    detail.MPSdetailssum = 0;
            //    detail.MPSdetailsdes = "";
            //    detail.ProductUnit = "";

            //    detail.Product = new Book.Model.Product();

            //    this.mpsheader.Details.Add(detail);
            //    this.bindingSourceDetails.Position = this.bindingSourceDetails.IndexOf(detail);
            //}
        }

        //“+”
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ChooseProductForm f = new ChooseProductForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                Model.Product product = f.SelectedItem as Model.Product;
                Model.MPSdetails detail = new Book.Model.MPSdetails();
                detail.MPSdetailsId = Guid.NewGuid().ToString();
                detail.Inumber = this.mpsheader.Details.Count + 1;
                detail.Product = f.SelectedItem as Model.Product;
                detail.ProductId = (f.SelectedItem as Model.Product).ProductId;
                detail.ProductUnit = detail.Product.DepotUnit == null ? null : detail.Product.DepotUnit.CnName;
                //單位轉換
                detail.ProductStock = (f.SelectedItem as Model.Product).StocksQuantity;
                detail.MPSdetailssum = 0;
                detail.MPSdetailsdes = "";
                detail.ProductSpecification = "";
                this.mpsheader.Details.Add(detail);
                this.bindingSourceDetails.Position = this.bindingSourceDetails.IndexOf(detail);
                this.gridControl1.RefreshDataSource();

            }
        }

        //“-”
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.bindingSourceDetails.Current != null)
            {
                Model.MPSdetails a = this.bindingSourceDetails.Current as Book.Model.MPSdetails;
                this.mpsheader.Details.Remove(this.bindingSourceDetails.Current as Book.Model.MPSdetails);
                if (a != null)
                {
                    Model.InvoiceXO iXO = new BL.InvoiceXOManager().GetById(a.InvoiceXOId);
                    //_iXOs.Remove(iXO);
                }
                if (this.mpsheader.Details.Count == 0)
                {
                    Model.MPSdetails detail = new Model.MPSdetails();
                    detail.MPSdetailsId = Guid.NewGuid().ToString();
                    detail.MPSdetailsdes = "";
                    detail.MPSdetailssum = 0;
                    detail.ProductUnit = "";
                    detail.ProductSpecification = "";
                    detail.Product = new Book.Model.Product();
                    this.mpsheader.Details.Add(detail);
                    this.bindingSourceDetails.Position = this.bindingSourceDetails.IndexOf(detail);
                }

                this.gridControl1.RefreshDataSource();
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        //选择销售订单 
        private void simpleButtonXO_Click(object sender, EventArgs e)
        {
            createProduce.EditForm f = new Book.UI.produceManager.createProduce.EditForm("mps");
            if (f.ShowDialog(this) != DialogResult.OK) return;
            if (f.SelectList == null || f.SelectList.Count == 0) return;
            this.mpsheader.Details.Clear();
            this.textEditXOId.Text = f.SelectList[0].InvoiceId;
            this.textEditPiHao.Text = f.SelectList[0].Invoice.CustomerLotNumber;
            this.textEditCustomerXOId.Text = f.SelectList[0].Invoice.CustomerInvoiceXOId;
            this.dateMPSEndDate.DateTime = f.SelectList[0].Invoice.InvoiceYjrq.Value;
            this.newChooseContorlCustomer.EditValue = f.SelectList[0].Invoice.xocustomer;
            foreach (Model.InvoiceXODetail xodetail in f.SelectList)
            {
                Model.MPSdetails mpsDetail = new Book.Model.MPSdetails();
                mpsDetail.MPSdetailsId = Guid.NewGuid().ToString();
                mpsDetail.Inumber = this.mpsheader.Details.Count + 1;
                mpsDetail.Product = xodetail.Product;
                mpsDetail.ProductId = xodetail.Product.ProductId;
                mpsDetail.ProductUnit = xodetail.InvoiceProductUnit;
                //考虑成品 库存,安全库存,已出货数量,
                //计划数量=订单数量-未出货数量-库存+安全库存
                xodetail.InvoiceMPSQuantity = xodetail.InvoiceMPSQuantity == null ? 0 : xodetail.InvoiceMPSQuantity;
                //double? quantity = xodetail.InvoiceXODetailQuantity - xodetail.InvoiceXODetailBeenQuantity;
                //if (quantity <= 0 || quantity - xodetail.InvoiceMPSQuantity - (xodetail.Product.StocksQuantity == null ? 0 : xodetail.Product.StocksQuantity) + (xodetail.Product.SafeStock == null ? 0 : xodetail.Product.SafeStock) <= 0)
                //    mpsDetail.MPSdetailssum = 0;
                //else if (xodetail.Product.MpsStockQuantity != null && xodetail.Product.MpsStockQuantity != 0)
                //{
                //    quantity = quantity - xodetail.InvoiceMPSQuantity;
                //}
                //else
                //{
                //    quantity = quantity - xodetail.InvoiceMPSQuantity - (xodetail.Product.StocksQuantity == null ? 0 : xodetail.Product.StocksQuantity) + (xodetail.Product.SafeStock == null ? 0 : xodetail.Product.SafeStock);
                //}

                mpsDetail.MPSdetailssum = xodetail.InvoiceXODetailQuantity - xodetail.InvoiceMPSQuantity;//quantity;
                mpsDetail.InvoiceXODetailSum = xodetail.InvoiceXODetailQuantity;
                if (mpsDetail.MPSdetailssum > mpsDetail.InvoiceXODetailSum)
                    mpsDetail.MPSdetailssum = mpsDetail.InvoiceXODetailSum;
                //轉換單位
                if (!string.IsNullOrEmpty(mpsDetail.ProductUnit))
                {
                    mpsDetail.ProductStock = this.productUnitManager.ConvertUnit(xodetail.Product.BasedUnitGroupId, xodetail.Product.DepotUnit == null ? "" : xodetail.Product.DepotUnit.CnName, mpsDetail.ProductUnit, xodetail.Product.StocksQuantity.HasValue ? xodetail.Product.StocksQuantity.Value : 0);
                }
                //xodetail.Product.StocksQuantity == null ? 0 : xodetail.Product.StocksQuantity;
                mpsDetail.MPSdetailsdes = string.Empty;
                mpsDetail.MPSheader = this.mpsheader;
                mpsDetail.MPSheaderId = this.mpsheader.MPSheaderId;
                mpsDetail.InvoiceXOId = xodetail.InvoiceId;
                mpsDetail.Customer = xodetail.Invoice.Customer;
                mpsDetail.CustomerInvoiceXOId = xodetail.Invoice.CustomerInvoiceXOId;
                mpsDetail.CustomerId = xodetail.Invoice.Customer.CustomerId;
                mpsDetail.InvoiceXODetailId = xodetail.InvoiceXODetailId;

                //if (this.mpsheader == null)
                // mpsheader = new Book.Model.MPSheader();
                this.mpsheader.Details.Add(mpsDetail);
            }
            this.gridControl1.RefreshDataSource();

        }

        private void EditForm_Load_1(object sender, EventArgs e)
        {

            //string sql = "SELECT productid,id,productname,CustomerProductName FROM product";
            //this.bindingSourceProductId.DataSource = this.productManager.DataReaderBind<Model.Product>(sql, null, CommandType.Text);
            // this.bindingSourceProductId.DataSource = productManager.GetProduct();
            //TreeLoad();
        }

        /// <summary>
        /// 加载tree
        /// </summary>

        //protected void TreeLoad()
        //{
        //    this.treeList1.ClearNodes();
        //    foreach (Model.MPSheader mps in mpsheaderManager.Select())
        //    {

        //        DevExpress.XtraTreeList.Nodes.TreeListNode treeNode = treeList1.AppendNode(new object[] { mps.MPSheaderId }, null, mps.MPSheaderId);


        //        foreach (Model.MPSdetails mPSdetails in mpsdetailManager.Select(mps))
        //        {

        //            treeList1.AppendNode(new object[] { mPSdetails.Product.ProductName }, treeNode, mPSdetails.Product.ProductId);

        //        }


        //    }
        //}

        /// <summary>
        /// 光标改变节点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        //{
        //    if (flag == 0)
        //    {
        //        if (e.Node != null && e.Node.ParentNode == null)
        //        {
        //            this.mpsheader = mpsheaderManager.Get(e.Node.Tag.ToString());
        //            this.action = "view";
        //            this.Refresh();
        //        }
        //    }
        //}

        private void dateMPSEndDate_TextChanged(object sender, EventArgs e)
        {
            if (dateMPSStartDate.DateTime > dateMPSEndDate.DateTime)
                dateMPSEndDate.DateTime = dateMPSStartDate.DateTime;
        }

        //计算物料需求
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                AddMRP();
                this.mpsheader.IsBuildMRP = true;
                this.simpleButton3.Enabled = false;
                this.mpsheaderManager.UpdateMPS(this.mpsheader);

                MessageBox.Show("計算完畢", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }

        //集合
        Model.BomParentPartInfo _bomparent = new Book.Model.BomParentPartInfo();
        IList<Model.BomComponentInfo> _comDetailss = new List<Model.BomComponentInfo>();
        IList<Model.BomComponentInfo> _comDetails = new List<Model.BomComponentInfo>();

        //绑定 计划数量 考虑订单数量 +安全库存数量 -当前库存-改单据已出货数量
        public void AddMRP()
        {
            IList<Model.BomComponentInfo> bomComponentInfo1 = new List<Model.BomComponentInfo>();
            IList<Model.BomComponentInfo> bomComponentInfo2 = new List<Model.BomComponentInfo>();
            IList<Model.BomComponentInfo> bomComponentInfo3 = new List<Model.BomComponentInfo>();
            IList<Model.BomComponentInfo> bomComponentInfo5 = new List<Model.BomComponentInfo>();
            IList<Model.BomComponentInfo> bomComponentInfo6 = new List<Model.BomComponentInfo>();
            IList<Model.BomComponentInfo> bomComponentInfo7 = new List<Model.BomComponentInfo>();
            string mrpid1 = null;
            IList<Model.BomComponentInfo> comDetailss4 = new List<Model.BomComponentInfo>();
            Model.BomComponentInfo comm4;
            foreach (Model.MPSdetails details in this.mpsheader.Details)
            {
                if (this.BomparentManager.Get(this.productManager.Get(details.ProductId)) == null)
                    throw new Exception("商品 " + (details.Product == null ? "" : details.Product.ToString()) + " 未建立BOM單，生成失敗！");
            }
            foreach (Model.MPSdetails details in this.mpsheader.Details)
            {
                this._comDetailss.Clear();
                this._bomparent = this.BomparentManager.Get(this.productManager.Get(details.ProductId));

                //添加成品
                comm4 = new Model.BomComponentInfo();
                comm4.MPSdetailsId = details.MPSdetailsId;
                comm4.ProductId = details.ProductId;
                comm4.MadeProductId = details.ProductId;
                comm4.MpsQuantity = details.MPSdetailssum;
                comm4.MrpQuantity = details.MPSdetailssum;
                comm4.Unit = details.ProductUnit;
                comm4.Customer = details.Customer;
                comm4.MPSdetailsId = details.MPSdetailsId;
                comm4.MPSdetailsId = details.MPSdetailsId;
                comm4.MPSdetailsId = details.MPSdetailsId;
                comDetailss4.Add(comm4);
                ////Model.BomComponentInfo com = new Book.Model.BomComponentInfo();
                ////com.Customer = details.Customer;
                ////com.UseQuantity = 1;
                ////com.MrpQuantity = details.MPSdetailssum;// details.InvoiceXODetailSum;
                ////com.MpsQuantity = details.MPSdetailssum;
                ////if (com.MrpQuantity <= 0)
                ////{
                ////    com.MrpQuantity = 0;
                ////    //continue;
                ////}
                ////com.Unit = details.ProductUnit;
                ////com.Product = details.Product;
                ////com.ProductId = details.ProductId;
                ////com.MPSdetailsId = details.MPSdetailsId;
                ////this._comDetailss.Add(com);

                //包装材料 作为 外购
                foreach (Model.BomPackageDetails bompackage in this.bomPackageDetailsManager.Select(this._bomparent.BomId))
                {
                    Model.BomComponentInfo component = new Book.Model.BomComponentInfo();
                    component.Customer = details.Customer;
                    component.UseQuantity = bompackage.Quantity;
                    //string b = "";
                    //double? a = 0;
                    //if (details.MPSdetailssum % bompackage.UseQuantity != 0)
                    //{
                    //    b = (details.MPSdetailssum / bompackage.UseQuantity + 1).ToString();
                    //    a = double.Parse(b.Substring(0, b.IndexOf('.') < 0 ? b.Length : b.Length - b.IndexOf('.') - 1));
                    //}
                    //else
                    //    a = details.MPSdetailssum / bompackage.UseQuantity;

                    component.MpsQuantity = details.MPSdetailssum * bompackage.Quantity;
                    component.MrpQuantity = details.MPSdetailssum * bompackage.Quantity - (bompackage.Product.StocksQuantity == null ? 0 : bompackage.Product.StocksQuantity - (bompackage.Product.MRSStockQuantity == null ? 0 : bompackage.Product.MRSStockQuantity)) + bompackage.Product.SafeStock;
                    if (component.MrpQuantity <= 0)
                    {
                        component.MrpQuantity = 0;
                        //continue;
                    }
                    component.Unit = bompackage.PackageUnit;
                    component.Product = bompackage.Product;
                    component.ProductId = bompackage.ProductId;
                    component.MPSdetailsId = details.MPSdetailsId;
                    component.NextWorkHouseId = bompackage.NextWorkHouseId;
                    component.BomComponentInfoDesc = "包裝材料";
                    this._comDetailss.Add(component);
                }
                foreach (Model.BomComponentInfo comm in this.bomComponentinfoManager.Select(_bomparent))
                {
                    comm.MPSdetailsId = details.MPSdetailsId;
                    comm.BeforepPackageProductId = comm.ProductId;
                    this._comDetailss.Add(comm);
                }

                if (this._comDetailss.Count != 0)
                {
                    foreach (Model.BomComponentInfo bom in this._comDetailss)
                    {
                        bom.UseQuantity = bom.UseQuantity * (1 + 0.01 * (bom.SubLoseRate == null ? 0 : bom.SubLoseRate.Value));
                        bom.MpsQuantity = bom.UseQuantity * details.MPSdetailssum;
                        bom.MrpQuantity = bom.UseQuantity * details.MPSdetailssum - (bom.Product.StocksQuantity == null ? 0 : bom.Product.StocksQuantity - (bom.Product.MRSStockQuantity == null ? 0 : bom.Product.MRSStockQuantity)) + (bom.Product.SafeStock == null ? 0 : bom.Product.SafeStock);
                        bom.Customer = details.Customer;
                        //bom.Unit = _comDetailss[i].Unit;                   
                    }
                    IList<Model.BomComponentInfo> a = null;
                    //   string strlenth = "";
                    Model.BomComponentInfo _bomcom = new Book.Model.BomComponentInfo();
                    for (int i = 0; i < this._comDetailss.Count; i++)
                    // foreach(Model.BomComponentInfo com in this._bomcomDetail)
                    {
                        //在物料中查询 是否 存在此子件
                        this._bomparent = this.BomparentManager.Get(_comDetailss[i].Product);
                        if (this._bomparent != null)
                        {
                            a = this.bomComponentinfoManager.Select(this._bomparent);
                            foreach (Model.BomComponentInfo bom in a)
                            {
                                //bom.Jibie = _comDetailss[i].Jibie + 1;
                                //_comDetailss[i].UseQuantity *                         
                                //考虑损耗率
                                bom.BeforepPackageProductId = _comDetailss[i].BeforepPackageProductId;
                                bom.UseQuantity = bom.UseQuantity * (1 + 0.01 * (bom.SubLoseRate == null ? 0 : bom.SubLoseRate.Value));
                                bom.MpsQuantity = _comDetailss[i].MpsQuantity * bom.UseQuantity;
                                //考虑在制品库存
                                double? mrpQuantity = 0;
                                if (_comDetailss[i].MrpQuantity != 0)
                                {
                                    // mrpQuantity = (_comDetailss[i].MrpQuantity - sum) * bom.UseQuantity;
                                    mrpQuantity = (_comDetailss[i].MrpQuantity) * bom.UseQuantity;
                                    if (this.checkEditIsAdvisementSafetyStock.Checked && this.checkEditIsAdvisementOnWay.Checked)
                                    {
                                        bom.MrpQuantity = mrpQuantity - (bom.Product.StocksQuantity == null ? 0 : bom.Product.StocksQuantity - (bom.Product.MRSStockQuantity == null ? 0 : bom.Product.MRSStockQuantity)) + (bom.Product.SafeStock == null ? 0 : bom.Product.SafeStock);// -bom.Product.OrderOnWayQuantity;
                                    }
                                    else
                                    {
                                        if (this.checkEditIsAdvisementOnWay.Checked)
                                            bom.MrpQuantity = mrpQuantity - (bom.Product.StocksQuantity == null ? 0 : bom.Product.StocksQuantity - (bom.Product.MRSStockQuantity == null ? 0 : bom.Product.MRSStockQuantity));//+ bom.Product.OrderOnWayQuantity;
                                        else if (this.checkEditIsAdvisementSafetyStock.Checked)
                                            bom.MrpQuantity = mrpQuantity - (bom.Product.StocksQuantity == null ? 0 : bom.Product.StocksQuantity - (bom.Product.MRSStockQuantity == null ? 0 : bom.Product.MRSStockQuantity)) + (bom.Product.SafeStock == null ? 0 : bom.Product.SafeStock);
                                        else
                                            bom.MrpQuantity = mrpQuantity - (bom.Product.StocksQuantity == null ? 0 : bom.Product.StocksQuantity - (bom.Product.MRSStockQuantity == null ? 0 : bom.Product.MRSStockQuantity));
                                    }
                                    if (bom.MrpQuantity <= 0)
                                    {
                                        bom.MrpQuantity = 0;
                                        ////continue;小于0不需要采购自制等 修改下面
                                    }
                                }
                                else
                                {
                                    bom.MrpQuantity = 0;

                                }
                                //// bom.Unit = _comDetailss[i].Unit;
                                bom.Customer = details.Customer;
                                bom.MPSdetailsId = details.MPSdetailsId;
                                this._comDetailss.Add(bom);
                            }
                            //foreach (Model.BomComponentInfo boms in _comDetails)
                            //{
                            //    this._comDetailss.Add(boms);
                            //}
                            //_comDetails.Clear();
                            a.Clear();
                        }
                    }
                }

                foreach (Model.BomComponentInfo bomcom in this._comDetailss)
                {
                    if (bomcom.Product.IsProcee == true)
                    {
                        bomcom.MadeProductId = details.ProductId;
                        if (bomcom.Product.HomeMade == true)
                            bomComponentInfo5.Add(bomcom);
                        else if (bomcom.Product.TrustOut == true)
                            bomComponentInfo6.Add(bomcom);
                        else if (bomcom.Product.IsDepot == true)
                            bomComponentInfo7.Add(bomcom);
                    }
                    else if (bomcom.Product.HomeMade == true)
                    {
                        bomcom.MadeProductId = details.ProductId;
                        bomComponentInfo1.Add(bomcom);
                    }
                    else if (bomcom.Product.OutSourcing == true)
                    {
                        bomcom.MadeProductId = details.ProductId;
                        bomComponentInfo2.Add(bomcom);
                    }
                    else if (bomcom.Product.TrustOut == true)
                    {
                        bomcom.MadeProductId = details.ProductId;
                        bomComponentInfo3.Add(bomcom);
                    }
                    else
                    {
                        bomcom.MadeProductId = details.ProductId;
                        bomComponentInfo1.Add(bomcom);
                    }

                }
            }

            Model.MRSHeader mRSHeader1;//自制
            Model.MRSdetails mRSdetails1;//自制
            Model.MRSHeader mRSHeader2;//外购
            Model.MRSdetails mRSdetails2;//外购
            Model.MRSHeader mRSHeader3;//委外
            Model.MRSdetails mRSdetails3;//委外
            Model.MRSHeader mRSHeader4;//组装     
            Model.MRSdetails mRSdetails4;//组装
            Model.MRSHeader mRSHeader5;//自製半成品加工     
            Model.MRSdetails mRSdetails5;//自製半成品加工     
            Model.MRSHeader mRSHeader6;//委外半成品加工     
            Model.MRSdetails mRSdetails6;//委外半成品加工   
            Model.MRSHeader mRSHeader7;//倉庫半成品加工     
            Model.MRSdetails mRSdetails7;//倉庫半成品加工   
            int InumerSum = 0;

            if (comDetailss4.Count > 0)
            {
                //if (mrpid1 == null)
                //{
                mrpid1 = this.mRSHeaderManager.GetId();
                mRSHeader4 = new Model.MRSHeader();
                mRSHeader4.MRSHeaderId = mrpid1;
                mRSHeader4.MPSheaderId = this.mpsheader.MPSheaderId;
                mRSHeader4.Employee0Id = this.mpsheader.Employee0Id;
                mRSHeader4.Employee1Id = this.mpsheader.Employee1Id;
                mRSHeader4.MRSstartdate = this.mpsheader.MPSStartDate;
                //mRSHeader1.Customer = bomComponentInfo1[0].Customer;
                //mRSHeader1.CustomerId = bomComponentInfo1[0].Customer == null ? null : bomComponentInfo1[0].Customer.CustomerId;

                mRSHeader4.SourceType = ((Int32)global::Helper.ProductType.Package).ToString();

                Audit(mRSHeader4);
                this.mRSHeaderManager.Insert(mRSHeader4);
                // }
                foreach (Model.BomComponentInfo bomcom in comDetailss4)
                {

                    //if (bomcom.MrpQuantity <= 0)
                    //{
                    //    bomcom.MrpQuantity = 0;
                    //    //continue;
                    //}
                    InumerSum += 1;
                    mRSdetails4 = new Book.Model.MRSdetails();
                    mRSdetails4.MRSdetailsId = Guid.NewGuid().ToString();
                    mRSdetails4.MRSdetailssum = bomcom.MpsQuantity;
                    mRSdetails4.MRSdetailsQuantity = bomcom.MpsQuantity;
                    mRSdetails4.MPSheaderId = this.mpsheader.MPSheaderId;
                    mRSdetails4.MPSdetailsId = bomcom.MPSdetailsId;
                    mRSdetails4.MRSHeaderId = mrpid1;
                    mRSdetails4.Product = bomcom.Product;
                    mRSdetails4.ProductId = bomcom.ProductId;
                    mRSdetails4.MadeProductId = mRSdetails4.ProductId;
                    mRSdetails4.ProductUnit = bomcom.Unit;
                    mRSdetails4.Customer = bomcom.Customer;
                    mRSdetails4.WorkHouseNextId = bomcom.NextWorkHouseId;
                    mRSdetails4.Inumber = InumerSum;
                    mRSdetails4.BeforePackageProductId = bomcom.BeforepPackageProductId;
                    mRSdetails4.MRSStockQuantity = mRSdetails4.Product == null ? 0 : mRSdetails4.Product.StocksQuantity;
                    if (mRSdetails4.Customer != null)
                        mRSdetails4.CustomerId = mRSdetails4.Customer.CustomerId;
                    //if (mRSdetails4.Product != null)
                    //    mRSdetails4.MRSdetailssum = mRSdetails4.MRSdetailsQuantity - (mRSdetails4.Product.StocksQuantity == null ? 0 : mRSdetails4.Product.StocksQuantity);
                    //else
                    mRSdetails4.MRSdetailssum = mRSdetails4.MRSdetailsQuantity;
                    if (mRSdetails4.MRSdetailssum == null || mRSdetails4.MRSdetailssum < 0)
                        mRSdetails4.MRSdetailssum = 0;
                    mRSdetails4.WorkHouseNextId = bomcom.NextWorkHouseId;
                    new BL.MRSdetailsManager().Insert(mRSdetails4);
                }

            }
            InumerSum = 0;
            if (bomComponentInfo5.Count > 0)
            {


                //if (mrpid1 == null)
                //{

                mrpid1 = this.mRSHeaderManager.GetId();
                mRSHeader5 = new Model.MRSHeader();
                mRSHeader5.MRSHeaderId = mrpid1;
                mRSHeader5.MPSheaderId = this.mpsheader.MPSheaderId;
                mRSHeader5.Employee0Id = this.mpsheader.Employee0Id;
                mRSHeader5.Employee1Id = this.mpsheader.Employee1Id;
                mRSHeader5.MRSstartdate = this.mpsheader.MPSStartDate;
                mRSHeader5.Customer = bomComponentInfo5[0].Customer;
                mRSHeader5.CustomerId = bomComponentInfo5[0].Customer == null ? null : bomComponentInfo5[0].Customer.CustomerId;

                mRSHeader5.SourceType = ((Int32)global::Helper.ProductType.HomeMadeProcee).ToString();
                Audit(mRSHeader5);
                this.mRSHeaderManager.Insert(mRSHeader5);
                //}

                var temp2 = from m in bomComponentInfo5
                            group m by new { m.ProductId, m.Unit } into g
                            select new
                            {
                                MrpQuantity = (from x in g select x.MrpQuantity).Sum(),
                                MpsQuantity = (from x in g select x.MpsQuantity).Sum(),
                                ProductId = g.Key.ProductId,
                                Product = g.Max(p => p.Product),
                                Unit = g.Key.Unit,
                                MPSdetailsId = g.Max(p => p.MPSdetailsId),
                                Customer = g.Max(p => p.Customer),
                                BomComponentInfoDesc = g.Max(p => p.BomComponentInfoDesc),
                                MadeProductId = g.First().MadeProductId,
                                BeforepPackageProductId = g.First().BeforepPackageProductId,
                                NextWorkHouseId = g.First().NextWorkHouseId
                            };

                foreach (var bomcom in temp2)
                {
                    //if (bomcom.MrpQuantity <= 0)
                    //{
                    //    bomcom.MrpQuantity = 0;
                    //    //continue;
                    //}
                    InumerSum += 1;
                    mRSdetails5 = new Book.Model.MRSdetails();
                    mRSdetails5.MRSdetailsId = Guid.NewGuid().ToString();
                    mRSdetails5.MRSHeaderId = mrpid1;
                    mRSdetails5.MRSdetailssum = bomcom.MpsQuantity < 0 ? 0 : double.Parse(bomcom.MpsQuantity.Value.ToString("f0"));
                    mRSdetails5.MRSdetailsQuantity = bomcom.MpsQuantity < 0 ? 0 : double.Parse(bomcom.MpsQuantity.Value.ToString("f0"));
                    mRSdetails5.MPSheaderId = this.mpsheader.MPSheaderId;
                    mRSdetails5.MPSdetailsId = bomcom.MPSdetailsId;
                    mRSdetails5.Product = bomcom.Product;
                    mRSdetails5.ProductId = bomcom.ProductId;
                    mRSdetails5.ProductUnit = bomcom.Unit;
                    mRSdetails5.Customer = bomcom.Customer;
                    mRSdetails5.MadeProductId = bomcom.MadeProductId;
                    mRSdetails5.MRSdetailsdes = bomcom.BomComponentInfoDesc;
                    mRSdetails5.WorkHouseNextId = bomcom.NextWorkHouseId;
                    mRSdetails5.BeforePackageProductId = bomcom.BeforepPackageProductId;
                    if (mRSdetails5.Customer != null)
                        mRSdetails5.CustomerId = mRSdetails5.Customer.CustomerId;
                    mRSdetails5.Inumber = InumerSum;
                    mRSdetails5.MRSStockQuantity = mRSdetails5.Product == null ? 0 : mRSdetails5.Product.StocksQuantity;
                    //if (mRSdetails5.Product != null)
                    //    mRSdetails5.MRSdetailssum = mRSdetails5.MRSdetailsQuantity - (mRSdetails5.Product.StocksQuantity == null ? 0 : mRSdetails5.Product.StocksQuantity);
                    //else
                    mRSdetails5.MRSdetailssum = mRSdetails5.MRSdetailsQuantity;
                    if (mRSdetails5.MRSdetailssum == null || mRSdetails5.MRSdetailssum < 0)
                        mRSdetails5.MRSdetailssum = 0;
                    mRSdetails5.WorkHouseNextId = bomcom.NextWorkHouseId;
                    new BL.MRSdetailsManager().Insert(mRSdetails5);
                }
            }
            InumerSum = 0;
            if (bomComponentInfo7.Count > 0)
            {
                mrpid1 = this.mRSHeaderManager.GetId();
                mRSHeader7 = new Model.MRSHeader();
                mRSHeader7.MRSHeaderId = mrpid1;
                mRSHeader7.MPSheaderId = this.mpsheader.MPSheaderId;
                mRSHeader7.Employee0Id = this.mpsheader.Employee0Id;
                mRSHeader7.Employee1Id = this.mpsheader.Employee1Id;
                mRSHeader7.MRSstartdate = this.mpsheader.MPSStartDate;
                mRSHeader7.Customer = bomComponentInfo7[0].Customer;
                mRSHeader7.CustomerId = bomComponentInfo7[0].Customer == null ? null : bomComponentInfo7[0].Customer.CustomerId;

                mRSHeader7.SourceType = ((Int32)global::Helper.ProductType.DepotMadeProcee).ToString();
                Audit(mRSHeader7);
                this.mRSHeaderManager.Insert(mRSHeader7);
                //}

                var temp2 = from m in bomComponentInfo7
                            group m by new { m.ProductId, m.Unit } into g
                            select new
                            {
                                MrpQuantity = (from x in g select x.MrpQuantity).Sum(),
                                MpsQuantity = (from x in g select x.MpsQuantity).Sum(),
                                ProductId = g.Key.ProductId,
                                Product = g.Max(p => p.Product),
                                Unit = g.Key.Unit,
                                MPSdetailsId = g.Max(p => p.MPSdetailsId),
                                Customer = g.Max(p => p.Customer),
                                BomComponentInfoDesc = g.Max(p => p.BomComponentInfoDesc),
                                MadeProductId = g.First().MadeProductId,
                                BeforepPackageProductId = g.First().BeforepPackageProductId,
                                NextWorkHouseId = g.First().NextWorkHouseId
                            };

                foreach (var bomcom in temp2)
                {
                    //if (bomcom.MrpQuantity <= 0)
                    //{
                    //    bomcom.MrpQuantity = 0;
                    //    //continue;
                    //}
                    InumerSum += 1;
                    mRSdetails7 = new Book.Model.MRSdetails();
                    mRSdetails7.MRSdetailsId = Guid.NewGuid().ToString();
                    mRSdetails7.MRSHeaderId = mrpid1;
                    mRSdetails7.MRSdetailssum = bomcom.MpsQuantity < 0 ? 0 : double.Parse(bomcom.MpsQuantity.Value.ToString("f0"));
                    mRSdetails7.MRSdetailsQuantity = bomcom.MpsQuantity < 0 ? 0 : double.Parse(bomcom.MpsQuantity.Value.ToString("f0"));
                    mRSdetails7.MPSheaderId = this.mpsheader.MPSheaderId;
                    mRSdetails7.MPSdetailsId = bomcom.MPSdetailsId;
                    mRSdetails7.Product = bomcom.Product;
                    mRSdetails7.ProductId = bomcom.ProductId;
                    mRSdetails7.ProductUnit = bomcom.Unit;
                    mRSdetails7.Customer = bomcom.Customer;
                    mRSdetails7.MadeProductId = bomcom.MadeProductId;
                    mRSdetails7.MRSdetailsdes = bomcom.BomComponentInfoDesc;
                    mRSdetails7.WorkHouseNextId = bomcom.NextWorkHouseId;
                    mRSdetails7.BeforePackageProductId = bomcom.BeforepPackageProductId;
                    if (mRSdetails7.Customer != null)
                        mRSdetails7.CustomerId = mRSdetails7.Customer.CustomerId;
                    mRSdetails7.Inumber = InumerSum;
                    mRSdetails7.MRSStockQuantity = mRSdetails7.Product == null ? 0 : mRSdetails7.Product.StocksQuantity;
                    //if (mRSdetails5.Product != null)
                    //    mRSdetails5.MRSdetailssum = mRSdetails5.MRSdetailsQuantity - (mRSdetails5.Product.StocksQuantity == null ? 0 : mRSdetails5.Product.StocksQuantity);
                    //else
                    mRSdetails7.MRSdetailssum = mRSdetails7.MRSdetailsQuantity;
                    if (mRSdetails7.MRSdetailssum == null || mRSdetails7.MRSdetailssum < 0)
                        mRSdetails7.MRSdetailssum = 0;
                    mRSdetails7.WorkHouseNextId = bomcom.NextWorkHouseId;
                    new BL.MRSdetailsManager().Insert(mRSdetails7);
                }
            }

            InumerSum = 0;
            if (bomComponentInfo6.Count > 0)
            {


                //if (mrpid1 == null)
                //{

                mrpid1 = this.mRSHeaderManager.GetId();
                mRSHeader6 = new Model.MRSHeader();
                mRSHeader6.MRSHeaderId = mrpid1;
                mRSHeader6.MPSheaderId = this.mpsheader.MPSheaderId;
                mRSHeader6.Employee0Id = this.mpsheader.Employee0Id;
                mRSHeader6.Employee1Id = this.mpsheader.Employee1Id;
                mRSHeader6.MRSstartdate = this.mpsheader.MPSStartDate;
                mRSHeader6.Customer = bomComponentInfo6[0].Customer;
                mRSHeader6.CustomerId = bomComponentInfo6[0].Customer == null ? null : bomComponentInfo6[0].Customer.CustomerId;

                mRSHeader6.SourceType = ((Int32)global::Helper.ProductType.TrustOutProcee).ToString();
                Audit(mRSHeader6);
                this.mRSHeaderManager.Insert(mRSHeader6);
                //}

                var temp2 = from m in bomComponentInfo6
                            group m by new { m.ProductId, m.Unit } into g
                            select new
                            {
                                MrpQuantity = (from x in g select x.MrpQuantity).Sum(),
                                MpsQuantity = (from x in g select x.MpsQuantity).Sum(),
                                ProductId = g.Key.ProductId,
                                Product = g.Max(p => p.Product),
                                Unit = g.Key.Unit,
                                MPSdetailsId = g.Max(p => p.MPSdetailsId),
                                Customer = g.Max(p => p.Customer),
                                BomComponentInfoDesc = g.Max(p => p.BomComponentInfoDesc),
                                MadeProductId = g.First().MadeProductId,
                                BeforepPackageProductId = g.First().BeforepPackageProductId,
                                NextWorkHouseId = g.First().NextWorkHouseId
                            };

                foreach (var bomcom in temp2)
                {
                    //if (bomcom.MrpQuantity <= 0)
                    //{
                    //    bomcom.MrpQuantity = 0;
                    //    //continue;
                    //}
                    InumerSum += 1;
                    mRSdetails6 = new Book.Model.MRSdetails();
                    mRSdetails6.MRSdetailsId = Guid.NewGuid().ToString();
                    mRSdetails6.MRSHeaderId = mrpid1;
                    mRSdetails6.MRSdetailssum = bomcom.MpsQuantity < 0 ? 0 : double.Parse(bomcom.MpsQuantity.Value.ToString("f0"));
                    mRSdetails6.MRSdetailsQuantity = bomcom.MpsQuantity < 0 ? 0 : double.Parse(bomcom.MpsQuantity.Value.ToString("f0"));
                    mRSdetails6.MPSheaderId = this.mpsheader.MPSheaderId;
                    mRSdetails6.MPSdetailsId = bomcom.MPSdetailsId;
                    mRSdetails6.Product = bomcom.Product;
                    mRSdetails6.ProductId = bomcom.ProductId;
                    mRSdetails6.MadeProductId = bomcom.MadeProductId;
                    mRSdetails6.ProductUnit = bomcom.Unit;
                    mRSdetails6.Customer = bomcom.Customer;
                    mRSdetails6.SupplierId = bomcom.Product.SupplierId;
                    mRSdetails6.MRSdetailsdes = bomcom.BomComponentInfoDesc;
                    mRSdetails6.WorkHouseNextId = bomcom.NextWorkHouseId;
                    //  mRSdetails2.BeforePackageProductId = bomcom.BeforepPackageProductId;
                    if (mRSdetails6.Customer != null)
                        mRSdetails6.CustomerId = mRSdetails6.Customer.CustomerId;
                    mRSdetails6.Inumber = InumerSum;
                    mRSdetails6.MRSStockQuantity = mRSdetails6.Product == null ? 0 : mRSdetails6.Product.StocksQuantity;

                    if (mRSdetails6.Product != null)
                        mRSdetails6.MRSdetailssum = (mRSdetails6.MRSdetailsQuantity == null ? 0 : mRSdetails6.MRSdetailsQuantity) - (mRSdetails6.Product.StocksQuantity == null ? 0 : mRSdetails6.Product.StocksQuantity) + (mRSdetails6.Product.ProduceMaterialDistributioned == null ? 0 : mRSdetails6.Product.ProduceMaterialDistributioned);
                    else
                        mRSdetails6.MRSdetailssum = mRSdetails6.MRSdetailsQuantity;
                    if (mRSdetails6.MRSdetailssum == null || mRSdetails6.MRSdetailssum < 0)
                        mRSdetails6.MRSdetailssum = 0;
                    mRSdetails6.WorkHouseNextId = bomcom.NextWorkHouseId;
                    new BL.MRSdetailsManager().Insert(mRSdetails6);
                }
            }

            InumerSum = 0;
            if (bomComponentInfo1.Count > 0)
            {
                //if (mrpid1 == null)
                //{
                mrpid1 = this.mRSHeaderManager.GetId();
                mRSHeader1 = new Model.MRSHeader();
                mRSHeader1.MRSHeaderId = mrpid1;
                mRSHeader1.MPSheaderId = this.mpsheader.MPSheaderId;
                mRSHeader1.Employee0Id = this.mpsheader.Employee0Id;
                mRSHeader1.Employee1Id = this.mpsheader.Employee1Id;
                mRSHeader1.MRSstartdate = this.mpsheader.MPSStartDate;
                //mRSHeader1.Customer = bomComponentInfo1[0].Customer;
                //mRSHeader1.CustomerId = bomComponentInfo1[0].Customer == null ? null : bomComponentInfo1[0].Customer.CustomerId;

                mRSHeader1.SourceType = ((Int32)global::Helper.ProductType.HomeMade).ToString();
                Audit(mRSHeader1);
                this.mRSHeaderManager.Insert(mRSHeader1);
                //}
                //加入成品
                //mRSdetails1 = new Book.Model.MRSdetails();
                //mRSdetails1.MRSdetailsId = Guid.NewGuid().ToString();
                //mRSdetails1.MRSdetailssum = bomcom.MrpQuantity;
                //mRSdetails1.MRSdetailsQuantity = bomcom.MrpQuantity;
                //mRSdetails1.MPSheaderId = this.mpsheader.MPSheaderId;
                //mRSdetails1.MRSHeaderId = mRSHeader1.MRSHeaderId;
                //mRSdetails1.Product = bomcom.Product;
                //mRSdetails1.ProductId = bomcom.ProductId;
                //mRSdetails1.ProductUnit = bomcom.Unit;
                //new BL.MRSdetailsManager().Insert(mRSdetails1);

                ///半成品
                ///

                var temp = from m in bomComponentInfo1
                           group m by new { m.ProductId, m.Unit } into g
                           select new
                           {
                               MrpQuantity = (from x in g select x.MrpQuantity).Sum(),
                               MpsQuantity = (from x in g select x.MpsQuantity).Sum(),
                               ProductId = g.Key.ProductId,
                               Product = g.Max(p => p.Product),
                               Unit = g.Key.Unit,
                               MPSdetailsId = g.Max(p => p.MPSdetailsId),
                               Customer = g.Max(p => p.Customer),
                               MadeProductId = g.First().MadeProductId,
                               BeforepPackageProductId = g.First().BeforepPackageProductId,
                               NextWorkHouseId = g.First().NextWorkHouseId
                           };


                foreach (var bomcom in temp)
                {

                    //if (bomcom.MrpQuantity <= 0)
                    //{
                    //    bomcom.MrpQuantity = 0;
                    //    //continue;
                    //}
                    InumerSum += 1;
                    mRSdetails1 = new Book.Model.MRSdetails();
                    mRSdetails1.MRSdetailsId = Guid.NewGuid().ToString();
                    mRSdetails1.MRSdetailssum = bomcom.MpsQuantity < 0 ? 0 : double.Parse(bomcom.MpsQuantity.Value.ToString("f0"));
                    mRSdetails1.MRSdetailsQuantity = bomcom.MpsQuantity < 0 ? 0 : double.Parse(bomcom.MpsQuantity.Value.ToString("f0"));
                    mRSdetails1.MPSheaderId = this.mpsheader.MPSheaderId;
                    mRSdetails1.MPSdetailsId = bomcom.MPSdetailsId;
                    mRSdetails1.MRSHeaderId = mrpid1;
                    mRSdetails1.Product = bomcom.Product;
                    mRSdetails1.ProductId = bomcom.ProductId;
                    mRSdetails1.ProductUnit = bomcom.Unit;
                    mRSdetails1.Customer = bomcom.Customer;

                    mRSdetails1.MadeProductId = bomcom.MadeProductId;
                    mRSdetails1.Inumber = InumerSum;
                    mRSdetails1.BeforePackageProductId = bomcom.BeforepPackageProductId;
                    mRSdetails1.WorkHouseNextId = bomcom.NextWorkHouseId;
                    mRSdetails1.MRSStockQuantity = mRSdetails1.Product == null ? 0 : mRSdetails1.Product.StocksQuantity;

                    if (mRSdetails1.Customer != null)
                        mRSdetails1.CustomerId = mRSdetails1.Customer.CustomerId;
                    if (mRSdetails1.Product != null)   //[13:49:17 | 已编辑 13:49:26] 乙蓉 - Becky: 計畫數量-庫存+領料單以分配量=需求數量
                        mRSdetails1.MRSdetailssum = (mRSdetails1.MRSdetailsQuantity == null ? 0 : mRSdetails1.MRSdetailsQuantity) - (mRSdetails1.Product.StocksQuantity == null ? 0 : mRSdetails1.Product.StocksQuantity) + (mRSdetails1.Product.ProduceMaterialDistributioned == null ? 0 : mRSdetails1.Product.ProduceMaterialDistributioned);               //计划数量-库存+领料单已分配
                    else
                        mRSdetails1.MRSdetailssum = mRSdetails1.MRSdetailsQuantity;
                    if (mRSdetails1.MRSdetailssum == null || mRSdetails1.MRSdetailssum < 0)
                        mRSdetails1.MRSdetailssum = 0;
                    mRSdetails1.WorkHouseNextId = bomcom.NextWorkHouseId;
                    new BL.MRSdetailsManager().Insert(mRSdetails1);
                }


                //foreach (Model.BomComponentInfo bomcom in bomComponentInfo1)
                //{
                //    mRSdetails1 = new Book.Model.MRSdetails();
                //    mRSdetails1.MRSdetailsId = Guid.NewGuid().ToString();
                //    mRSdetails1.MRSdetailssum = bomcom.MrpQuantity;
                //    mRSdetails1.MRSdetailsQuantity = bomcom.MrpQuantity;
                //    mRSdetails1.MPSheaderId = this.mpsheader.MPSheaderId;
                //    mRSdetails1.MPSdetailsId = bomcom.MPSdetailsId;
                //    mRSdetails1.MRSHeaderId = mRSHeader1.MRSHeaderId;
                //    mRSdetails1.Product = bomcom.Product;
                //    mRSdetails1.ProductId = bomcom.ProductId;
                //    mRSdetails1.ProductUnit = bomcom.Unit;
                //    mRSdetails1.Customer = bomcom.Customer;
                //    mRSdetails1.MRSdetailsId = bomcom.MPSdetailsId;
                //    if (mRSdetails1.Customer != null)
                //        mRSdetails1.CustomerId = mRSdetails1.Customer.CustomerId;
                //    new BL.MRSdetailsManager().Insert(mRSdetails1);
                //}
            }

            InumerSum = 0;
            if (bomComponentInfo2.Count > 0)
            {


                //if (mrpid1 == null)
                //{

                mrpid1 = this.mRSHeaderManager.GetId();
                mRSHeader2 = new Model.MRSHeader();
                mRSHeader2.MRSHeaderId = mrpid1;
                mRSHeader2.MPSheaderId = this.mpsheader.MPSheaderId;
                mRSHeader2.Employee0Id = this.mpsheader.Employee0Id;
                mRSHeader2.Employee1Id = this.mpsheader.Employee1Id;
                mRSHeader2.MRSstartdate = this.mpsheader.MPSStartDate;
                mRSHeader2.Customer = bomComponentInfo2[0].Customer;
                mRSHeader2.CustomerId = bomComponentInfo2[0].Customer == null ? null : bomComponentInfo2[0].Customer.CustomerId;

                mRSHeader2.SourceType = ((Int32)global::Helper.ProductType.OutSourcing).ToString();
                Audit(mRSHeader2);
                this.mRSHeaderManager.Insert(mRSHeader2);
                //}

                var temp2 = from m in bomComponentInfo2
                            group m by new { m.ProductId, m.Unit } into g
                            select new
                            {
                                MrpQuantity = (from x in g select x.MrpQuantity).Sum(),
                                MpsQuantity = (from x in g select x.MpsQuantity).Sum(),
                                ProductId = g.Key.ProductId,
                                Product = g.Max(p => p.Product),
                                Unit = g.Key.Unit,
                                MPSdetailsId = g.Max(p => p.MPSdetailsId),
                                Customer = g.Max(p => p.Customer),
                                BomComponentInfoDesc = g.Max(p => p.BomComponentInfoDesc),
                                MadeProductId = g.First().MadeProductId,
                                BeforepPackageProductId = g.First().BeforepPackageProductId,
                                NextWorkHouseId = g.First().NextWorkHouseId
                            };

                foreach (var bomcom in temp2)
                {
                    //if (bomcom.MrpQuantity <= 0)
                    //{
                    //    bomcom.MrpQuantity = 0;
                    //    //continue;
                    //}
                    InumerSum += 1;
                    mRSdetails2 = new Book.Model.MRSdetails();
                    mRSdetails2.MRSdetailsId = Guid.NewGuid().ToString();
                    mRSdetails2.MRSHeaderId = mrpid1;
                    mRSdetails2.MRSdetailssum = bomcom.MpsQuantity < 0 ? 0 : double.Parse(bomcom.MpsQuantity.Value.ToString("f0"));
                    mRSdetails2.MRSdetailsQuantity = bomcom.MpsQuantity < 0 ? 0 : double.Parse(bomcom.MpsQuantity.Value.ToString("f0"));
                    mRSdetails2.MPSheaderId = this.mpsheader.MPSheaderId;
                    mRSdetails2.MPSdetailsId = bomcom.MPSdetailsId;
                    mRSdetails2.Product = bomcom.Product;
                    mRSdetails2.SupplierId = bomcom.Product.SupplierId;
                    mRSdetails2.ProductId = bomcom.ProductId;
                    mRSdetails2.ProductUnit = bomcom.Unit;
                    mRSdetails2.Customer = bomcom.Customer;
                    mRSdetails2.MRSdetailsdes = bomcom.BomComponentInfoDesc;
                    mRSdetails2.MadeProductId = bomcom.MadeProductId;
                    //  mRSdetails2.BeforePackageProductId = bomcom.BeforepPackageProductId;
                    if (mRSdetails2.Customer != null)
                        mRSdetails2.CustomerId = mRSdetails2.Customer.CustomerId;
                    mRSdetails2.Inumber = InumerSum;
                    mRSdetails2.WorkHouseNextId = bomcom.NextWorkHouseId;
                    mRSdetails2.MRSStockQuantity = mRSdetails2.Product == null ? 0 : mRSdetails2.Product.StocksQuantity;

                    if (mRSdetails2.Product != null)
                        mRSdetails2.MRSdetailssum = (mRSdetails2.MRSdetailsQuantity == null ? 0 : mRSdetails2.MRSdetailsQuantity) - (mRSdetails2.Product.StocksQuantity == null ? 0 : mRSdetails2.Product.StocksQuantity) + (mRSdetails2.Product.ProduceMaterialDistributioned == null ? 0 : mRSdetails2.Product.ProduceMaterialDistributioned);   //计划数量-库存+领料单已分配
                    else
                        mRSdetails2.MRSdetailssum = mRSdetails2.MRSdetailsQuantity;
                    if (mRSdetails2.MRSdetailssum == null || mRSdetails2.MRSdetailssum < 0)
                        mRSdetails2.MRSdetailssum = 0;
                    mRSdetails2.WorkHouseNextId = bomcom.NextWorkHouseId;
                    new BL.MRSdetailsManager().Insert(mRSdetails2);
                }

                //foreach (Model.BomComponentInfo bomcom in bomComponentInfo2)
                //{
                //    if (bomcom.MrpQuantity <= 0)
                //        continue;
                //    mRSdetails2 = new Book.Model.MRSdetails();
                //    mRSdetails2.MRSdetailsId = Guid.NewGuid().ToString();
                //    mRSdetails2.MRSHeaderId = mRSHeader2.MRSHeaderId;
                //    mRSdetails2.MRSdetailssum = bomcom.MrpQuantity;
                //    mRSdetails2.MRSdetailsQuantity = bomcom.MrpQuantity;
                //    mRSdetails2.MPSheaderId = this.mpsheader.MPSheaderId;
                //    mRSdetails2.MPSdetailsId = bomcom.MPSdetailsId;
                //    mRSdetails2.Product = bomcom.Product;
                //    mRSdetails2.ProductId = bomcom.ProductId;
                //    mRSdetails2.ProductUnit = bomcom.Unit;
                //    mRSdetails2.Customer = bomcom.Customer;
                //    mRSdetails2.MRSdetailsId = bomcom.MPSdetailsId;
                //    mRSdetails2.MRSdetailsdes = bomcom.BomComponentInfoDesc;
                //    if (mRSdetails2.Customer != null)
                //        mRSdetails2.CustomerId = mRSdetails2.Customer.CustomerId;
                //    new BL.MRSdetailsManager().Insert(mRSdetails2);
                //}

            }
            InumerSum = 0;
            if (bomComponentInfo3.Count > 0)
            {
                //if (mrpid3 == null)
                //{
                mrpid1 = this.mRSHeaderManager.GetId();
                mRSHeader3 = new Model.MRSHeader();
                mRSHeader3.MRSHeaderId = mrpid1;
                mRSHeader3.MPSheaderId = this.mpsheader.MPSheaderId;
                mRSHeader3.Employee0Id = this.mpsheader.Employee0Id;
                mRSHeader3.Employee1Id = this.mpsheader.Employee1Id;
                mRSHeader3.MRSstartdate = this.mpsheader.MPSStartDate;
                mRSHeader3.Customer = bomComponentInfo3[0].Customer;
                mRSHeader3.CustomerId = bomComponentInfo3[0].Customer == null ? null : bomComponentInfo3[0].Customer.CustomerId;

                mRSHeader3.SourceType = ((Int32)global::Helper.ProductType.TrustOut).ToString();
                Audit(mRSHeader3);
                this.mRSHeaderManager.Insert(mRSHeader3);
                // }

                var temp3 = from m in bomComponentInfo3
                            group m by new { m.ProductId, m.Unit } into g
                            select new
                            {
                                MrpQuantity = (from x in g select x.MrpQuantity).Sum(),
                                MpsQuantity = (from x in g select x.MpsQuantity).Sum(),
                                ProductId = g.Key.ProductId,
                                Product = g.Max(p => p.Product),
                                Unit = g.Key.Unit,
                                MPSdetailsId = g.Max(p => p.MPSdetailsId),
                                Customer = g.Max(p => p.Customer),
                                MadeProductId = g.First().MadeProductId,
                                BeforepPackageProductId = g.First().BeforepPackageProductId,
                                NextWorkHouseId = g.First().NextWorkHouseId
                            };

                foreach (var bomcom in temp3)
                {
                    //if (bomcom.MrpQuantity <= 0)
                    //{
                    //    bomcom.MrpQuantity = 0;
                    //   // continue;
                    //}
                    InumerSum += 1;
                    mRSdetails3 = new Book.Model.MRSdetails();
                    mRSdetails3.MRSdetailsId = Guid.NewGuid().ToString();
                    mRSdetails3.MRSHeaderId = mrpid1;
                    mRSdetails3.MRSdetailssum = bomcom.MpsQuantity < 0 || bomcom.MpsQuantity == null ? 0 : double.Parse(bomcom.MpsQuantity.Value.ToString("f0"));
                    mRSdetails3.MRSdetailsQuantity = bomcom.MpsQuantity < 0 || bomcom.MpsQuantity == null ? 0 : double.Parse(bomcom.MpsQuantity.Value.ToString("f0"));
                    mRSdetails3.MPSheaderId = this.mpsheader.MPSheaderId;
                    mRSdetails3.MPSdetailsId = bomcom.MPSdetailsId;
                    mRSdetails3.Product = bomcom.Product;
                    mRSdetails3.ProductId = bomcom.ProductId;
                    mRSdetails3.ProductUnit = bomcom.Unit;
                    mRSdetails3.Customer = bomcom.Customer;
                    mRSdetails3.SupplierId = bomcom.Product.SupplierId;
                    mRSdetails3.MadeProductId = bomcom.MadeProductId;
                    mRSdetails3.BeforePackageProductId = bomcom.BeforepPackageProductId;
                    if (mRSdetails3.Customer != null)
                        mRSdetails3.CustomerId = mRSdetails3.Customer.CustomerId;
                    mRSdetails3.Inumber = InumerSum;
                    mRSdetails3.WorkHouseNextId = bomcom.NextWorkHouseId;
                    mRSdetails3.MRSStockQuantity = mRSdetails3.Product == null ? 0 : mRSdetails3.Product.StocksQuantity;

                    if (mRSdetails3.Product != null)
                        mRSdetails3.MRSdetailssum = (mRSdetails3.MRSdetailsQuantity == null ? 0 : mRSdetails3.MRSdetailsQuantity) - (mRSdetails3.Product.StocksQuantity == null ? 0 : mRSdetails3.Product.StocksQuantity) + (mRSdetails3.Product.ProduceMaterialDistributioned == null ? 0 : mRSdetails3.Product.ProduceMaterialDistributioned);     //计划数量-库存+领料单已分配
                    else
                        mRSdetails3.MRSdetailssum = mRSdetails3.MRSdetailsQuantity;
                    if (mRSdetails3.MRSdetailssum == null || mRSdetails3.MRSdetailssum < 0)
                        mRSdetails3.MRSdetailssum = 0;
                    mRSdetails3.WorkHouseNextId = bomcom.NextWorkHouseId;
                    new BL.MRSdetailsManager().Insert(mRSdetails3);
                }

                //foreach (Model.BomComponentInfo bomcom in bomComponentInfo3)
                //{
                //    mRSdetails3 = new Book.Model.MRSdetails();
                //    mRSdetails3.MRSdetailsId = Guid.NewGuid().ToString();
                //    mRSdetails3.MRSHeaderId = mRSHeader3.MRSHeaderId;
                //    mRSdetails3.MRSdetailssum = bomcom.MrpQuantity;
                //    mRSdetails3.MRSdetailsQuantity = bomcom.MrpQuantity;
                //    mRSdetails3.MPSheaderId = this.mpsheader.MPSheaderId;
                //    mRSdetails3.MPSdetailsId = bomcom.MPSdetailsId;
                //    mRSdetails3.Product = bomcom.Product;
                //    mRSdetails3.ProductId = bomcom.ProductId;
                //    mRSdetails3.ProductUnit = bomcom.Unit;
                //    mRSdetails3.Customer = bomcom.Customer;
                //    mRSdetails3.MRSdetailsId = bomcom.MPSdetailsId;
                //    if (mRSdetails3.Customer != null)
                //        mRSdetails3.CustomerId = mRSdetails3.Customer.CustomerId;
                //    new BL.MRSdetailsManager().Insert(mRSdetails3);
                //}
            }

        }

        private static void Audit(Model.MRSHeader mRSHeader)
        {
            //审核
            string tableName = "MRSHeader";
            //tableDesc = new BL.OperationManager().GetOperationNamebyTabel(tableName);
            Model.RoleAuditing roleAuditing = null;
            if (new BL.RoleAuditingManager().IsNeedAuditByTableName(tableName))
            {
                roleAuditing = new Book.Model.RoleAuditing();
                roleAuditing.RoleAuditingId = Guid.NewGuid().ToString();
                roleAuditing.AuditRank = 0;
                roleAuditing.NextAuditRole = new BL.RoleManager().select_byAuditRandTableName(1, tableName);
                if (roleAuditing.NextAuditRole != null)
                    roleAuditing.NextAuditRoleId = roleAuditing.NextAuditRole.RoleId;
                roleAuditing.AuditState = (int)global::Helper.InvoiceAudit.WaitAudit;
                roleAuditing.Employee0Id = BL.V.ActiveOperator.EmployeeId;
                roleAuditing.InsertTime = DateTime.Now;

                roleAuditing.InvoiceName = new BL.OperationManager().GetOperationNamebyTabel(tableName); ;
                roleAuditing.TableName = tableName;

                mRSHeader.AuditState = (int)global::Helper.InvoiceAudit.WaitAudit;
            }
            if (roleAuditing != null)
            {
                roleAuditing.InvoiceId = mRSHeader.MRSHeaderId;
                new BL.RoleAuditingManager().Insert(roleAuditing);
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView view = this.gridView1;
            this.saveFileDialog1.Filter = "PDF file|*.pdf";
            if (this.saveFileDialog1.ShowDialog(this) != DialogResult.OK)
                return;

            string file = this.saveFileDialog1.FileName;
            this.ExportToPdf(file);


        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView view = this.gridView1;
            this.saveFileDialog1.Filter = "Excel file|*.xls";
            if (this.saveFileDialog1.ShowDialog(this) != DialogResult.OK)
                return;

            string file = this.saveFileDialog1.FileName;
            view.GridControl.ExportToXls(file);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ListForm f = new ListForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                this.mpsheader = f.SelectItem;
                this.action = "view";
                this.Refresh();
            }
        }

        private void textMPSheaderDesc_DoubleClick(object sender, EventArgs e)
        {
            PCParameterSet.ChooseParameter cp = new Book.UI.produceManager.PCParameterSet.ChooseParameter("BeiZhuShuoMing");
            if (cp.ShowDialog(this) != DialogResult.OK) return;
            if (cp.SelectedItem != null)
            {
                Model.Setting setParam = cp.SelectedItem as Model.Setting;
                this.textMPSheaderDesc.Text += setParam.SettingCurrentValue;
            }
            cp.Dispose();
            GC.Collect();
        }


        #region 审核
        protected override string AuditKeyId()
        {
            return Model.MPSheader.PRO_MPSheaderId;
        }

        protected override int AuditState()
        {
            return this.mpsheader.AuditState.HasValue ? this.mpsheader.AuditState.Value : 0;
        }

        protected override string tableCode()
        {
            return "MPSheader" + "," + this.mpsheader.MPSheaderId;
        }
        #endregion
    }
}