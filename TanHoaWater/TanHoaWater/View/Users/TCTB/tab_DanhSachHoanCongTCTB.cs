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
using System.Globalization;
namespace TanHoaWater.View.Users.TCTB
{
    public partial class tab_DanhSachHoanCongTCTB : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_DanhSachHoanCongTCTB).Name);
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public tab_DanhSachHoanCongTCTB(string madottc)
        {
            InitializeComponent();
            //string sql = "SELECT [SHS],[HOTEN],[DIACHI],[COTLK],[NGAYTHICONG],[CHISO],[SOTHANTLK],[HIEUDONGHO],[SOHOADON],[NGAYDONGTIEN] ,[TCTB_TONGGIATRI],[TCTB_CPNHANCONG],[TCTB_CPVATTU],[ONG20],[ONG25],[ONG50],[ONG100],[ONG150],[ONGKHAC],[MADOTTC],[DHN_NGAYKIEMDINH] FROM V_HOANGCONGTCTB WHERE MADOTTC='" + this.cbDotHoanCong.Text.Replace(" ", "") + "'";
            //gridHoanCong.DataSource = DAL.LinQConnection.getDataTable(sql);


            string sql = "SELECT MADOTTC FROM V_HOANGCONGTCTB GROUP BY MADOTTC ORDER BY MADOTTC ASC";
            cbDotHoanCong.DataSource = DAL.LinQConnection.getDataTable(sql);
            cbDotHoanCong.DisplayMember = "MADOTTC";
            cbDotHoanCong.ValueMember = "MADOTTC";
            try
            {
                hoantat();
            }
            catch (Exception)
            {

            }

            List<DHN_DONGHO> list = DAL.C_DHN_TENDONGHO.ListDanhSachDongHo();
            foreach (var item in list)
            {
                namesCollection.Add(item.TENDONGHO);
            }
            txtHieu.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtHieu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtHieu.AutoCompleteCustomSource = namesCollection;



        }
        public void loadData()
        {

        }

        private void checkChuaHoanCong_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCong(this.cbDotHoanCong.Text, -1);
            }
            catch (Exception)
            {

            }
        }

        private void chekDaHoanCong_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCong(this.cbDotHoanCong.Text, 1);
            }
            catch (Exception)
            {

            }
        }

        private void checkALl_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCong(this.cbDotHoanCong.Text, 0);
            }
            catch (Exception)
            {

            }
        }
        public void hoantat()
        {
            try
            {

                string sql = "SELECT [SHS],'True' as 'IN',[HOTEN],[DIACHI],[COTLK],[NGAYTHICONG],[CHISO],[SOTHANTLK],[HIEUDONGHO],[SOHOADON],[NGAYDONGTIEN] ,[TCTB_TONGGIATRI],[TCTB_CPNHANCONG],[TCTB_CPVATTU],[ONG20],[ONG25],[ONG50],[ONG100],[ONG150],[ONGKHAC],[MADOTTC],[DHN_NGAYKIEMDINH],DANHBO ";
                sql+=" FROM V_HOANGCONGTCTB WHERE MADOTTC='" + this.cbDotHoanCong.Text.Replace(" ", "") + "'"; 
                gridHoanCong.DataSource = DAL.LinQConnection.getDataTable(sql);
                     }
            catch (Exception)
            {

            }
        }
        private void cbDotHoanCong_SelectedIndexChanged(object sender, EventArgs e)
        {
            hoantat();
        }
        
        private void gridHoanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               this.txtSHS.Text= this.gridHoanCong.Rows[e.RowIndex].Cells["hc_SHS"].Value+"";
               this.txtHoTen.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_HoTen"].Value + "";
               this.txtDiaChi.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_DiaChi"].Value + "";
               this.txtCoTLK.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_CoTLK"].Value + "";
               this.dateNgayGan.ValueObject = DateTime.ParseExact(this.gridHoanCong.Rows[e.RowIndex].Cells["hc_NgayTC"].Value + "", "dd/MM/yyyy", new CultureInfo("en-US"));
               if ("".Equals(this.gridHoanCong.Rows[e.RowIndex].Cells["hc_ChiSo"].Value + "")) {
                   this.txtChiSo.Text = "00";
               } else { 
             this.txtChiSo.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_ChiSo"].Value + "";
               }
              
               this.txtSoThan.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_SoTLK"].Value + "";
               this.txtHieu.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["gr_TenDongHo"].Value + "";
               this.txtbienLai.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_SoBL"].Value + "";
               this.dateNgayDongTien.ValueObject = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_NgayDongTein"].Value;
               this.txtTongGiaTri.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_TongGTXL"].Value + "";
               this.txtNhanCong.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_NhanCong"].Value + "";
               this.txtVatTu.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_ChiPhiVT"].Value + "";
               this.txtO20.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["O20"].Value + "";
               this.txtO25.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["O25"].Value + "";
               this.txtO50.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["O50"].Value + "";
               this.txtO100.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["O100"].Value + "";
               this.txtOK.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["OK"].Value + "";
               this.txtDanhBo.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["DANHBO"].Value + "";
               this.txtSHS.Focus();
                    

            }
            catch (Exception)
            {
            }
        }

        private void dateThiCong_ValueChanged(object sender, EventArgs e)
        {
           // gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_NgayTC"].Value = Utilities.DateToString.NgayVN(this.dateThiCong);
           // dateThiCong.Visible = false;
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
          //  this.dateThiCong.Visible = false;
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
                        DAL.C_KH_HoanCong.HoanCong(shs, DateTime.ParseExact(ngaytc, "dd/MM/yyyy", null), int.Parse(chiso), cotlk, sothanTLK.ToUpper(), hieudongho, HoanCong);
                        flag = true;
                    }

                }

                if (flag) {
                    MessageBox.Show(this, "Hoàn Tất.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
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

        
        double ParseDouble(string so) {
            try
            {
                return double.Parse(so.Replace(" ",""));
            }
            catch (Exception)
            {
            }
            return 0;
        }
        private void btHoanTat_Click(object sender, EventArgs e)
        {
            //updateDulieu();
            string shs = this.txtSHS.Text;
            KH_HOSOKHACHHANG hskh = DAL.C_HoanCongDHN_DotTCTB.findByHoSoHC(shs);
            if (hskh != null) {
                try{
                    hskh.COTLK = int.Parse(this.txtCoTLK.Text);
                }
                catch (Exception)
                {}
                if (!"1/1/0001".Equals(this.dateNgayGan.Value.ToShortDateString()))
                {
                    hskh.NGAYTHICONG = dateNgayGan.Value.Date;
                }
                try{
                       hskh.CHISO = int.Parse(this.txtChiSo.Text);
                }
                catch (Exception)
                {}
                hskh.SOTHANTLK = this.txtSoThan.Text;
                hskh.HIEUDONGHO=this.txtHieu.Text;
                hskh.TCTB_TONGGIATRI = ParseDouble(this.txtTongGiaTri.Text);
                hskh.TCTB_CPNHANCONG = ParseDouble(this.txtNhanCong.Text);
                hskh.TCTB_CPVATTU = ParseDouble(this.txtVatTu.Text);
                hskh.ONG20 = this.txtO20.Text;
                hskh.ONG25 = this.txtO25.Text;
                hskh.ONG50 = this.txtO50.Text;
                hskh.ONG100 = this.txtO100.Text;
                hskh.ONGKHAC = this.txtOK.Text;
                if (DAL.C_HoanCongDHN_DotTCTB.Update()== false)
                    MessageBox.Show(this, "Cập Nhật Đợt Thi Công Không Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
                hoantat();

                    
            }           

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

        private void btInBangKe_Click(object sender, EventArgs e)
        {
            if (getSHS().Equals(""))
                MessageBox.Show(this, "Cần Chọn Hồ Sơ In", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                ReportDocument rp = new rpt_HoanCong();
                rp.SetDataSource(DAL.C_KH_HoanCong.BC_HOANCONG(this.cbDotHoanCong.Text, getSHS()));
                rpt_Main rpt = new rpt_Main(rp);
                rpt.ShowDialog();
            }

        }

        private void gridHoanCong_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        public int checktrungsothan(string hopdong)
        {
            int count = 0;
            for (int i = 0; i < gridHoanCong.Rows.Count; i++)
                if (hopdong.Equals((this.gridHoanCong.Rows[i].Cells["hc_SoTLK"].Value + "").Trim()))
                  count++;
            return count;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}