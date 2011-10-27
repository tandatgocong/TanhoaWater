namespace TanHoaWater.View.Users.KEHOACH.XINPHEPDD
{
    partial class frmDialogPrintting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDialogPrintting));
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btExit = new DevComponents.DotNetBar.ButtonX();
            this.btPrint = new DevComponents.DotNetBar.ButtonX();
            this.denngay = new System.Windows.Forms.DateTimePicker();
            this.ngaytailap = new System.Windows.Forms.DateTimePicker();
            this.ngaykhoicong = new System.Windows.Forms.DateTimePicker();
            this.tungay = new System.Windows.Forms.DateTimePicker();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cbMaDot = new System.Windows.Forms.ComboBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(435, 250);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btExit);
            this.panel1.Controls.Add(this.btPrint);
            this.panel1.Controls.Add(this.denngay);
            this.panel1.Controls.Add(this.ngaytailap);
            this.panel1.Controls.Add(this.ngaykhoicong);
            this.panel1.Controls.Add(this.tungay);
            this.panel1.Controls.Add(this.labelX3);
            this.panel1.Controls.Add(this.labelX5);
            this.panel1.Controls.Add(this.labelX4);
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Controls.Add(this.cbMaDot);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 250);
            this.panel1.TabIndex = 1;
            // 
            // btExit
            // 
            this.btExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btExit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExit.Location = new System.Drawing.Point(191, 193);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(88, 31);
            this.btExit.TabIndex = 9;
            this.btExit.Text = "Thoát";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btPrint
            // 
            this.btPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btPrint.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrint.Location = new System.Drawing.Point(89, 193);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(96, 31);
            this.btPrint.TabIndex = 8;
            this.btPrint.Text = "In Báo Cáo";
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // denngay
            // 
            this.denngay.CustomFormat = "dd/MM/yyyy";
            this.denngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.denngay.Location = new System.Drawing.Point(309, 63);
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(111, 26);
            this.denngay.TabIndex = 7;
            // 
            // ngaytailap
            // 
            this.ngaytailap.CustomFormat = "dd/MM/yyyy";
            this.ngaytailap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngaytailap.Location = new System.Drawing.Point(151, 147);
            this.ngaytailap.Name = "ngaytailap";
            this.ngaytailap.Size = new System.Drawing.Size(115, 26);
            this.ngaytailap.TabIndex = 7;
            // 
            // ngaykhoicong
            // 
            this.ngaykhoicong.CustomFormat = "dd/MM/yyyy";
            this.ngaykhoicong.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngaykhoicong.Location = new System.Drawing.Point(151, 107);
            this.ngaykhoicong.Name = "ngaykhoicong";
            this.ngaykhoicong.Size = new System.Drawing.Size(115, 26);
            this.ngaykhoicong.TabIndex = 7;
            // 
            // tungay
            // 
            this.tungay.CustomFormat = "dd/MM/yyyy";
            this.tungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tungay.Location = new System.Drawing.Point(120, 63);
            this.tungay.Name = "tungay";
            this.tungay.Size = new System.Drawing.Size(115, 26);
            this.tungay.TabIndex = 7;
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(241, 63);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(84, 23);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "đến ngày :";
            // 
            // labelX5
            // 
            this.labelX5.Location = new System.Drawing.Point(12, 147);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(149, 23);
            this.labelX5.TabIndex = 6;
            this.labelX5.Text = "Ngày hoàn tất tái lập:";
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(12, 107);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(149, 23);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "Ngày khởi công đào:";
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(12, 63);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(116, 23);
            this.labelX2.TabIndex = 6;
            this.labelX2.Text = "Tuần lễ từ ngày :";
            // 
            // cbMaDot
            // 
            this.cbMaDot.DropDownHeight = 150;
            this.cbMaDot.DropDownWidth = 200;
            this.cbMaDot.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMaDot.FormattingEnabled = true;
            this.cbMaDot.IntegralHeight = false;
            this.cbMaDot.Location = new System.Drawing.Point(79, 19);
            this.cbMaDot.Name = "cbMaDot";
            this.cbMaDot.Size = new System.Drawing.Size(178, 27);
            this.cbMaDot.TabIndex = 5;
            // 
            // labelX1
            // 
            this.labelX1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(12, 19);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Mã Đợt";
            // 
            // frmDialogPrintting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 250);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDialogPrintting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In Danh Sách Xin Phép Đào Đường";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.ComboBox cbMaDot;
        private System.Windows.Forms.DateTimePicker tungay;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.DateTimePicker denngay;
        private System.Windows.Forms.DateTimePicker ngaytailap;
        private System.Windows.Forms.DateTimePicker ngaykhoicong;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX btExit;
        private DevComponents.DotNetBar.ButtonX btPrint;
    }
}