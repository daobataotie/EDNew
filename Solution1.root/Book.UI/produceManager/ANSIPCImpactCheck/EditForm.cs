﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Book.UI.Settings.BasicData.Employees;
using System.Xml;
using System.Linq;

namespace Book.UI.produceManager.ANSIPCImpactCheck
{
    public partial class EditForm : Book.UI.Settings.BasicData.BaseEditForm
    {
        Model.ANSIPCImpactCheck _ansipcic = null;
        BL.ANSIPCImpactCheckManager _ansipcicManager = new Book.BL.ANSIPCImpactCheckManager();
        IList<Model.Setting> CJLD = new List<Model.Setting>();
        IList<Model.Setting> ZQZL = new List<Model.Setting>();
        IList<Model.Setting> LYBTXX = new List<Model.Setting>();

        //测试单类型
        string ForANSIOrJIS = null;
        int _pcFlag = 0;         //0:ASNI   1:JIS

        public EditForm()
        {
            InitializeComponent();
            this.requireValueExceptions.Add(Model.ANSIPCImpactCheck.PRO_ANSIPCImpactCheckID, new AA(Properties.Resources.NumsIsNotNull, this.txtANSIPCImpactCheckId));
            this.requireValueExceptions.Add(Model.ANSIPCImpactCheck.PRO_ANSIPCImpactCheckDate, new AA(Properties.Resources.DateIsNull, this.DE_ANSIPCImpactCheckDate));
            this.requireValueExceptions.Add(Model.ANSIPCImpactCheck.PRO_ProductId, new AA(Properties.Resources.Noproduct, this.BEProduct));
            this.requireValueExceptions.Add(Model.ANSIPCImpactCheck.PRO_EmployeeId, new AA(Properties.Resources.EmployeeIdNotNull, this.nccEmployee0));
            this.action = "view";
            this.nccEmployee0.Choose = new ChooseEmployee();
            this.newChooseContorlAuditEmp.Choose = new ChooseEmployee();
            this.bindingSourceUnit.DataSource = (new BL.ProductUnitManager()).Select();
        }

        int LastFlag = 0;
        public EditForm(string invoiceId)
            : this()
        {
            //作为JIS冲击测试单使用
            if (invoiceId.IndexOf('-') > 0)
            {
                string str = invoiceId.Substring(invoiceId.IndexOf('-') + 1);
                if (str == "JIS")
                {
                    this.Text = "JIS衝擊測試單";
                    this.ForANSIOrJIS = "JIS";
                    this._pcFlag = 1;
                }
                else
                {
                    this.ForANSIOrJIS = "ANSI";
                    this._pcFlag = 0;
                }
            }

            else
            {
                this._ansipcic = this._ansipcicManager.Get(invoiceId);
                if (this._ansipcic == null)
                    throw new ArithmeticException("invoiceid");
                this.action = "view";
                if (this.action == "view")
                    LastFlag = 1;
            }
        }

        public EditForm(Model.ANSIPCImpactCheck mANSIPCImpactCheck)
            : this()
        {
            if (mANSIPCImpactCheck == null)
                throw new ArithmeticException("invoiceid");
            if (mANSIPCImpactCheck.ForANSIOrJIS == "JIS")
            {
                this.Text = "JIS衝擊測試單";
                this.ForANSIOrJIS = "JIS";
                this._pcFlag = 1;
            }
            else
            {
                this.ForANSIOrJIS = "ANSI";
                this._pcFlag = 0;
            }
            this._ansipcic = mANSIPCImpactCheck;
            this.action = "view";
            if (this.action == "view")
                LastFlag = 1;
        }

