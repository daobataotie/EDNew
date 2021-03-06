namespace Book.UI.Hr.Attendance.AnnualHoliday
{
    partial class AnnualHolidayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnnualHolidayForm));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnAutoArrangeHoliday = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridViewAnnualHoliday = new System.Windows.Forms.DataGridView();
            this.HolidayDate = new Book.UI.Hr.Attendance.AnnualHoliday.CalendarColumn();
            this.DayOfWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HolidayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Departs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Departids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnnualHolidayId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsNationalHoliday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bindingSourceAnnualHoliday = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceSpecificHoliday = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.barExport = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnnualHoliday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAnnualHoliday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSpecificHoliday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // comboBoxEdit1
            // 
            resources.ApplyResources(this.comboBoxEdit1, "comboBoxEdit1");
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("comboBoxEdit1.Properties.Buttons"))))});
            this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // btnAutoArrangeHoliday
            // 
            resources.ApplyResources(this.btnAutoArrangeHoliday, "btnAutoArrangeHoliday");
            this.btnAutoArrangeHoliday.Name = "btnAutoArrangeHoliday";
            this.btnAutoArrangeHoliday.Click += new System.EventHandler(this.btnAutoArrangeHoliday_Click);
            // 
            // dataGridViewAnnualHoliday
            // 
            this.dataGridViewAnnualHoliday.AutoGenerateColumns = false;
            this.dataGridViewAnnualHoliday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAnnualHoliday.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HolidayDate,
            this.DayOfWeek,
            this.HolidayName,
            this.Departs,
            this.Departids,
            this.AnnualHolidayId,
            this.IsNationalHoliday});
            this.dataGridViewAnnualHoliday.DataSource = this.bindingSourceAnnualHoliday;
            resources.ApplyResources(this.dataGridViewAnnualHoliday, "dataGridViewAnnualHoliday");
            this.dataGridViewAnnualHoliday.Name = "dataGridViewAnnualHoliday";
            this.dataGridViewAnnualHoliday.RowTemplate.Height = 23;
            this.dataGridViewAnnualHoliday.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAnnualHoliday_CellValueChanged);
            this.dataGridViewAnnualHoliday.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAnnualHoliday_CellDoubleClick);
            this.dataGridViewAnnualHoliday.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewAnnualHoliday_CellFormatting);
            this.dataGridViewAnnualHoliday.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewAnnualHoliday_CurrentCellDirtyStateChanged);
            // 
            // HolidayDate
            // 
            this.HolidayDate.DataPropertyName = "HolidayDate";
            resources.ApplyResources(this.HolidayDate, "HolidayDate");
            this.HolidayDate.Name = "HolidayDate";
            this.HolidayDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HolidayDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DayOfWeek
            // 
            resources.ApplyResources(this.DayOfWeek, "DayOfWeek");
            this.DayOfWeek.Name = "DayOfWeek";
            // 
            // HolidayName
            // 
            this.HolidayName.DataPropertyName = "HolidayName";
            resources.ApplyResources(this.HolidayName, "HolidayName");
            this.HolidayName.Name = "HolidayName";
            // 
            // Departs
            // 
            resources.ApplyResources(this.Departs, "Departs");
            this.Departs.Name = "Departs";
            // 
            // Departids
            // 
            this.Departids.DataPropertyName = "Departs";
            resources.ApplyResources(this.Departids, "Departids");
            this.Departids.Name = "Departids";
            // 
            // AnnualHolidayId
            // 
            this.AnnualHolidayId.DataPropertyName = "AnnualHolidayId";
            resources.ApplyResources(this.AnnualHolidayId, "AnnualHolidayId");
            this.AnnualHolidayId.Name = "AnnualHolidayId";
            // 
            // IsNationalHoliday
            // 
            this.IsNationalHoliday.DataPropertyName = "IsNationalHoliday";
            resources.ApplyResources(this.IsNationalHoliday, "IsNationalHoliday");
            this.IsNationalHoliday.Name = "IsNationalHoliday";
            this.IsNationalHoliday.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsNationalHoliday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageCollection1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barExport});
            this.barManager1.MaxItemId = 2;
            // 
            // bar1
            // 
            this.bar1.BarItemVertIndent = 6;
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barExport)});
            resources.ApplyResources(this.bar1, "bar1");
            // 
            // barButtonItem1
            // 
            resources.ApplyResources(this.barButtonItem1, "barButtonItem1");
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ImageIndex = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            // 
            // imageCollection1
            // 
            resources.ApplyResources(this.imageCollection1, "imageCollection1");
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // radioGroup1
            // 
            resources.ApplyResources(this.radioGroup1, "radioGroup1");
            this.radioGroup1.MenuManager = this.barManager1;
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((object)(resources.GetObject("radioGroup1.Properties.Items"))), resources.GetString("radioGroup1.Properties.Items1")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((object)(resources.GetObject("radioGroup1.Properties.Items2"))), resources.GetString("radioGroup1.Properties.Items3"))});
            // 
            // barExport
            // 
            resources.ApplyResources(this.barExport, "barExport");
            this.barExport.Id = 1;
            this.barExport.Name = "barExport";
            this.barExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barExport_ItemClick);
            // 
            // AnnualHolidayForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.dataGridViewAnnualHoliday);
            this.Controls.Add(this.btnAutoArrangeHoliday);
            this.Controls.Add(this.comboBoxEdit1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.Name = "AnnualHolidayForm";
            this.Load += new System.EventHandler(this.AnnualHolidayForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnnualHoliday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAnnualHoliday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSpecificHoliday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.SimpleButton btnAutoArrangeHoliday;
        private System.Windows.Forms.DataGridView dataGridViewAnnualHoliday;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private System.Windows.Forms.BindingSource bindingSourceAnnualHoliday;
        private System.Windows.Forms.BindingSource bindingSourceSpecificHoliday;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private CalendarColumn HolidayDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayOfWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn HolidayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Departs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Departids;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnnualHolidayId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsNationalHoliday;
        private DevExpress.XtraBars.BarButtonItem barExport;
    }
}