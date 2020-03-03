using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using DevExpress.XtraCharts;

namespace Book.UI.Query
{
    public partial class InvoiceXSStatisticsRO : DevExpress.XtraReports.UI.XtraReport
    {
        public InvoiceXSStatisticsRO(IList<Model.InvoiceXSDetail> list, string dateRange, string area, string proType)
        {
            InitializeComponent();

            this.DataSource = list;

            this.lblCompanyName.Text = BL.Settings.CompanyChineseName;
            this.lblDateRange.Text = dateRange;
            this.lblArea.Text = area;
            this.lblProType.Text = proType;

            this.TCId.DataBindings.Add("Text", this.DataSource, "PId");
            this.TCName.DataBindings.Add("Text", this.DataSource, "ProductName");
            this.TCMoney.DataBindings.Add("Text", this.DataSource, "InvoiceXSDetailTaxMoney", "{0:N}");

            this.lblTotal.DataBindings.Add("Text", this.DataSource, "InvoiceXSDetailTaxMoney", "{0:N}");

            Series series = new Series();
            series.DataSource = list;

            this.xrChart1.Legend.Visible = false;
            series.ShowInLegend = false;  //右上角的Series顯示狀態
            //series.LegendText = "銷售額";
            //xrChart1.Legend.Font = new Font(this.Font.FontFamily.Name, 11);

            series.ChangeView(ViewType.Bar);
            series.ArgumentScaleType = ScaleType.Qualitative;
            series.ArgumentDataMember = "PId";
            series.ValueScaleType = ScaleType.Numerical;
            series.ValueDataMembers.AddRange(new string[] { "InvoiceXSDetailTaxMoney" });
            series.PointOptions.PointView = PointView.ArgumentAndValues;
            series.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;

            series.PointOptions.PointView = PointView.Values;
            series.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;

            series.SeriesPointsSorting = SortingMode.Descending;

            this.xrChart1.Series.Add(series);
            
            //必須先添加Series，否則為null
            XYDiagram diagram = (XYDiagram)this.xrChart1.Diagram;
            diagram.Rotated = true;
            diagram.EnableAxisXScrolling = true;    //將Lable包在框内


            this.xrChart1.HeightF = list.Count * 50 + 200;
        }

    }
}
