namespace TanHoaWater.View.Users.TinhDuToan
{
    partial class frm_ChonLaiDG
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChonLaiDG));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btCapNhatDGVT = new DevComponents.DotNetBar.ButtonX();
            this.GridDonGiaVT = new System.Windows.Forms.DataGridView();
            this.dg_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAHIEUDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_vatlieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_nhanCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgXiMang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_Chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridDonGiaVT)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Vật Tư";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Vật Tư";
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Location = new System.Drawing.Point(103, 11);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(389, 26);
            this.textBoxX1.TabIndex = 1;
            // 
            // textBoxX2
            // 
            // 
            // 
            // 
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Location = new System.Drawing.Point(103, 47);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.Size = new System.Drawing.Size(389, 26);
            this.textBoxX2.TabIndex = 1;
            // 
            // btCapNhatDGVT
            // 
            this.btCapNhatDGVT.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btCapNhatDGVT.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btCapNhatDGVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCapNhatDGVT.ForeColor = System.Drawing.Color.DarkRed;
            this.btCapNhatDGVT.Location = new System.Drawing.Point(357, 450);
            this.btCapNhatDGVT.Name = "btCapNhatDGVT";
            this.btCapNhatDGVT.Size = new System.Drawing.Size(135, 23);
            this.btCapNhatDGVT.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btCapNhatDGVT.TabIndex = 1;
            this.btCapNhatDGVT.Text = "Cập Nhật Đơn Giá VT";
            // 
            // GridDonGiaVT
            // 
            this.GridDonGiaVT.AllowUserToDeleteRows = false;
            this.GridDonGiaVT.AllowUserToOrderColumns = true;
            this.GridDonGiaVT.AllowUserToResizeColumns = false;
            this.GridDonGiaVT.AllowUserToResizeRows = false;
            this.GridDonGiaVT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridDonGiaVT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridDonGiaVT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDonGiaVT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dg_ID,
            this.MAHIEUDG,
            this.dg_vatlieu,
            this.dg_nhanCong,
            this.dgXiMang,
            this.dg_ngay,
            this.dg_Chon});
            this.GridDonGiaVT.Location = new System.Drawing.Point(22, 102);
            this.GridDonGiaVT.Name = "GridDonGiaVT";
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridDonGiaVT.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.GridDonGiaVT.RowHeadersWidth = 30;
            this.GridDonGiaVT.Size = new System.Drawing.Size(470, 342);
            this.GridDonGiaVT.TabIndex = 0;
            // 
            // dg_ID
            // 
            this.dg_ID.DataPropertyName = "STT";
            this.dg_ID.HeaderText = "ID";
            this.dg_ID.Name = "dg_ID";
            this.dg_ID.Visible = false;
            // 
            // MAHIEUDG
            // 
            this.MAHIEUDG.DataPropertyName = "MAHIEUDG";
            this.MAHIEUDG.HeaderText = "MAHIEUDG";
            this.MAHIEUDG.Name = "MAHIEUDG";
            this.MAHIEUDG.ReadOnly = true;
            this.MAHIEUDG.Visible = false;
            // 
            // dg_vatlieu
            // 
            this.dg_vatlieu.DataPropertyName = "DGVATLIEU";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dg_vatlieu.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_vatlieu.HeaderText = "VL";
            this.dg_vatlieu.Name = "dg_vatlieu";
            this.dg_vatlieu.Width = 80;
            // 
            // dg_nhanCong
            // 
            this.dg_nhanCong.DataPropertyName = "DGNHANCONG";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dg_nhanCong.DefaultCellStyle = dataGridViewCellStyle3;
            this.dg_nhanCong.HeaderText = "NC";
            this.dg_nhanCong.Name = "dg_nhanCong";
            this.dg_nhanCong.Width = 80;
            // 
            // dgXiMang
            // 
            this.dgXiMang.DataPropertyName = "DGMAYTHICONG";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgXiMang.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgXiMang.HeaderText = "MTC";
            this.dgXiMang.Name = "dgXiMang";
            this.dgXiMang.Width = 90;
            // 
            // dg_ngay
            // 
            this.dg_ngay.DataPropertyName = "NGAYHIEULUC";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dg_ngay.DefaultCellStyle = dataGridViewCellStyle5;
            this.dg_ngay.HeaderText = "Ngày Áp Giá";
            this.dg_ngay.Name = "dg_ngay";
            this.dg_ngay.ReadOnly = true;
            this.dg_ngay.Width = 120;
            // 
            // dg_Chon
            // 
            this.dg_Chon.DataPropertyName = "CHON";
            this.dg_Chon.HeaderText = "Chọn";
            this.dg_Chon.Name = "dg_Chon";
            this.dg_Chon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_Chon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dg_Chon.Width = 55;
            // 
            // frm_ChonLaiDG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(511, 486);
            this.Controls.Add(this.btCapNhatDGVT);
            this.Controls.Add(this.GridDonGiaVT);
            this.Controls.Add(this.textBoxX2);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChonLaiDG";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn Đơn Giá";
            ((System.ComponentModel.ISupportInitialize)(this.GridDonGiaVT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX2;
        private DevComponents.DotNetBar.ButtonX btCapNhatDGVT;
        private System.Windows.Forms.DataGridView GridDonGiaVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAHIEUDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg_vatlieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg_nhanCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgXiMang;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg_ngay;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dg_Chon;
    }
}