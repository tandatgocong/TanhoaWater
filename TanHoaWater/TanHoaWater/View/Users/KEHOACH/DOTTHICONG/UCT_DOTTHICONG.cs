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
        }

        public void formload() {
            cbDonViThiCong.DataSource = DAL.C_KH_DonViTC.getDonViThiCong();
            cbDonViThiCong.DisplayMember = "TENCONGTY";
            cbDonViThiCong.ValueMember = "TENCONGTY";

            cbDonViTaiLapMD.DataSource = DAL.C_KH_DonViTC.getDonViTaiLap();
            cbDonViTaiLapMD.DisplayMember = "TENCONGTY";
            cbDonViTaiLapMD.ValueMember = "TENCONGTY";

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
            //bool quyettoan = false;
            //if (this.txtQuetToan.Checked)
            //    quyettoan = true;
            //else
            //    quyettoan = false;
            if ("".Equals(sodot)) {
                MessageBox.Show(this, "Nhập Số Đợt Thi Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtSodotTC.Text = "";
                this.txtSodotTC.Focus();
            }else if (DAL.C_KH_DotThiCong.findByMadot(sodot)!=null) {
                MessageBox.Show(this, "Số Đợt Thi Công Đã Có !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                dottc.MADOTTC = sodot;
                dottc.SOLUONGTLK = int.Parse(this.txtSoLuong.Text);
                dottc.NGAYLAP = this.dateNgayLap.Value;
                dottc.DONVITHICONG = this.cbDonViThiCong.Text;
                dottc.DONVITAILAP = this.cbDonViTaiLapMD.Text;
                dottc.BANGKE = this.txtBangKe.Text;
                dottc.LOAIBANGKE = this.cbLoaiBangKe.Text;
                dottc.CREATEBY = DAL.C_USERS._userName;
                dottc.CREATEDATE = DateTime.Now.Date;

                if (DAL.C_KH_DotThiCong.InsertDotTC(dottc) == false) {
                    MessageBox.Show(this, "Lỗi Thêm Đợt Thi Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                loadDataGrid();
              }
            //else if ("1/1/0001".Equals())
            //    {
            //        errorProvider1.SetError(this.createDate, "Ngày nhận đơn không hợp lệ.");
            //    }
            

        
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
        }

        public void loadTextBox(KH_DOTTHICONG dottc) {        
            this.txtSodotTC.Text = dottc.MADOTTC;
            this.txtSoHoSo.Text = dottc.SOLUONGTLK+"";
            this.txtBangKe.Text = dottc.BANGKE;
            this.txtGhiChuHoanCong.Text = dottc.GHICHUHC;
            this.txtSoLuong.Text = dottc.SOLUONG_HCTLK + "";
            this.txtTon.Text = dottc.CONLAI_TLK + "";
            if (dottc.QUYETTOAN == false)
                this.txtQuetToan.Checked = false;
            else
                this.txtQuetToan.Checked = true;
            this.cbDonViThiCong.Text = dottc.DONVITHICONG;
            this.cbDonViTaiLapMD.Text = dottc.DONVITAILAP;
            this.dateChuyenBu.ValueObject =  dottc.CHUYENBUHANMUC;
            this.dateNgayLap.ValueObject = dottc.NGAYLAP;

            //this.txtLyDoTroNgaiTC.Text = "";

            //this.dateChuyenBu.ValueObject = null;
            //this.dateNgayChuyenHC.ValueObject = null;
            //this.dateNgayChuyenKT.ValueObject = null;
            //this.dateNgayThanhToan.ValueObject = null;
            //this.dateNgayLap.Value = DateTime.Now.Date;
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
        
    }
}
