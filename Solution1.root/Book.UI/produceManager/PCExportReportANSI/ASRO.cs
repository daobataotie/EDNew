using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.produceManager.PCExportReportANSI
{
    public partial class ASRO : DevExpress.XtraReports.UI.XtraReport
    {
        public ASRO()
        {
            InitializeComponent();
            this.xrPictureBox1.Visible = false;
        }

        public ASRO(Model.PCExportReportANSI _PCExportReportANSI, int tag)
            : this()
        {
            if (tag == 1)
            {
                this.xrLabel1.Text = "ALAN    SAFETY    COMPANY.";

                this.lbl_Signature.Text = new BL.SettingManager().SelectByName("ALANSignature").Count < 1 ? "" : new BL.SettingManager().SelectByName("ALANSignature")[0].SettingCurrentValue;
                this.xrPictureBox1.Visible = true;
            }
            else if (tag == 2)
            {
                this.xrLabel1.Text = "PPE   SAFETY   INC.";
                this.lbl_Signature.Text = new BL.SettingManager().SelectByName("PPESignature").Count < 1 ? "" : new BL.SettingManager().SelectByName("PPESignature")[0].SettingCurrentValue;
            }
            else
                this.lbl_Signature.Text = new BL.SettingManager().SelectByName("ASWANSignature").Count < 1 ? "" : new BL.SettingManager().SelectByName("ASWANSignature")[0].SettingCurrentValue;
            this.xrLabel2.Text = "ASSEMBLED EYE PROTECTORS-QUALITY CONTROL TEST TEPORT";
            this.LbModelNo.Text = _PCExportReportANSI.Product == null ? null : _PCExportReportANSI.Product.CustomerProductName;
            //this.LbTestDate.Text = _PCExportReportANSI.ReportDate == null ? null : _PCExportReportANSI.ReportDate.Value.ToShortDateString();
            this.LbTestDate.Text = _PCExportReportANSI.ReportDate == null ? null : _PCExportReportANSI.ReportDate.Value.ToString("dd-MMM-yy", new System.Globalization.CultureInfo("en-us"));

            this.LbQtyTest.Text = (_PCExportReportANSI.QuYangShu2.HasValue ? _PCExportReportANSI.QuYangShu2.Value.ToString() : "0") + "PCS";
            this.LbBuyer.Text += "   " + (_PCExportReportANSI.Customer == null ? null : _PCExportReportANSI.Customer.CustomerName);
            this.LbOrderNo.Text += "   " + (_PCExportReportANSI.InvoiceCusXOId == null ? null : _PCExportReportANSI.InvoiceCusXOId.ToString());
            this.lbl_OrderQuantity.Text += "   " + (_PCExportReportANSI.Amount.HasValue ? _PCExportReportANSI.Amount.ToString() + "PCS" : "");

            this.LbBatchNo.Text = _PCExportReportANSI.ProductBatchNo == null ? null : _PCExportReportANSI.ProductBatchNo.ToString();
            this.CheckVisual.Checked = _PCExportReportANSI.VisualTest.HasValue ? _PCExportReportANSI.VisualTest.Value : false;
            this.CheckThermal.Checked = _PCExportReportANSI.ThermalStability.HasValue ? _PCExportReportANSI.ThermalStability.Value : false;
            this.CheckPriHIn.Checked = _PCExportReportANSI.PrismaticPowerHIn.HasValue ? _PCExportReportANSI.PrismaticPowerHIn.Value : false;
            this.CheckPriHOut.Checked = _PCExportReportANSI.PrismaticPowerHOut.HasValue ? _PCExportReportANSI.PrismaticPowerHOut.Value : false;
            this.CheckPriVUp.Checked = _PCExportReportANSI.PrismaticPowerVUp.HasValue ? _PCExportReportANSI.PrismaticPowerVUp.Value : false;
            this.CheckPriVDwn.Checked = _PCExportReportANSI.PrismaticPowerVDwn.HasValue ? _PCExportReportANSI.PrismaticPowerVDwn.Value : false;
            this.LbRefractive.Text = _PCExportReportANSI.RefractivePower.HasValue ? "(" + _PCExportReportANSI.RefractivePower.Value.ToString("0.00") + ") 2" : "(0.00) 2";
            this.CheckScatter.Checked = _PCExportReportANSI.ScatterLight.HasValue ? _PCExportReportANSI.ScatterLight.Value : false;
            this.CheckMdeium.Checked = _PCExportReportANSI.MediumImpact.HasValue ? _PCExportReportANSI.MediumImpact.Value : false;
            this.CheckHigh.Checked = _PCExportReportANSI.HighImpact.HasValue ? _PCExportReportANSI.HighImpact.Value : false;
            this.CheckExtraHigh.Checked = _PCExportReportANSI.ExtraHighImpact.HasValue ? _PCExportReportANSI.ExtraHighImpact.Value : false;
            this.CheckPemer.Checked = _PCExportReportANSI.PermertrationTest.HasValue ? _PCExportReportANSI.PermertrationTest.Value : false;
            this.CheckIgnition.Checked = _PCExportReportANSI.IgnitionTest.HasValue ? _PCExportReportANSI.IgnitionTest.Value : false;
            this.CheckCorrosion.Checked = _PCExportReportANSI.Corrsion.HasValue ? _PCExportReportANSI.Corrsion.Value : false;
            this.CheckMarkings.Checked = _PCExportReportANSI.Markings.HasValue ? _PCExportReportANSI.Markings.Value : false;
            this.LbTester.Text = _PCExportReportANSI.Employee == null ? null : _PCExportReportANSI.Employee.ToString();
            this.xrLabel4.Text = _PCExportReportANSI.AuditEmp == null ? null : _PCExportReportANSI.AuditEmp.ToString();

            //对外观，加热，坐标等判定新增的 测试数量

            this.lbl1.Text = _PCExportReportANSI.ShouCeShu4.HasValue ? _PCExportReportANSI.ShouCeShu4.Value.ToString() : "";
            this.lbl2.Text = _PCExportReportANSI.ShouCeShu5.HasValue ? _PCExportReportANSI.ShouCeShu5.Value.ToString() : "";
            this.lbl3.Text = _PCExportReportANSI.ShouCeShu6.HasValue ? _PCExportReportANSI.ShouCeShu6.Value.ToString() : "";
            this.lbl4.Text = _PCExportReportANSI.ShouCeShu7.HasValue ? _PCExportReportANSI.ShouCeShu7.Value.ToString() : "";
            this.lbl5.Text = _PCExportReportANSI.ShouCeShu8.HasValue ? _PCExportReportANSI.ShouCeShu8.Value.ToString() : "";
            this.lbl6.Text = _PCExportReportANSI.ShouCeShu9.HasValue ? _PCExportReportANSI.ShouCeShu9.Value.ToString() : "";
            this.lbl7.Text = _PCExportReportANSI.ShouCeShu10.HasValue ? _PCExportReportANSI.ShouCeShu10.Value.ToString() : "";
            this.lbl8.Text = _PCExportReportANSI.ShouCeShu11.HasValue ? _PCExportReportANSI.ShouCeShu11.Value.ToString() : "";
            this.lbl9.Text = _PCExportReportANSI.ShouCeShu12.HasValue ? _PCExportReportANSI.ShouCeShu12.Value.ToString() : "";
            this.lbl10.Text = _PCExportReportANSI.ShouCeShu13.HasValue ? _PCExportReportANSI.ShouCeShu13.Value.ToString() : "";
            this.lbl11.Text = _PCExportReportANSI.ShouCeShu14.HasValue ? _PCExportReportANSI.ShouCeShu14.Value.ToString() : "";
            this.lbl12.Text = _PCExportReportANSI.ShouCeShu15.HasValue ? _PCExportReportANSI.ShouCeShu15.Value.ToString() : "";
            this.lbl13.Text = _PCExportReportANSI.ShouCeShu16.HasValue ? _PCExportReportANSI.ShouCeShu16.Value.ToString() : "";
            this.lbl14.Text = _PCExportReportANSI.ShouCeShu17.HasValue ? _PCExportReportANSI.ShouCeShu17.Value.ToString() : "";

        }

    }
}
