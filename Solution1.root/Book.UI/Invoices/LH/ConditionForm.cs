using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.Invoices.LH
{
    public partial class ConditionForm : DevExpress.XtraEditors.XtraForm
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string CustomerId { get; set; }

        public ConditionForm()
        {
            InitializeComponent();

            this.date_StartDate.EditValue = DateTime.Now.AddMonths(-1);
            this.date_EndDate.EditValue = DateTime.Now;
            this.ncc_Customer.Choose = new Settings.BasicData.Customs.ChooseCustoms();

            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (this.date_StartDate.EditValue == null || this.date_EndDate.EditValue == null)
            {
                MessageBox.Show("日期區間有誤", this.Text, MessageBoxButtons.OK);
                return;
            }

            this.StartDate = this.date_StartDate.DateTime;
            this.EndDate = this.date_EndDate.DateTime;
            this.CustomerId = this.ncc_Customer.EditValue == null ? null : (this.ncc_Customer.EditValue as Model.Customer).CustomerId;

            this.DialogResult = DialogResult.OK;
        }
    }
}