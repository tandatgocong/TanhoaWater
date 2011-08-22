using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;
using TanHoaWater.Class;
using System.Collections;
using log4net;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.HSKHACHHANG.Report;

namespace TanHoaWater.View.Users.HSKHACHHANG
{
    public partial class HSKHACHHANG : UserControl
    {
        int currentPageIndex = 1;
        int pageSize = 8;
        int pageNumber = 0;
        int FirstRow, LastRow;
        int rows;

        private static readonly ILog log = LogManager.GetLogger(typeof(HSKHACHHANG).Name);
        public HSKHACHHANG()
        {
            InitializeComponent();
            formLoad();
            refresh();
            this.txtSHS.Focus();
            this.result.Visible = false;

        }

        private void txtghichukhan_MouseClick(object sender, MouseEventArgs e)
        {
            this.ghichukhan.Text = null;

        }
        public void formLoad()
        {
            #region Load Quan
            this.cbQuan.DataSource = DAL.C_QUAN.getList();
            this.cbQuan.DisplayMember = "TENQUAN";
            this.cbQuan.ValueMember = "MAQUAN";
            #endregion
            #region Loai HoSo
            this.cbLoaiHS.DataSource = DAL.C_LOAIHOSO.getList();
            this.cbLoaiHS.DisplayMember = "TENLOAI";
            this.cbLoaiHS.ValueMember = "MALOAI";
            #endregion
            #region Loai KhaHang
            this.cbLoaiKH.DataSource = DAL.C_LOAIKH.getList();
            this.cbLoaiKH.DisplayMember = "TENLOAI";
            this.cbLoaiKH.ValueMember = "MALOAI";
            #endregion
            #region Loai Dot Khach Hang
            this.cbDotNhanDon.DataSource = DAL.C_DOTNHANDON.getListtMa_Dot_NoChuyen();
            this.cbDotNhanDon.DisplayMember = "TEND";
            this.cbDotNhanDon.ValueMember = "MADOT";
            #endregion

            try
            {
                rows = DAL.C_DONKHACHHANG.TotalListByDot(this.cbDotNhanDon.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            PageTotal();
            Utilities.DataGridV.formatRows(dataG);
        }

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
                this.cbPhuong.DataSource = DAL.C_PHUONG.getListByQuan(maquan);
                this.cbPhuong.DisplayMember = "TENPHUONG";
                this.cbPhuong.ValueMember = "MAPHUONG";
            }
            catch (Exception)
            {
            }
        }

        private void cbPhuong_SelectedValueChanged(object sender, EventArgs e)
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

        private void txtSHS_Leave(object sender, EventArgs e)
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

