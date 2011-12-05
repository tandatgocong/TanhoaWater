﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.Report;
using TanHoaWater.View.Users.KEHOACH.DOTTHICONG.BC;
using log4net;

namespace TanHoaWater.View.Users.KEHOACH.DOTTHICONG
{
    public partial class tab_CapNhatDSBoiThuong : UserControl
    {
        string _madot="";
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_CapNhatDSBoiThuong).Name);
        public tab_CapNhatDSBoiThuong(string madot)
        {
            InitializeComponent();
            this.cbCoTLK.Items.Add("15");
            this.cbCoTLK.Items.Add("25");
            this.cbCoTLK.Items.Add("50");
            this.cbCoTLK.SelectedIndex = 0;
            lbDotTc.Text = "ĐỢT THI CÔNG : " + madot.ToUpper();
            _madot = madot;
            loadDataGrid();
        }
        public void refesh()
        {
            this.txtSHS.Text = "";
            this.txtHoTenKH.Text = "";
            this.txtDiaChi.Text = "";
            this.txtPhuong.Text = "";
            this.txtQuan.Text = "";
            this.cbCoTLK.Text = "15";
            this.dateNgayDongTien.ValueObject = null;
            this.txtSoHoaDon.Text = "";
            this.txtTinhTrangTLK.Text = "";
            this.txtSoDanhBo.Text = "";
            this.txtSHS.Focus();
        }
        public void loadDataGrid()
        {
            dataGridViewX1.DataSource = DAL.C_KH_DotThiCong.getListDotThiCongBT(_madot);
            Utilities.DataGridV.formatSoHoSoDanhBo(dataGridViewX1);
            lbTongHoSo.Text = "Tổng Số Có " + dataGridViewX1.Rows.Count + " Hồ Sơ";
          
        }
        public void DongTien()
        {
            if (!"".Equals(this.txtSoHoaDon.Text) && !"1/1/0001".Equals(this.dateNgayDongTien.Value.ToShortDateString()))
            {
                DAL.C_DonKhachHang.DongTienKH(this.txtSHS.Text, this.dateNgayDongTien.Value.Date, this.txtSoHoaDon.Text);
            }
        }
        public void add()
        {
            try
            {
                if ("".Equals(this.txtSHS.Text))
                {
                    MessageBox.Show(this, "Số Hồ Sơ Không Được Trống", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtSHS.Focus();
                }
                else
                {
                    DongTien();
                    KH_HOSOKHACHHANG kh_sh = DAL.C_KH_HoSoKhachHang.findBySHS(this.txtSHS.Text.Trim());
                    DON_KHACHHANG donkh = DAL.C_DonKhachHang.findBySOHOSO(this.txtSHS.Text.Trim());
                    BG_KHOILUONGXDCB xdcb = DAL.C_KhoiLuongXDCB.findBySHS(this.txtSHS.Text.Trim());
                    if (kh_sh == null)
                    {
                        kh_sh = new KH_HOSOKHACHHANG();
                        kh_sh.SHS = this.txtSHS.Text;
                        kh_sh.MADOTTC = _madot;
                        kh_sh.COTLK = int.Parse(this.cbCoTLK.Text);
                        if (xdcb != null)
                        {
                            kh_sh.CPVATTU = xdcb.CPVATTU;
                            kh_sh.CPNHANCONG = xdcb.CPNHANCONG;
                            kh_sh.CPMAYTHICONG = xdcb.CPMAYTHICONG;
                            kh_sh.CPCABA = xdcb.CPCABA;
                            kh_sh.CHIPHITRUCTIEP = xdcb.CHIPHITRUCTIEP;
                            kh_sh.CHIPHICHUNG = xdcb.CHIPHICHUNG;
                            kh_sh.TAILAPMATDUONG = xdcb.TAILAPMATDUONG;
                            kh_sh.TLMDTRUOCTHUE = xdcb.TLMDTRUOCTHUE;
                            kh_sh.CONG1 = xdcb.CONG1;
                            kh_sh.THUE55 = xdcb.THUE55;
                            kh_sh.CONG3 = xdcb.CONG3;
                            kh_sh.THUEGTGT = xdcb.THUEGTGT;
                            kh_sh.TONGIATRI = xdcb.TONGIATRI;
                            kh_sh.CPGAN = xdcb.CPGAN;
                            kh_sh.CPNHUA = xdcb.CPNHUA;
                        }
                        if (donkh != null)
                        {
                            kh_sh.DHN_HOTEN = Utilities.Strings.convertToUnSign(donkh.HOTEN.Replace("(ĐD " + donkh.SOHO + " Hộ)", ""));
                            kh_sh.DHN_SONHA = Utilities.Strings.convertToUnSign(donkh.SONHA);
                            kh_sh.DHN_DIACHI = Utilities.Strings.convertToUnSign(donkh.DUONG);
                            kh_sh.DHN_MAQUANPHUONG = donkh.QUAN + "" + donkh.PHUONG;
                        }
                        kh_sh.DHN_GIABIEU=11;
	                    kh_sh.DHN_DMGOC=0;
	                    kh_sh.DHN_DMCAPBU =0;
                        kh_sh.DHN_SOHO =0;
                        kh_sh.DHN_SONHANKHAU = 0;
                        kh_sh.MODIFYDATE = DateTime.Now;
                        kh_sh.CREATEBY = DAL.C_USERS._userName;
                        kh_sh.CREATEDATE = DateTime.Now.Date;
                        if (DAL.C_KH_HoSoKhachHang.Insert(kh_sh) == false)
                        {// co roi do len dot thi cong truoc
                            MessageBox.Show(this, "Thêm Hồ Sơ Xin Phép Bị lỗi !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.txtSHS.Focus();
                            refesh();
                        }
                        try
                        {
                            this.txtSHS.Text = (int.Parse(kh_sh.SHS) + 1) + "";
                        }
                        catch (Exception)
                        {

                        }
                    }
                    else
                    {
                        kh_sh.MADOTTC = _madot;
                        kh_sh.COTLK = int.Parse(this.cbCoTLK.Text);
                        kh_sh.MODIFYBY = DAL.C_USERS._userName;
                        kh_sh.MODIFYDATE = DateTime.Now;
                        if (xdcb != null)
                        {
                            kh_sh.CPVATTU = xdcb.CPVATTU;
                            kh_sh.CPNHANCONG = xdcb.CPNHANCONG;
                            kh_sh.CPMAYTHICONG = xdcb.CPMAYTHICONG;
                            kh_sh.CPCABA = xdcb.CPCABA;
                            kh_sh.CHIPHITRUCTIEP = xdcb.CHIPHITRUCTIEP;
                            kh_sh.CHIPHICHUNG = xdcb.CHIPHICHUNG;
                            kh_sh.TAILAPMATDUONG = xdcb.TAILAPMATDUONG;
                            kh_sh.TLMDTRUOCTHUE = xdcb.TLMDTRUOCTHUE;
                            kh_sh.CONG1 = xdcb.CONG1;
                            kh_sh.THUE55 = xdcb.THUE55;
                            kh_sh.CONG3 = xdcb.CONG3;
                            kh_sh.THUEGTGT = xdcb.THUEGTGT;
                            kh_sh.TONGIATRI = xdcb.TONGIATRI;
                            kh_sh.CPGAN = xdcb.CPGAN;
                            kh_sh.CPNHUA = xdcb.CPNHUA;
                        }
                        if (donkh != null)
                        {
                            kh_sh.DHN_HOTEN = Utilities.Strings.convertToUnSign(donkh.HOTEN.Replace("(ĐD " + donkh.SOHO + " Hộ)", ""));
                            kh_sh.DHN_SONHA = Utilities.Strings.convertToUnSign(donkh.SONHA);
                            kh_sh.DHN_DIACHI = Utilities.Strings.convertToUnSign(donkh.DUONG);
                            kh_sh.DHN_MAQUANPHUONG = donkh.QUAN + "" + donkh.PHUONG;
                        }
                        kh_sh.DHN_GIABIEU = 11;
                        kh_sh.DHN_DMGOC = 0;
                        kh_sh.DHN_DMCAPBU = 0;
                        kh_sh.DHN_SOHO = 0;
                        kh_sh.DHN_SONHANKHAU = 0;
                        //  kh_sh
                        DAL.C_KH_HoSoKhachHang.Update();
                        try
                        {
                            this.txtSHS.Text = (int.Parse(kh_sh.SHS) + 1) + "";
                        }
                        catch (Exception)
                        {

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error("add ho so kh -> ke hoach khLoi" + ex.Message);
            }

            loadDataGrid();
        }
        private void txtSHS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DataTable table = DAL.C_KH_DotThiCong.findByHSHT(this.txtSHS.Text);
                if (table.Rows.Count <= 0)
                {
                    MessageBox.Show(this, "Không Tìm Thấy Hồ Sơ Hoàn Tất Thiết Kế !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
                else
                {
                    this.txtSHS.Text = table.Rows[0][0].ToString();
                    this.txtHoTenKH.Text = table.Rows[0][2].ToString();
                    this.txtDiaChi.Text = table.Rows[0][3].ToString();
                    this.txtPhuong.Text = table.Rows[0][4].ToString();
                    this.txtQuan.Text = table.Rows[0][5].ToString();
                    this.dateNgayDongTien.ValueObject = table.Rows[0][6];
                    this.txtSoHoaDon.Text = table.Rows[0][7].ToString();
                    this.txtTinhTrangTLK.Text = table.Rows[0][9].ToString();
                    this.txtSoDanhBo.Text = Utilities.FormatSoHoSoDanhBo.sodanhbo(table.Rows[0][8].ToString());
                }
            }
        }

        private void txtSoDanhBo_Leave(object sender, EventArgs e)
        {
            add();
            this.txtSHS.Focus();
        }

        private void btLuuHoSo_Click(object sender, EventArgs e)
        {
            add();
            this.txtSHS.Focus();
        }

        private void btThemMoiHoSo_Click(object sender, EventArgs e)
        {
            refesh();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            ReportDocument rp = new rpt_DanhSachHSTC_BT();
            rp.SetDataSource(DAL.C_KH_DotThiCong.BC_DanhSachDotThiCong_BT(_madot));
            rpt_Main mainReport = new rpt_Main(rp);
            mainReport.ShowDialog();
        }
    }
}
