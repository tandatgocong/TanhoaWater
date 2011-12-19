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
using System.Data.SqlClient;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.TinhDuToan.report;
using TanHoaWater.View.Users.Report;

namespace TanHoaWater.View.Users.TinhDuToan
{

    public partial class tab_BoVatTuTaoSan : UserControl
    {
        public static string mabovt = "";
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_TinhDuToan).Name);
        public tab_BoVatTuTaoSan()
        {
            InitializeComponent();
            loadComboboxPhuiDao();
            loadlistBoVT();
        }
        public void loadlistBoVT()
        {
            listBox.Items.Clear();
            listBox.DataSource = DAL.C_BoVatTuTaoSan.listBoVT();
            this.listBox.DisplayMember = "MABOVT";
            this.listBox.ValueMember = "MABOVT";
        }
        public void loadComboboxPhuiDao()
        {
            congtac_mahieu.DataSource = DAL.C_DanhMucVatTu.getListDanhMucVatCobobox();
            this.congtac_mahieu.DisplayMember = "TENVT";
            this.congtac_mahieu.ValueMember = "MAHIEU";
            this.contac_loaisd.DataSource = DAL.C_LoaiSD.getList();
            this.contac_loaisd.DisplayMember = "MALOAI";
            this.contac_loaisd.ValueMember = "MALOAI";
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




        /// <summary>
        /// Cac Cong tac
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        bool loadcongtac = true;
        private void GridCacCongTac_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GridCacCongTac_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["contac_loaisd"].Value = "CM";
            GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_khoiluong"].Value = 1;
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
                    GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_khoiluong"].Value = 1;
                    GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["contac_loaisd"].Value = "CM";

                    GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congTacNhom"].Value = dmvt.NHOMVT;


                    //if (dmvt.BOVT == true)
                    //{
                    //    DataTable dongiavt = DAL.C_DonGiaVatTu.getDonGiaBoVT(dmvt.MAHIEU);
                    //    if (dongiavt != null)
                    //    {
                    //        GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_VL"].Value = dongiavt.Rows[0][0].ToString();
                    //        GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_NC"].Value = dongiavt.Rows[0][1].ToString();
                    //        GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_MTC"].Value = dongiavt.Rows[0][2].ToString();
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show(this, "Không Tìm Thấy Mã Hiệu Đơn Giá.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_mahieu"].Selected = true;
                    //        return;
                    //    }
                    //}
                    //else
                    //{
                    //    DONGIAVATTU dongiavt = DAL.C_DonGiaVatTu.getDonGia(dmvt.MAHIEU);
                    //    if (dongiavt != null)
                    //    {
                    //        GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_VL"].Value = dongiavt.DGVATLIEU;
                    //        GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_NC"].Value = dongiavt.DGNHANCONG;
                    //        GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_MTC"].Value = dongiavt.DGMAYTHICONG;
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show(this, "Không Tìm Thấy Mã Hiệu Đơn Giá.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_mahieu"].Selected = true;
                    //        return;
                    //    }
                    //}

                }
                else
                {
                    MessageBox.Show(this, "Không Tìm Thấy Mã Hiệu Đơn Giá.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_mahieu"].Selected = true;
                    return;
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


        private void btChonLaiDonGia_Click(object sender, EventArgs e)
        {
            //frm_ChonLaiDG from = new frm_ChonLaiDG();
            //from.ShowDialog();

        }

        private void GridCacCongTac_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (GridCacCongTac.CurrentCell.OwningColumn.Name == "contac_loaisd")
            //    {
            //        if (double.Parse(this.GridCacCongTac.Rows[e.RowIndex].Cells["congtac_khoiluong"].Value + "") > 10)
            //        {
            //            this.GridCacCongTac.Rows[e.RowIndex].Cells["congtac_khoiluong"].Value = String.Format("{0:0,0.00}", double.Parse(this.GridCacCongTac.Rows[e.RowIndex].Cells["congtac_khoiluong"].Value + "")); ;
            //        }
            //        else
            //        {
            //            this.GridCacCongTac.Rows[e.RowIndex].Cells["congtac_khoiluong"].Value = String.Format("{0:0.00}", double.Parse(this.GridCacCongTac.Rows[e.RowIndex].Cells["congtac_khoiluong"].Value + "")); ;
            //        }
            //    }
            //}
            //catch (Exception)
            //{ }

        }

        private void GridCacCongTac_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            try
            {

                if (double.Parse(this.GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_khoiluong"].Value + "") > 10)
                {
                    this.GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_khoiluong"].Value = String.Format("{0:0,0.00}", double.Parse(this.GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_khoiluong"].Value + "")); ;
                }
                else
                {
                    this.GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_khoiluong"].Value = String.Format("{0:0.00}", double.Parse(this.GridCacCongTac.Rows[GridCacCongTac.CurrentRow.Index].Cells["congtac_khoiluong"].Value + "")); ;
                }

            }
            catch (Exception)
            { }
        }

        private void GridCacCongTac_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

      
        private void GridPhuiDao_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            BOVATTAOSAN bovt = new BOVATTAOSAN();
            bovt.MABOVT = this.txtMaBo.Text;
            bovt.TENBOVT = this.txtTenBo.Text;
            bovt.CREATEBY = DAL.C_USERS._userName;
            bovt.CREATEDATE = DateTime.Now;
            DAL.C_BoVatTuTaoSan.InsertVTTS(bovt);
            loadlistBoVT();
        }

        public void reset()
        {

            this.txtMaBo.Text = "";
            this.txtTenBo.Text = "";
            this.search.Text = "";
            GridCacCongTac.DataSource = DAL.C_BoVatTuTaoSan.getDanhMucVatTu("");
            this.txtMaBo.ReadOnly = false;
            loadlistBoVT();
        }
        private void btLamLai_Click(object sender, EventArgs e)
        {
            reset();
        }
        public void InsertCONGTACBANGGIA()
        {
            try
            {
            for (int i = 0; i < this.GridCacCongTac.Rows.Count; i++)
            {
                string maketcau = this.GridCacCongTac.Rows[i].Cells["congtac_mahieu"].Value + "";
                if (!"".Equals(maketcau))
                {
                    CHITIETBOVATTAOSAN congtacbg = new CHITIETBOVATTAOSAN();

                    congtacbg.MAHIEU = maketcau;
                    congtacbg.TENVT = this.GridCacCongTac.Rows[i].Cells["congtac_hanmuc"].Value + "";
                    congtacbg.DVT = this.GridCacCongTac.Rows[i].Cells["congtac_dvt"].Value + "";
                    string nhom = this.GridCacCongTac.Rows[i].Cells["congTacNhom"].Value + "";
                    string loaisd = this.GridCacCongTac.Rows[i].Cells["contac_loaisd"].Value + "";
                    congtacbg.NHOM = this.GridCacCongTac.Rows[i].Cells["congTacNhom"].Value + "";
                    string chon = this.GridCacCongTac.Rows[i].Cells["gr_Chon"].Value + "";
                    bool c_chon = false;
                    if("True".Equals(chon)){
                        c_chon = true;
                    }
                    congtacbg.CHON = c_chon;
                    congtacbg.LOAISN = loaisd;
                    congtacbg.KHOILUONG = double.Parse(this.GridCacCongTac.Rows[i].Cells["congtac_khoiluong"].Value + "");
                    congtacbg.MABOVT = this.listBox.SelectedValue.ToString();
                    congtacbg.CREATEBY = DAL.C_USERS._userName;
                    congtacbg.CREATEDATE = DateTime.Now;
                    DAL.C_BoVatTuTaoSan.InsertChiTiet(congtacbg);

                    //DAL.C_BG_KICHTHUOCPHUIDAO.InsertKTPD(phuidao);

                }
            }
            }
            catch (Exception ex)
            {
                log.Error("Loi Insert Cong Tac Bang Gia " + ex.Message);
            }


        }
        private void btCapNhatDM_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.C_BoVatTuTaoSan.DeleteDMVT(this.listBox.SelectedValue.ToString());
                InsertCONGTACBANGGIA();
            }
            catch (Exception)
            {
                 
            }
           
        }

        private void search_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                for (int i = 0; i < listBox.Items.Count; i++)
                {
                    BOVATTAOSAN bo = (BOVATTAOSAN)listBox.Items[i];

                    if (bo.MABOVT.Contains(search.Text))
                    {
                        listBox.SetSelected(i, true);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mabovt = listBox.SelectedValue + "";
            BOVATTAOSAN bovt = DAL.C_BoVatTuTaoSan.findByMaBo(mabovt);
            if (bovt != null) {
                txtMaBo.Text = bovt.MABOVT;
                txtTenBo.Text = bovt.TENBOVT;
                this.GridCacCongTac.DataSource = DAL.C_BoVatTuTaoSan.getDanhMucVatTu(bovt.MABOVT);
                this.txtMaBo.ReadOnly = true;
            }
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
             
           
            //MessageBox.Show(this, search.Text);
        }

        private void btCopyDanhMuc_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.C_BoVatTuTaoSan.DeleteDMVT(this.listBox.SelectedValue.ToString());
                InsertCONGTACBANGGIA();
                DAL.C_BoVatTuTaoSan.mabovt = this.listBox.SelectedValue.ToString();
            }
            catch (Exception)
            {

            }
        }
        
        private void btThoat_Click(object sender, EventArgs e)
        {
          
        }
    }

}