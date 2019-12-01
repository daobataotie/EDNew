using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.Invoices.LH
{
    public partial class RO : DevExpress.XtraReports.UI.XtraReport
    {
        public RO(Model.InvoiceLH invoice)
        {
            InitializeComponent();

            this.DataSource = invoice.Detail;

            lbl_CompanyName.Text = BL.Settings.CompanyChineseName;
            lbl_InvoiceId.Text = invoice.InvoiceId;
            lbl_Customer.Text = invoice.Customer == null ? "" : invoice.Customer.CustomerShortName;
            lbl_ReportDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbl_ConveyanceMethod.Text = invoice.ConveyanceMethod == null ? "" : invoice.ConveyanceMethod.ConveyanceMethodName;
            lbl_InvoiceDate.Text = invoice.InvoiceDate.Value.ToString("yyyy-MM-dd");

            TC_No.DataBindings.Add("Text", this.DataSource, Model.InvoiceLHDetail.PRO_Number);
            TCProductId.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_Id);
            TCKehuPinhao.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_CustomerProductName);
            TC_InvoiceXOCusId.DataBindings.Add("Text", this.DataSource, Model.InvoiceLHDetail.PRO_InvoiceXOCusId);
            TCCustomerProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            TC_EstimateQty.DataBindings.Add("Text", this.DataSource, Model.InvoiceLHDetail.PRO_EstimateQty);
            TCProductUnit.DataBindings.Add("Text", this.DataSource, Model.InvoiceLHDetail.PRO_ProductUnit);
            TC_BoxCapacityQty.DataBindings.Add("Text", this.DataSource, Model.InvoiceLHDetail.PRO_BoxCapacityQty);
            TCBoxNumber.DataBindings.Add("Text", this.DataSource, Model.InvoiceLHDetail.PRO_BoxNumber);
            TCBoxQty.DataBindings.Add("Text", this.DataSource, Model.InvoiceLHDetail.PRO_BoxQty);
            TCNote.DataBindings.Add("Text", this.DataSource, Model.InvoiceLHDetail.PRO_Note);

            lbl_EmpCreater.Text = invoice.EmpCreater == null ? "" : invoice.EmpCreater.EmployeeName;
            //lbl_EmpShengguan.Text = invoice.EmpShengguan == null ? "" : invoice.EmpShengguan.EmployeeName;
            //lbl_EmpShechu.Text = invoice.EmpShechu == null ? "" : invoice.EmpShechu.EmployeeName;
            //lbl_EmpPinjian.Text=invoice.EmpPinjian==null?"":invoice.EmpPinjian.EmployeeName;
            //lbl_EmpDepot.Text = invoice.EmpDepot == null ? "" : invoice.EmpDepot.EmployeeName;

        }
    }
}