        public EditForm(Model.ANSIPCImpactCheck mANSIPCImpactCheck, int i)
            : this()
        {
            this._pcFlag = i;
            if (mANSIPCImpactCheck == null)
                throw new ArithmeticException("invoiceid");
            if (mANSIPCImpactCheck.ForANSIOrJIS == "JIS")
            {
                this.Text = "JIS衝擊測試單";
                this.ForANSIOrJIS = "JIS";
            }
            else
                this.ForANSIOrJIS = "ANSI";
            this._ansipcic = mANSIPCImpactCheck;
            this.action = "view";
            if (this.action == "view")
                LastFlag = 1;
        }

        public EditForm(Model.ANSIPCImpactCheck mANSIPCImpactCheck, string action)
            : this()
        {
            this._ansipcic = mANSIPCImpactCheck;
            this.action = action;
            if (this.action == "view")
                LastFlag = 1;
        }

        protected override void AddNew()
        {
            this._ansipcic = new Book.Model.ANSIPCImpactCheck();
            this._ansipcic.ANSIPCImpactCheckID = this._ansipcicManager.GetId();
            this._ansipcic.ANSIPCImpactCheckDate = DateTime.Now.Date;
            this._ansipcic.ANSIPCImpactCheckCount = 1;  //检测数量默认为1
            this._ansipcic.Employee = BL.V.ActiveOperator.Employee;
            this._ansipcic.EmployeeId = BL.V.ActiveOperator.EmployeeId;

            //if (this._pcFlag == 0)
            //{
            if (this.CJLD.Any(d => d.SettingCurrentValue.Contains("150 FT/S")))
                this.coBoxCJLD.EditValue = this.CJLD.First(d => d.SettingCurrentValue.Contains("150 FT/S")).SettingCurrentValue;
            //}
            //else
            //{
            //    if (this.CJLD.Any(d => d.SettingCurrentValue.Contains("150 FT/S")))
            //        this.coBoxCJLD.EditValue = this.CJLD.First(d => d.SettingCurrentValue.Contains("150 FT/S")).SettingCurrentValue;
            //}

            //初始化添加一条详细
            this._ansipcic.Details = new List<Model.ANSIPCImpactCheckDetail>();
            this.AddDataRows();
        }

