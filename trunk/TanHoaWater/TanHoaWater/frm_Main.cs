using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using TanHoaWater.View.QLDHN;
using TanHoaWater.View.Users;
using TanHoaWater.View.Administrators;
using TanHoaWater.View.Users.HSKHACHHANG;

namespace TanHoaWater
{
    public partial class frm_Main : Form
    {
        public void start()
        {
            Application.Run(new SplashScreen());
        }
        public frm_Main()
        {
            //  Thread th = new Thread(new ThreadStart(this.start));
            //   th.Start();
            //  Thread.Sleep(5000);
            InitializeComponent();            
            //  th.Abort();
        }

        public static frm_Login dn = new frm_Login();
        public void dangnhap() {
            dn.ShowDialog();
            if (DAL.Users._roles != null && "AD".Equals(DAL.Users._roles.Trim()))
            {
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new Admin_Main());
            }
            else if (DAL.Users._roles != null && "US".Equals(DAL.Users._roles.Trim()))
            {
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new Uses_Main());

            }          
            formLoad();
            this.skinEngine1.SkinFile = "office2007.ssk";
        }
        private void frm_Main_Load(object sender, EventArgs e)
        {             
            this.Show();
            dangnhap();
        }

        private void subThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Thoát Chương Trình ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Dispose();
            }
        }
        public void formLoad() {            
            if (DAL.Users._userName == null) {
                this.subdangnhap.Visible = true;
            }
            else if (DAL.Users._userName != null) {
                this.subdangnhap.Visible = false;
                this.subDangXuat.Visible = true;
                this.subDoiMatKhau.Visible = true;
            }


        }

        private void subdangnhap_Click(object sender, EventArgs e)
        {
            dangnhap();
        }

        private void btDotNhanDon_Click(object sender, EventArgs e)
        {
            this.PanelContent.Controls.Clear();
            this.PanelContent.Controls.Add(new uct_DOTNHANDON());
        }
    }
}