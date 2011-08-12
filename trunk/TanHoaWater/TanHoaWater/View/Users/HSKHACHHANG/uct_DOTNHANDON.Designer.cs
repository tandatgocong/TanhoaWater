namespace TanHoaWater.View.Users.HSKHACHHANG
{
    partial class uct_DOTNHANDON
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.reflectionLabel1 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.SOHOSO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HOTEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIACHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAY_NHAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refresh = new DevComponents.DotNetBar.ButtonX();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DOTNHAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAYNHAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOAIDON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addNewDot = new DevComponents.DotNetBar.ButtonX();
            this.SearchDot = new DevComponents.DotNetBar.ButtonX();
            this.cbLoaiHS = new System.Windows.Forms.ComboBox();
            this.txtsoDot = new System.Windows.Forms.MaskedTextBox();
            this.createDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.createDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // reflectionLabel1
            // 
            this.reflectionLabel1.Location = new System.Drawing.Point(243, 0);
            this.reflectionLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.reflectionLabel1.Name = "reflectionLabel1";
            this.reflectionLabel1.Size = new System.Drawing.Size(691, 65);
            this.reflectionLabel1.TabIndex = 0;
            this.reflectionLabel1.Text = "<font color=\"#ED1C24\"><b><font size=\"+6\">DANH SÁCH CÁC ĐỢT NHẬN ĐƠN KHÁCH HÀNG</f" +
                "ont></b></font>";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.refresh);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.addNewDot);
            this.groupBox1.Controls.Add(this.SearchDot);
            this.groupBox1.Controls.Add(this.cbLoaiHS);
            this.groupBox1.Controls.Add(this.txtsoDot);
            this.groupBox1.Controls.Add(this.createDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(972, 563);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Location = new System.Drawing.Point(603, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(369, 459);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách Khách Hàng của Đợt nhận đơn ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(11, 426);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Có 0 khách hàng đợt nhận đơn";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SOHOSO,
            this.HOTEN,
            this.DIACHI,
            this.NGAY_NHAN});
            this.dataGridView2.Location = new System.Drawing.Point(6, 43);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(354, 380);
            this.dataGridView2.TabIndex = 20;
            // 
            // SOHOSO
            // 
            this.SOHOSO.HeaderText = "Số Hồ Sơ";
            this.SOHOSO.Name = "SOHOSO";
            this.SOHOSO.ReadOnly = true;
            // 
            // HOTEN
            // 
            this.HOTEN.HeaderText = "Họ Tên";
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.ReadOnly = true;
            // 
            // DIACHI
            // 
            this.DIACHI.HeaderText = "Địa Chỉ";
            this.DIACHI.Name = "DIACHI";
            this.DIACHI.ReadOnly = true;
            // 
            // NGAY_NHAN
            // 
            this.NGAY_NHAN.HeaderText = "Ngày Nhận";
            this.NGAY_NHAN.Name = "NGAY_NHAN";
            this.NGAY_NHAN.ReadOnly = true;
            // 
            // refresh
            // 
            this.refresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.refresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh.Image = global::TanHoaWater.Properties.Resources.refresh;
            this.refresh.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.refresh.Location = new System.Drawing.Point(518, 69);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(75, 23);
            this.refresh.TabIndex = 18;
            this.refresh.Text = "Làm lại    ";
            this.refresh.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DOTNHAN,
            this.NGAYNHAN,
            this.LOAIDON,
            this.SATUS});
            this.dataGridView1.Location = new System.Drawing.Point(6, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(591, 450);
            this.dataGridView1.TabIndex = 17;
            // 
            // DOTNHAN
            // 
            this.DOTNHAN.DataPropertyName = "MADOT";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DOTNHAN.DefaultCellStyle = dataGridViewCellStyle1;
            this.DOTNHAN.HeaderText = "Đợt Nhận Đơn";
            this.DOTNHAN.Name = "DOTNHAN";
            this.DOTNHAN.ReadOnly = true;
            this.DOTNHAN.Width = 115;
            // 
            // NGAYNHAN
            // 
            this.NGAYNHAN.DataPropertyName = "NGAYLAPDON";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NGAYNHAN.DefaultCellStyle = dataGridViewCellStyle2;
            this.NGAYNHAN.HeaderText = "Ngày Lập Đơn";
            this.NGAYNHAN.Name = "NGAYNHAN";
            this.NGAYNHAN.ReadOnly = true;
            this.NGAYNHAN.Width = 120;
            // 
            // LOAIDON
            // 
            this.LOAIDON.DataPropertyName = "TENLOAI";
            this.LOAIDON.HeaderText = "Loại Đơn Nhận";
            this.LOAIDON.Name = "LOAIDON";
            this.LOAIDON.ReadOnly = true;
            this.LOAIDON.Width = 250;
            // 
            // SATUS
            // 
            this.SATUS.DataPropertyName = "CHUYEN";
            this.SATUS.HeaderText = "Tình Trạng";
            this.SATUS.Name = "SATUS";
            this.SATUS.ReadOnly = true;
            // 
            // addNewDot
            // 
            this.addNewDot.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.addNewDot.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.addNewDot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewDot.Image = global::TanHoaWater.Properties.Resources.note_add;
            this.addNewDot.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.addNewDot.Location = new System.Drawing.Point(314, 69);
            this.addNewDot.Margin = new System.Windows.Forms.Padding(4);
            this.addNewDot.Name = "addNewDot";
            this.addNewDot.Size = new System.Drawing.Size(89, 22);
            this.addNewDot.TabIndex = 16;
            this.addNewDot.Text = "Thêm Mới    ";
            this.addNewDot.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.addNewDot.Click += new System.EventHandler(this.addNewDot_Click);
            // 
            // SearchDot
            // 
            this.SearchDot.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.SearchDot.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.SearchDot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchDot.Image = global::TanHoaWater.Properties.Resources.search2;
            this.SearchDot.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.SearchDot.Location = new System.Drawing.Point(411, 70);
            this.SearchDot.Margin = new System.Windows.Forms.Padding(4);
            this.SearchDot.Name = "SearchDot";
            this.SearchDot.Size = new System.Drawing.Size(87, 22);
            this.SearchDot.TabIndex = 15;
            this.SearchDot.Text = "Tìm Kiếm   ";
            this.SearchDot.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.SearchDot.Click += new System.EventHandler(this.SearchDot_Click);
            // 
            // cbLoaiHS
            // 
            this.cbLoaiHS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiHS.FormattingEnabled = true;
            this.cbLoaiHS.Location = new System.Drawing.Point(298, 38);
            this.cbLoaiHS.Margin = new System.Windows.Forms.Padding(4);
            this.cbLoaiHS.Name = "cbLoaiHS";
            this.cbLoaiHS.Size = new System.Drawing.Size(295, 24);
            this.cbLoaiHS.TabIndex = 14;
            // 
            // txtsoDot
            // 
            this.txtsoDot.Location = new System.Drawing.Point(17, 37);
            this.txtsoDot.Margin = new System.Windows.Forms.Padding(4);
            this.txtsoDot.Mask = "0000/0000";
            this.txtsoDot.Name = "txtsoDot";
            this.txtsoDot.Size = new System.Drawing.Size(106, 22);
            this.txtsoDot.TabIndex = 13;
            // 
            // createDate
            // 
            // 
            // 
            // 
            this.createDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.createDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.createDate.ButtonDropDown.Visible = true;
            this.createDate.Location = new System.Drawing.Point(164, 38);
            this.createDate.Margin = new System.Windows.Forms.Padding(4);
            // 
            // 
            // 
            this.createDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.createDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.createDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.createDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.createDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.createDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.createDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.createDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.createDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.createDate.MonthCalendar.DisplayMonth = new System.DateTime(2011, 8, 1, 0, 0, 0, 0);
            this.createDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.createDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.createDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.createDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.createDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.createDate.MonthCalendar.TodayButtonVisible = true;
            this.createDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.createDate.Name = "createDate";
            this.createDate.Size = new System.Drawing.Size(89, 22);
            this.createDate.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Loại Đơn Nhận";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ngày Tạo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Số Đợt Nhận Đơn";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // uct_DOTNHANDON
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reflectionLabel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uct_DOTNHANDON";
            this.Size = new System.Drawing.Size(988, 615);
            this.Load += new System.EventHandler(this.DOTNHANDON_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.createDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX addNewDot;
        private DevComponents.DotNetBar.ButtonX SearchDot;
        private System.Windows.Forms.ComboBox cbLoaiHS;
        private System.Windows.Forms.MaskedTextBox txtsoDot;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput createDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.ButtonX refresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOTNHAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYNHAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOAIDON;
        private System.Windows.Forms.DataGridViewTextBoxColumn SATUS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOHOSO;
        private System.Windows.Forms.DataGridViewTextBoxColumn HOTEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIACHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAY_NHAN;
        private System.Windows.Forms.Label label4;
    }
}
