namespace TanHoaWater.View.Administrators
{
    partial class uct_Users
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.reflectionLabel1 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cbRoles = new System.Windows.Forms.ComboBox();
            this.btAddNew = new DevComponents.DotNetBar.ButtonX();
            this.btSearch = new DevComponents.DotNetBar.ButtonX();
            this.userGridView = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.userGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // reflectionLabel1
            // 
            this.reflectionLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reflectionLabel1.Location = new System.Drawing.Point(256, 4);
            this.reflectionLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.reflectionLabel1.Name = "reflectionLabel1";
            this.reflectionLabel1.Size = new System.Drawing.Size(245, 57);
            this.reflectionLabel1.TabIndex = 0;
            this.reflectionLabel1.Text = "<b><font size=\"+6\"><font color=\"#05266f\">Quản Trị Người Dùng</font></font></b>";
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(22, 76);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(113, 28);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Tên Đăng Nhập:";
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(337, 80);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(79, 28);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Mật Khẩu:";
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(51, 112);
            this.labelX3.Margin = new System.Windows.Forms.Padding(4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(84, 28);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "Họ và Tên:";
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(355, 118);
            this.labelX4.Margin = new System.Windows.Forms.Padding(4);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(51, 28);
            this.labelX4.TabIndex = 4;
            this.labelX4.Text = "Quyền:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(120, 76);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(196, 22);
            this.txtUserName.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(120, 108);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(196, 22);
            this.txtName.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(401, 77);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(183, 22);
            this.txtPassword.TabIndex = 7;
            // 
            // cbRoles
            // 
            this.cbRoles.FormattingEnabled = true;
            this.cbRoles.Items.AddRange(new object[] {
            "aaaa"});
            this.cbRoles.Location = new System.Drawing.Point(401, 115);
            this.cbRoles.Margin = new System.Windows.Forms.Padding(4);
            this.cbRoles.Name = "cbRoles";
            this.cbRoles.Size = new System.Drawing.Size(183, 24);
            this.cbRoles.TabIndex = 8;
            // 
            // btAddNew
            // 
            this.btAddNew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btAddNew.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btAddNew.Image = global::TanHoaWater.Properties.Resources.user_add;
            this.btAddNew.ImageFixedSize = new System.Drawing.Size(25, 25);
            this.btAddNew.Location = new System.Drawing.Point(616, 74);
            this.btAddNew.Margin = new System.Windows.Forms.Padding(4);
            this.btAddNew.Name = "btAddNew";
            this.btAddNew.Size = new System.Drawing.Size(111, 31);
            this.btAddNew.TabIndex = 9;
            this.btAddNew.Text = "Thêm Mới";
            this.btAddNew.Click += new System.EventHandler(this.btAddNew_Click);
            // 
            // btSearch
            // 
            this.btSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btSearch.Image = global::TanHoaWater.Properties.Resources.user_find;
            this.btSearch.ImageFixedSize = new System.Drawing.Size(25, 25);
            this.btSearch.Location = new System.Drawing.Point(616, 112);
            this.btSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(111, 31);
            this.btSearch.TabIndex = 10;
            this.btSearch.Text = "Tìm Kiếm";
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // userGridView
            // 
            this.userGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.userGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.userGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userGridView.Location = new System.Drawing.Point(30, 176);
            this.userGridView.Name = "userGridView";
            this.userGridView.Size = new System.Drawing.Size(697, 285);
            this.userGridView.TabIndex = 11;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Admin_Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userGridView);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.btAddNew);
            this.Controls.Add(this.cbRoles);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.reflectionLabel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Admin_Users";
            this.Size = new System.Drawing.Size(743, 480);
            ((System.ComponentModel.ISupportInitialize)(this.userGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cbRoles;
        private DevComponents.DotNetBar.ButtonX btAddNew;
        private DevComponents.DotNetBar.ButtonX btSearch;
        private System.Windows.Forms.DataGridView userGridView;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
