using System;
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
using System.Threading;

namespace TanHoaWater.View.Users.KEHOACH.DOTTHICONG
{
    public partial class tab_CapNhatDanhSachbyDot : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_CapNhatDanhSachbyDot).Name);
        string _madot="";
        public tab_CapNhatDanhSachbyDot(string madot)
        {
            InitializeComponent();
            
            lbDotTc.Text = "ĐỢT THI CÔNG : " + madot.ToUpper();
            _madot = madot;
            //loadDataGrid();
        }

        public void add(string shs)
        {
            try
            {
                if ("".Equals(shs))
                {
                    MessageBox.Show(this, "Số Hồ Sơ Không Được Trống", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtSoBangKe.Focus();
                }
                else
                {
                    KH_HOSOKHACHHANG kh_sh = DAL.C_KH_HoSoKhachHang.findBySHS(shs);
                    DON_KHACHHANG donkh = DAL.C_DonKhachHang.findBySOHOSO(shs);
                    BG_KHOILUONGXDCB xdcb = DAL.C_KhoiLuongXDCB.findBySHS(shs);
                    if (kh_sh == null)
                    {
                        kh_sh = new KH_HOSOKHACHHANG();
                        kh_sh.SHS = shs;
                        kh_sh.MADOTTC = _madot;
                        kh_sh.COTLK = 15;
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
                        kh_sh.MODIFYDATE = DateTime.Now;
                        kh_sh.CREATEBY = DAL.C_USERS._userName;
                        kh_sh.CREATEDATE = DateTime.Now.Date;
                        if (DAL.C_KH_HoSoKhachHang.Insert(kh_sh) == false)
                        {// co roi do len dot thi cong truoc
                            MessageBox.Show(this, "Thêm Hồ Sơ Xin Phép Bị lỗi !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.txtSoBangKe.Focus();
                        }

                    }
                    else
                    {
                        if (kh_sh.MADOTTC != null || !"".Equals(kh_sh.MADOTTC+""))
                        {
                            if (MessageBox.Show(this, "Đã Lên Đơt Thi Công Cho Số Hồ Sơ Rồi.", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                kh_sh.MADOTTC = _madot;
                                kh_sh.COTLK = 15;
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
                            }
                        }
                        else {
                            kh_sh.MADOTTC = _madot;
                            kh_sh.COTLK = 15;
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
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error("add ho so kh -> ke hoach khLoi" + ex.Message);
            }

        }
     public void loadDataGrid()
     {
         if (!"".Equals(this.txtSoBangKe.Text))
         {
             dataGridViewDotTC.DataSource = DAL.C_KH_DotThiCong.getListHSbyBangKe(this.txtSoBangKe.Text);
             Utilities.DataGridV.formatSoHoSo(dataGridViewDotTC);
             lbTongHoSo.Text = "Tổng Số Có " + dataGridViewDotTC.Rows.Count + " Hồ Sơ";
         }
     }

     private void txtSHS_KeyPress(object sender, KeyPressEventArgs e)
     {
         if (e.KeyChar == 13)
         {
             loadDataGrid();
         }
     }

     private void dataGridViewDotTC_CellClick(object sender, DataGridViewCellEventArgs e)
     {
         try
         {
             string s_thaotat = dataGridViewDotTC.Rows[dataGridViewDotTC.CurrentRow.Index].Cells["thaotac"].Value + "";
             if (dataGridViewDotTC.CurrentCell.OwningColumn.Name == "thaotac")
             {
                 string _shs = dataGridViewDotTC.Rows[dataGridViewDotTC.CurrentRow.Index].Cells["SHS"].Value + "";
                 try
                 {
                     if ("Thêm".Contains(s_thaotat))
                     {
                         add(_shs);
                         dataGridViewDotTC.Rows[dataGridViewDotTC.CurrentRow.Index].Cells["thaotac"].Value = "Hủy";
                     }
                     else {
                        
                             if (MessageBox.Show(this, "Có Muốn Hủy Hồ Sơ " + _shs + " Không ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                             {
                                 DAL.C_KH_HoSoKhachHang.HuyDotTC(_shs);
                                  
                             }
                             dataGridViewDotTC.Rows[dataGridViewDotTC.CurrentRow.Index].Cells["thaotac"].Value = "Thêm";
                     
                     }

                 }
                 catch (Exception ex)
                 {
                     log.Error("Them Dot THi Cong Loi " + ex.Message);   
                 }
                 //if (MessageBox.Show(this, "Có Muốn Hủy Hồ Sơ " + _shs + " Không ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 //{
                 //    DAL.C_KH_HoSoKhachHang.HuyDotTC(_shs);
                 //    loadDataGrid();
                 //}
             }
         }
         catch (Exception)
         {

         }
     }
        //private void txtSHS_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 13)
        //    {
        //        DataTable table = DAL.C_KH_DotThiCong.findByHSHT(this.txtSHS.Text);
        //        if (table.Rows.Count <= 0)
        //        {
        //            MessageBox.Show(this, "Không Tìm Thấy Hồ Sơ Hoàn Tất Thiết Kế !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    

        //        }
        //        else
        //        {
        //            this.txtSHS.Text = table.Rows[0][0].ToString();
        //            this.txtHoTenKH.Text = table.Rows[0][2].ToString();
        //            this.txtDiaChi.Text = table.Rows[0][3].ToString();
        //            this.txtPhuong.Text = table.Rows[0][4].ToString();
        //            this.txtQuan.Text = table.Rows[0][5].ToString();
        //            this.dateNgayDongTien.ValueObject = table.Rows[0][6];
        //            this.txtSoHoaDon.Text = table.Rows[0][7].ToString();
        //        }
        //    }
        //}

        //private void txtSoHoaDon_Leave(object sender, EventArgs e)
        //{
        //    add();
        //    this.txtSHS.Focus();
            
        //}

        //private void btThemMoiHoSo_Click(object sender, EventArgs e)
        //{
        //    refesh();
        //}

        //private void btLuuHoSo_Click(object sender, EventArgs e)
        //{
        //    add();
        //    this.txtSHS.Focus();
        //}
        //private static readonly ILog log = LogManager.GetLogger(typeof(tab_CapNhatDanhSachND).Name);
        //private void btPrint_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string tendot = DAL.C_KH_DotThiCong.findByMadot(_madot).LOAIBANGKE;
        //        if (tendot.Equals("Gắn Mới(NĐ117)"))
        //        {
        //            ReportDocument rp = new rpt_DanhSachHSTC_GM();
        //            rp.SetDataSource(DAL.C_KH_DotThiCong.BC_DanhSachDotThiCong(_madot));
        //            rpt_Main mainReport = new rpt_Main(rp);
        //            mainReport.ShowDialog();
        //        }
        //        else if (tendot.Equals("Ống Cái") || tendot.Equals("Gắn Mới"))
        //        {
        //            ReportDocument rp = new rpt_DanhSachHSTC_OC();
        //            rp.SetDataSource(DAL.C_KH_DotThiCong.BC_DanhSachDotThiCong_OC(_madot));
        //            rpt_Main mainReport = new rpt_Main(rp);
        //            mainReport.ShowDialog();
        //        }
        //        else if (tendot.Equals("Bồi Thường"))
        //        {
        //            ReportDocument rp = new rpt_DanhSachHSTC_BT();
        //            rp.SetDataSource(DAL.C_KH_DotThiCong.BC_DanhSachDotThiCong_BT(_madot));
        //            rpt_Main mainReport = new rpt_Main(rp);
        //            mainReport.ShowDialog();
        //        }
        //        else if (tendot.Equals("Dời-BT"))
        //        {
        //            reportValues rpt = new reportValues(2, _madot);
        //            rpt.ShowDialog();
        //        }
        //        else if (tendot.Equals("Dời"))
        //        {
        //            ReportDocument rp = new rpt_DanhSachHSTC_DOI();
        //            rp.SetDataSource(DAL.C_KH_DotThiCong.BC_DanhSachDotThiCong_OC(_madot));
        //            rpt_Main mainReport = new rpt_Main(rp);
        //            mainReport.ShowDialog();
        //        }
        //        else
        //        {
        //            reportValues rpt = new reportValues(1, _madot);
        //            rpt.ShowDialog();
        //        }  
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("In danh sach dot thi cong " + ex.Message);
        //    }
            
            
        //}

        //private void dataGridViewDotTC_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (dataGridViewDotTC.CurrentCell.OwningColumn.Name == "thaotac")
        //        {
        //            string _shs = dataGridViewDotTC.Rows[dataGridViewDotTC.CurrentRow.Index].Cells["SHS"].Value + "";
        //            if (MessageBox.Show(this, "Có Muốn Hủy Hồ Sơ " + _shs + " Không ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //            {
        //                DAL.C_KH_HoSoKhachHang.HuyDotTC(_shs);
        //                loadDataGrid();
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}
    }
}
