using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using TanHoaWater.Database;
using log4net;

namespace TanHoaWater.View.Users.TinhDuToan
{
    public partial class frm_ChonLaiDG : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_ChonLaiDG).Name);
        public frm_ChonLaiDG()
        {
            InitializeComponent();
            cbMaVatTu.DataSource = DAL.C_DanhMucVatTu.getListDanhMucVatCobobox();
            this.cbMaVatTu.DisplayMember = "TENVT";
            this.cbMaVatTu.ValueMember = "MAHIEU";
        }
        private void GridDonGiaVT_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            GridDonGiaVT.Rows[GridDonGiaVT.CurrentRow.Index].Cells[5].Value = Utilities.DateToString.NgayVN(DateTime.Now);
            GridDonGiaVT.Rows[GridDonGiaVT.CurrentRow.Index].Cells[0].Value = GridDonGiaVT.CurrentRow.Index + 1;
            GridDonGiaVT.Rows[GridDonGiaVT.CurrentRow.Index].Cells[1].Value = mahieuvt;

        }
        private void btCapNhatDGVT_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < GridDonGiaVT.Rows.Count - 1; i++)
                {
                    int stt = int.Parse(GridDonGiaVT.Rows[i].Cells[0].Value + "");
                    string mahieudg = GridDonGiaVT.Rows[i].Cells[1].Value + "";
                    string check = GridDonGiaVT.Rows[i].Cells[6].Value + "";
                    DONGIAVATTU dgvt = DAL.C_DonGiaVatTu.finbyDonGiaVT(stt, mahieudg);
                    if (dgvt != null)
                    {
                        dgvt.CHON = bool.Parse(check);
                        double vt = double.Parse(GridDonGiaVT.Rows[i].Cells["dg_vatlieu"].Value + "");
                        dgvt.DGVATLIEU = vt;
                        double nc = double.Parse(GridDonGiaVT.Rows[i].Cells["dg_nhanCong"].Value + "");
                        dgvt.DGNHANCONG = nc;
                        double xm = double.Parse(GridDonGiaVT.Rows[i].Cells["dgXiMang"].Value + "");
                        dgvt.MODIFYBY = DAL.C_USERS._userName;
                        dgvt.MODIFYDATE = DateTime.Now.Date;
                        DAL.C_DonGiaVatTu.UpdateDGVT(dgvt);
                    }
                    else
                    {
                        dgvt = new DONGIAVATTU();
                        dgvt.STT = stt;
                        dgvt.MAHIEUDG = mahieudg;
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
                        DAL.C_DonGiaVatTu.InsertDGVT(dgvt);
                    }
                }
                MessageBox.Show(this, "Cập Nhật Đơn Giá Vật Tư Thành Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                log.Error("Loi Khi Cap Nhat Don Gia Vat Tu " + ex.Message);
                MessageBox.Show(this, "Cập Nhật Đơn Giá Vật Tư Thất Bại.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        string mahieuvt = "";
        private void cbMaVatTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
               // MessageBox.Show(this, );
               

            }
        }
        public string catchuoi(string line)
        {
            string[] words = Regex.Split(line, "______");
            return words[1];
        }
        private void cbMaVatTu_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                 mahieuvt=this.cbMaVatTu.SelectedValue+"";
                this.GridDonGiaVT.DataSource = DAL.C_DonGiaVatTu.GetDonGiaVTbyMaHieu(this.cbMaVatTu.SelectedValue+"");
                Utilities.DataGridV.formatRows(GridDonGiaVT);
                try
                {
                    this.txtTenVT.Text = catchuoi(this.cbMaVatTu.Text);
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}
