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
             currentPageIndex = 1;
             pageSize = 16;
             pageNumber = 0;
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
            currentPageIndex = 1;
            pageSize = 16;
            pageNumber = 0;
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
        string _mahieuvtDG = "";
        private void GridDanhMucTLMD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            else
            {
                _mahieuvtDG = this.GridDanhMucTLMD.Rows[e.RowIndex].Cells[0].Value + "";
                this.editMaDM.Text = this.GridDanhMucTLMD.Rows[e.RowIndex].Cells[0].Value + "";
                this.editTenKetCau.Text = this.GridDanhMucTLMD.Rows[e.RowIndex].Cells[1].Value + "";
                this.editcbDVT.Text = this.GridDanhMucTLMD.Rows[e.RowIndex].Cells[2].Value + "";
                string madanhmuc = this.GridDanhMucTLMD.Rows[e.RowIndex].Cells[0].Value + "";
                this.GridDonGiaVT.DataSource = DAL.C_DonGiaTaiLapMatDuong.getListByMADANHMUC(madanhmuc);
                Utilities.DataGridV.formatRows(GridDonGiaVT);
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
                else
                {
                    errorProvider1.Clear();
                    DANHMUCTAILAPMATDUONG dmtlmd = new DANHMUCTAILAPMATDUONG();
                    dmtlmd.MADANHMUC = maketcau;
                    dmtlmd.TENKETCAU = tenketcau;
                    dmtlmd.DVT = dvt;
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
                else
                {
                    errorProvider1.Clear();
                    DANHMUCTAILAPMATDUONG dmtlmd = DAL.C_DanhMucTaiLapMD.finbyMaDM(maketcau);
                    if (dmtlmd != null)
                    {                     
                        bool result=   DAL.C_DanhMucTaiLapMD.UpdateDanhMucTLMD(maketcau, tenketcau, dvt, DAL.C_USERS._userName);
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
        private void GridDonGiaVT_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                txtKeypress = e.Control;
                if (GridDonGiaVT.CurrentCell.OwningColumn.Name == "dg_dg" |  GridDonGiaVT.CurrentCell.OwningColumn.Name == "dg_vatlieu" | GridDonGiaVT.CurrentCell.OwningColumn.Name == "dg_nhanCong" | GridDonGiaVT.CurrentCell.OwningColumn.Name == "dgXiMang")
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
                    int stt = int.Parse(GridDonGiaVT.Rows[i].Cells["dg_ID"].Value + "");
                    string mahieudg = GridDonGiaVT.Rows[i].Cells["dg_mahieudg"].Value + "";
                    string check = GridDonGiaVT.Rows[i].Cells["dg_Chon"].Value + "";
                    DONGIATAILAPMATDUONG dgvt = DAL.C_DonGiaTaiLapMatDuong.finbyDonGiaTLMD(stt, mahieudg);
                    if (dgvt != null)
                    {
                        dgvt.CHON = bool.Parse(check);
                        double dongia = double.Parse(GridDonGiaVT.Rows[i].Cells["dg_dg"].Value + "");
                        dgvt.DONGIA = dongia;
                        double vt = double.Parse(GridDonGiaVT.Rows[i].Cells["dg_vatlieu"].Value + "");
                        dgvt.DGVATLIEU = vt;
                        double nc = double.Parse(GridDonGiaVT.Rows[i].Cells["dg_nhanCong"].Value + "");
                        dgvt.DGNHANCONG = nc;
                        double xm = double.Parse(GridDonGiaVT.Rows[i].Cells["dgXiMang"].Value + "");
                        dgvt.MODIFYBY = DAL.C_USERS._userName;
                        dgvt.MODIFYDATE = DateTime.Now.Date;
                        DAL.C_DonGiaTaiLapMatDuong.UpdateDGTL(dgvt);
                    }
                    else
                    {
                        dgvt = new DONGIATAILAPMATDUONG();
                        dgvt.STT = stt;
                        dgvt.MADANHMUC = mahieudg;
                        double dongia = double.Parse(GridDonGiaVT.Rows[i].Cells["dg_dg"].Value + "");
                        dgvt.DONGIA = dongia;
                        double vt = double.Parse(GridDonGiaVT.Rows[i].Cells["dg_vatlieu"].Value + "");
                        dgvt.DGVATLIEU = vt;
                        double nc = double.Parse(GridDonGiaVT.Rows[i].Cells["dg_nhanCong"].Value + "");
                        dgvt.DGNHANCONG = nc;
                        double xm = double.Parse(GridDonGiaVT.Rows[i].Cells["dgXiMang"].Value + "");
                        dgvt.DGMAYTHICONG = xm;
                        dgvt.NGAYHIEULUC = DateTime.Now.Date;
                        dgvt.CHON = bool.Parse(check);
                        dgvt.CREATEBY = DAL.C_USERS._userName;
                        dgvt.CREATEDATE = DateTime.Now.Date;
                        dgvt.CREATEBY = DAL.C_USERS._userName;
                        dgvt.CREATEDATE = DateTime.Now.Date;
                        DAL.C_DonGiaTaiLapMatDuong.InsertDGTL(dgvt);
                    }
                }
                MessageBox.Show(this, "Cập Nhật Đơn Giá Tái Lập Mặt Đường Thành Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                log.Error("Loi Khi Cap Nhat Don Gia Tai Lap Mat Duong " + ex.Message);
                MessageBox.Show(this, "Cập Nhật Đơn Giá Đơn Giá Tái Lập Mặt Đường Thất Bại.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GridDonGiaVT_Sorted(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(GridDonGiaVT);
        }

        private void GridDonGiaVT_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            GridDonGiaVT.Rows[GridDonGiaVT.CurrentRow.Index].Cells["dg_ngay"].Value = Utilities.DateToString.NgayVN(DateTime.Now);
            GridDonGiaVT.Rows[GridDonGiaVT.CurrentRow.Index].Cells["dg_ID"].Value = GridDonGiaVT.CurrentRow.Index + 1;
            GridDonGiaVT.Rows[GridDonGiaVT.CurrentRow.Index].Cells["dg_mahieudg"].Value = _mahieuvtDG;
        }

        private void GridDonGiaVT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7)
                {
                    //if ("False".Equals(this.dataGridView1.Rows[e.RowIndex].Cells[5].Value + ""))
                    //{

                    //}
                    //else {
                    //    this.dataGridView1.Rows[e.RowIndex].Cells[5].Value = "True";
                    //}
                    for (int i = 0; i < GridDonGiaVT.Rows.Count; i++)
                    {
                        this.GridDonGiaVT.Rows[i].Cells["dg_Chon"].Value = "False";
                    }
                    this.GridDonGiaVT.Rows[e.RowIndex].Cells["dg_Chon"].Value = "True";

                }
            }
            catch (Exception)
            {

            }
        }
    
    }
}