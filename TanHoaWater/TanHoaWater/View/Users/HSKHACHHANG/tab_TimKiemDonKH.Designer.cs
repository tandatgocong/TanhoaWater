namespace TanHoaWater.View.Users.HSKHACHHANG
{
    partial class tab_TimKiemDonKH
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.searchSoNha = new System.Windows.Forms.TextBox();
            this.lbPaing = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.next = new System.Windows.Forms.PictureBox();
            this.searchLamLai = new DevComponents.DotNetBar.ButtonX();
            this.searchTimKiem = new DevComponents.DotNetBar.ButtonX();
            this.label4 = new System.Windows.Forms.Label();
            this.searchDiaChi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataSearCh = new System.Windows.Forms.DataGridView();
            this.G_SodotNhanDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOHOSO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HOTEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIACHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAY_NHAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_LoaiHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchHoTenKH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchMaHoSo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SearchDotNhanDon = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.next)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSearCh)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SearchDotNhanDon);
            this.groupBox1.Controls.Add(this.searchSoNha);
            this.groupBox1.Controls.Add(this.lbPaing);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.next);
            this.groupBox1.Controls.Add(this.searchLamLai);
            this.groupBox1.Controls.Add(this.searchTimKiem);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.searchDiaChi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dataSearCh);
            this.groupBox1.Controls.Add(this.searchHoTenKH);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.SearchMaHoSo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(569, 514);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm";
            // 
            // searchSoNha
            // 
            this.searchSoNha.Location = new System.Drawing.Point(304, 51);
            this.searchSoNha.Margin = new System.Windows.Forms.Padding(4);
            this.searchSoNha.Name = "searchSoNha";
            this.searchSoNha.Size = new System.Drawing.Size(65, 22);
            this.searchSoNha.TabIndex = 4;
            this.searchSoNha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchSoNha_KeyPress);
            // 
            // lbPaing
            // 
            this.lbPaing.AutoSize = true;
            this.lbPaing.Location = new System.Drawing.Point(509, 86);
            this.lbPaing.Name = "lbPaing";
            this.lbPaing.Size = new System.Drawing.Size(26, 16);
            this.lbPaing.TabIndex = 53;
            this.lbPaing.Text = "0/0";
            this.lbPaing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::TanHoaWater.Properties.Resources.Previous;
            this.pictureBox2.Location = new System.Drawing.Point(482, 86);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(19, 16);
            this.pictureBox2.TabIndex = 52;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pre);
            // 
            // next
            // 
            this.next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.next.Image = global::TanHoaWater.Properties.Resources.Next;
            this.next.Location = new System.Drawing.Point(541, 86);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(19, 16);
            this.next.TabIndex = 51;
            this.next.TabStop = false;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // searchLamLai
            // 
            this.searchLamLai.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.searchLamLai.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.searchLamLai.Location = new System.Drawing.Point(111, 79);
            this.searchLamLai.Name = "searchLamLai";
            this.searchLamLai.Size = new System.Drawing.Size(75, 23);
            this.searchLamLai.TabIndex = 7;
            this.searchLamLai.Text = "Làm Lại";
            this.searchLamLai.Click += new System.EventHandler(this.searchLamLai_Click);
            // 
            // searchTimKiem
            // 
            this.searchTimKiem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.searchTimKiem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.searchTimKiem.Location = new System.Drawing.Point(15, 79);
            this.searchTimKiem.Name = "searchTimKiem";
            this.searchTimKiem.Size = new System.Drawing.Size(75, 23);
            this.searchTimKiem.TabIndex = 6;
            this.searchTimKiem.Text = "Tìm Kiếm";
            this.searchTimKiem.Click += new System.EventHandler(this.searchTimKiem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 50;
            this.label4.Text = "Đợt N.Đơn";
            // 
            // searchDiaChi
            // 
            this.searchDiaChi.Location = new System.Drawing.Point(377, 51);
            this.searchDiaChi.Margin = new System.Windows.Forms.Padding(4);
            this.searchDiaChi.Name = "searchDiaChi";
            this.searchDiaChi.Size = new System.Drawing.Size(184, 22);
            this.searchDiaChi.TabIndex = 5;
            this.searchDiaChi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchDiaChi_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Địa Chỉ KH";
            // 
            // dataSearCh
            // 
            this.dataSearCh.AllowUserToAddRows = false;
            this.dataSearCh.AllowUserToDeleteRows = false;
            this.dataSearCh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSearCh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.G_SodotNhanDon,
            this.SOHOSO,
            this.HOTEN,
            this.DIACHI,
            this.NGAY_NHAN,
            this.G_LoaiHS});
            this.dataSearCh.Location = new System.Drawing.Point(11, 108);
            this.dataSearCh.Name = "dataSearCh";
            this.dataSearCh.ReadOnly = true;
            this.dataSearCh.RowHeadersWidth = 10;
            this.dataSearCh.Size = new System.Drawing.Size(550, 399);
            this.dataSearCh.TabIndex = 45;
            // 
            // G_SodotNhanDon
            // 
            this.G_SodotNhanDon.DataPropertyName = "MADOT";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.G_SodotNhanDon.DefaultCellStyle = dataGridViewCellStyle1;
            this.G_SodotNhanDon.HeaderText = "Số Đợt Nhận Đơn";
            this.G_SodotNhanDon.Name = "G_SodotNhanDon";
            this.G_SodotNhanDon.ReadOnly = true;
            this.G_SodotNhanDon.Width = 140;
            // 
            // SOHOSO
            // 
            this.SOHOSO.DataPropertyName = "SOHOSO";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SOHOSO.DefaultCellStyle = dataGridViewCellStyle2;
            this.SOHOSO.HeaderText = "Số Hồ Sơ";
            this.SOHOSO.Name = "SOHOSO";
            this.SOHOSO.ReadOnly = true;
            this.SOHOSO.Width = 120;
            // 
            // HOTEN
            // 
            this.HOTEN.DataPropertyName = "HOTEN";
            this.HOTEN.HeaderText = "Họ Tên";
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.ReadOnly = true;
            this.HOTEN.Width = 200;
            // 
            // DIACHI
            // 
            this.DIACHI.DataPropertyName = "DIACHI";
            this.DIACHI.HeaderText = "Địa Chỉ";
            this.DIACHI.Name = "DIACHI";
            this.DIACHI.ReadOnly = true;
            this.DIACHI.Width = 300;
            // 
            // NGAY_NHAN
            // 
            this.NGAY_NHAN.DataPropertyName = "NGAYNHAN";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NGAY_NHAN.DefaultCellStyle = dataGridViewCellStyle3;
            this.NGAY_NHAN.HeaderText = "Ngày Nhận";
            this.NGAY_NHAN.Name = "NGAY_NHAN";
            this.NGAY_NHAN.ReadOnly = true;
            this.NGAY_NHAN.Width = 135;
            // 
            // G_LoaiHS
            // 
            this.G_LoaiHS.DataPropertyName = "TENLOAI";
            this.G_LoaiHS.HeaderText = "Loại Hồ Sơ";
            this.G_LoaiHS.Name = "G_LoaiHS";
            this.G_LoaiHS.ReadOnly = true;
            this.G_LoaiHS.Width = 300;
            // 
            // searchHoTenKH
            // 
            this.searchHoTenKH.Location = new System.Drawing.Point(302, 17);
            this.searchHoTenKH.Margin = new System.Windows.Forms.Padding(4);
            this.searchHoTenKH.Name = "searchHoTenKH";
            this.searchHoTenKH.Size = new System.Drawing.Size(259, 22);
            this.searchHoTenKH.TabIndex = 3;
            this.searchHoTenKH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchHoTenKH_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ Tên KH";
            // 
            // SearchMaHoSo
            // 
            this.SearchMaHoSo.Location = new System.Drawing.Point(89, 53);
            this.SearchMaHoSo.Margin = new System.Windows.Forms.Padding(4);
            this.SearchMaHoSo.Name = "SearchMaHoSo";
            this.SearchMaHoSo.Size = new System.Drawing.Size(121, 22);
            this.SearchMaHoSo.TabIndex = 2;
            this.SearchMaHoSo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchMaHoSo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Hồ Sơ";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(583, 17);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(440, 513);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Khách Hàng";
            // 
            // SearchDotNhanDon
            // 
            this.SearchDotNhanDon.Location = new System.Drawing.Point(89, 20);
            this.SearchDotNhanDon.Margin = new System.Windows.Forms.Padding(4);
            this.SearchDotNhanDon.Name = "SearchDotNhanDon";
            this.SearchDotNhanDon.Size = new System.Drawing.Size(121, 22);
            this.SearchDotNhanDon.TabIndex = 1;
            this.SearchDotNhanDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDotNhanDon_KeyPress);
            // 
            // tab_TimKiemDonKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "tab_TimKiemDonKH";
            this.Size = new System.Drawing.Size(1047, 543);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.next)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSearCh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchMaHoSo;
        private System.Windows.Forms.TextBox searchHoTenKH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox searchDiaChi;
        private DevComponents.DotNetBar.ButtonX searchLamLai;
        private DevComponents.DotNetBar.ButtonX searchTimKiem;
        private System.Windows.Forms.DataGridView dataSearCh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbPaing;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox next;
        private System.Windows.Forms.TextBox searchSoNha;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_SodotNhanDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOHOSO;
        private System.Windows.Forms.DataGridViewTextBoxColumn HOTEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIACHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAY_NHAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_LoaiHS;
        private System.Windows.Forms.TextBox SearchDotNhanDon;

    }
}
