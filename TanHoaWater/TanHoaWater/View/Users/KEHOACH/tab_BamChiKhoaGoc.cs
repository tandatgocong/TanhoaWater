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
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.KEHOACH.Report;
using TanHoaWater.DULIEUKH;

namespace TanHoaWater.View.Users.KEHOACH
{
    public partial class tab_BamChiKhoaGoc : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_BamChiKhoaGoc).Name);
        public tab_BamChiKhoaGoc()
        {
            InitializeComponent();
            this.txtSoBangKe.Text = DAL.Idetity.IdentityDutChi();
        }
        public void pLoad()
        {
           
            this.txtShS.Text = "";
            this.txtHoTenKH.Text = "";
            this.txtDiaChi.Text = "";
            this.textBoxX2DB.Text = "";
            this.txtSoHoaDon.Text = "";
            this.txtGHiChu.Text = "";
            txtShS.Focus();

        }

        private void txtShS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DataTable table = DAL.C_KHDonBamChi.findByHSHT(this.txtShS.Text);
                if (table.Rows.Count <= 0)
                {
                    MessageBox.Show(this, "Không Tìm Thấy Hồ Sơ !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.txtHoTenKH.Text = table.Rows[0][2].ToString();
                    this.txtDiaChi.Text = table.Rows[0][3].ToString();
                    this.dateNgayDongTien.ValueObject = table.Rows[0][4];
                    this.txtSoHoaDon.Text = table.Rows[0][5].ToString();
                    this.textBoxX2DB.Text = table.Rows[0]["DANHBO"].ToString();
                    txtSoTien.Text = String.Format("{0:0,0}", table.Rows[0]["SOTIEN"] != null ? table.Rows[0]["SOTIEN"] : 0.0).Replace(",", ".");
                }
            }
        }

        private void btLuuHoSo_Click(object sender, EventArgs e)
        {
            KH_HOSOBAMCHIGOC hs = new KH_HOSOBAMCHIGOC();
            hs.SoBangKe = this.txtSoBangKe.Text;
            hs.SHS = this.txtShS.Text.ToUpper();
            hs.HoTen = this.txtHoTenKH.Text;
            hs.DiaChi = this.txtDiaChi.Text;
            hs.DanhBo = this.textBoxX2DB.Text;
            hs.NgayDongTien = this.dateNgayDongTien.Value;
            hs.SoBienLai = this.txtSoHoaDon.Text;
            hs.GhiChu = this.txtGHiChu.Text;
            hs.CreateDate = DateTime.Now;
            hs.CreateBy = DAL.C_USERS._userName;
            DAL.C_KHDonBamChi.InsertDonHK(hs);

            dataGridView1.DataSource = DAL.C_KHDonBamChi.getListbyDot(this.txtSoBangKe.Text);
            pLoad();
        }

        private void txtSoBangKe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dataGridView1.DataSource = DAL.C_KHDonBamChi.getListbyDot(this.txtSoBangKe.Text);
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void btin_Click(object sender, EventArgs e)
        {

            ReportDocument rp = new rptBamChiKhoaGoc();
            rp.SetDataSource(DAL.C_KHDonBamChi.getListbyDot(this.txtSoBangKe.Text));
            reportView inp = new reportView(rp);
            inp.ShowDialog();
        }

        private void btLamLai_Click(object sender, EventArgs e)
        {
            this.txtSoBangKe.Text = DAL.Idetity.IdentityDutChi();
            pLoad();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DAL.LinQConnection.ExecuteCommand("DELETE FROM KH_HOSOBAMCHIGOC WHERE ID='" + dataGridView1.CurrentRow.Cells["ID"].Value + "'");
            dataGridView1.DataSource = DAL.C_KHDonBamChi.getListbyDot(this.txtSoBangKe.Text);
            pLoad();
        }

        private void textBoxX2DB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DataTable table = C_DuLieuKhachHang.getDanhBo(this.textBoxX2DB.Text.Replace("-",""));
                if (table.Rows.Count <= 0)
                {
                    MessageBox.Show(this, "Không Tìm Thấy Hồ Sơ Hoàn Tất Thiết Kế !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.txtHoTenKH.Text = table.Rows[0][0].ToString();
                    this.txtDiaChi.Text = table.Rows[0][1].ToString();
                   
                }
            }
        }
    }
}