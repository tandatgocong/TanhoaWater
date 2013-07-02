using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace TanHoaWater.View.Users.KEHOACH
{
    public partial class tab_DonTroNgai : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_DonTroNgai).Name);
        public tab_DonTroNgai()
        {
            InitializeComponent();
            txtSHS.Focus();
        }

        private void txtSHS_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtResult.Text = null;
            if (e.KeyChar == 13)
            {
                try
                {
                    refesh();
                    string _soHoSo = this.txtSHS.Text;
                    if (_soHoSo != null)
                    {

                        Database.DON_KHACHHANG donkh = DAL.C_DonKhachHang.findBySOHOSO(_soHoSo);
                        if (donkh != null)
                        {
                            this.txtSHS.Text = donkh.SHS;
                            this.txtSoHoSo.Text = donkh.SOHOSO;
                            this.txtSoHo.Value = decimal.Parse(donkh.SOHO.ToString());
                            this.txtHoTen.Text = donkh.HOTEN;
                            this.txtdiachi.Text = donkh.SONHA + " " + donkh.DUONG + ", P. " + DAL.C_Phuong.finbyPhuong(donkh.QUAN, donkh.PHUONG).TENPHUONG + ", Q." + DAL.C_Quan.finByMaQuan(donkh.QUAN).TENQUAN;
                            this.txtLoaiKH.Text = DAL.C_LoaiKhachHang.finbyMaLoai(donkh.LOAIKH).TENLOAI;
                            this.txtLoaiHS.Text = DAL.C_LoaiHoSo.findbyMaLoai(donkh.LOAIHOSO).TENLOAI;
                            this.txtDotND.Text = donkh.MADOT;
                            this.txtSoDT.Text = donkh.DIENTHOAI;
                            this.txtGhiChu.Text = donkh.GHICHU;
                            Database.TOTHIETKE ttk = DAL.C_ToThietKe.findBySoHoSo(donkh.SOHOSO);
                            if (ttk != null)
                            {
                                if (ttk.TRONGAITHIETKE == true)
                                {
                                    this.txtnoidungtrongai.Text = ttk.NOIDUNGTRONGAI;


                                }
                                Database.USER us = DAL.C_USERS.findByUserName(ttk.SODOVIEN);
                                if (us != null)
                                {
                                    this.txt_sdv.Text = us.FULLNAME;
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show(this, "Không Tìm Thấy Đơn Khách Hàng", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.txtSHS.Text = null;
                            this.txtSoHoSo.Text = null;
                            this.txtSoHo.Value = 0;
                            this.txtHoTen.Text = null;
                            this.txtdiachi.Text = null;
                            this.txtLoaiKH.Text = null;
                            this.txtLoaiHS.Text = null;
                            this.txtDotND.Text = null;
                            this.txtSoDT.Text = null;
                            this.txtGhiChu.Text = null;
                            this.txt_sdv.Text = null;
                        }
                    }

                }
                catch (Exception)
                {
                }
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string _soHoSo = this.txtSoHoSo.Text;
                if (_soHoSo != null)
                {
                    bool result1 = DAL.C_DonKhachHang.TroNgaiThietKe(_soHoSo, this.txtnoidungtrongai.Text, DAL.C_USERS._userName);
                    if (result1)
                    {
                        MessageBox.Show(this, "Cập Nhật Hồ Sơ Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Cập Nhật Hồ Sơ Lỗi !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Loi tra ho so " + ex.Message);
                MessageBox.Show(this, "Cập Nhật Hồ Sơ Lỗi !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void refesh() {
           
            this.txtSoHoSo.Text = null;
            this.txtSoHo.Value = 0;
            this.txtHoTen.Text = null;
            this.txtdiachi.Text = null;
            this.txtLoaiKH.Text = null;
            this.txtLoaiHS.Text = null;
            this.txtDotND.Text = null;
            this.txtSoDT.Text = null;
            this.txtGhiChu.Text = null;
            this.txt_sdv.Text = null;
            this.txtnoidungtrongai.Text = "";

        }
        private void refresh_Click(object sender, EventArgs e)
        {
            refesh();
            this.txtSHS.Text = null;
            this.txtSHS.Focus();
        }

      
        private void buttonX4_Click(object sender, EventArgs e)
        {
            int shs = int.Parse(this.txtSHS.Text);
            int n = int.Parse(this.txtSoHo.Value.ToString());
            string sohoso = "";
            for (int i = 0; i < n; i++) {
                shs = shs+1;
                sohoso += "'" + (shs) + "',";
            }
            sohoso = sohoso+"''";

            string sql="SELECT  biennhan.SHS, biennhan.HOTEN,( SONHA +'  '+DUONG+',  P.'+ p.TENPHUONG+',  Q.'+q.TENQUAN) as 'DIACHI',DIENTHOAI  ";
sql += " FROM QUAN q,PHUONG p,DON_KHACHHANG biennhan ";
sql += " WHERE biennhan.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN   ";
sql += "  AND biennhan.PHUONG=p.MAPHUONG ";
sql += "  AND biennhan.SHS IN (" + sohoso + ") ";
dataGridView1.DataSource = DAL.LinQConnection.getDataTable(sql);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        this.dataGridView1.Rows[i].Cells[0].Value = "False";
                    }
                    this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = "True";

                }
            }
            catch (Exception)
            {

            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string parent = "";
            int i = 0;
            bool flag = false;
            for ( i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if ("True".Equals(this.dataGridView1.Rows[i].Cells[0].Value + ""))
                {
                    parent = this.dataGridView1.Rows[i].Cells[1].Value + "";
                    flag = true;
                    break;
                   
                }
            }
            if (flag)
            {
                this.txtHoTen.Text = this.txtHoTen.Text.Replace(" (ĐD " + txtSoHo.Value + " Hộ)", "");
                txtSoHo.Value = 1;
                string sql = "UPDATE DON_KHACHHANG SET SOHO=0, HOTEN='" + this.txtHoTen.Text.Replace(" (ĐD " + txtSoHo.Value + " Hộ)", "") + "', SONHA_TTK=N'Đại diện trở ngại chuyển ĐD hồ sơ : " + parent + "'  WHERE SHS='" + this.txtSHS.Text + "'";
                DAL.LinQConnection.ExecuteCommand_(sql);
                sql = "UPDATE DON_KHACHHANG SET SOHO=" + dataGridView1.Rows.Count + ", HOTEN =(HOTEN + N' (ĐD " + dataGridView1.Rows.Count + " Hộ)'), HOSOCHA='" + this.txtSHS.Text + "'" + " WHERE SHS='" + parent + "'";
                DAL.LinQConnection.ExecuteCommand_(sql);
                this.dataGridView1.Rows[i].Cells[2].Value = this.dataGridView1.Rows[i].Cells[2].Value + " (ĐD " + dataGridView1.Rows.Count + " Hộ)";
                MessageBox.Show(this, "Cập Nhật Hồ Sơ Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show(this, "Cập Nhật Hồ Sơ Lỗi !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}