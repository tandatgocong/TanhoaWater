using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;

namespace TanHoaWater.View.Users.KTTC
{
    public partial class frm_HeSoQT : Form
    {
        public double hs_nhancong = 0.0;
        public double hs_maythicong = 0.0;
        public double hs_chiphichung = 0.0;
        public double hs_tnchuithue = 0.0;
        public double hs_thue = 0.0;
        KTTC_HESOQUYETTOAN hsqt = null;
        public frm_HeSoQT()
        {
            InitializeComponent();
            hsqt = DAL.C_KTTC_HeSoQT.hsquyettoan();
            if (hsqt != null)
            {
                hsNhanCong.Text = hsqt.NHANCONG.Value+"";
                hsMayTC.Text = hsqt.MAYTC.Value + "";
                hsChiPhiChung.Text = hsqt.CHIPHICUNG.Value + "";
                hs_thunhap.Text = hsqt.TNCHUITHUE.Value + "";
                hsThue.Text = hsqt.THUE.Value + "";

            }
            
        }
       
        private void btLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (hsqt != null)
                {
                    hsqt.NHANCONG = double.Parse(hsNhanCong.Text.Trim());
                    hsqt.MAYTC = double.Parse(hsMayTC.Text.Trim());
                    hsqt.CHIPHICUNG = double.Parse(hsChiPhiChung.Text.Trim());
                    hsqt.TNCHUITHUE = double.Parse(hs_thunhap.Text.Trim());
                    hsqt.THUE = double.Parse(hsThue.Text.Trim());
                    DAL.C_KTTC_HeSoQT.Update();

                    hs_nhancong = double.Parse(hsNhanCong.Text.Trim());
                    hs_maythicong = double.Parse(hsMayTC.Text.Trim());
                    hs_chiphichung = double.Parse(hsChiPhiChung.Text.Trim());
                    hs_tnchuithue = double.Parse(hs_thunhap.Text.Trim());
                    hs_thue = double.Parse(hsThue.Text.Trim());

                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Lỗi, Cập Nhật Chỉ Số Quyết Toán.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btLuu.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            }
        }

        private void hsNhanCong_KeyPress(object sender, KeyPressEventArgs e)
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

        private void hsThue_KeyPress(object sender, KeyPressEventArgs e)
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

        private void hs_thunhap_KeyPress(object sender, KeyPressEventArgs e)
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

        private void hsChiPhiChung_KeyPress(object sender, KeyPressEventArgs e)
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

        private void hsMayTC_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
