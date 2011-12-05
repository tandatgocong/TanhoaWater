using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace TanHoaWater.View.Users.KEHOACH.XINPHEPDD
{
    public partial class tab_DanhSach : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_DanhSach).Name);
        int currentPageIndex = 1;
        int pageSize = 19;
        int pageNumber = 0;
        int FirstRow, LastRow;
        int rows;
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
        public tab_DanhSach()
        {
            InitializeComponent();
            search();
            #region Load Noi Cap Phep
            this.cbNoiCap.DataSource = DAL.C_KH_XinPhepDD.getNoiXiPhep();
            this.cbNoiCap.DisplayMember = "MACAPPHEP";
            this.cbNoiCap.ValueMember = "MACAPPHEP";
            #endregion
        }

        public void loadData()
        {
            //string _madot = this.cbDotNhanDon.SelectedValue.ToString();
            try
            {
                rows = DAL.C_KH_XinPhepDD.TotalList("", "", "");
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            PageTotal();

            this.dataDanhSachDaoDuong.DataSource = DAL.C_KH_XinPhepDD.getList("", "", "", FirstRow, pageSize);
            //this.totalRecord.Text = "Tống công có " + sokh + " khách hàng đợt nhận đơn " + _madot;

        }
        private void next_Click(object sender, EventArgs e)
        {
            if (currentPageIndex < pageNumber)
            {
                currentPageIndex = currentPageIndex + 1;
                FirstRow = pageSize * (currentPageIndex - 1);
                LastRow = pageSize * (currentPageIndex);
                PageTotal();
                search();
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
                    search();
                }
            }
            catch (Exception)
            {

            }

        }
        public void refesh()
        {
            this.radioNgayLap.Checked = false;
            this.radioSoDot.Checked = false;
            this.txtSearchSoDot.Text = "";


        }
        private void btThemMoi_Click(object sender, EventArgs e)
        {
            refesh();
            try
            {
                this.errorProvider1.Clear();

                if ("".Equals(this.txtSoDot.Text))
                {
                    this.errorProvider1.SetError(txtSoDot, "Số Đợt Xin Phép Đào Đường Không Được Trống !");
                    this.txtSoDot.Focus();
                }
                else if ("".Equals(this.cbNoiCap.Text))
                {
                    this.errorProvider1.SetError(cbNoiCap, "Nơi Phép Đào Đường Không Được Trống !");
                    this.cbNoiCap.Select();
                }
                else if ("1/1/0001".Equals(dateNgayLap.Value.ToShortDateString()))
                {
                    this.errorProvider1.SetError(dateNgayLap, "Chọn Ngày Lập Đợt Xin Phép Đào Đường !");
                    this.dateNgayLap.Select();
                }
                else if ("".Equals(this.txtMaQuanLy.Text))
                {
                    this.errorProvider1.SetError(txtMaQuanLy, "Mã Quản lý Đợt Không Được Trống !");
                    this.txtMaQuanLy.Focus();
                }
                else if (DAL.C_KH_XinPhepDD.finbyMaDot(this.txtSoDot.Text) != null)
                {
                    this.errorProvider1.SetError(txtSoDot, "Số Đợt Xin Phép Đào Đường Đã Có !");
                    this.txtSoDot.Focus();
                }
                else
                {
                    this.errorProvider1.Clear();
                    Database.KH_XINPHEPDAODUONG xinphep = new Database.KH_XINPHEPDAODUONG();
                    xinphep.MADOT = this.txtSoDot.Text.ToUpper();
                    xinphep.NOICAPPHEP = this.cbNoiCap.Text;
                    xinphep.NGAYLAP = this.dateNgayLap.Value;
                    xinphep.MAQUANLY = this.txtMaQuanLy.Text.ToUpper();
                    if (DAL.C_KH_XinPhepDD.Insert(xinphep) == false)
                    {
                        MessageBox.Show(this, "Lỗi Thêm Xin Phép Đào Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        search();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Them Xin Phep Dao Duong Loi. " + ex.Message);
            }

        }

        public void search()
        {
            string date = "";
            string madotsearch = "";
            if (radioSoDot.Checked)
            {
                madotsearch = txtSearchSoDot.Text;
            }
            if (radioNgayLap.Checked)
            {
                if (!"1/1/0001".Equals(dateTimeSearch.Value.ToShortDateString()))
                {
                    date = Utilities.DateToString.NgayVN(dateTimeSearch.Value);
                }
            }

            try
            {
                rows = DAL.C_KH_XinPhepDD.TotalList(madotsearch, "", date);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            PageTotal();

            this.dataDanhSachDaoDuong.DataSource = DAL.C_KH_XinPhepDD.getList(madotsearch, "", date, FirstRow, pageSize);
        }

        private void radioNgayLap_CheckedChanged(object sender, EventArgs e)
        {

            this.txtSearchSoDot.Visible = false;
            this.dateTimeSearch.Visible = true;
            txtSearchSoDot.Text = "";
            timkiem();
        }

        public void timkiem()
        {
            FirstRow = 0;
            currentPageIndex = 1;
            search();
        }
        private void radioSoDot_CheckedChanged(object sender, EventArgs e)
        {
            this.txtSearchSoDot.Visible = true;
            this.dateTimeSearch.Visible = false;

            timkiem();
        }

        private void txtSearchSoDot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                timkiem();
            }
        }

        private void dateTimeSearch_ValueChanged(object sender, EventArgs e)
        {
            timkiem();
        }

        private void txtSoDot_Leave(object sender, EventArgs e)
        {
            this.txtSoDot.Text = this.txtSoDot.Text.ToUpper();
            this.txtMaQuanLy.Text = this.txtSoDot.Text + "-" + this.cbNoiCap.Text;
            this.txtMaQuanLy.Text = this.txtMaQuanLy.Text.ToUpper();
        }

        private void capnhatDSChoDot_Click(object sender, EventArgs e)
        {
           
        }

    }
}
