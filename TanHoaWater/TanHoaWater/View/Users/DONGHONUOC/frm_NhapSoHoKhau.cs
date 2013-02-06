using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;
using log4net;

namespace TanHoaWater.View.Users.DONGHONUOC
{
    public partial class frm_NhapSoHoKhau : Form
    {
        string _sodanhbo = "";
        public  int sonk=0;
        public frm_NhapSoHoKhau(string sodanhbo, string shs, string  hoten, string diachi)
        {
            InitializeComponent();
            this.lbDanhBo.Text = " Nhập Số Hộ Khẩu Cho DB : " + sodanhbo ;
            _sodanhbo = sodanhbo;
            this.lbHoTen.Text = ": " + hoten;
            this.lbDiaChi.Text = ": " + diachi;
            this.lbSoHoSo.Text = ": " + shs;
            this.dataGridViewX1.DataSource = DAL.C_DHN_HoKhau.finbySoDanhBo(_sodanhbo.Replace(".",""));
            sonk = 0;
        }

        private static readonly ILog log = LogManager.GetLogger(typeof(frm_NhapSoHoKhau).Name);
        void Insert()
        {
            try
            {
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string soHoHK = dataGridViewX1.Rows[i].Cells["soHoHK"].Value + "";
                    string hk_GhiChu = dataGridViewX1.Rows[i].Cells["hk_GhiChu"].Value + "";
                    string hk_nhankhau = dataGridViewX1.Rows[i].Cells["gr_NhanKhau"].Value !=null ? dataGridViewX1.Rows[i].Cells["gr_NhanKhau"].Value+"": "0";
                    if (!"".Equals(soHoHK))
                    {
                        DB_HOKHAU hk = new DB_HOKHAU();
                        hk.SODANHBO = _sodanhbo.Replace(".", "");
                        hk.SOHOKHAU = soHoHK;
                        hk.SONHANKHAU = int.Parse(hk_nhankhau);
                        sonk += int.Parse(hk_nhankhau);
                        hk.GHICHU = hk_GhiChu;
                        hk.CREATEDATE = DateTime.Now;
                        hk.CREATEBY = DAL.C_USERS._userName;
                        DAL.C_DHN_HoKhau.Insert(hk);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Cap Nhat Ho Khau Loi : " + _sodanhbo + ex.Message);
            }
           
        }
        private void frm_NhapSoHoKhau_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX1.CurrentCell.OwningColumn.Name == "soHoHK")
            {
                string soHoHK = dataGridViewX1.Rows[dataGridViewX1.CurrentCell.RowIndex].Cells["soHoHK"].Value + "";
                if(!"".Equals(soHoHK)){
                    string mess = "";
                    List<DB_HOKHAU> sohk = DAL.C_DHN_HoKhau.finbySoHoKhau(soHoHK);
                    if (sohk.Count > 0) {
                        foreach (var item in sohk)
                        {
                            mess += item.SODANHBO + ", ";
                        }
                        MessageBox.Show(this, "Số Hộ Khẩu Đã Tồn Trong Danh Bộ " + mess, "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btInBangKe_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.C_DHN_HoKhau.Delete(_sodanhbo.Replace(".", ""));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            Insert();
            
        }
    }
}
