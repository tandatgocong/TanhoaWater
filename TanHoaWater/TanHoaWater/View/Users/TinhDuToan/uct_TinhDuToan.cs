using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;

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
                bool check = false;
                if (chekBoVT.Checked == true) {
                    check = true;
                } else {
                    check = false;
                }
                rows = DAL.C_DanhMucVatTu.TotalSearch(this.txtMaHieuVT.Text, this.txtMaHieuDG.Text, txtTenVT.Text, this.cbDVT.SelectedText, this.cbNhomVT.SelectedText, check, FirstRow, pageSize);
                GridDanhMucVT.DataSource = DAL.C_DanhMucVatTu.search(this.txtMaHieuVT.Text, this.txtMaHieuDG.Text, txtTenVT.Text, this.cbDVT.SelectedText, this.cbNhomVT.SelectedText, check, FirstRow, pageSize);
                this.totalRecord.Text = "Tống Cộng Có " + rows + " Danh Mục Vật Tư. ";
                Utilities.DataGridV.formatRows(GridDanhMucVT);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
        private void tabDanhMucVatTu_Click(object sender, EventArgs e)
        {
            try
            {
                rows = DAL.C_DanhMucVatTu.TotalSearch("", "", "", "", "", false, FirstRow, pageSize);
                GridDanhMucVT.DataSource = DAL.C_DanhMucVatTu.search("", "", "", "", "", false, FirstRow, pageSize);
                this.totalRecord.Text = "Tống Cộng Có " + rows + " Danh Mục Vật Tư. ";
                Utilities.DataGridV.formatRows(GridDanhMucVT);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            PageTotal();

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
