using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelCOM = Microsoft.Office.Interop.Excel;
using TanHoaWater.Database;
using System.IO;
using System.Text.RegularExpressions;
using aejw.Network;
using log4net;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms.VisualStyles;

namespace TanHoaWater.View.Users.KEHOACH.XINPHEPDD
{
    public partial class frm_Export : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_Export).Name);
        string _dotdd = "";
        public frm_Export(string dotdd)
        {
            InitializeComponent();
            _dotdd = dotdd;
            this.lbDotdd.Text = "ĐỢT ĐÀO ĐƯỜNG " + dotdd;
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            try
            {
                string[] arrFile = Utilities.Files.getFileOnServer();//get file onserver

            ExcelCOM.Application exApp = new ExcelCOM.Application();
            string workbookPath = Utilities.Files.fileTemplate;
            ExcelCOM.Workbook exBook = exApp.Workbooks.Open(workbookPath,
        0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
        true, false, 0, true, false, false);
            ExcelCOM.Worksheet exSheet = (ExcelCOM.Worksheet)exBook.Worksheets[1];

            exSheet.Name = "TAN HOA - XIN PHEP DAO DUONG";
            exSheet.Cells[4, 12] = "TP.Hồ Chí Minh, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            exSheet.Cells[6, 7] = "Danh sách đào đường đợt : " + _dotdd.ToUpper() + "-QTP/CNTH";
            List<KH_HOSOKHACHHANG> list = DAL.C_KH_XinPhepDD.ListHSKHByDotTC(_dotdd);

            exSheet.Cells[11, 2] = "CTY TNHH MTV CẤP NƯỚC TÂN HÒA";
            exSheet.Cells[11, 3] = this.SOCONGVAN.Text;
            exSheet.Cells[11, 4] = Utilities.DateToString.NgayVN(NGAYCONGVAN);
            int rows = 11;

            string mucdichdao = "";
            string phuongphapdao = "";
            string dvtl = "";

            for (int i = 0; i < list.Count; i++)
            {
                
                if (rows > 11) {
                    exSheet.Cells[rows, 2] = "\"";
                    exSheet.Cells[rows, 3] = "\"";
                    exSheet.Cells[rows, 4] = "\"";
                }
                KH_HOSOKHACHHANG hskh = list[i];
                exSheet.Cells[rows, 1] = i + 1;
                DON_KHACHHANG donkh = DAL.C_DonKhachHang.findBySHS(hskh.SHS);
                if (donkh.SOHO > 1)
                {
                    exSheet.Cells[rows, 5] = donkh.SONHA + "(ĐD " + donkh.SOHO + " Hộ)";//NHA
                }
                else
                {
                    exSheet.Cells[rows, 5] = donkh.SONHA;//NHA
                }
                if (i == 0)
                {
                    exSheet.Cells[rows, 14] = "CN TÂN HÒA";
                }
                else
                {
                    exSheet.Cells[rows, 14] = "\"";
                }
                exSheet.Cells[rows, 6] = donkh.DUONG;//DUONG
                exSheet.Cells[rows, 7] = DAL.C_Phuong.finbyPhuong(donkh.QUAN, donkh.PHUONG).TENPHUONG;//PHUONG
                ///copy bang ve  
                string tenfile = donkh.SHS;
                if (rdSoHoSo.Checked) {
                    tenfile = donkh.SHS;
                } if (radioDuong.Checked) {
                    tenfile = hskh.DHN_SONHA.Replace("/", "-") + " " + hskh.DHN_DIACHI.Replace("/", "-");
                }
                Utilities.Files.CopyFile(arrFile, donkh.SHS, _dotdd.Replace("/", "_"), tenfile);
                exSheet.Cells[rows, 12] = Utilities.Files.FileName;
                exSheet.Cells[rows, 13] = Utilities.Files.createFile;


                if (mucdichdao.Equals(hskh.MUCDICHDD))
                {
                    exSheet.Cells[rows, 15] =  "\"";// MUC DICH DAO
                }
                else
                {
                    exSheet.Cells[rows, 15] = hskh.MUCDICHDD;// MUC DICH DAO
                    mucdichdao = hskh.MUCDICHDD;
                }

                if (phuongphapdao.Equals(hskh.PHUONGPHAPDD))
                {
                    exSheet.Cells[rows, 16] =  "\""; // PHUONG PHAP DAO
                }
                else
                {
                    exSheet.Cells[rows, 16] = hskh.PHUONGPHAPDD; // PHUONG PHAP DAO
                    phuongphapdao = hskh.PHUONGPHAPDD;
                }

                if ("Hẻm".Equals(donkh.LOAIMIENPHI)) {
                    exSheet.Cells[rows, 17] = "6g00";// DAO TU GIO
                    exSheet.Cells[rows, 18] = "21g00";// DAO DIEN GIO
                    exSheet.Cells[rows, 22] = "6g00";// TU TAI LAP
                    exSheet.Cells[rows, 23] = "21g00";// DEN TAI LAP
                }
                else if ("Mặt tiền".Equals(donkh.LOAIMIENPHI))
                {
                    exSheet.Cells[rows, 17] = "22g00";// DAO TU GIO
                    exSheet.Cells[rows, 18] = "5g00";// DAO DIEN GIO
                    exSheet.Cells[rows, 22] = "22g00";// TU TAI LAP
                    exSheet.Cells[rows, 23] = "5g00";// DEN TAI LAP
                }
                else {
                    exSheet.Cells[rows, 17] = "22g00";// DAO TU GIO
                    exSheet.Cells[rows, 18] = "5g00";// DAO DIEN GIO
                    exSheet.Cells[rows, 22] = "22g00";// TU TAI LAP
                    exSheet.Cells[rows, 23] = "5g00";// DEN TAI LAP
                }
              
                exSheet.Cells[rows, 19] = ""; // DAO TU NGAY
                exSheet.Cells[rows, 20] = "";// DAO DEN NGAY

                if (dvtl.Equals(hskh.DVITAILAPDD))
                {
                    exSheet.Cells[rows, 21] =  "\""; // PHUONG PHAP DAO
                }
                else
                {
                    exSheet.Cells[rows, 21] = hskh.DVITAILAPDD;// DON VI TAI LAP
                    dvtl = hskh.DVITAILAPDD;
                }



               
                List<KH_BAOCAOPHUIDAO> listPhui = DAL.C_KH_XinPhepDD.getListBCPhuiDao(donkh.SHS);
                bool inde = true;
                foreach (KH_BAOCAOPHUIDAO item in listPhui)
                {
                    exSheet.Cells[rows, 8] = item.DAI;// DAI
                    exSheet.Cells[rows, 9] = item.RONG;//RONG
                    exSheet.Cells[rows, 10] = item.SAU;//SAU
                    exSheet.Cells[rows, 11] = item.TENKETCAU;//TENKETCAU
                    rows++;
                    inde = false;
                }
                if (inde)
                {
                    rows++;
                }
            }
            ExcelCOM.Range tR;
            tR = exSheet.get_Range("X11", "X" + (rows - 1));
            tR.VerticalAlignment = ExcelCOM.XlVAlign.xlVAlignCenter;
            tR.ShrinkToFit = false;
            tR.MergeCells = true;
            tR.Value2 = "Sau khi thi công xong(chậm nhất là 48 giờ tính từ khi bắt đầu khởi công)";
            

            exApp.Visible = false;
            string path = Utilities.Files.localSave + "\\209/2011".Replace("/", "_") + "\\BANGXINPHEPDD.xls";
            exBook.SaveAs(path.Replace("\\\\", "\\"), ExcelCOM.XlFileFormat.xlWorkbookNormal,
                null, null, false, false,
                ExcelCOM.XlSaveAsAccessMode.xlExclusive,
                false, false, false, false, false);
            exBook.Close(false, false, false);
            exApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);

            result.Text = "Đường dẫn lưu file : " + path;
            }
            catch (Exception ex)
            {
                log.Error("Export File Loi" + ex.Message);
            }

        }
 
    }
}
