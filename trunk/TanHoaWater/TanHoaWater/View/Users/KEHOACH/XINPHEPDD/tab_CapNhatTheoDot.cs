using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.Report;
using TanHoaWater.View.Users.KEHOACH.XINPHEPDD.BC;

namespace TanHoaWater.View.Users.KEHOACH.XINPHEPDD
{
    public partial class tab_CapNhatTheoDot : UserControl
    {
        DateTime _ngaylap = DateTime.Now.Date;
        public tab_CapNhatTheoDot(string madot,DateTime ngaylap)
        {
            InitializeComponent();
            this.cbMaDot.DataSource = DAL.C_KH_XinPhepDD.ListAllXinPhepDD();
            this.cbMaDot.ValueMember = "MADOT";
            this.cbMaDot.DisplayMember = "MADOT";
            cbMaDot.Text = madot;
            loadDataGrid(madot);
            _ngaylap = ngaylap;
        }

        private void checkLayBangGia_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLayBangGia.Checked)
            {
                this.GridViewPhuiDao.Visible = true;
            }
            else {
                this.GridViewPhuiDao.Visible = false;
            }
        }

        private void txtMaSHS_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            if (e.KeyChar == 13) {
                DataTable table =DAL.C_KH_XinPhepDD.findByHSHT(this.txtMaSHS.Text);
                if (table.Rows.Count <= 0)
                {
                    MessageBox.Show(this, "Không Tìm Thấy Hồ Sơ Hoàn Tất Thiết Kế !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtMaSHS.Text = "";
                    this.txtHoTen.Text = "";
                    this.txtGhiChu.Text = "";
                    this.txtDiaChi.Text = "";
                    this.txtMaSHS.Focus();
                }
                else {
                    string _shs = table.Rows[0][0].ToString();
                    if (DAL.C_KH_XinPhepDD.getListBCPhuiDao(_shs).Count <= 0)
                    {

                        DAL.C_KH_XinPhepDD.getPhuiDao(_shs);
                        DAL.C_KH_XinPhepDD.TinhPhuiDao(_shs);
                        GridViewPhuiDao.DataSource = DAL.C_KH_XinPhepDD.getListBCPhuiDao(_shs);
                    }
                    else {
                        GridViewPhuiDao.DataSource = DAL.C_KH_XinPhepDD.getListBCPhuiDao(_shs);
                    }
                    this.txtHoTen.Text = table.Rows[0][1].ToString();
                    this.txtDiaChi.Text = table.Rows[0][2].ToString();
                    this.txtGhiChu.Text = table.Rows[0][0].ToString();
                    this.txtGhiChu.Focus();
              }
            }
        }

        public void loadDataGrid(string sodot) {
            DataTable table = DAL.C_KH_HoSoKhachHang.getListHSbyDot(sodot);
            this.gridXiPhepDD.DataSource = table;
            this.lbTongHoSo.Text = "Tổng Số Hồ Sơ XPĐĐ: " + table.Rows.Count + " hồ sơ.";
        }
        public void add() {
            if ("".Equals(this.cbMaDot.Text))
            {
                MessageBox.Show(this, "Chọn Mã Đợt Xin Phép Đào Đường ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbMaDot.Select();
            }
            else if ("".Equals(this.txtMaSHS.Text))
            {
                MessageBox.Show(this, "Nhập Số Số Hồ Sơ ! ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtMaSHS.Focus();
            }
            else if (DAL.C_KH_HoSoKhachHang.findBySHS(this.txtMaSHS.Text) != null)
            {
                MessageBox.Show(this, "Số Hồ Sơ Đã Xin Phép Đào Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtMaSHS.Focus();
            }
            else
            {
                
                KH_HOSOKHACHHANG kh_sh = DAL.C_KH_HoSoKhachHang.findBySHS(this.txtMaSHS.Text);
                if (kh_sh == null)
                {
                    kh_sh = new KH_HOSOKHACHHANG();
                    kh_sh.SHS = this.txtMaSHS.Text;
                    kh_sh.MADOTDD = this.cbMaDot.Text;
                    kh_sh.NGAYNHAN = _ngaylap;
                    kh_sh.GHICHU = this.txtGhiChu.Text;
                    kh_sh.CREATEBY = DAL.C_USERS._userName;
                    kh_sh.CREATEDATE = DateTime.Now.Date;
                    if (DAL.C_KH_HoSoKhachHang.Insert(kh_sh) == false)
                    {// co roi do len dot thi cong truoc
                        MessageBox.Show(this, "Thêm Hồ Sơ Xin Phép Bị lỗi, Hoặc Đã Xin Phép Rồi !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtMaSHS.Focus();
                    }
                }
                else
                {
                    kh_sh.MADOTDD = this.cbMaDot.Text;
                    kh_sh.NGAYNHAN = _ngaylap;
                    DAL.C_KH_HoSoKhachHang.Update();
                }
                loadDataGrid(this.cbMaDot.Text);
            }
        }

        private void txtGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                add();
                this.txtMaSHS.Focus();
                this.txtMaSHS.Select();
            }
        }

        private void cbMaDot_SelectedValueChanged(object sender, EventArgs e)
        {
            loadDataGrid(this.cbMaDot.Text);
        }

        private void gridXiPhepDD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridXiPhepDD.CurrentCell.OwningColumn.Name == "thaotac")
                {
                    string _shs = gridXiPhepDD.Rows[gridXiPhepDD.CurrentRow.Index].Cells["gridMaHS"].Value + "";
                    if (MessageBox.Show(this, "Có Muốn Hủy Hồ Sơ " + _shs + " Không ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DAL.C_KH_HoSoKhachHang.Delete(_shs);
                        loadDataGrid(this.cbMaDot.Text);
                    }
                }
            }
            catch (Exception)
            {
                 
            }
            
        }


        private void inDanhSachCoPhep_Click(object sender, EventArgs e)
        {
            string madot = this.cbMaDot.Text;
            ReportDocument rp = new rpt_XinPhep();
            rp.SetDataSource(DAL.C_KH_XinPhepDD.ReportxinPhepDD(madot, "", "", "", ""));

            rpt_Main mainreport = new rpt_Main(rp);
            mainreport.ShowDialog();
        }

        private void btInDanhSachMienPhep_Click(object sender, EventArgs e)
        {
            string madot = this.cbMaDot.Text;
            frmDialogPrintting frm = new frmDialogPrintting(madot);
            frm.ShowDialog();
        }
    }
}
