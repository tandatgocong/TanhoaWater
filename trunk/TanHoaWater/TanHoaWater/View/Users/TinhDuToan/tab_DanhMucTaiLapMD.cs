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

namespace TanHoaWater.View.Users.TinhDuToan
{
    public partial class tab_DanhMucTaiLapMD : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_DanhMucVT).Name);
        int currentPageIndex = 1;
        int pageSize = 16;
        int pageNumber = 0;
        int FirstRow, LastRow;
        int rows;

        public tab_DanhMucTaiLapMD()
        {
            InitializeComponent();
            this.cbDVT.DataSource = DAL.C_DonViTinh.getDVT();
            this.cbDVT.ValueMember = "Value";
            this.cbDVT.DisplayMember = "Display";
            this.editcbDVT.DataSource = DAL.C_DonViTinh.getDVT();
            this.editcbDVT.ValueMember = "Value";
            this.editcbDVT.DisplayMember = "Display";
            search();
           Utilities.DataGridV.formatRows(GridDanhMucTLMD);
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
        public void search()
        {
            rows = DAL.C_DanhMucTaiLapMD.TotalSearch(this.txtMaDM.Text.Trim(), this.txtTenKC.Text.Trim(), this.cbDVT.Text.Trim());
            GridDanhMucTLMD.DataSource = DAL.C_DanhMucTaiLapMD.search(this.txtMaDM.Text.Trim(), this.txtTenKC.Text.Trim(), this.cbDVT.Text.Trim(), FirstRow, pageSize);
            this.totalRecord.Text = "Tống Cộng Có " + rows + " Danh Mục Vật Tư. ";
           Utilities.DataGridV.formatRows(GridDanhMucTLMD);
            PageTotal();

        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void GridDanhMucTLMD_Sorted(object sender, EventArgs e)
        {
           Utilities.DataGridV.formatRows(GridDanhMucTLMD);
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (currentPageIndex < pageNumber)
            {
                currentPageIndex = currentPageIndex + 1;
                FirstRow = pageSize * (currentPageIndex - 1);
                LastRow = pageSize * (currentPageIndex);
                PageTotal();
                search();

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
                    search();
                }
            }
            catch (Exception)
            {

            }
        }

        private void btLamLai_Click(object sender, EventArgs e)
        {
            this.txtMaDM.Text = "";
            this.txtTenKC.Text = "";
            this.cbDVT.Text = "";
            search();
        }

        private void txtMaDM_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    search();
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtTenKC_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    search();
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
                search();
            }
            catch (Exception)
            {

            }
        }

        private void GridDanhMucTLMD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            else
            {
                this.editMaDM.Text = this.GridDanhMucTLMD.Rows[e.RowIndex].Cells[0].Value + "";
                this.editTenKetCau.Text = this.GridDanhMucTLMD.Rows[e.RowIndex].Cells[1].Value + "";
                this.editcbDVT.Text = this.GridDanhMucTLMD.Rows[e.RowIndex].Cells[2].Value + "";
                this.editDonGia.Text = Utilities.FormatNumber.FormatDouble(this.GridDanhMucTLMD.Rows[e.RowIndex].Cells[3].Value + "");
                this.editDonGiaSo.Text = this.GridDanhMucTLMD.Rows[e.RowIndex].Cells[4].Value + "";
            }
           Utilities.DataGridV.formatRows(GridDanhMucTLMD);
        }

        private void editDonGia_KeyPress(object sender, KeyPressEventArgs e)
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

        private void editDonGiaSo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            try
            {
                string maketcau = this.editMaDM.Text;
                string tenketcau = this.editTenKetCau.Text;
                string dvt = this.editcbDVT.Text;
                string dongia = this.editDonGia.Text;
                string dongiaso = this.editDonGiaSo.Text;
                if ("".Equals(maketcau))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(this.editMaDM, "Nhâp Mã Kết Cấu.");
                    this.editMaDM.Focus();
                }
                else if ("".Equals(tenketcau))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(this.editTenKetCau, "Nhâp Tên Kết Cấu.");
                    this.editTenKetCau.Focus();
                }
                else if ("".Equals(dvt))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(this.editcbDVT, "Chọn Đơn Vị Tính.");
                    this.editcbDVT.Focus();
                }
                else if ("".Equals(dongia))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(this.editDonGia, "Nhập Đơn Giá.");
                    this.editDonGia.Focus();
                }
                else if (DAL.C_DanhMucTaiLapMD.finbyMaDM(maketcau) != null)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(this.editMaDM, "Mã Kế Cấu Đã Tồn Tại.");
                    this.editDonGia.Focus();
                }
                else
                {
                    errorProvider1.Clear();
                    DANHMUCTAILAPMATDUONG dmtlmd = new DANHMUCTAILAPMATDUONG();
                    dmtlmd.MADANHMUC = maketcau;
                    dmtlmd.TENKETCAU = tenketcau;
                    dmtlmd.DVT = dvt;
                    dmtlmd.DONGIA = double.Parse(dongia);
                    dmtlmd.DONGIASO = int.Parse(dongiaso);
                    dmtlmd.CREATEBY = DAL.C_USERS._userName;
                    dmtlmd.CREATEDATE = DateTime.Now.Date;
                    DAL.C_DanhMucTaiLapMD.InsertDanhMucTLMD(dmtlmd);
                    MessageBox.Show(this, "Thêm Mới Danh Mục Đơn Giá Tái Lập Mặt Đường Thành Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    search();

                }
            }
            catch (Exception ex)
            {
                log.Error("Thêm Danh Muc Tai Lap Mat Bang Loi " + ex.Message);
                MessageBox.Show(this, "Thêm Mới Danh Mục Đơn Giá Tái Lập Mặt Đường Thất Bại.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Xóa Danh Mục Đơn Giá Tái Lập Mặt Đường ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                DANHMUCTAILAPMATDUONG dmtlmd = DAL.C_DanhMucTaiLapMD.finbyMaDM(this.editMaDM.Text);
                if (dmtlmd!=null)
                {
                   bool result =  DAL.C_DanhMucTaiLapMD.DeleteDanhMucTLMD(dmtlmd);
                   if (result)
                   {
                       MessageBox.Show(this, "Xóa Danh Mục Đơn Giá Tái Lập Mặt Đường Thành Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   }
                   else {
                       MessageBox.Show(this, "Xóa Danh Mục Đơn Giá Tái Lập Mặt Đường Thất Bại.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }
                    editlamlai();
                    search();
                }
                else {
                    MessageBox.Show(this, "Không Tìm Thấy Mã Danh Mục Để Xóa.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        void editlamlai() {
            this.editMaDM.Text = "";
            this.editTenKetCau.Text = ""; 
            this.editcbDVT.Text = ""; 
            this.editDonGia.Text = ""; 
            this.editDonGiaSo.Text = null; 
        }
        private void btmLamLai_Click(object sender, EventArgs e)
        {
            editlamlai();
            search();
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                string maketcau = this.editMaDM.Text;
                string tenketcau = this.editTenKetCau.Text;
                string dvt = this.editcbDVT.Text;
                string dongia = this.editDonGia.Text;
                string dongiaso = this.editDonGiaSo.Text;
                if ("".Equals(maketcau))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(this.editMaDM, "Nhâp Mã Kết Cấu.");
                    this.editMaDM.Focus();
                }
                else if ("".Equals(tenketcau))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(this.editTenKetCau, "Nhâp Tên Kết Cấu.");
                    this.editTenKetCau.Focus();
                }
                else if ("".Equals(dvt))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(this.editcbDVT, "Chọn Đơn Vị Tính.");
                    this.editcbDVT.Focus();
                }
                else if ("".Equals(dongia))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(this.editDonGia, "Nhập Đơn Giá.");
                    this.editDonGia.Focus();
                }                
                else
                {
                    errorProvider1.Clear();
                    DANHMUCTAILAPMATDUONG dmtlmd = DAL.C_DanhMucTaiLapMD.finbyMaDM(maketcau);
                    if (dmtlmd != null)
                    {                     
                        bool result=   DAL.C_DanhMucTaiLapMD.UpdateDanhMucTLMD(maketcau, tenketcau, dvt, double.Parse(dongia), int.Parse(dongiaso), DAL.C_USERS._userName);
                        if (result)
                        {
                            MessageBox.Show(this, "Cập Nhật Danh Mục Đơn Giá Tái Lập Mặt Đường Thành Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }else{
                            MessageBox.Show(this, "Cập Nhật Danh Mục Đơn Giá Tái Lập Mặt Đường Lỗi.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                        search();
                    }
                    else {
                        MessageBox.Show(this, "Không Tìm Thấy Mã Danh Mục Để Cập Nhật.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                

                }
            }
            catch (Exception ex)
            {
                log.Error("Cập Nhật Danh Muc Tai Lap Mat Bang Loi " + ex.Message);
                MessageBox.Show(this, "Cập Nhật Mới Danh Mục Đơn Giá Tái Lập Mặt Đường Thất Bại.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }
    }
}