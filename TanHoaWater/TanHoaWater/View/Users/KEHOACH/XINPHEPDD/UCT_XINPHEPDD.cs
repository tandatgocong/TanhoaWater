using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using ExcelCOM = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using log4net;
using TanHoaWater.View.Users.Report;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.KEHOACH.XINPHEPDD.BC;
using TanHoaWater.Database;

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
            string noicapphep = "";
            try
            {
                madot = dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["gridSoDot"].Value + "";
                noicapphep = dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["gridNoiCapPhep"].Value + "";

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
                  
                    if (DAL.C_KH_XinPhepDD.UpdateCoPhep(madot,noicapphep, this.dateNgayCoPhep.Value.Date) == false) {
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
        
        public string export(string _dotdd)
        {
            ExcelCOM.Application exApp = new ExcelCOM.Application();
            string workbookPath = AppDomain.CurrentDomain.BaseDirectory + @"\XINPHEPDAODUONGTP.xls";
            ExcelCOM.Workbook exBook = exApp.Workbooks.Open(workbookPath,
        0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
        true, false, 0, true, false, false);
            ExcelCOM.Worksheet exSheet = (ExcelCOM.Worksheet)exBook.Worksheets[1];


            exSheet.Name = "TAN HOA - XIN PHEP DAO DUONG";
            exSheet.Cells[4, 4] = "TP.Hồ Chí Minh, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            exSheet.Cells[6, 4] = "Danh sách đào đường đợt : " + _dotdd.ToUpper() + "-QTP/CNTH";
            List<KH_HOSOKHACHHANG> list = DAL.C_KH_XinPhepDD.ListHSKHByDotTC(_dotdd + "-QTP");
            int rows = 11;
            for (int i = 0; i < list.Count; i++)
            {

                //if (rows > 11)
                //{
                //    exSheet.Cells[rows, 2] = "\"";
                //    exSheet.Cells[rows, 3] = "\"";
                //    exSheet.Cells[rows, 4] = "\"";
                //}
                KH_HOSOKHACHHANG hskh = list[i];
                exSheet.Cells[rows, 1] = i + 1;
                DON_KHACHHANG donkh = DAL.C_DonKhachHang.findBySHS(hskh.SHS);

                exSheet.Cells[rows, 2] = donkh.SONHA+ " " +  donkh.DUONG + ", P." + DAL.C_Phuong.finbyPhuong(donkh.QUAN, donkh.PHUONG).TENPHUONG;//PHUON

                List<KH_BAOCAOPHUIDAO> listPhui = DAL.C_KH_XinPhepDD.getListBCPhuiDao(donkh.SHS);
                string ketcau = "";
                foreach (KH_BAOCAOPHUIDAO item in listPhui)
                {
                    try
                    {
                        if ("L" == item.TENKETCAU.Substring(0, 1))
                            exSheet.Cells[rows, 4] = item.KICHTHUOC;
                        else
                            exSheet.Cells[rows, 3] = item.KICHTHUOC;

                        ketcau += item.TENKETCAU + " ; ";
                        //TENKETCAU
                    }
                    catch (Exception)
                    {
                        
                        
                    }
                   
                }
                exSheet.Cells[rows, 5] = ketcau;

                rows++;

            }

            string file = _dotdd.Replace(@"/","-") + "-QTP.xls";
            exApp.Visible = false;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save text Files";
            saveFileDialog1.FileName = file;
            saveFileDialog1.DefaultExt = ".xls";
            saveFileDialog1.Filter = "All files (*.*)|*.*";
            string path = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName; ;
                exBook.SaveAs(path, ExcelCOM.XlFileFormat.xlWorkbookNormal,
                    null, null, false, false,
                    ExcelCOM.XlSaveAsAccessMode.xlExclusive,
                    false, false, false, false, false);
            }


            //exBook.Close(false, false, false);
            exBook.Save();
            exBook.Close(true);
            exApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
          
            ////string path = "C:\\ThayDoiPhienLoTrinh." + ky + "." + nam + ".xls";
            ////exBook.SaveAs(path.Replace("\\\\", "\\"), ExcelCOM.XlFileFormat.xlWorkbookNormal,
            ////    null, null, false, false,
            ////    ExcelCOM.XlSaveAsAccessMode.xlExclusive,
            ////    false, false, false, false, false);
            //exBook.Close(false, false, false);
            //exApp.Quit();
            
            MessageBox.Show(this, "Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return path;
        }
        private void btExport_Click(object sender, EventArgs e)
        {
            string madot = "";
            try
            {
                madot = dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["gridSoDot"].Value + "";
                export(madot);
                //if ((dataDanhSachDaoDuong.Rows[dataDanhSachDaoDuong.CurrentRow.Index].Cells["gridMaQuanLy"].Value + "").Contains("QTP"))
                //{
                //frm_Export frm = new frm_Export(madot);
                //frm.ShowDialog();
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
        /*
        private void btnXuatExcelTienDu_Click(object sender, EventArgs e)
        {
            DataTable dt = _cTienDu.GetDSTienDu(dateNgayGiaiTrach.Value);

            //T?o các d?i tu?ng Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            //Microsoft.Office.Interop.Excel.Worksheet oSheetCQ;

            //T?o m?i m?t Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            //khai báo s? lu?ng sheet
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = "Ti?n Du";

            // T?o ph?n d?u n?u mu?n
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "F1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH TI?N DU NGÀY \r\n" + dateNgayGiaiTrach.Value.ToString("dd/MM/yyyy");
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.RowHeight = 50;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // T?o tiêu d? c?t 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Danh B?";
            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "S? Ti?n";
            cl2.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Ngày BK";
            cl3.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "MLT";
            cl4.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "Khách Hàng";
            cl5.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "Ð?a Ch?";
            cl6.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "T?";
            cl7.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "Hành Thu";
            cl8.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");
            cl9.Value2 = "Bank";
            cl9.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J3", "J3");
            cl10.Value2 = "Ði?n Tho?i";
            cl10.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K3", "K3");
            cl11.Value2 = "Lo?i";
            cl11.ColumnWidth = 12;

            // T?o m?ng d?i tu?ng d? luu d? toàn b? d? li?u trong DataTable,
            // vì d? li?u du?c du?c gán vào các Cell trong Excel ph?i thông qua object thu?n.
            object[,] arr = new object[dt.Rows.Count, 11];

            //Chuy?n d? li?u t? DataTable vào m?ng d?i tu?ng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                arr[i, 0] = dr["DanhBo"].ToString();
                arr[i, 1] = dr["SoTien"].ToString();

                TT_BangKe bangke = _cBangKe.Get(dr["DanhBo"].ToString());
                if (bangke != null)
                    arr[i, 2] = bangke.CreateDate.Value.ToString("dd/MM/yyyy");

                HOADON hoadon = _cHoaDon.GetMoiNhat(dr["DanhBo"].ToString());
                if (hoadon != null)
                {
                    arr[i, 3] = hoadon.MALOTRINH;
                    arr[i, 4] = hoadon.TENKH;
                    arr[i, 5] = hoadon.SO + " " + hoadon.DUONG;
                    if (hoadon.MaNV_HanhThu != null)
                    {
                        arr[i, 6] = _cNguoiDung.GetTenToByMaND(hoadon.MaNV_HanhThu.Value);
                        arr[i, 7] = _cNguoiDung.GetHoTenByMaND(hoadon.MaNV_HanhThu.Value);
                    }
                    if (hoadon.GB <= 20)
                        arr[i, 10] = "TG";
                    else
                        arr[i, 10] = "CQ";
                }
                arr[i, 8] = _cBangKe.GetBank(dr["DanhBo"].ToString());
                arr[i, 9] = dr["DienThoai"].ToString();

            }

            //Thi?t l?p vùng di?n d? li?u
            int rowStart = 4;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 11;

            // Ô b?t d?u di?n d? li?u
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô k?t thúc di?n d? li?u
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // L?y v? vùng di?n d? li?u
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
            Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            c3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
            Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
            Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            c3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            c3b.NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            c3c.NumberFormat = "@";
            c3c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //Ði?n d? li?u vào vùng dã thi?t l?p
            range.Value2 = arr;

            oSheet.Cells[rowEnd + 1, 2] = dt.Compute("sum(SoTien)", "");
            Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, 2];
            Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, 2];
            oSheet.get_Range(c1d, c2d).NumberFormat = "#,##0";
        }
        */
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
