namespace TanHoaWater.View.Users.KEHOACH
{
    partial class dialogNhapDon
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
            this.txtSHS = new System.Windows.Forms.MaskedTextBox();
            this.dienthoai = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ghichu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.cbLoaiKH = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbPhuong = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbQuan = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.soho = new System.Windows.Forms.NumericUpDown();
            this.duong = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.sonha = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtHoTen = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtSoHoSo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDotNhanDon = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.btInsert = new DevComponents.DotNetBar.ButtonX();
            this.cbLoaiHS = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtDanhBo = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.soho)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSHS
            // 
            this.txtSHS.Location = new System.Drawing.Point(128, 47);
            this.txtSHS.Name = "txtSHS";
            this.txtSHS.PromptChar = ' ';
            this.txtSHS.Size = new System.Drawing.Size(106, 26);
            this.txtSHS.TabIndex = 36;
            this.txtSHS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSHS_KeyPress);
            this.txtSHS.MouseLeave += new System.EventHandler(this.txtSHS_MouseLeave);
            // 
            // dienthoai
            // 
            this.dienthoai.Location = new System.Drawing.Point(333, 170);
            this.dienthoai.Name = "dienthoai";
            this.dienthoai.PromptChar = ' ';
            this.dienthoai.Size = new System.Drawing.Size(116, 26);
            this.dienthoai.TabIndex = 49;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(59, 210);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 19);
            this.label15.TabIndex = 54;
            this.label15.Text = "Danh Bộ";
            // 
            // ghichu
            // 
            // 
            // 
            // 
            this.ghichu.Border.Class = "TextBoxBorder";
            this.ghichu.Location = new System.Drawing.Point(127, 235);
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(322, 26);
            this.ghichu.TabIndex = 50;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(56, 237);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 19);
            this.label10.TabIndex = 53;
            this.label10.Text = "Ghi Chú";
            // 
            // cbLoaiKH
            // 
            this.cbLoaiKH.DisplayMember = "Text";
            this.cbLoaiKH.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLoaiKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiKH.FormattingEnabled = true;
            this.cbLoaiKH.ItemHeight = 20;
            this.cbLoaiKH.Location = new System.Drawing.Point(128, 171);
            this.cbLoaiKH.Name = "cbLoaiKH";
            this.cbLoaiKH.Size = new System.Drawing.Size(140, 26);
            this.cbLoaiKH.TabIndex = 48;
            // 
            // cbPhuong
            // 
            this.cbPhuong.DisplayMember = "Text";
            this.cbPhuong.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPhuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPhuong.FormattingEnabled = true;
            this.cbPhuong.ItemHeight = 20;
            this.cbPhuong.Location = new System.Drawing.Point(128, 141);
            this.cbPhuong.Name = "cbPhuong";
            this.cbPhuong.Size = new System.Drawing.Size(140, 26);
            this.cbPhuong.TabIndex = 47;
            this.cbPhuong.SelectedValueChanged += new System.EventHandler(this.cbPhuong_SelectedValueChanged);
            // 
            // cbQuan
            // 
            this.cbQuan.DisplayMember = "Text";
            this.cbQuan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbQuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuan.FormattingEnabled = true;
            this.cbQuan.ItemHeight = 20;
            this.cbQuan.Location = new System.Drawing.Point(321, 140);
            this.cbQuan.Name = "cbQuan";
            this.cbQuan.Size = new System.Drawing.Size(129, 26);
            this.cbQuan.TabIndex = 46;
            this.cbQuan.SelectedValueChanged += new System.EventHandler(this.cbQuan_SelectedValueChanged);
            // 
            // soho
            // 
            this.soho.Location = new System.Drawing.Point(410, 47);
            this.soho.Name = "soho";
            this.soho.Size = new System.Drawing.Size(48, 26);
            this.soho.TabIndex = 37;
            this.soho.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // duong
            // 
            // 
            // 
            // 
            this.duong.Border.Class = "TextBoxBorder";
            this.duong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duong.Location = new System.Drawing.Point(223, 108);
            this.duong.Multiline = true;
            this.duong.Name = "duong";
            this.duong.Size = new System.Drawing.Size(226, 25);
            this.duong.TabIndex = 45;
            // 
            // sonha
            // 
            // 
            // 
            // 
            this.sonha.Border.Class = "TextBoxBorder";
            this.sonha.Location = new System.Drawing.Point(128, 108);
            this.sonha.Multiline = true;
            this.sonha.Name = "sonha";
            this.sonha.Size = new System.Drawing.Size(89, 25);
            this.sonha.TabIndex = 42;
            // 
            // txtHoTen
            // 
            // 
            // 
            // 
            this.txtHoTen.Border.Class = "TextBoxBorder";
            this.txtHoTen.Location = new System.Drawing.Point(128, 77);
            this.txtHoTen.Multiline = true;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(322, 25);
            this.txtHoTen.TabIndex = 40;
            // 
            // txtSoHoSo
            // 
            // 
            // 
            // 
            this.txtSoHoSo.Border.Class = "TextBoxBorder";
            this.txtSoHoSo.Location = new System.Drawing.Point(240, 47);
            this.txtSoHoSo.Name = "txtSoHoSo";
            this.txtSoHoSo.ReadOnly = true;
            this.txtSoHoSo.Size = new System.Drawing.Size(120, 26);
            this.txtSoHoSo.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 19);
            this.label7.TabIndex = 44;
            this.label7.Text = "Địa Chỉ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(278, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 19);
            this.label6.TabIndex = 43;
            this.label6.Text = "Quận";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 19);
            this.label5.TabIndex = 41;
            this.label5.Text = "Phường";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(57, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "Loại K.H";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 19);
            this.label3.TabIndex = 38;
            this.label3.Text = "Số ĐT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 35;
            this.label2.Text = "Họ - Tên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 34;
            this.label1.Text = "Mã Hồ Sơ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(359, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 19);
            this.label8.TabIndex = 51;
            this.label8.Text = "Số Hộ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 19);
            this.label9.TabIndex = 56;
            this.label9.Text = "Đợt Nhận Đơn";
            // 
            // txtDotNhanDon
            // 
            // 
            // 
            // 
            this.txtDotNhanDon.Border.Class = "TextBoxBorder";
            this.txtDotNhanDon.Location = new System.Drawing.Point(129, 15);
            this.txtDotNhanDon.Name = "txtDotNhanDon";
            this.txtDotNhanDon.ReadOnly = true;
            this.txtDotNhanDon.Size = new System.Drawing.Size(191, 26);
            this.txtDotNhanDon.TabIndex = 55;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX2.Image = global::TanHoaWater.Properties.Resources.refresh;
            this.buttonX2.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.buttonX2.Location = new System.Drawing.Point(251, 283);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(93, 23);
            this.buttonX2.TabIndex = 58;
            this.buttonX2.Text = "Làm Lại";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // btInsert
            // 
            this.btInsert.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btInsert.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInsert.Image = global::TanHoaWater.Properties.Resources.add;
            this.btInsert.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btInsert.Location = new System.Drawing.Point(127, 283);
            this.btInsert.Name = "btInsert";
            this.btInsert.Size = new System.Drawing.Size(104, 23);
            this.btInsert.TabIndex = 57;
            this.btInsert.Text = "Thêm Mới";
            this.btInsert.Click += new System.EventHandler(this.btInsert_Click);
            // 
            // cbLoaiHS
            // 
            this.cbLoaiHS.DisplayMember = "Text";
            this.cbLoaiHS.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLoaiHS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiHS.DropDownWidth = 250;
            this.cbLoaiHS.FormattingEnabled = true;
            this.cbLoaiHS.ItemHeight = 20;
            this.cbLoaiHS.Location = new System.Drawing.Point(353, 280);
            this.cbLoaiHS.Name = "cbLoaiHS";
            this.cbLoaiHS.Size = new System.Drawing.Size(97, 26);
            this.cbLoaiHS.TabIndex = 59;
            this.cbLoaiHS.Visible = false;
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(128, 203);
            this.txtDanhBo.Mask = "0000-0000000";
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(131, 26);
            this.txtDanhBo.TabIndex = 60;
            // 
            // dialogNhapDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(497, 338);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.cbLoaiHS);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.btInsert);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSHS);
            this.Controls.Add(this.dienthoai);
            this.Controls.Add(this.txtDotNhanDon);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbLoaiKH);
            this.Controls.Add(this.cbPhuong);
            this.Controls.Add(this.cbQuan);
            this.Controls.Add(this.soho);
            this.Controls.Add(this.duong);
            this.Controls.Add(this.sonha);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtSoHoSo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "dialogNhapDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập Đơn Khách Hàng";
            ((System.ComponentModel.ISupportInitialize)(this.soho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtSHS;
        private System.Windows.Forms.MaskedTextBox dienthoai;
        private System.Windows.Forms.Label label15;
        private DevComponents.DotNetBar.Controls.TextBoxX ghichu;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbLoaiKH;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbPhuong;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbQuan;
        private System.Windows.Forms.NumericUpDown soho;
        private DevComponents.DotNetBar.Controls.TextBoxX duong;
        private DevComponents.DotNetBar.Controls.TextBoxX sonha;
        private DevComponents.DotNetBar.Controls.TextBoxX txtHoTen;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSoHoSo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDotNhanDon;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX btInsert;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbLoaiHS;
        private System.Windows.Forms.MaskedTextBox txtDanhBo;
    }
}