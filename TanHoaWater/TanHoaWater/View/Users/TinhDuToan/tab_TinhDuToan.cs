using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;

namespace TanHoaWater.View.Users.TinhDuToan
{
    public partial class tab_TinhDuToan : UserControl
    {
        public tab_TinhDuToan()
        {
            InitializeComponent();
            loadComboboxPhuiDao();
            this.txtSHS.Mask = DateTime.Now.Year.ToString().Substring(2) + "CCCCC";
            this.txtSHS.Focus();
        }
        public void loadComboboxPhuiDao()
        {
            this.pd_MaKetCau.DataSource = DAL.C_DanhMucTaiLapMD.getListDanhMucTLMD();
            this.pd_MaKetCau.ValueMember = "MADANHMUC";
            this.pd_MaKetCau.DisplayMember = "TENKETCAU";
            this.pd_MaKetCau.DropDownWidth = 300;
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
        private void tabTinhDuToan_Click(object sender, EventArgs e)
        {
            this.panelTinhDuToan.Visible = true;
            this.tabControl2.SelectedTabIndex = 0;
            //this.cbNhomVatTu.DataSource = DAL.C_DanhMucVatTu.getListDanhMucVatCobobox();
            //this.cbNhomVatTu.DisplayMember = "TENVT";
            //this.cbNhomVatTu.ValueMember = "MAHIEU";
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
            if (e.KeyChar == 13)
            {
                DataTable table = DAL.C_DonKhachHang.finbyDonKHTinhDuToan(this.txtSHS.Text);
                if (table.Rows.Count <= 0)
                {
                    MessageBox.Show(this, "Không Tìm Thấy Đơn Khách Hàng.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtSHS.Text = "";
                    this.txtSHS.Focus();
                }
                else
                {
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
                    if ("True".Equals(table.Rows[0][13].ToString())) {
                        checkKhoan.Checked = true;
                        txtLoaiKhoan.Text = table.Rows[0][14].ToString();
                        
                    } else {
                        checkKhoan.Checked = false;
                        txtLoaiKhoan.Text = table.Rows[0][14].ToString();
                    }

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
                    GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells[4].Value = "CM";
                }
                else
                {
                    MessageBox.Show(this, "Không Tìm Thấy Mã Hiệu Đơn Giá.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells[0].Selected = true;
                }
            }
        }

        private void GridCacCongTac_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                txtKeypress = e.Control;
                if (GridCacCongTac.CurrentCell.OwningColumn.Name == "congtac_khoiluong")
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