﻿namespace Book.UI.Invoices.QI
{
    partial class ViewForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.textEditNote = new DevExpress.XtraEditors.MemoEdit();
            this.calcEditTotal = new DevExpress.XtraEditors.CalcEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIncomingKindId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceQIDetailMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceQIDetailNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.buttonEditAccount = new DevExpress.XtraEditors.ButtonEdit();
            this.buttonEditEmployee = new DevExpress.XtraEditors.ButtonEdit();
            this.dateEditInvoiceDate = new DevExpress.XtraEditors.DateEdit();
            this.textEditInvoiceId = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcEditTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInvoiceDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInvoiceDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditInvoiceId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.textEditNote);
            this.layoutControl1.Controls.Add(this.calcEditTotal);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.buttonEditAccount);
            this.layoutControl1.Controls.Add(this.buttonEditEmployee);
            this.layoutControl1.Controls.Add(this.dateEditInvoiceDate);
            this.layoutControl1.Controls.Add(this.textEditInvoiceId);
            resources.ApplyResources(this.layoutControl1, "layoutControl1");
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            // 
            // textEditNote
            // 
            resources.ApplyResources(this.textEditNote, "textEditNote");
            this.textEditNote.Name = "textEditNote";
            this.textEditNote.Properties.ReadOnly = true;
            this.textEditNote.StyleController = this.layoutControl1;
            // 
            // calcEditTotal
            // 
            resources.ApplyResources(this.calcEditTotal, "calcEditTotal");
            this.calcEditTotal.Name = "calcEditTotal";
            this.calcEditTotal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("calcEditTotal.Properties.Buttons"))), resources.GetString("calcEditTotal.Properties.Buttons1"), ((int)(resources.GetObject("calcEditTotal.Properties.Buttons2"))), ((bool)(resources.GetObject("calcEditTotal.Properties.Buttons3"))), ((bool)(resources.GetObject("calcEditTotal.Properties.Buttons4"))), ((bool)(resources.GetObject("calcEditTotal.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("calcEditTotal.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("calcEditTotal.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("calcEditTotal.Properties.Buttons8"), ((object)(resources.GetObject("calcEditTotal.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("calcEditTotal.Properties.Buttons10"))), ((bool)(resources.GetObject("calcEditTotal.Properties.Buttons11"))))});
            this.calcEditTotal.Properties.ReadOnly = true;
            this.calcEditTotal.StyleController = this.layoutControl1;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bindingSource1;
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIncomingKindId,
            this.colInvoiceQIDetailMoney,
            this.colInvoiceQIDetailNote});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colIncomingKindId
            // 
            this.colIncomingKindId.AppearanceCell.Options.UseTextOptions = true;
            this.colIncomingKindId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIncomingKindId.AppearanceHeader.Options.UseTextOptions = true;
            this.colIncomingKindId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colIncomingKindId, "colIncomingKindId");
            this.colIncomingKindId.FieldName = "IncomingKind";
            this.colIncomingKindId.Name = "colIncomingKindId";
            this.colIncomingKindId.OptionsColumn.AllowEdit = false;
            this.colIncomingKindId.OptionsColumn.ReadOnly = true;
            // 
            // colInvoiceQIDetailMoney
            // 
            this.colInvoiceQIDetailMoney.AppearanceCell.Options.UseTextOptions = true;
            this.colInvoiceQIDetailMoney.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colInvoiceQIDetailMoney.AppearanceHeader.Options.UseTextOptions = true;
            this.colInvoiceQIDetailMoney.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            resources.ApplyResources(this.colInvoiceQIDetailMoney, "colInvoiceQIDetailMoney");
            this.colInvoiceQIDetailMoney.FieldName = "InvoiceQIDetailMoney";
            this.colInvoiceQIDetailMoney.Name = "colInvoiceQIDetailMoney";
            this.colInvoiceQIDetailMoney.OptionsColumn.AllowEdit = false;
            this.colInvoiceQIDetailMoney.OptionsColumn.ReadOnly = true;
            // 
            // colInvoiceQIDetailNote
            // 
            this.colInvoiceQIDetailNote.AppearanceCell.Options.UseTextOptions = true;
            this.colInvoiceQIDetailNote.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colInvoiceQIDetailNote.AppearanceHeader.Options.UseTextOptions = true;
            this.colInvoiceQIDetailNote.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colInvoiceQIDetailNote, "colInvoiceQIDetailNote");
            this.colInvoiceQIDetailNote.FieldName = "InvoiceQIDetailNote";
            this.colInvoiceQIDetailNote.Name = "colInvoiceQIDetailNote";
            this.colInvoiceQIDetailNote.OptionsColumn.AllowEdit = false;
            this.colInvoiceQIDetailNote.OptionsColumn.ReadOnly = true;
            // 
            // buttonEditAccount
            // 
            resources.ApplyResources(this.buttonEditAccount, "buttonEditAccount");
            this.buttonEditAccount.Name = "buttonEditAccount";
            this.buttonEditAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("buttonEditAccount.Properties.Buttons"))), resources.GetString("buttonEditAccount.Properties.Buttons1"), ((int)(resources.GetObject("buttonEditAccount.Properties.Buttons2"))), ((bool)(resources.GetObject("buttonEditAccount.Properties.Buttons3"))), ((bool)(resources.GetObject("buttonEditAccount.Properties.Buttons4"))), ((bool)(resources.GetObject("buttonEditAccount.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("buttonEditAccount.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("buttonEditAccount.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, resources.GetString("buttonEditAccount.Properties.Buttons8"), ((object)(resources.GetObject("buttonEditAccount.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("buttonEditAccount.Properties.Buttons10"))), ((bool)(resources.GetObject("buttonEditAccount.Properties.Buttons11"))))});
            this.buttonEditAccount.Properties.ReadOnly = true;
            this.buttonEditAccount.StyleController = this.layoutControl1;
            // 
            // buttonEditEmployee
            // 
            resources.ApplyResources(this.buttonEditEmployee, "buttonEditEmployee");
            this.buttonEditEmployee.Name = "buttonEditEmployee";
            this.buttonEditEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("buttonEditEmployee.Properties.Buttons"))), resources.GetString("buttonEditEmployee.Properties.Buttons1"), ((int)(resources.GetObject("buttonEditEmployee.Properties.Buttons2"))), ((bool)(resources.GetObject("buttonEditEmployee.Properties.Buttons3"))), ((bool)(resources.GetObject("buttonEditEmployee.Properties.Buttons4"))), ((bool)(resources.GetObject("buttonEditEmployee.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("buttonEditEmployee.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("buttonEditEmployee.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, resources.GetString("buttonEditEmployee.Properties.Buttons8"), ((object)(resources.GetObject("buttonEditEmployee.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("buttonEditEmployee.Properties.Buttons10"))), ((bool)(resources.GetObject("buttonEditEmployee.Properties.Buttons11"))))});
            this.buttonEditEmployee.Properties.ReadOnly = true;
            this.buttonEditEmployee.StyleController = this.layoutControl1;
            // 
            // dateEditInvoiceDate
            // 
            resources.ApplyResources(this.dateEditInvoiceDate, "dateEditInvoiceDate");
            this.dateEditInvoiceDate.Name = "dateEditInvoiceDate";
            this.dateEditInvoiceDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dateEditInvoiceDate.Properties.Buttons"))), resources.GetString("dateEditInvoiceDate.Properties.Buttons1"), ((int)(resources.GetObject("dateEditInvoiceDate.Properties.Buttons2"))), ((bool)(resources.GetObject("dateEditInvoiceDate.Properties.Buttons3"))), ((bool)(resources.GetObject("dateEditInvoiceDate.Properties.Buttons4"))), ((bool)(resources.GetObject("dateEditInvoiceDate.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("dateEditInvoiceDate.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("dateEditInvoiceDate.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, resources.GetString("dateEditInvoiceDate.Properties.Buttons8"), ((object)(resources.GetObject("dateEditInvoiceDate.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("dateEditInvoiceDate.Properties.Buttons10"))), ((bool)(resources.GetObject("dateEditInvoiceDate.Properties.Buttons11"))))});
            this.dateEditInvoiceDate.Properties.ReadOnly = true;
            this.dateEditInvoiceDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditInvoiceDate.StyleController = this.layoutControl1;
            // 
            // textEditInvoiceId
            // 
            resources.ApplyResources(this.textEditInvoiceId, "textEditInvoiceId");
            this.textEditInvoiceId.Name = "textEditInvoiceId";
            this.textEditInvoiceId.Properties.ReadOnly = true;
            this.textEditInvoiceId.StyleController = this.layoutControl1;
            // 
            // layoutControlGroup1
            // 
            resources.ApplyResources(this.layoutControlGroup1, "layoutControlGroup1");
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem8,
            this.layoutControlItem2,
            this.layoutControlItem7,
            this.layoutControlItem6,
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(924, 516);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEditInvoiceId;
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(292, 25);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.buttonEditEmployee;
            resources.ApplyResources(this.layoutControlItem3, "layoutControlItem3");
            this.layoutControlItem3.Location = new System.Drawing.Point(582, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(322, 25);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.gridControl1;
            resources.ApplyResources(this.layoutControlItem8, "layoutControlItem8");
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(904, 319);
            this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dateEditInvoiceDate;
            resources.ApplyResources(this.layoutControlItem2, "layoutControlItem2");
            this.layoutControlItem2.Location = new System.Drawing.Point(292, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(290, 25);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(52, 14);
            // 
            // emptySpaceItem1
            // 
            resources.ApplyResources(this.emptySpaceItem1, "emptySpaceItem1");
            this.emptySpaceItem1.Location = new System.Drawing.Point(582, 25);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(322, 25);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.buttonEditAccount;
            resources.ApplyResources(this.layoutControlItem7, "layoutControlItem7");
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(292, 25);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.calcEditTotal;
            resources.ApplyResources(this.layoutControlItem6, "layoutControlItem6");
            this.layoutControlItem6.Location = new System.Drawing.Point(292, 25);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(290, 25);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.textEditNote;
            resources.ApplyResources(this.layoutControlItem4, "layoutControlItem4");
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 369);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(904, 127);
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(52, 14);
            // 
            // ViewForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ViewForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcEditTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInvoiceDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInvoiceDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditInvoiceId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.ButtonEdit buttonEditEmployee;
        private DevExpress.XtraEditors.DateEdit dateEditInvoiceDate;
        private DevExpress.XtraEditors.TextEdit textEditInvoiceId;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.ButtonEdit buttonEditAccount;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colIncomingKindId;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceQIDetailMoney;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceQIDetailNote;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraEditors.CalcEdit calcEditTotal;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.MemoEdit textEditNote;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}