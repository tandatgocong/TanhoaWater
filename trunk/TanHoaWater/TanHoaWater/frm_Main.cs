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
using log4net;
using TanHoaWater.View.Users.To_ThietKe;
using TanHoaWater.View.Users.TinhDuToan;

namespace TanHoaWater
{
    public partial class frm_Main : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_Main).Name);
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
            log4net.Config.XmlConfigurator.Configure();
            //  th.Abort();
        }

        public static frm_Login dn = new frm_Login();
        public void dangnhap() {
            dn.ShowDialog();
            if (DAL.C_USERS._roles != null && "AD".Equals(DAL.C_USERS._roles.Trim()))
            {
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new Admin_Main());
            }
            else if (DAL.C_USERS._roles != null && "US".Equals(DAL.C_USERS._roles.Trim()))
            {
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new Uses_Main());

            }          
            formLoad();
          
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
            if (DAL.C_USERS._userName == null) {
                this.subdangnhap.Visible = true;
            }
            else if (DAL.C_USERS._userName != null) {
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

        private void menuNhanDon_Click(object sender, EventArgs e)
        {
            this.PanelContent.Controls.Clear();
            this.PanelContent.Controls.Add(new HSKHACHHANG());
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.PanelContent.Controls.Clear();
            this.PanelContent.Controls.Add(new uct_GiaoHS());
        }

        private void tínhDựToánHSKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.PanelContent.Controls.Clear();
            this.PanelContent.Controls.Add(new uct_TinhDuToan());
        }

        
    }
}