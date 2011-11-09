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
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.Report;
using TanHoaWater.View.Users.KEHOACH.DOTTHICONG.BC;

namespace TanHoaWater.View.Users.KEHOACH.DOTTHICONG
{
    public partial class UCT_DOTTHICONG : UserControl
    {
        int currentPageIndex = 1;
        int pageSize = 11;
        int pageNumber = 0;
        int FirstRow, LastRow;
        int rows;
        private static readonly ILog log = LogManager.GetLogger(typeof(UCT_DOTTHICONG).Name);
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
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

        public UCT_DOTTHICONG()
        {
            InitializeComponent();
            formload();
          
            loadDataGrid();
            //List<KH_DOTTHICONG> list = DAL.C_KH_DotThiCong.AutoCompleteDotNhanDon();
            //foreach (var item in list)
            //{
            //    namesCollection.Add(item.MADOTTC);
            //}
            //txtSearchDotTC.AutoCompleteMode = AutoCompleteMode.Suggest;
            //txtSearchDotTC.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //txtSearchDotTC.AutoCompleteCustomSource = namesCollection;
            
        }

        public void formload() {
            cbDonViThiCong.DataSource = DAL.C_KH_DonViTC.getDonViThiCong();
            cbDonViThiCong.DisplayMember = "TENCONGTY";
            cbDonViThiCong.ValueMember = "ID";

            cbDonViTaiLapMD.DataSource = DAL.C_KH_DonViTC.getDonViTaiLap();
            cbDonViTaiLapMD.DisplayMember = "TENCONGTY";
            cbDonViTaiLapMD.ValueMember = "ID";

            cbLoaiBangKe.DataSource = DAL.C_KH_DonViTC.getLoaiBangKe();
            cbLoaiBangKe.DisplayMember = "TENBANGKE";
            cbLoaiBangKe.ValueMember = "TENBANGKE";
        }
        
