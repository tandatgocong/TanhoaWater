namespace TanHoaWater.View.Users.KEHOACH.DOTTHICONG
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
            this.lbDotTC = new DevComponents.DotNetBar.LabelX();
            this.cbDonViGiamSat = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btExit = new DevComponents.DotNetBar.ButtonX();
            this.btPrint = new DevComponents.DotNetBar.ButtonX();
            this.ngaytailap = new System.Windows.Forms.DateTimePicker();
            this.ngaykhoicong = new System.Windows.Forms.DateTimePicker();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
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
            this.crystalReportViewer1.Size = new System.Drawing.Size(494, 250);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.lbDotTC);
            this.panel1.Controls.Add(this.cbDonViGiamSat);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.btExit);
            this.panel1.Controls.Add(this.btPrint);
            this.panel1.Controls.Add(this.ngaytailap);
            this.panel1.Controls.Add(this.ngaykhoicong);
            this.panel1.Controls.Add(this.labelX5);
            this.panel1.Controls.Add(this.labelX4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 250);
            this.panel1.TabIndex = 1;
            // 
            // lbDotTC
            // 
            this.lbDotTC.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDotTC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbDotTC.Location = new System.Drawing.Point(12, 17);
            this.lbDotTC.Name = "lbDotTC";
            this.lbDotTC.Size = new System.Drawing.Size(411, 31);
            this.lbDotTC.TabIndex = 12;
            this.lbDotTC.Text = "Đợt Thi Công";
            // 
            // cbDonViGiamSat
            // 
            this.cbDonViGiamSat.DisplayMember = "Text";
            this.cbDonViGiamSat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDonViGiamSat.FormattingEnabled = true;
            this.cbDonViGiamSat.ItemHeight = 20;
            this.cbDonViGiamSat.Location = new System.Drawing.Point(132, 58);
            this.cbDonViGiamSat.Name = "cbDonViGiamSat";
            this.cbDonViGiamSat.Size = new System.Drawing.Size(345, 26);
            this.cbDonViGiamSat.TabIndex = 11;
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(12, 58);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(117, 19);
            this.labelX1.TabIndex = 10;
            this.labelX1.Text = "Đơn vị giám sát :";
            // 
            // btExit
            // 
            this.btExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btExit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExit.Location = new System.Drawing.Point(271, 182);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(117, 31);
            this.btExit.TabIndex = 9;
            this.btExit.Text = "Thoát";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btPrint
            // 
            this.btPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btPrint.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrint.Location = new System.Drawing.Point(143, 182);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(122, 31);
            this.btPrint.TabIndex = 8;
            this.btPrint.Text = "Xem  Báo Cáo";
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // ngaytailap
            // 
            this.ngaytailap.CustomFormat = "dd/MM/yyyy";
            this.ngaytailap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngaytailap.Location = new System.Drawing.Point(132, 130);
            this.ngaytailap.Name = "ngaytailap";
            this.ngaytailap.Size = new System.Drawing.Size(115, 26);
            this.ngaytailap.TabIndex = 7;
            // 
            // ngaykhoicong
            // 
            this.ngaykhoicong.CustomFormat = "dd/MM/yyyy";
            this.ngaykhoicong.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngaykhoicong.Location = new System.Drawing.Point(132, 93);
            this.ngaykhoicong.Name = "ngaykhoicong";
            this.ngaykhoicong.Size = new System.Drawing.Size(115, 26);
            this.ngaykhoicong.TabIndex = 7;
            // 
            // labelX5
            // 
            this.labelX5.Location = new System.Drawing.Point(12, 133);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(149, 23);
            this.labelX5.TabIndex = 6;
            this.labelX5.Text = "Ngày hoàn tất :";
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(12, 93);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(149, 23);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "Ngày khởi công :";
            // 
            // frmDialogPrintting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 250);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDialogPrintting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quyết Định Thi Công";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker ngaytailap;
        private System.Windows.Forms.DateTimePicker ngaykhoicong;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX btExit;
        private DevComponents.DotNetBar.ButtonX btPrint;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lbDotTC;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbDonViGiamSat;
    }
}