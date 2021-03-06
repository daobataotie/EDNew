﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.produceManager.PCParameterSet
{
    public partial class EditForm : Settings.BasicData.BaseEditForm1
    {
        Model.Setting _setting;
        IList<Model.Setting> _detail;
        //  private Model.ProcessCategory _processCategory;

        private BL.SettingManager settingManager = new Book.BL.SettingManager();

        public EditForm()
        {
            InitializeComponent();

            DataTable da = new DataTable();
            DataColumn dc;
            dc = new DataColumn("SettingSetId", typeof(string));
            da.Columns.Add(dc);
            dc = new DataColumn("SettingName", typeof(string));
            da.Columns.Add(dc);
            DataRow dr;
            dr = da.NewRow();
            dr["SettingSetId"] = "ChongJiLiDao";
            dr["SettingName"] = "衝擊力道";
            da.Rows.Add(dr);
            dr = da.NewRow();
            dr["SettingSetId"] = "ZhuiQiuZhongLiang";
            dr["SettingName"] = "墜球數量";
            da.Rows.Add(dr);
            dr = da.NewRow();
            dr["SettingSetId"] = "LieYinBiaoTouXinXi";
            dr["SettingName"] = "表頭信息";
            da.Rows.Add(dr);

            dr = da.NewRow();
            dr["SettingSetId"] = "waiguan";
            dr["SettingName"] = "外觀";
            da.Rows.Add(dr);

            dr = da.NewRow();
            dr["SettingSetId"] = "toushi";
            dr["SettingName"] = "電鍍片透視率";
            da.Rows.Add(dr);
            dr = da.NewRow();
            dr["SettingSetId"] = "boli";
            dr["SettingName"] = "電鍍剝離測試";
            da.Rows.Add(dr);

            dr = da.NewRow();
            dr["SettingSetId"] = "gaojiaol";
            dr["SettingName"] = "高低腳 左";
            da.Rows.Add(dr);

            dr = da.NewRow();
            dr["SettingSetId"] = "gaojiaor";
            dr["SettingName"] = "高低腳 右";
            da.Rows.Add(dr);

            dr = da.NewRow();
            dr["SettingSetId"] = "jinsong";
            dr["SettingName"] = "裝腳鬆緊度";
            da.Rows.Add(dr);

            dr = da.NewRow();
            dr["SettingSetId"] = "BeiZhuShuoMing";
            dr["SettingName"] = "備註說明";
            da.Rows.Add(dr);

            dr = da.NewRow();
            dr["SettingSetId"] = "SheBeiMingCheng";
            dr["SettingName"] = "設備名稱";
            da.Rows.Add(dr);

            dr = da.NewRow();
            dr["SettingSetId"] = "SheBeiMingCheng";
            dr["SettingName"] = "設備名稱";
            da.Rows.Add(dr);

            dr = da.NewRow();
            dr["SettingSetId"] = "JISgxzcJiXing";
            dr["SettingName"] = "JIS光學制程測試機型";
            da.Rows.Add(dr);

            dr = da.NewRow();
            dr["SettingSetId"] = "JISgxzcTiaoJian";
            dr["SettingName"] = "JIS光學制程測試條件";
            da.Rows.Add(dr);

            dr = da.NewRow();
            dr["SettingSetId"] = "ChongJiCeShiJiaRe";
            dr["SettingName"] = "衝擊測試加熱溫度";
            da.Rows.Add(dr);

            dr = da.NewRow();
            dr["SettingSetId"] = "ChongJiCeShiLengDong";
            dr["SettingName"] = "衝擊測試冷凍溫度";
            da.Rows.Add(dr);

            dr = da.NewRow();
            dr["SettingSetId"] = "CSAJiShuBiaoZhun";
            dr["SettingName"] = "CSA外銷報告技術標準";
            da.Rows.Add(dr);

            dr = da.NewRow();
            dr["SettingSetId"] = "ASJiShuBiaoZhun";
            dr["SettingName"] = "AS外銷報告技術標準";
            da.Rows.Add(dr);

            dr = da.NewRow();
            dr["SettingSetId"] = "ANSI2015JiShuBiaoZhun";
            dr["SettingName"] = "ANSI2015外銷報告技術標準";
            da.Rows.Add(dr);

            dr = da.NewRow();
            dr["SettingSetId"] = "JISJiShuBiaoZhun";
            dr["SettingName"] = "JIS外銷報告技術標準";
            da.Rows.Add(dr);

            dr = da.NewRow();
            dr["SettingSetId"] = "ALANSignature";
            dr["SettingName"] = "ALAN外销报告署名";
            da.Rows.Add(dr);
            dr = da.NewRow();
            dr["SettingSetId"] = "PPESignature";
            dr["SettingName"] = "PPE外销报告署名";
            da.Rows.Add(dr);
            dr = da.NewRow();
            dr["SettingSetId"] = "ASWANSignature";
            dr["SettingName"] = "ASWAN外销报告署名";
            da.Rows.Add(dr);
            dr = da.NewRow();
            dr["SettingSetId"] = "FogMethod";
            dr["SettingName"] = "霧度測試單Method";
            da.Rows.Add(dr);

            dr = da.NewRow();
            dr["SettingSetId"] = "EarplugsResilience";
            dr["SettingName"] = "耳塞回彈力測試表-鐵塊壓設置";
            da.Rows.Add(dr);

            dr = da.NewRow();
            dr["SettingSetId"] = "EarplugsDecibel";
            dr["SettingName"] = "耳塞分貝測試表-音頻設置";
            da.Rows.Add(dr);

            dr = da.NewRow();
            dr["SettingSetId"] = "EarplugsStayWire";
            dr["SettingName"] = "耳塞拉線測試表-砝碼設置";
            da.Rows.Add(dr);


            dr = da.NewRow();
            dr["SettingSetId"] = "EarplugsResilience2";
            dr["SettingName"] = "耳塞回彈力測試表-手搓揉設置";
            da.Rows.Add(dr);


            dr = da.NewRow();
            dr["SettingSetId"] = "CEEN_Tran";
            dr["SettingName"] = "CEEN外銷報告-Transmittance";
            da.Rows.Add(dr);

            this._detail = this.settingManager.SelectTagOrderDefault("PCISO");
            this.requireValueExceptions.Add(Model.Setting.PRO_SettingName, new AA(Properties.Resources.NameIsNotNull, this.gridControl1));

            repositoryItemLookUpEdit1.DataSource = da;
            this.action = "view";
            this.gridView1.GroupPanelText = "修改時請逐條修改";
        }

        protected override void AddNew()
        {
            this._setting = new Book.Model.Setting();
            this._setting.SettingId = Guid.NewGuid().ToString();
            this._setting.SettingTags = "PCISO";

            this._detail.Add(this._setting);
            this.action = "insert";

        }

        protected override void Delete()
        {
            if (MessageBox.Show(Properties.Resources.ConfirmToDelete, this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            settingManager.Delete((this.bindingSource1.Current as Model.Setting).SettingId);
            this._detail.Remove(this.bindingSource1.Current as Model.Setting);
        }

        protected override void Save()
        {

            this._setting = bindingSource1.Current as Model.Setting;

            try
            {
                if (!this.gridView1.PostEditor() || !this.gridView1.UpdateCurrentRow())
                    return;
                BL.V.BeginTransaction();

                if (_setting.SettingName == null)
                {
                    throw new Helper.RequireValueException(Model.Setting.PRO_SettingName);
                }
                _setting.PictrueLogo = new Byte[] { };
                if (this.action == "insert")
                    this.settingManager.Insert(_setting);
                if (this.action == "update")
                    this.settingManager.Update(_setting);
                this._detail = this.settingManager.SelectTagOrderDefault("PCISO");
                this.bindingSource1.Position = this.bindingSource1.IndexOf(_setting);

                BL.V.CommitTransaction();
            }
            catch
            {
                BL.V.RollbackTransaction();
                throw;
            }
        }

        protected override void Undo()
        {
            if (this._detail == null)
                this._detail = new List<Model.Setting>();

            if (this.action == "insert")
            {
                this._detail.RemoveAt(this._detail.Count - 1);
            }

        }

        public override void Refresh()
        {
            if (_detail == null)
                this._detail = new List<Model.Setting>();
            this.bindingSource1.DataSource = this._detail;

            //if ((this.bindingSource1.Current as Model.Setting) == null)
            if (this.bindingSource1.Count == 0)
            {
                this.AddNew();

                //this._detail.Add(this._setting);
                //this.bindingSource1.Position = this.bindingSource1.IndexOf(this._setting);
            }
            this.gridControl1.RefreshDataSource();
            this.bindingSource1.Position = this.bindingSource1.IndexOf(_setting);
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

        protected override void grid_keyDpwn()
        {
            Model.Setting set = new Book.Model.Setting();
            set.SettingId = Guid.NewGuid().ToString();
            set.SettingTags = "PCISO";

            this._detail.Add(set);
            this.bindingSource1.Position = this.bindingSource1.IndexOf(set);
            this.gridControl1.RefreshDataSource();

        }

        protected override void grid_KeyDelete()
        {
            this.Delete();
        }

    }
}