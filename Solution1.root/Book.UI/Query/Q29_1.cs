using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.Query
{

    /*----------------------------------------------------------------
// Copyright (C) 2008 - 2010  咸阳飛馳軟件有限公司
//                     版權所有 圍著必究

// 编 码 人: 裴盾             完成时间:2009-6-14
// 修改原因：
// 修 改 人:                          修改时间:
// 修改原因：
// 修 改 人:                          修改时间:
//----------------------------------------------------------------*/
    public partial class Q29_1 : DevExpress.XtraReports.UI.XtraReport
    {
        private BL.InvoiceXSDetailManager xsDetailManager = new Book.BL.InvoiceXSDetailManager();

        private Model.InvoiceXS invoice;

        public Model.InvoiceXS Invoice
        {
            get { return invoice; }
            set { invoice = value; }
        }


        /// <summary>
        /// 无参构造
        /// </summary>
        public Q29_1()
        {
            InitializeComponent();

            this.xrTableCellProductId.DataBindings.Add("Text", this.DataSource, Model.InvoiceXSDetail.PRO_PrimaryKeyId);
            this.xrTableCellProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            this.xrTableCellQuantity.DataBindings.Add("Text", this.DataSource, Model.InvoiceXSDetail.PRO_InvoiceXSDetailQuantity);
            this.xrTableCellUnit.DataBindings.Add("Text", this.DataSource, Model.InvoiceXSDetail.PRO_InvoiceProductUnit);
            //this.xrTableCellUnitPrice.DataBindings.Add("Text", this.DataSource, Model.InvoiceXSDetail.PROPERTY_INVOICEXSDETAILPRICE, "{0:0}");
            //this.xrTableCell1TotalMoney.DataBindings.Add("Text", this.DataSource, Model.InvoiceXSDetail.PROPERTY_INVOICEXSDETAILMONEY0, "{0:0}");

            this.xrTableCellTotalHeji.Summary.Running = SummaryRunning.Report;
            this.xrTableCellTotalHeji.Summary.IgnoreNullValues = true;
            this.xrTableCellTotalHeji.Summary.Func = SummaryFunc.Sum;
            this.xrTableCellTotalHeji.Summary.FormatString = "{0:0}";
            //this.xrTableCellTotalHeji.DataBindings.Add("Text", this.DataSource, Model.InvoiceXSDetail.PROPERTY_INVOICEXSDETAILMONEY0, "{0:0}");
        

        }

        private void Q29_1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.bindingSource1.DataSource = this.xsDetailManager.Select(this.invoice);
        }

    }
}
