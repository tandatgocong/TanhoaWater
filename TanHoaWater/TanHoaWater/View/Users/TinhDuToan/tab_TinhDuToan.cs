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
            pd_MaKetCau.AutoComplete = true;
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
                    mahieuvt = dmvt.MADANHMUC;
                    GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[1].Value = dmvt.TENKETCAU.ToUpper();
                    GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[7].Value = dmvt.DONGIA; 
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
        public void DuToan()
        {
            mahieuvt = "";
            double sumChuViNhua = 0.0, sumkhoiluongNhua = 0.0;
            double sumChuViBT = 0.0, sumkhoiluongBT = 0.0;
            double sumDatC4 = 0.0, sumDatC3 = 0.0, sumxutDat = 0.0;
            double sumTheTich = 0.0;
            double sumKLDa4 = 0.0;
            double sumKLCat = 0.0;
            double SODHN = 0.0;

            for (int i = 0; i < GridPhuiDao.Rows.Count - 1; i++)
            {
                mahieuvt = GridPhuiDao.Rows[i].Cells[0].Value + "";
                if (!"".Equals(mahieuvt) && ("N12B".Equals(mahieuvt) || "N12C".Equals(mahieuvt)))
                {
                    sumChuViNhua += double.Parse(GridPhuiDao.Rows[i].Cells[9].Value + "");
                    sumkhoiluongNhua += double.Parse(GridPhuiDao.Rows[i].Cells[8].Value + "") * 0.12;
                    sumDatC4 += double.Parse(GridPhuiDao.Rows[i].Cells[8].Value + "") * 0.4;
                }
                else if (!"".Equals(mahieuvt) && ("NHUA10".Equals(mahieuvt) || "NHUA10-C3".Equals(mahieuvt)))
                {
                    sumChuViNhua += double.Parse(GridPhuiDao.Rows[i].Cells[9].Value + "");
                    sumkhoiluongNhua += double.Parse(GridPhuiDao.Rows[i].Cells[8].Value + "") * 0.1;
                    sumDatC4 += double.Parse(GridPhuiDao.Rows[i].Cells[8].Value + "") * 0.3;
                }
                else if (!"".Equals(mahieuvt) && ("BT10".Contains(mahieuvt)))
                {
                    sumChuViBT += double.Parse(GridPhuiDao.Rows[i].Cells[9].Value + "");
                    sumkhoiluongBT += double.Parse(GridPhuiDao.Rows[i].Cells[8].Value + "") * 0.1;
                    sumDatC4 += double.Parse(GridPhuiDao.Rows[i].Cells[8].Value + "") * 0.3;
                }
                else if (!"".Equals(mahieuvt) && ("DXANH".Equals(mahieuvt)))
                {
                    sumDatC4 += double.Parse(GridPhuiDao.Rows[i].Cells[8].Value + "") * 0.25;
                }
                else if (!"".Equals(mahieuvt) && ("DDO".Equals(mahieuvt)))
                {
                    sumDatC4 += double.Parse(GridPhuiDao.Rows[i].Cells[8].Value + "") * 0.25;
                }
                else if (!"".Equals(mahieuvt) && ("TNHA".Equals(mahieuvt)))
                {
                    //sumDatC4 += double.Parse(GridPhuiDao.Rows[i].Cells[8].Value + "")  ; 
                    SODHN += double.Parse(GridPhuiDao.Rows[i].Cells[2].Value + "");
                }
                else
                {
                    sumChuViBT += double.Parse(GridPhuiDao.Rows[i].Cells[9].Value + "");
                    sumkhoiluongBT += double.Parse(GridPhuiDao.Rows[i].Cells[8].Value + "") * 0.05;
                    sumDatC4 += double.Parse(GridPhuiDao.Rows[i].Cells[8].Value + "") * 0.1;
                }
                sumTheTich += double.Parse(GridPhuiDao.Rows[i].Cells[10].Value + "");
                if (!"".Equals(mahieuvt) && !("TNHA".Equals(mahieuvt)))
                {
                    sumKLDa4 += double.Parse(GridPhuiDao.Rows[i].Cells[8].Value + "") * 0.1;
                }
                //If TLAP!Loai <> "TNHA" Then
                //        sumKLDa += 4 + (TLAP!DT * 0.1) double.Parse(GridPhuiDao.Rows[i].Cells[8].Value + "") * 0.1;  
                //   End If              }

                //sumKLCat = sumTheTich - sumKLDa4 - SODHN * 0.18;
                //sumDatC3 = sumTheTich - (sumkhoiluongNhua + sumkhoiluongBT + sumDatC4);
            }
            sumxutDat = sumTheTich;
            sumKLCat = sumTheTich - sumKLDa4 - SODHN * 0.18;
            sumDatC3 = Math.Round(sumTheTich, 2) - (Math.Round(sumkhoiluongNhua, 2) + Math.Round(sumkhoiluongBT, 2) + Math.Round(sumDatC4, 2));
            this.txtKhoiLuongCatNhua.Text = String.Format("{0:0.00}", sumkhoiluongNhua);
            this.txtChuViCatNhua.Text = String.Format("{0:0.00}", sumChuViNhua);
            this.txtKhoiLuongBT.Text = String.Format("{0:0.00}", sumkhoiluongBT);
            this.txtChuViBT.Text = String.Format("{0:0.00}", sumChuViBT);
            this.txtDatCap4.Text = String.Format("{0:0.00}", sumDatC4);
            this.txtDatCap3.Text = String.Format("{0:0.00}", sumDatC3);
            this.txtXucDatThua.Text = String.Format("{0:0.00}", sumxutDat);
            this.txtKLDa.Text = String.Format("{0:0.00}", sumKLDa4);
            this.txtKLCat.Text = String.Format("{0:0.00}", sumKLCat);
        }
        private void GridPhuiDao_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
                {
                    double dai = double.Parse(GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[2].Value + "");
                    double rong = double.Parse(GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[3].Value + "");
                    double sau = double.Parse(GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[4].Value + "");
                    int soluong = int.Parse(GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[5].Value + "");
                    double khoiluong = 0.0;
                    double chuvi = 0.0;
                    double thetich = 0.0;
                    if (dai >= 0 && rong >= 0 && soluong >= 1 && sau > 0)
                    {
                        khoiluong = dai * rong * soluong;
                        if (rong > 0.3)
                            chuvi = (dai + rong) * 2 * soluong;
                        else
                            chuvi = dai * 2 * soluong;
                        thetich = dai * rong * sau * soluong;
                    }
                    GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[8].Value = Math.Round(khoiluong, 3);
                    GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[9].Value = Math.Round(chuvi, 3);
                    GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[10].Value = Math.Round(thetich, 3);

                    DuToan();
                }

            }
            catch (Exception)
            {

            }

        }

        private void GridPhuiDao_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                DuToan();
            }
            catch (Exception)
            {
            }

        }

        private void GridPhuiDao_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < GridPhuiDao.RowCount - 1)
                {
                    //  MessageBox.Show(this,"Dữ Liệu Không Được trống và lớn hơn 0 !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ("".Equals(this.GridPhuiDao.Rows[e.RowIndex].Cells["phuidao_Daii"].Value) || this.GridPhuiDao.Rows[e.RowIndex].Cells["phuidao_Daii"].Value == null || Convert.ToDouble(this.GridPhuiDao.Rows[e.RowIndex].Cells["phuidao_Daii"].Value.ToString()) <= 0)
                    {
                        this.GridPhuiDao.Rows[e.RowIndex].Cells["phuidao_Daii"].ErrorText = "Dữ Liệu Không Được trống và lớn hơn 0 !";

                    }
                    else
                    {
                        this.GridPhuiDao.Rows[e.RowIndex].Cells["phuidao_Daii"].ErrorText = null;
                    }

                    if ("".Equals(this.GridPhuiDao.Rows[e.RowIndex].Cells["phuidao_rongg"].Value) || this.GridPhuiDao.Rows[e.RowIndex].Cells["phuidao_rongg"].Value == null || Convert.ToDouble(this.GridPhuiDao.Rows[e.RowIndex].Cells["phuidao_rongg"].Value.ToString()) <= 0)
                    {
                        this.GridPhuiDao.Rows[e.RowIndex].Cells["phuidao_rongg"].ErrorText = "Dữ Liệu Không Được trống và lớn hơn 0!";

                    }
                    else
                    {
                        this.GridPhuiDao.Rows[e.RowIndex].Cells["phuidao_rongg"].ErrorText = null;
                    }

                    if ("".Equals(this.GridPhuiDao.Rows[e.RowIndex].Cells["phuidao_sauu"].Value) || this.GridPhuiDao.Rows[e.RowIndex].Cells["phuidao_sauu"].Value == null || Convert.ToDouble(this.GridPhuiDao.Rows[e.RowIndex].Cells["phuidao_sauu"].Value.ToString()) <= 0)
                    {
                        this.GridPhuiDao.Rows[e.RowIndex].Cells["phuidao_sauu"].ErrorText = "Dữ Liệu Không Được trống và lớn hơn 0!";

                    }
                    else
                    {
                        this.GridPhuiDao.Rows[e.RowIndex].Cells["phuidao_sauu"].ErrorText = null;
                    }

                    if ("".Equals(this.GridPhuiDao.Rows[e.RowIndex].Cells["phuidao_sll"].Value) || this.GridPhuiDao.Rows[e.RowIndex].Cells["phuidao_sll"].Value == null || Convert.ToDouble(this.GridPhuiDao.Rows[e.RowIndex].Cells["phuidao_sll"].Value.ToString()) <= 0)
                    {
                        this.GridPhuiDao.Rows[e.RowIndex].Cells["phuidao_sll"].ErrorText = "Dữ Liệu Không Được trống và lớn hơn 0!";

                    }
                    else
                    {
                        this.GridPhuiDao.Rows[e.RowIndex].Cells["phuidao_sll"].ErrorText = null;
                    }
                }
            }
            catch (Exception)
            {}
        }

        /// <summary>
        /// Cac Cong tac
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        bool cacongtac = true;
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
            try
            {
                string CNHUA = this.txtChuViCatNhua.Text;
                string BOCNHUA = this.txtKhoiLuongCatNhua.Text;
                string CMBTXM = this.txtChuViBT.Text;
                string BMBTXM = this.txtKhoiLuongBT.Text;
                string DP4 = this.txtDatCap4.Text;
                string DP3 = this.txtDatCap3.Text;
                string XUCDAT = this.txtXucDatThua.Text;
                string CAT = this.txtKLCat.Text;
                string DA04 = this.txtKLDa.Text;
                string selectin = "";
                // GridCacCongTac   
                //// if (cacongtac) {
                if (!"".Equals(CNHUA) && double.Parse(CNHUA) > 0.0)
                {
                    selectin += "'CNHUA',";
                }
                if (!"".Equals(BOCNHUA) && double.Parse(BOCNHUA) > 0.0)
                {
                    selectin += "'BNHUA',";
                }
                if (!"".Equals(CMBTXM) && double.Parse(CMBTXM) > 0.0)
                {
                    selectin += "'CMBTXM',";
                }
                if (!"".Equals(BMBTXM) && double.Parse(BMBTXM) > 0.0)
                {
                    selectin += "'BMBTXM',";
                }
                if (!"".Equals(DP4) && double.Parse(DP4) > 0.0)
                {
                    selectin += "'DP4',";
                }
                if (!"".Equals(DP3) && double.Parse(DP3) > 0.0)
                {
                    selectin += "'DP3',";
                }
                if (!"".Equals(XUCDAT) && double.Parse(XUCDAT) > 0.0)
                {
                    selectin += "'XUCDAT',";
                }
                if (!"".Equals(CAT) && double.Parse(CAT) > 0.0)
                {
                    selectin += "'CAT',";
                }
                if (!"".Equals(DA04) && double.Parse(DA04) > 0.0)
                {
                    selectin += "'DA04',";
                }
                //MessageBox.Show(this, selectin.Remove(selectin.Length-1,1));
                GridCacCongTac.DataSource = DAL.C_DanhMucVatTu.getDMVT(selectin.Remove(selectin.Length - 1, 1));
                for (int i = 0; i < GridCacCongTac.Rows.Count; i++) {

                    if ("CNHUA".Equals(GridCacCongTac.Rows[i].Cells["congtac_mahieu"].Value) && double.Parse(CNHUA) > 0.0)
                    {
                        GridCacCongTac.Rows[i].Cells["congtac_khoiluong"].Value = double.Parse(CNHUA) * 1000;
                    }
                    if ("BNHUA".Equals(GridCacCongTac.Rows[i].Cells["congtac_mahieu"].Value) && double.Parse(BOCNHUA) > 0.0)
                    {
                        GridCacCongTac.Rows[i].Cells["congtac_khoiluong"].Value = double.Parse(BOCNHUA) * 1000;
                    }
                    if ("CMBTXM".Equals(GridCacCongTac.Rows[i].Cells["congtac_mahieu"].Value) && double.Parse(CMBTXM) > 0.0)
                    {
                        GridCacCongTac.Rows[i].Cells["congtac_khoiluong"].Value = double.Parse(CMBTXM) * 1000;
                    }
                    if ("BMBTXM".Equals(GridCacCongTac.Rows[i].Cells["congtac_mahieu"].Value) && double.Parse(BMBTXM) > 0.0)
                    {
                        GridCacCongTac.Rows[i].Cells["congtac_khoiluong"].Value = double.Parse(BMBTXM) * 1000;
                    }
                    if ("DP4".Equals(GridCacCongTac.Rows[i].Cells["congtac_mahieu"].Value) && double.Parse(DP4) > 0.0)
                    {
                        GridCacCongTac.Rows[i].Cells["congtac_khoiluong"].Value = double.Parse(DP4) * 1000;
                    }
                    if ("DP3".Equals(GridCacCongTac.Rows[i].Cells["congtac_mahieu"].Value) && double.Parse(DP3) > 0.0)
                    {
                        GridCacCongTac.Rows[i].Cells["congtac_khoiluong"].Value = double.Parse(DP3) * 1000;
                    }
                    if ("XUCDAT".Equals(GridCacCongTac.Rows[i].Cells["congtac_mahieu"].Value) && double.Parse(XUCDAT) > 0.0)
                    {
                        GridCacCongTac.Rows[i].Cells["congtac_khoiluong"].Value = double.Parse(XUCDAT) * 1000;
                    }
                    if ("CAT".Equals(GridCacCongTac.Rows[i].Cells["congtac_mahieu"].Value) && double.Parse(CAT) > 0.0)
                    {
                        GridCacCongTac.Rows[i].Cells["congtac_khoiluong"].Value = double.Parse(CAT) * 1000;
                    }
                    if ("DA04".Equals(GridCacCongTac.Rows[i].Cells["congtac_mahieu"].Value) && double.Parse(DA04) > 0.0)
                    {
                        GridCacCongTac.Rows[i].Cells["congtac_khoiluong"].Value = double.Parse(DA04) * 1000;
                    }
                }

                // }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }


        }
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

        string mahieuvt = "";
        private void GridCacCongTac_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        { 
            if (e.ColumnIndex == 2)
            {
                DANHMUCVATTU dmvt = DAL.C_DanhMucVatTu.finbyMaHieu(GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_mahieu"].Value + "");
                if (dmvt != null)
                {

                    GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_hanmuc"].Value = dmvt.TENVT.ToUpper();
                    GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_dvt"].Value = dmvt.DVT;
                    GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["contac_loaisd"].Value = "CM";
                }
                else
                {
                    MessageBox.Show(this, "Không Tìm Thấy Mã Hiệu Đơn Giá.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells[2].Selected = true;
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

        private void GridCacCongTac_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

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