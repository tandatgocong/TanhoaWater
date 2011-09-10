using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace TanHoaWater.View.Users.KEHOACH
{
    public partial class tab_DonTroNgai : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_DonTroNgai).Name);
        public tab_DonTroNgai()
        {
            InitializeComponent();
            this.txtSHS.Mask = DateTime.Now.Year.ToString().Substring(2) + "CCCCC";
            txtSHS.Focus();
        }

        private void txtSHS_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtResult.Text = null;
            if (e.KeyChar == 13)
            {
                try
                {
                    string _soHoSo = this.txtSHS.Text;
                    if (_soHoSo != null)
                    {

                        Database.DON_KHACHHANG donkh = DAL.C_DonKhachHang.findBySOHOSO(_soHoSo);
                        if (donkh != null)
                        {
                            this.txtSHS.Text = donkh.SHS;
                            this.txtSoHoSo.Text = donkh.SOHOSO;
                            this.txtSoHo.Value = decimal.Parse(donkh.SOHO.ToString());
                            this.txtHoTen.Text = donkh.HOTEN;
                            this.txtdiachi.Text = donkh.SONHA + " " + donkh.DUONG + ", P. " + DAL.C_Phuong.finbyPhuong(donkh.QUAN, donkh.PHUONG).TENPHUONG + ", Q." + DAL.C_Quan.finByMaQuan(donkh.QUAN).TENQUAN;
                            this.txtLoaiKH.Text = DAL.C_LoaiKhachHang.finbyMaLoai(donkh.LOAIKH).TENLOAI;
                            this.txtLoaiHS.Text = DAL.C_LoaiHoSo.findbyMaLoai(donkh.LOAIHOSO).TENLOAI;
                            this.txtDotND.Text = donkh.MADOT;
                            this.txtSoDT.Text = donkh.DIENTHOAI;
                            this.txtGhiChu.Text = donkh.GHICHU;
                            Database.TOTHIETKE ttk = DAL.C_ToThietKe.findBySoHoSo(donkh.SOHOSO);
                            if (ttk != null)
                            {
                                if (ttk.TRONGAITHIETKE == true)
                                {                                  
                                    this.txtNoiDungTN.Text = ttk.NOIDUNGTRONGAI;


                                }
                                Database.USER us = DAL.C_USERS.findByUserName(ttk.SODOVIEN);
                                if (us != null)
                                {
                                    this.txt_sdv.Text = us.FULLNAME;
                                }
                            }

                        }
                        else
                        {
                            this.txtSHS.Text = null;
                            this.txtSoHoSo.Text = null;
                            this.txtSoHo.Value = 0;
                            this.txtHoTen.Text = null;
                            this.txtdiachi.Text = null;
                            this.txtLoaiKH.Text = null;
                            this.txtLoaiHS.Text = null;
                            this.txtDotND.Text = null;
                            this.txtSoDT.Text = null;
                            this.txtGhiChu.Text = null;
                            this.txt_sdv.Text = null;
                        }
                    }

                }
                catch (Exception)
                {
                }
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string _soHoSo = this.txtSoHoSo.Text;
                if (_soHoSo != null)
                {
                    bool result1 = DAL.C_DonKhachHang.TroNgaiThietKe(_soHoSo, this.txtNoiDungTN.Text, DAL.C_USERS._userName);
                    if ( result1) { txtResult.Text = "Cập Nhật Hồ Sơ Thành Công"; }
                    else { txtResult.Text = "Cập Nhật Hồ Sơ Thất Bại"; }
                }
            }
            catch (Exception ex)
            {
                log.Error("Loi tra ho so " + ex.Message);
                MessageBox.Show(this, "..: Thông Báo :..", "Cập Nhật Hồ Sơ Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
