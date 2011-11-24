using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TanHoaWater.View.Users.To_ThietKe
{
    public partial class tab_GhepHoSo : UserControl
    {
        DataTable table;
        public tab_GhepHoSo()
        {
            InitializeComponent();
            this.txtSHS.Mask = DateTime.Now.Year.ToString().Substring(2) + "CCCCCC";
            init();
        }
        public void clear()
        {
            this.txtSHS.Text = null;
            this.txtSoHoSo.Text = null;
            this.txtHoTen.Text = null;
            this.duong.Text = null;
            this.cbDotNhanDon.Text = null;
            this.dienthoai.Text = null;
            this.txtSHS.Focus();
        }
        private void txtSHS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                try
                {
                    string _soHoSo = this.txtSHS.Text;
                    if (_soHoSo != null)
                    {
                        Database.DON_KHACHHANG donkh = DAL.C_DonKhachHang.findBySOHOSO(_soHoSo);
                        if (donkh != null)
                        {
                            this.txtSHS.Text = donkh.SHS;
                            this.txtSoHoSo.Text = donkh.SOHOSO;
                            this.txtHoTen.Text = donkh.HOTEN;
                            this.duong.Text = donkh.SONHA + " " + donkh.DUONG + ", P." + DAL.C_Phuong.finbyPhuong(donkh.QUAN, donkh.PHUONG).TENPHUONG + ", Q. " + DAL.C_Quan.finByMaQuan(donkh.QUAN).TENQUAN;
                            this.cbDotNhanDon.Text = donkh.MADOT;
                            this.dienthoai.Text = donkh.DIENTHOAI;
                        }
                        else {
                            MessageBox.Show(this, "Không Tìm Thấy Số Hồ Sơ !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clear();
                        }
                    }
                    else {
                        MessageBox.Show(this, "Nhập Số Hồ Sơ !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtSHS.Focus();
                    }

                }
                catch (Exception)
                {
                }
            }
        }
        void init() {
            table = new DataTable();
            table.Columns.Add("DOTNHANDON", typeof(string));
            table.Columns.Add("SOHOSO", typeof(string));
            table.Columns.Add("HOTEN", typeof(string));
            table.Columns.Add("DIACHI", typeof(string));
            table.Columns.Add("DIENTHOAI", typeof(string));
            table.Columns.Add("DAIDIEN", typeof(bool));

        }
        bool checkprimarykey(string sohoso) {
            for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                if (sohoso.Equals(dataGridView1.Rows[i].Cells[1].Value)) {
                    return false;
                }
            }
            return true;

        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (!"".Equals(txtSoHoSo.Text))
            {
                if (checkprimarykey(txtSHS.Text))
                {
                    DataRow row = table.NewRow();
                    row["DOTNHANDON"] = this.cbDotNhanDon.Text;
                    row["SOHOSO"] = this.txtSHS.Text;
                    row["HOTEN"] = this.txtHoTen.Text;
                    row["DIACHI"] = this.duong.Text;
                    row["DIENTHOAI"] = this.dienthoai.Text;
                    row["DAIDIEN"] = false;
                    table.Rows.Add(row);
                    this.dataGridView1.DataSource = table;
                    Utilities.DataGridV.formatRows(dataGridView1);
                    clear();
                }
                else {
                    MessageBox.Show(this, "Số Hồ Sơ đã được tồn tại. ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clear();
                }
                
                
            }
            else {
                MessageBox.Show(this, "Nhập Số Hồ Sơ Khách Hàng !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtSHS.Focus();
            }
        }

        string parent = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    //if ("False".Equals(this.dataGridView1.Rows[e.RowIndex].Cells[5].Value + ""))
                    //{

                    //}
                    //else {
                    //    this.dataGridView1.Rows[e.RowIndex].Cells[5].Value = "True";
                    //}
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        this.dataGridView1.Rows[i].Cells[5].Value = "False";
                    }
                    this.dataGridView1.Rows[e.RowIndex].Cells[5].Value = "True";

                }
            }
            catch (Exception)
            {
                 
            }
           
        }

        private void btGhep_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ("True".Equals(this.dataGridView1.Rows[i].Cells[5].Value + ""))
                    {
                        parent = this.dataGridView1.Rows[i].Cells[1].Value + "";
                        break;
                    }
                }
                if(!"".Equals(parent)){
                    int number = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string soshs = this.dataGridView1.Rows[i].Cells[1].Value + "";
                        if (parent.Equals(soshs) == false)
                        {
                            DAL.C_DonKhachHang.UpdateHoSoCon(soshs, parent);
                        }
                        number++;
                    }
                    if (DAL.C_DonKhachHang.UpdateHoSoCha(parent, number))
                    {
                        MessageBox.Show(this, "Ghép Hồ Sơ Thành Công ! ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Ghép Hồ Sơ Lỗi ! ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }else{
                    MessageBox.Show(this, "Cần Chọn Hồ Sơ Đại Diện ! ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (Exception)
            {
                
               
            }
            
            
        }
       
    }
}
