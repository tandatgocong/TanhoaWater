namespace TanHoaWater.View.QLDHN
{
    partial class controlViewLich
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.editDot = new System.Windows.Forms.ComboBox();
            this.editNgay = new System.Windows.Forms.DateTimePicker();
            this.editKy = new System.Windows.Forms.ComboBox();
            this.editNam = new System.Windows.Forms.ComboBox();
            this.update = new DevComponents.DotNetBar.ButtonX();
            this.delete = new DevComponents.DotNetBar.ButtonX();
            this.calendar = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btUndo = new DevComponents.DotNetBar.ButtonX();
            this.btSearch = new DevComponents.DotNetBar.ButtonX();
            this.dtgSearch = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchDgQuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchDgPhuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchDgKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchDgNam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchDgDot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchDgNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbDot = new System.Windows.Forms.ComboBox();
            this.cbNam = new System.Windows.Forms.ComboBox();
            this.cbKy = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPhuong = new System.Windows.Forms.ComboBox();
            this.cbQuan = new System.Windows.Forms.ComboBox();
            this.sfdsad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.editDot);
            this.panelSearch.Controls.Add(this.editNgay);
            this.panelSearch.Controls.Add(this.editKy);
            this.panelSearch.Controls.Add(this.editNam);
            this.panelSearch.Controls.Add(this.update);
            this.panelSearch.Controls.Add(this.delete);
            this.panelSearch.Controls.Add(this.calendar);
            this.panelSearch.Controls.Add(this.btUndo);
            this.panelSearch.Controls.Add(this.btSearch);
            this.panelSearch.Controls.Add(this.dtgSearch);
            this.panelSearch.Controls.Add(this.cbDot);
            this.panelSearch.Controls.Add(this.cbNam);
            this.panelSearch.Controls.Add(this.cbKy);
            this.panelSearch.Controls.Add(this.label6);
            this.panelSearch.Controls.Add(this.label5);
            this.panelSearch.Controls.Add(this.label4);
            this.panelSearch.Controls.Add(this.label3);
            this.panelSearch.Controls.Add(this.cbPhuong);
            this.panelSearch.Controls.Add(this.cbQuan);
            this.panelSearch.Controls.Add(this.sfdsad);
            this.panelSearch.Controls.Add(this.label1);
            this.panelSearch.Location = new System.Drawing.Point(4, 3);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(773, 519);
            this.panelSearch.TabIndex = 19;
            // 
            // editDot
            // 
            this.editDot.FormattingEnabled = true;
            this.editDot.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.editDot.Location = new System.Drawing.Point(662, 177);
            this.editDot.Name = "editDot";
            this.editDot.Size = new System.Drawing.Size(64, 21);
            this.editDot.TabIndex = 21;
            this.editDot.Visible = false;
            this.editDot.SelectedIndexChanged += new System.EventHandler(this.cbDot_SelectedIndexChanged);
            // 
            // editNgay
            // 
            this.editNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.editNgay.Location = new System.Drawing.Point(662, 307);
            this.editNgay.Name = "editNgay";
            this.editNgay.Size = new System.Drawing.Size(86, 20);
            this.editNgay.TabIndex = 20;
            this.editNgay.Visible = false;
            this.editNgay.ValueChanged += new System.EventHandler(this.calendar_ValueChanged);
            // 
            // editKy
            // 
            this.editKy.FormattingEnabled = true;
            this.editKy.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.editKy.Location = new System.Drawing.Point(662, 220);
            this.editKy.Name = "editKy";
            this.editKy.Size = new System.Drawing.Size(64, 21);
            this.editKy.TabIndex = 19;
            this.editKy.Visible = false;
            this.editKy.SelectedIndexChanged += new System.EventHandler(this.cbKy_SelectedIndexChanged);
            this.editKy.SelectedValueChanged += new System.EventHandler(this.editKy_SelectedValueChanged);
            // 
            // editNam
            // 
            this.editNam.FormattingEnabled = true;
            this.editNam.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.editNam.Location = new System.Drawing.Point(662, 247);
            this.editNam.Name = "editNam";
            this.editNam.Size = new System.Drawing.Size(64, 21);
            this.editNam.TabIndex = 18;
            this.editNam.Visible = false;
            this.editNam.SelectedIndexChanged += new System.EventHandler(this.cbNam_SelectedIndexChanged);
            // 
            // update
            // 
            this.update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.update.Image = global::TanHoaWater.Properties.Resources.check2;
            this.update.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.update.Location = new System.Drawing.Point(661, 124);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(77, 23);
            this.update.TabIndex = 17;
            this.update.Text = "Cập Nhật";
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // delete
            // 
            this.delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.delete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.delete.Image = global::TanHoaWater.Properties.Resources.delete2;
            this.delete.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.delete.Location = new System.Drawing.Point(661, 85);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(77, 23);
            this.delete.TabIndex = 16;
            this.delete.Text = "Xóa";
            this.delete.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // calendar
            // 
            // 
            // 
            // 
            this.calendar.BackgroundStyle.Class = "DateTimeInputBackground";
            this.calendar.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.calendar.ButtonDropDown.Visible = true;
            this.calendar.Location = new System.Drawing.Point(344, 44);
            // 
            // 
            // 
            this.calendar.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.calendar.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.calendar.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.calendar.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.calendar.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.calendar.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.calendar.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.calendar.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.calendar.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.calendar.MonthCalendar.DisplayMonth = new System.DateTime(2011, 7, 1, 0, 0, 0, 0);
            this.calendar.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.calendar.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.calendar.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.calendar.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.calendar.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.calendar.MonthCalendar.TodayButtonVisible = true;
            this.calendar.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.calendar.Name = "calendar";
            this.calendar.Size = new System.Drawing.Size(90, 20);
            this.calendar.TabIndex = 15;
            // 
            // btUndo
            // 
            this.btUndo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btUndo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btUndo.Image = global::TanHoaWater.Properties.Resources.refresh;
            this.btUndo.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btUndo.Location = new System.Drawing.Point(460, 39);
            this.btUndo.Name = "btUndo";
            this.btUndo.Size = new System.Drawing.Size(91, 25);
            this.btUndo.TabIndex = 14;
            this.btUndo.Text = "<b>Làm Lại  </b>\r\n";
            this.btUndo.Click += new System.EventHandler(this.btUndo_Click);
            // 
            // btSearch
            // 
            this.btSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btSearch.Image = global::TanHoaWater.Properties.Resources.search;
            this.btSearch.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btSearch.Location = new System.Drawing.Point(460, 5);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(91, 25);
            this.btSearch.TabIndex = 13;
            this.btSearch.Text = "<b>Tìm Kiếm </b>\r\n";
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // dtgSearch
            // 
            this.dtgSearch.AllowUserToAddRows = false;
            this.dtgSearch.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgSearch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.searchDgQuan,
            this.searchDgPhuong,
            this.searchDgKy,
            this.searchDgNam,
            this.searchDgDot,
            this.searchDgNgay});
            this.dtgSearch.Location = new System.Drawing.Point(-9, 85);
            this.dtgSearch.Name = "dtgSearch";
            this.dtgSearch.Size = new System.Drawing.Size(664, 418);
            this.dtgSearch.TabIndex = 12;
            this.dtgSearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSearch_CellClick);
            this.dtgSearch.AllowUserToOrderColumnsChanged += new System.EventHandler(this.dtgSearch_AllowUserToOrderColumnsChanged);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // searchDgQuan
            // 
            this.searchDgQuan.DataPropertyName = "Quận";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.searchDgQuan.DefaultCellStyle = dataGridViewCellStyle2;
            this.searchDgQuan.HeaderText = "Quận";
            this.searchDgQuan.Name = "searchDgQuan";
            // 
            // searchDgPhuong
            // 
            this.searchDgPhuong.DataPropertyName = "Phường";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.searchDgPhuong.DefaultCellStyle = dataGridViewCellStyle3;
            this.searchDgPhuong.HeaderText = "Phường";
            this.searchDgPhuong.Name = "searchDgPhuong";
            // 
            // searchDgKy
            // 
            this.searchDgKy.DataPropertyName = "Kỳ";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.searchDgKy.DefaultCellStyle = dataGridViewCellStyle4;
            this.searchDgKy.HeaderText = "Kỳ";
            this.searchDgKy.Name = "searchDgKy";
            // 
            // searchDgNam
            // 
            this.searchDgNam.DataPropertyName = "Năm";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.searchDgNam.DefaultCellStyle = dataGridViewCellStyle5;
            this.searchDgNam.HeaderText = "Năm";
            this.searchDgNam.Name = "searchDgNam";
            // 
            // searchDgDot
            // 
            this.searchDgDot.DataPropertyName = "Đợt";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.searchDgDot.DefaultCellStyle = dataGridViewCellStyle6;
            this.searchDgDot.HeaderText = "Đợt";
            this.searchDgDot.Name = "searchDgDot";
            // 
            // searchDgNgay
            // 
            this.searchDgNgay.DataPropertyName = "Ngày";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.searchDgNgay.DefaultCellStyle = dataGridViewCellStyle7;
            this.searchDgNgay.HeaderText = "Ngày";
            this.searchDgNgay.Name = "searchDgNgay";
            // 
            // cbDot
            // 
            this.cbDot.FormattingEnabled = true;
            this.cbDot.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cbDot.Location = new System.Drawing.Point(344, 9);
            this.cbDot.Name = "cbDot";
            this.cbDot.Size = new System.Drawing.Size(90, 21);
            this.cbDot.TabIndex = 10;
            // 
            // cbNam
            // 
            this.cbNam.FormattingEnabled = true;
            this.cbNam.Location = new System.Drawing.Point(215, 41);
            this.cbNam.Name = "cbNam";
            this.cbNam.Size = new System.Drawing.Size(71, 21);
            this.cbNam.TabIndex = 9;
            // 
            // cbKy
            // 
            this.cbKy.FormattingEnabled = true;
            this.cbKy.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbKy.Location = new System.Drawing.Point(215, 12);
            this.cbKy.Name = "cbKy";
            this.cbKy.Size = new System.Drawing.Size(71, 21);
            this.cbKy.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(304, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Ngày";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Đợt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Năm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kỳ";
            // 
            // cbPhuong
            // 
            this.cbPhuong.FormattingEnabled = true;
            this.cbPhuong.Location = new System.Drawing.Point(60, 40);
            this.cbPhuong.Name = "cbPhuong";
            this.cbPhuong.Size = new System.Drawing.Size(96, 21);
            this.cbPhuong.TabIndex = 3;
            // 
            // cbQuan
            // 
            this.cbQuan.FormattingEnabled = true;
            this.cbQuan.Location = new System.Drawing.Point(60, 13);
            this.cbQuan.Name = "cbQuan";
            this.cbQuan.Size = new System.Drawing.Size(96, 21);
            this.cbQuan.TabIndex = 2;
            this.cbQuan.SelectedIndexChanged += new System.EventHandler(this.cbQuan_SelectedIndexChanged);
            // 
            // sfdsad
            // 
            this.sfdsad.AutoSize = true;
            this.sfdsad.Location = new System.Drawing.Point(15, 44);
            this.sfdsad.Name = "sfdsad";
            this.sfdsad.Size = new System.Drawing.Size(44, 13);
            this.sfdsad.TabIndex = 1;
            this.sfdsad.Text = "Phường";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quận";
            // 
            // controlViewLich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelSearch);
            this.Name = "controlViewLich";
            this.Size = new System.Drawing.Size(780, 527);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.DataGridView dtgSearch;
        private System.Windows.Forms.ComboBox cbDot;
        private System.Windows.Forms.ComboBox cbNam;
        private System.Windows.Forms.ComboBox cbKy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPhuong;
        private System.Windows.Forms.ComboBox cbQuan;
        private System.Windows.Forms.Label sfdsad;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btUndo;
        private DevComponents.DotNetBar.ButtonX btSearch;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput calendar;
        private DevComponents.DotNetBar.ButtonX delete;
        private DevComponents.DotNetBar.ButtonX update;
        private System.Windows.Forms.ComboBox editDot;
        private System.Windows.Forms.DateTimePicker editNgay;
        private System.Windows.Forms.ComboBox editKy;
        private System.Windows.Forms.ComboBox editNam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn searchDgQuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn searchDgPhuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn searchDgKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn searchDgNam;
        private System.Windows.Forms.DataGridViewTextBoxColumn searchDgDot;
        private System.Windows.Forms.DataGridViewTextBoxColumn searchDgNgay;

    }
}
