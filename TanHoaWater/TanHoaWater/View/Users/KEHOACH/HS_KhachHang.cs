using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;
using System.Collections;
using log4net;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.KEHOACH.Report;
using TanHoaWater.View.Users.KEHOACH;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using TanHoaWater.View.Users.KEHOACH.ThuMoiDongTien;
using TanHoaWater.View.Users.Report;

namespace TanHoaWater.View.Users.HSKHACHHANG
{
    public partial class HSKHACHHANG : UserControl
    {
        int currentPageIndex = 1;
        int pageSize = 11;
        int pageNumber = 0;
        int FirstRow, LastRow;
        int rows;
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        private static readonly ILog log = LogManager.GetLogger(typeof(HSKHACHHANG).Name);
        public HSKHACHHANG(int tab)
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            if (tab == 2)
            {
                tabControl1.SelectedTabIndex = 1;
                this.resultChuyen.Visible = false;
                this.resultDGChuyen.Visible = false;
                this.resultPrint.Visible = false;
                this.CD_NguoiDuyetDon.Visible = false;
                this.nguoiduyetDon.Visible = false;
                #region Load Bo Phan Chuyen
                this.bophanChuyen.DataSource = DAL.C_PhongBan.getList();
                this.bophanChuyen.DisplayMember = "TENPHONG";
                this.bophanChuyen.ValueMember = "MAPHONG";
                #endregion
                load_cd_Grid();

            }
            else if (tab == 3)
            {
                tabControl1.SelectedTabIndex = 2;
                this.panel4.Controls.Clear();
                this.panel4.Controls.Add(new tab_DonTroNgai());
            }
            else if (tab == 4)
            {
                tabControl1.SelectedTabIndex = 3;
                this.panel5.Controls.Clear();
                this.panel5.Controls.Add(new tab_DonTaiXet());
            }
            else if (tab == 5)
            {
                this.panel2.Controls.Clear();
                this.panel2.Controls.Add(new tab_TimKiemDonKH());
                tabControl1.SelectedTabIndex = 4;
            }
            else if (tab == 6)
            {
                #region Bao cao Quan
                this.BC_QUAN.DataSource = DAL.C_Quan.getList();
                this.BC_QUAN.DisplayMember = "TENQUAN";
                this.BC_QUAN.ValueMember = "MAQUAN";
                #endregion
                #region Loai Dot Nhan Don
                this.BC_DOTNHANDON.DataSource = DAL.C_DotNhanDon.getListtMa_Dot();
                this.BC_DOTNHANDON.DisplayMember = "TEND";
                this.BC_DOTNHANDON.ValueMember = "MADOT";
                #endregion
                #region Load User
                this.BC_NGUOIDUYET.DataSource = DAL.C_USERS.getUserByMaPhongAndLevel("VTTH", 0);
                this.BC_NGUOIDUYET.DisplayMember = "FULLNAME";
                this.BC_NGUOIDUYET.ValueMember = "USERNAME";
                #endregion
                tabControl1.SelectedTabIndex = 5;
            }
            else
            {

                formLoad();
                refresh();
                this.txtSHS.Focus();
            }
            
        }

