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

namespace TanHoaWater.View.Administrators
{
    public partial class ut_HeThongDuong : UserControl
    {
        int currentPageIndex = 1;
        int pageSize = 23;
        int pageNumber = 0;
        int FirstRow, LastRow;
        int rows;
        private static readonly ILog log = LogManager.GetLogger(typeof(ut_HeThongDuong).Name);
        public ut_HeThongDuong()
        {
            InitializeComponent();
            fromLoad();


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
                search();
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
                    search();
                }
            }
            catch (Exception)
            {

            }

        }
        public void fromLoad()
        {
            this.cbPhuong.DataSource = DAL.C_TenDuong.getPhuong();
            this.cbPhuong.DisplayMember = "Display";
            this.cbPhuong.ValueMember = "Display";
            this.cbQuan.DataSource = DAL.C_TenDuong.getQuan();
            this.cbQuan.DisplayMember = "Display";
            this.cbQuan.ValueMember = "Value";

            this.addPhuong.DataSource = DAL.C_Phuong.getListPhuongAdmin();
            this.addPhuong.DisplayMember = "TENPHUONG";
            this.addPhuong.ValueMember = "MAQUAN";
            this.add_Quan.DataSource = DAL.C_Quan.getList();
            this.add_Quan.DisplayMember = "TENQUAN";
            this.add_Quan.ValueMember = "MAQUAN";
            search();

        }
        public void search()
        {
            string phuong = this.cbPhuong.SelectedValue + "";
            if ("  Chọn Phường  ".Equals(this.cbPhuong.SelectedValue))
            {
                phuong = "";
            }
            try
            {
                rows = DAL.C_TenDuong.TotalListDuong(this.txtTenDuong.Text, phuong, this.cbQuan.SelectedValue + "");
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            PageTotal();
            this.dataGridViewX1.DataSource = DAL.C_TenDuong.getListDuong(this.txtTenDuong.Text, phuong, this.cbQuan.SelectedValue + "", FirstRow, pageSize);

        }
        private void btTimKiem_Click(object sender, EventArgs e)
        {
            currentPageIndex = 1;
            pageSize = 23;
            pageNumber = 0;
            FirstRow = 0;
            LastRow = 0;
            search();
        }

        private void addPhuong_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.add_Quan.Text = DAL.C_Quan.finByMaQuan(int.Parse(this.addPhuong.SelectedValue + "")).TENQUAN;
            }
            catch (Exception)
            {

            }
        }
        string _id = "";
        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _id = dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells[0].Value + "";
                string _tenduong = dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells[1].Value + "";
                string _phuong = dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells[2].Value + "";
                string _quan = dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells[3].Value + "";
                this.add_tenduong.Text = _tenduong;
                this.addPhuong.Text = _phuong;
                this.add_Quan.Text = _quan;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            QUAN quan = DAL.C_Quan.finbyTenQuan(this.add_Quan.Text);
            PHUONG phuong = null;
            if (quan != null)
            {
                phuong = DAL.C_Phuong.finbyTenPhuong(quan.MAQUAN, this.addPhuong.Text);
                if (phuong != null)
                {
                    try
                    {
                        TENDUONG _duong = new TENDUONG();
                        _duong.DUONG = this.add_tenduong.Text;
                        _duong.MAPHUONG =  phuong.MAPHUONG;
                        _duong.MAQUAN = phuong.MAQUAN;

                        if (DAL.C_TenDuong.InsertDuong( _duong))
                        {
                            MessageBox.Show(this, "Thêm Tên Đường Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            search();
                        }
                        else
                        {
                            MessageBox.Show(this, "Thêm Tên Đường Lỗi !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(this, "Thêm Tên Đường Lỗi  !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Thêm Tên Đường Lỗi  !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, "Thêm Tên Đường Lỗi  !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            if ("".Equals(_id) == false)
            {
                QUAN quan = DAL.C_Quan.finbyTenQuan(this.add_Quan.Text);
                PHUONG phuong = null;
                if (quan != null)
                {
                    phuong = DAL.C_Phuong.finbyTenPhuong(quan.MAQUAN, this.addPhuong.Text);
                    if (phuong != null)
                    {
                        try
                        {
                            if (DAL.C_TenDuong.UpdateDuong(int.Parse(_id), this.add_tenduong.Text, phuong.MAPHUONG, phuong.MAQUAN))
                            {
                                MessageBox.Show(this, "Cập Nhật Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                search();
                            }
                            else
                            {
                                MessageBox.Show(this, "Lỗi Dữ Liệu Khi Cập Nhật !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(this, "Cập Nhật Tên Đường Bị Lỗi  !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Lỗi Dữ Liệu Khi Cập Nhật !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Lỗi Dữ Liệu Khi Cập Nhật !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show(this, "Không Tìm Thấy Dữ Liệu Để Cập Nhật !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void refesh() {
            this.add_tenduong.Text = "";
            this.addPhuong.Text = "";
            this.add_Quan.Text = "";
        }
        private void btXoa_Click(object sender, EventArgs e)
        {
            if ("".Equals(_id) == false)
            {
                try
                {
                    string tenduong = "Có Muốn Xóa Đường " + this.add_tenduong.Text + " ?";

                    if(MessageBox.Show(this,tenduong,"..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes){
                    if (DAL.C_TenDuong.Delete(int.Parse(_id)))
                    {
                        MessageBox.Show(this, "Xóa Tên Đường Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        search();
                        refesh();
                    }
                    else
                    {
                        MessageBox.Show(this, "Lỗi Khi Xóa Tên Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    }
                    
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "Lỗi Khi Xóa Tên Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, "Không Tìm Thấy Dữ Liệu Để Xóa !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}