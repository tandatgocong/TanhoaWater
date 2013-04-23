using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;
using TanHoaWater.View.Report;
using log4net;
using TanHoaWater.View.Users.KEHOACH;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.KEHOACH.Report;
using TanHoaWater.View.Users.Report;

namespace TanHoaWater.View.Users.HSKHACHHANG
{
    public partial class uct_DOTNHANDON : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(uct_DOTNHANDON).Name);
        string _madot_ = null;
        int currentPageIndex = 1;
        int pageSize = 50;
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
        public uct_DOTNHANDON()
        {
            InitializeComponent();

        }

        private void DOTNHANDON_Load(object sender, EventArgs e)
        {
            formLoad();            
        }

        public void formLoad()
        {
           
            #region Load Combox Loai Ho So
            this.cbLoaiHS.DataSource = DAL.C_LoaiHoSo.getListCombobox();
            this.cbLoaiHS.DisplayMember = "Display";
            this.cbLoaiHS.ValueMember = "Value";            
            #endregion
            //#region Load Marsk TextBox
            //DateTime now = DateTime.Now;           
            //this.createDate.Value = now;
            //#endregion
            #region Load Data
                loadGrid();
               
            #endregion
        }

        private void addNewDot_Click(object sender, EventArgs e)
        {
            try
            {
                string madot = this.txtsoDot.Text.ToUpper();
                DateTime ngaylap = this.createDate.Value;
                string loaiDonNhan = this.cbLoaiHS.SelectedValue.ToString();
                if ("".Equals(madot))
                {
                    MessageBox.Show(this, "Nhập đợt nhận đơn không hợp lệ.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtsoDot.Focus();
                }
                else if ("1/1/0001".Equals(ngaylap.ToShortDateString()))
                {
                    MessageBox.Show(this, "Ngày nhận đơn không hợp lệ.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    createDate.Focus();
                    createDate.Select();
                }
                else if ("".Equals(loaiDonNhan))
                {
                    MessageBox.Show(this, "Chọn loại nhận đơn.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoaiHS.Focus();
                    cbLoaiHS.Select();
                }
                else if (DAL.C_DotNhanDon.findByMaDot(madot) != null)
                {
                    MessageBox.Show(this, "Số đợt đã tồn tại.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtsoDot.Focus();
                }
                else
                {
                    DOT_NHAN_DON dotnhan = new DOT_NHAN_DON();
                    dotnhan.MADOT = madot;
                    dotnhan.NGAYLAPDON = ngaylap;
                    dotnhan.LOAIDON = loaiDonNhan;
                    dotnhan.CREATEBY = DAL.C_USERS._userName;
                    dotnhan.CREATEDATE = DateTime.Now;
                    dotnhan.CHUYENDON = false;
                    DAL.C_DotNhanDon.InsertDot(dotnhan);
                    loadGrid();
                }
            }
            catch (Exception ex)
            {
                log.Error("Insert Dot KHACH HANG " + ex.Message);
            }           
  
        }
        public void loadGrid() {
            try
            {
                rows = DAL.C_DotNhanDon.TotalListByDotNhanDon();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            PageTotal();
            this.mainGrid.DataSource = DAL.C_DotNhanDon.getList(FirstRow, pageSize);
           
        }
        private void next_Click(object sender, EventArgs e)
        {
            if (currentPageIndex < pageNumber)
            {
                currentPageIndex = currentPageIndex + 1;
                FirstRow = pageSize * (currentPageIndex - 1);
                LastRow = pageSize * (currentPageIndex);
                PageTotal();
                loadGrid();
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
                    loadGrid();
                }
            }
            catch (Exception)
            {

            }

        }

        private void SearchDot_Click(object sender, EventArgs e)
        {
            this.mainGrid.DataSource = DAL.C_DotNhanDon.Search(this.txtsoDot.Text, this.createDate.Value, this.cbLoaiHS.SelectedValue.ToString());
            Utilities.DataGridV.formatRows(mainGrid);
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            this.cbLoaiHS.SelectedIndex = 0;
            this.txtsoDot.Text = null;        
            this.createDate.ValueObject = null;
            this.loadGrid();

        }
        int sokh = 0;
        public void loadDetail(string madot) {

            this.detail.DataSource = DAL.C_DonKhachHang.getListbyDot(madot);
            sokh = DAL.C_DonKhachHang.getListbyDot(madot).Rows.Count;
            //if (sokh > 0)
            //{
            //    this.print.Visible = true;
            //    this.checkCD.Visible = true;

            //}
            //else
            //{
            //    this.print.Visible = false;
            //    this.checkCD.Visible = false;
            //}
            //if (DAL.C_DotNhanDon.findByMaDot(madot).CHUYENDON == true)
            //{
            //    this.checkCD.Visible = false;
            //}
            ////cap nhat tinh trang
            for (int i = 0; i < detail.Rows.Count; i++)
            {
                try
                {
                    string shs = detail.Rows[i].Cells["SHS"].Value + "";
                    TOTHIETKE ttk = DAL.C_ToThietKe.findBySHS(shs);
                    if (ttk != null)
                    {
                        if (ttk.HOANTATTK == true && (ttk.TRONGAITHIETKE == null || ttk.TRONGAITHIETKE == false))
                        {
                            detail.Rows[i].Cells["gHoanTat"].Value = "Hoàn Tất";
                            detail.Rows[i].Cells["g_ngayht"].Value = Utilities.DateToString.NgayVN(ttk.NGAYHOANTATTK.Value) + "";
                        }
                        if (ttk.TRONGAITHIETKE == true)
                        {
                            detail.Rows[i].Cells["gHoanTat"].Value = "Trở Ngại";
                            detail.Rows[i].Cells["g_ngayht"].Value = Utilities.DateToString.NgayVN(ttk.NGAYTRAHS.Value) + "";
                        }

                    }
                }
                catch (Exception)
                {
                }
            }
            Utilities.DataGridV.formatRows(detail);
        }
        DOT_NHAN_DON dotnd = null;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string _madot = mainGrid.Rows[e.RowIndex].Cells[0].Value != null ? mainGrid.Rows[e.RowIndex].Cells[0].Value.ToString() : null;

                try
                {
                    dotnd= DAL.C_DotNhanDon.findByMaDot(_madot);
                    if(dotnd!=null){
                        this.txtsoDot.Text = dotnd.MADOT;
                        this.createDate.ValueObject = dotnd.NGAYLAPDON;
                        this.cbLoaiHS.Text = DAL.C_LoaiHoSo.findbyMaLoai(dotnd.LOAIDON).TENLOAI;
                        if (dotnd.CHUYENDON == true)
                        {
                            btCapNhat.Enabled = false;
                            btAddHS.Visible = true;
                        }
                        else {
                            btCapNhat.Enabled = true;

                            btAddHS.Visible = true;
                        }
                    }
                    
                }
                catch (Exception)
                {
                    
                }
                loadDetail(_madot);
                this.lbSoKHNhanDon.Text = "Có " + sokh + " khách hàng đợt nhận đơn " + _madot;

                   
                ///
                _madot_ = _madot;
                this.cbBOPHAN.Visible = false;
                this.chyenTTK.Visible = false;
                this.cbBOPHAN.DataSource = null;
            }
            catch (Exception ex){
                log.Error(ex.Message);
             }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    rpt_View rpt = new rpt_View(_madot_);
            //    rpt.ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(this, "..: Thông Báo :..", "Lỗi Khi In !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    log.Error("In Loi " + ex.Message);
            //}
            ReportDocument rp = new rpt_DOT_QUAN();
            rp.SetDataSource(DAL.C_BAOCAO_VIEW.BC_DOTNHANDON_DOT(_madot_, DAL.C_USERS._userName, DAL.C_USERS.KHVTDuyet(), null, null));
            DOT_NHAN_DON dotnd = DAL.C_DotNhanDon.findByMaDot(_madot_);
            rp.SetParameterValue("ngaylapdot", " ngày " + dotnd.NGAYLAPDON.Date.Day + " tháng " + dotnd.NGAYLAPDON.Date.Month + " năm " + dotnd.NGAYLAPDON.Date.Year);
            rpt_Main main = new rpt_Main(rp);
            main.ShowDialog();

        }

        private void chyenTTK_Click(object sender, EventArgs e)
        {
            try
            {
                #region Update DOT NHAN DON
                string _madot = mainGrid.Rows[mainGrid.CurrentRow.Index].Cells[0].Value != null ? mainGrid.Rows[mainGrid.CurrentRow.Index].Cells[0].Value.ToString() : null;
                DOT_NHAN_DON dot = DAL.C_DotNhanDon.findByMaDot(_madot);
                dot.CHUYENDON = true;
                dot.NGAYCHUYEN = DateTime.Now;
                dot.NGUOICHUYEN = DAL.C_USERS._userName;
                dot.BOPHANCHUYEN = this.cbBOPHAN.SelectedValue.ToString();
                DAL.C_DotNhanDon.chuyendon(dot);
                #endregion
                #region Update DON KHACH HANG
                for (int i = 0; i < detail.Rows.Count; i++)
                {
                    string sohoso = detail.Rows[i].Cells[0].Value != null ? detail.Rows[i].Cells[0].Value.ToString() : null;
                    if (sohoso != null)
                    {
                        DAL.C_DonKhachHang.chuyenhs(sohoso, DAL.C_USERS._userName, this.cbBOPHAN.SelectedValue.ToString());
                    }
                }

                #endregion
                #region Add Chuyen TTK
                if (_madot != null)
                {
                    for (int j = 0; j < detail.Rows.Count; j++)
                    {
                        if (detail.Rows[j].Cells[0].Value != null)
                        {
                            string sohskh = detail.Rows[j].Cells[0].Value.ToString();
                            string shs = sohskh.Substring(6);
                            TOTHIETKE ttk = new TOTHIETKE();
                            ttk.MADOT = _madot;
                            ttk.SOHOSO = sohskh;
                            ttk.SHS = shs;
                            ttk.NGAYNHAN = DateTime.Now;
                            DAL.C_ToThietKe.addNew(ttk);
                        }
                    }
                }
                #endregion
                MessageBox.Show(this, "Chuyển Đợt Nhận Đơn Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {               
                log.Error("Chuyen TTT Loi " + ex.Message);
                MessageBox.Show(this, "Chuyển Đợt Nhận Đơn Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadGrid();
        }

        private void checkCD_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCD.Checked == true) {
                this.cbBOPHAN.Visible = true;
                this.chyenTTK.Visible = true;
                this.cbBOPHAN.DataSource = DAL.C_PhongBan.getList();
                this.cbBOPHAN.DisplayMember = "TENPHONG";
                this.cbBOPHAN.ValueMember = "MAPHONG";
            } else {
                this.cbBOPHAN.Visible = false;
                this.chyenTTK.Visible = false;
                this.cbBOPHAN.DataSource = null;
            }
        }

        private void txtsoDot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                this.mainGrid.DataSource = DAL.C_DotNhanDon.Search(this.txtsoDot.Text, this.createDate.Value, this.cbLoaiHS.SelectedValue.ToString());
                Utilities.DataGridV.formatRows(mainGrid);
            }

        }

        private void mainGrid_Sorted(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(mainGrid);
        }

        private void updateDot(object sender, EventArgs e)
        {
            try
            {
                if (dotnd != null) {
                    dotnd.NGAYLAPDON = createDate.Value;
                    if (cbLoaiHS.SelectedValue != null) {
                        dotnd.LOAIDON = cbLoaiHS.SelectedValue+"";
                    }
                    dotnd.MODIFYBY = DAL.C_USERS._userName;
                    dotnd.MODIFYDATE = DateTime.Now;
                    DAL.C_DotNhanDon.Update();
                    MessageBox.Show(this, "Cập Nhật Bảng Kê Thành Công", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                log.Error("Sua Thong Tin Dot Nhan Don Loi" + ex.Message);
                MessageBox.Show(this, "Cập Nhật Bảng Kê Thất Bại.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btAddHS_Click(object sender, EventArgs e)
        {
            if (dotnd != null)
            {
                dialogNhapDon frm = new dialogNhapDon(dotnd.MADOT);
                frm.ShowDialog();
                loadDetail(dotnd.MADOT);
            }
        }

        private void txtsoDot_TextChanged(object sender, EventArgs e)
        {
            mainGrid.ClearSelection();
            foreach (DataGridViewRow currentRow in mainGrid.Rows)
            {
                if (currentRow.Cells["DOTNHAN"].Value.ToString().Contains(txtsoDot.Text))
                {
                    currentRow.Selected = true;
                    break;
                }
            }
        }

        private void mainGrid_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
               string _madot = mainGrid.Rows[mainGrid.CurrentRow.Index].Cells[0].Value != null ? mainGrid.Rows[mainGrid.CurrentRow.Index].Cells[0].Value.ToString() : null;

                loadDetail(_madot);
                this.lbSoKHNhanDon.Text = "Có " + sokh + " khách hàng đợt nhận đơn " + _madot;


                ///
                _madot_ = _madot;
                this.cbBOPHAN.Visible = false;
                this.chyenTTK.Visible = false;
                this.cbBOPHAN.DataSource = null;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string madot = this.txtsoDot.Text;
            DOT_NHAN_DON dotnd= DAL.C_DotNhanDon.findByMaDot(madot);
            if (DAL.C_DotNhanDon.DeleteDot(dotnd) == true)
            {
                MessageBox.Show(this, "Xóa Bảng Kê Thành Công .", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadGrid();
            }
            else {
                MessageBox.Show(this, "Xóa Bảng Kê Thất Bại.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtsoDot_Leave(object sender, EventArgs e)
        {
            this.txtsoDot.Text = this.txtsoDot.Text.ToUpper();
        }
    }
}
