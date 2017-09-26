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

        public string export()
        {
            ExcelCOM.Application exApp = new ExcelCOM.Application();
            string workbookPath = AppDomain.CurrentDomain.BaseDirectory + @"\XINPHEPDAODUONGTP.xls";
            ExcelCOM.Workbook exBook = exApp.Workbooks.Open(workbookPath,
        0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
        true, false, 0, true, false, false);
            ExcelCOM.Worksheet exSheet = (ExcelCOM.Worksheet)exBook.Worksheets[1];


            exSheet.Name = "TAN HOA - XIN PHEP DAO DUONG";
            exSheet.Cells[4, 12] = "TP.Hồ Chí Minh, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            exSheet.Cells[6, 7] = "Danh sách đào đường đợt : " + _dotdd.ToUpper() + "-QTP/CNTH";
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

                exSheet.Cells[rows, 2] = donkh.DUONG + ", P." + DAL.C_Phuong.finbyPhuong(donkh.QUAN, donkh.PHUONG).TENPHUONG;//PHUON

                List<KH_BAOCAOPHUIDAO> listPhui = DAL.C_KH_XinPhepDD.getListBCPhuiDao(donkh.SHS);
                bool inde = true;
                foreach (KH_BAOCAOPHUIDAO item in listPhui)
                {
                    if ("LỀ".Contains(item.TENKETCAU))
                        exSheet.Cells[rows, 4] = item.KICHTHUOC;
                    else
                        exSheet.Cells[rows, 3] = item.KICHTHUOC;


                    exSheet.Cells[rows, 5] = item.TENKETCAU;//TENKETCAU

                }

                rows++;

            }

            string file = _dotdd+".QTP.xls";
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


            exBook.Close(false, false, false);
            exApp.Visible = false;
            //string path = "C:\\ThayDoiPhienLoTrinh." + ky + "." + nam + ".xls";
            //exBook.SaveAs(path.Replace("\\\\", "\\"), ExcelCOM.XlFileFormat.xlWorkbookNormal,
            //    null, null, false, false,
            //    ExcelCOM.XlSaveAsAccessMode.xlExclusive,
            //    false, false, false, false, false);
            //exBook.Close(false, false, false);
            //exApp.Quit();
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);
            return path;
        }


        private void btExport_Click(object sender, EventArgs e)
        {
            export();
        }
        public void FileCu()
        {
            string workbookPath = AppDomain.CurrentDomain.BaseDirectory + @"XINPHEPDAODUONGTP.xls"; //"Utilities.Files.fileTemplate";
            try
            {
                //   string[] arrFile = Utilities.Files.getFileOnServer();//get file onserver
                //string filePath = AppDomain.CurrentDomain.BaseDirectory + @"XINPHEPDAODUONG.xls";
                if (!File.Exists(workbookPath))
                {
                    System.Windows.Forms.MessageBox.Show("Không tìm thấy tập tin.");
                    return;
                }


                ExcelCOM.Application exApp = new ExcelCOM.Application();

                ExcelCOM.Workbook exBook = exApp.Workbooks.Open(workbookPath,
            0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
            true, false, 0, true, false, false);
                ExcelCOM.Worksheet exSheet = (ExcelCOM.Worksheet)exBook.Worksheets[1];

                exSheet.Name = "TAN HOA - XIN PHEP DAO DUONG";
                exSheet.Cells[4, 12] = "TP.Hồ Chí Minh, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                exSheet.Cells[6, 7] = "Danh sách đào đường đợt : " + _dotdd.ToUpper() + "-QTP/CNTH";
                List<KH_HOSOKHACHHANG> list = DAL.C_KH_XinPhepDD.ListHSKHByDotTC(_dotdd + "-QTP");

                exSheet.Cells[11, 2] = "CTY CP CẤP NƯỚC TÂN HÒA";
                exSheet.Cells[11, 3] = this.SOCONGVAN.Text;
                exSheet.Cells[11, 4] = Utilities.DateToString.NgayVN(NGAYCONGVAN);
                int rows = 11;

                string mucdichdao = "";
                string phuongphapdao = "";
                string dvtl = "";

                for (int i = 0; i < list.Count; i++)
                {

                    if (rows > 11)
                    {
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
                    if (rdSoHoSo.Checked)
                    {
                        tenfile = donkh.SHS;
                    } if (radioDuong.Checked)
                    {
                        tenfile = donkh.SONHA.Replace("/", "-") + " " + donkh.DUONG.Replace("/", "-");
                    }

                    //Utilities.Files.CopyFile(arrFile, donkh.SHS, _dotdd.Replace("/", "_"), tenfile);

                    exSheet.Cells[rows, 12] = Utilities.Files.FileName;
                    exSheet.Cells[rows, 13] = Utilities.Files.createFile;


                    if (hskh.MUCDICHDD == null)
                    {
                        exSheet.Cells[rows, 15] = "\"";// MUC DICH DAO
                    }
                    else
                    {
                        exSheet.Cells[rows, 15] = hskh.MUCDICHDD;// MUC DICH DAO
                        mucdichdao = hskh.MUCDICHDD;
                    }

                    if (hskh.PHUONGPHAPDD == null)
                    {
                        exSheet.Cells[rows, 16] = "\""; // PHUONG PHAP DAO
                    }
                    else
                    {
                        exSheet.Cells[rows, 16] = hskh.PHUONGPHAPDD; // PHUONG PHAP DAO
                        phuongphapdao = hskh.PHUONGPHAPDD;
                    }

                    if ("Hẻm".Equals(donkh.LOAIMIENPHI))
                    {
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
                    else
                    {
                        exSheet.Cells[rows, 17] = "22g00";// DAO TU GIO
                        exSheet.Cells[rows, 18] = "5g00";// DAO DIEN GIO
                        exSheet.Cells[rows, 22] = "22g00";// TU TAI LAP
                        exSheet.Cells[rows, 23] = "5g00";// DEN TAI LAP
                    }

                    exSheet.Cells[rows, 19] = ""; // DAO TU NGAY
                    exSheet.Cells[rows, 20] = "";// DAO DEN NGAY

                    if (hskh.DVITAILAPDD == null)
                    {
                        exSheet.Cells[rows, 21] = "\""; // PHUONG PHAP DAO
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
                string path = "D:\\XINPHEPDAODUONGTP.xls";
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
                MessageBox.Show(this, "Xuất File Lỗi. ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}