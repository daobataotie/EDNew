using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;

namespace Book.UI.Invoices.XJ
{
    public partial class RoSubCB_Pack : DevExpress.XtraReports.UI.XtraReport
    {
        public Model.InvoiceXJ _InvoiceXJ { get; set; }

        public RoSubCB_Pack()
        {
            InitializeComponent();
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(RoSubCB_Pack_BeforePrint);
            if (this._InvoiceXJ != null)
                this.TCGuanXiao_Pack.Text += this._InvoiceXJ.GuanXiaoPack.ToString();

            //Binding
            this.TCProductName.DataBindings.Add("Text", this.DataSource, Model.InvoiceXJPackageDetails.PRO_ProductName);
            this.TCInvoiceXJPackageDetailsQuantity.DataBindings.Add("Text", this.DataSource, Model.InvoiceXJPackageDetails.PRO_InvoiceXJPackageDetailsQuantity, "{0:0.###}");
            this.TCInvoiceXJPackageDetailsType.DataBindings.Add("Text", this.DataSource, Model.InvoiceXJPackageDetails.PRO_InvoiceXJPackageDetailsType);
            this.TCInvoiceXJProcessCB1.DataBindings.Add("Text", this.DataSource, Model.InvoiceXJPackageDetails.PRO_InvoiceXJProcessCB1, "{0:0.####}");
            this.TCInvoiceXJProcessCB2.DataBindings.Add("Text", this.DataSource, Model.InvoiceXJPackageDetails.PRO_InvoiceXJProcessCB2, "{0:0.####}");
            this.TCPackagePrice.DataBindings.Add("Text", this.DataSource, Model.InvoiceXJPackageDetails.PRO_PackagePrice, "{0:0.####}");
            //this.TCProcessCategory.DataBindings.Add("Text", this.DataSource, "ProcessCategory." + Model.ProcessCategory.PROPERTY_PROCESSCATEGORYNAME);
            this.TCSupplier.DataBindings.Add("Text", this.DataSource, "Supplier." + Model.Supplier.PROPERTY_SUPPLIERSHORTNAME);
            this.RTPackageDesc.DataBindings.Add("Rtf", this.DataSource, Model.InvoiceXJPackageDetails.PRO_Description);
            this.TCUnitPrice.DataBindings.Add("Text", DataSource, Model.InvoiceXJPackageDetails.PRO_DanJia, "{0:0.####}");

            this.TCInvoiceXJProcessCB1Total.Summary.FormatString = "{0:0.####}";
            this.TCInvoiceXJProcessCB1Total.Summary.Func = SummaryFunc.Sum;
            this.TCInvoiceXJProcessCB1Total.Summary.IgnoreNullValues = true;
            this.TCInvoiceXJProcessCB1Total.Summary.Running = SummaryRunning.Report;
            this.TCInvoiceXJProcessCB1Total.DataBindings.Add("Text", this.DataSource, Model.InvoiceXJPackageDetails.PRO_InvoiceXJProcessCB1, "{0:0}");
            this.TCInvoiceXJProcessCB2Total.Summary.FormatString = "{0:0.####}";
            this.TCInvoiceXJProcessCB2Total.Summary.Func = SummaryFunc.Sum;
            this.TCInvoiceXJProcessCB2Total.Summary.IgnoreNullValues = true;
            this.TCInvoiceXJProcessCB2Total.Summary.Running = SummaryRunning.Report;
            this.TCInvoiceXJProcessCB2Total.DataBindings.Add("Text", this.DataSource, Model.InvoiceXJPackageDetails.PRO_InvoiceXJProcessCB2, "{0:0}");
            this.TCPackagePriceTotal.Summary.FormatString = "{0:0.####}";
            this.TCPackagePriceTotal.Summary.Func = SummaryFunc.Sum;
            this.TCPackagePriceTotal.Summary.IgnoreNullValues = true;
            this.TCPackagePriceTotal.Summary.Running = SummaryRunning.Report;
            this.TCPackagePriceTotal.DataBindings.Add("Text", this.DataSource, Model.InvoiceXJPackageDetails.PRO_PackagePrice, "{0:0}");
        }

        private void RoSubCB_Pack_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var list = (from item in this._InvoiceXJ.DetailPackage
                        orderby item.Inumber ascending
                        select item).ToList<Model.InvoiceXJPackageDetails>();
            foreach (var item in list)
            {
                item.InvoiceXJProcessCB1 = item.InvoiceXJProcessCB1 == 0 ? null : item.InvoiceXJProcessCB1;
                item.InvoiceXJProcessCB2 = item.InvoiceXJProcessCB2 == 0 ? null : item.InvoiceXJProcessCB2;
                item.PackagePrice = item.PackagePrice == 0 ? null : item.PackagePrice;
                item.DanJia = item.DanJia == 0 ? null : item.DanJia;
            }
            this.DataSource = list;
            this.TCGuanXiao_Pack.Text += this._InvoiceXJ.GuanXiaoPack == 0 ? "    " : this._InvoiceXJ.GuanXiaoPack.Value.ToString();
        }
    }
}
