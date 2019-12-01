using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.Settings.BasicData.ExchangeRate
{
    public partial class EditForm : BaseEditForm1
    {
        Model.ExchangeRate exchangeRate = new Book.Model.ExchangeRate();
        BL.ExchangeRateManager exchangeRateManager = new Book.BL.ExchangeRateManager();
        IList<Model.ExchangeRate> List = new List<Model.ExchangeRate>();

        public EditForm()
        {
            InitializeComponent();
            this.requireValueExceptions.Add(Model.ExchangeRate.PRO_YearValue, new AA("年份不能為空", this.gridControl1));
            this.requireValueExceptions.Add(Model.ExchangeRate.PRO_MonthValue, new AA("月份不能為空", this.gridControl1));
            this.requireValueExceptions.Add(Model.ExchangeRate.PRO_Currency, new AA("幣別不能為空", this.gridControl1));

            this.action = "view";

            int year = DateTime.Now.Year + 10;
            for (int i = 0; i < 20; i++)
            {
                this.repositoryItemComboBox2.Items.Add(year - i);
            }
            for (int i = 1; i <= 12; i++)
            {
                this.repositoryItemComboBox3.Items.Add(i);
            }
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
        }

        protected override void Delete()
        {
            if ((this.bindingSource1.Current as Model.ExchangeRate) != null)
            {
                if (MessageBox.Show(Properties.Resources.ConfirmToDelete, this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.exchangeRateManager.Delete((this.bindingSource1.Current as Model.ExchangeRate).Id);
            }

        }

        protected override void Save()
        {
            this.gridView1.PostEditor();
            this.gridView1.UpdateCurrentRow();

            switch (this.action)
            {
                case "insert":
                    this.exchangeRateManager.Update(this.List);
                    break;
                case "update":
                    this.exchangeRateManager.Update(this.List);
                    break;
                default:
                    break;
            }
        }


        public override void Refresh()
        {
            this.List = exchangeRateManager.Select();
            this.bindingSource1.DataSource = this.List;
            if (this.action == "insert")
            {
                Model.ExchangeRate model = new Book.Model.ExchangeRate();
                model.Id = Guid.NewGuid().ToString();
                this.List.Add(model);
                this.bindingSource1.DataSource = this.List;
                this.bindingSource1.Position = this.bindingSource1.IndexOf(model);
                this.gridControl1.RefreshDataSource();
            }

            switch (this.action)
            {
                case "insert":
                    this.gridView1.OptionsBehavior.Editable = true;
                    break;
                case "update":
                    this.gridView1.OptionsBehavior.Editable = true;
                    break;
                case "view":
                    this.gridView1.OptionsBehavior.Editable = false;
                    break;
                default:
                    break;
            }
            base.Refresh();
        }
    }
}