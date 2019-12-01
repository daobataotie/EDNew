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

namespace Book.UI.Invoices.IP
{
    public partial class EditForm : BaseEditForm
    {
        Model.PackingListHeader packingListHeader = new Model.PackingListHeader();
        BL.PackingListHeaderManager packingListHeaderManager = new Book.BL.PackingListHeaderManager();
        BL.PortManager portManager = new Book.BL.PortManager();

        public EditForm()
        {
            InitializeComponent();

            this.ncc_Customer.Choose = new Settings.BasicData.Customs.ChooseCustoms();
            this.requireValueExceptions.Add(Model.PackingListHeader.PRO_PackingNo, new AA("PackingNo 不能為空！", this.txt_PackingNo));
            this.requireValueExceptions.Add(Model.PackingListHeader.PRO_PackingDate, new AA("Date 不能為空！", this.Date_PackingDate));
            this.requireValueExceptions.Add(Model.PackingListHeader.PRO_CustomerId, new AA("CONSIGNEE 不能為空！", this.ncc_Customer));
            this.requireValueExceptions.Add(Model.PackingListHeader.PRO_PerSS, new AA("PerSS 不能為空！", this.txt_PerSS));
            this.requireValueExceptions.Add(Model.PackingListHeader.PRO_SailingOnOrAbout, new AA("SailingOnOrAbout 不能為空！", this.date_Sailing));
            this.requireValueExceptions.Add(Model.PackingListHeader.PRO_FromPortId, new AA("From 不能為空！", this.lue_From));
            this.requireValueExceptions.Add(Model.PackingListHeader.PRO_ToPortId, new AA("TO 不能為空！", this.lue_TO));

            this.requireValueExceptions.Add(Model.PackingListDetail.PRO_PLTNo, new AA("PLTNo 不能為空！", this.gridControl3));
            this.requireValueExceptions.Add(Model.PackingListDetail.PRO_CartonNo, new AA("CartonNo 不能為空！", this.gridControl3));

            this.action = "view";

            //设置单位
            this.bindingSourcePort.DataSource = portManager.Select();
            var unitList = new BL.ProductUnitManager().Select().GroupBy(U => U.CnName).Select(D => D.Key).ToList();
            unitList.ForEach(U =>
            {
                this.cob_Unit.Properties.Items.Add(U);
            });
        }

        int LastFlag = 0; //页面载 入时是否执行 last方法
        public EditForm(string invoiceId)
            : this()
        {
            this.packingListHeader = this.packingListHeaderManager.Get(invoiceId);
            if (this.packingListHeader == null)
                throw new ArithmeticException("invoiceid");
            this.action = "view";
            if (this.action == "view")
                LastFlag = 1;
        }

        public EditForm(Model.PackingListHeader invoice)
            : this()
        {
            if (invoice == null)
                throw new ArithmeticException("invoiceid");
            this.packingListHeader = invoice;
            this.action = "view";
            if (this.action == "view")
                LastFlag = 1;
        }


        //public override BaseListForm GetListForm()
        //{
        //    return new ListForm();
        //}

        public override Book.Model.Invoice Invoice
        {
            get
            {
                return packingListHeader;
            }
            set
            {
                if (value is Model.PackingListHeader)
                {
                    packingListHeader = packingListHeaderManager.Get((value as Model.PackingListHeader).PackingNo);
                }
            }
        }


        protected override void AddNew()
        {
            this.packingListHeader = new Book.Model.PackingListHeader();
            packingListHeader.PackingDate = DateTime.Now;
            this.cob_Unit.Text = "PCS";


            this.action = "insert";
        }

        public override void Refresh()
        {
            if (this.packingListHeader == null)
                this.AddNew();
            else
            {
                if (this.action == "view" || this.action == "update")  //打印時去掉PLTNO，修改時刷新一下顯示出來
                {
                    this.packingListHeader = this.packingListHeaderManager.GetDetail(this.packingListHeader.PackingNo);
                }
            }

            this.txt_PackingNo.Text = this.packingListHeader.PackingNo;
            this.Date_PackingDate.EditValue = this.packingListHeader.PackingDate;
            this.ncc_Customer.EditValue = this.packingListHeader.Customer;
            this.txt_CustomerName.Text = this.packingListHeader.CustomerFullName;
            this.txt_ADDRESS.Text = this.packingListHeader.CustomerAddress;
            this.txt_PerSS.Text = this.packingListHeader.PerSS;
            this.date_Sailing.EditValue = this.packingListHeader.SailingOnOrAbout;
            this.lue_From.EditValue = this.packingListHeader.FromPortId;
            this.lue_TO.EditValue = this.packingListHeader.ToPortId;
            this.txt_MarkNos.Text = this.packingListHeader.MarkNos;
            this.cob_Unit.Text = this.packingListHeader.Unit;

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

            this.bindingSourceDetail.DataSource = this.packingListHeader.Details;

            base.Refresh();

            //if (this.action == "update")
            //    this.txt_PackingNo.Properties.ReadOnly = true;
        }

