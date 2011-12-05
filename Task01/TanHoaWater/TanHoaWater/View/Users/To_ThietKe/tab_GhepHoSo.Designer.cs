namespace TanHoaWater.View.Users.To_ThietKe
{
    partial class tab_GhepHoSo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btGhep = new DevComponents.DotNetBar.ButtonX();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dotnhandon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mahoso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diachi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daidien = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cbDotNhanDon = new System.Windows.Forms.TextBox();
            this.txtSHS = new System.Windows.Forms.MaskedTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dienthoai = new System.Windows.Forms.MaskedTextBox();
            this.btAdd = new DevComponents.DotNetBar.ButtonX();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSoHoSo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtHoTen = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.duong = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btGhep);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.cbDotNhanDon);
            this.panel1.Controls.Add(this.txtSHS);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.dienthoai);
            this.panel1.Controls.Add(this.btAdd);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtSoHoSo);
            this.panel1.Controls.Add(this.txtHoTen);
            this.panel1.Controls.Add(this.duong);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 555);
            this.panel1.TabIndex = 1;
            // 
            // btGhep
            // 
            this.btGhep.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btGhep.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btGhep.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGhep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btGhep.Location = new System.Drawing.Point(871, 64);
            this.btGhep.Name = "btGhep";
            this.btGhep.Size = new System.Drawing.Size(108, 23);
            this.btGhep.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btGhep.TabIndex = 118;
            this.btGhep.Text = "Ghép Hồ Sơ";
            this.btGhep.Click += new System.EventHandler(this.btGhep_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dotnhandon,
            this.mahoso,
            this.hoten,
            this.diachi,
            this.dt,
            this.daidien});
            this.dataGridView1.Location = new System.Drawing.Point(0, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.Size = new System.Drawing.Size(979, 427);
            this.dataGridView1.TabIndex = 117;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dotnhandon
            // 
            this.dotnhandon.DataPropertyName = "DOTNHANDON";
            this.dotnhandon.HeaderText = "Đợt Nhận Đơn";
            this.dotnhandon.Name = "dotnhandon";
            this.dotnhandon.Width = 125;
            // 
            // mahoso
            // 
            this.mahoso.DataPropertyName = "SOHOSO";
            this.mahoso.HeaderText = "Số Hồ Sơ";
            this.mahoso.Name = "mahoso";
            // 
            // hoten
            // 
            this.hoten.DataPropertyName = "HOTEN";
            this.hoten.HeaderText = "Họ - Tên";
            this.hoten.Name = "hoten";
            this.hoten.Width = 210;
            // 
            // diachi
            // 
            this.diachi.DataPropertyName = "DIACHI";
            this.diachi.HeaderText = "Địa Chỉ";
            this.diachi.Name = "diachi";
            this.diachi.Width = 300;
            // 
            // dt
            // 
            this.dt.DataPropertyName = "DIENTHOAI";
            this.dt.HeaderText = "Điện Thoại";
            this.dt.Name = "dt";
            this.dt.Width = 120;
            // 
            // daidien
            // 
            this.daidien.DataPropertyName = "DAIDIEN";
            this.daidien.HeaderText = "Đại Diện";
            this.daidien.Name = "daidien";
            this.daidien.Width = 90;
            // 
            // cbDotNhanDon
            // 
            this.cbDotNhanDon.Location = new System.Drawing.Point(654, 41);
            this.cbDotNhanDon.Name = "cbDotNhanDon";
            this.cbDotNhanDon.ReadOnly = true;
            this.cbDotNhanDon.Size = new System.Drawing.Size(124, 26);
            this.cbDotNhanDon.TabIndex = 116;
            // 
            // txtSHS
            // 
            this.txtSHS.Location = new System.Drawing.Point(92, 9);
            this.txtSHS.Name = "txtSHS";
            this.txtSHS.PromptChar = ' ';
            this.txtSHS.Size = new System.Drawing.Size(107, 26);
            this.txtSHS.TabIndex = 115;
            this.txtSHS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSHS_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(579, 44);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 19);
            this.label17.TabIndex = 111;
            this.label17.Text = "Đợt N.Đơn";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(398, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 19);
            this.label13.TabIndex = 85;
            this.label13.Text = "Số ĐT";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 19);
            this.label15.TabIndex = 82;
            this.label15.Text = "Mã Hồ Sơ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 19);
            this.label14.TabIndex = 84;
            this.label14.Text = "Họ - Tên";
            // 
            // dienthoai
            // 
            this.dienthoai.Location = new System.Drawing.Point(453, 41);
            this.dienthoai.Mask = "00000000000";
            this.dienthoai.Name = "dienthoai";
            this.dienthoai.PromptChar = ' ';
            this.dienthoai.ReadOnly = true;
            this.dienthoai.Size = new System.Drawing.Size(118, 26);
            this.dienthoai.TabIndex = 18;
            // 
            // btAdd
            // 
            this.btAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btAdd.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdd.Image = global::TanHoaWater.Properties.Resources.update;
            this.btAdd.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btAdd.Location = new System.Drawing.Point(796, 11);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(116, 23);
            this.btAdd.TabIndex = 25;
            this.btAdd.Text = "Thêm Hồ Sơ";
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(394, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 19);
            this.label7.TabIndex = 93;
            this.label7.Text = "Địa Chỉ";
            // 
            // txtSoHoSo
            // 
            // 
            // 
            // 
            this.txtSoHoSo.Border.Class = "TextBoxBorder";
            this.txtSoHoSo.Location = new System.Drawing.Point(205, 10);
            this.txtSoHoSo.Name = "txtSoHoSo";
            this.txtSoHoSo.ReadOnly = true;
            this.txtSoHoSo.Size = new System.Drawing.Size(175, 26);
            this.txtSoHoSo.TabIndex = 9;
            // 
            // txtHoTen
            // 
            // 
            // 
            // 
            this.txtHoTen.Border.Class = "TextBoxBorder";
            this.txtHoTen.Location = new System.Drawing.Point(92, 38);
            this.txtHoTen.Multiline = true;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(288, 27);
            this.txtHoTen.TabIndex = 11;
            // 
            // duong
            // 
            // 
            // 
            // 
            this.duong.Border.Class = "TextBoxBorder";
            this.duong.Location = new System.Drawing.Point(453, 9);
            this.duong.Multiline = true;
            this.duong.Name = "duong";
            this.duong.ReadOnly = true;
            this.duong.Size = new System.Drawing.Size(325, 27);
            this.duong.TabIndex = 13;
            // 
            // tab_GhepHoSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "tab_GhepHoSo";
            this.Size = new System.Drawing.Size(995, 628);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox dienthoai;
        private DevComponents.DotNetBar.ButtonX btAdd;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSoHoSo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtHoTen;
        private DevComponents.DotNetBar.Controls.TextBoxX duong;
        private System.Windows.Forms.MaskedTextBox txtSHS;
        private System.Windows.Forms.TextBox cbDotNhanDon;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevComponents.DotNetBar.ButtonX btGhep;
        private System.Windows.Forms.DataGridViewTextBoxColumn dotnhandon;
        private System.Windows.Forms.DataGridViewTextBoxColumn mahoso;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn diachi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dt;
        private System.Windows.Forms.DataGridViewCheckBoxColumn daidien;

    }
}