        public void loadDataGrid()
        {
            try
            {
                rows = DAL.C_KH_DotThiCong.TotalListDotThiCong();
                lbTongHoSo.Text = "Tống Số Có " + rows + " Đợt Thi Công." ;
                PageTotal();
                gridDotThiCong.DataSource = DAL.C_KH_DotThiCong.getListDotThiCong(FirstRow, pageSize);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        
        }
        
        private void txtSoHoSo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTon_KeyPress(object sender, KeyPressEventArgs e)
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
        
        public void refesh() {
            this.txtSodotTC.Text = "";
            this.txtSoHoSo.Text = "0";
            this.txtBangKe.Text = "";
            this.txtGhiChuHoanCong.Text = "";
            this.txtSoLuong.Text = "0";
            this.txtTon.Text = "0";
            this.txtQuetToan.Checked = false;
            this.txtLyDoTroNgaiTC.Text = "";

            this.dateChuyenBu.ValueObject = null;
            this.dateNgayChuyenHC.ValueObject = null;
            this.dateNgayChuyenKT.ValueObject = null;
            this.dateNgayThanhToan.ValueObject = null;
        }
        
        private void btLapDotMoi_Click(object sender, EventArgs e)
        {
            this.txtSodotTC.ReadOnly = false;
            refesh();
            this.dateNgayLap.Value = DateTime.Now.Date;
        }
        
        public void LuuDot()
        {
            string sodot = this.txtSodotTC.Text + "";            
            string dovithicong = this.cbDonViThiCong.Text+"";
            string donvitailap = this.cbDonViTaiLapMD.Text+"";
            string bangke = this.txtBangKe.Text+"";
            string loaibangke = this.cbLoaiBangKe.Text+"";
            string ghichuhoancong= this.txtGhiChuHoanCong.Text+"";
            string soluonghc = this.txtSoLuong.Text + "";
            string ton = this.txtTon.Text+"";
            bool quyettoan = false;
            if (this.txtQuetToan.Checked)
                quyettoan = true;
            else
                quyettoan = false;

            if ("".Equals(sodot)) {
                MessageBox.Show(this, "Nhập Số Đợt Thi Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtSodotTC.Text = "";
                this.txtSodotTC.Focus();
            }else if (DAL.C_KH_DotThiCong.findByMadot(sodot)!=null) {
                MessageBox.Show(this, "Số Đợt Thi Công Đã Tồn Tại.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtSodotTC.Text = "";
                this.txtSodotTC.Focus();
            }else if ("1/1/0001".Equals(this.dateNgayLap.Value.ToShortDateString()))
            {
                MessageBox.Show(this, "Cần Chọn Ngày Lập", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateNgayLap.Select();
            }
            else if ("".Equals(dovithicong))
            {
                MessageBox.Show(this, "Cần Chọn Đơn Vị Thi Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);             
                this.cbDonViThiCong.Select();
            }
            else if ("".Equals(donvitailap))
            {
                MessageBox.Show(this, "Cần Chọn Đơn Vị Tái Lập Mặt Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);            
                this.cbDonViTaiLapMD.Select();
            }
            else if ("".Equals(bangke))
            {
                MessageBox.Show(this, "Cần Nhập Bảng Kê !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtBangKe.Text = "";
                this.txtBangKe.Focus();
            }
            else if ("".Equals(loaibangke))
            {
                MessageBox.Show(this, "Cần Chọn Loại Bảng Kê !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cbLoaiBangKe.Focus();
            }
            else {
                KH_DOTTHICONG dottc = new KH_DOTTHICONG();
                dottc.MADOTTC = sodot.ToUpper();
                dottc.SOLUONGTLK = int.Parse(this.txtSoLuong.Text);
                dottc.NGAYLAP = this.dateNgayLap.Value;
                dottc.DONVITHICONG = int.Parse(this.cbDonViThiCong.SelectedValue + "");
               
                if (!"1/1/0001".Equals(this.dateNgayChuyenHC.Value.ToShortDateString())) {
                    dottc.NGAYCHUYENHC = dateNgayChuyenHC.Value.Date;
                }
                if (!"1/1/0001".Equals(this.dateNgayChuyenKT.Value.ToShortDateString()))
                {
                    dottc.NGAYCHUYENKT = dateNgayChuyenKT.Value.Date;
                }
                if (!"1/1/0001".Equals(this.dateNgayThanhToan.Value.ToShortDateString()))
                {
                    dottc.NGAYTHANHTOAN = dateNgayThanhToan.Value.Date;
                }
                if(!"".Equals(txtGhiChuHoanCong.Text)){
                    dottc.GHICHUHC= txtGhiChuHoanCong.Text;
                }
                if (!"".Equals(txtSoLuong.Text))
                {
                    dottc.SOLUONG_HCTLK =  int.Parse(txtSoLuong.Text);
                }
                if (!"".Equals(txtTon.Text))
                {
                    dottc.CONLAI_TLK = int.Parse(txtTon.Text);
                }
                if (!"".Equals(txtLyDoTroNgaiTC.Text))
                {
                    dottc.TRONGAITC =  txtLyDoTroNgaiTC.Text;
                }
                dottc.QUYETTOAN = quyettoan;

                dottc.DONVITAILAP = int.Parse(this.cbDonViTaiLapMD.SelectedValue + ""); 
                dottc.BANGKE = this.txtBangKe.Text;
                dottc.LOAIBANGKE = this.cbLoaiBangKe.Text;
                dottc.CREATEBY = DAL.C_USERS._userName;
                dottc.CREATEDATE = DateTime.Now.Date;

                if (DAL.C_KH_DotThiCong.InsertDotTC(dottc) == false) {
                    MessageBox.Show(this, "Lỗi Thêm Đợt Thi Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                loadDataGrid();
              }
        }
       
        public void UpdateDot(KH_DOTTHICONG dottc)
        {
            string sodot = this.txtSodotTC.Text + "";
            string dovithicong = this.cbDonViThiCong.Text + "";
            string donvitailap = this.cbDonViTaiLapMD.Text + "";
            string bangke = this.txtBangKe.Text + "";
            string loaibangke = this.cbLoaiBangKe.Text + "";
            string ghichuhoancong = this.txtGhiChuHoanCong.Text + "";
            string soluonghc = this.txtSoLuong.Text + "";
            string ton = this.txtTon.Text + "";
            bool quyettoan = false;
            if (this.txtQuetToan.Checked)
                quyettoan = true;
            else
                quyettoan = false;

            if ("".Equals(sodot))
            {
                MessageBox.Show(this, "Nhập Số Đợt Thi Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtSodotTC.Text = "";
                this.txtSodotTC.Focus();
            }
           else if ("1/1/0001".Equals(this.dateNgayLap.Value.ToShortDateString()))
            {
                MessageBox.Show(this, "Cần Chọn Ngày Lập", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateNgayLap.Select();
            }
            else if ("".Equals(dovithicong))
            {
                MessageBox.Show(this, "Cần Chọn Đơn Vị Thi Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cbDonViThiCong.Select();
            }
            else if ("".Equals(donvitailap))
            {
                MessageBox.Show(this, "Cần Chọn Đơn Vị Tái Lập Mặt Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cbDonViTaiLapMD.Select();
            }
            else if ("".Equals(bangke))
            {
                MessageBox.Show(this, "Cần Nhập Bảng Kê !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtBangKe.Text = "";
                this.txtBangKe.Focus();
            }
            else if ("".Equals(loaibangke))
            {
                MessageBox.Show(this, "Cần Chọn Loại Bảng Kê !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cbLoaiBangKe.Focus();
            }
            else
            {
                dottc.SOLUONGTLK = int.Parse(this.txtSoLuong.Text);
                dottc.NGAYLAP = this.dateNgayLap.Value;
                dottc.DONVITHICONG = DAL.C_KH_DonViTC.findDVTCbyTENCTY(this.cbDonViThiCong.Text).ID;

                if (!"1/1/0001".Equals(this.dateNgayChuyenHC.Value.ToShortDateString()))
                {
                    dottc.NGAYCHUYENHC = dateNgayChuyenHC.Value.Date;
                }
                if (!"1/1/0001".Equals(this.dateNgayChuyenKT.Value.ToShortDateString()))
                {
                    dottc.NGAYCHUYENKT = dateNgayChuyenKT.Value.Date;
                }
                if (!"1/1/0001".Equals(this.dateNgayThanhToan.Value.ToShortDateString()))
                {
                    dottc.NGAYTHANHTOAN = dateNgayThanhToan.Value.Date;
                }
                if (!"".Equals(txtGhiChuHoanCong.Text))
                {
                    dottc.GHICHUHC = txtGhiChuHoanCong.Text;
                }
                if (!"".Equals(txtSoLuong.Text))
                {
                    dottc.SOLUONG_HCTLK = int.Parse(txtSoLuong.Text);
                }
                if (!"".Equals(txtTon.Text))
                {
                    dottc.CONLAI_TLK = int.Parse(txtTon.Text);
                }
                if (!"".Equals(txtLyDoTroNgaiTC.Text))
                {
                    dottc.TRONGAITC = txtLyDoTroNgaiTC.Text;
                }
                dottc.QUYETTOAN = quyettoan;

                dottc.DONVITAILAP = DAL.C_KH_DonViTC.findDVTLbyTENCTY(this.cbDonViTaiLapMD.Text).ID;
                dottc.BANGKE = this.txtBangKe.Text;
                dottc.LOAIBANGKE = this.cbLoaiBangKe.Text;
                dottc.CREATEBY = DAL.C_USERS._userName;
                dottc.CREATEDATE = DateTime.Now.Date;

                if (DAL.C_KH_DotThiCong.UpdateDotTC(dottc) == false)
                    MessageBox.Show(this, "Cập Nhật Đợt Thi Công Không Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(this, "Cập Nhật Đợt Thi Công Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDataGrid();
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
                loadDataGrid();
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
                    loadDataGrid();
                }
            }
            catch (Exception)
            {

            }

        }

        private void btLuuDotMoi_Click(object sender, EventArgs e)
        {
            LuuDot();
            this.txtSodotTC.ReadOnly = true;
        }

        public void loadTextBox(KH_DOTTHICONG dottc) {        
            this.txtSodotTC.Text = dottc.MADOTTC;
            this.txtSoHoSo.Text = dottc.SOLUONGTLK+"";
            this.txtBangKe.Text = dottc.BANGKE;
            this.txtGhiChuHoanCong.Text = dottc.GHICHUHC;
            this.txtSoLuong.Text = dottc.SOLUONG_HCTLK != null ? dottc.SOLUONG_HCTLK + "" : "0";
            
            if (dottc.QUYETTOAN == true)
                this.txtQuetToan.Checked = true;
            else
                this.txtQuetToan.Checked = false;
            this.cbDonViThiCong.Text = DAL.C_KH_DonViTC.findDVTCbyID(int.Parse(dottc.DONVITHICONG+"")).TENCONGTY;
            this.cbDonViTaiLapMD.Text = DAL.C_KH_DonViTC.findDVTLbyID(int.Parse(dottc.DONVITAILAP+"")).TENCONGTY;
            this.dateChuyenBu.ValueObject =  dottc.CHUYENBUHANMUC;
            this.dateNgayLap.ValueObject = dottc.NGAYLAP;
            this.cbLoaiBangKe.Text = dottc.LOAIBANGKE;
            this.dateChuyenBu.ValueObject = dottc.CHUYENBUHANMUC;
            this.dateNgayChuyenHC.ValueObject = dottc.NGAYCHUYENHC;
            this.txtGhiChuHoanCong.Text = dottc.GHICHUHC;
            this.txtTon.Text = dottc.CONLAI_TLK != null ? dottc.CONLAI_TLK+"" : "0";
            this.dateNgayChuyenKT.ValueObject = dottc.NGAYCHUYENKT;
            this.dateNgayThanhToan.ValueObject = dottc.NGAYTHANHTOAN;
            this.txtLyDoTroNgaiTC.Text = dottc.TRONGAITC;

        }
        
        private void gridDotThiCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string dottcS = gridDotThiCong.Rows[e.RowIndex].Cells["gridSoDot"].Value + "";
                KH_DOTTHICONG dottc = DAL.C_KH_DotThiCong.findByMadot(dottcS);
                if (dottc != null)
                {
                    loadTextBox(dottc);
                }
            }
            catch (Exception)
            { 
            }
            
        }

        private void txtSearchDotTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                KH_DOTTHICONG dottc = DAL.C_KH_DotThiCong.findByMadot(this.txtSearchDotTC.Text);
                if (dottc != null)
                {
                    loadTextBox(dottc);
                }
                else {
                    MessageBox.Show(this, "Không Tìm Thấy Đợt Thi Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    refesh();
                    txtSearchDotTC.Text = "";
                    txtSearchDotTC.Focus();
                }
            }
        }

        private void txtSoHoSo_Leave(object sender, EventArgs e)
        {
            this.txtTon.Text = txtSoHoSo.Text;
        }

        private void txtSodotTC_Leave(object sender, EventArgs e)
        {
            this.txtSodotTC.Text = this.txtSodotTC.Text.ToUpper();

        }

        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            this.txtTon.Text = (int.Parse(txtSoHoSo.Text) - int.Parse(txtSoLuong.Text)) + "";
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {

            KH_DOTTHICONG dottc = DAL.C_KH_DotThiCong.findByMadot(this.txtSodotTC.Text);
            if (dottc != null) {
                UpdateDot(dottc);
            }

            this.txtSodotTC.ReadOnly = true;
        }

        private void txtSearchDotTC_Enter(object sender, EventArgs e)
        {
            MessageBox.Show(this, "safdsa");
        }

        public void tabClick() {

            string madot = "";
            try
            {
                madot = gridDotThiCong.Rows[gridDotThiCong.CurrentRow.Index].Cells["gridSoDot"].Value + "";

            }
            catch (Exception)
            {
            }
            if (!"".Equals(madot))
            {
                this.tabCapNhatDS.Controls.Clear();
                this.tabCapNhatDS.Controls.Add(new tab_CapNhatDSBoiThuong(madot));
              //  this.tabCapNhatDS.Controls.Add(new tab_CapNhatDanhSachND(madot));
                this.tabControl1.SelectedTabIndex = 1;
            }
            else
            {
                MessageBox.Show(this, "Cần Chọn Mã Đợt Để Xin Phép Đào Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void tabItem2_Click(object sender, EventArgs e)
        {
            tabClick();
        }

        private void btCapNhatGanMoiDoi_Click(object sender, EventArgs e)
        {
            tabClick();
        }

        private void btCapNhatBoiTuong_Click(object sender, EventArgs e)
        {
            tabClick();
        }

        private void btQuyetDinh_Click(object sender, EventArgs e)
        {
            string madot = "";
            try
            {
                madot = gridDotThiCong.Rows[gridDotThiCong.CurrentRow.Index].Cells["gridSoDot"].Value + "";

            }
            catch (Exception)
            {
            }
            if (!"".Equals(madot))
            {
                frmDialogPrintting obj = new frmDialogPrintting(madot);
                obj.ShowDialog(); 
            }
            else
            {
                MessageBox.Show(this, "Cần Chọn Mã Đợt Để Xin Phép Đào Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btInDanhSachGanMoi_Click(object sender, EventArgs e)
        {
            string madot = "";
            try
            {
                madot = gridDotThiCong.Rows[gridDotThiCong.CurrentRow.Index].Cells["gridSoDot"].Value + "";

            }
            catch (Exception)
            {
            }
            if (!"".Equals(madot))
            {
                ReportDocument rp = new rpt_DanhSachHSTC_GM();
                rp.SetDataSource(DAL.C_KH_DotThiCong.BC_DanhSachDotThiCong(madot));
                rpt_Main prM = new rpt_Main(rp);
                prM.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Cần Chọn Mã Đợt Để Xin Phép Đào Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        
    }
}
