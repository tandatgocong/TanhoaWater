namespace TanHoaWater.View.Users.HSKHACHHANG
{
    partial class tab_BaoCao
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.BC_DotNhanDon = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.BC_QUAN = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.cbLoaiBC = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.donKhanTheoQuan = new DevComponents.Editors.ComboItem();
            this.donkhan = new DevComponents.Editors.ComboItem();
            this.dotNdQuan = new DevComponents.Editors.ComboItem();
            this.dotNhanDon = new DevComponents.Editors.ComboItem();
            this.Quận = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(6, 55);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(740, 377);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn Loại BC";
            // 
            // BC_DotNhanDon
            // 
            this.BC_DotNhanDon.DisplayMember = "Text";
            this.BC_DotNhanDon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.BC_DotNhanDon.DropDownWidth = 400;
            this.BC_DotNhanDon.Enabled = false;
            this.BC_DotNhanDon.FormattingEnabled = true;
            this.BC_DotNhanDon.ItemHeight = 14;
            this.BC_DotNhanDon.Location = new System.Drawing.Point(306, 3);
            this.BC_DotNhanDon.Name = "BC_DotNhanDon";
            this.BC_DotNhanDon.Size = new System.Drawing.Size(112, 20);
            this.BC_DotNhanDon.TabIndex = 4;
            // 
            // BC_QUAN
            // 
            this.BC_QUAN.DisplayMember = "Text";
            this.BC_QUAN.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.BC_QUAN.Enabled = false;
            this.BC_QUAN.FormattingEnabled = true;
            this.BC_QUAN.ItemHeight = 14;
            this.BC_QUAN.Location = new System.Drawing.Point(49, 29);
            this.BC_QUAN.Name = "BC_QUAN";
            this.BC_QUAN.Size = new System.Drawing.Size(112, 20);
            this.BC_QUAN.TabIndex = 6;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(181, 29);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(103, 20);
            this.buttonX1.TabIndex = 7;
            this.buttonX1.Text = "Xem";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // cbLoaiBC
            // 
            this.cbLoaiBC.DisplayMember = "Text";
            this.cbLoaiBC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLoaiBC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiBC.DropDownWidth = 250;
            this.cbLoaiBC.FormattingEnabled = true;
            this.cbLoaiBC.ItemHeight = 14;
            this.cbLoaiBC.Location = new System.Drawing.Point(93, 3);
            this.cbLoaiBC.Name = "cbLoaiBC";
            this.cbLoaiBC.Size = new System.Drawing.Size(112, 20);
            this.cbLoaiBC.TabIndex = 2;
            this.cbLoaiBC.SelectedIndexChanged += new System.EventHandler(this.cbLoaiBC_SelectedIndexChanged);
            // 
            // donKhanTheoQuan
            // 
            this.donKhanTheoQuan.Text = "Đơn Khẩn Theo Đợt & Quận";
            // 
            // donkhan
            // 
            this.donkhan.Text = "Đơn Khẩn Theo Đợt";
            // 
            // dotNdQuan
            // 
            this.dotNdQuan.Text = "Theo Đợt Nhận Đơn  và Quận";
            // 
            // dotNhanDon
            // 
            this.dotNhanDon.Text = "Theo Đợt Nhận Đơn";
            // 
            // Quận
            // 
            this.Quận.AutoSize = true;
            this.Quận.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quận.Location = new System.Drawing.Point(6, 32);
            this.Quận.Name = "Quận";
            this.Quận.Size = new System.Drawing.Size(37, 13);
            this.Quận.TabIndex = 5;
            this.Quận.Text = "Quận";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(216, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Đợt Nhận Đơn";
            // 
            // tab_BaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.BC_QUAN);
            this.Controls.Add(this.Quận);
            this.Controls.Add(this.BC_DotNhanDon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbLoaiBC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "tab_BaoCao";
            this.Size = new System.Drawing.Size(878, 533);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx BC_DotNhanDon;
        private DevComponents.DotNetBar.Controls.ComboBoxEx BC_QUAN;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbLoaiBC;
        private DevComponents.Editors.ComboItem donKhanTheoQuan;
        private DevComponents.Editors.ComboItem donkhan;
        private DevComponents.Editors.ComboItem dotNdQuan;
        private DevComponents.Editors.ComboItem dotNhanDon;
        private System.Windows.Forms.Label Quận;
        private System.Windows.Forms.Label label2;


    }
}
