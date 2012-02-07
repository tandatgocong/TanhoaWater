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
using TanHoaWater.Roles;
using TanHoaWater.View.Users.KEHOACH;
using TanHoaWater.View.Tool;
using TanHoaWater.View.Users.KEHOACH.XINPHEPDD;
using TanHoaWater.View.Users.KEHOACH.DOTTHICONG;
using TanHoaWater.View.Users.KEHOACH.HOANCONG;
using TanHoaWater.View.Users.DONGHONUOC;
using TanHoaWater.View.Users.TinhDuToan.BGDieuChinh;

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
            //Thread th = new Thread(new ThreadStart(this.start));

            //th.Start();
            //Thread.Sleep(5000);
            InitializeComponent();
            //th.Abort();
            this.menuHeThong.Select();

            this.lbNgayHeThong.Text = Utilities.DateToString.fullCurrentNgay() + "  ";

            PanelMain.Location = new Point(this.ClientSize.Width / 2 - PanelMain.Size.Width / 2, this.ClientSize.Height / 2 - PanelMain.Size.Height / 2);
            PanelMain.Anchor = AnchorStyles.None;

        }

        public static frm_Login dn = new frm_Login();
        public void dangnhap()
        {
            dn.ShowDialog();
            if (DAL.C_USERS._roles != null)
            {
                role(DAL.C_USERS._roles);
            }

            formLoad();
            this.Text = "Tan Hoa Water Co., ltd - Nhân Viên : " + DAL.C_USERS._fullName;
        }
        private void frm_Main_Load(object sender, EventArgs e)
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();
                if (DAL.TestConection.testConnection() == false)
                {
                    MessageBox.Show(this, "Lỗi Kết Nối, Kiểm Tra Kết Nối Tới Server.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
               
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Chuong Trinh: " + ex.Message);
                MessageBox.Show(this, "Lỗi Kết Nối, Kiểm Tra Kết Nối Tới Server.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            this.Show();
            dangnhap();

        }

        private void subThoat_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }
        public void formLoad()
        {
            if (DAL.C_USERS._userName == null)
            {
                this.subdangnhap.Visible = true;
            }
            else if (DAL.C_USERS._userName != null)
            {
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
            try
            {
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new uct_DOTNHANDON());
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }

        private void menuNhanDon_Click(object sender, EventArgs e)
        {

            try
            {
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new HSKHACHHANG(1));
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            try
            {
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new uct_GiaoHS(1));
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void tínhDựToánHSKToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new tab_DanhMucVT(1));
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void ribbonTabItem1_Click(object sender, EventArgs e)
        {
            this.PanelContent.Controls.Clear();
            this.PanelContent.Controls.Add(PanelMain);
            //     this.iconMenuPanel.Controls.Clear();
            ////     this.iconMenuPanel.Controls.Add(new Icon_KHVT());
            //     this.iconMenuPanel.Controls.Add(new TTK());

        }
        public void role(string role)
        {
            if ("AD".Equals(DAL.C_USERS._roles.Trim()))
            {
                menuQuanTri.Visible = true;
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new Admin_Main());
            }
            else if ("US".Equals(DAL.C_USERS._roles.Trim()))
            {
                menuQuanTri.Visible = false;
                if ("TTK".Equals(DAL.C_USERS._maphong.Trim()))
                {
                    this.menuToThietKe.Visible = true;
                    this.iconMenuPanel.Controls.Clear();
                    this.iconMenuPanel.Controls.Add(groupTTK);
                    groupTTK.Visible = true;

                }
                else if ("VTTH".Equals(DAL.C_USERS._maphong.Trim()))
                {
                    this.menuKHVT.Visible = true;
                    this.iconMenuPanel.Controls.Clear();
                    this.iconMenuPanel.Controls.Add(group_VTTH);
                    group_VTTH.Visible = true;

                }
                else if ("DHN".Equals(DAL.C_USERS._maphong.Trim()))
                {
                    this.menuQLDHNuoc.Visible = true;
                    this.iconMenuPanel.Controls.Clear();
                    this.iconMenuPanel.Controls.Add(group_DoiDHN);
                    group_DoiDHN.Visible = true;

                }
            }
            else if ("QT".Equals(DAL.C_USERS._roles.Trim()))
            {

                this.menuToThietKe.Visible = true;
                this.iconMenuPanel.Controls.Clear();
                this.menuKHVT.Visible = true;
                this.menuQLDHNuoc.Visible = true;
            }
        }

        private void vtth_DotNhanDon_Click(object sender, EventArgs e)
        {

            try
            {
                this.menuKHVT.Visible = true;
                this.menuKHVT.Select();
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new uct_DOTNHANDON());
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }

        private void vtth_NhanDonKH_Click(object sender, EventArgs e)
        {

            try
            {
                this.menuKHVT.Visible = true;
                this.menuKHVT.Select();
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new HSKHACHHANG(1));
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        private void btChuyenDon_Click(object sender, EventArgs e)
        {

            try
            {
                this.menuKHVT.Visible = true;
                this.menuKHVT.Select();
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new UCT_XINPHEPDD());
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        private void vtth_HoSoTraNgai_Click(object sender, EventArgs e)
        {

            try
            {
                this.menuKHVT.Visible = true;
                this.menuKHVT.Select();
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new UCT_DOTTHICONG());
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void vtth_HoSoTaiXet_Click(object sender, EventArgs e)
        {

            try
            {
                this.menuKHVT.Visible = true;
                this.menuKHVT.Select();
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new UCT_HOANCONG());
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void khvt_TraCuuHS_Click(object sender, EventArgs e)
        {

        }
        private void timkiemDOn_Click(object sender, EventArgs e)
        {

            try
            {
                this.menuKHVT.Visible = true;
                this.menuKHVT.Select();
                this.PanelContent.Controls.Clear();
                //this.PanelContent.Controls.Add(new HSKHACHHANG(5));
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        private void khvt_BaoCao_Click(object sender, EventArgs e)
        {

            try
            {
                this.menuKHVT.Visible = true;
                this.menuKHVT.Select();
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new HSKHACHHANG(6));
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btGiaoHoSo_Click(object sender, EventArgs e)
        {

            try
            {
                this.menuToThietKe.Visible = true;
                this.menuToThietKe.Select();
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new uct_GiaoHS(1));
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        private void btGhepHoSo_Click(object sender, EventArgs e)
        {

            try
            {
                this.menuToThietKe.Visible = true;
                this.menuToThietKe.Select();
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new uct_GiaoHS(2));
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        private void bt_SDVTraHS_Click(object sender, EventArgs e)
        {

            try
            {
                this.menuToThietKe.Visible = true;
                this.menuToThietKe.Select();
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new uct_GiaoHS(3));
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btTheoDoiTHTK_Click(object sender, EventArgs e)
        {

            try
            {
                this.menuToThietKe.Visible = true;
                this.menuToThietKe.Select();
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new uct_GiaoHS(4));
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {

            try
            {
                this.menuToThietKe.Visible = true;
                this.menuToThietKe.Select();
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new uct_GiaoHS(5));
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void subDangXuat_Click(object sender, EventArgs e)
        {
            this.menuToThietKe.Visible = false;
            this.menuQLDHNuoc.Visible = false;
            this.menuKHVT.Visible = false;
            menuQuanTri.Visible = false;
            iconMenuPanel.Controls.Clear();
            DAL.C_USERS._fullName = null;
            DAL.C_USERS._roles = null;
            DAL.C_USERS._userName = null;
            this.subDoiMatKhau.Visible = false;
            this.subDangXuat.Visible = false;
            this.subdangnhap.Visible = true;

        }

        private void btTinhDuToan_Click(object sender, EventArgs e)
        {

            try
            {
                this.menuToThietKe.Visible = true;
                this.menuToThietKe.Select();
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new tab_DanhMucVT(1));
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btDanhMucVT_Click(object sender, EventArgs e)
        {

            try
            {
                this.menuToThietKe.Visible = true;
                this.menuToThietKe.Select();
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new tab_DanhMucVT(2));
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btTaiLapMatBang_Click(object sender, EventArgs e)
        {

            try
            {
                this.menuToThietKe.Visible = true;
                this.menuToThietKe.Select();
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new tab_DanhMucVT(3));
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btBienNhan_Click(object sender, EventArgs e)
        {

            try
            {
                frm_BienNhanDon bn = new frm_BienNhanDon();
                bn.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void caculator_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void microsoftWord_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("WINWORD.EXE");
        }

        private void microsoftAccess_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("MSACCESS.EXE");
        }

        private void microsoftExcel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("EXCEL.EXE");
        }

        private void webBrowserTool_Click(object sender, EventArgs e)
        {

            try
            {
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new webBrowser());
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void menuTiemKiem_Click(object sender, EventArgs e)
        {

            try
            {
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new uc_TimKiemDonKH());
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void biennhan_Click(object sender, EventArgs e)
        {
            frm_BienNhanDon bn = new frm_BienNhanDon();
            bn.ShowDialog();
        }

        private void hoantatThietKe_Click(object sender, EventArgs e)
        {

            try
            {
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new tab_HoanTatTK());
                this.menuToThietKe.Select();
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btHoanTatTK_Click(object sender, EventArgs e)
        {

            try
            {
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new tab_HoanTatTK());
                this.menuToThietKe.Select();
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void frm_Main_SizeChanged(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Maximized)
            {
                PanelContent.Location = new Point(
    this.ClientSize.Width / 2 - PanelMain.Size.Width / 2,
    this.ClientSize.Height / 2 - PanelMain.Size.Height / 2 + 3);
                PanelContent.Anchor = AnchorStyles.None;
                this.lbNgayHeThong.Location = new System.Drawing.Point(800, 0);
            }
            else
            {
                this.lbNgayHeThong.Location = new System.Drawing.Point(653, 0);
                this.PanelContent.Location = new System.Drawing.Point(0, 54);
            }
        }

        private void xinphepDaoDuong_Click(object sender, EventArgs e)
        {

            try
            {

                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new UCT_XINPHEPDD());
                this.menuKHVT.Select();
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "Thoát Chương Trình ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }

        }

        private void Kh_DotThiCong_Click(object sender, EventArgs e)
        {

            try
            {
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new UCT_DOTTHICONG());
                this.menuKHVT.Select();
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void menuHoanCong_Click(object sender, EventArgs e)
        {

            try
            {
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new UCT_HOANCONG());
                this.menuKHVT.Select();
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void menuNhapDanhBo_Click(object sender, EventArgs e)
        {

            try
            {
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new UCT_CapDanhBo());
                this.menuQLDHNuoc.Select();
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void dhn_NhapDanhBo_Click(object sender, EventArgs e)
        {

            try
            {
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new UCT_CapDanhBo());
                this.menuQLDHNuoc.Select();
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void dhn_BaoCao_Click(object sender, EventArgs e)
        {

        }

        private void subDoiMatKhau_Click(object sender, EventArgs e)
        {
            frm_ChangePassword chang = new frm_ChangePassword();
            chang.ShowDialog();
        }

        private void menuQuanTri_Click(object sender, EventArgs e)
        {

            try
            {
                menuQuanTri.Visible = true;
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new Admin_Main());
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }

        private void khvt_bctk_Click(object sender, EventArgs e)
        {
            try
            {
                this.PanelContent.Controls.Clear();
                this.PanelContent.Controls.Add(new tab_BAOCAOTONGKET());
                this.menuKHVT.Select();
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        //private void menuDieuChinh_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.PanelContent.Controls.Clear();
        //        this.PanelContent.Controls.Add(new frm_BGDieuChinh());
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Loi Load Form " + ex.Message);
        //        MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        Application.Exit();
        //    }

        //}
    }
}