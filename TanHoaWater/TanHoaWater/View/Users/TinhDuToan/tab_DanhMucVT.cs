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
using System.Text.RegularExpressions;
using TanHoaWater.View.Users.TinhDuToan.BGDieuChinh;
using TanHoaWater.View.Users.BGDieuChinh;

namespace TanHoaWater.View.Users.TinhDuToan
{
    public partial class tab_DanhMucVT : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_DanhMucVT).Name);
        int currentPageIndex = 1;
        int pageSize = 17;
        int pageNumber = 0;
        int FirstRow, LastRow;
        int rows;
        private void uct_TinhDuToan_Load(object sender, EventArgs e)
        {
            //this.txtSHS.Mask = DateTime.Now.Year.ToString().Substring(2) + "CCCCC";
            //this.txtSHS.Focus();
            //this.txtLoaiKH.DataSource = DAL.C_LoaiKhachHang.getList();
            //this.txtLoaiKH.DisplayMember = "TENLOAI";
            //this.txtLoaiKH.ValueMember = "MALOAI";
        }
        public void loadComboboxPhuiDao()
        {
            //this.pd_MaKetCau.DataSource = DAL.C_DanhMucTaiLapMD.getListDanhMucTLMD();
            //this.pd_MaKetCau.ValueMember = "MADANHMUC";
            //this.pd_MaKetCau.DisplayMember = "TENKETCAU";
            //this.pd_MaKetCau.DropDownWidth = 300;
        }
        public tab_DanhMucVT(int tab)
        {
            InitializeComponent();
            if (tab == 1)
            {
                tabControl1.SelectedTabIndex = 0;
                this.tabControlPanel1.Visible = true;
                tabControlPanel1.Controls.Clear();
                tabControlPanel1.Controls.Add(new tab_TinhDuToan());
            }
            if (tab == 2)
            {
                tabControl1.SelectedTabIndex = 2;
                tab2select();
            }
            if (tab == 3)
            {
                tabControl1.SelectedTabIndex = 3;
                panelTaiLapMD.Controls.Clear();
                panelTaiLapMD.Controls.Add(new tab_DanhMucTaiLapMD());
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

        public void loadDanhMucVatTu()
        {
            try
            {
                bool checkBovt = false;
                if (this.checkBoVT.Checked)
                    checkBovt = true;
                rows = DAL.C_DanhMucVatTu.TotalSearch(this.txtMaHieuVT.Text, this.txtMaHieuDG.Text, txtTenVT.Text, this.cbDVT.Text.Trim(), this.cbNhomVT.Text.Trim(), checkBovt);
                GridDanhMucVT.DataSource = DAL.C_DanhMucVatTu.search(this.txtMaHieuVT.Text, this.txtMaHieuDG.Text, txtTenVT.Text, this.cbDVT.Text, this.cbNhomVT.Text, checkBovt, FirstRow, pageSize);
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

        void tab2select()
        {

            try
            {
                rows = DAL.C_DanhMucVatTu.TotalSearch("", "", "", "", "", false);
                GridDanhMucVT.DataSource = DAL.C_DanhMucVatTu.search("", "", "", "", "", false, FirstRow, pageSize);
                this.totalRecord.Text = "Tống Cộng Có " + rows + " Danh Mục Vật Tư. ";
                Utilities.DataGridV.formatRows(GridDanhMucVT);
                this.cbDVT.DataSource = DAL.C_DonViTinh.getDVT();
                this.cbDVT.ValueMember = "Value";
                this.cbDVT.DisplayMember = "Display";
                this.cbNhomVT.DataSource = DAL.C_NhomVatTu.getNhomVT();
                this.cbNhomVT.ValueMember = "Value";
                this.cbNhomVT.DisplayMember = "Display";
                this.bovt_MAHIEU.DataSource = DAL.C_DanhMucVatTu.getListDanhMucVatCobobox();
                this.bovt_MAHIEU.DisplayMember = "TENVT";
                this.bovt_MAHIEU.ValueMember = "MAHIEU";
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            PageTotal();
            //this.panelTinhDuToan.Visible = false;
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
        public void visibleTab(bool tabThamSo, bool tabBoiThuong, bool tabNhapPhuidao, bool tabCacCongTac, bool tabItem5)
        {

            PanelThamSo.Visible = tabThamSo;
            //panelBoiThuong.Visible = tabBoiThuong;
            //panelNhapPhuiDao.Visible = tabNhapPhuidao;
            //splitContainer1.Panel2.Visible = tabCacCongTac;
            //panelKhoanCong.Visible = tabItem5;
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

        private void tabCacCongTac_Click(object sender, EventArgs e)
        {
            visibleTab(false, false, false, true, false);
            //congtac_mahieu.DataSource = DAL.C_DanhMucVatTu.getListDanhMucVatCobobox();
            //this.congtac_mahieu.DisplayMember = "TENVT";
            //this.congtac_mahieu.ValueMember = "MAHIEU";
            //congtac_mahieu.DropDownWidth = 300;
            //congtac_mahieu.MaxDropDownItems = 5;
            //this.cbLoaiSD.DataSource = DAL.C_LoaiSD.getList();
            //this.cbLoaiSD.DisplayMember = "MALOAI";
            //this.cbLoaiSD.ValueMember = "MALOAI";
        }

        private void GridDanhMucVT_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Utilities.DataGridV.formatRows(GridDanhMucVT);
        }

        private void tabTaiLapMatDuong_Click(object sender, EventArgs e)
        {
            panelTaiLapMD.Controls.Clear();
            panelTaiLapMD.Controls.Add(new tab_DanhMucTaiLapMD());
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            loadDanhMucVatTu();
        }
        string mahieuvtDG = "";
        private void GridDanhMucVT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string bovt = GridDanhMucVT.Rows[e.RowIndex].Cells[5].Value.ToString();
                if ("True".Equals(bovt))
                {
                    groupDGVT.Visible = false;
                    groupPanelBoVT.Visible = true;
                    mahieuvtDG = GridDanhMucVT.Rows[e.RowIndex].Cells[0].Value.ToString();
                    LoadDanhMucBoVT(mahieuvtDG);
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
                if (GridDonGiaVT.CurrentCell.OwningColumn.Name == "dg_vatlieu" | GridDonGiaVT.CurrentCell.OwningColumn.Name == "dg_nhanCong" | GridDonGiaVT.CurrentCell.OwningColumn.Name == "dgXiMang")
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

        private void btCapNhatDGVT_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < GridDonGiaVT.Rows.Count-1; i++)
                {
                    int stt = int.Parse(GridDonGiaVT.Rows[i].Cells[0].Value + "");
                    string mahieudg = GridDonGiaVT.Rows[i].Cells[1].Value + "";
                    string check = GridDonGiaVT.Rows[i].Cells[6].Value + "";
                    DONGIAVATTU dgvt = DAL.C_DonGiaVatTu.finbyDonGiaVT(stt, mahieudg);
                    if (dgvt != null)
                    {
                        dgvt.CHON = bool.Parse(check);
                        double vt = double.Parse(GridDonGiaVT.Rows[i].Cells["dg_vatlieu"].Value + "");
                        dgvt.DGVATLIEU = vt;
                        double nc = double.Parse(GridDonGiaVT.Rows[i].Cells["dg_nhanCong"].Value + "");
                        dgvt.DGNHANCONG = nc;
                        double xm = double.Parse(GridDonGiaVT.Rows[i].Cells["dgXiMang"].Value + "");
                        dgvt.MODIFYBY = DAL.C_USERS._userName;
                        dgvt.MODIFYDATE = DateTime.Now.Date;
                        DAL.C_DonGiaVatTu.UpdateDGVT(dgvt);
                    }
                    else
                    {
                        dgvt = new DONGIAVATTU();
                        dgvt.STT = stt;
                        dgvt.MAHIEUDG = mahieudg;
                        double vt = double.Parse(GridDonGiaVT.Rows[i].Cells["dg_vatlieu"].Value + "");
                        dgvt.DGVATLIEU = vt;
                        double nc = double.Parse(GridDonGiaVT.Rows[i].Cells["dg_nhanCong"].Value + "");
                        dgvt.DGNHANCONG = nc;
                        double xm = double.Parse(GridDonGiaVT.Rows[i].Cells["dgXiMang"].Value + "");
                        dgvt.DGMAYTHICONG = xm;
                        dgvt.NGAYHIEULUC = DateTime.Now.Date;
                        dgvt.CHON = bool.Parse(check);
                        dgvt.CREATEBY = DAL.C_USERS._userName;
                        dgvt.CREATEDATE = DateTime.Now.Date;
                        DAL.C_DonGiaVatTu.InsertDGVT(dgvt);
                    }
                }
                MessageBox.Show(this, "Cập Nhật Đơn Giá Vật Tư Thành Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                log.Error("Loi Khi Cap Nhat Don Gia Vat Tu " + ex.Message);
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
                else if (DAL.C_DanhMucVatTu.finbyMaHieu(mavattu) != null)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(cbNhomVT, "Mã Vật Tư Đã Tồn Tại.");
                    this.txtMaHieuVT.Focus();
                }
                else
                {
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
                    if (dmvt != null)
                    {
                        bool bovt = false;
                        if (this.checkBoVT.Checked)
                            bovt = true;
                        else
                            bovt = false;

                        DAL.C_DanhMucVatTu.UpdateDanhMucVT(mavattu, mahieuvattu, tenvt, dvt, 0.0, nhomvt, bovt, DAL.C_USERS._userName);
                        MessageBox.Show(this, "Cập Nhật Danh Mục Vật Tư Thành Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDanhMucVatTu();
                    }
                    else
                    {
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
            this.txtMaHieuVT.Text = "";
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

            //    if (e.RowIndex < 0) return;
            //    else if (e.ColumnIndex == 1)
            //    {
            //        cbNhomVatTu.Visible = true;
            //        cbNhomVatTu.Top = this.GridBoVT.Top + GridBoVT.GetRowDisplayRectangle(e.RowIndex, true).Top;
            //        cbNhomVatTu.Left = this.GridBoVT.Left + GridBoVT.GetColumnDisplayRectangle(e.ColumnIndex, true).Left;
            //        cbNhomVatTu.Width = GridBoVT.Columns[e.ColumnIndex].Width;
            //        cbNhomVatTu.Height = GridBoVT.Rows[e.RowIndex].Height;
            //        cbNhomVatTu.BringToFront();
            //        //  cmbTaiKhoanLuoi.SelectedValue = DatagirdThem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        public string catchuoi(string line)
        {
            string[] words = Regex.Split(line, "______");
            return words[1];
        }
        DataTable table;
        public void LoadDanhMucBoVT(string mabovt)
        {
            table = DAL.C_DanhMucBoVT.getByMaBoVT(mabovt);
            GridBoVT.DataSource = table;
            Utilities.DataGridV.formatRows(GridBoVT);
        }
        private void cbNhomVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    cbNhomVatTu.Visible = false;
            //    if (table != null)
            //    {
            //        DataRow rows = table.NewRow();
            //        rows["MABOVT"] = mahieuvtDG;
            //        rows["MAHIEU"] = this.cbNhomVatTu.SelectedValue + "";
            //        rows["TENVT"] = catchuoi(this.cbNhomVatTu.Text + "");
            //        rows["DM"] = 1;
            //        table.Rows.Add(rows);
            //    }
            //    else
            //    {
            //        table = new DataTable();
            //        DataRow rows = table.NewRow();
            //        rows["MABOVT"] = mahieuvtDG;
            //        rows["MAHIEU"] = this.cbNhomVatTu.SelectedValue + "";
            //        rows["TENVT"] = catchuoi(this.cbNhomVatTu.Text + "");
            //        rows["DM"] = 1;
            //        table.Rows.Add(rows);
            //    }
            //    GridBoVT.DataSource = table;
            //    Utilities.DataGridV.formatRows(GridBoVT);
            //}
            //catch (Exception)
            //{
            //}

        }

        private void btCapNhatBoVT_Click(object sender, EventArgs e)
        {
            try
            {
                #region Delete Truoc Khi Insert
                DAL.C_DanhMucBoVT.deletebyMaBoVT(mahieuvtDG);
                #endregion
                for (int i = 0; i < GridBoVT.Rows.Count; i++)
                {
                    string mahieu = this.GridBoVT.Rows[i].Cells[1].Value + "";
                    if (!"".Equals(mahieu) && DAL.C_DanhMucVatTu.finbyMaHieu(mahieu) != null && DAL.C_DanhMucBoVT.findBoVT(mahieuvtDG, mahieu) == null)
                    {
                        DANHMUCBOVATTU dmbovt = new DANHMUCBOVATTU();
                        dmbovt.MABOVT = mahieuvtDG;
                        dmbovt.MAHIEU = mahieu;
                        dmbovt.TENVT = this.GridBoVT.Rows[i].Cells[2].Value + "";
                        dmbovt.DM = int.Parse(this.GridBoVT.Rows[i].Cells[3].Value + "");
                        dmbovt.CREATEBY = DAL.C_USERS._userName;
                        dmbovt.CREATEDATE = DateTime.Now.Date;
                        DAL.C_DanhMucBoVT.InsertBoVT(dmbovt);

                    }
                }
                MessageBox.Show(this, "Cập Nhật Danh Mục Bộ Vật Tư Thành Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhMucBoVT(mahieuvtDG);
            }
            catch (Exception ex)
            {
                log.Error("Cap Nhat Bo Vat Tu Loi" + ex.Message);
                MessageBox.Show(this, "Cập Nhật Danh Mục Bộ Vật Tư Không Thành Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GridDonGiaVT_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            GridDonGiaVT.Rows[GridDonGiaVT.CurrentRow.Index].Cells[5].Value = Utilities.DateToString.NgayVN(DateTime.Now);
            GridDonGiaVT.Rows[GridDonGiaVT.CurrentRow.Index].Cells[0].Value = GridDonGiaVT.CurrentRow.Index + 1;
            GridDonGiaVT.Rows[GridDonGiaVT.CurrentRow.Index].Cells[1].Value = mahieuvtDG;

        }


        private void GridBoVT_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                txtKeypress = e.Control;
                if (GridBoVT.CurrentCell.OwningColumn.Name == "bovt_dinhmuc")
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

        private void txtMaHieuVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DANHMUCVATTU dmvt = DAL.C_DanhMucVatTu.finbyMaHieu(txtMaHieuVT.Text);
                if (dmvt != null) {
                    this.txtMaHieuDG.Text = dmvt.MAHDG;
                    this.txtTenVT.Text = dmvt.TENVT;
                    this.cbDVT.Text = dmvt.DVT;
                    this.cbNhomVT.Text = dmvt.NHOMVT;
                    if (dmvt.BOVT == true)
                        this.checkBoVT.Checked = true;
                    else
                        this.checkBoVT.Checked = false;
                }
                else {
                    MessageBox.Show(this, "Không Tìm Thấy Mã Hiệu Vật Tư.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtMaHieuDG_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    currentPageIndex = 1;
                    pageNumber = 0;
                    FirstRow = 0;
                    LastRow = 0;
                    loadDanhMucVatTu();
                }
            }
            catch (Exception)
            {

            }

        }

        private void txtTenVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    currentPageIndex = 1;
                    pageNumber = 0;
                    FirstRow = 0;
                    LastRow = 0;
                    loadDanhMucVatTu();
                }
            }
            catch (Exception)
            {

            }
        }

        private void cbDVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                currentPageIndex = 1;
                pageNumber = 0;
                FirstRow = 0;
                LastRow = 0;
                loadDanhMucVatTu();
            }
            catch (Exception)
            {

            }
        }

        private void cbNhomVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                currentPageIndex = 1;
                pageNumber = 0;
                FirstRow = 0;
                LastRow = 0;
                loadDanhMucVatTu();
            }
            catch (Exception)
            {

            }
        }

        private void checkBoVT_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                currentPageIndex = 1;
                pageNumber = 0;
                FirstRow = 0;
                LastRow = 0;
                loadDanhMucVatTu();
            }
            catch (Exception)
            {

            }
        }

        private void tabTinhDuToan_Click(object sender, EventArgs e)
        {
            this.tabControlPanel1.Visible = true;
            tabControlPanel1.Controls.Clear();
            tabControlPanel1.Controls.Add(new tab_TinhDuToan());
            this.panelDanhMucVT.Visible = false;            
            //this.cbNhomVatTu.DataSource = DAL.C_DanhMucVatTu.getListDanhMucVatCobobox();
            //this.cbNhomVatTu.DisplayMember = "TENVT";
            //this.cbNhomVatTu.ValueMember = "MAHIEU";
            //loadComboboxPhuiDao();
 
        }

        private void GridBoVT_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                DANHMUCVATTU dmvt = DAL.C_DanhMucVatTu.finbyMaHieu(GridBoVT.Rows[GridBoVT.CurrentRow.Index].Cells["bovt_MAHIEU"].Value + "");
                if (dmvt != null)
                {

                    GridBoVT.Rows[GridBoVT.CurrentRow.Index].Cells["bovt_TENVT"].Value = dmvt.TENVT.ToUpper();
                    GridBoVT.Rows[GridBoVT.CurrentRow.Index].Cells["bovt_dinhmuc"].Value = 1;                     
                }
                else
                {
                    MessageBox.Show(this, "Không Tìm Thấy Mã Hiệu Đơn Giá.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GridBoVT.Rows[GridBoVT.CurrentRow.Index].Cells["bovt_MAHIEU"].Selected = true;
                }
            }
        }

        private void GridDonGiaVT_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
         
        }

        private void tabItem2_Click(object sender, EventArgs e)
        {
            panelThongSoBG.Controls.Clear();
            panelThongSoBG.Controls.Add(new tabThongSoBG());
        }

        private void tabItem3_Click(object sender, EventArgs e)
        {
            tabControlPanel4.Controls.Clear();
            tabControlPanel4.Controls.Add(new tab_BangGiaDieuChinh());
        }

        private void GridDonGiaVT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    for (int i = 0; i < GridDonGiaVT.Rows.Count; i++)
                    {
                        this.GridDonGiaVT.Rows[i].Cells["dg_Chon"].Value = "False";
                    }
                    this.GridDonGiaVT.Rows[e.RowIndex].Cells["dg_Chon"].Value = "True";

                }
            }
            catch (Exception)
            {

            }
        }

        private void tabAmSauDoi_Click(object sender, EventArgs e)
        {
            this.tabControlPanel6.Visible = true;
            tabControlPanel6.Controls.Clear();
            tabControlPanel6.Controls.Add(new tab_TinhDuToan2015());
            this.panelDanhMucVT.Visible = false;       
        }

     
    }
}