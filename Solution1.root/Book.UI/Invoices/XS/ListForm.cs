using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace Book.UI.Invoices.XS
{
    public partial class ListForm : BaseListForm
    {
        private Model.InvoiceXO invoiceXO;
        int tag = 0;
        DataTable dtHeader = new DataTable();

        public ListForm()
        {
            InitializeComponent();
            this.invoiceManager = new BL.InvoiceXSManager();

            this.gridView1.LevelIndent = 0;
        }

        public ListForm(Model.InvoiceXO xo)
        {
            InitializeComponent();
            this.invoiceManager = new BL.InvoiceXSManager();
            this.invoiceXO = xo;

        }

        public ListForm(string InvoiceCusId)
            : this()
        {
            this.tag = 1;

            //this.bindingSource1.DataSource = ((BL.InvoiceXSManager)this.invoiceManager).SelectDateRangAndWhere(null, null, global::Helper.DateTimeParse.NullDate, global::Helper.DateTimeParse.EndDate, global::Helper.DateTimeParse.NullDate, global::Helper.DateTimeParse.EndDate, InvoiceCusId, null, null, null, null, null, null,null,null);

            this.bindingSource1.DataSource = ((BL.InvoiceXSManager)this.invoiceManager).SelectDateRangAndWhereToTable(null, null, global::Helper.DateTimeParse.NullDate, global::Helper.DateTimeParse.EndDate, global::Helper.DateTimeParse.NullDate, global::Helper.DateTimeParse.EndDate, InvoiceCusId, null, null, null, null, null, null, null, null, null, null);

            this.gridControl1.RefreshDataSource();
        }

        private void ListForm_Load(object sender, EventArgs e)
        {
            if (this.tag == 1)
                return;

            ShowSearchForm();
        }

        protected override Form GetViewForm()
        {
            //Model.InvoiceXS invoice = this.SelectedItem as Model.InvoiceXS;
            //if (invoice != null)
            //    return new EditForm(invoice.InvoiceId);
            //DataRowView dr = this.bindingSource1.Current as DataRowView;
            DataRow dr = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
            if (dr != null)
                return new EditForm(dr["InvoiceId"].ToString());

            return null;
        }

        protected override void ShowSearchForm()
        {
            if (this.tag == 1)
            {
                this.tag = 0;
                return;
            }
            Query.ConditionXChooseForm f = new Query.ConditionXChooseForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                Query.ConditionX con = f.Condition as Query.ConditionX;
                DataTable dtDetail = new DataTable();

                //this.bindingSource1.DataSource = ((BL.InvoiceXSManager)this.invoiceManager).SelectDateRangAndWhere(con.Customer1, con.Customer2, con.StartDate, con.EndDate, con.Yjri1, con.Yjri2, con.CusXOId, con.Product, con.Product2, con.XOId1, con.XOId2, con.FreightedCompanyId, con.ConveyanceMethodId, con.Employee1, con.Employee2);
                dtDetail = ((BL.InvoiceXSManager)this.invoiceManager).SelectDateRangAndWhereToTable(con.Customer1, con.Customer2, con.StartDate, con.EndDate, con.Yjri1, con.Yjri2, con.CusXOId, con.Product, con.Product2, con.XOId1, con.XOId2, con.FreightedCompanyId, con.ConveyanceMethodId, con.Employee1, con.Employee2, con.Product_Id, con.ProductCategoryId);

                if (dtDetail != null || dtDetail.Rows.Count > 0)
                {
                    dtHeader = dtDetail.Clone();
                    dtHeader.Columns.Add("XSId");

                    for (int i = 0; i < dtDetail.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            DataRow dr = dtHeader.NewRow();
                            dr.ItemArray = dtDetail.Rows[i].ItemArray;
                            dr["CustomerInvoiceXOId"] = "";
                            dtHeader.Rows.Add(dr);
                        }
                        else
                        {
                            if (dtDetail.Rows[i]["InvoiceId"].ToString() == dtDetail.Rows[i - 1]["InvoiceId"].ToString())
                            {
                                dtHeader.Rows[dtHeader.Rows.Count - 1]["XOMoney"] = Convert.ToDecimal(dtHeader.Rows[dtHeader.Rows.Count - 1]["XOMoney"]) + Convert.ToDecimal(dtDetail.Rows[i]["XOMoney"]);
                                dtHeader.Rows[dtHeader.Rows.Count - 1]["XSMoney"] = Convert.ToDecimal(dtHeader.Rows[dtHeader.Rows.Count - 1]["XSMoney"]) + Convert.ToDecimal(dtDetail.Rows[i]["XSMoney"]);
                            }
                            else
                            {
                                DataRow dr = dtHeader.NewRow();
                                dr.ItemArray = dtDetail.Rows[i].ItemArray;
                                dr["CustomerInvoiceXOId"] = "";
                                dtHeader.Rows.Add(dr);
                            }
                        }

                        dtDetail.Rows[i]["Employee0"] = "";
                        dtDetail.Rows[i]["Customer"] = "";
                        dtDetail.Rows[i]["Depot"] = "";
                        dtDetail.Rows[i]["InvoiceDate"] = DBNull.Value;
                        dtDetail.Rows[i]["InvoiceNote"] = "";
                    }

                    DataSet ds = new DataSet();
                    ds.Tables.Add(dtHeader);
                    ds.Tables.Add(dtDetail);

                    ds.Relations.Add(dtHeader.Columns["InvoiceId"], dtDetail.Columns["InvoiceId"]);

                    this.gridView1.OptionsDetail.ShowDetailTabs = false;
                    this.gridControl1.DataSource = this.bindingSource1.DataSource = dtHeader;
                    this.gridControl1.RefreshDataSource();
                }
            }
            else
            {
                this.Dispose();
                this.Close();
            }
            this.barStaticItem1.Caption = string.Format("{0}По", this.bindingSource1.Count);
            f.Dispose();
            GC.Collect();
        }

        protected override DevExpress.XtraReports.UI.XtraReport GetReport()
        {
            //return new R02(this.bindingSource1.DataSource as IList<Model.InvoiceXS>);
            return new R02(dtHeader);
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView MainView
        {
            get
            {
                return this.gridView1;
            }
        }

        private void gridControl1_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            GridView gv = e.View as GridView;
            gv.OptionsView.ShowColumnHeaders = false;
            gv.OptionsView.ShowIndicator = false;
            gv.OptionsView.ShowFooter = false;
            gv.OptionsView.ShowAutoFilterRow = false;

            foreach (GridColumn gc in gv.Columns)
            {
                foreach (GridColumn item in this.gridView1.Columns)
                {
                    if (gc.FieldName == item.FieldName)
                    {
                        gc.ColumnEdit = item.ColumnEdit;
                        gc.Width = item.Width;
                        gc.VisibleIndex = item.VisibleIndex;
                    }
                }
            }

            //gv.Columns[""]
        }
    }
}