        protected override void Delete()
        {
            if (this._ansipcic == null)
                return;
            if (MessageBox.Show(Properties.Resources.ConfirmToDelete, this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this._ansipcicManager.Delete(this._ansipcic);

            this._ansipcic = this._ansipcicManager.GetNext(this._ansipcic);
            if (this._ansipcic == null)
            {
                this._ansipcic = this._ansipcicManager.GetLast();
            }
        }

        protected override void MoveLast()
        {
            if (LastFlag == 1) { LastFlag = 0; return; }
            this._ansipcic = this._ansipcicManager.Get(this._ansipcicManager.GetLastByForANSIOrJIS(this.ForANSIOrJIS) == null ? "" : this._ansipcicManager.GetLastByForANSIOrJIS(this.ForANSIOrJIS).ANSIPCImpactCheckID);
        }

        protected override void MoveFirst()
        {
            this._ansipcic = this._ansipcicManager.Get(this._ansipcicManager.GetFirstByForANSIOrJIS(this.ForANSIOrJIS) == null ? "" : this._ansipcicManager.GetFirstByForANSIOrJIS(this.ForANSIOrJIS).ANSIPCImpactCheckID);
        }

        protected override void MovePrev()
        {
            Model.ANSIPCImpactCheck ansipcic = this._ansipcicManager.GetPrevByForANSIOrJIS(this._ansipcic);
            if (ansipcic == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);
            this._ansipcic = this._ansipcicManager.Get(ansipcic.ANSIPCImpactCheckID);
        }

        protected override void MoveNext()
        {
            Model.ANSIPCImpactCheck ansipcic = this._ansipcicManager.GetNextByForANSIOrJIS(this._ansipcic);
            if (ansipcic == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);
            this._ansipcic = this._ansipcicManager.Get(ansipcic.ANSIPCImpactCheckID);
        }

        protected override bool HasRows()
        {
            return this._ansipcicManager.HasRowsByForANSIOrJIS(this.ForANSIOrJIS);
        }

        protected override bool HasRowsNext()
        {
            return this._ansipcicManager.HasRowsAfterByForANSIOrJIS(this._ansipcic);
        }

        protected override bool HasRowsPrev()
        {
            return this._ansipcicManager.HasRowsBeforeByForANSIOrJIS(this._ansipcic);
        }

        public override void Refresh()
        {
            if (this._ansipcic == null)
            {
                this.AddNew();
                this.action = "insert";
            }
            else
            {
                if (this.action == "view")
                {
                    this._ansipcic = this._ansipcicManager.GetDetail(this._ansipcic);
                }
            }

            //初始化控件
            this.txtANSIPCImpactCheckId.Text = this._ansipcic.ANSIPCImpactCheckID;
            this.txtPronoteHeaderId.Text = this._ansipcic.PronoteHeaderId;
            //this.txtInvoiceCusXOId.Text = this._ansipcic.InvoiceCusXOId;
            this.txtInvoiceCusXOId.Text = (this._ansipcic.Invoice == null ? this._ansipcic.InvoiceCusXOId : this._ansipcic.Invoice.CustomerInvoiceXOId);
            this.txtANSIPCImpactCheckDesc.Text = this._ansipcic.ANSIPCImpactCheckDesc;
            this.ceInvoiceXOCount.EditValue = this._ansipcic.InvoiceXOQuantity.HasValue ? this._ansipcic.InvoiceXOQuantity.Value : 0;
            this.calcPCCheckCount.EditValue = this._ansipcic.ANSIPCImpactCheckCount.HasValue ? this._ansipcic.ANSIPCImpactCheckCount.Value : 0;
            this.DE_ANSIPCImpactCheckDate.EditValue = this._ansipcic.ANSIPCImpactCheckDate.Value;
            this.BEProduct.EditValue = this._ansipcic.Product;
            this.nccEmployee0.EditValue = this._ansipcic.Employee;
            this.txtCheckedStandard.Text = this._ansipcic.CheckStandard;
            this.coBoxCJLD.Text = string.IsNullOrEmpty(this._ansipcic.PowerImpact) ? this.coBoxCJLD.Text : this._ansipcic.PowerImpact;
            this.coBoxZQZL.Text = string.IsNullOrEmpty(this._ansipcic.ZhuiQiuKG) ? this.coBoxZQZL.Text : this._ansipcic.ZhuiQiuKG;
            this.coBoxLYBTXX.Text = string.IsNullOrEmpty(this._ansipcic.PrintDesc1) ? this.coBoxLYBTXX.Text : this._ansipcic.PrintDesc1;

            this.chkEditYZZL.Checked = this._ansipcic.IsYuanZhuiZhuiLuo.HasValue ? this._ansipcic.IsYuanZhuiZhuiLuo.Value : false;
            this.chkEditGSCJ.Checked = this._ansipcic.IsGaoSuChongJi.HasValue ? this._ansipcic.IsGaoSuChongJi.Value : false;
            this.newChooseContorlAuditEmp.EditValue = this._ansipcic.AuditEmp;
            this.txt_AuditState.EditValue = this.GetAuditName(this._ansipcic.AuditState);
            this.lookUpEditUnit.EditValue = this._ansipcic.UnitId;

            #region LookUpEditor

            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("id", typeof(string));
            DataColumn dc1 = new DataColumn("name", typeof(string));
            dt.Columns.Add(dc);
            dt.Columns.Add(dc1);
            DataRow dr;
            dr = dt.NewRow();
            dr[0] = "-1";
            dr[1] = string.Empty;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "0";
            dr[1] = "√";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "△";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "2";
            dr[1] = "X";
            dt.Rows.Add(dr);


            for (int i = 0; i < this.gridView1.Columns.Count - 1; i++)
            {
                if (this.gridView1.Columns[i].ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
                {
                    ((DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)this.gridView1.Columns[i].ColumnEdit).DataSource = dt;
                    ((DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)this.gridView1.Columns[i].ColumnEdit).Columns.Clear();
                    ((DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)this.gridView1.Columns[i].ColumnEdit).Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                    new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name",25, "标识"),
                     });
                    ((DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)this.gridView1.Columns[i].ColumnEdit).DisplayMember = "name";
                    ((DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)this.gridView1.Columns[i].ColumnEdit).ValueMember = "id";
                }
            }

            #endregion

            this.GirdViewLookUpEditEmployee.DataSource = this.bsLUEemployees;

            this.bindingSource1.DataSource = this._ansipcic.Details;

            base.Refresh();
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
            }

            //this.ceInvoiceXOCount.Enabled = false;
            this.txtANSIPCImpactCheckId.Properties.ReadOnly = true;
            //this.nccEmployee0.Enabled = false;
        }

