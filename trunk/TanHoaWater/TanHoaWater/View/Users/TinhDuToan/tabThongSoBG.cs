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
        public tabThongSoBG()
        {
            InitializeComponent();
            BG_HESOBANGGIA hsbg = DAL.C_HeSoBangGia.getHeSoBangGia();
            if (hsbg != null) {
                this.NhanCong.Text = hsbg.NC+"";
                this.MayThiCong.Text = hsbg.MTC + "";
                this.PhiCaBa.Text = hsbg.CABA + "";
                this.PhiKhac.Text = hsbg.PHIKHAC+"";
                this.PhiChung.Text = hsbg.PHICHUNG + "";
                this.PhiTruocThue.Text = hsbg.TRUOCTHUE + "";
                this.PhiKSTK.Text = hsbg.PHIKSTK + "";
                this.HSKSTK.Text = hsbg.HSKSTK + "";
                this.PhiGiamSat.Text = hsbg.PHIGIAMSAT + "";
                this.PhiQuanLy.Text = hsbg.CHIPHIQL+"";
                this.ThueVAT.Text = hsbg.VAT + "";

            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                BG_HESOBANGGIA hsbg = DAL.C_HeSoBangGia.getHeSoBangGia();
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
    }
}
