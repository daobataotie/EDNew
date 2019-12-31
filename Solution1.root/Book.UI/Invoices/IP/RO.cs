using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
using System.Globalization;

namespace Book.UI.Invoices.IP
{
    public partial class RO : DevExpress.XtraReports.UI.XtraReport
    {
        public RO(Model.PackingListHeader packingList)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(packingList.Unit))
                this.xrTableCell5.Text = string.Format("Quantity              ({0})", packingList.Unit);

            var group = packingList.Details.GroupBy(P => P.PLTNo);
            foreach (var item in group)
            {
                item.ToList().ForEach(D =>
                {
                    D.PLTNo = "";
                });
                item.First().PLTNo = item.Key;
            }

            this.DataSource = packingList.Details;

            //lbl_CompanyName.Text = BL.Settings.CompanyChineseName;
            this.lbl_PackingNo.Text = packingList.PackingNo;
            //this.lbl_PackingDate.Text = packingList.PackingDate.Value.ToString("yyyy-MM-dd");
            this.lbl_PackingDate.Text = packingList.PackingDate.Value.ToString("MMM dd.yyyy", CultureInfo.CreateSpecificCulture("en-GB"));
            //this.lbl_CustomerFullName.Text = packingList.Customer.CustomerFullName;
            //this.lbl_address.Text = packingList.Customer.CustomerAddress;
            this.lbl_CustomerFullName.Text = packingList.CustomerFullName;
            this.lbl_address.Text = packingList.CustomerAddress;
            this.lbl_PerSS.Text = packingList.PerSS;
            if (packingList.SailingOnOrAbout != null)
                this.lbl_SailingDate.Text = packingList.SailingOnOrAbout.Value.ToString("yyyy-MM-dd");
            if (packingList.FromPort != null)
                this.lbl_From.Text = packingList.FromPort.PortName;
            if (packingList.ToPort != null)
                this.lbl_TO.Text = packingList.ToPort.PortName;
            this.lbl_marks.Text = packingList.MarkNos;

            //this.lblTotal.Text = packingList.Details.Max(P => Convert.ToInt32(string.IsNullOrEmpty(P.PLTNo) ? "0" : P.PLTNo)) + " PLT / " +
            //    (string.IsNullOrEmpty(packingList.Details.Last().CartonNo) ? "" : packingList.Details.Last().CartonNo.Substring(packingList.Details.Last().CartonNo.Length - 1)) + " CARTON";
            var cartonNoGroup = packingList.Details.GroupBy(P => P.CartonNo.Trim());
            int totalCartonNo = 0;
            foreach (var item in cartonNoGroup)
            {
                totalCartonNo += item.ToList()[0].CartonQty;
            }

            if (packingList.Details != null && packingList.Details.Count > 0)
                this.lblTotal.Text = packingList.Details.Max(P => Convert.ToInt32(string.IsNullOrEmpty(P.PLTNo) ? "0" : P.PLTNo)) + " PLT / " +
                                     totalCartonNo + " CARTON";

            if (!string.IsNullOrEmpty(packingList.Unit))
                this.lbl_TotalQTY.Text = packingList.Details.Sum(P => P.Quantity).Value.ToString("0.##") + " " + packingList.Unit;
            else
                this.lbl_TotalQTY.Text = packingList.Details.Sum(P => P.Quantity).Value.ToString("0.##") + " PCS";

            this.lbl_TotalNetWeight.Text = packingList.Details.Sum(P => P.NetWeight).Value.ToString("0.##") + " KGS";
            this.lbl_TotalGrossWeight.Text = packingList.Details.Sum(P => P.GrossWeight).Value.ToString("0.##") + " KGS";

            TC_PLTNo.DataBindings.Add("Text", this.DataSource, Model.PackingListDetail.PRO_PLTNo);
            TC_CartonNo.DataBindings.Add("Text", this.DataSource, Model.PackingListDetail.PRO_CartonNo);
            TC_PONO.DataBindings.Add("Text", this.DataSource, Model.PackingListDetail.PRO_PONo);
            //TC_CUSTNO.DataBindings.Add("Text", this.DataSource, Model.PackingListDetail.PRO_CUSTNO);
            //TC_ProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            TC_CUSTNO.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_CustomerProductName);
            TC_ProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            TCQTY.DataBindings.Add("Text", this.DataSource, Model.PackingListDetail.PRO_ShowQty);
            TC_NetWeight.DataBindings.Add("Text", this.DataSource, Model.PackingListDetail.PRO_ShowNetWeight);
            TC_GrossWeight.DataBindings.Add("Text", this.DataSource, Model.PackingListDetail.PRO_ShowGrossWeight);

        }
    }
}
