using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using TanHoaWater.Database;

namespace TanHoaWater.View.Users.TinhDuToan
{
    public partial class uct_TinhDuToan : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(uct_TinhDuToan).Name);
        int currentPageIndex = 1;
        int pageSize = 17;
        int pageNumber = 0;
        int FirstRow, LastRow;
        int rows;

        public uct_TinhDuToan(int tab)
        {
            InitializeComponent();
            if (tab == 1) {
                tabControl1.SelectedTabIndex = 0;
            }
            if (tab == 2)
            {
                tabControl1.SelectedTabIndex = 1;
                tab2select();
            }
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
        private void next_Click(object sender, EventArgs e)
        {
            if (currentPageIndex < pageNumber)
            {
                currentPageIndex = currentPageIndex + 1;
                FirstRow = pageSize * (currentPageIndex - 1);
                LastRow = pageSize * (currentPageIndex);
                PageTotal();
                loadDanhMucVatTu();
                
            }

        }
        private void pren_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPageIndex > 1)
                {
                    currentPageIndex = currentPageIndex - 1;
                    FirstRow = pageSize * (currentPageIndex - 1);
                    LastRow = pageSize * (currentPageIndex);
                    PageTotal();
                    loadDanhMucVatTu();
                }
            }
            catch (Exception)
            {

            }
        }

        public void loadDanhMucVatTu() {
            try
            {
                rows = DAL.C_DanhMucVatTu.TotalSearch(this.txtMaHieuVT.Text, this.txtMaHieuDG.Text, txtTenVT.Text, this.cbDVT.Text.Trim(), this.cbNhomVT.Text.Trim(), FirstRow, pageSize);
                GridDanhMucVT.DataSource = DAL.C_DanhMucVatTu.search(this.txtMaHieuVT.Text, this.txtMaHieuDG.Text, txtTenVT.Text, this.cbDVT.Text, this.cbNhomVT.Text, FirstRow, pageSize);
                this.totalRecord.Text = "Tống Cộng Có " + rows + " Danh Mục Vật Tư. ";
                Utilities.DataGridV.formatRows(GridDanhMucVT);
                PageTotal();
                this.groupPanelBoVT.Visible = false;
                this.groupDGVT.Visible = false;
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
        private void tabTinhDuToan_Click(object sender, EventArgs e)
        {
            this.panelTinhDuToan.Visible = true;
            this.panelDanhMucVT.Visible = false;

        }
        void tab2select() {

            try
            {
                rows = DAL.C_DanhMucVatTu.TotalSearch("", "", "", "", "", FirstRow, pageSize);
                GridDanhMucVT.DataSource = DAL.C_DanhMucVatTu.search("", "", "", "", "", FirstRow, pageSize);
                this.totalRecord.Text = "Tống Cộng Có " + rows + " Danh Mục Vật Tư. ";
                Utilities.DataGridV.formatRows(GridDanhMucVT);
                this.cbDVT.DataSource = DAL.C_DonViTinh.getDVT();
                this.cbDVT.ValueMember = "Value";
                this.cbDVT.DisplayMember = "Display";
                this.cbNhomVT.DataSource = DAL.C_NhomVatTu.getNhomVT();
                this.cbNhomVT.ValueMember = "Value";
                this.cbNhomVT.DisplayMember = "Display";
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            PageTotal();
            this.panelTinhDuToan.Visible = false;
            this.panelDanhMucVT.Visible = true;
            this.groupDGVT.Visible = false;
            this.groupPanelBoVT.Visible = false;
        }
        private void tabDanhMucVatTu_Click(object sender, EventArgs e)
        {
            tab2select();

        }
        private Control txtKeypress;
        private void KeyPressHandle(object sender, System.Windows.Forms.KeyPressEventArgs e)
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
        public void visibleTab(bool tabThamSo, bool tabBoiThuong, bool tabNhapPhuidao, bool tabCacCongTac, bool tabItem5) {

            PanelThamSo.Visible = tabThamSo;
            panelBoiThuong.Visible = tabBoiThuong;
            panelNhapPhuiDao.Visible = tabNhapPhuidao;
            panelCacCongTac.Visible = tabCacCongTac;
            panelKhoanCong.Visible = tabItem5;
        }
        private void tabThamSo_Click(object sender, EventArgs e)
        {
            visibleTab(true, false, false, false, false);
        }

        private void tabBoiThuong_Click(object sender, EventArgs e)
        {
            visibleTab(false, true, false, false, false);
        }

        private void tabItem5_Click(object sender, EventArgs e)
        {
            visibleTab(false, false, false, false, true);
        }

        private void tabNhapPhuiDao_Click(object sender, EventArgs e)
        {
            visibleTab(false, false, true, false, false);
        }

        private void tabCacCongTac_Click(object sender, EventArgs e)
        {
            visibleTab(false, false, false, true, false);
        }

        private void GridDanhMucVT_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Utilities.DataGridV.formatRows(GridDanhMucVT);
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            loadDanhMucVatTu();
        }
        string mahieuvtDG = "";
        private void GridDanhMucVT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //bovt_MAHIEU.DataSource = DAL.C_DonViTinh.getList();
            //bovt_MAHIEU.DisplayMember = "DONVI";
            //bovt_MAHIEU.ValueMember = "DONVI";
            try
            {
                string bovt = GridDanhMucVT.Rows[e.RowIndex].Cells[3].Value.ToString();
                if ("Bộ".Equals(bovt))
                {
                    groupDGVT.Visible = false;
                    groupPanelBoVT.Visible = true;
                    mahieuvtDG = GridDanhMucVT.Rows[e.RowIndex].Cells[0].Value.ToString();
                    this.GridDonGiaVT.DataSource = DAL.C_DonGiaVatTu.GetDonGiaVTbyMaHieu(mahieuvtDG);
                    Utilities.DataGridV.formatRows(GridDonGiaVT);
                    groupPanelBoVT.Text = "Danh Sách Vật Tư của bộ Vật Tư : " + mahieuvtDG;
                }
                else
                {
                    groupPanelBoVT.Visible = false;
                    groupDGVT.Visible = true;
                    mahieuvtDG = GridDanhMucVT.Rows[e.RowIndex].Cells[0].Value.ToString();
                    this.GridDonGiaVT.DataSource = DAL.C_DonGiaVatTu.GetDonGiaVTbyMaHieu(mahieuvtDG);
                    Utilities.DataGridV.formatRows(GridDonGiaVT);
                    groupDGVT.Text = "Đơn Giá Vật Tư Của Mã Hiệu Vật Tư : " + mahieuvtDG;
                }
                //DANHMUCVATTU dmvt = DAL.C_DanhMucVatTu.finbyMaHieu(mahieuvtDG);
                //if (dmvt != null) {
                //    this.txtMaHieuVT.Text = dmvt.MAHIEU;
                //    this.txtMaHieuDG.Text = dmvt.MAHDG;
                //    this.txtTenVT.Text = dmvt.TENVT;
                //    this.cbDVT.Text = dmvt.DVT;
                //    this.cbNhomVT.Text = dmvt.NHOMVT;
                //}
            
            }
            catch (Exception)
            {
                
                 
            }
        }

        private void GridDonGiaVT_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Utilities.DataGridV.formatRows(GridDonGiaVT);
        }

        private void GridDonGiaVT_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                txtKeypress = e.Control;
                if (GridDonGiaVT.CurrentCell.OwningColumn.Name == "dg_vatlieu" | GridDonGiaVT.CurrentCell.OwningColumn.Name == "dg_nhanCong" | GridDonGiaVT.CurrentCell.OwningColumn.Name == "dgXiMang" | GridDonGiaVT.CurrentCell.OwningColumn.Name == "phuidao_sl" | GridDonGiaVT.CurrentCell.OwningColumn.Name == "phuidao_cotyle")
                {
                    txtKeypress.KeyPress -= KeyPressHandle;
                    txtKeypress.KeyPress += KeyPressHandle;
                }
                else
                {
                    txtKeypress.KeyPress -= KeyPressHandle;
                }
            }
            catch (Exception)
            {
            }
        }

        private void GridDonGiaVT_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            GridDonGiaVT.Rows[GridDonGiaVT.CurrentRow.Index].Cells[5].Value = Utilities.DateToString.NgayVN(DateTime.Now);
            GridDonGiaVT.Rows[GridDonGiaVT.CurrentRow.Index].Cells[0].Value = GridDonGiaVT.CurrentRow.Index + 1;
            GridDonGiaVT.Rows[GridDonGiaVT.CurrentRow.Index].Cells[1].Value = mahieuvtDG;
        }

        private void btCapNhatDGVT_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < GridDonGiaVT.Rows.Count - 1; i++)
                {
                    int stt = int.Parse(GridDonGiaVT.Rows[i].Cells[0].Value + "");
                    string mahieudg = GridDonGiaVT.Rows[i].Cells[1].Value + "";
                    string check = GridDonGiaVT.Rows[i].Cells[6].Value + "";
                    DONGIAVATTU dgvt = DAL.C_DonGiaVatTu.finbyDonGiaVT(stt, mahieudg);
                    if (dgvt != null)
                    {
                        dgvt.CHON = bool.Parse(check);
                        dgvt.MODIFYBY = DAL.C_USERS._userName;
                        dgvt.MODIFYDATE = DateTime.Now.Date;
                        DAL.C_DonGiaVatTu.UpdateDGVT(dgvt);
                    }
                    else {
                        dgvt = new DONGIAVATTU();
                        dgvt.STT = stt;
                        dgvt.MAHIEUDG = mahieudg;
                        double vt = double.Parse(GridDonGiaVT.Rows[i].Cells[2].Value + "");
                        dgvt.DGVATLIEU = vt;
                        double nc = double.Parse(GridDonGiaVT.Rows[i].Cells[3].Value + "");
                        dgvt.DGNHANCONG = nc;
                        double xm = double.Parse(GridDonGiaVT.Rows[i].Cells[3].Value + "");
                        dgvt.DGXIMANG = xm;
                        dgvt.NGAYHIEULUC = DateTime.Now.Date;
                        dgvt.CHON = bool.Parse(check);
                        dgvt.CREATEBY = DAL.C_USERS._userName;
                        dgvt.CREATEDATE=DateTime.Now.Date;
                        DAL.C_DonGiaVatTu.InsertDGVT(dgvt);
                    }
                }
                MessageBox.Show(this, "Cập Nhật Đơn Giá Vật Tư Thành Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                log.Error("Loi Khi Cap Nhat Don Gia Vat Tu " + ex.Message );
                MessageBox.Show(this, "Cập Nhật Đơn Giá Vật Tư Thất Bại.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            try
            {
                string mavattu = this.txtMaHieuVT.Text;
                string mahieuvattu = this.txtMaHieuDG.Text;
                string tenvt = this.txtTenVT.Text;
                string dvt = this.cbDVT.Text;
                string nhomvt = this.cbNhomVT.Text;
                if ("".Equals(mavattu))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtMaHieuVT, "Nhập Mã Hiệu Vật Tư.");
                    this.txtMaHieuVT.Focus();
                }               
                else if ("".Equals(tenvt))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtTenVT, "Nhập Tên Vật Tư.");
                    this.txtMaHieuVT.Focus();
                }
                else if ("".Equals(dvt))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(cbDVT, "Chọn Đơn Vị Tính");
                    this.txtMaHieuVT.Focus();
                }
                else if ("".Equals(nhomvt))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(cbNhomVT, "Chọn Nhóm Vật Tư.");
                    this.txtMaHieuVT.Focus();
                }
                else if (DAL.C_DanhMucVatTu.finbyMaHieu(mavattu) != null) {
                    errorProvider1.Clear();
                    errorProvider1.SetError(cbNhomVT, "Mã Vật Tư Đã Tồn Tại.");
                    this.txtMaHieuVT.Focus();
                }else{
                    errorProvider1.Clear();
                    DANHMUCVATTU dmvt = new DANHMUCVATTU();
                    dmvt.MAHIEU = mavattu;
                    dmvt.MAHDG = mahieuvattu;
                    dmvt.TENVT = tenvt;
                    dmvt.DVT = dvt;
                    dmvt.NHOMVT = nhomvt;
                    dmvt.CREATEBY = DAL.C_USERS._userName;
                    dmvt.CREATEDATE = DateTime.Now.Date;
                    DAL.C_DanhMucVatTu.InsertDanhMucVT(dmvt);
                    MessageBox.Show(this, "Thêm Mới Danh Mục Vật Tư Thành Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDanhMucVatTu();
                }
                
                
            }
            catch (Exception ex)
            {
                log.Error("Them Danh Muc Vat Tu That Bai " + ex.Message);
                MessageBox.Show(this, "Thêm Mới Danh Mục Vật Tư Thất Bại.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
                string mavattu = this.txtMaHieuVT.Text;
                string mahieuvattu = this.txtMaHieuDG.Text;
                string tenvt = this.txtTenVT.Text;
                string dvt = this.cbDVT.Text;
                string nhomvt = this.cbNhomVT.Text;
                if ("".Equals(mavattu))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtMaHieuVT, "Nhập Mã Hiệu Vật Tư.");
                    this.txtMaHieuVT.Focus();
                }
                else if ("".Equals(tenvt))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtTenVT, "Nhập Tên Vật Tư.");
                    this.txtMaHieuVT.Focus();
                }
                else if ("".Equals(dvt))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(cbDVT, "Chọn Đơn Vị Tính");
                    this.txtMaHieuVT.Focus();
                }
                else if ("".Equals(nhomvt))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(cbNhomVT, "Chọn Nhóm Vật Tư.");
                    this.txtMaHieuVT.Focus();
                }
                else
                {
                    errorProvider1.Clear();
                    DANHMUCVATTU dmvt = DAL.C_DanhMucVatTu.finbyMaHieu(mavattu);
                     try
                     {
                         if (dmvt != null) {
                             DAL.C_DanhMucVatTu.UpdateDanhMucVT(mavattu, mahieuvattu, tenvt, dvt, 0.0, nhomvt, false, DAL.C_USERS._userName);                             
                             MessageBox.Show(this, "Cập Nhật Danh Mục Vật Tư Thành Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             loadDanhMucVatTu();
                         }
                         else {
                             MessageBox.Show(this, "Không Tìm Thấy Mã Hiệu Vật Tư.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             txtMaHieuVT.Focus();
                         }
                     }
                     catch (Exception ex)
                     {
                         log.Error("Cap Nhat Danh Muc Vat Tu That Bai " + ex.Message);
                         MessageBox.Show(this, "Cập Nhật Danh Mục Vật Tư Thất Bại.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                   
                }           
            
        }

        private void btLamLai_Click(object sender, EventArgs e)
        {
            this.txtMaHieuVT.Text="";
            this.txtMaHieuDG.Text = "";
            this.txtTenVT.Text = "";
            this.cbDVT.Text = "";
            this.cbNhomVT.Text = "";
            loadDanhMucVatTu();
            this.errorProvider1.Clear(); 
        }

        private void GridBoVT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
              
                if (e.RowIndex < 0) return;
                else if (e.ColumnIndex == 1)
                {
                    cbyy.Visible = true;
                    cbyy.Top =   this.GridBoVT.Top + GridBoVT.GetRowDisplayRectangle(e.RowIndex, true).Top;
                    cbyy.Left =   this.GridBoVT.Left  + GridBoVT.GetColumnDisplayRectangle(e.ColumnIndex, true).Left;
                    cbyy.Width = GridBoVT.Columns[e.ColumnIndex].Width;
                    cbyy.Height = GridBoVT.Rows[e.RowIndex].Height;
                    cbyy.BringToFront();
                    //  cmbTaiKhoanLuoi.SelectedValue = DatagirdThem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                
            //}
            //catch (Exception)
            //{
            //}
        }

         

        private void GridPhuiDao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(this.GridPhuiDao.Top + "");
             
          
                MessageBox.Show(this.GridPhuiDao.Top + "");
                cbyy.Top = (this.GridPhuiDao.Top + GridPhuiDao.GetRowDisplayRectangle(e.RowIndex, true).Top);
                cbyy.Left = (this.GridPhuiDao.Left + GridPhuiDao.GetColumnDisplayRectangle(e.ColumnIndex, true).Left);
                cbyy.Width = GridPhuiDao.Columns[e.ColumnIndex].Width;
                cbyy.Height = GridPhuiDao.Rows[e.RowIndex].Height;
                cbyy.BringToFront();
                //  cmbTaiKhoanLuoi.SelectedValue = DatagirdThem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
          
        }


         
        //private void GridPhuiDao_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    try
        //    {
        //        txtKeypress = e.Control;
        //        if (GridPhuiDao.CurrentCell.OwningColumn.Name == "phuidao_dai" | GridPhuiDao.CurrentCell.OwningColumn.Name == "phuidao_rong" | GridPhuiDao.CurrentCell.OwningColumn.Name == "pd_Sau" | GridPhuiDao.CurrentCell.OwningColumn.Name == "phuidao_sl" | GridPhuiDao.CurrentCell.OwningColumn.Name == "phuidao_cotyle")
        //        {
        //            txtKeypress.KeyPress -= KeyPressHandle;
        //            txtKeypress.KeyPress += KeyPressHandle;
        //        }
        //        else
        //        {
        //            txtKeypress.KeyPress -= KeyPressHandle;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        

        
    }
}