        private void txtghichukhan_MouseClick(object sender, MouseEventArgs e)
        {
            this.ghichukhan.Text = null;

        }
        public void formLoad()
        {
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
            #region Loai Dot Khach Hang
            this.cbDotNhanDon.DataSource = DAL.C_DotNhanDon.getListtMa_Dot_NoChuyen();
            this.cbDotNhanDon.DisplayMember = "TEND";
            this.cbDotNhanDon.ValueMember = "MADOT";
            #endregion

            try
            {
                rows = DAL.C_DonKhachHang.TotalListByDot(this.cbDotNhanDon.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            PageTotal();
            Utilities.DataGridV.formatRows(dataG);
        }
        int _maquan = 0;
        string _maphuong = "";
        private void PageTotal()
        {
            try
            {
                pageNumber = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                lbPaing.Text = currentPageIndex + "/" + pageNumber;
            }
            catch (Exception ex)
            {
                log.Error(ex); ;
            }

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
        DateTime ngaynhan = DateTime.Now;
        string loaihoso = "";
        private void txtSHS_KeyPress(object sender, KeyPressEventArgs e)
        {
            flag = true;
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
                    loaihoso = biennhan.LOAIDON;
                    this.soho.Value = int.Parse(biennhan.SOHO + ""); ;
                    this.dienthoai.Text = biennhan.DIENTHOAI;
                    this.cbQuan.Text = recordQuan.TENQUAN;
                    this.cbPhuong.Text = recordPhuong.TENPHUONG;
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

        private void txtSHS_Leave(object sender, EventArgs e)
        {
            //BIENNHANDON biennhan = DAL.C_BienNhanDon.finbyMaBienNhan(this.txtSHS.Text);

            //if (biennhan != null)
            //{
            //    _maquan = biennhan.QUAN;
            //    _maphuong = biennhan.PHUONG;
            //    QUAN recordQuan = DAL.C_Quan.finByMaQuan(biennhan.QUAN);
            //    PHUONG recordPhuong = DAL.C_Phuong.finbyPhuong(recordQuan.MAQUAN, biennhan.PHUONG);
            //    string sohoso = "";
            //    if (DateTime.Now.Month < 10)
            //    {
            //        sohoso = "0" + DateTime.Now.Month.ToString();
            //    }
            //    else
            //    {
            //        sohoso = DateTime.Now.Month.ToString();
            //    }
            //    this.txtSHS.Text = this.txtSHS.Text.ToUpper();
            //    this.txtSoHoSo.Text = recordQuan.MAQUAN + "" + recordPhuong.MAPHUONG + sohoso + this.txtSHS.Text;
            //    this.txtHoTen.Text = biennhan.HOTEN;
            //    this.dienthoai.Text = biennhan.DIENTHOAI;
            //    this.sonha.Text = biennhan.SONHA;
            //    this.duong.Text = biennhan.DUONG;
            //    this.cbQuan.Text = recordQuan.TENQUAN;
            //    this.cbPhuong.Text = recordPhuong.TENPHUONG;
            //}
            //else {
            //    MessageBox.Show(this, "Không Tìm Thấy Số Biên Nhận Khách Hàng !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.txtSHS.Clear();
            //    this.txtSHS.Focus();
            //}
            _soshoso();
            flag = true;
        }

        private void cbDotNhanDon_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                loadDataGrid();


            }
            catch (Exception)
            {

            }
        }
        bool flag = true;
        public void add()
        {
            flag = false;
            if (this.cbDotNhanDon.SelectedValue == null)
            {
                MessageBox.Show(this, "Cần Chọn Đợt Nhận Đơn.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cbDotNhanDon.Focus();
            }//else if (this.txtSHS.Text.Length < 7)
            //{
            //    MessageBox.Show(this, "Số Hồ Sơ Không Hợp Lệ.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.txtSHS.Focus();
            //}
            else if ("".Equals(this.txtHoTen.Text))
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
                if (DAL.C_DonKhachHang.findByAddressAndLoaiHS_(this.cbDotNhanDon.SelectedValue.ToString(), loaihoso, this.sonha.Text, this.duong.Text, _maphuong, "" + _maquan))
                {
                    if (MessageBox.Show(this, "Địa Chỉ Khách Hàng Đã Được Nhận Đơn. Có Muốn Thêm Mới Hồ Sơ ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        DON_KHACHHANG donKH = new DON_KHACHHANG();
                        donKH.MADOT = this.cbDotNhanDon.SelectedValue.ToString();
                        donKH.SOHOSO = this.txtSoHoSo.Text.ToUpper();
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
                        donKH.LOAIHOSO = DAL.C_DotNhanDon.findByMaDot(this.cbDotNhanDon.SelectedValue.ToString()).LOAIDON;
                        donKH.GHICHU = this.ghichu.Text;
                        if (this.khan.Checked == true)
                        {
                            donKH.HOSOKHAN = true;
                            donKH.GHICHUKHAN = this.ghichukhan.Text;
                        }
                        donKH.NGAYNHAN = ngaynhan;
                        donKH.DANHBO = this.txtDanhBo.Text;
                        donKH.HOPDONG = this.txtHopDong.Text;
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
                            loadDataGrid();
                            Utilities.DataGridV.formatRows(dataG);
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
                    donKH.MADOT = this.cbDotNhanDon.SelectedValue.ToString();
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
                    donKH.LOAIHOSO = DAL.C_DotNhanDon.findByMaDot(this.cbDotNhanDon.SelectedValue.ToString()).LOAIDON;
                    donKH.GHICHU = this.ghichu.Text;
                    if (this.khan.Checked == true)
                    {
                        donKH.HOSOKHAN = true;
                        donKH.GHICHUKHAN = this.ghichukhan.Text;
                    }
                    donKH.NGAYNHAN = ngaynhan;
                    donKH.DANHBO = this.txtDanhBo.Text;
                    donKH.HOPDONG = this.txtHopDong.Text;
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
                        loadDataGrid();
                        Utilities.DataGridV.formatRows(dataG);
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
        private void btInsert_Click(object sender, EventArgs e)
        {
            add();

        }

        private void khan_CheckedChanged(object sender, EventArgs e)
        {
            if (this.khan.Checked == true)
            {
                this.ghichukhan.Visible = true;
            }
            else
            {
                this.ghichukhan.Visible = false;
            }
        }
        public void refresh()
        {
            this.txtSHS.Text = null;

            this.txtHoTen.Text = null;
            this.dienthoai.Text = null;
            this.sonha.Text = null;
          //  this.duong.Text = null;
            this.txtSoHoSo.Text = null;
            this.txtSHS.Focus();
            this.soho.Value = 1;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void tabItem2_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(new tab_TimKiemDonKH());
        }

        public void loadDataGrid()
        {
            string _madot = this.cbDotNhanDon.SelectedValue.ToString();

            try
            {
                rows = DAL.C_DonKhachHang.TotalListByDot(this.cbDotNhanDon.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            PageTotal();
            int sokh = DAL.C_DonKhachHang.TotalListByDot(_madot);
            this.dataG.DataSource = DAL.C_DonKhachHang.getListbyDot(_madot, FirstRow, pageSize);
            this.totalRecord.Text = "Tống công có " + sokh + " khách hàng đợt nhận đơn " + _madot;
            Utilities.DataGridV.formatRows(dataG);
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (currentPageIndex < pageNumber)
            {
                currentPageIndex = currentPageIndex + 1;
                FirstRow = pageSize * (currentPageIndex - 1);
                LastRow = pageSize * (currentPageIndex);
                PageTotal();
                loadDataGrid();
            }

        }

        private void pre(object sender, EventArgs e)
        {
            try
            {
                if (currentPageIndex > 1)
                {
                    currentPageIndex = currentPageIndex - 1;
                    FirstRow = pageSize * (currentPageIndex - 1);
                    LastRow = pageSize * (currentPageIndex);
                    PageTotal();
                    loadDataGrid();
                }
            }
            catch (Exception)
            {

            }

        }

        private void tabItem1_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            formLoad();
            refresh();
            this.txtSHS.Focus();
        }

        private void tab_BaoCao_Click(object sender, EventArgs e)
        {
            #region Bao cao Quan
            this.BC_QUAN.DataSource = DAL.C_Quan.getList();
            this.BC_QUAN.DisplayMember = "TENQUAN";
            this.BC_QUAN.ValueMember = "MAQUAN";
            #endregion
            #region Loai Dot Nhan Don
            this.BC_DOTNHANDON.DataSource = DAL.C_DotNhanDon.getListtMa_Dot();
            this.BC_DOTNHANDON.DisplayMember = "TEND";
            this.BC_DOTNHANDON.ValueMember = "MADOT";
            #endregion
            #region Load User
            this.BC_NGUOIDUYET.DataSource = DAL.C_USERS.getUserByMaPhongAndLevel("VTTH", 0);
            this.BC_NGUOIDUYET.DisplayMember = "FULLNAME";
            this.BC_NGUOIDUYET.ValueMember = "USERNAME";
            #endregion
        }

        private void BC_LOAIBC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.BC_LOAIBC.SelectedIndex == 0)
            {
                this.BC_QUAN.Enabled = false;
                this.BC_DOTNHANDON.Enabled = true;
            }
            if (this.BC_LOAIBC.SelectedIndex == 1)
            {
                this.BC_QUAN.Enabled = true;
                this.BC_DOTNHANDON.Enabled = true;
            }
            if (this.BC_LOAIBC.SelectedIndex == 2)
            {
                this.BC_QUAN.Enabled = false;
                this.BC_DOTNHANDON.Enabled = true;
            }
            if (this.BC_LOAIBC.SelectedIndex == 3)
            {
                this.BC_QUAN.Enabled = true;
                this.BC_DOTNHANDON.Enabled = true;
            }

        }

        private void BC_XEM_Click(object sender, EventArgs e)
        {
            if (this.BC_LOAIBC.SelectedIndex == 0)
            {
                ReportDocument rp = new rpt_DOT();
                rp.SetDataSource(DAL.C_BAOCAO_VIEW.BC_DOTNHANDON_DOT(this.BC_DOTNHANDON.SelectedValue.ToString(), DAL.C_USERS._userName, this.BC_NGUOIDUYET.SelectedValue.ToString(), null, null));
                report.ReportSource = rp;
            }
            if (this.BC_LOAIBC.SelectedIndex == 1)
            {
                ReportDocument rp = new rpt_DOT_QUAN();
                rp.SetDataSource(DAL.C_BAOCAO_VIEW.BC_DOTNHANDON_DOT(this.BC_DOTNHANDON.SelectedValue.ToString(), DAL.C_USERS._userName, this.BC_NGUOIDUYET.SelectedValue.ToString(), this.BC_QUAN.SelectedValue.ToString(), null));
                report.ReportSource = rp;
            }
            if (this.BC_LOAIBC.SelectedIndex == 2)
            {
                ReportDocument rp = new rpt_TroNgai();
                rp.SetDataSource(DAL.C_BAOCAO_VIEW.BC_DOTNHANDON_DOT(this.BC_DOTNHANDON.SelectedValue.ToString(), DAL.C_USERS._userName, this.BC_NGUOIDUYET.SelectedValue.ToString(), null, "True"));
                report.ReportSource = rp;
            }
            if (this.BC_LOAIBC.SelectedIndex == 3)
            {
                ReportDocument rp = new rpt_TroNgaiQuan();
                rp.SetDataSource(DAL.C_BAOCAO_VIEW.BC_DOTNHANDON_DOT(this.BC_DOTNHANDON.SelectedValue.ToString(), DAL.C_USERS._userName, this.BC_NGUOIDUYET.SelectedValue.ToString(), this.BC_QUAN.SelectedValue.ToString(), "True"));
                report.ReportSource = rp;
            }
        }
        private void tabChuyenDon_Click(object sender, EventArgs e)
        {
            this.resultChuyen.Visible = false;
            this.resultDGChuyen.Visible = false;
            this.resultPrint.Visible = false;
            this.CD_NguoiDuyetDon.Visible = false;
            this.nguoiduyetDon.Visible = false;
            this.cd_detail.Visible = true;
            #region Load Bo Phan Chuyen
            this.bophanChuyen.DataSource = DAL.C_PhongBan.getList();
            this.bophanChuyen.DisplayMember = "TENPHONG";
            this.bophanChuyen.ValueMember = "MAPHONG";
            #endregion
            // customize dataviewgrid, add checkbox column
            //if (flag == 0)
            //{
            //    DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
            //    checkboxColumn.Width = 30;
            //    checkboxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    cd_MainGird.Columns.Insert(3, checkboxColumn);

            //    // add checkbox header
            //    Rectangle rect = cd_MainGird.GetCellDisplayRectangle(3, -1, true);
            //    // set checkbox header to center of header cell. +1 pixel to position correctly.
            //    rect.X = rect.Location.X + (rect.Width / 4);

            //    CheckBox checkboxHeader = new CheckBox();
            //    checkboxHeader.Name = "checkboxHeader";
            //    checkboxHeader.Size = new Size(17, 17);
            //    checkboxHeader.Location = rect.Location;
            //    checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);
            //  //  cd_MainGird.Controls.Add(checkboxHeader);
            //}

            load_cd_Grid();
            Utilities.DataGridV.formatRows(cd_MainGird);
        }
        public void load_cd_Grid()
        {
            cd_MainGird.DataSource = DAL.C_DotNhanDon.getListChuaChuyen();
        }
        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < cd_MainGird.RowCount; i++)
            {
                cd_MainGird[0, i].Value = ((CheckBox)cd_MainGird.Controls.Find("checkboxHeader", true)[0]).Checked;
            }
            cd_MainGird.EndEdit();
        }
        string _madot = null;
        private void cd_MainGird_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _madot = cd_MainGird.Rows[e.RowIndex].Cells[0].Value != null ? cd_MainGird.Rows[e.RowIndex].Cells[0].Value.ToString() : null;
                loadDetail(_madot);
                this.lbSoKHNhanDon.Text = "Có " + sokh + " khách hàng đợt nhận đơn " + _madot;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        private void chuyenDot_Click(object sender, EventArgs e)
        {
            try
            {
                if (cd_detail.Rows.Count <= 0)
                {
                    MessageBox.Show(this, "Không Có Hồ Sơ Nào Để Chuyển.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DateTime ngaynhan = DateTime.Now;
                    #region  Update DOT NHAN DON
                    //for (int i = 0; i < cd_MainGird.RowCount; i++)
                    //{
                    //    //if (cd_MainGird[0, i].Value != null && "True".Equals(cd_MainGird[0, i].Value.ToString()))
                    //    //{
                    //     //   _madot=cd_MainGird.Rows[i].Cells[0].Value.ToString();
                    //        //string _user = DAL.C_USERS._userName;
                    //        //string _bpchuyen= this.bophanChuyen.SelectedValue.ToString();
                    //        //DAL.C_DotNhanDon.chuyendon(_madot,_user,_bpchuyen);
                    //        //DAL.C_DonKhachHang.chuyenhsbydot(_madot, _user, _bpchuyen);
                    //    //}
                    //}
                    string _user = DAL.C_USERS._userName;
                    string _bpchuyen = this.bophanChuyen.SelectedValue.ToString();
                    DAL.C_DotNhanDon.chuyendon(_madot, _user, _bpchuyen);
                    DAL.C_DonKhachHang.chuyenhsbydot(_madot, _user, _bpchuyen);
                    #endregion

                    MessageBox.Show(this, "Chuyển Đợt Nhận Đơn Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_cd_Grid();
                    #region Add Chuyen TTK
                    if (_madot != null)
                    {
                        for (int j = 0; j < cd_detail.Rows.Count; j++)
                        {
                            if (cd_detail.Rows[j].Cells[0].Value != null)
                            {
                                string sohskh = cd_detail.Rows[j].Cells[0].Value.ToString();
                                string shs = sohskh.Substring(6);
                                TOTHIETKE ttk = new TOTHIETKE();
                                ttk.MADOT = _madot;
                                ttk.SOHOSO = sohskh;
                                ttk.SHS = shs;
                                ttk.NGAYNHAN = ngaynhan;
                                DAL.C_ToThietKe.addNew(ttk);
                            }
                        }
                    }
                    #endregion
                    int count = DAL.C_ToThietKe.DanhSachChuyen(_madot).Rows.Count;
                    if (count > 0)
                    {
                        this.resultChuyen.Text = "Đã Chuyển " + count + " Hồ Sơ Lên " + this.bophanChuyen.Text;
                        this.resultDGChuyen.DataSource = DAL.C_ToThietKe.DanhSachChuyen(_madot);

                        #region Nguoi Duyet Don
                        this.CD_NguoiDuyetDon.DataSource = DAL.C_USERS.getUserByMaPhongAndLevel("VTTH", 0);
                        this.CD_NguoiDuyetDon.DisplayMember = "FULLNAME";
                        this.CD_NguoiDuyetDon.ValueMember = "USERNAME";
                        #endregion
                        this.CD_NguoiDuyetDon.Visible = true;
                        this.nguoiduyetDon.Visible = true;
                        this.resultChuyen.Visible = true;
                        this.resultDGChuyen.Visible = true;
                        this.resultPrint.Visible = true;
                        Utilities.DataGridV.formatRows(resultDGChuyen);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Chuyen TTT Loi " + ex.Message);
                MessageBox.Show(this, "Chuyển Đợt Nhận Đơn Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        int sokh = 0;
        public void loadDetail(string madot)
        {

            this.cd_detail.DataSource = DAL.C_DonKhachHang.getListbyDot(madot);
            sokh = DAL.C_DonKhachHang.getListbyDot(madot).Rows.Count;

            Utilities.DataGridV.formatRows(cd_detail);
        }



        private void resultPrint_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = false;
                if ("TCTB".Equals(this.bophanChuyen.SelectedValue.ToString())) {
                    flag = true;
                }
                rpt_DanhSachChuyen ds = new rpt_DanhSachChuyen(_madot, DAL.C_USERS._userName, CD_NguoiDuyetDon.SelectedValue.ToString(), flag);
                ds.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Error("Lỗi Khi In" + ex.Message);
                MessageBox.Show(this, "Lỗi Khi In.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void soho_ValueChanged(object sender, EventArgs e)
        {
            //if (soho.Value > 1)
            //{
            //    txtDanhBo.Text = "(ĐD " + soho.Value + " Hộ)";
            //    cbLoaiKH.Text = "Tập Thể";
            //}
            //else {
            //    txtDanhBo.Text = null;
            //    cbLoaiKH.Text = "Cá Nhân";
            //}

        }

        private void tabItem3_Click(object sender, EventArgs e)
        {
            this.panel4.Controls.Clear();
            this.panel4.Controls.Add(new tab_DonTroNgai());
        }

        private void cd_MainGird_Sorted(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(cd_MainGird);
        }

        private void tabItem4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTabIndex = 3;
            this.panel5.Controls.Clear();
            this.panel5.Controls.Add(new tab_DonTaiXet());
        }

        private void dataG_Sorted(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataG);
        }

        private void ghichu_Leave(object sender, EventArgs e)
        {
            if (flag)
            {
                add();
            }
        }

        private void ghichu_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //{
            //    add();
            //}
        }

        private void txtDanhBo_Leave(object sender, EventArgs e)
        {
            this.txtDanhBo.Text = Utilities.FormatSoHoSoDanhBo.sodanhbo(this.txtDanhBo.Text);
        }

        private void txtSHS_CursorChanged(object sender, EventArgs e)
        {
            add();
        }

        private void tab_xemlog_Click(object sender, EventArgs e)
        {
            this.tabControlPanel7.Controls.Clear();
            this.tabControlPanel7.Controls.Add(new tab_LogDonKH());
        }

        private void textBoxX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                DataTable table = DAL.C_KH_DotThiCong.findByHSHT(this.textBoxX1.Text);
                if (table.Rows.Count <= 0)
                {
                    MessageBox.Show(this, "Không Tìm Thấy Hồ Sơ Hoàn Tất Thiết Kế !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
                else
                {

                    this.txtHoTenKH.Text = table.Rows[0][2].ToString();
                    this.txtDiaChi.Text = table.Rows[0][3].ToString();
                    this.txtPhuong.Text = table.Rows[0][4].ToString();
                    this.txtQuan.Text = table.Rows[0][5].ToString();
                    this.dateNgayDongTien.ValueObject = table.Rows[0][6];
                    this.txtSoHoaDon.Text = table.Rows[0][7].ToString();
                    this.textBoxX2DB.Text = table.Rows[0]["DANHBO"].ToString();
                    BG_KHOILUONGXDCB xdcb = DAL.C_KhoiLuongXDCB.findBySHS(table.Rows[0][0].ToString());
                    if (xdcb != null)
                    {
                        txtSoTien.Text = String.Format("{0:0,0.00}", xdcb.TONGIATRI != null ? xdcb.TONGIATRI : 0.0).Replace(",",".");
                    }

                }
            }
        }

        private void btLuuHoSo_Click(object sender, EventArgs e)
        {
            if (!"".Equals(this.txtSoHoaDon.Text) && !"1/1/0001".Equals(this.dateNgayDongTien.Value.ToShortDateString()))
            {
                try
                {
                    DAL.C_DonKhachHang.DongTienKH_(this.textBoxX1.Text, this.dateNgayDongTien.Value.Date, this.txtSoHoaDon.Text);
                    MessageBox.Show(this, "Cập Nhật Khách Hàng Đóng Tiền Thành Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    log.Error("Khach Hang Dong Tien Loi." + ex.Message);
                    MessageBox.Show(this, "Cập Nhật Khách Hàng Đóng Tiền Lỗi .", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show(this, "Cần Nhập Số Hóa Đơn Và Ngày Đóng Tiền", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoHoaDon.Focus();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable("THUMOI");
            table.Columns.Add("TITLE", typeof(string));
            table.Columns.Add("HOTEN", typeof(string));
            table.Columns.Add("DIACHI", typeof(string));
            table.Columns.Add("TUNGAY", typeof(string));
            table.Columns.Add("DENNGAY", typeof(string));
            table.Columns.Add("SOTIEN", typeof(string));
            table.Columns.Add("DANHBO", typeof(string));


            DataSet ds = new DataSet();

            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();

            string sql = " SELECT * FROM KH_TC_BAOCAO ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            adapter.Fill(ds, "KH_TC_BAOCAO");

            if (comboBox1.SelectedIndex == 0)
            {
                DataRow myDataRow = table.NewRow();
                myDataRow["TITLE"] = "THƠ MỜI THANH TOÁN CHI PHÍ LẮP ĐẶT ỐNG CẤP NƯỚC";
                myDataRow["HOTEN"] = txtHoTenKH.Text;
                myDataRow["DIACHI"] = txtDiaChi.Text + ", Phường " + this.txtPhuong.Text + ", Quận " + this.txtQuan.Text;
                myDataRow["TUNGAY"] = dateTuNgay.Text;
                myDataRow["DENNGAY"] = dateDenNgay.Text;
                myDataRow["SOTIEN"] = txtSoTien.Text;
                myDataRow["DANHBO"] = textBoxX2DB.Text;

                table.Rows.Add(myDataRow);
                ds.Tables.Add(table);


                ReportDocument rp = new lapdatongcapnuoc();
               
                rp.SetDataSource(ds);
                rpt_InBienNhan inp = new rpt_InBienNhan(rp);
                inp.ShowDialog();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                ReportDocument rp = new ganthayongnganhdhn();

                DataRow myDataRow = table.NewRow();
                myDataRow["TITLE"] = "THƠ MỜI THANH TOÁN CHI PHÍ DỜI ĐỒNG HỒ NƯỚC";
                myDataRow["HOTEN"] = txtHoTenKH.Text;
                myDataRow["DIACHI"] = txtDiaChi.Text + ", Phường " + this.txtPhuong.Text + ", Quận " + this.txtQuan.Text;
                myDataRow["TUNGAY"] = dateTuNgay.Text;
                myDataRow["DENNGAY"] = dateDenNgay.Text;
                myDataRow["SOTIEN"] = txtSoTien.Text;
                myDataRow["DANHBO"] = textBoxX2DB.Text;

                table.Rows.Add(myDataRow);
                ds.Tables.Add(table);

                rp.SetDataSource(ds);
                rp.SetParameterValue("title", " dời đồng hồ nước ");
                rpt_InBienNhan inp = new rpt_InBienNhan(rp);
                inp.ShowDialog();

            }
            else
            {
                ReportDocument rp = new ganthayongnganhdhn();
                rp.PrintOptions.PaperSize = PaperSize.Paper11x17;
                DataRow myDataRow = table.NewRow();
                myDataRow["TITLE"] = "THƠ MỜI THANH TOÁN CHI PHÍ GẮN ỐNG NGÁNH ĐHN + ĐHN";
                myDataRow["HOTEN"] = txtHoTenKH.Text;
                myDataRow["DIACHI"] = txtDiaChi.Text + ", Phường " + this.txtPhuong.Text + ", Quận " + this.txtQuan.Text;
                myDataRow["TUNGAY"] = dateTuNgay.Text;
                myDataRow["DENNGAY"] = dateDenNgay.Text;
                myDataRow["SOTIEN"] = txtSoTien.Text;
                myDataRow["DANHBO"] = textBoxX2DB.Text;
                table.Rows.Add(myDataRow);
                ds.Tables.Add(table);
                rp.SetDataSource(ds);
                rp.SetParameterValue("title", " gắn ống ngánh ĐHN");
                rpt_InBienNhan inp = new rpt_InBienNhan(rp);
                inp.ShowDialog();

            }


        }

        private void HSKHACHHANG_Load(object sender, EventArgs e)
        {
            try
            {
                List<TENDUONG> list = DAL.C_TenDuong.getList();
                foreach (var item in list)
                {
                    namesCollection.Add(item.DUONG);
                }
                duong.AutoCompleteMode = AutoCompleteMode.Suggest;
                duong.AutoCompleteSource = AutoCompleteSource.CustomSource;
                duong.AutoCompleteCustomSource = namesCollection;
            }
            catch (Exception)
            {

            }
        }

        private void print_Click(object sender, EventArgs e)
        {
            string _madot_ = this.cbDotNhanDon.SelectedValue.ToString();
            ReportDocument rp = new rpt_DOT_QUAN();
            rp.SetDataSource(DAL.C_BAOCAO_VIEW.BC_DOTNHANDON_DOT(_madot_, DAL.C_USERS._userName, DAL.C_USERS.KHVTDuyet(), null, null));
            DOT_NHAN_DON dotnd = DAL.C_DotNhanDon.findByMaDot(_madot_);
            rp.SetParameterValue("ngaylapdot", " ngày " + dotnd.NGAYLAPDON.Date.Day + " tháng " + dotnd.NGAYLAPDON.Date.Month + " năm " + dotnd.NGAYLAPDON.Date.Year);
            
            rpt_Main main = new rpt_Main(rp);
            main.ShowDialog();
        }
    }
}