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

// 编 码 人:  够波涛             完成时间:2009-6-15
// 修改原因：
// 修 改 人:                          修改时间:
// 修改原因：
// 修 改 人:                          修改时间:
//----------------------------------------------------------------*/
    public partial class Q22 : BaseReport
    {
        private BL.InvoiceXSManager invoiceManager = new Book.BL.InvoiceXSManager();

        //一参构造
        public Q22(ConditionA condition)
        {
            InitializeComponent();
            this.xrLabelReportName.Text = Properties.Resources.CHJYB;
            this.xrLabelDateRange.Text = string.Format(Properties.Resources.DateRange, condition.StartDate.ToString("yyyy/MM/dd"), condition.EndDate.ToString("yyyy/MM/dd"));

            System.Collections.Generic.IList<Model.InvoiceXS> list = this.invoiceManager.Select(condition.StartDate, condition.EndDate);
            if (list == null || list.Count <= 0)
            {
                throw new global::Helper.InvalidValueException();
            }
            this.bindingSource1.DataSource = list;

            this.xrTableCellKind.Text = Properties.Resources.XS;
            //this.xrTableCellTax.DataBindings.Add("Text", this.DataSource, Model.InvoiceXS.PROPERTY_INVOICETAX, "{0:0}");
            //this.xrTableCellCompanyName.DataBindings.Add("Text", this.DataSource, "Company." + Model.Company.PROPERTY_COMPANYNAME1);
            //this.xrTableCellFpbh.DataBindings.Add("Text", this.DataSource, Model.InvoiceXS.PROPERTY_INVOICEFPBH);
            this.xrTableCellInvoiceDate.DataBindings.Add("Text", this.DataSource, Model.Invoice.PROPERTY_INVOICEDATE, "{0:yyyy-MM-dd}");
            //this.xrTableCellInvoiceHeji.DataBindings.Add("Text", this.DataSource, Model.InvoiceXS.PROPERTY_INVOICEHEJI, "{0:0}");
            this.xrTableCellInvoiceId.DataBindings.Add("Text", this.DataSource, Model.InvoiceXS.PROPERTY_INVOICEID);
            //this.xrTableCellInvoiceZongji.DataBindings.Add("Text", this.DataSource, Model.InvoiceXS.PROPERTY_INVOICEZONGJI, "{0:0}");

            this.xrLabelTax.Summary.FormatString = "{0:0}";
            this.xrLabelZongji.Summary.FormatString = "{0:0}";
            this.xrLabelHeJi.Summary.FormatString = "{0:0}";

            this.xrLabelTax.Summary.Func = SummaryFunc.Sum;
            this.xrLabelZongji.Summary.Func = SummaryFunc.Sum;
            this.xrLabelHeJi.Summary.Func = SummaryFunc.Sum;

            this.xrLabelTax.Summary.IgnoreNullValues = true;
            this.xrLabelZongji.Summary.IgnoreNullValues = true;
            this.xrLabelHeJi.Summary.IgnoreNullValues = true;

            this.xrLabelTax.Summary.Running = SummaryRunning.Report;
            this.xrLabelZongji.Summary.Running = SummaryRunning.Report;
            this.xrLabelHeJi.Summary.Running = SummaryRunning.Report;

            //this.xrLabelHeJi.DataBindings.Add("Text", this.DataSource, Model.InvoiceXS.PROPERTY_INVOICEHEJI, "{0:0}");
            //this.xrLabelTax.DataBindings.Add("Text", this.DataSource, Model.InvoiceXS.PROPERTY_INVOICETAX, "{0:0}");
            //this.xrLabelZongji.DataBindings.Add("Text", this.DataSource, Model.InvoiceXS.PROPERTY_INVOICEZONGJI, "{0:0}");

        }

    }
}
