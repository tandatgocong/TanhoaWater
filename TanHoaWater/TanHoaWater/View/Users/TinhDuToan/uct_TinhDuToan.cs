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
        private void uct_TinhDuToan_Load(object sender, EventArgs e)
        {
            this.txtSHS.Focus();
        }
        public void loadComboboxPhuiDao()
        {
            this.pd_MaKetCau.DataSource = DAL.C_DanhMucTaiLapMD.getListDanhMucTLMD();
            this.pd_MaKetCau.ValueMember = "MADANHMUC";
            this.pd_MaKetCau.DisplayMember = "TENKETCAU";
            this.pd_MaKetCau.DropDownWidth = 300;
        }
        public uct_TinhDuToan(int tab)
        {
            InitializeComponent();
            if (tab == 1)
            {
                tabControl1.SelectedTabIndex = 0;
                loadComboboxPhuiDao();
                this.txtSHS.Focus();
            }
            if (tab == 2)
            {
                tabControl1.SelectedTabIndex = 1;
                tab2select();
            }
            if (tab == 3)
            {
                tabControl1.SelectedTabIndex = 2;
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
                this.cbNhomVatTu.DataSource = DAL.C_DanhMucVatTu.getListDanhMucVatCobobox();
                this.cbNhomVatTu.DisplayMember = "TENVT";
                this.cbNhomVatTu.ValueMember = "MAHIEU";
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
        public void visibleTab(bool tabThamSo, bool tabBoiThuong, bool tabNhapPhuidao, bool tabCacCongTac, bool tabItem5)
        {

            PanelThamSo.Visible = tabThamSo;
            panelBoiThuong.Visible = tabBoiThuong;
            panelNhapPhuiDao.Visible = tabNhapPhuidao;
            splitContainer1.Panel2.Visible = tabCacCongTac;
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

        private void tabCacCongTac_Click(object sender, EventArgs e)
        {
            visibleTab(false, false, false, true, false);
            congtac_mahieu.DataSource = DAL.C_DanhMucVatTu.getListDanhMucVatCobobox();
            this.congtac_mahieu.DisplayMember = "TENVT";
            this.congtac_mahieu.ValueMember = "MAHIEU";
            congtac_mahieu.DropDownWidth = 300;
            congtac_mahieu.MaxDropDownItems = 5;
            this.cbLoaiSD.DataSource = DAL.C_LoaiSD.getList();
            this.cbLoaiSD.DisplayMember = "MALOAI";
            this.cbLoaiSD.ValueMember = "MALOAI";
        }

        private void GridDanhMucVT_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Utilities.DataGridV.formatRows(GridDanhMucVT);
        }

        private void tabTaiLapMatDuong_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTabIndex = 2;
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
                    else
                    {
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
                        DAL.C_DanhMucVatTu.UpdateDanhMucVT(mavattu, mahieuvattu, tenvt, dvt, 0.0, nhomvt, false, DAL.C_USERS._userName);
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
            try
            {

                if (e.RowIndex < 0) return;
                else if (e.ColumnIndex == 1)
                {
                    cbNhomVatTu.Visible = true;
                    cbNhomVatTu.Top = this.GridBoVT.Top + GridBoVT.GetRowDisplayRectangle(e.RowIndex, true).Top;
                    cbNhomVatTu.Left = this.GridBoVT.Left + GridBoVT.GetColumnDisplayRectangle(e.ColumnIndex, true).Left;
                    cbNhomVatTu.Width = GridBoVT.Columns[e.ColumnIndex].Width;
                    cbNhomVatTu.Height = GridBoVT.Rows[e.RowIndex].Height;
                    cbNhomVatTu.BringToFront();
                    //  cmbTaiKhoanLuoi.SelectedValue = DatagirdThem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            try
            {
                cbNhomVatTu.Visible = false;
                if (table != null)
                {
                    DataRow rows = table.NewRow();
                    rows["MABOVT"] = mahieuvtDG;
                    rows["MAHIEU"] = this.cbNhomVatTu.SelectedValue + "";
                    rows["TENVT"] = catchuoi(this.cbNhomVatTu.Text + "");
                    rows["DM"] = 1;
                    table.Rows.Add(rows);
                }
                else
                {
                    table = new DataTable();
                    DataRow rows = table.NewRow();
                    rows["MABOVT"] = mahieuvtDG;
                    rows["MAHIEU"] = this.cbNhomVatTu.SelectedValue + "";
                    rows["TENVT"] = catchuoi(this.cbNhomVatTu.Text + "");
                    rows["DM"] = 1;
                    table.Rows.Add(rows);
                }
                GridBoVT.DataSource = table;
                Utilities.DataGridV.formatRows(GridBoVT);
            }
            catch (Exception)
            {
            }

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
                loadDanhMucVatTu();
            }
        }

        private void txtMaHieuDG_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
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
                loadDanhMucVatTu();
            }
            catch (Exception)
            {

            }
        }

        private void tabTinhDuToan_Click(object sender, EventArgs e)
        {
            this.panelTinhDuToan.Visible = true;
            this.panelDanhMucVT.Visible = false;
            this.tabControl2.SelectedTabIndex = 0;
            this.cbNhomVatTu.DataSource = DAL.C_DanhMucVatTu.getListDanhMucVatCobobox();
            this.cbNhomVatTu.DisplayMember = "TENVT";
            this.cbNhomVatTu.ValueMember = "MAHIEU";
            loadComboboxPhuiDao();
            this.txtSHS.Focus();

        }

        /// <summary>
        /// Phui Dao
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

               
        private void GridPhuiDao_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[6].Value = "True";
            GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[5].Value = 1;
        }
        private void tabNhapPhuiDao_Click(object sender, EventArgs e)
        {
            visibleTab(false, false, true, false, false);
        }

        private void GridPhuiDao_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DANHMUCTAILAPMATDUONG dmvt = DAL.C_DanhMucTaiLapMD.finbyMaDM(GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[0].Value + "");
                if (dmvt != null)
                {
                    GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[1].Value = dmvt.TENKETCAU.ToUpper();
                }
                else
                {
                    MessageBox.Show(this, "Không Tìm Thấy Mã Kết Cấu.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[0].Selected = true;
                }
            }
        }
        private void GridPhuiDao_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            try
            {
                txtKeypress = e.Control;
                if (GridPhuiDao.CurrentCell.OwningColumn.Name == "phuidao_Daii" | GridPhuiDao.CurrentCell.OwningColumn.Name == "phuidao_rongg" | GridPhuiDao.CurrentCell.OwningColumn.Name == "phuidao_sauu" | GridPhuiDao.CurrentCell.OwningColumn.Name == "phuidao_sll")
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
        /// <summary>
        /// Cac Cong tac
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridCacCongTac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             try
                    {
                        if (e.RowIndex < 0) return;
                        else if (e.ColumnIndex == 4)
                        {
                            //GridPhuiDao.Columns["phudao_MaKetCau"].Width = 300;
                            //GridPhuiDao.Columns["pd_KetCauMD"].Width = 200;
                            cbLoaiSD.Visible = true;
                            cbLoaiSD.Top = this.GridCacCongTac.Top + GridCacCongTac.GetRowDisplayRectangle(e.RowIndex, true).Top;
                            cbLoaiSD.Left = this.GridCacCongTac.Left + GridCacCongTac.GetColumnDisplayRectangle(e.ColumnIndex, true).Left;
                            cbLoaiSD.Width = GridCacCongTac.Columns[e.ColumnIndex].Width;
                            cbLoaiSD.Height = GridCacCongTac.Rows[e.RowIndex].Height;
                            cbLoaiSD.BringToFront();

                        }
                    }
                    catch (Exception)
                    {
                    }
        }

        private void GridCacCongTac_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells[4].Value = "CM";
        }

        private void cbLoaiSD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells[4].Value = cbLoaiSD.SelectedValue + "";
                cbLoaiSD.Visible = false;
            }
            catch (Exception)
            {
                
            }
        }

        private void txtSHS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                DataTable table = DAL.C_DonKhachHang.finbyDonKHTinhDuToan(this.txtSHS.Text);
                if (table.Rows.Count <=0) {
                    MessageBox.Show(this, "Không Tìm Thấy Đơn Khách Hàng.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtSHS.Text = "";
                    this.txtSHS.Focus();
                }else{
                    this.txtHoTen.Text = table.Rows[0][2].ToString();
                    this.txtSoNha.Text = table.Rows[0][4].ToString();
                    this.txtDuong.Text = table.Rows[0][5].ToString();
                    this.txtPhuong.Text = table.Rows[0][6].ToString();
                    this.txtQuan.Text = table.Rows[0][7].ToString();
                    this.txtSoHo.Value = int.Parse(table.Rows[0][8].ToString());
                    this.txtLoaiKH.Text = table.Rows[0][9].ToString();
                    this.txtDanhBo.Text = table.Rows[0][10].ToString();
                    this.txtTenBangThietKe.Text = table.Rows[0][11].ToString();
                    this.txtSoDoVien.Text = table.Rows[0][12].ToString();

                }
            }
        }


        private void GridCacCongTac_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DANHMUCVATTU dmvt = DAL.C_DanhMucVatTu.finbyMaHieu(GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells[0].Value + "");
                if (dmvt != null)
                {
                    GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells[1].Value = dmvt.TENVT.ToUpper();
                    GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells[2].Value = dmvt.DVT;
                }
                else
                {
                    MessageBox.Show(this, "Không Tìm Thấy Mã Hiệu Đơn Giá.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells[0].Selected = true;
                }
            }
        }


        

       

        

        //        private void tabNhapPhuiDao_Click(object sender, EventArgs e)
        //        {
        //            visibleTab(false, false, true, false, false);
        //            loadComboboxPhuiDao();
        //        }
        //        private void GridPhuiDao_CellClick(object sender, DataGridViewCellEventArgs e)
        //        {
        //            try
        //            {
        //                if (e.RowIndex < 0) return;
        //                else if (e.ColumnIndex == 0)
        //                {
        //                    //GridPhuiDao.Columns["phudao_MaKetCau"].Width = 300;
        //                    //GridPhuiDao.Columns["pd_KetCauMD"].Width = 200;
        //                    PhuiDaocbMaKetCau.Visible = true;                    
        //                    PhuiDaocbMaKetCau.Top = this.GridPhuiDao.Top + GridPhuiDao.GetRowDisplayRectangle(e.RowIndex, true).Top;
        //                    PhuiDaocbMaKetCau.Left = this.GridPhuiDao.Left + GridPhuiDao.GetColumnDisplayRectangle(e.ColumnIndex, true).Left;
        //                    PhuiDaocbMaKetCau.Width = GridPhuiDao.Columns[e.ColumnIndex].Width;
        //                    PhuiDaocbMaKetCau.Height = GridPhuiDao.Rows[e.RowIndex].Height;
        //                    PhuiDaocbMaKetCau.BringToFront();

        //                }
        //            }
        //            catch (Exception)
        //            {
        //            }
        //        }        
        //        DataTable phuidao = null;

        //        private void tabTaiLapMatDuong_Click(object sender, EventArgs e)
        //        {
        //            panelTaiLapMD.Controls.Clear();
        //            panelTaiLapMD.Controls.Add(new tab_DanhMucTaiLapMD());
        //        }
        //        private void GridPhuiDao_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //        {
        //        }
        //        void PhuiDao() {
        //            //if (phuidao != null)
        //            //{
        //            //    DataRow rows = phuidao.NewRow();
        //            //    rows["MAKETCAU"] = this.PhuiDaocbMaKetCau.SelectedValue + "";
        //            //    rows["KETCAUMD"] = catchuoi(this.PhuiDaocbMaKetCau.Text + "");
        //            //    rows["DAI"] = 0.0;
        //            //    rows["RONG"] = 0.0;
        //            //    rows["SAU"] = 0.6;
        //            //    rows["SL"] = 1;
        //            //    rows["COTL"] = true;
        //            //    phuidao.Rows.Add(rows);
        //            //}
        //            //else
        //            //{
        //            //    phuidao = new DataTable();
        //            //    phuidao.Columns.Add("MAKETCAU", typeof(string));
        //            //    phuidao.Columns.Add("KETCAUMD", typeof(string));
        //            //    phuidao.Columns.Add("DAI", typeof(double));
        //            //    phuidao.Columns.Add("RONG", typeof(double));
        //            //    phuidao.Columns.Add("SAU", typeof(double));
        //            //    phuidao.Columns.Add("SL", typeof(int));
        //            //    phuidao.Columns.Add("COTL", typeof(bool));

        //            //    DataRow rows = phuidao.NewRow();
        //            //    rows["MAKETCAU"] = this.PhuiDaocbMaKetCau.SelectedValue + "";
        //            //    rows["KETCAUMD"] = catchuoi(this.PhuiDaocbMaKetCau.Text + "");
        //            //    rows["DAI"] = 0.0;
        //            //    rows["RONG"] = 0.0;
        //            //    rows["SAU"] = 0.6;
        //            //    rows["SL"] = 1;
        //            //    rows["COTL"] = true;
        //            //    phuidao.Rows.Add(rows);
        //            //}
        //            //GridPhuiDao.DataSource = phuidao;

        //            GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[0].Value = this.PhuiDaocbMaKetCau.SelectedValue + "";
        //            GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[1].Value = catchuoi(this.PhuiDaocbMaKetCau.Text + "");
        //            //GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[0].Selected = false;
        //            //GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[2].Selected = true;
        //            GridPhuiDao.Columns[GridPhuiDao.CurrentCell.RowIndex].Width = 95;           
        //            Utilities.DataGridV.formatRows(GridPhuiDao);
        //            PhuiDaocbMaKetCau.Visible = false;
        //            GridPhuiDao.Columns["phudao_MaKetCau"].Width = 95;
        //            GridPhuiDao.Columns["pd_KetCauMD"].Width = 200;  
        //        }

        //        private void PhuiDaocbMaKetCau_SelectedValueChanged(object sender, EventArgs e)
        //        {
        //            try
        //            {
        //                PhuiDao();
        //            }
        //            catch (Exception ex)
        //            {

        //            }
        //        }

        //        private void PhuiDaocbMaKetCau_KeyUp(object sender, KeyEventArgs e)
        //        {
        //            PhuiDaocbMaKetCau.DroppedDown = true;
        //        }

        //        private void GridPhuiDao_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        //        {
        //            GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[3].Value = 0;
        //            GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[4].Value = 0;
        //            GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[5].Value = 0.6;
        //            GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[6].Value = true;           
        //        }


        //        /// <summary>
        //        /// Cac Cong Tac
        //        /// </summary>
        //        /// <param name="sender"></param>
        //        /// <param name="e"></param>

        //        private void GridCacCongTac_CellClick(object sender, DataGridViewCellEventArgs e)
        //        {
        //            try
        //            {
        //                if (e.RowIndex < 0) return;
        //                else if (e.ColumnIndex == 0)
        //                {

        //                    CCT_cbMaHieu.Visible = true;
        //                    CCT_cbMaHieu.Top = this.GridCacCongTac.Top + GridCacCongTac.GetRowDisplayRectangle(e.RowIndex, true).Top;
        //                    CCT_cbMaHieu.Left = this.GridCacCongTac.Left + GridCacCongTac.GetColumnDisplayRectangle(e.ColumnIndex, true).Left;
        //                    CCT_cbMaHieu.Width = GridCacCongTac.Columns[e.ColumnIndex].Width;
        //                    CCT_cbMaHieu.Height = GridCacCongTac.Rows[e.RowIndex].Height;
        //                    CCT_cbMaHieu.BringToFront();

        //                }
        //            }
        //            catch (Exception)
        //            {
        //            }
        //        }

        //        private void GridCacCongTac_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //        {
        //            try
        //            {
        //                txtKeypress = e.Control;
        //                if (GridCacCongTac.CurrentCell.OwningColumn.Name == "cct_KhoiLuong")
        //                {
        //                    txtKeypress.KeyPress -= KeyPressHandle;
        //                    txtKeypress.KeyPress += KeyPressHandle;
        //                }
        //                else
        //                {
        //                    txtKeypress.KeyPress -= KeyPressHandle;
        //                }
        //            }
        //            catch (Exception)
        //            {
        //            }
        //        }
        //    }
        //}
    }
}