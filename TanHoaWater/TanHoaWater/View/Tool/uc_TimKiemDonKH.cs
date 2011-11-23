using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TanHoaWater.View.Tool
{
    public partial class uc_TimKiemDonKH : UserControl
    {
        public uc_TimKiemDonKH()
        {
            InitializeComponent();
            this.SearchMaHoSo.Mask =  "CCCCCCCC";
        }

        private void uc_TimKiemDonKH_Load(object sender, EventArgs e)
        {
           
        }
        public void refesh() { 
            this.SearchMaHoSo.Text="";
            this.searchHoTenKH.Text="";
            this.searchDiaChi.Text = "";          
            this.SearchMaHoSo.Focus();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                this.dataGridView1.Rows.RemoveAt(i);
            }
            
        }
        string ngaygiaoTTK = "";
        string ngaygiaoSDV = "";
        string ngaytringky = "";
        string trongaiTK = "";
        string noidungTK = "";
        void search() {
            DataTable table = DAL.C_DonKhachHang.TimKiemDonKhachHang(this.SearchMaHoSo.Text, this.searchHoTenKH.Text, this.searchDiaChi.Text);
            this.dataGridView1.DataSource = table;
            Utilities.DataGridV.formatRows(dataGridView1);
            if (table.Rows.Count <= 0) {
                MessageBox.Show(this, "Không Tìm Thấy Thông Tin Khách Hàng !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refesh();
            }
            if (table.Rows.Count == 1)
            {
                this.txtDotND.Text = dataGridView1.Rows[0].Cells[0].Value + "";
                this.txtShs.Text = dataGridView1.Rows[0].Cells[1].Value + "";
                this.txtSoHoSo.Text = dataGridView1.Rows[0].Cells[2].Value + "";
                this.txtHoTen.Text = dataGridView1.Rows[0].Cells[4].Value + "";
                this.txtdiachi.Text = dataGridView1.Rows[0].Cells[6].Value + "";
                this.txtSoDT.Text = dataGridView1.Rows[0].Cells[5].Value + "";
                this.txtLoaiKH.Text = dataGridView1.Rows[0].Cells[8].Value + "";
                this.txtLoaiHS.Text = dataGridView1.Rows[0].Cells[9].Value + "";
                this.txtNgayNhanHS.Text = dataGridView1.Rows[0].Cells[10].Value + "";
                ngaygiaoTTK = dataGridView1.Rows[0].Cells[11].Value + "";
                this.txtNgayGiaoTTK.Text = ngaygiaoTTK;
                ngaygiaoSDV = DAL.C_USERS.findByUserName(dataGridView1.Rows[0].Cells[12].Value + "").FULLNAME;
                this.txtSoDoVien.Text = ngaygiaoSDV;                
               // ngaytringky= dataGridView1.Rows[0].Cells[13].Value + "";
                ngaytringky = dataGridView1.Rows[0].Cells[13].Value + "";
                this.txtNgayTrinhKyGD.Text = ngaytringky;
                trongaiTK = dataGridView1.Rows[0].Cells[15].Value + "";
                noidungTK = dataGridView1.Rows[0].Cells[16].Value + "";
                result();
            }
            try
            {
                dataGridView1.Columns["NGAYGIAOTTK_"].Visible = false;
            }
            catch (Exception)
            {
            }
           
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        //    for (int i = 0; i < dataGridView1.Rows[e.RowIndex].Cells.Count; i++)
        //    {
        //        MessageBox.Show(this, dataGridView1.Rows[e.RowIndex].Cells[i].Value + "");
        //    }
            try
            {
                 this.txtDotND.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value+"";
                this.txtShs.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value + "";
                this.txtSoHoSo.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value + "";
                this.txtHoTen.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value + "";
                this.txtdiachi.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value + "";
                this.txtSoDT.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value + "";
                this.txtLoaiKH.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value + "";
                this.txtLoaiHS.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value + "";
                this.txtNgayNhanHS.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value + "";
                ngaygiaoTTK = dataGridView1.Rows[e.RowIndex].Cells[11].Value + "";
                this.txtNgayGiaoTTK.Text = ngaygiaoTTK;
                ngaygiaoSDV = DAL.C_USERS.findByUserName(dataGridView1.Rows[e.RowIndex].Cells[12].Value + "").FULLNAME;
                this.txtSoDoVien.Text = ngaygiaoSDV;
                ngaytringky = dataGridView1.Rows[e.RowIndex].Cells[13].Value + "";
                this.txtNgayTrinhKyGD.Text = ngaytringky;
                trongaiTK = dataGridView1.Rows[e.RowIndex].Cells[15].Value + "";
                noidungTK = dataGridView1.Rows[e.RowIndex].Cells[16].Value + "";
                result();
            }
            catch (Exception)
            {
                
            } 


        }

        private void SearchMaHoSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                search();
            }
        }

        private void searchHoTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                search();
            }
        }

        private void searchDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                search();
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            refesh();
        }
        public void result() {
          
            groupBox1.Visible = true;
            if ("True".Equals(trongaiTK)) {
                lbresult.Text = "HỒ SƠ TRỞ NGẠI THIẾT KẾ";
                lbresult.ForeColor = Color.Red;
                resultNoiDung.Text = noidungTK;
            } else {
                lbresult.ForeColor = Color.Blue;
                if (!"".Equals(ngaytringky))
                {
                    lbresult.Text = "HỒ SƠ ĐANG HOÀN THÀNH ";
                    resultNoiDung.Text = "Hồ Sơ Trình Ký Ban Giám Đốc";
                }
                else if (!"".Equals(ngaygiaoTTK))
                {
                    lbresult.Text = "HỒ SƠ ĐANG HOÀN THÀNH ";
                    resultNoiDung.Text = "Hồ Sơ Đang Khảo Sát Thiết Kế";
                }
                else {
                    lbresult.Text = "HỒ SƠ ĐANG HOÀN THÀNH ";
                    resultNoiDung.Text = "Hồ Sơ Chưa Chuyển Tồ Thiết Kế";
                }
                    
                //string ngaygiaoTTK = "";
                //string ngaygiaoSDV = "";
                //string ngaytringky = "";
            }
        
        }
    }
}
