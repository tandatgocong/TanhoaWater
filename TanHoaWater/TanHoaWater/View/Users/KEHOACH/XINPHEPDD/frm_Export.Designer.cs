namespace TanHoaWater.View.Users.KEHOACH.XINPHEPDD
{
    partial class frm_Export
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Export));
            this.NGAYCONGVAN = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.SOCONGVAN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDotdd = new DevComponents.DotNetBar.LabelX();
            this.btExport = new DevComponents.DotNetBar.ButtonX();
            this.result = new DevComponents.DotNetBar.LabelX();
            this.label1 = new System.Windows.Forms.Label();
            this.rdSoHoSo = new System.Windows.Forms.RadioButton();
            this.radioDuong = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // NGAYCONGVAN
            // 
            this.NGAYCONGVAN.CustomFormat = "dd/MM/yyyy";
            this.NGAYCONGVAN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.NGAYCONGVAN.Location = new System.Drawing.Point(213, 79);
            this.NGAYCONGVAN.Name = "NGAYCONGVAN";
            this.NGAYCONGVAN.Size = new System.Drawing.Size(120, 26);
            this.NGAYCONGVAN.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "NGÀY CÔNG VĂN";
            // 
            // SOCONGVAN
            // 
            this.SOCONGVAN.Location = new System.Drawing.Point(213, 47);
            this.SOCONGVAN.Name = "SOCONGVAN";
            this.SOCONGVAN.Size = new System.Drawing.Size(257, 26);
            this.SOCONGVAN.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "SỐ CÔNG VĂN ";
            // 
            // lbDotdd
            // 
            this.lbDotdd.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDotdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbDotdd.Location = new System.Drawing.Point(4, 13);
            this.lbDotdd.Margin = new System.Windows.Forms.Padding(4);
            this.lbDotdd.Name = "lbDotdd";
            this.lbDotdd.Size = new System.Drawing.Size(519, 34);
            this.lbDotdd.TabIndex = 9;
            this.lbDotdd.Text = "labelX1";
            this.lbDotdd.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btExport
            // 
            this.btExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btExport.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btExport.Location = new System.Drawing.Point(213, 149);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(161, 23);
            this.btExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btExport.TabIndex = 721;
            this.btExport.Text = "Export Danh Sách";
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // result
            // 
            this.result.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.result.Location = new System.Drawing.Point(13, 179);
            this.result.Margin = new System.Windows.Forms.Padding(4);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(510, 34);
            this.result.TabIndex = 722;
            this.result.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "FILE BẢNG VẼ";
            // 
            // rdSoHoSo
            // 
            this.rdSoHoSo.AutoSize = true;
            this.rdSoHoSo.Checked = true;
            this.rdSoHoSo.Location = new System.Drawing.Point(213, 111);
            this.rdSoHoSo.Name = "rdSoHoSo";
            this.rdSoHoSo.Size = new System.Drawing.Size(88, 23);
            this.rdSoHoSo.TabIndex = 723;
            this.rdSoHoSo.TabStop = true;
            this.rdSoHoSo.Text = "Số Hồ Sơ";
            this.rdSoHoSo.UseVisualStyleBackColor = true;
            // 
            // radioDuong
            // 
            this.radioDuong.AutoSize = true;
            this.radioDuong.Location = new System.Drawing.Point(307, 109);
            this.radioDuong.Name = "radioDuong";
            this.radioDuong.Size = new System.Drawing.Size(96, 23);
            this.radioDuong.TabIndex = 724;
            this.radioDuong.Text = "Tên Đường";
            this.radioDuong.UseVisualStyleBackColor = true;
            // 
            // frm_Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(536, 223);
            this.Controls.Add(this.radioDuong);
            this.Controls.Add(this.rdSoHoSo);
            this.Controls.Add(this.result);
            this.Controls.Add(this.btExport);
            this.Controls.Add(this.lbDotdd);
            this.Controls.Add(this.NGAYCONGVAN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SOCONGVAN);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_Export";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export File ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker NGAYCONGVAN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SOCONGVAN;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.LabelX lbDotdd;
        private DevComponents.DotNetBar.ButtonX btExport;
        private DevComponents.DotNetBar.LabelX result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdSoHoSo;
        private System.Windows.Forms.RadioButton radioDuong;
    }
}