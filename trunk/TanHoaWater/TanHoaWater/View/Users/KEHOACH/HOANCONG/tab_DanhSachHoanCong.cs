using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using TanHoaWater.View.Users.HOANCONG.BC;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.KEHOACH.HOANCONG.BC;
using TanHoaWater.View.Users.Report;
using TanHoaWater.Database;
namespace TanHoaWater.View.Users.KEHOACH.HOANCONG
{
    public partial class tab_DanhSachHoanCong : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_DanhSachHoanCong).Name);
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public tab_DanhSachHoanCong(string madottc)
        {
            InitializeComponent();
            List<KH_DOTTHICONG> list = DAL.C_KH_DotThiCong.getListDTC();
            foreach (var item in list)
            {
                namesCollection.Add(item.MADOTTC);
            }
            cbDotTC.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbDotTC.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbDotTC.AutoCompleteCustomSource = namesCollection;
            try
            {
                gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCong(DAL.C_KH_DotThiCong.__dotthicong, 0);
                lbHoanCong.Text = "Tổng cộng có " + gridHoanCong.Rows.Count + " hồ sơ Hoàn Công";
            }
            catch (Exception)
            {

            }

            List<DHN_DONGHO> list1 = DAL.C_DHN_TENDONGHO.ListDanhSachDongHo();
            foreach (var item in list1)
            {
                namesCollection.Add(item.TENDONGHO);
            }
            cbDotTC.Text = DAL.C_KH_DotThiCong.__dotthicong;

            txtHieuDN.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtHieuDN.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtHieuDN.AutoCompleteCustomSource = namesCollection;
        }
        public void loadData()
        {

        }

        private void checkChuaHoanCong_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCong(this.cbDotTC.Text, -1);
            }
            catch (Exception)
            {

            }
        }

        private void chekDaHoanCong_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCong(this.cbDotTC.Text, 1);
            }
            catch (Exception)
            {

            }
        }

        private void checkALl_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCong(this.cbDotTC.Text, 0);
            }
            catch (Exception)
            {

            }
        }
        public void hoantat()
        {
            try
            {
                if (checkALl.Checked)
                    gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCong_(this.cbDotTC.Text, 0);
                else if (checkChuaHoanCong.Checked)
                    gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCong_(this.cbDotTC.Text, -1);
                else if (chekDaHoanCong.Checked)
                    gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCong_(this.cbDotTC.Text, 1);

            }
            catch (Exception)
            {

            }
        }
        private void cbDotHoanCong_SelectedIndexChanged(object sender, EventArgs e)
        {
            hoantat();
        }
        string formatNumber(string db)
        {
            try
            {
                return double.Parse(db).ToString("N0");
            }
            catch (Exception)
            {


            }

            return "0";
        }
        public void Refresh()
        {
            this.txtSoHoSo.Focus();
            this.txtSoHoSo.Text = "";
            this.txtHoTen.Text = "";
            this.txtDiaChi.Text = "";
            this.CoTLK.Text = "";
            this.txtNgayTC.ValueObject = null;
            this.txtNgayKiemDinh.ValueObject = null;
            this.ckChuyenDHN.Checked = true;
            this.txtChiSo.Text = "";
            this.txtSoThan.Text = "";
            this.txtHieuDN.Text = "";
            this.txtNgayDongTien.Text = "";
            this.txtGiaTriXL.Text = "";
            this.txtNhanCong.Text = "";
            this.txtVatTu.Text = "";
            this.txtMayTC.Text = "";
        }
        private void gridHoanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_ChonIn")
                {
                }
                else
                {
                    Refresh();
                    this.txtSoHoSo.Focus();
                    this.txtSoHoSo.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_SHS"].Value + "";
                    this.txtHoTen.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_HoTen"].Value + "";
                    this.txtDiaChi.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_DiaChi"].Value + "";
                    this.CoTLK.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_TLK"].Value + "";
                    if (this.gridHoanCong.Rows[e.RowIndex].Cells["hc_NgayTC"].Value != null && !"".Equals(this.gridHoanCong.Rows[e.RowIndex].Cells["hc_NgayTC"].Value + ""))
                    {
                        this.txtNgayTC.ValueObject = DateTime.ParseExact(this.gridHoanCong.Rows[e.RowIndex].Cells["hc_NgayTC"].Value + "", "dd/MM/yyyy", null);
                    }

                    if (this.gridHoanCong.Rows[e.RowIndex].Cells["hc_NgayKD"].Value != null && !"".Equals(this.gridHoanCong.Rows[e.RowIndex].Cells["hc_NgayKD"].Value + ""))
                    {
                        this.txtNgayKiemDinh.ValueObject = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_NgayKD"].Value;
                    }

                    try
                    {
                        this.ckChuyenDHN.Checked = bool.Parse(this.gridHoanCong.Rows[e.RowIndex].Cells["hc_DHN"].Value + "");
                    }
                    catch (Exception)
                    {

                        this.ckChuyenDHN.Checked = true;
                    }
                    this.txtChiSo.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_ChiSo"].Value + "";
                    this.txtSoThan.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_SoTLK"].Value + "";
                    this.txtHieuDN.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["gr_TenDongHo"].Value + "";
                    this.txtNgayDongTien.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_NgayDongTein"].Value + "";
                    this.txtGiaTriXL.Text = formatNumber(this.gridHoanCong.Rows[e.RowIndex].Cells["hc_TongGTXL"].Value + "");
                    this.txtNhanCong.Text = formatNumber(this.gridHoanCong.Rows[e.RowIndex].Cells["hc_NhanCong"].Value + "");
                    this.txtVatTu.Text = formatNumber(this.gridHoanCong.Rows[e.RowIndex].Cells["hc_ChiPhiVT"].Value + "");
                    this.txtMayTC.Text = formatNumber(this.gridHoanCong.Rows[e.RowIndex].Cells["hc_MayThiCong"].Value + "");

                    this.txtDanhBo.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["DHN_SODANHBO"].Value + "";
                    this.txtHopDong.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["DHN_SOHOPDONG"].Value + "";
                }


            }
            catch (Exception)
            {
            }
        }

        private void dateThiCong_ValueChanged(object sender, EventArgs e)
        {
            gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_NgayTC"].Value = Utilities.DateToString.NgayVN(this.dateThiCong);
            dateThiCong.Visible = false;
        }

        private void gridHoanCong_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_NgayDongTein")
            //{
            //    dateThiCong.Visible = true;
            //    dateThiCong.Top = this.gridHoanCong.Top + gridHoanCong.GetRowDisplayRectangle(gridHoanCong.CurrentCell.RowIndex, true).Top;
            //    dateThiCong.Left = this.gridHoanCong.Left + gridHoanCong.GetColumnDisplayRectangle(gridHoanCong.CurrentCell.ColumnIndex, true).Left;
            //    dateThiCong.Width = gridHoanCong.Columns[gridHoanCong.CurrentCell.ColumnIndex+1].Width;
            //    dateThiCong.Height = gridHoanCong.Rows[gridHoanCong.CurrentCell.ColumnIndex+1].Height;
            //    dateThiCong.BringToFront();
            //    dateThiCong.Select();
            //    dateThiCong.Focus();
            //}
            //try
            //{
            //    this.gridHoanCong.Rows[e.RowIndex].Cells["hc_SoTLK"].Value = (this.gridHoanCong.Rows[e.RowIndex].Cells["hc_SoTLK"].Value + "").ToUpper();
            //}
            //catch (Exception)
            //{

            //}

        }

        private void dateThiCong_Leave(object sender, EventArgs e)
        {
            this.dateThiCong.Visible = false;
        }
        private Control txtKeypress;
        private void KeyPressHandle(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                if ((e.KeyChar) != 8 && (e.KeyChar) != 46 && (e.KeyChar) != 37 && (e.KeyChar) != 39 && (e.KeyChar) != 188)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
        }
        private void gridHoanCong_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            try
            {
                if (gridHoanCong.CurrentCell.OwningColumn.Name == "gr_TenDongHo")
                {
                    if (e.Control is DataGridViewTextBoxEditingControl)
                    {
                        DataGridViewTextBoxEditingControl te =
                        (DataGridViewTextBoxEditingControl)e.Control;
                        te.AutoCompleteMode = AutoCompleteMode.Suggest;
                        te.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        te.AutoCompleteCustomSource = namesCollection;
                    }
                }
                if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_SoTLK")
                {
                    btInBangKe.Enabled = false;
                    btHoanTat.Enabled = true;
                    this.gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoTLK"].Value = (this.gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoTLK"].Value + "").ToUpper();

                }

                txtKeypress = e.Control;
                if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_ChiSo")
                {
                    txtKeypress.KeyPress -= KeyPressHandle;
                    txtKeypress.KeyPress += KeyPressHandle;
                }
                else
                {
                    txtKeypress.KeyPress -= KeyPressHandle;
                }
            }
            catch (Exception)
            {

            }

        }

        private void gridHoanCong_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_NgayTC")
            //    {
            //        if (Utilities.DateToString.checkDate(this.gridHoanCong.Rows[e.RowIndex].Cells["hc_NgayTC"].Value + "") == false)
            //        {
            //            this.gridHoanCong.Rows[e.RowIndex].Cells["hc_NgayTC"].ErrorText = "Ngày Không Hợp Lệ.";

            //        }
            //        else
            //            this.gridHoanCong.Rows[e.RowIndex].Cells["hc_NgayTC"].ErrorText = null;
            //    }
            //}
            //catch (Exception)
            //{ }
        }

        bool flag = true;
        void updateDulieu()
        {
            bool flag = false;
            int i = 0;
            try
            {

                for (i = 0; i < gridHoanCong.Rows.Count; i++)
                {
                    flag = false;
                    string ngaytc = "";
                    string chiso = "";
                    string shs = this.gridHoanCong.Rows[i].Cells["hc_SHS"].Value + "";
                    string sothanTLK = this.gridHoanCong.Rows[i].Cells["hc_SoTLK"].Value + "";
                    string hc = this.gridHoanCong.Rows[i].Cells["hc_DHN"].Value + "";
                    string hieudongho = this.gridHoanCong.Rows[i].Cells["gr_TenDongHo"].Value + "";
                    string s_cotlk = (this.gridHoanCong.Rows[i].Cells["hc_TLK"].Value + "").Trim();
                    bool HoanCong = false;
                    try
                    {
                        HoanCong = bool.Parse(hc);
                    }
                    catch (Exception)
                    {
                    }
                    if (this.gridHoanCong.Rows[i].Cells["hc_SoTLK"].Value != null && !"".Equals(this.gridHoanCong.Rows[i].Cells["hc_SoTLK"].Value + ""))
                    {
                        if (this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].Value != null && "".Equals(this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].Value + ""))
                        {
                            this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].ErrorText = "Ngày Thi Công Không Được Trống";
                            break;
                        }
                        else
                        {
                            this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].ErrorText = null;
                            ngaytc = this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].Value + "";
                        }


                        if (Utilities.DateToString.checkDate(Utilities.DateToString.convartddMMyyyy(this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].Value + "").Trim()) == false)
                        {
                            this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].ErrorText = "Ngày Thi Công Không Hợp Lệ";
                            break;
                        }
                        else
                        {
                            this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].ErrorText = null;
                            ngaytc = Utilities.DateToString.convartddMMyyyy((this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].Value + "").Trim());
                        }

                        if (this.gridHoanCong.Rows[i].Cells["hc_ChiSo"].Value != null && "".Equals(this.gridHoanCong.Rows[i].Cells["hc_ChiSo"].Value + ""))
                        {
                            this.gridHoanCong.Rows[i].Cells["hc_ChiSo"].ErrorText = "Chi Số Ko Được Trống";
                            break;
                        }
                        else
                        {
                            this.gridHoanCong.Rows[i].Cells["hc_ChiSo"].ErrorText = null;
                            chiso = this.gridHoanCong.Rows[i].Cells["hc_ChiSo"].Value + "";
                        }
                        int cotlk = 15;
                        try
                        {
                            cotlk = int.Parse(s_cotlk);
                        }
                        catch (Exception)
                        {

                        }
                        //     DAL.C_KH_HoanCong.HoanCong(shs, DateTime.ParseExact(ngaytc, "dd/MM/yyyy", null), int.Parse(chiso), cotlk, sothanTLK.ToUpper(), hieudongho, HoanCong);
                        flag = true;
                    }

                }

                if (flag)
                {
                    MessageBox.Show(this, "Hoàn Tất.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Lỗi Cập Nhật Dữ Liệu.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.btInBangKe.Enabled = true;
                //hoantat();
            }
            catch (Exception ex)
            {
                this.gridHoanCong.Rows[i].ErrorText = "Lỗi Dữ Liệu";
                log.Error("Loi Hoan Tat Hoan Cong" + ex.Message);
            }

        }

        private void btHoanTat_Click(object sender, EventArgs e)
        {
            updateDulieu();


        }

        public string getSHS()
        {
            string result = "";
            for (int i = 0; i < gridHoanCong.Rows.Count; i++)
            {
                string shs = this.gridHoanCong.Rows[i].Cells["hc_SHS"].Value + "";
                string chonin = this.gridHoanCong.Rows[i].Cells["hc_ChonIn"].Value + "";
                if ("True".Equals(chonin))
                    result += "'" + shs + "',";
            }
            if (result.Length > 0)
                result = result.Substring(0, result.Length - 1);
            return result;
        }
        private void btTachChiPhi_Click(object sender, EventArgs e)
        {
            if (getSHS().Equals(""))
                MessageBox.Show(this, "Cần Chọn Hồ Sơ In", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                frmDialogPrintting frm = new frmDialogPrintting(getSHS());
                frm.ShowDialog();
            }
        }

        public string DemHS()
        {
            int count = 0;
            int hs = 0;
            for (int i = 0; i < gridHoanCong.Rows.Count; i++)
            {
                string hc_ChiPhiVT = this.gridHoanCong.Rows[i].Cells["hc_TongGTXL"].Value + "";
                string chonin = this.gridHoanCong.Rows[i].Cells["hc_ChonIn"].Value + "";
                if ("True".Equals(chonin))
                {
                    hs++;

                    if (!"0".Equals(hc_ChiPhiVT))
                        count++;
                }

            }
            return (count + " HS/ " + hs + "ĐC");

        }
        private void btInBangKe_Click(object sender, EventArgs e)
        {
            if (getSHS().Equals(""))
                MessageBox.Show(this, "Cần Chọn Hồ Sơ In", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                ReportDocument rp = new rpt_HoanCong();
                rp.SetDataSource(DAL.C_KH_HoanCong.BC_HOANCONG(this.cbDotTC.Text, getSHS()));
                rp.SetParameterValue("DemHS", DemHS());
                rpt_Main rpt = new rpt_Main(rp);
                rpt.ShowDialog();
            }

        }

        private void gridHoanCong_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        public int checktrungsothan(string hopdong, string shs)
        {
            int count = 0;
            for (int i = 0; i < gridHoanCong.Rows.Count; i++)
                if (hopdong.Equals((this.gridHoanCong.Rows[i].Cells["hc_SoTLK"].Value + "").Trim()) && !shs.Equals((this.gridHoanCong.Rows[i].Cells["hc_SHS"].Value + "").Trim()))
                    count++;
            return count;
        }
        private void gridHoanCong_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_SoTLK")
            //{
            //    if (checktrungsothan(this.gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoTLK"].Value + "")>1)
            //    {
            //        MessageBox.Show(this, "Số Thân TLK Đã Tồn Tại.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    else if (DAL.C_KH_HoSoKhachHang.checkSoThanTLK(this.gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoTLK"].Value + "") >= 1)
            //    {
            //        MessageBox.Show(this, "Số Thân TLK Đã Tồn Tại.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}

        }

        private void cbDotTC_Leave(object sender, EventArgs e)
        {
            try
            {
                gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCong(this.cbDotTC.Text, 0);
                lbHoanCong.Text = "Tổng cộng có " + gridHoanCong.Rows.Count + " hồ sơ Hoàn Công";
                DAL.C_KH_DotThiCong.__dotthicong = this.cbDotTC.Text;
            }
            catch (Exception)
            {

            }
        }

        void UpdateGrid(int index)
        {
         //   MessageBox.Show(this, index.ToString());
            try
            {
                this.gridHoanCong.Rows[index].Cells["hc_TLK"].Value = this.CoTLK.Text;
                this.gridHoanCong.Rows[index].Cells["hc_ChiSo"].Value = this.txtChiSo.Text;
                this.gridHoanCong.Rows[index].Cells["hc_SoTLK"].Value = this.txtSoThan.Text;
                this.gridHoanCong.Rows[index].Cells["gr_TenDongHo"].Value = this.txtHieuDN.Text;
                this.gridHoanCong.Rows[index].Cells["hc_NgayTC"].Value = this.txtNgayTC.Value;

                try
                {
                    this.gridHoanCong.Rows[index].Cells["hc_DHN"].Value = this.ckChuyenDHN.Checked;
                }
                catch (Exception)
                {

                    this.ckChuyenDHN.Checked = true;
                }

            }
            catch (Exception)
            {
            }
            
           // gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCong(this.cbDotTC.Text, 0);

            

        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            string shs = this.txtSoHoSo.Text;
            string sothanTLK = this.txtSoThan.Text;
            string hieudongho = this.txtHieuDN.Text;
            string s_cotlk = this.CoTLK.Text;
            bool HoanCong = false;
            try
            {
                HoanCong = this.ckChuyenDHN.Checked;
            }
            catch (Exception)
            {
            }
            DateTime ngaytc = new DateTime();
            if (!"1/1/0001".Equals(this.txtNgayTC.Value.Date.ToShortDateString()))
            {
                ngaytc = txtNgayTC.Value.Date;
            }
            try
            {

            }
            catch (Exception)
            {

            }
            DateTime ngaykd = new DateTime();
            if (!"1/1/0001".Equals(this.txtNgayKiemDinh.Value.ToShortDateString()))
            {
                ngaykd = txtNgayKiemDinh.Value.Date;
            }


            int cotlk = 15;
            try
            {
                cotlk = int.Parse(s_cotlk.Trim());
            }
            catch (Exception)
            {

            }
            int cs = 0;
            try
            {
                cs = int.Parse(this.txtChiSo.Text.Trim());
            }
            catch (Exception)
            {

            }

            List<KH_HOSOKHACHHANG> tlk = DAL.C_KH_HoSoKhachHang.ListSoThanTLK(sothanTLK.Trim(), shs);

            if (checktrungsothan(sothanTLK.Trim() + "", shs) > 0)
            {
                MessageBox.Show(this, "Số Thân TLK Đã Tồn Tại. Kiểm tra Đợt Thi Công : " +this.cbDotTC.Text, "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tlk.Count > 1)
            {
                MessageBox.Show(this, "Số Thân TLK Đã Tồn Tại. Kiểm Tra SHS-Đợt TC : [" + tlk[0].SHS + "-" + tlk[0].MADOTTC + "] và [" + tlk[1].SHS + "-" + tlk[1].MADOTTC + "]", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                flag = DAL.C_KH_HoanCong.HoanCong(shs, ngaytc, cs, cotlk, sothanTLK.ToUpper(), hieudongho, HoanCong, ngaykd);
                if (flag)
                {
                    //
                    UpdateDocSo();
                    //
                    MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ///gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCong(this.cbDotTC.Text, 0);
                    UpdateGrid(this.gridHoanCong.CurrentCell.RowIndex);
                    Refresh();
                }
                else
                {
                    MessageBox.Show(this, "Cập Nhật Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public void UpdateDocSo()
        {
            try
            {
                if (!"".Equals(this.txtDanhBo.Text.Trim().Replace("-", "")))
                {
                    string insert = "UPDATE TB_DULIEUKHACHHANG SET NGAYKIEMDINH='" + this.txtNgayKiemDinh.Value + "' WHERE DANHBO='" + this.txtDanhBo.Text.Trim().Replace("-", "") + "'";
                    DULIEUKH.C_GanMoi.ExecuteCommand_(insert);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }
        private void txtSoHoSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                for (int i = 0; i < gridHoanCong.Rows.Count; i++)
                {
                    if (this.txtSoHoSo.Text.Equals(this.gridHoanCong.Rows[i].Cells["hc_SHS"].Value + ""))
                    {
                        this.txtHoTen.Text = this.gridHoanCong.Rows[i].Cells["hc_HoTen"].Value + "";
                        this.txtDiaChi.Text = this.gridHoanCong.Rows[i].Cells["hc_DiaChi"].Value + "";
                        this.CoTLK.Text = this.gridHoanCong.Rows[i].Cells["hc_TLK"].Value + "";
                        if (this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].Value != null && !"".Equals(this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].Value + ""))
                        {
                            this.txtNgayTC.ValueObject = DateTime.ParseExact(this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].Value + "", "dd/MM/yyyy", null);
                        }

                        if (this.gridHoanCong.Rows[i].Cells["hc_NgayKD"].Value != null && !"".Equals(this.gridHoanCong.Rows[i].Cells["hc_NgayKD"].Value + ""))
                        {
                            this.txtNgayKiemDinh.ValueObject = DateTime.ParseExact(this.gridHoanCong.Rows[i].Cells["hc_NgayKD"].Value + "", "dd/MM/yyyy", null); ;
                        }

                        try
                        {
                            this.ckChuyenDHN.Checked = bool.Parse(this.gridHoanCong.Rows[i].Cells["hc_DHN"].Value + "");
                        }
                        catch (Exception)
                        {

                            this.ckChuyenDHN.Checked = true;
                        }
                        this.txtChiSo.Text = this.gridHoanCong.Rows[i].Cells["hc_ChiSo"].Value + "";
                        this.txtSoThan.Text = this.gridHoanCong.Rows[i].Cells["hc_SoTLK"].Value + "";
                        this.txtHieuDN.Text = this.gridHoanCong.Rows[i].Cells["gr_TenDongHo"].Value + "";
                        this.txtNgayDongTien.Text = this.gridHoanCong.Rows[i].Cells["hc_NgayDongTein"].Value + "";
                        this.txtGiaTriXL.Text = formatNumber(this.gridHoanCong.Rows[i].Cells["hc_TongGTXL"].Value + "");
                        this.txtNhanCong.Text = formatNumber(this.gridHoanCong.Rows[i].Cells["hc_NhanCong"].Value + "");
                        this.txtVatTu.Text = formatNumber(this.gridHoanCong.Rows[i].Cells["hc_ChiPhiVT"].Value + "");
                        this.txtMayTC.Text = formatNumber(this.gridHoanCong.Rows[i].Cells["hc_MayThiCong"].Value + "");

                        break;
                    }

                }
            }
        }

        private void btXoaHC_Click(object sender, EventArgs e)
        {
            string shs = this.txtSoHoSo.Text;
            flag = DAL.C_KH_HoanCong.HoanCong_Clear(shs);
            if (flag)
            {
                MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCong(this.cbDotTC.Text, 0);
                Refresh();
            }
            else
            {
                MessageBox.Show(this, "Cập Nhật Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
