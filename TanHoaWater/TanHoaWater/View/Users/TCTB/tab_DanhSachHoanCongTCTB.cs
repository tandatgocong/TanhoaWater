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
using TanHoaWater.View.Users.TCTB.Report;
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
            string sql = "SELECT MADOTTC FROM V_HOANGCONGTCTB  GROUP BY MADOTTC ORDER BY MADOTTC ASC";
            DataTable table = DAL.LinQConnection.getDataTable(sql);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                namesCollection.Add(table.Rows[i]["MADOTTC"].ToString());
            }
            cbDotTC.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbDotTC.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbDotTC.AutoCompleteCustomSource = namesCollection;


         
            
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

                string sql = "SELECT [SHS],'True' as 'IN',[HOTEN],[DIACHI],[COTLK],[NGAYTHICONG],[CHISO],[SOTHANTLK],[HIEUDONGHO],[SOHOADON],[NGAYDONGTIEN] ,[TCTB_TONGGIATRI],[TCTB_CPNHANCONG],[TCTB_CPVATTU],[ONG20],[ONG25],[ONG50],[ONG100],[ONG150],[ONGKHAC],[MADOTTC],[DHN_NGAYKIEMDINH],DANHBO ";
                sql += " FROM V_HOANGCONGTCTB WHERE MADOTTC='" + this.cbDotTC.Text.Replace(" ", "") + "'"; 
                gridHoanCong.DataSource = DAL.LinQConnection.getDataTable(sql);
                TongKetGanNhua();

                     }
            catch (Exception)
            {

            }
        }
        private void cbDotHoanCong_SelectedIndexChanged(object sender, EventArgs e)
        {
            hoantat();
        }
        public void Refresh()
        {
            this.txtSHS.Text = "";
            this.txtHoTen.Text = "";
            this.txtDiaChi.Text = "";
            this.txtCoTLK.Text = "";
            this.dateNgayGan.ValueObject = null;
            this.txtChiSo.Text = "00";
            this.txtSoThan.Text = "";
            this.txtHieu.Text = "";
            this.txtbienLai.Text = "";
            this.dateNgayDongTien.ValueObject = null;
            this.txtTongGiaTri.Text = "";
            this.txtNhanCong.Text = "";
            this.txtVatTu.Text = "";
            this.txtO20.Text = "";
       //     this.txtO25.Text = "";
            this.txtO50.Text = "";
            this.txtO100.Text = "";
            this.txtOK.Text = "";
            this.txtDanhBo.Text = "";
            this.txtSHS.Focus();

        }
        private void gridHoanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Refresh();
               this.txtSHS.Text= this.gridHoanCong.Rows[e.RowIndex].Cells["hc_SHS"].Value+"";
               this.txtHoTen.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_HoTen"].Value + "";
               this.txtDiaChi.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_DiaChi"].Value + "";
               this.txtCoTLK.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_CoTLK"].Value + "";
               this.txtbienLai.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_SoBL"].Value + "";
               this.dateNgayDongTien.ValueObject = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_NgayDongTein"].Value;
               this.txtDanhBo.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["DANHBO"].Value + "";
               this.dateNgayGan.ValueObject = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_NgayTC"].Value;
               if ("".Equals(this.gridHoanCong.Rows[e.RowIndex].Cells["hc_ChiSo"].Value + "")) {
                   this.txtChiSo.Text = "00";
               } else { 
             this.txtChiSo.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_ChiSo"].Value + "";
               }
              
               this.txtSoThan.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_SoTLK"].Value + "";
               this.txtHieu.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["gr_TenDongHo"].Value + "";
             
               this.txtTongGiaTri.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_TongGTXL"].Value + "";
               this.txtNhanCong.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_NhanCong"].Value + "";
               this.txtVatTu.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_ChiPhiVT"].Value + "";
               this.txtO20.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["O20"].Value + "";
            //   this.txtO25.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["O25"].Value + "";
               this.txtO50.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["O50"].Value + "";
               this.txtO100.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["O100"].Value + "";
               this.txtOK.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["OK"].Value + "";
              
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
                  //      DAL.C_KH_HoanCong.HoanCong(shs, DateTime.ParseExact(ngaytc, "dd/MM/yyyy", null), int.Parse(chiso), cotlk, sothanTLK.ToUpper(), hieudongho, HoanCong);
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

        public void CapNhatHandHeld(TB_DULIEUKHACHHANG hskh)
        {
            //Cap Nhat Du Lieu Cho HandHeld
            try
            {
                DAL.C_PhienLoTrinh.CapNhatThongTinHandHeld(this.txtDanhBo.Text.Replace("-", ""), txtHieu.Text.Substring(0, 3), txtSoThan.Text,"","");
                string loai = "1";
                string sql = "INSERT INTO BAOTHAYDHN (DANHBA, TENKH, SO, DUONG, HIEUMOI, COMOI, NGAYTHAY, CSGAN, SOTHANMOI, VITRIMOI, MACHITHAN, MACHIGOC, LOAI) " +
                " VALUES     ('" + this.txtDanhBo.Text.Replace("-", "") + "', " +
                " '" + hskh.HOTEN + "', " +
                " '" + hskh.SONHA + "' ," +
                " '" + hskh.TENDUONG + "' , " +
                " '" + txtHieu.Text.Substring(0, 3) + "', " +
                " " + hskh.CODH + ", " +
                " '" + dateNgayGan.Value.Date + "', " +            
                " " + txtChiSo.Text + ", " +
                " '" + txtSoThan.Text + "'," +
                " N' ', " +
                " ' '," +
                " ' ', " +
                "  " + loai + ")";
                if (DAL.C_PhienLoTrinh.InsertBaoThayHandHeld(sql) == 0)
                {

                    sql = "UPDATE  BAOTHAYDHN  " +
                    " SET  " +
                    " TENKH='" + hskh.HOTEN + "', " +
                    " SO='" + hskh.SONHA + "' ," +
                    " DUONG='" + hskh.TENDUONG + "' , " +
                    " HIEUMOI='" + txtHieu.Text.Substring(0, 3) + "', " +
                    " COMOI=" + hskh.CODH + ", " +
                    " NGAYTHAY='" + dateNgayGan.Value.Date + "', " +
                    " CSGAN=" + txtChiSo.Text + ", " +                 
                    " LOAI=" + loai + " " +
                    " WHERE DANHBA='" + this.txtDanhBo.Text.Replace("-", "") + "' AND CONVERT(DATETIME,NGAYTHAY,103)='" + dateNgayGan.Value.ToShortDateString() + "'";
                    DAL.C_PhienLoTrinh.InsertBaoThayHandHeld(sql);
                }
            }
            catch (Exception ex)
            {
                log.Error("Cap Nhat Du Lieu Cho HandHeld : " + ex.Message);
            }
            //// END
        }
        
        private void btHoanTat_Click(object sender, EventArgs e)
        {
            //updateDulieu();
            string shs = this.txtSHS.Text;
            KH_HOSOKHACHHANG hskh = DAL.C_HoanCongDHN_DotTCTB.findByHoSoHC(shs);
            if (hskh != null) {
                if (this.checkTroNgai.Checked)
                {
                    hskh.TRONGAI = true;
                    hskh.NOIDUNGTN = this.txtNoiDungTroNgai.Text;
                }
                else {
                    try
                    {
                        hskh.COTLK = int.Parse(this.txtCoTLK.Text);
                    }
                    catch (Exception)
                    { }
                    if (!"1/1/0001".Equals(this.dateNgayGan.Value.ToShortDateString()))
                    {
                        hskh.NGAYTHICONG = dateNgayGan.Value.Date;
                    }
                    try
                    {
                        hskh.CHISO = int.Parse(this.txtChiSo.Text);
                    }
                    catch (Exception)
                    { }
                    hskh.HOANCONG = true;
                    hskh.SOTHANTLK = this.txtSoThan.Text;
                    hskh.HIEUDONGHO = this.txtHieu.Text;
                    hskh.TCTB_TONGGIATRI = ParseDouble(this.txtTongGiaTri.Text);
                    hskh.TCTB_CPNHANCONG = ParseDouble(this.txtNhanCong.Text);
                    hskh.TCTB_CPVATTU = ParseDouble(this.txtVatTu.Text);

                    hskh.ONG20 = ParseDouble(this.txtO20.Text);
                    //  hskh.ONG25 = this.txtO25.Text;
                    hskh.ONG50 = ParseDouble(this.txtO50.Text);
                    hskh.ONG100 = ParseDouble(this.txtO100.Text);
                    hskh.ONGKHAC = ParseDouble(this.txtOK.Text);
                    hskh.TRONGAI = false;
                    hskh.NOIDUNGTN = "";
                }

                if (DAL.C_HoanCongDHN_DotTCTB.Update() == true)
                {
                    try
                    {
                        if (this.cbDotTC.Text.Contains("BT"))
                        {
                            TB_DULIEUKHACHHANG kh = DULIEUKH.C_DuLieuKhachHang.finByDanhBo(txtDanhBo.Text.Replace(" ", "").Replace("-", ""));
                            if (kh != null)
                            {
                                kh.NGAYTHAY = hskh.NGAYTHICONG;
                                kh.NGAYKIEMDINH = hskh.DHN_NGAYKIEMDINH;
                                kh.CODH = this.txtCoTLK.Text;
                                kh.HIEUDH = hskh.HIEUDONGHO;
                                kh.SOTHANDH = hskh.SOTHANTLK;
                                kh.CHISOKYTRUOC = hskh.CHISO + "";
                                DULIEUKH.C_DuLieuKhachHang.Update();

                                try
                                {
                                    CapNhatHandHeld(kh);
                                }
                                catch (Exception)
                                {

                                }
                            }


                        }
                  }
                    catch (Exception ex)
                    {
                        log.Error(ex.Message);
                    }
                    
               //     MessageBox.Show(this, "Cập Nhật Hoàn Công  Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    hoantat();
                }

                else {
                    MessageBox.Show(this, "Cập Nhật Hoàn Công Không Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            ReportDocument rp = new rpt_HoanCongTCTB();
            if (this.cbDotTC.Text.Contains("BT"))
            {
                rp = new rpt_HoanCongTCTB();
            }
            else if (this.cbDotTC.Text.Contains("D"))
            {
                rp = new rpt_HoanCongTCTB_DD();

            } else {
                rp = new rpt_HoanCongTCTB_GM();
            }

                rp.SetDataSource(DAL.C_HoanCongDHN_DotTCTB.BC_HOANCONG_TCTB(this.cbDotTC.Text));
                string tlkgom = "Gồm TLK ";
                DataTable table = DAL.LinQConnection.getDataTable("select COTLK, COUNT(*)  from KH_HOSOKHACHHANG WHERE MADOTTC='" + this.cbDotTC.Text.Replace(" ", "") + "' group by COTLK");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    tlkgom += table.Rows[i][0].ToString()+" ly   : " + table.Rows[i][1].ToString()+"Cái. ";
                }
                rp.SetParameterValue("tlkgom", tlkgom);
                rpt_Main rpt = new rpt_Main(rp);
                rpt.ShowDialog();
          

        }
        public void TongKetGanNhua() {
            TCTB_TONGKEVATTU tkvt = DAL.C_HoanCongDHN_DotTCTB.findTongKetVTHC(this.cbDotTC.Text.Replace(" ", ""));
            if (tkvt != null)
            {
                this.TKtxtVatTuNhua.Text = tkvt.VATUNHUA + "";
                this.TKtxtVatTuGan.Text = tkvt.VATUGAN + "";
                this.TKtxtTongKetVT.Text = DAL.C_HoanCongDHN_DotTCTB.getTongCPVatTu(this.cbDotTC.Text.Replace(" ", "")).ToString();
            }
            else {
                this.TKtxtTongKetVT.Text = DAL.C_HoanCongDHN_DotTCTB.getTongCPVatTu(this.cbDotTC.Text.Replace(" ", "")).ToString();
                this.TKtxtVatTuGan.Text = "0";
                TKtxtVatTuNhua.Text = DAL.C_HoanCongDHN_DotTCTB.getTongCPVatTu(this.cbDotTC.Text.Replace(" ", "")).ToString();
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

        private void btTachChiPhi_Click_1(object sender, EventArgs e)
        {
            TCTB_TONGKEVATTU tkvt = DAL.C_HoanCongDHN_DotTCTB.findTongKetVTHC(this.cbDotTC.Text.Replace(" ", ""));
            if (tkvt != null) {
                tkvt.VATUGAN = ParseDouble(TKtxtVatTuGan.Text);
                tkvt.VATUNHUA = ParseDouble(TKtxtVatTuNhua.Text);
                if (DAL.C_HoanCongDHN_DotTCTB.Update() == false)
                    MessageBox.Show(this, "Cập Nhật Chi Phí Gan Nhựa Không Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(this, "Cập Nhật Chi Phí Gan Nhựa Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
            } else {
                tkvt = new TCTB_TONGKEVATTU();
                tkvt.MADOTTC = this.cbDotTC.Text.Replace(" ", "");
                tkvt.VATUGAN =ParseDouble(TKtxtVatTuGan.Text);
                tkvt.VATUNHUA = ParseDouble(TKtxtVatTuNhua.Text);
                if (DAL.C_HoanCongDHN_DotTCTB.Insert(tkvt) == false)
                    MessageBox.Show(this, "Cập Nhật Hoàn Công Không Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(this, "Cập Nhật Chi Phí Gan Nhựa Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void TKtxtVatTuGan_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TKtxtVatTuNhua_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtO100_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbDotTC_Leave(object sender, EventArgs e)
        {
            try
            {
                hoantat();
            }
            catch (Exception)
            {

            }
        }

        private void TKtxtVatTuGan_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                try
                {
                    double kq = int.Parse(this.TKtxtVatTuGan.Text);
                    double s1 = int.Parse(this.TKtxtVatTuNhua.Text);
                    this.TKtxtTongKetVT.Text = (kq + s1) + "";
                }
                catch (Exception)
                {

                }
            }
           
        }

        private void TKtxtVatTuNhua_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    double kq = int.Parse(this.TKtxtVatTuGan.Text);
                    double s1 = int.Parse(this.TKtxtVatTuNhua.Text);
                    this.TKtxtTongKetVT.Text = (kq + s1) + "";
                }
                catch (Exception)
                {

                }
            }
           
        }
    }
}