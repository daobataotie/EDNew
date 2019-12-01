using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.Invoices.IP
{
    public partial class ConditionForm : DevExpress.XtraEditors.XtraForm
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CustomerId { get; set; }

        public ConditionForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            this.date_Start.EditValue = DateTime.Now.AddMonths(-1);
            this.date_End.EditValue = DateTime.Now;
            this.ncc_Customer.Choose = new Settings.BasicData.Customs.ChooseCustoms();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (date_Start.EditValue == null || date_End.EditValue == null)
            {
                MessageBox.Show("日期區間不完整", this.Text, MessageBoxButtons.OK);
                return;
            }
            this.StartDate = date_Start.DateTime;
            this.EndDate = date_End.DateTime;
            this.CustomerId = this.ncc_Customer.EditValue == null ? null : (this.ncc_Customer.EditValue as Model.Customer).CustomerId;

            this.DialogResult = DialogResult.OK;
        }
    }
}