        protected override void Save()
        {
            this._ansipcic.ANSIPCImpactCheckID = this.txtANSIPCImpactCheckId.Text;
            this._ansipcic.ANSIPCImpactCheckDesc = this.txtANSIPCImpactCheckDesc.Text;
            this._ansipcic.PronoteHeaderId = this.txtPronoteHeaderId.Text;
            this._ansipcic.InvoiceCusXOId = this.txtInvoiceCusXOId.Text;
            this._ansipcic.ANSIPCImpactCheckDate = this.DE_ANSIPCImpactCheckDate.DateTime;
            this._ansipcic.CheckStandard = this.txtCheckedStandard.Text;
            this._ansipcic.InvoiceXOQuantity = this.ceInvoiceXOCount.EditValue != null ? double.Parse(this.ceInvoiceXOCount.EditValue.ToString()) : 0;
            this._ansipcic.PowerImpact = this.coBoxCJLD.Text;
            this._ansipcic.ZhuiQiuKG = this.coBoxZQZL.Text;
            this._ansipcic.PrintDesc1 = this.coBoxLYBTXX.Text;
            this._ansipcic.ANSIPCImpactCheckCount = this.calcPCCheckCount.EditValue != null ? int.Parse(this.calcPCCheckCount.EditValue.ToString()) : 0;

            this._ansipcic.IsYuanZhuiZhuiLuo = this.chkEditYZZL.Checked;
            this._ansipcic.IsGaoSuChongJi = this.chkEditGSCJ.Checked;

            this._ansipcic.Employee = (this.nccEmployee0.EditValue as Model.Employee);
            if (this._ansipcic.Employee != null)
            {
                this._ansipcic.EmployeeId = this._ansipcic.Employee.EmployeeId;
            }

            this._ansipcic.Product = (this.BEProduct.EditValue as Model.Product);
            if (this._ansipcic.Product != null)
            {
                this._ansipcic.ProductId = this._ansipcic.Product.ProductId;
            }

            this._ansipcic.ForANSIOrJIS = this.ForANSIOrJIS;
            this._ansipcic.UnitId = this.lookUpEditUnit.EditValue == null ? null : this.lookUpEditUnit.EditValue.ToString();

            if (!this.gridView1.PostEditor() || !this.gridView1.UpdateCurrentRow())
                return;
            switch (this.action)
            {
                case "insert":
                    this._ansipcicManager.Insert(this._ansipcic);
                    break;
                case "update":
                    this._ansipcicManager.Update(this._ansipcic);
                    break;
            }
        }

        protected override DevExpress.XtraReports.UI.XtraReport GetReport()
        {
            if (this._pcFlag == 0)
                return new RO1(this._ansipcic);
            return new RO(this._ansipcic);
        }

