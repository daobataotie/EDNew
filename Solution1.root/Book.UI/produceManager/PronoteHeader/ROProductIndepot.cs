using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace Book.UI.produceManager.PronoteHeader
{
    public partial class ROProductIndepot : DevExpress.XtraReports.UI.XtraReport
    {
        public ROProductIndepot()
        {
            InitializeComponent();
        }

        public ROProductIndepot(IList<Model.PronoteHeader> list)
            : this()
        {
            foreach (var item in list)
            {
                item.DateHelp = item.PronoteProceduresDate.HasValue ? item.PronoteProceduresDate.Value.ToString("yyyy-MM-dd") : "";
            }
            this.DataSource = list;
            this.lblCompanyName.Text = BL.Settings.CompanyChineseName;
            this.lblPrintDate.Text += DateTime.Now.Date;
            this.TCPronoteHeaderId.DataBindings.Add("Text", this.DataSource, "PronoteHeaderID");
            this.TCCusXOId.DataBindings.Add("Text", this.DataSource, "CustomerInvoiceXOId");
            this.TC_ShechuJiaoqi.DataBindings.Add("Text", this.DataSource, "Shechudata", "{0:yyyy-MM-dd}");
            this.TCJiaohuoDate.DataBindings.Add("Text", this.DataSource, "DateHelp");
            this.TCProductName.DataBindings.Add("Text", this.DataSource, "ProductName");
            this.TCProduceQuantity.DataBindings.Add("Text", this.DataSource, "DetailsSum");
            this.TCUpDepartmentPass.DataBindings.Add("Text", this.DataSource, "ProduceTransferQuantity");
            this.TCNumHejiProduce.DataBindings.Add("Text", this.DataSource, "HeJiProceduresSum");
            this.TCNumPass.DataBindings.Add("Text", this.DataSource, "HeJiCheckOutSum");
            this.TCUnit.DataBindings.Add("Text", this.DataSource, "ProductUnit");
            this.TCMachine.DataBindings.Add("Text", this.DataSource, "PronoteMachineId");
            this.RTProductDesc.DataBindings.Add("Rtf", this.DataSource, "ProductDesc");
        }

    }
}
