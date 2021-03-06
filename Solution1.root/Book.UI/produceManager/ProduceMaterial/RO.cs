﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.produceManager.ProduceMaterial
{
    public partial class RO : DevExpress.XtraReports.UI.XtraReport
    {
        private BL.ProduceMaterialManager produceMaterialManager = new Book.BL.ProduceMaterialManager();
        private BL.ProduceMaterialdetailsManager produceMaterialdetailsManager = new Book.BL.ProduceMaterialdetailsManager();
        BL.InvoiceXOManager invoiceXoManager = new BL.InvoiceXOManager();
        BL.PronoteHeaderManager ph = new BL.PronoteHeaderManager();
        private Model.ProduceMaterial produceMaterial;
        public RO(string produceMaterialID)
        {
            InitializeComponent();
            this.produceMaterial = this.produceMaterialManager.Get(produceMaterialID);
            if (this.produceMaterial == null)
                return;
            if (this.produceMaterial.SourceType == 0)
            {
                Model.PronoteHeader pheader = ph.Get(produceMaterial.InvoiceId);
                if (pheader != null)
                {
                    this.xrLabelProduct.Text = string.IsNullOrEmpty(pheader.Product.CustomerProductName) ? pheader.Product.ProductName : pheader.Product.ProductName + "{" + pheader.Product.CustomerProductName + "}";
                    this.xrLabelInvoiceSum.Text = pheader.InvoiceXODetailQuantity == null ? null : pheader.InvoiceXODetailQuantity.ToString();
                }
            }
            this.produceMaterial.Details = this.produceMaterialdetailsManager.Select(this.produceMaterial);
            this.DataSource = this.produceMaterial.Details;
            //CompanyInfo
            this.xrLabelCompanyInfoName.Text = BL.Settings.CompanyChineseName;
            this.xrLabelDataName.Text = Properties.Resources.ProduceMaterialdetails;
            //加工领料
            this.xrLabelProduceMaterialDate.Text = this.produceMaterial.ProduceMaterialDate.Value.ToString("yyyy-MM-dd");
            this.xrBarCodeProduceMaterialID.Text = this.produceMaterial.ProduceMaterialID;
            this.xrLabelInsertTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            if (this.produceMaterial.SourceType == 1)
            {
                this.xrLabelSourceType.Text = "需求計劃";
            }
            else { this.xrLabelSourceType.Text = "生產加工"; }
            this.xrLabelPronoteHeaderID.Text = this.produceMaterial.InvoiceId;
            // this.xrLabelMRP.Text=this.produceMaterial.


            //if (this.produceMaterial.Employee1 != null)
            //{
            //    this.xrLabelEmployee1.Text = this.produceMaterial.Employee1.EmployeeName;
            //}
            if (this.produceMaterial.Employee0 != null)
            {
                this.xrLabelEmployee0.Text = this.produceMaterial.Employee0.EmployeeName;
            }

            if (this.produceMaterial.AuditEmp != null)
                this.xrLabelEmployee2.Text = this.produceMaterial.AuditEmp.EmployeeName;

            if (this.produceMaterial.WorkHouse != null)
            {
                this.xrLabelDepartment.Text = this.produceMaterial.WorkHouse.Workhousename;
            }
            this.xrLabel1ProduceMaterialdesc.Text = this.produceMaterial.ProduceMaterialdesc;
            this.xrLabelProduceMaterialId.Text = this.produceMaterial.ProduceMaterialID;


            //if (this.produceMaterial.InvoiceXO != null)
            //{
            //    this.xrLabelXOId.Text = invoiceXoManager.Get(this.produceMaterial.InvoiceXO)==null?"":invoiceXoManager.Get(this.produceMaterial.InvoiceXO).CustomerInvoiceXOId;
            //}

            //if (this.produceMaterial.SourceType != 1 && !string.IsNullOrEmpty(this.produceMaterial.InvoiceId))
            //{

            //    Model.MRSdetails mrsdetail = new Book.Model.MRSdetails();
            //    Model.PronoteHeader pronoteHeader = new BL.PronoteHeaderManager().Get(this.produceMaterial.InvoiceId);
            //    if (pronoteHeader != null)
            //    {
            //        mrsdetail = new BL.MRSdetailsManager().Get(pronoteHeader.MRSdetailsId);

            //    }
            //Model.InvoiceXO invoiceXO = new BL.InvoiceXOManager().Get(produceMaterial.InvoiceXOId);
            //if (invoiceXO != null)
            //{
            //    this.xrLabelPiHao.Text = invoiceXO.CustomerLotNumber;
            //}

            //}
            if (!string.IsNullOrEmpty(this.produceMaterial.InvoiceXOId))
            {

                Model.InvoiceXO invoiceXO = new BL.InvoiceXOManager().Get(produceMaterial.InvoiceXOId);
                if (invoiceXO != null)
                {
                    this.xrLabelXOId.Text = invoiceXO.CustomerInvoiceXOId;
                    this.xrLabelCustomer.Text = invoiceXO.xocustomer == null ? null : invoiceXO.xocustomer.ToString();
                    this.lblCustomerPH.Text = invoiceXO.CustomerLotNumber;
                }
            }

            //明细
            this.xrTableCell5.DataBindings.Add("Text", this.DataSource, Model.ProduceMaterialdetails.PRO_Inumber);
            //this.xrTableCell1ProductId.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_Id);
            //this.xrTableCellProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            this.xrTableCellProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.Pro_ProductNameWithVersion);

            this.xrTableCusProName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_CustomerProductName);

            this.xrTableCellQuantity.DataBindings.Add("Text", this.DataSource, Model.ProduceMaterialdetails.PRO_Materialprocessum);

            //this.xrTableHasOutDepot.DataBindings.Add("Text", this.DataSource, Model.ProduceMaterialdetails.PRO_Distributioned, "{0:0.####}");
            // this.xrTableMPSSum.DataBindings.Add("Text", this.DataSource, Model.ProduceMaterialdetails.PRO_MPSDetailsSum, "{0:0.####}");
            this.xrTableCellUnit.DataBindings.Add("Text", this.DataSource, "ProductUnit");
            this.xrTableCellProductSpecification.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_StocksQuantity, "{0:0.####}");
            this.xrTableCellPihao.DataBindings.Add("Text", this.DataSource, Model.ProduceMaterialdetails.PRO_Pihao);
            // this.xrTableMRP.DataBindings.Add("Text", this.DataSource, Model.ProduceMaterialdetails.PRO_MRSHeaderId);
            // this.xrTableCusXOID.DataBindings.Add("Text", this.DataSource,  Model.ProduceMaterialdetails.PRO_CustomerInvoiceXOId);
            this.TCNextWorkstation.DataBindings.Add("Text", this.DataSource, "NextWorkHouse."+Model.WorkHouse.PROPERTY_WORKHOUSENAME);
            this.xrRichText1.DataBindings.Add("Rtf", this.DataSource, "ProductDescription");
        }

    }
}
