using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Book.UI.Settings.BasicData.Port
{
    /*----------------------------------------------------------------
// Copyright (C) 2008 - 2010  咸阳飛馳軟件有限公司
//                     版權所有 圍著必究

// 编 码 人: 裴盾            完成时间:2009-10-20
// 修改原因：
// 修 改 人:                          修改时间:
// 修改原因：
// 修 改 人:                          修改时间:
//----------------------------------------------------------------*/
    public partial class EditForm : DevExpress.XtraEditors.XtraForm
    {
        Model.Port port;
        BL.PortManager portManager = new Book.BL.PortManager();
        string State = "";

        public EditForm()
        {
            InitializeComponent();

            this.gridView1.OptionsBehavior.Editable = false;

            this.StartPosition = FormStartPosition.CenterScreen;

            this.State = "view";
            this.StateChanged();
        }


        //加载
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void RefreshData()
        {
            this.bindingSource1.DataSource = portManager.Select();

            this.gridControl1.RefreshDataSource();

            ControlInitial();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txt_Id.Text = "";
            this.txt_PortName.Text = "";

            this.State = "insert";
            StateChanged();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.port != null)
            {
                this.State = "update";
                StateChanged();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.bindingSource1.Current != null)
            {
                if (MessageBox.Show("確定刪除？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Model.Port port = this.bindingSource1.Current as Model.Port;

                    portManager.Delete(port.PortId);

                    this.RefreshData();
                }
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_PortName.Text.Trim()) || string.IsNullOrEmpty(this.txt_Id.Text.Trim()))
            {
                MessageBox.Show("編號，名稱不能為空！", "提示", MessageBoxButtons.OK);
                return;
            }

            try
            {
                BL.V.BeginTransaction();

                if (this.State == "insert")
                {
                    port = new Book.Model.Port();
                    port.PortId = Guid.NewGuid().ToString();
                    port.Id = this.txt_Id.Text;
                    port.PortName = this.txt_PortName.Text;

                    this.portManager.Insert(port);
                }
                else if (this.State == "update")
                {
                    port.Id = this.txt_Id.Text;
                    port.PortName = this.txt_PortName.Text;

                    this.portManager.Update(port);
                }

                BL.V.CommitTransaction();

                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                BL.V.RollbackTransaction();
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK);
                return;
            }

            this.State = "view";
            this.StateChanged();

            this.RefreshData();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.State = "view";
            StateChanged();
            ControlInitial();
        }

        private void StateChanged()
        {
            if (this.State == "view")
            {
                this.barButtonItem1.Enabled = true;
                this.barButtonItem2.Enabled = true;
                this.barButtonItem3.Enabled = true;
                this.barButtonItem4.Enabled = false;
                this.barButtonItem5.Enabled = false;


                this.txt_Id.Enabled = false;
                this.txt_PortName.Enabled = false;
            }
            else
            {
                this.barButtonItem1.Enabled = false;
                this.barButtonItem2.Enabled = false;
                this.barButtonItem3.Enabled = false;
                this.barButtonItem4.Enabled = true;
                this.barButtonItem5.Enabled = true;


                this.txt_Id.Enabled = true;
                this.txt_PortName.Enabled = true;
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle > 0)
            {
                ControlInitial();

                this.State = "view";
                StateChanged();
            }
        }

        private void ControlInitial()
        {
            port = this.bindingSource1.Current as Model.Port;

            if (port != null)
            {
                this.txt_Id.Text = port.Id;
                this.txt_PortName.Text = port.PortName;
            }
            else
            {
                this.txt_Id.Text = "";
                this.txt_PortName.Text = "";

            }
        }
    }
}