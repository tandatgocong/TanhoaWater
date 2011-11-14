namespace TanHoaWater.View.Users.KEHOACH.HOANCONG
{
    partial class tab_TroNgaiHoanCong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.reflectionLabel6 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.cbDotHoanCong = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkChuaHoanCong = new System.Windows.Forms.RadioButton();
            this.chekDaHoanCong = new System.Windows.Forms.RadioButton();
            this.checkALl = new System.Windows.Forms.RadioButton();
            this.btHoanTat = new DevComponents.DotNetBar.ButtonX();
            this.gridHoanCong = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.hc_SHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hc_HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hc_DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hc_trongai = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hc_noidungtrongai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHoanCong)).BeginInit();
            this.SuspendLayout();
            // 
            // reflectionLabel6
            // 
            this.reflectionLabel6.Location = new System.Drawing.Point(242, 6);
            this.reflectionLabel6.Name = "reflectionLabel6";
            this.reflectionLabel6.ReflectionEnabled = false;
            this.reflectionLabel6.Size = new System.Drawing.Size(204, 25);
            this.reflectionLabel6.TabIndex = 0;
            this.reflectionLabel6.Text = "<b><font size=\"+3\">Chọn Đợt Hoàn Công</font></b>";
            // 
            // cbDotHoanCong
            // 
            this.cbDotHoanCong.DisplayMember = "Text";
            this.cbDotHoanCong.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDotHoanCong.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDotHoanCong.FormattingEnabled = true;
            this.cbDotHoanCong.ItemHeight = 23;
            this.cbDotHoanCong.Location = new System.Drawing.Point(432, 6);
            this.cbDotHoanCong.Name = "cbDotHoanCong";
            this.cbDotHoanCong.Size = new System.Drawing.Size(270, 29);
            this.cbDotHoanCong.TabIndex = 4;
            this.cbDotHoanCong.SelectedIndexChanged += new System.EventHandler(this.cbDotHoanCong_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.gridHoanCong);
            this.panel2.Controls.Add(this.checkChuaHoanCong);
            this.panel2.Controls.Add(this.chekDaHoanCong);
            this.panel2.Controls.Add(this.checkALl);
            this.panel2.Controls.Add(this.btHoanTat);
            this.panel2.Controls.Add(this.cbDotHoanCong);
            this.panel2.Controls.Add(this.reflectionLabel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(999, 585);
            this.panel2.TabIndex = 699;
            // 
            // checkChuaHoanCong
            // 
            this.checkChuaHoanCong.AutoSize = true;
            this.checkChuaHoanCong.Checked = true;
            this.checkChuaHoanCong.Location = new System.Drawing.Point(622, 37);
            this.checkChuaHoanCong.Name = "checkChuaHoanCong";
            this.checkChuaHoanCong.Size = new System.Drawing.Size(135, 23);
            this.checkChuaHoanCong.TabIndex = 8;
            this.checkChuaHoanCong.TabStop = true;
            this.checkChuaHoanCong.Text = "Chưa Hoàn Công";
            this.checkChuaHoanCong.UseVisualStyleBackColor = true;
            this.checkChuaHoanCong.CheckedChanged += new System.EventHandler(this.checkChuaHoanCong_CheckedChanged);
            // 
            // chekDaHoanCong
            // 
            this.chekDaHoanCong.AutoSize = true;
            this.chekDaHoanCong.Location = new System.Drawing.Point(502, 37);
            this.chekDaHoanCong.Name = "chekDaHoanCong";
            this.chekDaHoanCong.Size = new System.Drawing.Size(119, 23);
            this.chekDaHoanCong.TabIndex = 8;
            this.chekDaHoanCong.Text = "Đã Hoàn Công";
            this.chekDaHoanCong.UseVisualStyleBackColor = true;
            this.chekDaHoanCong.CheckedChanged += new System.EventHandler(this.chekDaHoanCong_CheckedChanged);
            // 
            // checkALl
            // 
            this.checkALl.AutoSize = true;
            this.checkALl.Location = new System.Drawing.Point(431, 37);
            this.checkALl.Name = "checkALl";
            this.checkALl.Size = new System.Drawing.Size(69, 23);
            this.checkALl.TabIndex = 8;
            this.checkALl.Text = "Tất Cả";
            this.checkALl.UseVisualStyleBackColor = true;
            this.checkALl.CheckedChanged += new System.EventHandler(this.checkALl_CheckedChanged);
            // 
            // btHoanTat
            // 
            this.btHoanTat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btHoanTat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btHoanTat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btHoanTat.Location = new System.Drawing.Point(868, 35);
            this.btHoanTat.Name = "btHoanTat";
            this.btHoanTat.Size = new System.Drawing.Size(109, 23);
            this.btHoanTat.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btHoanTat.TabIndex = 5;
            this.btHoanTat.Text = "Hoàn Tất";
            this.btHoanTat.Click += new System.EventHandler(this.btHoanTat_Click);
            // 
            // gridHoanCong
            // 
            this.gridHoanCong.AllowUserToAddRows = false;
            this.gridHoanCong.AllowUserToDeleteRows = false;
            this.gridHoanCong.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.gridHoanCong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridHoanCong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridHoanCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHoanCong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hc_SHS,
            this.hc_HoTen,
            this.hc_DiaChi,
            this.hc_trongai,
            this.hc_noidungtrongai});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridHoanCong.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridHoanCong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridHoanCong.Location = new System.Drawing.Point(15, 61);
            this.gridHoanCong.Name = "gridHoanCong";
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridHoanCong.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridHoanCong.RowHeadersWidth = 10;
            this.gridHoanCong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridHoanCong.Size = new System.Drawing.Size(969, 516);
            this.gridHoanCong.TabIndex = 9;
            // 
            // hc_SHS
            // 
            this.hc_SHS.DataPropertyName = "SHS";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.hc_SHS.DefaultCellStyle = dataGridViewCellStyle2;
            this.hc_SHS.Frozen = true;
            this.hc_SHS.HeaderText = "Số Hồ Sơ";
            this.hc_SHS.Name = "hc_SHS";
            this.hc_SHS.ReadOnly = true;
            this.hc_SHS.Width = 85;
            // 
            // hc_HoTen
            // 
            this.hc_HoTen.DataPropertyName = "HOTEN";
            this.hc_HoTen.Frozen = true;
            this.hc_HoTen.HeaderText = "Họ và Tên";
            this.hc_HoTen.Name = "hc_HoTen";
            this.hc_HoTen.ReadOnly = true;
            this.hc_HoTen.Width = 170;
            // 
            // hc_DiaChi
            // 
            this.hc_DiaChi.DataPropertyName = "DIACHI";
            this.hc_DiaChi.Frozen = true;
            this.hc_DiaChi.HeaderText = "Địa Chỉ";
            this.hc_DiaChi.Name = "hc_DiaChi";
            this.hc_DiaChi.ReadOnly = true;
            this.hc_DiaChi.Width = 280;
            // 
            // hc_trongai
            // 
            this.hc_trongai.DataPropertyName = "TRONGAI";
            this.hc_trongai.HeaderText = "Trở Ngại";
            this.hc_trongai.Name = "hc_trongai";
            this.hc_trongai.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hc_trongai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.hc_trongai.Width = 80;
            // 
            // hc_noidungtrongai
            // 
            this.hc_noidungtrongai.DataPropertyName = "NOIDUNGTN";
            this.hc_noidungtrongai.HeaderText = "Nội Dung Trở Ngại";
            this.hc_noidungtrongai.Name = "hc_noidungtrongai";
            this.hc_noidungtrongai.Width = 350;
            // 
            // tab_TroNgaiHoanCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "tab_TroNgaiHoanCong";
            this.Size = new System.Drawing.Size(999, 585);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHoanCong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbDotHoanCong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton checkChuaHoanCong;
        private System.Windows.Forms.RadioButton chekDaHoanCong;
        private System.Windows.Forms.RadioButton checkALl;
        private DevComponents.DotNetBar.ButtonX btHoanTat;
        private DevComponents.DotNetBar.Controls.DataGridViewX gridHoanCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn hc_SHS;
        private System.Windows.Forms.DataGridViewTextBoxColumn hc_HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn hc_DiaChi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hc_trongai;
        private System.Windows.Forms.DataGridViewTextBoxColumn hc_noidungtrongai;


    }
}
