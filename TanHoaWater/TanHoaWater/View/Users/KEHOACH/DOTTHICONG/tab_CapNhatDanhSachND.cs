using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;

namespace TanHoaWater.View.Users.KEHOACH.DOTTHICONG
{
    public partial class tab_CapNhatDanhSachND : UserControl
    {
        string _madot;
        public tab_CapNhatDanhSachND(string madot)
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
        public void refesh(){
            this.txtSHS.Text = "";
            this.txtHoTenKH.Text = "";
            this.txtDiaChi.Text = "";
            this.txtPhuong.Text = "";
            this.txtQuan.Text = "";
            this.cbCoTLK.Text = "15";
            this.dateNgayDongTien.ValueObject = null;
            this.txtSoHoaDon.Text = "";
            this.txtSHS.Focus();
        }
        public void DongTien() {
            if (!"".Equals(this.txtSoHoaDon.Text) && !"1/1/0001".Equals(this.dateNgayDongTien.Value.ToShortDateString()))
            {
                DAL.C_DonKhachHang.DongTienKH(this.txtSHS.Text, this.dateNgayDongTien.Value.Date, this.txtSoHoaDon.Text);
            }
        }
       public void add()
        {
            if ("".Equals(this.txtSHS.Text))
            {
                MessageBox.Show(this, "Số Hồ Sơ Không Được Trống", "", MessageBoxButtons.OK, MessageBoxIcon.Error);               
                this.txtSHS.Focus();
            }
            else
            {
                KH_HOSOKHACHHANG kh_sh = DAL.C_KH_HoSoKhachHang.findBySHS(this.txtSHS.Text.Trim());
                BG_KHOILUONGXDCB xdcb = DAL.C_KhoiLuongXDCB.findBySHS(this.txtSHS.Text.Trim());
                if (kh_sh == null)
                {
                    kh_sh = new KH_HOSOKHACHHANG();
                    kh_sh.SHS = this.txtSHS.Text;
                    kh_sh.MADOTTC = _madot;
                    kh_sh.COTLK = int.Parse(this.cbCoTLK.Text);
                    if (xdcb != null) {
                        kh_sh.CPVATTU = xdcb.CPVATTU;
                        kh_sh.CPNHANCONG = xdcb.CPNHANCONG;
                        kh_sh.CPMAYTHICONG = xdcb.CPMAYTHICONG;
                        kh_sh.CPCABA =xdcb.CPCABA;
                        kh_sh.CHIPHITRUCTIEP =xdcb.CHIPHITRUCTIEP;
                        kh_sh.CHIPHICHUNG = xdcb.CHIPHICHUNG;
                        kh_sh.TAILAPMATDUONG = xdcb.TAILAPMATDUONG;
                        kh_sh.TLMDTRUOCTHUE =xdcb.TLMDTRUOCTHUE;
                        kh_sh.CONG1 = xdcb.CONG1;
                        kh_sh.THUE55 =xdcb.THUE55;
                        kh_sh.CONG3 = xdcb.CONG3;
                        kh_sh.THUEGTGT = xdcb.THUEGTGT;
                        kh_sh.TONGIATRI = xdcb.TONGIATRI;
                    }
                    kh_sh.MODIFYDATE = DateTime.Now;
                    kh_sh.CREATEBY = DAL.C_USERS._userName;
                    kh_sh.CREATEDATE = DateTime.Now.Date;
                    if (DAL.C_KH_HoSoKhachHang.Insert(kh_sh) == false)
                    {// co roi do len dot thi cong truoc
                        MessageBox.Show(this, "Thêm Hồ Sơ Xin Phép Bị lỗi !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtSHS.Focus();
                        refesh();
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
                    }
                    //  kh_sh
                    DAL.C_KH_HoSoKhachHang.Update();
                }
            }
      
            loadDataGrid();
        }
     public void loadDataGrid()
     {
         dataGridViewDotTC.DataSource = DAL.C_KH_DotThiCong.getListDotThiCong(_madot);
         Utilities.DataGridV.formatSoHoSo(dataGridViewDotTC);
         lbTongHoSo.Text = "Tổng Số Có " + dataGridViewDotTC.Rows.Count + " Hồ Sơ";
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
                }
            }
        }

        private void txtSoHoaDon_Leave(object sender, EventArgs e)
        {
            add();
            this.txtSHS.Focus();
            
        }

        private void btThemMoiHoSo_Click(object sender, EventArgs e)
        {
            refesh();
        }

        private void btLuuHoSo_Click(object sender, EventArgs e)
        {
            add();
            this.txtSHS.Focus();
        }
    }
}
