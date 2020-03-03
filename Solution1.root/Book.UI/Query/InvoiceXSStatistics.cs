using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Office.Interop.Excel;
using System.Linq;

namespace Book.UI.Query
{
    /// <summary>
    /// 出貨單-金額統計 
    /// </summary>
    public partial class InvoiceXSStatistics : DevExpress.XtraEditors.XtraForm
    {
        BL.InvoiceXSDetailManager invoiceXSDetailManager = new Book.BL.InvoiceXSDetailManager();

        //depot        kn
        //isProcess    n
        //TrustOut     ve
        //OutSourcing  vpp

        public InvoiceXSStatistics()
        {
            InitializeComponent();

            this.ncc_Area.Choose = new Settings.BasicData.AreaCategory.ChooseAreaCategory();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (this.date_Start.EditValue == null || this.date_End.EditValue == null)
            {
                MessageBox.Show("請選擇日期區間", "提示", MessageBoxButtons.OK);
                return;
            }
            if (this.ncc_Area.EditValue == null)
            {
                MessageBox.Show("請選擇地區", "提示", MessageBoxButtons.OK);
                return;
            }

            DateTime startDate = this.date_Start.DateTime;
            DateTime endDate = this.date_End.DateTime;
            string areaId = (this.ncc_Area.EditValue as Model.AreaCategory).AreaCategoryId;

            string showType = "";
            string proType = "";
            if (this.ce_Qiang.Checked)
            {
                proType += " and IsQiangHua=1";
                showType += "強化,";
            }
            if (this.ce_FangWu.Checked)
            {
                proType += " and IsFangWu=1";
                showType += "防霧,";
            }
            if (this.ce_NoQiang.Checked)
            {
                proType += " and IsNoQiangFang=1";
                showType += "無強化防霧,";
            }
            if (this.ce_OutSourcing.Checked)
            {
                proType += " and OutSourcing=1";
                showType += "VPP,";
            }
            if (this.ce_TrustOut.Checked)
            {
                proType += " and TrustOut=1";
                showType += "VE,";
            }
            if (this.ce_IsProcess.Checked)
            {
                proType += " and IsProcee=1";
                showType += "N,";
            }
            if (this.ce_Depot.Checked)
            {
                proType += " and IsDepot=1";
                showType += ",KN";
            }

            showType = showType.Trim(',');

            IList<Model.InvoiceXSDetail> list = invoiceXSDetailManager.GetXSStatistics(startDate, endDate, areaId, proType);
            if (list == null || list.Count == 0)
            {
                MessageBox.Show("無數據", "提示", MessageBoxButtons.OK);
                return;
            }

            InvoiceXSStatisticsRO ro = new InvoiceXSStatisticsRO(list, string.Format("{0} ~ {1}", startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd")), (this.ncc_Area.EditValue as Model.AreaCategory).AreaCategoryName, showType);
            ro.ShowPreviewDialog();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}