        private void cbDotNhanDon_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                loadDataGrid();
                this.errorProvider1.Clear();

            }
            catch (Exception)
            {

            }
        }
        private void btInsert_Click(object sender, EventArgs e)
        {
            if (this.txtSHS.Text.Length < 5)
            {
                this.errorProvider1.Clear();
                this.errorProvider1.SetError(this.txtSHS, "Số Hồ Sơ Không Hợp Lệ.");
            }
            else if ("".Equals(this.txtHoTen.Text))
            {
                this.errorProvider1.Clear();
                this.errorProvider1.SetError(this.txtHoTen, "Họ Tên Khách Hàng Không Được Trống.");
            }
            else if ("".Equals(this.sonha.Text))
            {
                this.errorProvider1.Clear();
                this.errorProvider1.SetError(this.sonha, "Số Nhà Không Được Trống.");
            }
            else if ("".Equals(this.duong.Text))
            {
                this.errorProvider1.Clear();
                this.errorProvider1.SetError(this.duong, "Tên Đường Không Được Trống.");
            }
            else if (DAL.C_DONKHACHHANG.findBySOHOSO(this.txtSoHoSo.Text) != null)
            {
                this.errorProvider1.Clear();
                this.errorProvider1.SetError(this.txtSHS, "Số Hồ Sơ Đã Tồn Tại.");
            }
            else if (DAL.C_DONKHACHHANG.findByAddressAndLoaiHS(this.cbDotNhanDon.SelectedValue.ToString(), this.cbLoaiHS.SelectedValue.ToString(), this.sonha.Text, this.duong.Text, this.cbPhuong.SelectedValue.ToString(), this.cbQuan.SelectedValue.ToString()))
            {
                this.errorProvider1.Clear();
                this.errorProvider1.SetError(this.sonha, "Địa Chỉ Khách Hàng Đã Được Nhận Đơn.");
            }
            else
            {
                this.errorProvider1.Clear();
                DON_KHACHHANG donKH = new DON_KHACHHANG();
                donKH.MADOT = this.cbDotNhanDon.SelectedValue.ToString();
                donKH.SOHOSO = this.txtSoHoSo.Text;
                donKH.SHS = this.txtSHS.Text;
                donKH.HOTEN = this.txtHoTen.Text;
                donKH.DIENTHOAI = this.dienthoai.Text;
                donKH.SOHO = int.Parse(this.soho.Value.ToString());
                donKH.SONHA = this.sonha.Text;
                donKH.DUONG = this.duong.Text;
                donKH.PHUONG = this.cbPhuong.SelectedValue.ToString();
                donKH.QUAN = int.Parse(this.cbQuan.SelectedValue.ToString());
                donKH.NGAYNHAN = DateTime.Now;
                donKH.LOAIKH = this.cbLoaiKH.SelectedValue.ToString();
                donKH.LOAIHOSO = this.cbLoaiHS.SelectedValue.ToString();
                donKH.GHICHU = this.ghichu.Text;
                if (this.khan.Checked == true)
                {
                    donKH.HOSOKHAN = true;
                    donKH.GHICHUKHAN = this.ghichukhan.Text;
                }
                donKH.CREATEBY = DAL.C_USERS._userName;
                donKH.CREATEDATE = DateTime.Now;
                DAL.C_DONKHACHHANG.InsertDonHK(donKH);
                loadDataGrid();
                Utilities.DataGridV.formatRows(dataG);
            }
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
            this.txtSHS.Mask = DateTime.Now.Year.ToString().Substring(2) + "00000";
            this.txtHoTen.Text = null;
            this.dienthoai.Text = null;
            this.sonha.Text = null;
            this.duong.Text = null;
            this.txtSoHoSo.Text = null;
            this.errorProvider1.Clear();
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
            this.dataG.DataSource = DAL.C_DONKHACHHANG.getListbyDot(_madot, FirstRow, pageSize);
            int sokh = DAL.C_DONKHACHHANG.TotalListByDot(_madot);
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
        }

        private void tab_BaoCao_Click(object sender, EventArgs e)
        {
            #region Bao cao Quan
            this.BC_QUAN.DataSource = DAL.C_QUAN.getList();
            this.BC_QUAN.DisplayMember = "TENQUAN";
            this.BC_QUAN.ValueMember = "MAQUAN";
            #endregion
            #region Loai Dot Nhan Don
            this.BC_DOTNHANDON.DataSource = DAL.C_DOTNHANDON.getListtMa_Dot();
            this.BC_DOTNHANDON.DisplayMember = "TEND";
            this.BC_DOTNHANDON.ValueMember = "MADOT";
            #endregion
            #region Load User
            this.BC_NGUOIDUYET.DataSource = DAL.C_USERS.getAll();
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
                ReportDocument rp = new rpt_DOT_KHAN();
                rp.SetDataSource(DAL.C_BAOCAO_VIEW.BC_DOTNHANDON_DOT(this.BC_DOTNHANDON.SelectedValue.ToString(), DAL.C_USERS._userName, this.BC_NGUOIDUYET.SelectedValue.ToString(), null, "True"));
                report.ReportSource = rp;
            }
            if (this.BC_LOAIBC.SelectedIndex == 3)
            {
                ReportDocument rp = new rpt_DOT_QUAN_KHAN();
                rp.SetDataSource(DAL.C_BAOCAO_VIEW.BC_DOTNHANDON_DOT(this.BC_DOTNHANDON.SelectedValue.ToString(), DAL.C_USERS._userName, this.BC_NGUOIDUYET.SelectedValue.ToString(), this.BC_QUAN.SelectedValue.ToString(), "True"));
                report.ReportSource = rp;
            }
        }


        private void txtSoHoSo_MouseClick(object sender, MouseEventArgs e)
        {
            this.cd_MaHoSo.Text = "";

        }

        private void txtSoHoSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    string _soHoSo = this.cd_MaHoSo.Text;
                    if (_soHoSo != null)
                    {

                        Database.DON_KHACHHANG donkh = DAL.C_DONKHACHHANG.findBySOHOSO(_soHoSo);
                        if (donkh != null)
                        {
                            this.cd_MaHoSo.Text = donkh.SOHOSO;
                            this.cd_soHo.Value = decimal.Parse(donkh.SOHO.ToString());
                            this.cd_HoTen.Text = donkh.HOTEN;
                            this.cd_soNha.Text = donkh.SONHA;
                            this.cd_TenDuong.Text = donkh.DUONG;
                            // select Quan
                            this.cd_Quan.Text = DAL.C_QUAN.finByMaQuan(donkh.QUAN).TENQUAN;
                            // select Phuong
                            this.cd_Phuong.Text = DAL.C_PHUONG.finbyPhuong(donkh.QUAN, donkh.PHUONG).TENPHUONG;
                            //select loaiKH
                            this.cd_LoaiKH.Text = DAL.C_LOAIKH.finbyMaLoai(donkh.LOAIKH).TENLOAI;
                            // select loaiHoso
                            cd_LoaiHS.Text = DAL.C_LOAIHOSO.findbyMaLoai(donkh.LOAIHOSO).TENLOAI;
                            this.cd_DotNhanDon.Text = donkh.MADOT;
                            this.cd_SoDT.Text = donkh.DIENTHOAI;
                            this.cd_ghichu.Text = donkh.GHICHU;
                            if (donkh.HOSOKHAN == true)
                            {
                                this.cd_checkkhan.Checked = true;
                                this.cd__ghichukhan.Visible = true;
                                this.cd__ghichukhan.Text = donkh.GHICHUKHAN;
                            }
                            else
                            {
                                this.cd_checkkhan.Checked = false;
                                this.cd__ghichukhan.Visible = false;
                                this.cd__ghichukhan.Text = null;
                            }
                            if (donkh.CHUYEN_HOSO == true)
                            {
                                this.chuyenhoso.Checked = true;
                                this.bophanChuyen.Visible = true;
                                // load bo phan chuyen
                                this.btChuyenHS.Enabled = false;
                                this.bophanChuyen.Text = DAL.C_PHONGBAN.findbyMaPhong(donkh.BOPHANCHUYEN).TENPHONG;
                            }
                            else
                            {
                                this.chuyenhoso.Checked = false;
                                this.bophanChuyen.Visible = false;
                                this.btChuyenHS.Enabled = true;
                                this.bophanChuyen.Text = null;
                            }

                        }
                        else
                        {
                            string flag = "Không Tìm Thấy Mã Hồ Sơ " + _soHoSo;
                            MessageBox.Show(this, flag, "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
                catch (Exception ex)
                {
                    log.Error("Tim Chuyen Ho So Loi " + ex.Message);
                }
            }
        }
        private void btChuyenHS_Click(object sender, EventArgs e)
        {
            try
            {
                if (chuyenhoso.Checked == true)
                {
                    DAL.C_DONKHACHHANG.chuyenhs(this.cd_MaHoSo.Text.Trim(), DAL.C_USERS._userName, this.bophanChuyen.SelectedValue.ToString());
                    result.Visible = true;
                }
                else
                {
                    MessageBox.Show(this, "Chọn Chuyển Hồ Sơ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception ex)
            {
                log.Error("Loi Khi Chuyen Ho So " + ex.Message);
                result.Text = "Lỗi Khi Chuyển Hồ Sơ";
                result.Visible = true;
            }

        }

        private void chuyenhoso_CheckedChanged_1(object sender, EventArgs e)
        {
            this.bophanChuyen.DataSource = DAL.C_PHONGBAN.getList();
            this.bophanChuyen.DisplayMember = "TENPHONG";
            this.bophanChuyen.ValueMember = "MAPHONG";
            if (chuyenhoso.Checked)
            {
                this.bophanChuyen.Visible = true;
            }
            else
            {
                this.bophanChuyen.Visible = false;
            }

        }

        private void tabChuyenDon_Click(object sender, EventArgs e)
        {
            // customize dataviewgrid, add checkbox column
            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
            checkboxColumn.Width = 30;
            checkboxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cd_MainGird.Columns.Insert(3, checkboxColumn);

            // add checkbox header
            Rectangle rect = cd_MainGird.GetCellDisplayRectangle(3, -1, true);
            // set checkbox header to center of header cell. +1 pixel to position correctly.
            rect.X = rect.Location.X + (rect.Width / 4);

            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.Name = "checkboxHeader";
            checkboxHeader.Size = new Size(17, 17);
            checkboxHeader.Location = rect.Location;
            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);
            cd_MainGird.Controls.Add(checkboxHeader);
            load_cd_Grid();
        }
        public void load_cd_Grid() {
            cd_MainGird.DataSource = DAL.C_DOTNHANDON.getListChuaChuyen();
        }
        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < cd_MainGird.RowCount; i++)
            {
                cd_MainGird[0, i].Value = ((CheckBox)cd_MainGird.Controls.Find("checkboxHeader", true)[0]).Checked;
            }
            cd_MainGird.EndEdit();
        }

        private void chuyenDot_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cd_MainGird.RowCount; i++)
            {
                if (cd_MainGird[0, i].Value != null && "True".Equals(cd_MainGird[0, i].Value.ToString())) {
                    MessageBox.Show(this, cd_MainGird.Rows[i].Cells[1].Value.ToString());
                }
                    
                
            }
        }
       
    }
}