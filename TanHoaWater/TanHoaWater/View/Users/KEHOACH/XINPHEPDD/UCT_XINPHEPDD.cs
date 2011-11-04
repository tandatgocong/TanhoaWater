using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using TanHoaWater.View.Users.Report;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.KEHOACH.XINPHEPDD.BC;

namespace TanHoaWater.View.Users.KEHOACH.XINPHEPDD
{
    public partial class UCT_XINPHEPDD : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UCT_XINPHEPDD).Name);
        int currentPageIndex = 1;
        int pageSize = 19;
        int pageNumber = 0;
        int FirstRow, LastRow;
        int rows;
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
        public UCT_XINPHEPDD()
        {
            InitializeComponent();
            this.tabControl1.SelectedTabIndex = 0;
            //this.tabDanhSachDot.Controls.Clear();
            //this.tabDanhSachDot.Controls.Add(new tab_DanhSach());
            search();
            #region Load Noi Cap Phep
            this.cbNoiCap.DataSource = DAL.C_KH_XinPhepDD.getNoiXiPhep();
            this.cbNoiCap.DisplayMember = "MACAPPHEP";
            this.cbNoiCap.ValueMember = "MACAPPHEP";
            #endregion
                
        }
        public void loadData()
        {
            //string _madot = this.cbDotNhanDon.SelectedValue.ToString();
            try
            {
                rows = DAL.C_KH_XinPhepDD.TotalList("", "", "");
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            PageTotal();

            this.dataDanhSachDaoDuong.DataSource = DAL.C_KH_XinPhepDD.getList("", "", "", FirstRow, pageSize);
            //this.totalRecord.Text = "Tống công có " + sokh + " khách hàng đợt nhận đơn " + _madot;

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
        public void refesh()
        {
            this.radioNgayLap.Checked = false;
            this.radioSoDot.Checked = false;
            this.txtSearchSoDot.Text = "";


        }
        public void add() {
            refesh();
            try
            {
                this.errorProvider1.Clear();

                if ("".Equals(this.txtSoDot.Text))
                {
                    this.errorProvider1.SetError(txtSoDot, "Số Đợt Xin Phép Đào Đường Không Được Trống !");
                    this.txtSoDot.Focus();
                }
                else if ("".Equals(this.cbNoiCap.Text))
                {
                    this.errorProvider1.SetError(cbNoiCap, "Nơi Phép Đào Đường Không Được Trống !");
                    this.cbNoiCap.Select();
                }
                else if ("1/1/0001".Equals(dateNgayLap.Value.ToShortDateString()))
                {
                    this.errorProvider1.SetError(dateNgayLap, "Chọn Ngày Lập Đợt Xin Phép Đào Đường !");
                    this.dateNgayLap.Select();
                }
                else if ("".Equals(this.txtMaQuanLy.Text))
                {
                    this.errorProvider1.SetError(txtMaQuanLy, "Mã Quản lý Đợt Không Được Trống !");
                    this.txtMaQuanLy.Focus();
                }
                else if (DAL.C_KH_XinPhepDD.finbyMaDot(this.txtSoDot.Text) != null)
                {
                    this.errorProvider1.SetError(txtSoDot, "Số Đợt Xin Phép Đào Đường Đã Có !");
                    this.txtSoDot.Focus();
                }
                else
                {
                    this.errorProvider1.Clear();
                    Database.KH_XINPHEPDAODUONG xinphep = new Database.KH_XINPHEPDAODUONG();
                    xinphep.MADOT = this.txtSoDot.Text.ToUpper();
                    xinphep.NOICAPPHEP = this.cbNoiCap.Text;
                    xinphep.NGAYLAP = this.dateNgayLap.Value;
                    xinphep.MAQUANLY = this.txtMaQuanLy.Text.ToUpper();
                    xinphep.CREATEBY = DAL.C_USERS._userName;
                    xinphep.CREATEDATE = DateTime.Now;
                    if (DAL.C_KH_XinPhepDD.Insert(xinphep) == false)
                    {
                        MessageBox.Show(this, "Lỗi Thêm Xin Phép Đào Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        search();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Them Xin Phep Dao Duong Loi. " + ex.Message);
            }
        }
        private void btThemMoi_Click(object sender, EventArgs e)
        {
            add();

        }

        public void search()
        {
            string date = "";
            string madotsearch = "";
            if (radioSoDot.Checked)
            {
                madotsearch = txtSearchSoDot.Text;
            }
            if (radioNgayLap.Checked)
            {
                if (!"1/1/0001".Equals(dateTimeSearch.Value.ToShortDateString()))
                {
                    date = Utilities.DateToString.NgayVN(dateTimeSearch.Value);
                }
            }

            try
            {
                rows = DAL.C_KH_XinPhepDD.TotalList(madotsearch, "", date);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            PageTotal();

            this.dataDanhSachDaoDuong.DataSource = DAL.C_KH_XinPhepDD.getList(madotsearch, "", date, FirstRow, pageSize);
        }

        private void radioNgayLap_CheckedChanged(object sender, EventArgs e)
        {

            this.txtSearchSoDot.Visible = false;
            this.dateTimeSearch.Visible = true;
            txtSearchSoDot.Text = "";
            timkiem();
        }

        public void timkiem()
        {
            FirstRow = 0;
            currentPageIndex = 1;
            search();
        }
        private void radioSoDot_CheckedChanged(object sender, EventArgs e)
        {
            this.txtSearchSoDot.Visible = true;
            this.dateTimeSearch.Visible = false;

            timkiem();
        }

        private void txtSearchSoDot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                timkiem();
            }
        }

        private void dateTimeSearch_ValueChanged(object sender, EventArgs e)
        {
            timkiem();
        }

        private void txtSoDot_Leave(object sender, EventArgs e)
        {
            this.txtSoDot.Text = this.txtSoDot.Text.ToUpper();
            this.txtMaQuanLy.Text = this.txtSoDot.Text + "-" + this.cbNoiCap.Text;
            this.txtMaQuanLy.Text = this.txtMaQuanLy.Text.ToUpper();
        }

        

        private void tabItem2_Click(object sender, EventArgs e)
        {
             string madot = "";
             DateTime ngaylap = DateTime.Now.Date;
            try
            {
                madot = dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["gridSoDot"].Value + "";
                ngaylap = DateTime.Parse(dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["gridNgayLap"].Value + "");
                
            }
            catch (Exception)
            {
            }
           tabCapNhatDS.Controls.Clear();
           tabCapNhatDS.Controls.Add(new tab_CapNhatTheoDot(madot, ngaylap));
           this.tabControl1.SelectedTabIndex = 1;
          
        }

        private void capnhatDSChoDot_Click_1(object sender, EventArgs e)
        {
            string madot = "";
            DateTime ngaylap = DateTime.Now.Date;
            try
            {
                madot = dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["gridSoDot"].Value + "";
                ngaylap = DateTime.Parse(dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["gridNgayLap"].Value + "");

            }
            catch (Exception)
            {
            }
            if (!"".Equals(madot))
            {
                tabCapNhatDS.Controls.Clear();
                tabCapNhatDS.Controls.Add(new tab_CapNhatTheoDot(madot, ngaylap));
                this.tabControl1.SelectedTabIndex = 1;
            }
            else
            {
                MessageBox.Show(this, "Cần Chọn Mã Đợt Để Xin Phép Đào Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtMaQuanLy_Leave(object sender, EventArgs e)
        {
            add();
        }

        private void inDanhSachCoPhep_Click(object sender, EventArgs e)
        {
            string madot = "";
            try
            {
                madot = dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["gridSoDot"].Value + "";

            }
            catch (Exception)
            {
            }
            ReportDocument rp = new rpt_XinPhep();
            rp.SetDataSource(DAL.C_KH_XinPhepDD.ReportxinPhepDD(madot,"","","",""));

            rpt_Main mainreport = new rpt_Main(rp);
            mainreport.ShowDialog();
        }

        private void btInDanhSachMienPhep_Click(object sender, EventArgs e)
        {
            string madot = "";
            try
            {
                madot = dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["gridSoDot"].Value + "";

            }
            catch (Exception)
            {
            }
            frmDialogPrintting frm = new frmDialogPrintting(madot);
            frm.ShowDialog();
        }

        private void huyDotXP_Click(object sender, EventArgs e)
        {
            string madot = "";
            try
            {
                madot = dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["gridSoDot"].Value + "";

            }
            catch (Exception)
            {
            }
            if (DAL.C_KH_HoSoKhachHang.getListHSbyDot(madot).Rows.Count > 0)
            {
                MessageBox.Show(this, "Đợt Xin Phép Đợt " + madot + " Đã Có Hồ Sơ, Không Thể Hủy Đợt  " + madot + " !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                if (MessageBox.Show(this, "Có Muốn Hủy Đợt Xin Phép " + madot + " Không ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (DAL.C_KH_XinPhepDD.Delete(madot) == true)
                    {
                        search();
                    }
                    else
                    {
                        MessageBox.Show(this, "Lỗi Hủy Đợt Xin Phép " + madot + " lỗi. ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            
            }
           
        }
    }
}
