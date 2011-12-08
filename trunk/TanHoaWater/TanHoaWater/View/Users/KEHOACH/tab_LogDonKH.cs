using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using System.Collections;
using TanHoaWater.Database;

namespace TanHoaWater.View.Users.HSKHACHHANG
{
    public partial class tab_LogDonKH : UserControl
    {

        private static readonly ILog log = LogManager.GetLogger(typeof(tab_TimKiemDonKH).Name);
        public tab_LogDonKH()
        {
            InitializeComponent();

        }

        private void SearchMaHoSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {

                //try
                //{
                    string _soHoSo = SearchMaHoSo.Text;
                    if (_soHoSo != null)
                    {
                        Database.DON_KHACHHANG donkh = DAL.C_DonKhachHang.findBySHS(_soHoSo);
                        if (donkh != null)
                        {
                            this.txtSHS.Text = donkh.SHS;
                            this.txtSoHoSo.Text = Utilities.FormatSoHoSoDanhBo.sohoso(donkh.SOHOSO);
                            this.txtSoHo.Value = decimal.Parse(donkh.SOHO.ToString());
                            this.txtHoTen.Text = donkh.HOTEN;
                            this.txtsonha.Text = donkh.SONHA;
                            this.duong.Text = donkh.DUONG;
                            // select Quan
                            cbQuan.Text = DAL.C_Quan.finByMaQuan(donkh.QUAN).TENQUAN;
                            // select Phuong
                            cbPhuong.Text = DAL.C_Phuong.finbyPhuong(donkh.QUAN, donkh.PHUONG).TENPHUONG;
                            //select loaiKH
                            cbLoaiKH.Text = DAL.C_LoaiKhachHang.finbyMaLoai(donkh.LOAIKH).TENLOAI;
                            // select loaiHoso
                            cbLoaiHS.Text = DAL.C_LoaiHoSo.findbyMaLoai(donkh.LOAIHOSO).TENLOAI;
                            this.cbDotNhanDon.Text = donkh.MADOT;
                            this.dienthoai.Text = donkh.DIENTHOAI;
                            this.ghichu.Text = donkh.GHICHU;
                            this.hsnguoilap.Text = donkh.CREATEBY;
                            this.hsngaylap.Text = donkh.CREATEDATE+"";
                            this.hsngaysua.Text = donkh.MODIFYDATE+"";
                            this.hsnguoisua.Text = donkh.MODIFYBY;
                            this.hsnoidungsua.Text = donkh.MODIFYLOG;
                            Database.BIENNHANDON biennhan = DAL.C_BienNhanDon.finbyMaBienNhan(donkh.SHS);
                            if (biennhan != null)
                            {
                                this.bnnguoilap.Text = biennhan.CREATEBY;
                                this.bnNgayLao.Text = biennhan.CREATEDATE + "";
                                this.bnngaysua.Text = biennhan.MODIFYDATE + "";
                                this.bnnguoisua.Text = biennhan.MODIFYBY;

                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Không Tìm Thấy Đơn Khách Hàng ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    

                //}
                //catch (Exception)
                //{
                //}
            }
        }
    }

}