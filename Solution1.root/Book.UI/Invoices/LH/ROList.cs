using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.Invoices.LH
{
    public partial class ROList : DevExpress.XtraReports.UI.XtraReport
    {
        public ROList(System.Collections.Generic.IList<Model.InvoiceLHDetail> list)
        {
            InitializeComponent();

            this.DataSource = list;

            this.lbl_CompanyName.Text = BL.Settings.CompanyChineseName;
            this.lbl_ReportDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            TC_InvoiceId.DataBindings.Add("Text", this.DataSource, "InvoiceLH." + Model.InvoiceLH.PRO_InvoiceId);
            TC_YujiaoDate.DataBindings.Add("Text", this.DataSource, "InvoiceLH." + Model.InvoiceLH.PRO_InvoiceDate, "{0:yyyy-MM-dd}");
            TCProductId.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_Id);
            TC_InvoiceXOCusId.DataBindings.Add("Text", this.DataSource, Model.InvoiceLHDetail.PRO_InvoiceXOCusId);
            TCCustomerProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_CustomerProductName);
            TC_EstimateQty.DataBindings.Add("Text", this.DataSource, Model.InvoiceLHDetail.PRO_EstimateQty);
            TCProductUnit.DataBindings.Add("Text", this.DataSource, Model.InvoiceLHDetail.PRO_ProductUnit);
            TC_BoxCapacityQty.DataBindings.Add("Text", this.DataSource, Model.InvoiceLHDetail.PRO_BoxCapacityQty);
            TCBoxNumber.DataBindings.Add("Text", this.DataSource, Model.InvoiceLHDetail.PRO_BoxNumber);
            TCBoxQty.DataBindings.Add("Text", this.DataSource, Model.InvoiceLHDetail.PRO_BoxQty);
            TCNote.DataBindings.Add("Text", this.DataSource, Model.InvoiceLHDetail.PRO_Note);

        }
    }
}
