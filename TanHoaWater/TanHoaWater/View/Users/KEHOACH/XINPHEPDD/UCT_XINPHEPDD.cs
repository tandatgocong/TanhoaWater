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
        int flag_ = 0;
        public UCT_XINPHEPDD(int flag)
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

            if (flag == 0)
            {
                tabItem2.Visible = true;
                btCapNhatCoPhep.Visible = true;
                capnhatDSChoDot.Visible = true;
                btExport.Visible = true;
               // txtSoDot.ReadOnly = false;
                btInDanhSachMienPhep.Visible = true;
                inDanhSachCoPhep.Visible = true;
            }
            else
            {
                tabItem2.Visible = false;
                btCapNhatCoPhep.Visible = false;
                capnhatDSChoDot.Visible = false;
                btExport.Visible = false;
                btInDanhSachMienPhep.Visible = false;
                inDanhSachCoPhep.Visible = false;
                //txtSoDot.ReadOnly = true;
                txtSoDot.Text = DAL.Idetity.IdentityDUAN("");
                flag_ = 1;

            }
                
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
              
                if ("".Equals(this.txtSoDot.Text))
                {
                    MessageBox.Show(this, "Số Đợt Xin Phép Đào Đường Không Được Trống !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtSoDot.Focus();
                }
                else if ("".Equals(this.cbNoiCap.Text))
                {
                    MessageBox.Show(this, "Nơi Phép Đào Đường Không Được Trống !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.cbNoiCap.Select();
                }
                else if ("1/1/0001".Equals(dateNgayLap.Value.ToShortDateString()))
                {
                    MessageBox.Show(this, "Chọn Ngày Lập Đợt Xin Phép Đào Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dateNgayLap.Select();
                }
                else if ("".Equals(this.txtMaQuanLy.Text))
                {
                    MessageBox.Show(this, "Mã Quản lý Đợt Không Được Trống !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtMaQuanLy.Focus();
                }
                else if (DAL.C_KH_XinPhepDD.finbyMaDot((this.txtSoDot.Text.ToUpper() + "-" + this.cbNoiCap.Text)) != null)
                {;
                    MessageBox.Show(this, "Số Đợt Xin Phép Đào Đường Đã Có !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtSoDot.Focus();
                }
                else
                {
                    Database.KH_XINPHEPDAODUONG xinphep = new Database.KH_XINPHEPDAODUONG();
                    xinphep.MADOT = (this.txtSoDot.Text.ToUpper() + "-" + this.cbNoiCap.Text);
                    xinphep.NOICAPPHEP = this.cbNoiCap.Text;
                    xinphep.NGAYLAP = this.dateNgayLap.Value;
                    xinphep.MAQUANLY = this.txtMaQuanLy.Text.ToUpper();
                    xinphep.MADOTXP = this.txtSoDot.Text.ToUpper();
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
                madot = dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["MADOTXP"].Value + "";
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

        private void capnhatDSChoDot_Click_1(object sender, EventArgs e)
        {
            string madot = "";
            DateTime ngaylap = DateTime.Now.Date;
            try
            {
                madot = dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["MADOTXP"].Value + "";
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
                madot = dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["MADOTXP"].Value + "";

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
                madot = dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["MADOTXP"].Value + "";

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
                madot = dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["MADOTXP"].Value + "";

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

        private void btCapNhatCoPhep_Click(object sender, EventArgs e)
        {
            string madot = "";
            try
            {
                madot = dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["gridSoDot"].Value + "";

            }
            catch (Exception)
            {
            }
            if (!"".Equals(madot))
            {
                if ("1/1/0001".Equals(dateNgayCoPhep.Value.ToShortDateString()))
                {
                    MessageBox.Show(this, "Chọn Ngày Có Phép Đào Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dateNgayCoPhep.Select();
                }
                else {
                  
                    if (DAL.C_KH_XinPhepDD.UpdateCoPhep(madot, this.dateNgayCoPhep.Value.Date) == false) {
                        MessageBox.Show(this, "Cập Nhật Ngày Có Phép Đào Đường Lỗi !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else {
                        search();
                    }                   
                }
            }
            else
            {
                MessageBox.Show(this, "Cần Chọn Mã Đợt Để Xin Phép Đào Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tabItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void cbNoiCap_Leave(object sender, EventArgs e)
        {
            this.txtSoDot.Text = this.txtSoDot.Text.ToUpper();
            this.txtMaQuanLy.Text = this.txtSoDot.Text + "-" + this.cbNoiCap.Text;
            this.txtMaQuanLy.Text = this.txtMaQuanLy.Text.ToUpper();
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            string madot = "";
            try
            {
                madot = dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["gridSoDot"].Value + "";
                //if ((dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["gridMaQuanLy"].Value + "").Contains("QTP"))
                //{
                    frm_Export frm = new frm_Export(madot);
                    frm.ShowDialog();
                //}
                //else {

                //    MessageBox.Show(this, "Chỉ lấy bảng vẽ của Q. Tân Phú.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

            }
            catch (Exception ex)
            {
                log.Error("Export Loi " + ex.Message);
            }
        }

        private void txtSearchSoDot_TextChanged(object sender, EventArgs e)
        {
            dataDanhSachDaoDuong.ClearSelection();
            foreach (DataGridViewRow currentRow in dataDanhSachDaoDuong.Rows)
            {
                if (currentRow.Cells["gridSoDot"].Value.ToString().Contains(txtSearchSoDot.Text))
                {
                    currentRow.Selected = true;
                    break;
                }
            }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {

        }

        private void tabItem3_Click(object sender, EventArgs e)
        {
            string madot = "";
            DateTime ngaylap = DateTime.Now.Date;
            try
            {
                madot = dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["MADOTXP"].Value + "";
                ngaylap = DateTime.Parse(dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["gridNgayLap"].Value + "");

            }
            catch (Exception)
            {
            }
            if (!"".Equals(madot))
            {
                tabCapNhatDS.Controls.Clear();
                tabHoSoDuAn.Controls.Clear();
                tabHoSoDuAn.Controls.Add(new tab_XinPhepDuAn(madot, ngaylap));
                this.tabControl1.SelectedTabIndex = 2;
            }
            else
            {
                MessageBox.Show(this, "Cần Chọn Mã Đợt Để Xin Phép Đào Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btHoSoDuAn_Click(object sender, EventArgs e)
        {
            string madot = "";
            DateTime ngaylap = DateTime.Now.Date;
            try
            {
                madot = dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["MADOTXP"].Value + "";
                ngaylap = DateTime.Parse(dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["gridNgayLap"].Value + "");

            }
            catch (Exception)
            {
            }
            if (!"".Equals(madot))
            {
                tabCapNhatDS.Controls.Clear();
                tabHoSoDuAn.Controls.Clear();
                tabHoSoDuAn.Controls.Add(new tab_XinPhepDuAn(madot, ngaylap));
                this.tabControl1.SelectedTabIndex = 2;
            }
            else
            {
                MessageBox.Show(this, "Cần Chọn Mã Đợt Để Xin Phép Đào Đường !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }

        private void btDonCapPhep_Click(object sender, EventArgs e)
        {
            string madot = "";
            try
            {
                madot = dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["MADOTXP"].Value + "";

            }
            catch (Exception)
            {
            }
            if (flag_ == 1)
            {
                frmDialogDonXP_DA frm = new frmDialogDonXP_DA(madot);
                frm.ShowDialog();
            }
            else
            {
                frmDialogDonXP frm = new frmDialogDonXP(madot);
                frm.ShowDialog();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string madot = "";
            try
            {
                madot = dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["MADOTXP"].Value + "";

            }
            catch (Exception)
            {
            }

            ReportDocument rp = new rptBienPhapThiCong();
            rp.SetDataSource(DAL.C_KH_XinPhepDD.ReportxinPhepDD(madot));
            rpt_Main mainreport = new rpt_Main(rp);
            mainreport.ShowDialog();
        }
    }
}