        //添加行
        private void AddDataRows()
        {
            Model.ANSIPCImpactCheckDetail ansipcicDetail = new Book.Model.ANSIPCImpactCheckDetail();
            ansipcicDetail.ANSIPCImpactCheckDetailsID = Guid.NewGuid().ToString();
            ansipcicDetail.ANSIPCImpactCheckID = this._ansipcic.ANSIPCImpactCheckID;
            ansipcicDetail.attrDate = DateTime.Now;
            this._ansipcic.Details.Add(ansipcicDetail);

            this.bindingSource1.Position = this.bindingSource1.IndexOf(ansipcicDetail);
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            this.AddDataRows();
            this.gridControl1.RefreshDataSource();
        }

        private void btnDelDetail_Click(object sender, EventArgs e)
        {
            if (this.bindingSource1.Current != null)
            {
                this._ansipcic.Details.Remove(this.bindingSource1.Current as Model.ANSIPCImpactCheckDetail);
                this.gridControl1.RefreshDataSource();
            }
        }

        //选择加工单据
        private void btnGetPronoteHeader_Click(object sender, EventArgs e)
        {
            Book.UI.produceManager.PronoteHeader.ChoosePronoteHeaderDetailsForm pronoForm = new Book.UI.produceManager.PronoteHeader.ChoosePronoteHeaderDetailsForm(null, 0);
            if (pronoForm.ShowDialog(this) == DialogResult.OK)
            {
                Model.PronoteHeader currentModel = pronoForm.SelectItem;

                if (currentModel != null)
                {
                    this._ansipcic.Invoice = currentModel.InvoiceXO;
                    this._ansipcic.InvoiceId = currentModel.InvoiceXOId;
                    this._ansipcic.PronoteHeaderId = currentModel.PronoteHeaderID;
                    this._ansipcic.InvoiceCusXOId = currentModel.CustomerInvoiceXOId;
                    this._ansipcic.Product = new BL.ProductManager().Get(currentModel.ProductId);
                    this._ansipcic.ProductId = this._ansipcic.Product.ProductId;
                    this._ansipcic.CheckStandard = currentModel.CustomerCheckStandard;
                    this._ansipcic.InvoiceXOQuantity = currentModel.InvoiceXODetailQuantity;
                    //this._ansipcic.ANSIPCImpactCheckCount = Convert.ToInt16(Math.Ceiling(Convert.ToDouble(currentModel.InvoiceXODetailQuantity) / 500));
                    this._ansipcic.ANSIPCImpactCheckCount = Common.AutoCalculation.Calculation(this.ForANSIOrJIS, Convert.ToInt32(currentModel.InvoiceXODetailQuantity));

                    this._ansipcic.UnitId = this._ansipcic.Product.QualityTestUnitId;
                    this._ansipcic.Unit = this._ansipcic.Product.QualityTestUnit;


                    //if (!string.IsNullOrEmpty(this._ansipcic.CheckStandard))
                    //{
                    //    if (this.CJLD.Any(d => d.SettingDescription == this._ansipcic.CheckStandard))
                    //        this.coBoxCJLD.EditValue = this.CJLD.First(d => d.SettingDescription == this._ansipcic.CheckStandard).SettingCurrentValue;
                    //    if (this.ZQZL.Any(d => d.SettingDescription == this._ansipcic.CheckStandard))
                    //        this.coBoxZQZL.EditValue = this.ZQZL.FirstOrDefault(d => d.SettingDescription == this._ansipcic.CheckStandard).SettingCurrentValue;
                    //    if (this.LYBTXX.Any(d => d.SettingDescription == this._ansipcic.CheckStandard))
                    //        this.coBoxLYBTXX.EditValue = this.LYBTXX.First(d => d.SettingDescription == this._ansipcic.CheckStandard).SettingCurrentValue;
                    //}
                    this.Refresh();
                }
            }
            pronoForm.Dispose();
            GC.Collect();
        }

