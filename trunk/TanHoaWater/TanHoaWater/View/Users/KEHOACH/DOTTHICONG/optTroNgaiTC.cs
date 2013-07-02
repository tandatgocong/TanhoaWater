using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;

namespace TanHoaWater.View.Users.KEHOACH.DOTTHICONG
{
    public partial class optTroNgaiTC : Form
    {
        public optTroNgaiTC()
        {
            InitializeComponent();
        }
        KH_HOSOKHACHHANG hskh = null;
        void refesh()
        {
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
            this.txtnoidungtrongai.Text = "";

        }

        private void txtSHS_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtResult.Text = null;
            if (e.KeyChar == 13)
            {
                try
                {
                    refesh();
                    string _soHoSo = this.txtSHS.Text;
                    if (_soHoSo != null)
                    {

                        Database.DON_KHACHHANG donkh = DAL.C_DonKhachHang.findBySOHOSO(_soHoSo);
                        if (donkh != null)
                        {
                            hskh = DAL.C_KH_HoSoKhachHang.findBySHS(donkh.SHS);
                            if (hskh != null) {

                                this.textBoxX1.Text = hskh.MADOTTC;
                            }
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
                                    this.txtnoidungtrongai.Text = ttk.NOIDUNGTRONGAI;


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
                            MessageBox.Show(this, "Không Tìm Thấy Đơn Khách Hàng", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (hskh != null) {
                try
                {
                    hskh.TRONGAI = true;
                    hskh.NOIDUNGTN = this.txtnoidungtrongai.Text;
                    hskh.MODIFYBY = DAL.C_USERS._userName;
                    hskh.MODIFYDATE = DateTime.Now;

                    bool result1 = DAL.C_KH_HoSoKhachHang.Update();
                        if (result1)
                        {
                            MessageBox.Show(this, "Cập Nhật Hồ Sơ Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(this, "Cập Nhật Hồ Sơ Lỗi !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
               
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Cập Nhật Hồ Sơ Lỗi !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
