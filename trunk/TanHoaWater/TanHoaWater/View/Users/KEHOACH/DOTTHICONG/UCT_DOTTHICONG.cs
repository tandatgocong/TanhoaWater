using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;
using log4net;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.Report;
using TanHoaWater.View.Users.KEHOACH.DOTTHICONG.BC;

namespace TanHoaWater.View.Users.KEHOACH.DOTTHICONG
{
    public partial class UCT_DOTTHICONG : UserControl
    {
        int currentPageIndex = 1;
        int pageSize = 400;
        int pageNumber = 0;
        int FirstRow, LastRow;
        int rows;
        private static readonly ILog log = LogManager.GetLogger(typeof(UCT_DOTTHICONG).Name);
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
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

        public UCT_DOTTHICONG()
        {
            InitializeComponent();
            formload();

            loadDataGrid();
            //List<KH_DOTTHICONG> list = DAL.C_KH_DotThiCong.AutoCompleteDotNhanDon();
            //foreach (var item in list)
            //{
            //    namesCollection.Add(item.MADOTTC);
            //}
            //txtSearchDotTC.AutoCompleteMode = AutoCompleteMode.Suggest;
            //txtSearchDotTC.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //txtSearchDotTC.AutoCompleteCustomSource = namesCollection;

            //List<KH_DOTTHICONG> list = DAL.C_KH_DotThiCong.getListDTC();
            //foreach (var item in list)
            //{
            //    namesCollection.Add(item.MADOTTC);
            //}
            //searchTimKiem.AutoCompleteMode = AutoCompleteMode.Suggest;
            //searchTimKiem.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //searchTimKiem.AutoCompleteCustomSource = namesCollection;

        }

        public void formload()
        {
            cbDonViThiCong.DataSource = DAL.C_KH_DonViTC.getDonViThiCong();
            cbDonViThiCong.DisplayMember = "TENCONGTY";
            cbDonViThiCong.ValueMember = "ID";
            cbDonViThiCong.SelectedIndex = cbDonViThiCong.Items.Count-1;

            cbDonViTaiLapMD.DataSource = DAL.C_KH_DonViTC.getDonViTaiLap();
            cbDonViTaiLapMD.DisplayMember = "TENCONGTY";
            cbDonViTaiLapMD.ValueMember = "ID";
            cbDonViTaiLapMD.SelectedIndex = cbDonViTaiLapMD.Items.Count-1;

            cbDonViTuVanGSTLMD.DataSource = DAL.C_KH_DonViTC.getDonViGiamSatTL();
            cbDonViTuVanGSTLMD.DisplayMember = "TENCONGTY";
            cbDonViTuVanGSTLMD.ValueMember = "ID";
            cbDonViTuVanGSTLMD.SelectedIndex = cbDonViTuVanGSTLMD.Items.Count-1;

            cbDonViGiamSatTC.DataSource = DAL.C_KH_DotThiCong.DonViGiamSat();
            this.cbDonViGiamSatTC.ValueMember = "TENDONVI";
            this.cbDonViGiamSatTC.DisplayMember = "TENDONVI";
            cbDonViGiamSatTC.SelectedIndex = cbDonViGiamSatTC.Items.Count-1;
           
            cbLoaiBangKe.DataSource = DAL.C_KH_DonViTC.getLoaiBangKe();
            cbLoaiBangKe.DisplayMember = "TENBANGKE";
            cbLoaiBangKe.ValueMember = "TENBANGKE";
        }