        //选择测试单据
        private void barBtnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ListForm form = new ListForm(this.ForANSIOrJIS);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                Model.ANSIPCImpactCheck currentModel = form.SelectItem as Model.ANSIPCImpactCheck;
                if (currentModel != null)
                {
                    this._ansipcic = currentModel;
                    this._ansipcic = this._ansipcicManager.GetDetail(this._ansipcic);
                    this.Refresh();
                }
            }
            form.Dispose();
            GC.Collect();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.action != "view")
            {
                switch (e.KeyValue)
                {
                    case 13:
                        this.AddDataRows();
                        break;
                    case 46:
                        if (this.bindingSource1.Current != null)
                        {
                            this._ansipcic.Details.Remove(this.bindingSource1.Current as Model.ANSIPCImpactCheckDetail);
                            if (this._ansipcic.Details.Count == 0)
                            {
                                this.AddDataRows();
                            }
                        }
                        break;
                    default:
                        break;
                }
                this.gridControl1.RefreshDataSource();
            }
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            this.bsLUEemployees.DataSource = new BL.EmployeeManager().SelectOnActive();

            #region XML Note
            //XmlDocument xDoc = new XmlDocument();
            //string filePath = Application.StartupPath + "\\QualityCheck.config";
            //xDoc.Load(filePath);

            //Hashtable ansiHT = new Hashtable();
            //XmlNodeList ANSINodeList = xDoc.SelectSingleNode("/configuration/CheckList/ImpactCheck").ChildNodes;
            ////冲击力度
            //ansiHT.Add(this.coBoxCJLD, ANSINodeList.Item(0).ChildNodes);
            ////坠球重量
            //ansiHT.Add(this.coBoxZQZL, ANSINodeList.Item(1).ChildNodes);
            ////列印表头信息
            //ansiHT.Add(this.coBoxLYBTXX, ANSINodeList.Item(2).ChildNodes);

            //BindAllListBox(ansiHT);

            //this.coBoxCJLD.SelectedText = this._ansipcic.PowerImpact;
            //this.coBoxZQZL.SelectedText = this._ansipcic.ZhuiQiuKG;
            //this.coBoxLYBTXX.SelectedText = this._ansipcic.PrintDesc1;
            #endregion

            foreach (Model.Setting SET in new BL.SettingManager().SelectByName("LieYinBiaoTouXinXi"))
            {
                this.coBoxLYBTXX.Properties.Items.Add(SET.SettingCurrentValue);
                if (!string.IsNullOrEmpty(SET.SettingDescription))
                    this.LYBTXX.Add(SET);
            }
            foreach (Model.Setting SET in new BL.SettingManager().SelectByName("ChongJiLiDao"))
            {
                this.coBoxCJLD.Properties.Items.Add(SET.SettingCurrentValue);
                //if (!string.IsNullOrEmpty(SET.SettingDescription))
                if (!string.IsNullOrEmpty(SET.SettingCurrentValue))
                    this.CJLD.Add(SET);
            }
            foreach (Model.Setting SET in new BL.SettingManager().SelectByName("ZhuiQiuZhongLiang"))
            {
                this.coBoxZQZL.Properties.Items.Add(SET.SettingCurrentValue);
                if (!string.IsNullOrEmpty(SET.SettingDescription))
                    this.ZQZL.Add(SET);
            }

            if (this._pcFlag == 0)
            {
                this.attr_15L.Visible = false;
                this.attr_15R.Visible = false;
                //this.attr0L.Visible = false;
                //this.attr0R.Visible = false;
                this.attr15L.Visible = false;
                this.attr15R.Visible = false;
                //this.attr30L.Visible = false;
                //this.attr30R.Visible = false;
                this.attr45L.Visible = false;
                this.attr45R.Visible = false;
                this.attr60L.Visible = false;
                this.attr60R.Visible = false;
                this.attr75L.Visible = false;
                this.attr75R.Visible = false;
            }
            else if (this._pcFlag == 1)
            {
                this.attrHM500gL.Visible = false;
                this.attrHM500gR.Visible = false;
                this.attrChuanTou44_2gL.Visible = false;
                this.attrChuanTou44_2gR.Visible = false;
                this.attr_15L.Visible = false;
                this.attr_15R.Visible = false;
                this.attr15L.Visible = false;
                this.attr15R.Visible = false;
                this.attr45L.Visible = false;
                this.attr45R.Visible = false;
                this.attr60L.Visible = false;
                this.attr60R.Visible = false;
                this.attr75L.Visible = false;
                this.attr75R.Visible = false;
            }
        }

        private void BindAllListBox(Hashtable mHt)
        {
            foreach (DictionaryEntry de in mHt)
            {
                DevExpress.XtraEditors.ComboBoxEdit mcoBox = de.Key as DevExpress.XtraEditors.ComboBoxEdit;
                XmlNodeList mNodes = de.Value as XmlNodeList;
                mcoBox.Properties.Items.Clear();
                foreach (XmlNode nd in mNodes)
                {
                    mcoBox.Properties.Items.Add(nd.Attributes["value"].Value);
                }
                mcoBox.SelectedIndex = 0;
            }
        }

        private void coBoxZQZL_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(coBoxZQZL.Text))
            {
                this.attrZhuiQiu68gL.Caption = this.coBoxZQZL.SelectedItem.ToString() + "(左)";
                this.attrZhuiQiu68gR.Caption = this.coBoxZQZL.SelectedItem.ToString() + "(右)";
            }
        }

        private void txtANSIPCImpactCheckDesc_DoubleClick(object sender, EventArgs e)
        {
            PCParameterSet.ChooseParameter cp = new Book.UI.produceManager.PCParameterSet.ChooseParameter("BeiZhuShuoMing");
            if (cp.ShowDialog(this) != DialogResult.OK) return;
            if (cp.SelectedItem != null)
            {
                Model.Setting setParam = cp.SelectedItem as Model.Setting;
                this.txtANSIPCImpactCheckDesc.Text += setParam.SettingCurrentValue;
            }
            cp.Dispose();
            GC.Collect();
        }

        private void BEProduct_Click(object sender, EventArgs e)
        {
            Invoices.ChooseProductForm f = new Book.UI.Invoices.ChooseProductForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                this.BEProduct.EditValue = f.SelectedItem;
            }
        }

        #region 审核

        protected override string AuditKeyId()
        {
            return Model.ANSIPCImpactCheck.PRO_ANSIPCImpactCheckID;
        }

        protected override int AuditState()
        {
            return this._ansipcic.AuditState.HasValue ? this._ansipcic.AuditState.Value : 0;
        }

        protected override string tableCode()
        {
            return "ANSIPCImpactCheck" + "," + this._ansipcic.ANSIPCImpactCheckID;
        }

        #endregion

        private void repositoryItemLookUpEdit35_EditValueChanged(object sender, EventArgs e)
        {
            this.gridView1.PostEditor();
            this.gridView1.UpdateCurrentRow();
            Model.ANSIPCImpactCheckDetail model = this.bindingSource1.Current as Model.ANSIPCImpactCheckDetail;
            if (model != null)
            {
                model.attr_15L = model.attr_15R = model.attr0L = model.attr0R = model.attr15L = model.attr15R = model.attr30L = model.attr30R = model.attr45L = model.attr45R = model.attr60L = model.attr60R = model.attr75L = model.attr75R = model.attr90cDown10mmL = model.attr90cDown10mmR = model.attr90cUp10mmL = model.attr90cUp10mmR = model.attr90L = model.attr90R = model.attrChuanTou44_2gL = model.attrChuanTou44_2gR = model.attrHM500gL = model.attrHM500gR = model.attrZhuiQiu68gL = model.attrZhuiQiu68gR = model.CheckAll;
                this.gridControl1.RefreshDataSource();
            }
        }
    }
}
