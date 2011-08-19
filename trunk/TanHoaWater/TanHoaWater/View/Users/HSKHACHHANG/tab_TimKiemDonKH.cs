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

namespace TanHoaWater.View.Users.HSKHACHHANG
{
    public partial class tab_TimKiemDonKH : UserControl
    {
        int currentPageIndex = 1;
        int pageSize = 7;
        int pageNumber = 0;
        int FirstRow, LastRow;
        int rows;
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_TimKiemDonKH).Name);
        public tab_TimKiemDonKH()
        {
            InitializeComponent();
           
        }

        private void PageTotal()
        {
            try
            {
                pageNumber = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                lbPaing.Text = currentPageIndex + "/" + pageNumber;
            }
            catch (Exception)
            {
                
            }

        }
         
        public void search() {
            try
            {
                rows = DAL.C_DONKHACHHANG.TotalPageSearch(SearchDotNhanDon.Text, this.SearchMaHoSo.Text, this.searchHoTenKH.Text, this.searchSoNha.Text, this.searchDiaChi.Text);
                PageTotal();
                this.dataSearCh.DataSource = DAL.C_DONKHACHHANG.search(SearchDotNhanDon.Text, this.SearchMaHoSo.Text, this.searchHoTenKH.Text, this.searchSoNha.Text, this.searchDiaChi.Text, FirstRow, pageSize);
                Utilities.DataGridV.formatRows(dataSearCh);

            }
            catch (Exception ex){
                log.Error(ex.Message);
            }

        }
        private void searchTimKiem_Click(object sender, EventArgs e)
        {
            search();
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

        private void txtDotNhanDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { search(); }
        }

        private void SearchMaHoSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { search(); }
        }

        private void searchHoTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { search(); }
        }

        private void searchSoNha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { search(); }
        }

        private void searchDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { search(); }
        }

        private void searchLamLai_Click(object sender, EventArgs e)
        {
            this.searchDiaChi.Text = null;
            this.searchHoTenKH.Text = null;
            this.SearchMaHoSo.Text = null;
            this.searchSoNha.Text = null;
            this.SearchDotNhanDon.Text = null;
            this.cbQuan.DataSource = null;
            this.cbPhuong.DataSource = null;
            this.cbLoaiHS.DataSource = null;
            this.cbLoaiKH.DataSource = null;
            this.cbDotNhanDon.DataSource = null;
                       
        }

        public void loadAllCombox() {
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
            this.cbDotNhanDon.DataSource = DAL.C_DOTNHANDON.getALL();
            this.cbDotNhanDon.DisplayMember = "MADOT";
            this.cbDotNhanDon.ValueMember = "MADOT";
            #endregion                
        }
        private void dataSearCh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string _soHoSo = this.dataSearCh.Rows[e.RowIndex].Cells[1].Value !=null? this.dataSearCh.Rows[e.RowIndex].Cells[1].Value.ToString() : null;
                if (_soHoSo != null) {
                    loadAllCombox();
                    Database.DON_KHACHHANG donkh= DAL.C_DONKHACHHANG.findBySOHOSO(_soHoSo);
                    if (donkh != null) {
                        this.txtSHS.Text = donkh.SHS;
                        this.txtSoHoSo.Text = donkh.SOHOSO;
                        this.txtSoHo.Value = decimal.Parse(donkh.SOHO.ToString());
                        this.txtHoTen.Text = donkh.HOTEN;
                        this.sonha.Text = donkh.SONHA;
                        this.duong.Text = donkh.DUONG;
                        // select Quan
                        cbQuan.Text = DAL.C_QUAN.finByMaQuan(donkh.QUAN).TENQUAN;
                        // select Phuong
                        cbPhuong.Text = DAL.C_PHUONG.finbyPhuong(donkh.QUAN, donkh.PHUONG).TENPHUONG;
                        //select loaiKH
                        cbLoaiKH.Text = DAL.C_LOAIKH.finbyMaLoai(donkh.LOAIKH).TENLOAI;
                        // select loaiHoso
                        cbLoaiHS.Text = DAL.C_LOAIHOSO.findbyMaLoai(donkh.LOAIHOSO).TENLOAI;
                        this.cbDotNhanDon.Text = donkh.MADOT;
                        this.dienthoai.Text = donkh.DIENTHOAI;
                        this.ghichu.Text = donkh.GHICHU;
                        if (donkh.HOSOKHAN == true)
                        {
                            this.khan.Checked = true;
                            this.ghichuKhan.Visible = true;
                            this.ghichuKhan.Text = donkh.GHICHUKHAN;
                        }
                        else
                        {
                            this.khan.Checked = false;
                            this.ghichuKhan.Visible = false;
                            this.ghichuKhan.Text = null;
                        }
                        if (donkh.CHUYEN_HOSO == true)
                        {
                            this.chuyenhoso.Checked = true;
                            this.bophanChuyen.Visible = true;
                            // load bo phan chuyen
                        }
                        else {
                            this.chuyenhoso.Checked = false;
                            this.bophanChuyen.Visible = false;
                        }
                    
                    }
                }
                
            }
            catch (Exception)
            {
            }
        }

        private void khan_CheckedChanged(object sender, EventArgs e)
        {
            if (khan.Checked) {
                this.ghichuKhan.Visible = true;
            } else {
                this.ghichuKhan.Visible = false;
            }
        }

        private void chuyenhoso_CheckedChanged(object sender, EventArgs e)
        {
            this.bophanChuyen.DataSource = DAL.C_PHONGBAN.getList();
            this.bophanChuyen.DisplayMember = "TENPHONG";
            this.bophanChuyen.ValueMember = "MAPHONG";
            if (chuyenhoso.Checked) {
                this.bophanChuyen.Visible = true;
            } else {
                this.bophanChuyen.Visible = true;
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
    }
}
