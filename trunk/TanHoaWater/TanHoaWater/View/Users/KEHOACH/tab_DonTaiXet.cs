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
    public partial class tab_DonTaiXet : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_DonTroNgai).Name);
        public tab_DonTaiXet()
        {
            InitializeComponent();           
          
            this.taix_shs.Mask = DateTime.Now.Year.ToString().Substring(2) + "CCCCC";
            fromload();
            Utilities.DataGridV.formatRows(dataG);
        }
        
        public void fromload() {
            this.dataG.DataSource = DAL.C_DonKhachHang.getListTaiXet();         
            Utilities.DataGridV.formatRows(dataG);
        }
            

        private void update_TaiXet_Click(object sender, EventArgs e)
        {
            try
            {
                string _soHoSo = this.taix_sohoso.Text;
                if (_soHoSo != null)
                {
                    bool result1 = DAL.C_DonKhachHang.HoSoTaiXet(_soHoSo, DAL.C_USERS._userName);
                    if (result1)
                    {
                        MessageBox.Show(this, "Tái Xét Hồ Sơ Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Tái Xét Hồ Sơ Lỗi !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Loi tra ho so " + ex.Message);
                MessageBox.Show(this, "Tái Xét Hồ Sơ Lỗi !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            fromload();
        }

        private void taix_shs_KeyPress(object sender, KeyPressEventArgs e)
        {
          //  txtResult.Text = null;
            if (e.KeyChar == 13)
            {
                try
                {
                    string _soHoSo = this.taix_shs.Text;
                    if (_soHoSo != null)
                    {

                        Database.DON_KHACHHANG donkh = DAL.C_DonKhachHang.findBySOHOSO(_soHoSo);
                        if (donkh != null)
                        {
                            this.taix_shs.Text = donkh.SHS;
                            this.taix_sohoso.Text = donkh.SOHOSO;
                            this.taix_soHo.Value = decimal.Parse(donkh.SOHO.ToString());
                            this.taix_hoten.Text = donkh.HOTEN;
                            this.taix_diachi.Text = donkh.SONHA + " " + donkh.DUONG + ", P. " + DAL.C_Phuong.finbyPhuong(donkh.QUAN, donkh.PHUONG).TENPHUONG + ", Q." + DAL.C_Quan.finByMaQuan(donkh.QUAN).TENQUAN;
                            this.taix_loaikh.Text = DAL.C_LoaiKhachHang.finbyMaLoai(donkh.LOAIKH).TENLOAI;
                            this.taix_loaihs.Text = DAL.C_LoaiHoSo.findbyMaLoai(donkh.LOAIHOSO).TENLOAI;
                            this.taix_dotnhandon.Text = donkh.MADOT;
                            this.taix_sodt.Text = donkh.DIENTHOAI;
                            this.taix_ghichu.Text = donkh.GHICHU;
                            this.taix_ngaydaottk.Text = Utilities.DateToString.NgayVN(donkh.NGAYCHUYEN_HOSO.Value);
                            this.taix_noiduntrongai.Text = donkh.NOIDUNGTRONGAI;
                            Database.TOTHIETKE ttk = DAL.C_ToThietKe.findBySoHoSo(donkh.SOHOSO);
                            if (ttk != null)
                            {
                                if (ttk.TRONGAITHIETKE == true)
                                {
                                    this.taix_noiduntrongai.Text = ttk.NOIDUNGTRONGAI;


                                }
                                Database.USER us = DAL.C_USERS.findByUserName(ttk.SODOVIEN);
                                if (us != null)
                                {
                                    this.taix_sodovien.Text = us.FULLNAME;
                                }
                            }

                        }
                        else
                        {
                            this.taix_shs.Text = null;
                            this.taix_sohoso.Text = null;
                            this.taix_soHo.Value = 0;
                            this.taix_hoten.Text = null;
                            this.taix_diachi.Text = null;
                            this.taix_loaikh.Text = null;
                            this.taix_loaihs.Text = null;
                            this.taix_dotnhandon.Text = null;
                            this.taix_sodt.Text = null;
                            this.taix_ghichu.Text = null;
                            this.taix_sodovien.Text = null;
                            this.taix_noiduntrongai.Text = null;
                        }
                    }

                }
                catch (Exception)
                {
                }
            }
        }

        private void dataG_Sorted(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataG);
        }
    }
}
