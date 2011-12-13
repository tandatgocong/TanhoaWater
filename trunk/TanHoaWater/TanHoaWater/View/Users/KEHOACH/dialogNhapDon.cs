using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;
using log4net;

namespace TanHoaWater.View.Users.KEHOACH
{
    public partial class dialogNhapDon : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(dialogNhapDon).Name);
        string _dotnhandon = "";
        public dialogNhapDon(string dotnhandon)
        {
            InitializeComponent();
            _dotnhandon = dotnhandon;
            this.txtDotNhanDon.Text = _dotnhandon;
            #region Load Quan
            this.cbQuan.DataSource = DAL.C_Quan.getList();
            this.cbQuan.DisplayMember = "TENQUAN";
            this.cbQuan.ValueMember = "MAQUAN";
            #endregion
            #region Loai HoSo
            this.cbLoaiHS.DataSource = DAL.C_LoaiHoSo.getList();
            this.cbLoaiHS.DisplayMember = "TENLOAI";
            this.cbLoaiHS.ValueMember = "MALOAI";
            #endregion
            #region Loai KhaHang
            this.cbLoaiKH.DataSource = DAL.C_LoaiKhachHang.getList();
            this.cbLoaiKH.DisplayMember = "TENLOAI";
            this.cbLoaiKH.ValueMember = "MALOAI";
            #endregion
        }
        private void cbPhuong_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sohoso = "";
                if (DateTime.Now.Month < 10)
                {
                    sohoso = "0" + DateTime.Now.Month.ToString();
                }
                else
                {
                    sohoso = DateTime.Now.Month.ToString();
                }
                this.txtSoHoSo.Text = this.cbQuan.SelectedValue + "" + this.cbPhuong.SelectedValue + sohoso + this.txtSHS.Text;
                _maphuong = this.cbPhuong.SelectedValue + "";
            }
            catch (Exception)
            {

            }

            _soshoso();
        }
        private void cbQuan_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int maquan = int.Parse(this.cbQuan.SelectedValue.ToString());
                _maquan = maquan;
                this.cbPhuong.DataSource = DAL.C_Phuong.getListByQuan(maquan);
                this.cbPhuong.DisplayMember = "TENPHUONG";
                this.cbPhuong.ValueMember = "MAPHUONG";
                _soshoso();
            }
            catch (Exception)
            {
            }
        }
        public void _soshoso()
        {
            try
            {
                string sohoso = "";
                if (DateTime.Now.Month < 10)
                {
                    sohoso = "0" + DateTime.Now.Month.ToString();
                }
                else
                {
                    sohoso = DateTime.Now.Month.ToString();
                }
                this.txtSoHoSo.Text = this.cbQuan.SelectedValue + "" + this.cbPhuong.SelectedValue + sohoso + this.txtSHS.Text;
            }
            catch (Exception)
            {
            }

        }

        DateTime ngaynhan = DateTime.Now;
        private void txtSHS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BIENNHANDON biennhan = DAL.C_BienNhanDon.finbyMaBienNhan(this.txtSHS.Text);

                if (biennhan != null)
                {
                    QUAN recordQuan = DAL.C_Quan.finByMaQuan(biennhan.QUAN);
                    PHUONG recordPhuong = DAL.C_Phuong.finbyPhuong(recordQuan.MAQUAN, biennhan.PHUONG);
                    string sohoso = "";
                    if (DateTime.Now.Month < 10)
                    {
                        sohoso = "0" + DateTime.Now.Month.ToString();
                    }
                    else
                    {
                        sohoso = DateTime.Now.Month.ToString();
                    }
                    this.txtSHS.Text = this.txtSHS.Text.ToUpper();
                    this.txtSoHoSo.Text = recordQuan.MAQUAN + "" + recordPhuong.MAPHUONG + sohoso + this.txtSHS.Text;
                    this.txtHoTen.Text = biennhan.HOTEN;
                    this.dienthoai.Text = biennhan.DIENTHOAI;
                    this.sonha.Text = biennhan.SONHA;
                    this.duong.Text = biennhan.DUONG;
                    this.soho.Value = int.Parse(biennhan.SOHO + ""); ;
                    this.dienthoai.Text = biennhan.DIENTHOAI;
                    this.cbQuan.Text = recordQuan.TENQUAN;
                    this.cbPhuong.Text = recordPhuong.TENPHUONG;
                    loaihoso = biennhan.LOAIDON;
                    ngaynhan = biennhan.NGAYNHAN.Value;
                }
                else
                {
                    _soshoso();
                    //MessageBox.Show(this, "Không Tìm Thấy Số Biên Nhận Khách Hàng !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //this.txtSHS.Clear();
                    //this.txtSHS.Focus();
                    refresh();

                }
            }
        }
        public void refresh()
        {
            this.txtSHS.Text = null;

            this.txtHoTen.Text = null;
            this.dienthoai.Text = null;
            this.sonha.Text = null;
            this.duong.Text = null;
            this.txtSoHoSo.Text = null;
            this.txtSHS.Focus();
            this.soho.Value = 1;
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            refresh();
        }
        bool flag = true;
        string loaihoso = "";
        int _maquan = 0;
        string _maphuong = "";
        public void add()
        {
            try
            {
                flag = false;
                if ("".Equals(this.txtHoTen.Text))
                {
                    MessageBox.Show(this, "Họ Tên Khách Hàng Không Được Trống.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtHoTen.Focus();
                }
                else if ("".Equals(this.sonha.Text))
                {
                    MessageBox.Show(this, "Số Nhà Không Được Trống.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.sonha.Focus();
                }
                else if ("".Equals(this.duong.Text))
                {
                    MessageBox.Show(this, "Tên Đường Không Được Trống.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.duong.Focus();
                }
                else
                {
                    if (DAL.C_DonKhachHang.findByAddressAndLoaiHS(this.txtDotNhanDon.Text, loaihoso, this.sonha.Text, this.duong.Text, _maphuong, "" + _maquan))
                    {
                        if (MessageBox.Show(this, "Địa Chỉ Khách Hàng Đã Được Nhận Đơn. Có Muốn Thêm Mới Hồ Sơ ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            DON_KHACHHANG donKH = new DON_KHACHHANG();
                            donKH.MADOT = this.txtDotNhanDon.Text;
                            donKH.SOHOSO = this.txtSoHoSo.Text;
                            donKH.SHS = this.txtSHS.Text;
                            if (soho.Value > 1)
                            {
                                donKH.TAPTHE = true;
                                cbLoaiKH.Text = "Tập Thể";
                            }
                            else
                            {
                                donKH.TAPTHE = false;
                                cbLoaiKH.Text = "Cá Nhân";
                            }
                            //else
                            //{
                            //    donKH.HOTEN = this.txtHoTen.Text;
                            //}
                            donKH.HOTEN = this.txtHoTen.Text;
                            donKH.DIENTHOAI = this.dienthoai.Text;
                            donKH.SOHO = int.Parse(this.soho.Value.ToString());
                            donKH.SONHA = this.sonha.Text;
                            donKH.TINHKHOAN = true;
                            if (this.sonha.Text.Contains("/") == true)
                            {
                                donKH.LOAIMIENPHI = "Hẻm";
                            }
                            else
                            {
                                donKH.LOAIMIENPHI = "Mặt tiền";
                            }
                            donKH.DUONG = this.duong.Text;
                            donKH.PHUONG = _maphuong;
                            donKH.QUAN = _maquan;
                            string maloaikh = "";
                            if (this.cbLoaiKH.SelectedValue == null || "".Equals(this.cbLoaiKH.SelectedValue.ToString()) == true)
                            {
                                maloaikh = DAL.C_LoaiKhachHang.finbyTenLoai(this.cbLoaiKH.Text).MALOAI;
                            }
                            else
                            {
                                maloaikh = this.cbLoaiKH.SelectedValue.ToString();
                            }
                            donKH.LOAIKH = maloaikh;
                            donKH.LOAIHOSO = DAL.C_DotNhanDon.findByMaDot(this.txtDotNhanDon.Text).LOAIDON;
                            donKH.GHICHU = this.ghichu.Text;

                            donKH.NGAYNHAN = ngaynhan;
                            donKH.DANHBO = this.txtDanhBo.Text;
                            donKH.CREATEBY = DAL.C_USERS._userName;
                            donKH.CREATEDATE = DateTime.Now;

                            if (DAL.C_DonKhachHang.checkHoSoTonTai(donKH.SHS) != 0)
                            {
                                MessageBox.Show(this, "Số Hồ Sơ Đã Tồn Tại.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.txtSHS.Focus();
                            }
                            else
                            {
                                DAL.C_DonKhachHang.InsertDonHK(donKH);
                                DAL.C_DonKhachHang.chuyenhsbySHS(this.txtSHS.Text, DAL.C_USERS._userName, "VTTH");
                                //chuyenttk
                                try
                                {
                                    TOTHIETKE ttk = new TOTHIETKE();
                                    ttk.MADOT = this.txtDotNhanDon.Text;
                                    ttk.SOHOSO = this.txtSoHoSo.Text;
                                    ttk.SHS = this.txtSHS.Text;
                                    ttk.NGAYNHAN = ngaynhan;
                                    DAL.C_ToThietKe.addNew(ttk);
                                }
                                catch (Exception ex)
                                {
                                    log.Error("Chuyen To TTK LOI" + ex.Message);                                    
                                }

                                MessageBox.Show(this, "Thêm Mới Thành Công .", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                refresh();
                                try
                                {
                                    this.txtSHS.Text = (int.Parse(donKH.SHS) + 1) + "";
                                    this.txtSHS.Focus();
                                }
                                catch (Exception)
                                {

                                }
                            }
                        }
                    }
                    else
                    {

                        DON_KHACHHANG donKH = new DON_KHACHHANG();
                        donKH.MADOT = this.txtDotNhanDon.Text;
                        donKH.SOHOSO = this.txtSoHoSo.Text;
                        donKH.SHS = this.txtSHS.Text;
                        if (soho.Value > 1)
                        {
                            donKH.TAPTHE = true;
                            cbLoaiKH.Text = "Tập Thể";
                        }
                        else
                        {
                            donKH.TAPTHE = false;
                            cbLoaiKH.Text = "Cá Nhân";
                        }
                        //else
                        //{
                        //    donKH.HOTEN = this.txtHoTen.Text;
                        //}
                        donKH.HOTEN = this.txtHoTen.Text;
                        donKH.DIENTHOAI = this.dienthoai.Text;
                        donKH.SOHO = int.Parse(this.soho.Value.ToString());
                        donKH.SONHA = this.sonha.Text;
                        donKH.TINHKHOAN = true;
                        if (this.sonha.Text.Contains("/") == true)
                        {
                            donKH.LOAIMIENPHI = "Hẻm";
                        }
                        else
                        {
                            donKH.LOAIMIENPHI = "Mặt tiền";
                        }
                        donKH.DUONG = this.duong.Text;
                        donKH.PHUONG = _maphuong;
                        donKH.QUAN = _maquan;
                        string maloaikh = "";
                        if (this.cbLoaiKH.SelectedValue == null || "".Equals(this.cbLoaiKH.SelectedValue.ToString()) == true)
                        {
                            maloaikh = DAL.C_LoaiKhachHang.finbyTenLoai(this.cbLoaiKH.Text).MALOAI;
                        }
                        else
                        {
                            maloaikh = this.cbLoaiKH.SelectedValue.ToString();
                        }
                        donKH.LOAIKH = maloaikh;
                        donKH.LOAIHOSO = DAL.C_DotNhanDon.findByMaDot(this.txtDotNhanDon.Text).LOAIDON;
                        donKH.GHICHU = this.ghichu.Text;

                        donKH.NGAYNHAN = ngaynhan;
                        donKH.DANHBO = this.txtDanhBo.Text;
                        donKH.CREATEBY = DAL.C_USERS._userName;
                        donKH.CREATEDATE = DateTime.Now;

                        if (DAL.C_DonKhachHang.checkHoSoTonTai(donKH.SHS) != 0)
                        {
                            MessageBox.Show(this, "Số Hồ Sơ Đã Tồn Tại.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.txtSHS.Focus();
                        }
                        else
                        {
                            DAL.C_DonKhachHang.InsertDonHK(donKH);
                            DAL.C_DonKhachHang.chuyenhsbySHS(this.txtSHS.Text, DAL.C_USERS._userName, "VTTH");
                            try
                            {
                                TOTHIETKE ttk = new TOTHIETKE();
                                ttk.MADOT = this.txtDotNhanDon.Text;
                                ttk.SOHOSO = this.txtSoHoSo.Text;
                                ttk.SHS = this.txtSHS.Text;
                                ttk.NGAYNHAN = ngaynhan;
                                DAL.C_ToThietKe.addNew(ttk);
                            }
                            catch (Exception ex)
                            {
                                log.Error("Chuyen To TTK LOI" + ex.Message);
                            }
                            MessageBox.Show(this, "Thêm Mới Thành Công .", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            refresh();
                            try
                            {
                                this.txtSHS.Text = (int.Parse(donKH.SHS) + 1) + "";
                                this.txtSHS.Focus();
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(" insert loi" + ex.Message);
            }
            
        }
        private void txtSHS_MouseLeave(object sender, EventArgs e)
        {
            _soshoso();
            flag = true;
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            add();
        }

       
    }
}
