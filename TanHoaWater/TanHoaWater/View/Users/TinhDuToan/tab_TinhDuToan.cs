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

namespace TanHoaWater.View.Users.TinhDuToan
{

    public partial class tab_TinhDuToan : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_TinhDuToan).Name);
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
                    GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells["phuidao_dvt"].Value = dmvt.DVT;
                }
                else
                {
                    MessageBox.Show(this, "Không Tìm Thấy Mã Kết Cấu.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells[0].Selected = true;
                }
                //Utilities.DataGridV.formatRows(GridPhuiDao);
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
        private void GridPhuiDao_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            try
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
            { }
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
                if (cacongtac)
                {
                    cacongtac = false;
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
                    for (int i = 0; i < GridCacCongTac.Rows.Count; i++)
                    {

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
                        GridCacCongTac.Rows[i].Cells["contac_loaisd"].Value = "CM";
                        DANHMUCVATTU dmvt = DAL.C_DanhMucVatTu.finbyMaHieu(GridCacCongTac.Rows[i].Cells["congtac_mahieu"].Value + "");
                        if (dmvt!=null && dmvt.BOVT == true)
                        {
                            DataTable dongiavt = DAL.C_DonGiaVatTu.getDonGiaBoVT(dmvt.MAHIEU);
                            if (dongiavt != null)
                            {
                                GridCacCongTac.Rows[i].Cells["congtac_VL"].Value = dongiavt.Rows[0][0].ToString();
                                GridCacCongTac.Rows[i].Cells["congtac_NC"].Value = dongiavt.Rows[0][1].ToString();
                                GridCacCongTac.Rows[i].Cells["congtac_MTC"].Value = dongiavt.Rows[0][2].ToString();
                            }
                        }
                        else if (dmvt != null)
                        {
                            DONGIAVATTU dongiavt = DAL.C_DonGiaVatTu.getDonGia(dmvt.MAHIEU);
                            if (dongiavt != null)
                            {
                                GridCacCongTac.Rows[i].Cells["congtac_VL"].Value = dongiavt.DGVATLIEU;
                                GridCacCongTac.Rows[i].Cells["congtac_NC"].Value = dongiavt.DGNHANCONG;
                                GridCacCongTac.Rows[i].Cells["congtac_MTC"].Value = dongiavt.DGMAYTHICONG;
                            }
                        }
                    }
                    //Utilities.DataGridV.formatRows(GridCacCongTac);

                }
            }
            catch (Exception)
            {
                //MessageBox.Show(this, ex.Message);
            }


        }
        private void GridCacCongTac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                else if (GridCacCongTac.CurrentCell.OwningColumn.Name == "contac_loaisd")
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
                else
                {
                    try
                    {
                        string _mahieuvt = GridCacCongTac.Rows[e.RowIndex].Cells["congtac_mahieu"].Value + "";
                        if (_mahieuvt != null && !"".Equals(_mahieuvt))
                        {
                            DONGIAVATTU dongiavt = DAL.C_DonGiaVatTu.finbyDonGiaVTbyMahieu(_mahieuvt);
                            if (dongiavt != null)
                            {
                                this.txtDonGiaVatLieu.Text = String.Format("{0:0,0.00}", dongiavt.DGVATLIEU);
                                this.TxtDonGiaNhanCong.Text = String.Format("{0:0,0.00}", dongiavt.DGNHANCONG);
                                this.txtDonGiaMayThiCong.Text = String.Format("{0:0,0.00}", dongiavt.DGMAYTHICONG);
                            }
                            else
                            {
                                MessageBox.Show(this, "Không Tìm Thế Đơn Giá Mã Hiệu.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else {
                            this.txtDonGiaVatLieu.Text = "0.00";
                            this.TxtDonGiaNhanCong.Text = "0.00";
                            this.txtDonGiaMayThiCong.Text = "0.00";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message);
                        log.Error(ex.Message);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
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
                GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["contac_loaisd"].Value = cbLoaiSD.SelectedValue + "";
                cbLoaiSD.Visible = false;
            }
            catch (Exception)
            {

            }
        }
        string _shs = "";
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
                    _shs = table.Rows[0][1].ToString();
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
                    if ("True".Equals(table.Rows[0][13].ToString()))
                    {
                        checkKhoan.Checked = true;
                        txtLoaiKhoan.Text = table.Rows[0][14].ToString();

                    }
                    else
                    {
                        checkKhoan.Checked = false;
                        txtLoaiKhoan.Text = table.Rows[0][14].ToString();
                    }

                }
            }
        }

        string mahieuvt = "";
        private void GridCacCongTac_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (GridCacCongTac.CurrentCell.OwningColumn.Name == "congtac_mahieu")
            {
                DANHMUCVATTU dmvt = DAL.C_DanhMucVatTu.finbyMaHieu(GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_mahieu"].Value + "");
                if (dmvt != null)
                {

                    GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_hanmuc"].Value = dmvt.TENVT.ToUpper();
                    GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_dvt"].Value = dmvt.DVT;
                    GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["contac_loaisd"].Value = "CM";
                    GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtacMahieuDG"].Value = dmvt.MAHDG;
                    GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congTacNhom"].Value = dmvt.NHOMVT;

                    if (dmvt.BOVT == true)
                    {
                        DataTable dongiavt = DAL.C_DonGiaVatTu.getDonGiaBoVT(dmvt.MAHIEU);
                        if (dongiavt != null)
                        {
                            GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_VL"].Value = dongiavt.Rows[0][0].ToString();
                            GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_NC"].Value = dongiavt.Rows[0][1].ToString();
                            GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_MTC"].Value = dongiavt.Rows[0][2].ToString();
                        }
                    }
                    else {
                        DONGIAVATTU dongiavt = DAL.C_DonGiaVatTu.getDonGia(dmvt.MAHIEU);
                        if (dongiavt != null) {
                            GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_VL"].Value = dongiavt.DGVATLIEU;
                            GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_NC"].Value = dongiavt.DGNHANCONG;
                            GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_MTC"].Value = dongiavt.DGMAYTHICONG;
                        }
                    }
                    
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
             try
            {
                if (e.RowIndex < GridCacCongTac.RowCount - 1)
                {
                    //  MessageBox.Show(this,"Dữ Liệu Không Được trống và lớn hơn 0 !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ("".Equals(this.GridCacCongTac.Rows[e.RowIndex].Cells["congtac_khoiluong"].Value) || this.GridCacCongTac.Rows[e.RowIndex].Cells["congtac_khoiluong"].Value == null || Convert.ToDouble(this.GridCacCongTac.Rows[e.RowIndex].Cells["phuidao_Daii"].Value.ToString()) <= 0)
                    {
                        this.GridCacCongTac.Rows[e.RowIndex].Cells["congtac_khoiluong"].ErrorText = "Dữ Liệu Không Được trống và lớn hơn 0 !";

                    }
                    else
                    {
                        this.GridCacCongTac.Rows[e.RowIndex].Cells["congtac_khoiluong"].ErrorText = null;
                    }
                }
            }
            catch (Exception)
            { }            
        }
        

        private void btChonLaiDonGia_Click(object sender, EventArgs e)
        {
            //frm_ChonLaiDG from = new frm_ChonLaiDG();
            //from.ShowDialog();

        }
        public void InsertBG_KICHTHUOCPHUIDAO()
        {
            try
            {
                for (int i = 0; i < this.GridPhuiDao.Rows.Count; i++)
                {
                    string maketcau = this.GridPhuiDao.Rows[i].Cells["pd_MaKetCau"].Value + "";
                    if (!"".Equals(maketcau) && !"".Equals(_shs))
                    {
                        BG_KICHTHUOCPHUIDAO phuidao = new BG_KICHTHUOCPHUIDAO();
                        phuidao.SHS = _shs;
                        phuidao.MADANHMUC = this.GridPhuiDao.Rows[i].Cells["pd_MaKetCau"].Value + "";
                        phuidao.TENKETCAU = this.GridPhuiDao.Rows[i].Cells["phuidao_tenketcau"].Value + "";
                        phuidao.DVT = this.GridPhuiDao.Rows[i].Cells["phuidao_dvt"].Value + "";
                        phuidao.DAI = double.Parse(this.GridPhuiDao.Rows[i].Cells["phuidao_Daii"].Value + "");
                        phuidao.RONG = double.Parse(this.GridPhuiDao.Rows[i].Cells["phuidao_rongg"].Value + "");
                        phuidao.DOSAU = double.Parse(this.GridPhuiDao.Rows[i].Cells["phuidao_sauu"].Value + "");
                        phuidao.SOLUONG = double.Parse(this.GridPhuiDao.Rows[i].Cells["phuidao_sll"].Value + "");
                        phuidao.KHOILUONG = double.Parse(this.GridPhuiDao.Rows[i].Cells["phui_khoiluong"].Value + "");
                        phuidao.CHUVI = double.Parse(this.GridPhuiDao.Rows[i].Cells["phuidao_chuvi"].Value + "");
                        phuidao.THETICH = double.Parse(this.GridPhuiDao.Rows[i].Cells["phuidao_thetich"].Value + "");
                        phuidao.COTINHTL = bool.Parse(this.GridPhuiDao.Rows[i].Cells["phidao_cotll"].Value + "");
                        phuidao.CREATEBY = DAL.C_USERS._userName;
                        phuidao.CREATEDATE = DateTime.Now;
                        DAL.C_BG_KICHTHUOCPHUIDAO.InsertKTPD(phuidao);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Loi Insert Kich Thuoc Phui Dao " + ex.Message);
            }
            
        }
        public void InsertCONGTACBANGGIA()
        {
            try
            {
                for (int i = 0; i < this.GridCacCongTac.Rows.Count; i++)
                {
                    string maketcau = this.GridCacCongTac.Rows[i].Cells["congtac_mahieu"].Value + "";
                    if (!"".Equals(maketcau) && !"".Equals(_shs))
                    {
                        BG_CONGTACBANGIA congtacbg = new BG_CONGTACBANGIA();
                        congtacbg.SHS = _shs;
                        congtacbg.MAHIEU = this.GridCacCongTac.Rows[i].Cells["congtac_mahieu"].Value + "";
                        congtacbg.MAHDG = this.GridCacCongTac.Rows[i].Cells["congtacMahieuDG"].Value + "";
                        congtacbg.TENVT = this.GridCacCongTac.Rows[i].Cells["congtac_hanmuc"].Value + "";
                        congtacbg.DVT = this.GridCacCongTac.Rows[i].Cells["congtac_dvt"].Value + "";
                        congtacbg.NHOM = this.GridCacCongTac.Rows[i].Cells["congTacNhom"].Value + "";
                        congtacbg.LOAISN = this.GridCacCongTac.Rows[i].Cells["contac_loaisd"].Value + "";
                        congtacbg.KHOILUONG = double.Parse(this.GridCacCongTac.Rows[i].Cells["congtac_khoiluong"].Value + "");
                        congtacbg.DONGIAVL = double.Parse(this.GridCacCongTac.Rows[i].Cells["congtac_VL"].Value + "");
                        congtacbg.DONGIANC = double.Parse(this.GridCacCongTac.Rows[i].Cells["congtac_NC"].Value + "");
                        congtacbg.DONGIAMTC = double.Parse(this.GridCacCongTac.Rows[i].Cells["congtac_MTC"].Value + "");
                        congtacbg.CREATEBY = DAL.C_USERS._userName;
                        congtacbg.CREATEDATE = DateTime.Now;
                        DAL.C_CongTacBangGia.InsertCongTacBG(congtacbg);

                        //DAL.C_BG_KICHTHUOCPHUIDAO.InsertKTPD(phuidao);

                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Loi Insert Cong Tac Bang Gia " + ex.Message);
            }
            

        }
        private void btTinhBangGia_Click(object sender, EventArgs e)
        {
            if(!"".Equals(_shs)){
                InsertBG_KICHTHUOCPHUIDAO();
                InsertCONGTACBANGGIA();
            }else{
                MessageBox.Show(this, "Nhập Số Hồ Sơ Tính Dự Toán.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtSHS.Focus();
                this.txtSHS.BackColor = Color.Red;

            }
        }

        private void GridCacCongTac_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (GridCacCongTac.CurrentCell.OwningColumn.Name == "contac_loaisd")
                {
                    if (double.Parse(this.GridCacCongTac.Rows[e.RowIndex].Cells["congtac_khoiluong"].Value + "") > 10)
                    {
                        this.GridCacCongTac.Rows[e.RowIndex].Cells["congtac_khoiluong"].Value = String.Format("{0:0,0.00}", double.Parse(this.GridCacCongTac.Rows[e.RowIndex].Cells["congtac_khoiluong"].Value + "")); ;
                    }
                    else {
                        this.GridCacCongTac.Rows[e.RowIndex].Cells["congtac_khoiluong"].Value = String.Format("{0:0.00}", double.Parse(this.GridCacCongTac.Rows[e.RowIndex].Cells["congtac_khoiluong"].Value + "")); ;
                    }
                }
            }
            catch (Exception)
            {}
            
        }

        

    }
}