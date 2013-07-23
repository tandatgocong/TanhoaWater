using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using TanHoaWater.View.Users.To_ThietKe.Report;
using TanHoaWater.View.Users.To_ThietKe.Report.KSTK;

namespace TanHoaWater.View.Users.To_ThietKe
{
    public partial class uct_GiaoHS : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(uct_GiaoHS).Name);
        public uct_GiaoHS(int tab)
        {
            InitializeComponent();
             if (tab == 2) {
                 this.panelGhepHs.Controls.Clear();
                 this.panelGhepHs.Controls.Add(new tab_GhepHoSo());
                 this.tabControl1.SelectedTabIndex = 1;
            } else if (tab == 3) {
                this.tabControl1.SelectedTabIndex = 2;
            } else if (tab == 4) {
                this.tabControl1.SelectedTabIndex = 3;
                #region Load SDV
                this.theodoi_SDV.DataSource = DAL.C_USERS.getUserByMaPhongAndLevel("TTK", 2);
                this.theodoi_SDV.DisplayMember = "FULLNAME";
                this.theodoi_SDV.ValueMember = "USERNAME";
                #endregion
                #region Loai Dot Khach Hang
                this.cb_TheoDot.DataSource = DAL.C_DotNhanDon.getListtMa_Dot_DaChuyen();
                this.cb_TheoDot.DisplayMember = "TEND";
                this.cb_TheoDot.ValueMember = "MADOT";
                #endregion
                theodoi();
            }
            else if (tab == 5) {
                this.tabControl1.SelectedTabIndex = 4;
            }           
            else {
                this.dateNhanDon.Value = DateTime.Now;
                formLoad();
                this.tabControl1.SelectedTabIndex = 0;
            }
           
            


        }

        private void theongay_CheckedChanged(object sender, EventArgs e)
        {
            this.dateNhanDon.Enabled = true;
            this.DotNhanDon.Enabled = false;
            giaoviec();
        }

        private void theodot_CheckedChanged(object sender, EventArgs e)
        {
            this.dateNhanDon.Enabled = false;
            this.DotNhanDon.Enabled = true;
            giaoviec();
        }
        int flag = 0;
        CheckBox checkboxHeader1 = new CheckBox();
        CheckBox checkboxHeader = new CheckBox();
        public void formLoad()
        {

            #region Load SDV
            this.sodovien.DataSource = DAL.C_USERS.getUserByMaPhongAndLevel("TTK", 2);
            this.sodovien.DisplayMember = "FULLNAME";
            this.sodovien.ValueMember = "USERNAME";
            #endregion
            #region Loai Dot Khach Hang
            this.DotNhanDon.DataSource = DAL.C_DotNhanDon.getListtMa_Dot_DaChuyen();
            this.DotNhanDon.DisplayMember = "TEND";
            this.DotNhanDon.ValueMember = "MADOT";
            #endregion
            //#region DS Chua Giao Theo Ngay
            //this.DG_ChuaGiao.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, Utilities.DateToString.NgayVN(this.dateNhanDon), null);
            //#endregion
            //#region DS Da Giao Theo Ngay
            //this.DG_ChuaGiao.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, Utilities.DateToString.NgayVN(this.dateNhanDon), this.sodovien.SelectedValue.ToString());
            //#endregion

            //customize dataviewgrid, add checkbox column
            if (flag == 0)
            {
                //DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
                //checkboxColumn.Width = 30;
                //checkboxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //DG_ChuaGiao.Columns.Insert(0, checkboxColumn);

                // add checkbox header
                Rectangle rect = DG_ChuaGiao.GetCellDisplayRectangle(0, -1, true);
                // set checkbox header to center of header cell. +1 pixel to position correctly.
                rect.X = rect.Location.X + (rect.Width / 4);

                CheckBox checkboxHeader = new CheckBox();
                checkboxHeader.Name = "checkboxHeader";
                checkboxHeader.Size = new Size(17, 17);
                checkboxHeader.Location = rect.Location;
                checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);
                DG_ChuaGiao.Controls.Add(checkboxHeader);

                Rectangle rect1 = DG_ChuaGiao.GetCellDisplayRectangle(0, -1, true);
                // set checkbox header to center of header cell. +1 pixel to position correctly.
                rect1.X = rect.Location.X + (rect.Width / 4);

                CheckBox checkboxHeader1 = new CheckBox();
                checkboxHeader1.Name = "checkboxHeader";
                checkboxHeader1.Size = new Size(17, 17);
                checkboxHeader1.Location = rect.Location;
                checkboxHeader1.ForeColor = Color.Transparent;
                checkboxHeader1.CheckedChanged += new EventHandler(checkboxHeader1_CheckedChanged);
                DG_SDV.Controls.Add(checkboxHeader1);

                flag = 1;
            }
        }
        public void dagiaoviec()
        {
            int count = 0;
            try
            {
                if (btAll.Checked == true)
                {
                    //#region DS Chua Giao Theo Ngay
                    //this.DG_ChuaGiao.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, null, null);
                    //labelDSChuaGiao.Text = "Tổng Số " + DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, null, null).Rows.Count + " Hồ Sơ Chưa Giao Sơ Đồ Viên. ";
                    //#endregion
                    count = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, null, this.sodovien.SelectedValue.ToString()).Rows.Count;
                    #region DS Da Giao Theo Ngay
                    this.DG_SDV.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, null, this.sodovien.SelectedValue.ToString());
                    lableGIAO_SDV.Text = this.sodovien.Text + " Có " + count + " Hồ Sơ Được Giao";
                    #endregion
                }
                else if (theodot.Checked == true)
                {
                    //#region DS Chua Giao Theo Ngay
                    //this.DG_ChuaGiao.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(this.DotNhanDon.SelectedValue.ToString(), null, null);
                    //labelDSChuaGiao.Text = "Tổng Số " + DAL.C_ToThietKe.DachSachHoSoGiaoViec(this.DotNhanDon.SelectedValue.ToString(), null, null).Rows.Count + " Hồ Sơ Chưa Giao Sơ Đồ Viên. ";
                    //#endregion
                    count = DAL.C_ToThietKe.DachSachHoSoGiaoViec(this.DotNhanDon.SelectedValue.ToString(), null, this.sodovien.SelectedValue.ToString()).Rows.Count;
                    #region DS Da Giao Theo Ngay
                    this.DG_SDV.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(this.DotNhanDon.SelectedValue.ToString(), null, this.sodovien.SelectedValue.ToString());
                    lableGIAO_SDV.Text = this.sodovien.Text + " Có " + count + " Hồ Sơ Được Giao";
                    #endregion

                }
                else
                {
                    //#region DS Chua Giao Theo Ngay
                    //this.DG_ChuaGiao.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, Utilities.DateToString.NgayVN(this.dateNhanDon), null);
                    //labelDSChuaGiao.Text = "Tổng Số " + DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, Utilities.DateToString.NgayVN(this.dateNhanDon), null).Rows.Count + " Hồ Sơ Chưa Giao Sơ Đồ Viên. ";
                    //#endregion
                    #region DS Da Giao Theo Ngay
                    this.DG_SDV.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, Utilities.DateToString.NgayVN(this.dateNhanDon), this.sodovien.SelectedValue.ToString());
                    count = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, Utilities.DateToString.NgayVN(this.dateNhanDon), this.sodovien.SelectedValue.ToString()).Rows.Count;
                    lableGIAO_SDV.Text = this.sodovien.Text + " Có " + count + " Hồ Sơ Được Giao";
                    #endregion
                }
            }
            catch (Exception)
            { }
            if (count > 0)
            {
                resultPrint.Visible = true;
            }
            else
            {
                resultPrint.Visible = false;
            }
            Utilities.DataGridV.formatRows(DG_SDV);
        }
        public void giaoviec()
        {
            int count = 0;
            try
            {
                if (btAll.Checked == true)
                {
                    #region DS Chua Giao Theo Ngay
                    this.DG_ChuaGiao.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, null, null);
                    labelDSChuaGiao.Text = "Tổng Số " + DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, null, null).Rows.Count + " Hồ Sơ Chưa Giao Sơ Đồ Viên. ";
                    #endregion
                    count = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, null, this.sodovien.SelectedValue.ToString()).Rows.Count;
                    #region DS Da Giao Theo Ngay
                    this.DG_SDV.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, null, this.sodovien.SelectedValue.ToString());
                    lableGIAO_SDV.Text = this.sodovien.Text + " Có " + count + " Hồ Sơ Được Giao";
                    #endregion
                }
                else if (theodot.Checked == true)
                {
                    #region DS Chua Giao Theo Ngay
                    this.DG_ChuaGiao.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(this.DotNhanDon.SelectedValue.ToString(), null, null);
                    labelDSChuaGiao.Text = "Tổng Số " + DAL.C_ToThietKe.DachSachHoSoGiaoViec(this.DotNhanDon.SelectedValue.ToString(), null, null).Rows.Count + " Hồ Sơ Chưa Giao Sơ Đồ Viên. ";
                    #endregion
                    count = DAL.C_ToThietKe.DachSachHoSoGiaoViec(this.DotNhanDon.SelectedValue.ToString(), null, this.sodovien.SelectedValue.ToString()).Rows.Count;
                    #region DS Da Giao Theo Ngay
                    this.DG_SDV.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(this.DotNhanDon.SelectedValue.ToString(), null, this.sodovien.SelectedValue.ToString());
                    lableGIAO_SDV.Text = this.sodovien.Text + " Có " + count + " Hồ Sơ Được Giao";
                    #endregion

                }
                else
                {
                    #region DS Chua Giao Theo Ngay
                    this.DG_ChuaGiao.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, Utilities.DateToString.NgayVN(this.dateNhanDon), null);
                    labelDSChuaGiao.Text = "Tổng Số " + DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, Utilities.DateToString.NgayVN(this.dateNhanDon), null).Rows.Count + " Hồ Sơ Chưa Giao Sơ Đồ Viên. ";
                    #endregion
                    #region DS Da Giao Theo Ngay
                    this.DG_SDV.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, Utilities.DateToString.NgayVN(this.dateNhanDon), this.sodovien.SelectedValue.ToString());
                    count = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, Utilities.DateToString.NgayVN(this.dateNhanDon), this.sodovien.SelectedValue.ToString()).Rows.Count;
                    lableGIAO_SDV.Text = this.sodovien.Text + " Có " + count + " Hồ Sơ Được Giao";
                    #endregion
                }
            }
            catch (Exception)
            { }
            if (count > 0)
            {
                resultPrint.Visible = true;
            }
            else
            {
                resultPrint.Visible = false;
            }
            Utilities.DataGridV.formatRows(DG_ChuaGiao);
            Utilities.DataGridV.formatRows(DG_SDV);
        }
        private void btView_Click(object sender, EventArgs e)
        {
            giaoviec();
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < DG_ChuaGiao.RowCount; i++)
            {
                DG_ChuaGiao[0, i].Value = ((CheckBox)DG_ChuaGiao.Controls.Find("checkboxHeader", true)[0]).Checked;
            }
        }
        private void checkboxHeader1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < DG_SDV.RowCount; i++)
            {
                DG_SDV[0, i].Value = ((CheckBox)DG_SDV.Controls.Find("checkboxHeader", true)[0]).Checked;
            }
        }
        private void sodovien_SelectedValueChanged(object sender, EventArgs e)
        {
            dagiaoviec();
        }

        private void btGiaoViec_Click(object sender, EventArgs e)
        {
            try
            {
                bool chek = false;
                for (int i = 0; i < DG_ChuaGiao.RowCount; i++)
                {
                    if (DG_ChuaGiao[0, i].Value != null && "True".Equals(DG_ChuaGiao[0, i].Value.ToString()))
                    {
                        chek = true;
                        string shs = DG_ChuaGiao.Rows[i].Cells[2].Value.ToString();
                        DAL.C_ToThietKe.giaoviecSDV(shs, this.sodovien.SelectedValue.ToString(), DAL.C_USERS._userName);
                    }
                }

                if (chek == false)
                {
                    MessageBox.Show(this, "Chưa Chọn Hồ Sơ Để Giao Cho Sơ Đồ Viên.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    giaoviec();
                }
            }
            catch (Exception ex)
            {
                log.Error("TTK Giao Viec Loi " + ex.Message);
            }
           
        }

        private void DG_ChuaGiao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DG_ChuaGiao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == 0)
            {
                if (DG_ChuaGiao.Rows[e.RowIndex].Cells[0].Value == null)
                {
                    DG_ChuaGiao.Rows[e.RowIndex].Cells[0].Value = true;
                }
                else
                {
                    bool bChecked = (bool)DG_ChuaGiao.Rows[e.RowIndex].Cells[0].Value;
                    DG_ChuaGiao.Rows[e.RowIndex].Cells[0].Value = !bChecked;
                }
            }
        }

        private void DotNhanDon_SelectedValueChanged(object sender, EventArgs e)
        {
            if (theodot.Checked)
            {
                giaoviec();
            }
           
        }

        private void dateNhanDon_ValueChanged(object sender, EventArgs e)
        {
            if (theodoi_ngay.Checked) {
                giaoviec();
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                bool chek = false;
                for (int i = 0; i < DG_SDV.RowCount; i++)
                {
                    if (DG_SDV[0, i].Value != null && "True".Equals(DG_SDV[0, i].Value.ToString()))
                    {
                        chek = true;
                        string shs = DG_SDV.Rows[i].Cells[2].Value.ToString();
                        DAL.C_ToThietKe.giaoviecSDV(shs, null, DAL.C_USERS._userName);
                    }
                }

                if (chek == false)
                {
                    MessageBox.Show(this, "Chưa Chọn Hồ Sơ Để Hủy Giao Cho Sơ Đồ Viên.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    giaoviec();
                }
            }
            catch (Exception ex)
            {
                log.Error("TTK Giao Viec Loi " + ex.Message);
            }
        }

        private void DG_SDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == 0)
            {
                if (DG_SDV.Rows[e.RowIndex].Cells[0].Value == null)
                {
                    DG_SDV.Rows[e.RowIndex].Cells[0].Value = true;
                }
                else
                {
                    bool bChecked = (bool)DG_SDV.Rows[e.RowIndex].Cells[0].Value;
                    DG_SDV.Rows[e.RowIndex].Cells[0].Value = !bChecked;
                }
            }
        }

        private void resultPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (btAll.Checked == true)
            {
                ds = DAL.C_ToThietKe.BC_GIAOHS_SDV(null, null, this.sodovien.SelectedValue.ToString(), DAL.C_USERS._userName);

            }else  if (theodot.Checked == true)
            {

                ds = DAL.C_ToThietKe.BC_GIAOHS_SDV(this.DotNhanDon.SelectedValue.ToString(), null, this.sodovien.SelectedValue.ToString(), DAL.C_USERS._userName);


            }
            else if (theongay.Checked == true)
            {
                ds = DAL.C_ToThietKe.BC_GIAOHS_SDV(null, Utilities.DateToString.NgayVN(this.dateNhanDon), this.sodovien.SelectedValue.ToString(), DAL.C_USERS._userName);

            }
            rpt_View rpt = new rpt_View(ds);
            rpt.ShowDialog();
        }

        private void btAll_CheckedChanged(object sender, EventArgs e)
        {
           
            this.dateNhanDon.Enabled = false;
            this.DotNhanDon.Enabled = false;
            giaoviec();
        }

        private void thedoi_all_CheckedChanged(object sender, EventArgs e)
        {
            this.cb_TheoDot.Enabled = false;
            this.theodoi_denngay.Enabled = false;
            this.theodoi_tungay.Enabled = false;
            theodoi();
        }

        private void theodoi_bydot_CheckedChanged(object sender, EventArgs e)
        {
            this.cb_TheoDot.Enabled = true;
            this.theodoi_denngay.Enabled = false;
            this.theodoi_tungay.Enabled = false;
            theodoi();
        }

        private void theodoi_ngay_CheckedChanged(object sender, EventArgs e)
        {
            this.cb_TheoDot.Enabled = false;
            this.theodoi_denngay.Enabled = true;
            this.theodoi_tungay.Enabled = true;
            theodoi();
        }

        private void tabItem3_Click(object sender, EventArgs e)
        {
            #region Load SDV
            this.theodoi_SDV.DataSource = DAL.C_USERS.getUserByMaPhongAndLevel("TTK", 2);
            this.theodoi_SDV.DisplayMember = "FULLNAME";
            this.theodoi_SDV.ValueMember = "USERNAME";
            #endregion
            #region Loai Dot Khach Hang
            this.cb_TheoDot.DataSource = DAL.C_DotNhanDon.getListtMa_Dot_DaChuyen();
            this.cb_TheoDot.DisplayMember = "TEND";
            this.cb_TheoDot.ValueMember = "MADOT";
            #endregion
            theodoi();
        }

        public void theodoi()
        {
            try
            {                   
                DataTable tableHT = new DataTable();
                DataTable tableChuaHT = new DataTable();
                int countHT = 0;
                int countChuaHT = 0;
                if (this.thedoi_all.Checked)
                {
                    tableHT = DAL.C_ToThietKe.TinhHinhKSTK(null, null, null, this.theodoi_SDV.SelectedValue.ToString(), true);
                    tableChuaHT = DAL.C_ToThietKe.TinhHinhKSTK(null, null, null, this.theodoi_SDV.SelectedValue.ToString(), false);
                    countHT = DAL.C_ToThietKe.CountTinhHinhKSTK(null, null, null, this.theodoi_SDV.SelectedValue.ToString(), true);
                    countChuaHT = DAL.C_ToThietKe.CountTinhHinhKSTK(null, null, null, this.theodoi_SDV.SelectedValue.ToString(), false);
                }
                else if (this.theodoi_ngay.Checked)
                {
                    tableHT = DAL.C_ToThietKe.TinhHinhKSTK(null, Utilities.DateToString.NgayVN(theodoi_tungay), Utilities.DateToString.NgayVN(theodoi_denngay), this.theodoi_SDV.SelectedValue.ToString(), true);
                    tableChuaHT = DAL.C_ToThietKe.TinhHinhKSTK(null, Utilities.DateToString.NgayVN(theodoi_tungay), Utilities.DateToString.NgayVN(theodoi_denngay), this.theodoi_SDV.SelectedValue.ToString(), false);
                    countHT = DAL.C_ToThietKe.CountTinhHinhKSTK(null, Utilities.DateToString.NgayVN(theodoi_tungay), Utilities.DateToString.NgayVN(theodoi_denngay), this.theodoi_SDV.SelectedValue.ToString(), true);
                    countChuaHT = DAL.C_ToThietKe.CountTinhHinhKSTK(null, Utilities.DateToString.NgayVN(theodoi_tungay), Utilities.DateToString.NgayVN(theodoi_denngay), this.theodoi_SDV.SelectedValue.ToString(), false);
                }
                else if (this.theodoi_bydot.Checked)
                {
                    tableHT = DAL.C_ToThietKe.TinhHinhKSTK(cb_TheoDot.SelectedValue.ToString(), null, null, this.theodoi_SDV.SelectedValue.ToString(), true);
                    tableChuaHT = DAL.C_ToThietKe.TinhHinhKSTK(cb_TheoDot.SelectedValue.ToString(), null, null, this.theodoi_SDV.SelectedValue.ToString(), false);
                    countHT = DAL.C_ToThietKe.CountTinhHinhKSTK(cb_TheoDot.SelectedValue.ToString(), null, null, this.theodoi_SDV.SelectedValue.ToString(), true);
                    countChuaHT = DAL.C_ToThietKe.CountTinhHinhKSTK(cb_TheoDot.SelectedValue.ToString(), null, null, this.theodoi_SDV.SelectedValue.ToString(), false);
                }
                gv_ChuaHoanThanh.DataSource = tableChuaHT;
                gv_DaHoanThanh.DataSource = tableHT;
                lb_ChuaHoanThanh.Text = "Tống Công Có " + countChuaHT + " Hồ Sơ.";
                lb_Dahoanhthanh.Text = "Tống Công Có " + countHT + " Hồ Sơ.";               
            }
            catch (Exception ex)
            {
                log.Error("Theo Doi Tinh Hinh Thiet Ke Loi " + ex.Message);
            }
            Utilities.DataGridV.formatRows(gv_ChuaHoanThanh);
            Utilities.DataGridV.formatRows(gv_ChuaHoanThanh);
        }
        private void theodoi_Xem_Click(object sender, EventArgs e)
        {
            theodoi();
        }        
        private void txtSHS_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtResult.Text = null;
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
                            this.txtSoHo.Value = decimal.Parse(donkh.SOHO.ToString());
                            this.txtHoTen.Text = donkh.HOTEN;
                            this.txtdiachi.Text = donkh.SONHA + " " + donkh.DUONG + ", P. " + DAL.C_Phuong.finbyPhuong(donkh.QUAN, donkh.PHUONG).TENPHUONG + ", Q." + DAL.C_Quan.finByMaQuan(donkh.QUAN).TENQUAN;
                            this.txtLoaiKH.Text = DAL.C_LoaiKhachHang.finbyMaLoai(donkh.LOAIKH).TENLOAI;
                            this.txtLoaiHS.Text = DAL.C_LoaiHoSo.findbyMaLoai(donkh.LOAIHOSO).TENLOAI;
                            this.txtDotND.Text = donkh.MADOT;
                            this.txtSoDT.Text = donkh.DIENTHOAI;
                            this.txtGhiChu.Text = donkh.GHICHU;
                            Database.TOTHIETKE ttk = DAL.C_ToThietKe.findBySoHoSo(donkh.SOHOSO);
                            if (ttk != null) {
                                if (ttk.TRONGAITHIETKE == true)
                                {
                                    this.checkTroNgai.Checked = true;
                                    this.txtNoiDungTN.Text = ttk.NOIDUNGTRONGAI;
                                    
                                   
                                }
                                Database.USER us = DAL.C_USERS.findByUserName(ttk.SODOVIEN);
                                if (us != null)
                                {
                                    this.txt_sdv.Text = us.FULLNAME;
                                }
                            }
                         
                        }
                        else {
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
            string _soHoSo = this.txtSoHoSo.Text;
            bool tk=false;
            if (this.checkTroNgai.Checked == true)
            {
                tk = true;
                DAL.LinQConnection.ExecuteCommand_("UPDATE DON_KHACHHANG SET TRONGAITHIETKE=1 WHERE SHS='" + _soHoSo + "'");
            }
            else {
                DAL.LinQConnection.ExecuteCommand_("UPDATE DON_KHACHHANG SET TRONGAITHIETKE=0 WHERE SHS='" + _soHoSo + "'");
            }
            try
            {
               
                if (_soHoSo != null)
                {
                  bool result =  DAL.C_ToThietKe.TraHS(tk,_soHoSo, this.txtNoiDungTN.Text);
                  bool result1 = DAL.C_DonKhachHang.TroNgaiThietKe(tk, _soHoSo, this.txtNoiDungTN.Text, DAL.C_USERS._userName);
                  if (result && result1) {
                    
                      MessageBox.Show(this,"Trả Hồ Sơ Thành Công !" , "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
                      //txtResult.Text = "Trả Hồ Sơ Thành Công";
                  }
                  else { 
                      MessageBox.Show(this, "Trả Hồ Sơ Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      //txtResult.Text = "Trả Hồ Sơ Thất Bại"; 
                  }
                }
            }
            catch (Exception ex)
            {
                log.Error("Loi tra ho so " + ex.Message);
                MessageBox.Show(this,  "Chuyển Hồ Sơ Lỗi !","..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void theodoi_SDV_SelectedValueChanged(object sender, EventArgs e)
        {
            theodoi();
        }

        private void cb_TheoDot_SelectedValueChanged(object sender, EventArgs e)
        {
            theodoi();

        }

        private void theodoi_tungay_ValueChanged(object sender, EventArgs e)
        {
            theodoi();
        }

        private void theodoi_denngay_ValueChanged(object sender, EventArgs e)
        {
            theodoi();
        }

        private void print_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (this.theodoi_ngay.Checked)
            {
                ds = DAL.C_ToThietKe.BC_TinhHinhKSTK(null, Utilities.DateToString.NgayVN(theodoi_tungay), Utilities.DateToString.NgayVN(theodoi_denngay), this.theodoi_SDV.SelectedValue.ToString(), DAL.C_USERS._userName);
                flag = 1;
            }
            else if (this.theodoi_bydot.Checked)
            {
                ds = DAL.C_ToThietKe.BC_TinhHinhKSTK(cb_TheoDot.SelectedValue.ToString(), null, null, this.theodoi_SDV.SelectedValue.ToString(), DAL.C_USERS._userName);
                flag = 2;
            }
            frm_TTTK rpt = new frm_TTTK(ds, flag);
            rpt.ShowDialog();
            //rpt_BC_TheoDoiTTTK r = new rpt_BC_TheoDoiTTTK();
            //r.ShowDialog();
        }

        private void tabItem1_Click(object sender, EventArgs e)
        {
            this.dateNhanDon.Value = DateTime.Now;
            formLoad();
        }

        private void tabItem2_Click(object sender, EventArgs e)
        {

        }

        public void refesh() {
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
        private void tabItem4_Click(object sender, EventArgs e)
        {
            refesh();
        }

        private void tabItem2_Click_1(object sender, EventArgs e)
        {
            this.panelGhepHs.Controls.Clear();
            this.panelGhepHs.Controls.Add(new tab_GhepHoSo());
        }
    }
}