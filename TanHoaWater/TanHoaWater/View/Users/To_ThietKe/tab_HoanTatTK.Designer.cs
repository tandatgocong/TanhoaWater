namespace TanHoaWater.View.Users.To_ThietKe
{
    partial class tab_HoanTatTK
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cbDotNhanDon = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.bt_XemBC = new DevComponents.DotNetBar.ButtonX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.bt_XemBC);
            this.panel1.Controls.Add(this.cbDotNhanDon);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 577);
            this.panel1.TabIndex = 0;
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(20, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(152, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Nhập Đợt Nhận Đơn";
            // 
            // cbDotNhanDon
            // 
            this.cbDotNhanDon.DisplayMember = "Text";
            this.cbDotNhanDon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDotNhanDon.FormattingEnabled = true;
            this.cbDotNhanDon.ItemHeight = 20;
            this.cbDotNhanDon.Location = new System.Drawing.Point(159, 12);
            this.cbDotNhanDon.Name = "cbDotNhanDon";
            this.cbDotNhanDon.Size = new System.Drawing.Size(161, 26);
            this.cbDotNhanDon.TabIndex = 1;
            // 
            // bt_XemBC
            // 
            this.bt_XemBC.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_XemBC.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_XemBC.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_XemBC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(22)))), ((int)(((byte)(111)))));
            this.bt_XemBC.Location = new System.Drawing.Point(333, 12);
            this.bt_XemBC.Margin = new System.Windows.Forms.Padding(4);
            this.bt_XemBC.Name = "bt_XemBC";
            this.bt_XemBC.Size = new System.Drawing.Size(109, 25);
            this.bt_XemBC.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.bt_XemBC.TabIndex = 2;
            this.bt_XemBC.Text = "Xem Báo Cáo";
            // 
            // tab_HoanTatTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "tab_HoanTatTK";
            this.Size = new System.Drawing.Size(1008, 577);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbDotNhanDon;
        private DevComponents.DotNetBar.ButtonX bt_XemBC;
    }
}
