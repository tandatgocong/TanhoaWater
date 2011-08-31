namespace TanHoaWater.View.Users
{
    partial class frm_Login
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
            this.components = new System.ComponentModel.Container();
            this.bt_Login = new DevComponents.DotNetBar.ButtonX();
            this.bt_huy = new DevComponents.DotNetBar.ButtonX();
            this.ckSavePass = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtuserName = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbFail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Login
            // 
            this.bt_Login.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_Login.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_Login.Location = new System.Drawing.Point(126, 134);
            this.bt_Login.Name = "bt_Login";
            this.bt_Login.Size = new System.Drawing.Size(75, 23);
            this.bt_Login.TabIndex = 0;
            this.bt_Login.Text = "Đăng Nhập";
            this.bt_Login.Click += new System.EventHandler(this.bt_Login_Click);
            // 
            // bt_huy
            // 
            this.bt_huy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_huy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_huy.Location = new System.Drawing.Point(231, 134);
            this.bt_huy.Name = "bt_huy";
            this.bt_huy.Size = new System.Drawing.Size(75, 23);
            this.bt_huy.TabIndex = 1;
            this.bt_huy.Text = "Hủy";
            this.bt_huy.Click += new System.EventHandler(this.bt_huy_Click);
            // 
            // ckSavePass
            // 
            this.ckSavePass.Location = new System.Drawing.Point(126, 102);
            this.ckSavePass.Name = "ckSavePass";
            this.ckSavePass.Size = new System.Drawing.Size(200, 23);
            this.ckSavePass.TabIndex = 2;
            this.ckSavePass.Text = "Nhớ mật khẩu của tôi trên máy này";
            // 
            // txtuserName
            // 
            this.txtuserName.Location = new System.Drawing.Point(126, 39);
            this.txtuserName.Name = "txtuserName";
            this.txtuserName.Size = new System.Drawing.Size(180, 20);
            this.txtuserName.TabIndex = 3;
            this.txtuserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtuserName_KeyPress);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(126, 76);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(180, 20);
            this.txtPass.TabIndex = 4;
            this.txtPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPass_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tên Đăng Nhập:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mật Khẩu:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lbFail
            // 
            this.lbFail.AutoSize = true;
            this.lbFail.ForeColor = System.Drawing.Color.Red;
            this.lbFail.Location = new System.Drawing.Point(6, 173);
            this.lbFail.Name = "lbFail";
            this.lbFail.Size = new System.Drawing.Size(182, 13);
            this.lbFail.TabIndex = 7;
            this.lbFail.Text = "(*) Sai tên đăng nhập hoặc mật khẩu";
            this.lbFail.Visible = false;
            // 
            // frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(206)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(374, 195);
            this.Controls.Add(this.lbFail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtuserName);
            this.Controls.Add(this.ckSavePass);
            this.Controls.Add(this.bt_huy);
            this.Controls.Add(this.bt_Login);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Login";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.frm_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX bt_Login;
        private DevComponents.DotNetBar.ButtonX bt_huy;
        private DevComponents.DotNetBar.Controls.CheckBoxX ckSavePass;
        private System.Windows.Forms.TextBox txtuserName;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lbFail;


    }
}