        public void loadDataGrid()
        {
            try
            {
                rows = DAL.C_KH_DotThiCong.TotalListDotThiCong();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            PageTotal();
            gridDotThiCong.DataSource = DAL.C_KH_DotThiCong.getListDotThiCong(FirstRow, pageSize);
        }

        private void txtSoHoSo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTon_KeyPress(object sender, KeyPressEventArgs e)
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

        public void refesh()
        {
            this.txtSodotTC.Text = "";
            this.txtSoHoSo.Text = "0";
            this.txtBangKe.Text = "";
            this.txtGhiChuHoanCong.Text = "";
            this.txtSoLuong.Text = "0";
            this.txtTon.Text = "0";
            this.txtQuetToan.Checked = false;
            this.txtLyDoTroNgaiTC.Text = "";

            this.dateChuyenBu.ValueObject = null;
            this.dateNgayChuyenHC.ValueObject = null;
            this.dateNgayChuyenKT.ValueObject = null;
            this.dateNgayThanhToan.ValueObject = null;
        }

        private void btLapDotMoi_Click(object sender, EventArgs e)
        {
            this.txtSodotTC.ReadOnly = false;
            refesh();
            this.dateNgayLap.Value = DateTime.Now.Date;
        }

        public void LuuDot()
        {
            try
            {

                string sodot = this.txtSodotTC.Text + "";
                string dovithicong = this.cbDonViThiCong.Text + "";
                string donvitailap = this.cbDonViTaiLapMD.Text + "";
                string donvigiamsat = this.cbDonViGiamSatTC.Text + "";
                string donvigiamsatTL = this.cbDonViTuVanGSTLMD.Text + "";
                string bangke = this.txtBangKe.Text + "";
                string loaibangke = this.cbLoaiBangKe.Text + "";
                string ghichuhoancong = this.txtGhiChuHoanCong.Text + "";
                string soluonghc = this.txtSoLuong.Text + "";
                string ton = this.txtTon.Text + "";
                bool quyettoan = false;
                if (this.txtQuetToan.Checked)
                    quyettoan = true;
                else
                    quyettoan = false;

                if ("".Equals(sodot))
                {
                    MessageBox.Show(this, "Nhập Số Đợt Thi Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtSodotTC.Text = "";
                    this.txtSodotTC.Focus();
                }
                else if (DAL.C_KH_DotThiCong.findByMadot(sodot) != null)
                {
                    MessageBox.Show(this, "Số Đợt Thi Công Đã Tồn Tại.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtSodotTC.Text = "";
                    this.txtSodotTC.Focus();
                }
                else if ("1/1/0001".Equals(this.dateNgayLap.Value.ToShortDateString()))
                {
                    MessageBox.Show(this, "Cần Chọn Ngày Lập", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dateNgayLap.Select();
                }
                else if ("".Equals(dovithicong))
                {
                    MessageBox.Show(this, "Cần Chọn Đơn Vị Thi Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.cbDonViThiCong.Select();
                }
                else if ("".Equals(donvitailap))
                {
                    MessageBox.Show(this, "Cần Chọn Đơn Vị Tái Lập Mặt Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.cbDonViTaiLapMD.Select();
                }
                //else if ("".Equals(bangke))
                //{
                //    MessageBox.Show(this, "Cần Nhập Bảng Kê !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    this.txtBangKe.Text = "";
                //    this.txtBangKe.Focus();
                //}
                else if ("".Equals(loaibangke))
                {
                    MessageBox.Show(this, "Cần Chọn Loại Bảng Kê !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.cbLoaiBangKe.Focus();
                }
                else if ("".Equals(donvigiamsat))
                {
                    MessageBox.Show(this, "Cần Chọn Đơn Vị Giám Sát Thi Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.cbLoaiBangKe.Focus();
                }
                else if ("".Equals(donvigiamsatTL))
                {
                    MessageBox.Show(this, "Cần Chọn Đơn Vị Giám Sát Tái Lập Mặt Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.cbLoaiBangKe.Focus();
                }
                else
                {
                    KH_DOTTHICONG dottc = new KH_DOTTHICONG();
                    dottc.MADOTTC = sodot.ToUpper();
                    dottc.SOLUONGTLK = int.Parse(this.txtSoHoSo.Text);
                    dottc.NGAYLAP = this.dateNgayLap.Value;
                    dottc.DONVITHICONG = int.Parse(this.cbDonViThiCong.SelectedValue + "");

                    if (!"1/1/0001".Equals(this.dateNgayChuyenHC.Value.ToShortDateString()))
                    {
                        dottc.NGAYCHUYENHC = dateNgayChuyenHC.Value.Date;
                    }
                    /////////////
                    if (!"1/1/0001".Equals(this.dtcTuNgay.Value.ToShortDateString()))
                    {
                        dottc.TCTUNGAY = dtcTuNgay.Value.Date;
                    }


                    if (!"1/1/0001".Equals(this.dtcDenNgay.Value.ToShortDateString()))
                    {
                        dottc.TCDENNGAY = dtcDenNgay.Value.Date;
                    }


                    /////
                    if (!"1/1/0001".Equals(this.dateChuyenTC.Value.ToShortDateString()))
                    {
                        dottc.NGAYCHUYENTC = dateChuyenTC.Value.Date;
                    }

                    if (!"1/1/0001".Equals(this.dateNgayChuyenKT.Value.ToShortDateString()))
                    {
                        dottc.NGAYCHUYENKT = dateNgayChuyenKT.Value.Date;
                    }
                    if (!"1/1/0001".Equals(this.dateNgayThanhToan.Value.ToShortDateString()))
                    {
                        dottc.NGAYTHANHTOAN = dateNgayThanhToan.Value.Date;
                    }
                    if (!"".Equals(txtGhiChuHoanCong.Text))
                    {
                        dottc.GHICHUHC = txtGhiChuHoanCong.Text;
                    }
                    if (!"".Equals(txtSoLuong.Text))
                    {
                        dottc.SOLUONG_HCTLK = int.Parse(txtSoLuong.Text);
                    }
                    if (!"".Equals(txtTon.Text))
                    {
                        dottc.CONLAI_TLK = int.Parse(txtTon.Text);
                    }
                    if (!"".Equals(txtLyDoTroNgaiTC.Text))
                    {
                        dottc.TRONGAITC = txtLyDoTroNgaiTC.Text;
                    }
                    dottc.QUYETTOAN = quyettoan;

                    dottc.DONVITAILAP = int.Parse(this.cbDonViTaiLapMD.SelectedValue + "");
                    dottc.DONVIGS = donvigiamsat;
                    dottc.DONVIGSTL = int.Parse(this.cbDonViTuVanGSTLMD.SelectedValue + "");
                    dottc.BANGKE = this.txtBangKe.Text;
                    dottc.LOAIBANGKE = this.cbLoaiBangKe.Text;
                    dottc.CREATEBY = DAL.C_USERS._userName;
                    dottc.CREATEDATE = DateTime.Now;

                    if (DAL.C_KH_DotThiCong.InsertDotTC(dottc) == false)
                    {
                        MessageBox.Show(this, "Lỗi Thêm Đợt Thi Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else {
                        this.searchTimKiem.Text = sodot.ToUpper();
                        Search();
                    }
                    //loadDataGrid();
                }
            }
            catch (Exception ex)
            {
                log.Error("Luu Dot Nhan Don Loi " + ex.Message);
            }
        }

        public void UpdateDot(KH_DOTTHICONG dottc)
        {
            try
            {
                string sodot = this.txtSodotTC.Text + "";
                string dovithicong = this.cbDonViThiCong.Text + "";
                string donvitailap = this.cbDonViTaiLapMD.Text + "";
                string bangke = this.txtBangKe.Text + "";
                string donvigiamsat = this.cbDonViGiamSatTC.Text + "";
                string donvigiamsatTL = this.cbDonViTuVanGSTLMD.Text + "";
                string loaibangke = this.cbLoaiBangKe.Text + "";
                string ghichuhoancong = this.txtGhiChuHoanCong.Text + "";
                string soluonghc = this.txtSoLuong.Text + "";
                string ton = this.txtTon.Text + "";
                bool quyettoan = false;
                if (this.txtQuetToan.Checked)
                    quyettoan = true;
                else
                    quyettoan = false;

                if ("".Equals(sodot))
                {
                    MessageBox.Show(this, "Nhập Số Đợt Thi Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtSodotTC.Text = "";
                    this.txtSodotTC.Focus();
                }
                else if ("1/1/0001".Equals(this.dateNgayLap.Value.ToShortDateString()))
                {
                    MessageBox.Show(this, "Cần Chọn Ngày Lập", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dateNgayLap.Select();
                }
                else if ("".Equals(dovithicong))
                {
                    MessageBox.Show(this, "Cần Chọn Đơn Vị Thi Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.cbDonViThiCong.Select();
                }
                else if ("".Equals(donvitailap))
                {
                    MessageBox.Show(this, "Cần Chọn Đơn Vị Tái Lập Mặt Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.cbDonViTaiLapMD.Select();
                }
                else if ("".Equals(bangke))
                {
                    MessageBox.Show(this, "Cần Nhập Bảng Kê !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtBangKe.Text = "";
                    this.txtBangKe.Focus();
                }
                else if ("".Equals(loaibangke))
                {
                    MessageBox.Show(this, "Cần Chọn Loại Bảng Kê !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.cbLoaiBangKe.Focus();
                }
                else
                {
                    dottc.SOLUONGTLK = int.Parse(this.txtSoHoSo.Text);
                    dottc.NGAYLAP = this.dateNgayLap.Value;
                    dottc.DONVITHICONG = DAL.C_KH_DonViTC.findDVTCbyTENCTY(this.cbDonViThiCong.Text).ID;

                    if (!"1/1/0001".Equals(this.dateNgayChuyenHC.Value.ToShortDateString()))
                    {
                        dottc.NGAYCHUYENHC = dateNgayChuyenHC.Value.Date;
                    }

                    if (!"1/1/0001".Equals(this.dateChuyenTC.Value.ToShortDateString()))
                    {
                        dottc.NGAYCHUYENTC = dateChuyenTC.Value.Date;
                    }
                    /////////////
                    if (!"1/1/0001".Equals(this.dtcTuNgay.Value.ToShortDateString()))
                    {
                        dottc.TCTUNGAY = dtcTuNgay.Value.Date;
                    }


                    if (!"1/1/0001".Equals(this.dtcDenNgay.Value.ToShortDateString()))
                    {
                        dottc.TCDENNGAY = dtcDenNgay.Value.Date;
                    }

                    if (!"1/1/0001".Equals(this.dateNgayChuyenKT.Value.ToShortDateString()))
                    {
                        dottc.NGAYCHUYENKT = dateNgayChuyenKT.Value.Date;
                    }
                    if (!"1/1/0001".Equals(this.dateNgayThanhToan.Value.ToShortDateString()))
                    {
                        dottc.NGAYTHANHTOAN = dateNgayThanhToan.Value.Date;
                    }
                    if (!"".Equals(txtGhiChuHoanCong.Text))
                    {
                        dottc.GHICHUHC = txtGhiChuHoanCong.Text;
                    }
                    if (!"".Equals(txtSoLuong.Text))
                    {
                        dottc.SOLUONG_HCTLK = int.Parse(txtSoLuong.Text);
                    }
                    if (!"".Equals(txtTon.Text))
                    {
                        dottc.CONLAI_TLK = int.Parse(txtTon.Text);
                    }
                    if (!"".Equals(txtLyDoTroNgaiTC.Text))
                    {
                        dottc.TRONGAITC = txtLyDoTroNgaiTC.Text;
                    }
                    dottc.QUYETTOAN = quyettoan;

                    dottc.DONVITAILAP = DAL.C_KH_DonViTC.findDVTLbyTENCTY(this.cbDonViTaiLapMD.Text).ID;
                    dottc.DONVIGS = donvigiamsat;
                    dottc.DONVIGSTL = DAL.C_KH_DonViTC.findDVGSTCbyName(donvigiamsatTL).ID;
                    dottc.BANGKE = this.txtBangKe.Text;
                    dottc.LOAIBANGKE = this.cbLoaiBangKe.Text;
                    dottc.MODIFYBY = DAL.C_USERS._userName;
                    dottc.MODIFYDATE = DateTime.Now.Date;

                    if (DAL.C_KH_DotThiCong.UpdateDotTC(dottc) == false)
                        MessageBox.Show(this, "Cập Nhật Đợt Thi Công Không Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(this, "Cập Nhật Đợt Thi Công Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDataGrid();
                }
            }
            catch (Exception ex)
            {

                log.Error("Cap Nhat Dot Nhan Don Loi " + ex.Message);
            }
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

        private void btLuuDotMoi_Click(object sender, EventArgs e)
        {
            LuuDot();
            this.txtSodotTC.ReadOnly = true;
        }

        public void loadTextBox(KH_DOTTHICONG dottc)
        {
            this.txtSodotTC.Text = dottc.MADOTTC;
            this.txtSoHoSo.Text = dottc.SOLUONGTLK + "";
            this.txtBangKe.Text = dottc.BANGKE;
            this.txtGhiChuHoanCong.Text = dottc.GHICHUHC;
            this.txtSoLuong.Text = dottc.SOLUONG_HCTLK != null ? dottc.SOLUONG_HCTLK + "" : "0";

            if (dottc.QUYETTOAN == true)
                this.txtQuetToan.Checked = true;
            else
                this.txtQuetToan.Checked = false;
            this.cbDonViThiCong.Text = DAL.C_KH_DonViTC.findDVTCbyID(int.Parse(dottc.DONVITHICONG + "")).TENCONGTY;
            this.cbDonViTaiLapMD.Text = DAL.C_KH_DonViTC.findDVTLbyID(int.Parse(dottc.DONVITAILAP + "")).TENCONGTY;
            this.cbDonViTuVanGSTLMD.Text = DAL.C_KH_DonViTC.findDVGSTCbyID(int.Parse(dottc.DONVIGSTL + "")).TENCONGTY;
            this.cbDonViGiamSatTC.Text = dottc.DONVIGS;
            this.dateChuyenBu.ValueObject = dottc.CHUYENBUHANMUC;
            this.dateNgayLap.ValueObject = dottc.NGAYLAP;
            this.dateChuyenTC.ValueObject = dottc.NGAYCHUYENTC;

            this.dtcTuNgay.ValueObject = dottc.TCTUNGAY;
            this.dtcDenNgay.ValueObject = dottc.TCDENNGAY;
           // if (!"1/1/0001".Equals(this.dateChuyenTC.Value.ToShortDateString()))        
            this.cbLoaiBangKe.Text = dottc.LOAIBANGKE;
            this.dateChuyenBu.ValueObject = dottc.CHUYENBUHANMUC;
            this.dateNgayChuyenHC.ValueObject = dottc.NGAYCHUYENHC;
            this.txtGhiChuHoanCong.Text = dottc.GHICHUHC;
            this.txtTon.Text = dottc.CONLAI_TLK != null ? dottc.CONLAI_TLK + "" : "0";
            this.dateNgayChuyenKT.ValueObject = dottc.NGAYCHUYENKT;
            this.dateNgayThanhToan.ValueObject = dottc.NGAYTHANHTOAN;
            this.txtLyDoTroNgaiTC.Text = dottc.TRONGAITC;
           
        }

        private void gridDotThiCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string dottcS = gridDotThiCong.Rows[e.RowIndex].Cells["gridSoDot"].Value + "";
                KH_DOTTHICONG dottc = DAL.C_KH_DotThiCong.findByMadot(dottcS);
                if (dottc != null)
                {
                    loadTextBox(dottc);
                }
            }
            catch (Exception)
            {
            }

        }

        private void txtSearchDotTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                KH_DOTTHICONG dottc = DAL.C_KH_DotThiCong.findByMadot(this.txtSearchDotTC.Text);
                if (dottc != null)
                {
                    loadTextBox(dottc);
                }
                else
                {
                    MessageBox.Show(this, "Không Tìm Thấy Đợt Thi Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    refesh();
                    txtSearchDotTC.Text = "";
                    txtSearchDotTC.Focus();
                }
            }
        }

        private void txtSoHoSo_Leave(object sender, EventArgs e)
        {
            this.txtTon.Text = txtSoHoSo.Text;
        }

        private void txtSodotTC_Leave(object sender, EventArgs e)
        {
            this.txtSodotTC.Text = this.txtSodotTC.Text.ToUpper();

        }

        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            try
            {
                this.txtTon.Text = (int.Parse(txtSoHoSo.Text) - int.Parse(txtSoLuong.Text)) + "";
            }
            catch (Exception)
            {

            }

        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                KH_DOTTHICONG dottc = DAL.C_KH_DotThiCong.findByMadot(this.txtSodotTC.Text);
                if (dottc != null)
                {
                    UpdateDot(dottc);
                }

                this.txtSodotTC.ReadOnly = true;
            }
            catch (Exception ex)
            {
                log.Error("Loi " + ex.Message);
            }

        }

        private void txtSearchDotTC_Enter(object sender, EventArgs e)
        {
            MessageBox.Show(this, "safdsa");
        }

        public void tabClick()
        {

            string madot = "";
            string tendot = "";
            try
            {
                madot = gridDotThiCong.Rows[gridDotThiCong.CurrentRow.Index].Cells["gridSoDot"].Value + "";
                tendot = gridDotThiCong.Rows[gridDotThiCong.CurrentRow.Index].Cells["girdLoaiDot"].Value + "";
            }
            catch (Exception)
            {
            }
            if (!"".Equals(madot))
            {
                if (tendot.Equals("Bồi Thường"))
                {
                    this.tabCapNhatDS.Controls.Clear();
                    this.tabCapNhatDS.Controls.Add(new tab_CapNhatDSBoiThuong(madot));
                    //  this.tabCapNhatDS.Controls.Add(new tab_CapNhatDanhSachND(madot));
                    this.tabControl1.SelectedTabIndex = 1;
                }
                else
                {
                    this.tabCapNhatDS.Controls.Clear();
                    //this.tabCapNhatDS.Controls.Add(new tab_CapNhatDSBoiThuong(madot));
                    this.tabCapNhatDS.Controls.Add(new tab_CapNhatDanhSachND(madot));
                    this.tabControl1.SelectedTabIndex = 1;
                }
            }
            else
            {
                MessageBox.Show(this, "Cần Chọn Đợt Thi Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void tabItem2_Click(object sender, EventArgs e)
        {
            tabClick();
        }

        private void btCapNhatGanMoiDoi_Click(object sender, EventArgs e)
        {
            tabClick();
        }

        private void btCapNhatBoiTuong_Click(object sender, EventArgs e)
        {
            tabClick();
        }

        private void btQuyetDinh_Click(object sender, EventArgs e)
        {
            string madot = "";
            try
            {
                madot = gridDotThiCong.Rows[gridDotThiCong.CurrentRow.Index].Cells["gridSoDot"].Value + "";

            }
            catch (Exception)
            {
            }
            if (!"".Equals(madot))
            {
                ReportDocument rp = new rpt_QuyetDinhTC();
                if (DAL.C_KH_DonViTC.findDVTLbyTENCTY(this.cbDonViTaiLapMD.Text).ID == 17 || DAL.C_KH_DonViTC.findDVTLbyTENCTY(this.cbDonViTaiLapMD.Text).ID == 19)
                {
                    rp = new rpt_QuyetDinhTCKoDVTL();
                }
                rp.SetDataSource(DAL.C_KH_DotThiCong.BC_QuyetDinhThiCong(madot, "", "", ""));
               // crystalReportViewer1.ReportSource = rp;

                rpt_Main mainReport = new rpt_Main(rp);
                mainReport.ShowDialog();
                //frmDialogPrintting obj = new frmDialogPrintting(madot);
                //obj.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Cần Chọn Đợt Thi Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btInDanhSachGanMoi_Click(object sender, EventArgs e)
        {
            string madot = "";
            string tendot = "";
            try
            {
                madot = gridDotThiCong.Rows[gridDotThiCong.CurrentRow.Index].Cells["gridSoDot"].Value + "";
                tendot = gridDotThiCong.Rows[gridDotThiCong.CurrentRow.Index].Cells["girdLoaiDot"].Value + "";
            }
            catch (Exception)
            {
            }
            string ngaytk = "";
            KH_DOTTHICONG dotc = DAL.C_KH_DotThiCong.findByMadot(madot);
            ngaytk = "Ngày " + dotc.NGAYLAP.Value.Day.ToString() + " tháng " + dotc.NGAYLAP.Value.Month.ToString() + " năm " + dotc.NGAYLAP.Value.Year.ToString();
            if (!"".Equals(madot) && !"".Equals(tendot))
            {
                if (tendot.Equals("Gắn Mới(NĐ117)"))
                {
                    ReportDocument rp = new rpt_DanhSachHSTC_GM();
                    string tungay = "";
                    string denngay = "";
                    try
                    {
                       
                        if (dotc != null)
                        {
                            tungay = Utilities.DateToString.NgayVN(dotc.TCTUNGAY.Value);
                            denngay = Utilities.DateToString.NgayVN(dotc.TCDENNGAY.Value);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    
                    rp.SetDataSource(DAL.C_KH_DotThiCong.BC_DanhSachDotThiCong(madot));
                    rp.SetParameterValue("tungay", tungay);
                    rp.SetParameterValue("denngay", denngay);
                    rp.SetParameterValue("ngaytk", ngaytk);
                    rpt_Main mainReport = new rpt_Main(rp);
                    mainReport.ShowDialog();
                }
                else if (tendot.Equals("Ống Cái") )
                {
                    string tungay = "";
                    string denngay = "";
                    try
                    {

                        if (dotc != null)
                        {
                            tungay = Utilities.DateToString.NgayVN(dotc.TCTUNGAY.Value);
                            denngay = Utilities.DateToString.NgayVN(dotc.TCDENNGAY.Value);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    
                    ReportDocument rp = new rpt_DanhSachHSTC_OC();
                    rp.SetDataSource(DAL.C_KH_DotThiCong.BC_DanhSachDotThiCong_OC(madot));
                    rp.SetParameterValue("tungay", tungay);
                    rp.SetParameterValue("denngay", denngay);
                    rp.SetParameterValue("ngaytk", ngaytk);
                    rpt_Main mainReport = new rpt_Main(rp);
                    mainReport.ShowDialog();

                }else if(tendot.Equals("Gắn Mới")){
                    string tungay = "";
                    string denngay = "";
                    try
                    {

                        if (dotc != null)
                        {
                            tungay = Utilities.DateToString.NgayVN(dotc.TCTUNGAY.Value);
                            denngay = Utilities.DateToString.NgayVN(dotc.TCDENNGAY.Value);
                        }
                    }
                    catch (Exception)
                    {
                    }

                    ReportDocument rp = new rpt_DanhSachHSTC_GM_KND();
                    rp.SetDataSource(DAL.C_KH_DotThiCong.BC_DanhSachDotThiCong_OC(madot));
                    rp.SetParameterValue("tungay", tungay);
                    rp.SetParameterValue("denngay", denngay);
                    rp.SetParameterValue("ngaytk", ngaytk);
                    rpt_Main mainReport = new rpt_Main(rp);
                    mainReport.ShowDialog();
                
                }
                else if (tendot.Equals("Bồi Thường"))
                {
                    ReportDocument rp = new rpt_DanhSachHSTC_BT();
                    rp.SetDataSource(DAL.C_KH_DotThiCong.BC_DanhSachDotThiCong_BT(madot));
                    rp.SetParameterValue("ngaytk", ngaytk);
                    rpt_Main mainReport = new rpt_Main(rp);
                    mainReport.ShowDialog();
                }
                else if (tendot.Equals("Dời-BT"))
                {
                    reportValues rpt = new reportValues(2, madot,ngaytk);
                    rpt.ShowDialog();
                }
                else if (tendot.Equals("Dời"))
                {
                    ReportDocument rp = new rpt_DanhSachHSTC_DOI();
                    rp.SetDataSource(DAL.C_KH_DotThiCong.BC_DanhSachDotThiCong_OC(madot));
                    rp.SetParameterValue("ngaytk", ngaytk);
                    rpt_Main mainReport = new rpt_Main(rp);
                    mainReport.ShowDialog();
                }
                else if (tendot.Equals("GQ Sự Cố"))
                {
                    reportValues rpt = new reportValues(3, madot,ngaytk);
                    rpt.ShowDialog();
                }
                else if (tendot.Equals("Di Dời TCH"))
                {
                    reportValues rpt = new reportValues(4, madot,ngaytk);
                    rpt.ShowDialog();
                }
                else
                {
                    reportValues rpt = new reportValues(1, madot, ngaytk);
                    rpt.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show(this, "Cần Chọn Đợt Thi Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void tabItem3_Click(object sender, EventArgs e)
        {
            this.tabThamSo.Controls.Clear();
            this.tabThamSo.Controls.Add(new tab_DonViTCTLMD());
            //  this.tabCapNhatDS.Controls.Add(new tab_CapNhatDanhSachND(madot));
            this.tabControl1.SelectedTabIndex = 4;
        }

        public void Search() {
            try
            {
                string dottcS = this.searchTimKiem.Text;
                if ("".Equals(dottcS))
                {
                    loadDataGrid();
                }
                else
                {
                    DataTable table = DAL.C_KH_DotThiCong.getListDotThiCongbyMaDot(dottcS);
                    if (table.Rows.Count <= 0)
                    {
                        MessageBox.Show(this, "Không Tìm Thấy Đợt Thi Công!", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (table.Rows.Count == 1)
                    {
                        KH_DOTTHICONG dottc = DAL.C_KH_DotThiCong.findByMadot(table.Rows[0][0].ToString());
                        if (dottc != null)
                        {
                            loadTextBox(dottc);
                        }
                        gridDotThiCong.DataSource = table;
                    }
                    else
                    {
                        gridDotThiCong.DataSource = table;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void searchTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Search();
            }
        }

        private void btTheoBangKe_Click(object sender, EventArgs e)
        {
            string madot = "";
            string tendot = "";
            try
            {
                madot = gridDotThiCong.Rows[gridDotThiCong.CurrentRow.Index].Cells["gridSoDot"].Value + "";
                tendot = gridDotThiCong.Rows[gridDotThiCong.CurrentRow.Index].Cells["girdLoaiDot"].Value + "";
            }
            catch (Exception)
            {
            }
            if (!"".Equals(madot))
            {
                this.tabControlPanel1.Controls.Clear();
                this.tabControlPanel1.Controls.Add(new tab_CapNhatDanhSachbyDot(madot));
                //  this.tabCapNhatDS.Controls.Add(new tab_CapNhatDanhSachND(madot));
                this.tabControl1.SelectedTabIndex = 2;
            }
            else
            {
                MessageBox.Show(this, "Cần Chọn Mã Đợt Để Xin Phép Đào Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tabItem4_Click(object sender, EventArgs e)
        {
            string madot = "";
            string tendot = "";
            try
            {
                madot = gridDotThiCong.Rows[gridDotThiCong.CurrentRow.Index].Cells["gridSoDot"].Value + "";
                tendot = gridDotThiCong.Rows[gridDotThiCong.CurrentRow.Index].Cells["girdLoaiDot"].Value + "";
            }
            catch (Exception)
            {
            }
            if (!"".Equals(madot))
            {
                this.tabControlPanel1.Controls.Clear();
                this.tabControlPanel1.Controls.Add(new tab_CapNhatDanhSachbyDot(madot));
                //  this.tabCapNhatDS.Controls.Add(new tab_CapNhatDanhSachND(madot));
                this.tabControl1.SelectedTabIndex = 2;
            }
            else
            {
                MessageBox.Show(this, "Cần Chọn Mã Đợt Để Xin Phép Đào Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btChinhSuaDanhSach_Click(object sender, EventArgs e)
        {
            string madot = "";
            string tendot = "";
            try
            {
                madot = gridDotThiCong.Rows[gridDotThiCong.CurrentRow.Index].Cells["gridSoDot"].Value + "";
                tendot = gridDotThiCong.Rows[gridDotThiCong.CurrentRow.Index].Cells["girdLoaiDot"].Value + "";
            }
            catch (Exception)
            {
            }
            if (!"".Equals(madot))
            {
                this.tabControlPanel2.Controls.Clear();
                this.tabControlPanel2.Controls.Add(new Tab_EditDanhSachTC(madot));
                //  this.tabCapNhatDS.Controls.Add(new tab_CapNhatDanhSachND(madot));
                this.tabControl1.SelectedTabIndex = 3;
            }
            else
            {
                MessageBox.Show(this, "Cần Chọn Mã Đợt Để Xin Phép Đào Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tabItem5_Click(object sender, EventArgs e)
        {
            string madot = "";
            string tendot = "";
            try
            {
                madot = gridDotThiCong.Rows[gridDotThiCong.CurrentRow.Index].Cells["gridSoDot"].Value + "";
                tendot = gridDotThiCong.Rows[gridDotThiCong.CurrentRow.Index].Cells["girdLoaiDot"].Value + "";
            }
            catch (Exception)
            {
            }
            if (!"".Equals(madot))
            {
                this.tabControlPanel2.Controls.Clear();
                this.tabControlPanel2.Controls.Add(new Tab_EditDanhSachTC(madot));
                //  this.tabCapNhatDS.Controls.Add(new tab_CapNhatDanhSachND(madot));
                this.tabControl1.SelectedTabIndex = 3;
            }
            else
            {
                MessageBox.Show(this, "Cần Chọn Mã Đợt Để Xin Phép Đào Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void searchTimKiem_TextChanged(object sender, EventArgs e)
        {
            gridDotThiCong.ClearSelection();
            foreach (DataGridViewRow currentRow in gridDotThiCong.Rows)
            {
                if (currentRow.Cells["gridSoDot"].Value.ToString().Contains(searchTimKiem.Text))
                {
                    currentRow.Selected = true;
                    break;
                }
            }
        }

        private void btTroNgaiTC_Click(object sender, EventArgs e)
        {
            optTroNgaiTC opt = new optTroNgaiTC();
            opt.ShowDialog();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string madot = "";
            try
            {
                madot = gridDotThiCong.Rows[gridDotThiCong.CurrentRow.Index].Cells["gridSoDot"].Value + "";
                if (MessageBox.Show(this, "Bạn chắc muốn xóa đợt thi công " + madot + " ?", "..: Thông Báo:..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAL.LinQConnection.ExecuteCommand("DELETE FROM KH_DOTTHICONG WHERE MADOTTC=N'"+madot+"'");
                    gridDotThiCong.Rows.RemoveAt(gridDotThiCong.CurrentRow.Index);
                    searchTimKiem_TextChanged(sender, e);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string madot = "";
            string tendot = "";
            try
            {
                madot = gridDotThiCong.Rows[gridDotThiCong.CurrentRow.Index].Cells["gridSoDot"].Value + "";
                tendot = gridDotThiCong.Rows[gridDotThiCong.CurrentRow.Index].Cells["girdLoaiDot"].Value + "";
            }
            catch (Exception)
            {

            }
            frm_HoSoBoSung obj = new frm_HoSoBoSung(madot);
            obj.ShowDialog();
        }

       
    }
}