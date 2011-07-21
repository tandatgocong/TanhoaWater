namespace TanHoaWater.View.QLDHN
{
    partial class controlAddLich
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
            this.panelAdd = new System.Windows.Forms.Panel();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.nam = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.calendar = new System.Windows.Forms.DateTimePicker();
            this.cbPhuong = new System.Windows.Forms.ComboBox();
            this.cbKy = new System.Windows.Forms.ComboBox();
            this.cbDot = new System.Windows.Forms.ComboBox();
            this.cbQuan = new System.Windows.Forms.ComboBox();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.btSave = new DevComponents.DotNetBar.ButtonX();
            this.dtg2 = new System.Windows.Forms.DataGridView();
            this.reflectionLabel1 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.quan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAdd
            // 
            this.panelAdd.Controls.Add(this.buttonX1);
            this.panelAdd.Controls.Add(this.nam);
            this.panelAdd.Controls.Add(this.calendar);
            this.panelAdd.Controls.Add(this.cbPhuong);
            this.panelAdd.Controls.Add(this.cbKy);
            this.panelAdd.Controls.Add(this.cbDot);
            this.panelAdd.Controls.Add(this.cbQuan);
            this.panelAdd.Controls.Add(this.buttonX2);
            this.panelAdd.Controls.Add(this.btSave);
            this.panelAdd.Controls.Add(this.dtg2);
            this.panelAdd.Controls.Add(this.reflectionLabel1);
            this.panelAdd.Location = new System.Drawing.Point(0, 3);
            this.panelAdd.Name = "panelAdd";
            this.panelAdd.Size = new System.Drawing.Size(722, 559);
            this.panelAdd.TabIndex = 5;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Image = global::TanHoaWater.Properties.Resources.add;
            this.buttonX1.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.buttonX1.Location = new System.Drawing.Point(602, 44);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(88, 30);
            this.buttonX1.TabIndex = 16;
            this.buttonX1.Text = "Thêm dòng";
            this.buttonX1.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.buttonX1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nam
            // 
            this.nam.DisplayMember = "Text";
            this.nam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.nam.FormattingEnabled = true;
            this.nam.ItemHeight = 14;
            this.nam.Location = new System.Drawing.Point(450, 8);
            this.nam.Name = "nam";
            this.nam.Size = new System.Drawing.Size(53, 20);
            this.nam.TabIndex = 15;
            // 
            // calendar
            // 
            this.calendar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.calendar.Location = new System.Drawing.Point(491, 520);
            this.calendar.Name = "calendar";
            this.calendar.Size = new System.Drawing.Size(86, 20);
            this.calendar.TabIndex = 13;
            this.calendar.Visible = false;
            this.calendar.ValueChanged += new System.EventHandler(this.calendar_ValueChanged);
            // 
            // cbPhuong
            // 
            this.cbPhuong.DropDownWidth = 120;
            this.cbPhuong.FormattingEnabled = true;
            this.cbPhuong.Items.AddRange(new object[] {
            "PHUONG1",
            "PHUONG2"});
            this.cbPhuong.Location = new System.Drawing.Point(124, 520);
            this.cbPhuong.Name = "cbPhuong";
            this.cbPhuong.Size = new System.Drawing.Size(121, 21);
            this.cbPhuong.TabIndex = 10;
            this.cbPhuong.Visible = false;
            this.cbPhuong.SelectedIndexChanged += new System.EventHandler(this.cbPhuong_SelectedIndexChanged);
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
            this.cbKy.Location = new System.Drawing.Point(331, 520);
            this.cbKy.Name = "cbKy";
            this.cbKy.Size = new System.Drawing.Size(64, 21);
            this.cbKy.TabIndex = 8;
            this.cbKy.Visible = false;
            this.cbKy.SelectedIndexChanged += new System.EventHandler(this.cbKy_SelectedIndexChanged);
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
            this.cbDot.Location = new System.Drawing.Point(427, 520);
            this.cbDot.Name = "cbDot";
            this.cbDot.Size = new System.Drawing.Size(57, 21);
            this.cbDot.TabIndex = 7;
            this.cbDot.Visible = false;
            this.cbDot.SelectedIndexChanged += new System.EventHandler(this.cbDot_SelectedIndexChanged);
            // 
            // cbQuan
            // 
            this.cbQuan.DropDownWidth = 100;
            this.cbQuan.FormattingEnabled = true;
            this.cbQuan.Items.AddRange(new object[] {
            "TP",
            "TB"});
            this.cbQuan.Location = new System.Drawing.Point(-3, 520);
            this.cbQuan.Name = "cbQuan";
            this.cbQuan.Size = new System.Drawing.Size(121, 21);
            this.cbQuan.TabIndex = 5;
            this.cbQuan.Visible = false;
            this.cbQuan.SelectedIndexChanged += new System.EventHandler(this.cbQuan_SelectedIndexChanged);
            this.cbQuan.SelectedValueChanged += new System.EventHandler(this.cbQuan_SelectedValueChanged);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX2.Image = global::TanHoaWater.Properties.Resources.stop;
            this.buttonX2.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.buttonX2.Location = new System.Drawing.Point(602, 122);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(88, 23);
            this.buttonX2.TabIndex = 4;
            this.buttonX2.Text = "Hủy";
            this.buttonX2.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // btSave
            // 
            this.btSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.Image = global::TanHoaWater.Properties.Resources.save;
            this.btSave.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btSave.Location = new System.Drawing.Point(602, 86);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(88, 23);
            this.btSave.TabIndex = 3;
            this.btSave.Text = "Lưu";
            this.btSave.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // dtg2
            // 
            this.dtg2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtg2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.quan,
            this.phuong,
            this.ky,
            this.dot,
            this.ngay});
            this.dtg2.Location = new System.Drawing.Point(15, 44);
            this.dtg2.Name = "dtg2";
            this.dtg2.Size = new System.Drawing.Size(572, 496);
            this.dtg2.TabIndex = 2;
            this.dtg2.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg2_CellValidated);
            this.dtg2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // reflectionLabel1
            // 
            this.reflectionLabel1.Location = new System.Drawing.Point(218, 3);
            this.reflectionLabel1.Name = "reflectionLabel1";
            this.reflectionLabel1.Size = new System.Drawing.Size(266, 35);
            this.reflectionLabel1.TabIndex = 0;
            this.reflectionLabel1.Text = "<b><font size=\"+5\"><font color=\"#0055A8\">Lịch Ghi Chỉ Số  Nước Năm  </font></font" +
                "></b>";
            // 
            // quan
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.quan.DefaultCellStyle = dataGridViewCellStyle1;
            this.quan.HeaderText = "Quận";
            this.quan.Name = "quan";
            this.quan.ReadOnly = true;
            // 
            // phuong
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.phuong.DefaultCellStyle = dataGridViewCellStyle2;
            this.phuong.HeaderText = "Phường";
            this.phuong.Name = "phuong";
            this.phuong.ReadOnly = true;
            this.phuong.Width = 120;
            // 
            // ky
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ky.DefaultCellStyle = dataGridViewCellStyle3;
            this.ky.HeaderText = "Kỳ";
            this.ky.Name = "ky";
            this.ky.ReadOnly = true;
            // 
            // dot
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dot.DefaultCellStyle = dataGridViewCellStyle4;
            this.dot.HeaderText = "Đợt";
            this.dot.Name = "dot";
            this.dot.ReadOnly = true;
            // 
            // ngay
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ngay.DefaultCellStyle = dataGridViewCellStyle5;
            this.ngay.HeaderText = "Ngày Ghi";
            this.ngay.Name = "ngay";
            this.ngay.ReadOnly = true;
            // 
            // controlAddLich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelAdd);
            this.Name = "controlAddLich";
            this.Size = new System.Drawing.Size(728, 562);
            this.panelAdd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAdd;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx nam;
        private System.Windows.Forms.DateTimePicker calendar;
        private System.Windows.Forms.ComboBox cbPhuong;
        private System.Windows.Forms.ComboBox cbKy;
        private System.Windows.Forms.ComboBox cbDot;
        private System.Windows.Forms.ComboBox cbQuan;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX btSave;
        private System.Windows.Forms.DataGridView dtg2;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn quan;
        private System.Windows.Forms.DataGridViewTextBoxColumn phuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn dot;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngay;

    }
}