        protected override void Save(Helper.InvoiceStatus status)
        {
            string tempID = this.packingListHeader.PackingNo;

            if (!this.gridView3.PostEditor() || !this.gridView3.UpdateCurrentRow())
                return;

            this.packingListHeader.PackingNo = this.txt_PackingNo.Text.Trim();
            if (this.Date_PackingDate.EditValue != null)
                this.packingListHeader.PackingDate = this.Date_PackingDate.DateTime;
            if (this.ncc_Customer.EditValue != null)
            {
                this.packingListHeader.CustomerId = (this.ncc_Customer.EditValue as Model.Customer).CustomerId;
                this.packingListHeader.Customer = this.ncc_Customer.EditValue as Model.Customer;
            }
            this.packingListHeader.CustomerFullName = this.txt_CustomerName.Text;
            this.packingListHeader.CustomerAddress = this.txt_ADDRESS.Text;
            this.packingListHeader.PerSS = this.txt_PerSS.Text;
            if (this.date_Sailing.EditValue != null)
                this.packingListHeader.SailingOnOrAbout = this.date_Sailing.DateTime;
            this.packingListHeader.FromPortId = this.lue_From.EditValue == null ? null : this.lue_From.EditValue.ToString();
            this.packingListHeader.ToPortId = this.lue_TO.EditValue == null ? null : this.lue_TO.EditValue.ToString();
            this.packingListHeader.MarkNos = this.txt_MarkNos.Text;
            this.packingListHeader.Unit = this.cob_Unit.Text;

            if (this.action == "insert")
                this.packingListHeaderManager.Insert(this.packingListHeader);
            if (this.action == "update")
                this.packingListHeaderManager.Update(this.packingListHeader, tempID);
        }

        protected override void MoveLast()
        {
            if (this.LastFlag == 1)
            {
                this.LastFlag = 0;
                return;
            }
            this.packingListHeader = this.packingListHeaderManager.GetLast();
        }

        protected override void MoveFirst()
        {
            this.packingListHeader = this.packingListHeaderManager.GetFirst();
        }

        protected override void MovePrev()
        {
            Model.PackingListHeader model = this.packingListHeaderManager.GetPrev(this.packingListHeader);
            if (model == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);
            this.packingListHeader = model;
        }

        protected override void MoveNext()
        {
            Model.PackingListHeader model = this.packingListHeaderManager.GetNext(this.packingListHeader);
            if (model == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);
            this.packingListHeader = model;
        }

        protected override bool HasRows()
        {
            return this.packingListHeaderManager.HasRows();
        }

        protected override bool HasRowsPrev()
        {
            return this.packingListHeaderManager.HasRowsBefore(this.packingListHeader);
        }

        protected override bool HasRowsNext()
        {
            return this.packingListHeaderManager.HasRowsAfter(this.packingListHeader);
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
            if (this.packingListHeader == null)
                return;
            if (MessageBox.Show(Properties.Resources.ConfirmToDelete, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.packingListHeaderManager.Delete(this.packingListHeader.PackingNo);
                this.packingListHeader = this.packingListHeaderManager.GetNext(this.packingListHeader);
                if (this.packingListHeader == null)
                    this.packingListHeader = this.packingListHeaderManager.GetLast();
            }
        }

        public override BaseListForm GetListForm()
        {
            return new ListForm();
        }

        protected override DevExpress.XtraReports.UI.XtraReport GetReport()
        {
            return new RO(this.packingListHeader);
        }

        // 添加客户订单
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.ncc_Customer.EditValue == null)
            {
                MessageBox.Show("請先選擇客戶", "提示", MessageBoxButtons.OK);
                return;
            }

            if (packingListHeader.Details == null)
                packingListHeader.Details = new List<Model.PackingListDetail>();

            XS.SearcharInvoiceXSForm f = new Book.UI.Invoices.XS.SearcharInvoiceXSForm(this.ncc_Customer.EditValue as Model.Customer);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                if (f.key != null && f.key.Count > 0)
                {
                    Model.PackingListDetail packingDetail = null;

                    foreach (Model.InvoiceXODetail detail in f.key)
                    {
                        packingDetail = new Book.Model.PackingListDetail();
                        packingDetail.CartonQty = 1;
                        packingDetail.PackingListDetailId = Guid.NewGuid().ToString();
                        packingDetail.Product = detail.Product;
                        packingDetail.ProductId = detail.ProductId;
                        packingDetail.PONo = detail.Invoice.CustomerInvoiceXOId;
                        packingDetail.PackingListHeader = this.packingListHeader;
                        packingDetail.InvoiceXODetail = detail;
                        packingDetail.InvoiceXODetailId = detail.InvoiceXODetailId;

                        packingListHeader.Details.Add(packingDetail);
                    }
                }

