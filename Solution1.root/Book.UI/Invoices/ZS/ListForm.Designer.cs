﻿namespace Book.UI.Invoices.ZS
{
    partial class ListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListForm));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInvoiceId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployee0Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceAbstract = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.AccessibleDescription = null;
            this.gridControl1.AccessibleName = null;
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.BackgroundImage = null;
            this.gridControl1.DataSource = this.bindingSource1;
            this.gridControl1.EmbeddedNavigator.AccessibleDescription = null;
            this.gridControl1.EmbeddedNavigator.AccessibleName = null;
            this.gridControl1.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gridControl1.EmbeddedNavigator.Anchor")));
            this.gridControl1.EmbeddedNavigator.BackgroundImage = null;
            this.gridControl1.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("gridControl1.EmbeddedNavigator.BackgroundImageLayout")));
            this.gridControl1.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gridControl1.EmbeddedNavigator.ImeMode")));
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("gridControl1.EmbeddedNavigator.TextLocation")));
            this.gridControl1.EmbeddedNavigator.ToolTip = resources.GetString("gridControl1.EmbeddedNavigator.ToolTip");
            this.gridControl1.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("gridControl1.EmbeddedNavigator.ToolTipIconType")));
            this.gridControl1.EmbeddedNavigator.ToolTipTitle = resources.GetString("gridControl1.EmbeddedNavigator.ToolTipTitle");
            this.gridControl1.Font = null;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            resources.ApplyResources(this.gridView1, "gridView1");
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInvoiceId,
            this.colCompanyId,
            this.colEmployee0Id,
            this.colInvoiceDate,
            this.colInvoiceStatus,
            this.colInvoiceTotal,
            this.colInvoiceAbstract,
            this.colInvoiceNote});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // colInvoiceId
            // 
            this.colInvoiceId.AppearanceCell.Options.UseTextOptions = true;
            this.colInvoiceId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colInvoiceId.AppearanceHeader.Options.UseTextOptions = true;
            this.colInvoiceId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colInvoiceId, "colInvoiceId");
            this.colInvoiceId.FieldName = "InvoiceId";
            this.colInvoiceId.Name = "colInvoiceId";
            this.colInvoiceId.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colCompanyId
            // 
            this.colCompanyId.AppearanceCell.Options.UseTextOptions = true;
            this.colCompanyId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCompanyId.AppearanceHeader.Options.UseTextOptions = true;
            this.colCompanyId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colCompanyId, "colCompanyId");
            this.colCompanyId.FieldName = "Company";
            this.colCompanyId.Name = "colCompanyId";
            // 
            // colEmployee0Id
            // 
            this.colEmployee0Id.AppearanceCell.Options.UseTextOptions = true;
            this.colEmployee0Id.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEmployee0Id.AppearanceHeader.Options.UseTextOptions = true;
            this.colEmployee0Id.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colEmployee0Id, "colEmployee0Id");
            this.colEmployee0Id.FieldName = "Employee0";
            this.colEmployee0Id.Name = "colEmployee0Id";
            // 
            // colInvoiceDate
            // 
            this.colInvoiceDate.AppearanceCell.Options.UseTextOptions = true;
            this.colInvoiceDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInvoiceDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colInvoiceDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colInvoiceDate, "colInvoiceDate");
            this.colInvoiceDate.FieldName = "InvoiceDate";
            this.colInvoiceDate.Name = "colInvoiceDate";
            // 
            // colInvoiceStatus
            // 
            this.colInvoiceStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colInvoiceStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInvoiceStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colInvoiceStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colInvoiceStatus, "colInvoiceStatus");
            this.colInvoiceStatus.FieldName = "InvoiceStatusDesc";
            this.colInvoiceStatus.Name = "colInvoiceStatus";
            // 
            // colInvoiceTotal
            // 
            this.colInvoiceTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colInvoiceTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colInvoiceTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colInvoiceTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            resources.ApplyResources(this.colInvoiceTotal, "colInvoiceTotal");
            this.colInvoiceTotal.FieldName = "InvoiceTotal";
            this.colInvoiceTotal.Name = "colInvoiceTotal";
            this.colInvoiceTotal.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colInvoiceAbstract
            // 
            this.colInvoiceAbstract.AppearanceCell.Options.UseTextOptions = true;
            this.colInvoiceAbstract.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colInvoiceAbstract.AppearanceHeader.Options.UseTextOptions = true;
            this.colInvoiceAbstract.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colInvoiceAbstract, "colInvoiceAbstract");
            this.colInvoiceAbstract.FieldName = "InvoiceAbstract";
            this.colInvoiceAbstract.Name = "colInvoiceAbstract";
            this.colInvoiceAbstract.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceAbstract.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceAbstract.OptionsFilter.AllowFilter = false;
            // 
            // colInvoiceNote
            // 
            this.colInvoiceNote.AppearanceCell.Options.UseTextOptions = true;
            this.colInvoiceNote.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colInvoiceNote.AppearanceHeader.Options.UseTextOptions = true;
            this.colInvoiceNote.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colInvoiceNote, "colInvoiceNote");
            this.colInvoiceNote.FieldName = "InvoiceNote";
            this.colInvoiceNote.Name = "colInvoiceNote";
            this.colInvoiceNote.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceNote.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceNote.OptionsFilter.AllowFilter = false;
            // 
            // gridView2
            // 
            resources.ApplyResources(this.gridView2, "gridView2");
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // ListForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.gridControl1);
            this.Icon = null;
            this.Name = "ListForm";
            this.Load += new System.EventHandler(this.ListForm_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceId;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyId;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployee0Id;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceDate;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceAbstract;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNote;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceTotal;
    }
}