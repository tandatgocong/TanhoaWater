namespace TanHoaWater.View.Users.KEHOACH.XINPHEPDD
{
    partial class optThemKetCAU
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtDiaChi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMaSHS = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.GridPhuiDao = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.pd_MaKetCau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phuidao_tenketcau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridPhuiDao)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDiaChi
            // 
            // 
            // 
            // 
            this.txtDiaChi.Border.Class = "TextBoxBorder";
            this.txtDiaChi.Location = new System.Drawing.Point(134, 46);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(250, 26);
            this.txtDiaChi.TabIndex = 11;
            this.txtDiaChi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiaChi_KeyPress);
            // 
            // txtMaSHS
            // 
            // 
            // 
            // 
            this.txtMaSHS.Border.Class = "TextBoxBorder";
            this.txtMaSHS.Location = new System.Drawing.Point(134, 14);
            this.txtMaSHS.Name = "txtMaSHS";
            this.txtMaSHS.Size = new System.Drawing.Size(250, 26);
            this.txtMaSHS.TabIndex = 10;
            this.txtMaSHS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaSHS_KeyPress);
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(43, 47);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(85, 23);
            this.labelX4.TabIndex = 8;
            this.labelX4.Text = "Tên Kết Cấu";
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(43, 12);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(85, 23);
            this.labelX2.TabIndex = 9;
            this.labelX2.Text = "Mã Kết Cấu";
            // 
            // GridPhuiDao
            // 
            this.GridPhuiDao.AllowUserToAddRows = false;
            this.GridPhuiDao.AllowUserToOrderColumns = true;
            this.GridPhuiDao.AllowUserToResizeColumns = false;
            this.GridPhuiDao.AllowUserToResizeRows = false;
            this.GridPhuiDao.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(206)))), ((int)(((byte)(236)))));
            this.GridPhuiDao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 12F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridPhuiDao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.GridPhuiDao.ColumnHeadersHeight = 25;
            this.GridPhuiDao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pd_MaKetCau,
            this.phuidao_tenketcau});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 12F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridPhuiDao.DefaultCellStyle = dataGridViewCellStyle8;
            this.GridPhuiDao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.GridPhuiDao.Location = new System.Drawing.Point(12, 90);
            this.GridPhuiDao.Name = "GridPhuiDao";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Times New Roman", 12F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridPhuiDao.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.GridPhuiDao.RowHeadersWidth = 30;
            this.GridPhuiDao.Size = new System.Drawing.Size(425, 384);
            this.GridPhuiDao.TabIndex = 714;
            // 
            // pd_MaKetCau
            // 
            this.pd_MaKetCau.DataPropertyName = "MADANHMUC";
            this.pd_MaKetCau.HeaderText = "Mã Kết Cấu";
            this.pd_MaKetCau.Name = "pd_MaKetCau";
            this.pd_MaKetCau.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pd_MaKetCau.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pd_MaKetCau.Width = 120;
            // 
            // phuidao_tenketcau
            // 
            this.phuidao_tenketcau.DataPropertyName = "TENKETCAU";
            this.phuidao_tenketcau.HeaderText = "Kết Cấu Mặt Đường";
            this.phuidao_tenketcau.Name = "phuidao_tenketcau";
            this.phuidao_tenketcau.ReadOnly = true;
            this.phuidao_tenketcau.Width = 250;
            // 
            // optThemKetCAU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 486);
            this.Controls.Add(this.GridPhuiDao);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtMaSHS);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX2);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "optThemKetCAU";
            this.Text = "optThemKetCAU";
            ((System.ComponentModel.ISupportInitialize)(this.GridPhuiDao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtDiaChi;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaSHS;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.DataGridViewX GridPhuiDao;
        private System.Windows.Forms.DataGridViewTextBoxColumn pd_MaKetCau;
        private System.Windows.Forms.DataGridViewTextBoxColumn phuidao_tenketcau;
    }
}