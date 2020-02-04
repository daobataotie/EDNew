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
    /// 客戶訂單金額統計
    /// </summary>
    public partial class AmountStatisticsXO : DevExpress.XtraEditors.XtraForm
    {
        BL.InvoiceXOManager invoiceXOManager = new Book.BL.InvoiceXOManager();

        public AmountStatisticsXO()
        {
            InitializeComponent();

            this.ncc_Employee.Choose = new Settings.BasicData.Employees.ChooseEmployee();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (this.ncc_Employee.EditValue == null)
            {
                MessageBox.Show("請選擇業務員", "提示", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(this.comboBoxEditCurrency.Text))
            {
                MessageBox.Show("請選擇幣別", "提示", MessageBoxButtons.OK);
                return;
            }
            if (this.date_Start.EditValue == null || this.date_End.EditValue == null)
            {
                MessageBox.Show("請選擇日期區間", "提示", MessageBoxButtons.OK);
                return;
            }

            Model.Employee employee = this.ncc_Employee.EditValue as Model.Employee;
            DateTime startDate = this.date_Start.DateTime;
            DateTime endDate = this.date_End.DateTime;
            string currency = this.comboBoxEditCurrency.Text;

            IList<Model.InvoiceXO> list = invoiceXOManager.AmountStatistics(employee.EmployeeId, startDate, endDate, currency);
            if (list == null || list.Count == 0)
            {
                MessageBox.Show("無數據", "提示", MessageBoxButtons.OK);
                return;
            }

            var group = list.GroupBy(l => l.InvoiceDate.Value.Year);

            try
            {
                Type objClassType = null;
                objClassType = Type.GetTypeFromProgID("Excel.Application");
                if (objClassType == null)
                {
                    MessageBox.Show("本機沒有安裝Excel", "提示！", MessageBoxButtons.OK);
                    return;
                }

                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);

                int col = 1 + group.Count();


                Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.Worksheets[1];
                Microsoft.Office.Interop.Excel.Range r = sheet.get_Range(sheet.Cells[1, 1], sheet.Cells[1, col]);
                r.MergeCells = true;//合并单元格
                sheet.Cells.ColumnWidth = 12;

                sheet.get_Range(sheet.Cells[1, 1], sheet.Cells[1, 1]).HorizontalAlignment = -4108;
                sheet.get_Range(sheet.Cells[5, 1], sheet.Cells[18, col]).BorderAround(1, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, null);
                sheet.get_Range(sheet.Cells[5, 1], sheet.Cells[18, col]).Borders.Value = 1;

                sheet.Cells[1, 1] = "客戶訂單-金額統計";
                sheet.Cells[2, 1] = string.Format("業務員編號：{0}", employee.IDNo);
                sheet.Cells[2, 3] = string.Format("業務員名稱：{0}", employee.EmployeeName);
                sheet.Cells[3, 1] = string.Format("日期區間：{0} ~ {1}", startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
                sheet.Cells[3, 4] = string.Format("幣別：{0}", Model.ExchangeRate.GetCurrencyENName(currency));

                //左邊第一列
                sheet.Cells[6, 1] = "一月";
                sheet.Cells[7, 1] = "二月";
                sheet.Cells[8, 1] = "三月";
                sheet.Cells[9, 1] = "四月";
                sheet.Cells[10, 1] = "五月";
                sheet.Cells[11, 1] = "六月";
                sheet.Cells[12, 1] = "七月";
                sheet.Cells[13, 1] = "八月";
                sheet.Cells[14, 1] = "九月";
                sheet.Cells[15, 1] = "十月";
                sheet.Cells[16, 1] = "十一月";
                sheet.Cells[17, 1] = "十二月";
                sheet.Cells[18, 1] = "合計";

                for (int i = 0; i < group.Count(); i++)   //列
                {
                    //int year = i + startDate.Year;         //可能查詢年並沒有數據，從有數據最小年開始
                    int year = i + group.Min(g => g.Key);

                    sheet.Cells[5, 2 + i] = year;
                    var yearList = group.First(g => g.Key == year).ToList();

                    for (int j = 1; j <= 12; j++)       //行
                    {
                        var monthMoney = yearList.Where(l => l.InvoiceDate.Value.Month == j).Sum(d => d.InvoiceTotal);

                        sheet.Cells[5 + j, 2 + i] = monthMoney;
                    }

                    sheet.Cells[18, 2 + i] = yearList.Sum(l => l.InvoiceTotal);
                }

                sheet.Cells[18, 2 + group.Count()] = list.Sum(l => l.InvoiceTotal);


                excel.Visible = true;//是否打开该Excel文件
                excel.WindowState = XlWindowState.xlMaximized;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel未生成完畢，請勿操作，并重新點擊按鈕生成數據！", "提示！", MessageBoxButtons.OK);
                return;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}