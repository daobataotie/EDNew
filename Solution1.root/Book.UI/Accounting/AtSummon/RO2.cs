﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.Accounting.AtSummon
{
    public partial class RO2 : DevExpress.XtraReports.UI.XtraReport
    {
        public RO2()
        {
            InitializeComponent();
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(RO2_BeforePrint);

            //this.lblReportDate.Text += DateTime.Now.ToString("yyyy-MM-dd");
            //this.lblDate.DataBindings.Add("Text", this.DataSource, Model.AtSummon.PRO_SummonDate, "{0:yyyy-MM-dd}");
            //this.lblId.DataBindings.Add("Text", this.DataSource, Model.AtSummon.PRO_Id);
            //this.lblCategory.DataBindings.Add("Text", this.DataSource, Model.AtSummon.PRO_SummonCategory);
            //this.lblJieTotal.DataBindings.Add("Text", this.DataSource, Model.AtSummon.PRO_TotalDebits, "{0:F2}");
            //this.lblDaiTotal.DataBindings.Add("Text", this.DataSource, Model.AtSummon.PRO_CreditTotal, "{0:F2}");
            this.TCJieDai.DataBindings.Add("Text", this.DataSource, Model.AtSummonDetail.PRO_Lending);
            this.TCKemuId.DataBindings.Add("Text", this.DataSource, "Subject." + Model.AtAccountSubject.PRO_Id);
            this.TCKemuName.DataBindings.Add("Text", this.DataSource, "Subject." + Model.AtAccountSubject.PRO_SubjectName);
            this.TCNote.DataBindings.Add("Text", this.DataSource, Model.AtSummonDetail.PRO_Summary);
            this.TCMoney.DataBindings.Add("Text", this.DataSource, Model.AtSummonDetail.PRO_AMoney, "{0:F2}");
        }

        void RO2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.AtSummon != null)
                this.DataSource = new BL.AtSummonDetailManager().Select(this.AtSummon);
        }

        public Model.AtSummon AtSummon { get; set; }


    }
}
