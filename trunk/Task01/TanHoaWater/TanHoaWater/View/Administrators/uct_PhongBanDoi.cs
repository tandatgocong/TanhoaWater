using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;

namespace TanHoaWater.View.Administrators
{
    public partial class uct_PhongBanDoi : UserControl
    {
        KH_BC_XINPHEPDD xinphepdd = null;
        KH_TC_BAOCAO thicong = null;
        DHN_BAOCAO dhn = null;
        public uct_PhongBanDoi()
        {
            InitializeComponent();
            xinphepdd = DAL.C_Admin_BaoCao.xinphepdaoduong();
            thicong = DAL.C_Admin_BaoCao.xinHoanCongAndDotTC();
            dhn = DAL.C_Admin_BaoCao.quanlydhn();
            if (xinphepdd != null) {
                xpdd_nguoiduyet.Text = xinphepdd.NGUOIDUYET;
                xpdd_chucvu.Text = xinphepdd.CHUCVU;
            }
            if (thicong != null)
            {
                thicong_chucvu.Text = thicong.CVDUYET;
                thicong_nguoiduyet.Text = thicong.NGUOIDUYET;
                thicong_chucvulap.Text = thicong.CVKEHOACH;
                thicong_chucvunguoi.Text = thicong.NGUOITL;
                hoancong_chucvu.Text = thicong.CVKEHOACH;
                hoancong_nguoiduyet.Text = thicong.NGUOITL;
            }
            if (dhn != null)
            {
                dhn_chucvuduyet.Text = dhn.KTGIAMDOC_CV;
                dhn_nguoiduyet.Text = dhn.TENKT;
                dhn_nguoilap.Text = dhn.THANHLAP;
                dhn_tennguoilap.Text = dhn.TENTHL;
            }
            
        }

        private void thicong_capnhat_Click(object sender, EventArgs e)
        {
            if (xinphepdd != null)
            {
                 xinphepdd.NGUOIDUYET = xpdd_nguoiduyet.Text;
                 xinphepdd.CHUCVU = xpdd_chucvu.Text ;
            }
            if (thicong != null)
            {
                thicong.CVDUYET = thicong_chucvu.Text;
                thicong.NGUOIDUYET = thicong_nguoiduyet.Text;
                thicong.CVKEHOACH = thicong_chucvulap.Text;
                thicong.NGUOITL = thicong_chucvunguoi.Text;

                thicong.CVKEHOACH=hoancong_chucvu.Text ;
                thicong.NGUOITL = hoancong_nguoiduyet.Text;
            }
            if (dhn != null)
            {
                dhn.KTGIAMDOC_CV = dhn_chucvuduyet.Text;
                dhn.TENKT = dhn_nguoiduyet.Text;
                dhn.THANHLAP = dhn_nguoilap.Text;
                dhn.TENTHL = dhn_tennguoilap.Text;
            }
            DAL.C_Admin_BaoCao.update();
            MessageBox.Show(this,"Cập Nhật Thành Công !");
        }
    }
}