                this.bindingSourceDetail.DataSource = packingListHeader.Details;
                this.gridControl3.RefreshDataSource();
                this.bindingSourceDetail.MoveLast();

            }
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.bindingSourceDetail.Current == null)
                return;

            Model.PackingListDetail detail = this.bindingSourceDetail.Current as Model.PackingListDetail;
            this.packingListHeader.Details.Remove(detail);

            this.gridControl3.RefreshDataSource();
        }

        private void ncc_Customer_EditValueChanged(object sender, EventArgs e)
        {
            if (this.action == "view")
                return;

            this.txt_CustomerName.Text = null;
            this.txt_ADDRESS.Text = null;

            if (this.ncc_Customer.EditValue != null)
            {
                Model.Customer c = this.ncc_Customer.EditValue as Model.Customer;

                this.txt_CustomerName.Text = c.CustomerFullName;
                this.txt_ADDRESS.Text = c.CustomerAddress;

                this.packingListHeader.Customer = c;
            }
        }

        protected override string tableCode()
        {
            return "PackingList";
        }

        protected override int AuditState()
        {
            return this.packingListHeader.AuditState.HasValue ? this.packingListHeader.AuditState.Value : 0;
        }

        private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string str = e.Value.ToString();
            Model.PackingListDetail detail = this.bindingSourceDetail.Current as Model.PackingListDetail;

            if (e.Column.Name == "gridColumn2")
            {
                if (!string.IsNullOrEmpty(str) && (str.Contains('-') || str.Contains('_') || str.Contains('~')))
                {
                    string[] cartonNos = null;
                    if (str.Contains('-'))
                        cartonNos = str.Split('-');
                    else if (str.Contains('_'))
                        cartonNos = str.Split('_');
                    else
                        cartonNos = str.Split('~');

                    try
                    {
                        int startNo = int.Parse(cartonNos[0]);
                        int endNo = int.Parse(cartonNos[1]);
                        if (endNo >= startNo)
                        {
                            //还原数量到最初状态
                            if (detail.CartonQty > 1)
                            {
                                detail.Quantity = (detail.Quantity.HasValue ? detail.Quantity.Value : 0) / detail.CartonQty;
                                detail.NetWeight = (detail.NetWeight.HasValue ? detail.NetWeight.Value : 0) / detail.CartonQty;
                                detail.GrossWeight = (detail.GrossWeight.HasValue ? detail.GrossWeight.Value : 0) / detail.CartonQty;
                            }


                            //根据现在的箱数计算数量
                            detail.CartonQty = endNo - startNo + 1;
                            detail.Quantity = (detail.Quantity.HasValue ? detail.Quantity.Value : 0) * detail.CartonQty;
                            detail.NetWeight = (detail.NetWeight.HasValue ? detail.NetWeight.Value : 0) * detail.CartonQty;
                            detail.GrossWeight = (detail.GrossWeight.HasValue ? detail.GrossWeight.Value : 0) * detail.CartonQty;
                        }
                    }
                    catch
                    {
                        return;
                    }
                }
                else
                {
                    detail.CartonNo = e.Value + "-" + e.Value;

                    if (detail.CartonQty > 1)
                    {
                        detail.Quantity = (detail.Quantity.HasValue ? detail.Quantity.Value : 0) / detail.CartonQty;
                        detail.NetWeight = (detail.NetWeight.HasValue ? detail.NetWeight.Value : 0) / detail.CartonQty;
                        detail.GrossWeight = (detail.GrossWeight.HasValue ? detail.GrossWeight.Value : 0) / detail.CartonQty;

                        detail.CartonQty = 1;
                    }
                }

                //else
                //{
                //    if (detail.CartonQty > 1)
                //    {
                //        detail.Quantity = (detail.Quantity.HasValue ? detail.Quantity.Value : 0) / detail.CartonQty;
                //        detail.NetWeight = (detail.NetWeight.HasValue ? detail.NetWeight.Value : 0) / detail.CartonQty;
                //        detail.GrossWeight = (detail.GrossWeight.HasValue ? detail.GrossWeight.Value : 0) / detail.CartonQty;
                //    }
                //}

            }
            else if (e.Column.Name == "gridColumn6")
            {
                decimal qty = 0;
                decimal.TryParse(str, out qty);
                detail.Quantity = qty * detail.CartonQty;
            }
            else if (e.Column.Name == "gridColumn7")
            {
                decimal netWeight = 0;
                decimal.TryParse(str, out netWeight);
                detail.NetWeight = netWeight * detail.CartonQty;
            }
            else if (e.Column.Name == "gridColumn8")
            {
                decimal grossWeight = 0;
                decimal.TryParse(str, out grossWeight);
                detail.GrossWeight = grossWeight * detail.CartonQty;
            }

            this.gridControl3.RefreshDataSource();
        }

        private void cob_Unit_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.cob_Unit.Text))
            {
                this.gridColumn6.DisplayFormat.FormatString = string.Format("@0.## {0}", this.cob_Unit.Text);
                this.gridColumn9.DisplayFormat.FormatString = string.Format("0.## {0}", this.cob_Unit.Text);
            }
            else
            {
                this.gridColumn6.DisplayFormat.FormatString = string.Format("@0.## {0}", "PCS");
                this.gridColumn9.DisplayFormat.FormatString = string.Format("0.## {0}", "PCS");
            }
        }
    }
}
