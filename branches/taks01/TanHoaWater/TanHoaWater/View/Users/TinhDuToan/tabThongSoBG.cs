using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;
using log4net;

namespace TanHoaWater.View.Users.TinhDuToan
{
    public partial class tabThongSoBG : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tabThongSoBG).Name);
        BG_REPORT report = null;
        BG_HESOBANGGIA hsbg = null;
        BG_HESOPHUIDAO hsphui = null;
        public tabThongSoBG()
        {
            InitializeComponent();
            try
            {
                hsbg = DAL.C_HeSoBangGia.getHeSoBangGia();
                if (hsbg != null)
                {
                    this.NhanCong.Text = hsbg.NC + "";
                    this.MayThiCong.Text = hsbg.MTC + "";
                    this.PhiCaBa.Text = hsbg.CABA + "";
                    this.PhiKhac.Text = hsbg.PHIKHAC + "";
                    this.PhiChung.Text = hsbg.PHICHUNG + "";
                    this.PhiTruocThue.Text = hsbg.TRUOCTHUE + "";
                    this.PhiKSTK.Text = hsbg.PHIKSTK + "";
                    this.HSKSTK.Text = hsbg.HSKSTK + "";
                    this.PhiGiamSat.Text = hsbg.PHIGIAMSAT + "";
                    this.PhiQuanLy.Text = hsbg.CHIPHIQL + "";
                    this.ThueVAT.Text = hsbg.VAT + "";

                }
                report = DAL.C_HeSoBangGia.getReport();
                if (report != null)
                {
                    LINE1.Text = report.LINE1;
                    LINE2.Text = report.LINE2;
                    LINE3.Text = report.LINE3;
                    LINE4.Text = report.LINE4;
                    LINE5.Text = report.LINE5;
                    DuyetChucVu.Text = report.DUYET;
                    DuyetNguoiDuyet.Text = report.NGUOIDUYET;
                    THANHLAP.Text = report.THANHLAP;
                    NGUOILAP.Text = report.NGUOILAP;
                }
                hsphui = DAL.C_HeSoBangGia.getHesoPhui();
                if (hsphui != null)
                {
                    KL_NHUA12.Text = hsphui.KL_NHUA12 + "";
                    DATC4_NHUA12.Text = hsphui.DATC4_NHUA12 + "";
                    KL_NHUA10.Text = hsphui.KL_NHUA10 + "";
                    DATC4_NHUA10.Text = hsphui.DATC4_NHUA10 + "";
                    KL_BT10.Text = hsphui.KL_BT10 + "";
                    DATC4_BT10.Text = hsphui.DATC4_BT10 + "";
                    DATC4_DAXANH.Text = hsphui.DATC4_DAXANH + "";
                    DATC4_DADO.Text = hsphui.DATC4_DADO + "";
                    KLDA04_TNHA.Text = hsphui.KLDA04_TNHA + "";
                    CHISODD.Text = hsphui.CHISODD + "";
                    KL_CONLAI.Text = hsphui.KL_CONLAI + "";
                    DATC4_CONLAI.Text = hsphui.DATC4_CONLAI + "";
                }

            }
            catch (Exception)
            {

            }
        }


        private void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // BG_HESOBANGGIA hsbg = DAL.C_HeSoBangGia.getHeSoBangGia();
                hsbg.NC = double.Parse(this.NhanCong.Text);
                hsbg.MTC = double.Parse(this.MayThiCong.Text);
                hsbg.CABA = double.Parse(this.PhiCaBa.Text);
                hsbg.PHIKHAC = double.Parse(this.PhiKhac.Text);
                hsbg.PHICHUNG = double.Parse(this.PhiChung.Text);
                hsbg.TRUOCTHUE = double.Parse(this.PhiTruocThue.Text);
                hsbg.PHIKSTK = double.Parse(this.PhiKSTK.Text);
                hsbg.HSKSTK = double.Parse(this.HSKSTK.Text);
                hsbg.PHIGIAMSAT = double.Parse(this.PhiGiamSat.Text);
                hsbg.CHIPHIQL = double.Parse(this.PhiQuanLy.Text);
                hsbg.VAT = double.Parse(this.ThueVAT.Text);
                if (DAL.C_HeSoBangGia.UpdateHeSoBangGia())
                {
                    MessageBox.Show(this, "Cập Nhật Thông Số Bảng Giá Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Cập Nhật Thông Số Bảng Giá Thất Bại!", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                log.Error("Cap Nhat THong So That Bai " + ex.Message);
                MessageBox.Show(this, "Cập Nhật Thông Số Bảng Giá Thất Bại!", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void NhanCong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                if ((e.KeyChar) != 8 && (e.KeyChar) != 46 && (e.KeyChar) != 37 && (e.KeyChar) != 39 && (e.KeyChar) != 188)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
        }

        private void MayThiCong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                if ((e.KeyChar) != 8 && (e.KeyChar) != 46 && (e.KeyChar) != 37 && (e.KeyChar) != 39 && (e.KeyChar) != 188)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
        }

        private void PhiCaBa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                if ((e.KeyChar) != 8 && (e.KeyChar) != 46 && (e.KeyChar) != 37 && (e.KeyChar) != 39 && (e.KeyChar) != 188)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
        }

        private void PhiKhac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                if ((e.KeyChar) != 8 && (e.KeyChar) != 46 && (e.KeyChar) != 37 && (e.KeyChar) != 39 && (e.KeyChar) != 188)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
        }

        private void PhiChung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                if ((e.KeyChar) != 8 && (e.KeyChar) != 46 && (e.KeyChar) != 37 && (e.KeyChar) != 39 && (e.KeyChar) != 188)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
        }

        private void PhiTruocThue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                if ((e.KeyChar) != 8 && (e.KeyChar) != 46 && (e.KeyChar) != 37 && (e.KeyChar) != 39 && (e.KeyChar) != 188)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
        }

        private void PhiKSTK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                if ((e.KeyChar) != 8 && (e.KeyChar) != 46 && (e.KeyChar) != 37 && (e.KeyChar) != 39 && (e.KeyChar) != 188)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
        }

        private void HSKSTK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                if ((e.KeyChar) != 8 && (e.KeyChar) != 46 && (e.KeyChar) != 37 && (e.KeyChar) != 39 && (e.KeyChar) != 188)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
        }

        private void PhiGiamSat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                if ((e.KeyChar) != 8 && (e.KeyChar) != 46 && (e.KeyChar) != 37 && (e.KeyChar) != 39 && (e.KeyChar) != 188)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
        }

        private void PhiQuanLy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                if ((e.KeyChar) != 8 && (e.KeyChar) != 46 && (e.KeyChar) != 37 && (e.KeyChar) != 39 && (e.KeyChar) != 188)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
        }

        private void ThueVAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                if ((e.KeyChar) != 8 && (e.KeyChar) != 46 && (e.KeyChar) != 37 && (e.KeyChar) != 39 && (e.KeyChar) != 188)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
        }

        private void btCapNhatBangGia_Click(object sender, EventArgs e)
        {
            try
            {
                // BG_HESOBANGGIA hsbg = DAL.C_HeSoBangGia.getHeSoBangGia();
                report.LINE1 = LINE1.Text;
                report.LINE2 = LINE2.Text;
                report.LINE3 = LINE3.Text;
                report.LINE4 = LINE4.Text;
                report.LINE5 = LINE5.Text;
                report.DUYET = DuyetChucVu.Text;
                report.NGUOIDUYET = DuyetNguoiDuyet.Text;
                report.THANHLAP = THANHLAP.Text;
                report.NGUOILAP = NGUOILAP.Text;
                if (DAL.C_HeSoBangGia.UpdateHeSoBangGia())
                {
                    MessageBox.Show(this, "Cập Nhật Thông Số Bảng Giá Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Cập Nhật Thông Số Bảng Giá Thất Bại!", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                log.Error("Cap Nhat THong So That Bai " + ex.Message);
                MessageBox.Show(this, "Cập Nhật Thông Số Bảng Giá Thất Bại!", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
             try
            {
            hsphui.KL_NHUA12 = double.Parse(KL_NHUA12.Text);
            hsphui.DATC4_NHUA12 = double.Parse(DATC4_NHUA12.Text);
            hsphui.KL_NHUA10 = double.Parse(KL_NHUA10.Text);
            hsphui.DATC4_NHUA10 = double.Parse(DATC4_NHUA10.Text);
            hsphui.KL_BT10 = double.Parse(KL_BT10.Text);
            hsphui.DATC4_BT10 = double.Parse(DATC4_BT10.Text);
            hsphui.DATC4_DAXANH = double.Parse(DATC4_DAXANH.Text);
            hsphui.DATC4_DADO = double.Parse(DATC4_DADO.Text);
            hsphui.KLDA04_TNHA = double.Parse(KLDA04_TNHA.Text);
            hsphui.CHISODD = double.Parse(CHISODD.Text);
            hsphui.KL_CONLAI = double.Parse(KL_CONLAI.Text);
            hsphui.DATC4_CONLAI = double.Parse(DATC4_CONLAI.Text);
            if (DAL.C_HeSoBangGia.UpdateHeSoBangGia())
            {
                MessageBox.Show(this, "Cập Nhật Hệ Số Phui Đào Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "Cập Nhật Hệ Số Phui ĐàoThất Bại!", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
             catch (Exception ex)
             {
                 log.Error("Cap Nhat He So Phui Dao That BAI " + ex.Message);
                 MessageBox.Show(this, "Cập Nhật Hệ Số Phui Đào Thất Bại!", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }
    }
}
