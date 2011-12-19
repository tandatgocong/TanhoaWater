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
namespace TanHoaWater
{
    public partial class tab_XinPhepDD24 : UserControl
    {
        public tab_XinPhepDD24()
        {
            InitializeComponent();
             
            //this.NHA.Text = Utilities.Files.createFile;
            //checkFile("");
        }
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_XinPhepDD24).Name);
        public bool checkFile(string shs)
        {

            string line;
            string[] words = null;
            try
            {
                StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\app.conf");
                while ((line = sr.ReadLine()) != null)
                {
                    words = Regex.Split(line, ",");
                }
            }
            catch (Exception)
            {
            }
            if (words != null)
            {
                string LocalDirver = words[0];
                string pathShare = words[1];
                string UserName = words[2];
                string Password = words[3];
                string fileTemplate = words[4];
                string localSave = words[5];
                NetworkDrive oNetDrive = new aejw.Network.NetworkDrive();
                try
                {
                    oNetDrive.LocalDrive = LocalDirver;
                    oNetDrive.ShareName = pathShare;
                    oNetDrive.MapDrive(UserName, Password);
                    
                }
                catch (Exception err)
                {
                    
                }
                oNetDrive = null;
                string[] arrFile = Directory.GetFiles(@"M:\");

                foreach (string fileName in arrFile)
                {
                    MessageBox.Show(this, fileName);
                    //listBox1.Items.Add(fileName.Substring(fileName.LastIndexOf('\\') + 1));
                }
            }

            return false;
        }
        
        private void bnExportExl_Click(object sender, EventArgs e)
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
            exSheet.Cells[6, 7] = "Danh sách đào đường đợt : " + this.txtDotDD.Text.ToUpper() + "-QTP/CNTH";
            List<KH_HOSOKHACHHANG> list = DAL.C_KH_XinPhepDD.ListHSKHByDotTC("209/2011");
           
            exSheet.Cells[11, 2] = "CTY TNHH MTV CẤP NƯỚC TÂN HÒA";
            exSheet.Cells[11, 3] = this.SOCONGVAN.Text;
            exSheet.Cells[11, 4] = Utilities.DateToString.NgayVN(NGAYCONGVAN);
            int rows = 11;

            string mucdichdao = "";
            string phuongphapdao = "";
            string dvtl = "";
            
            for (int i = 0; i < list.Count; i++) {

                KH_HOSOKHACHHANG hskh = list[i];
                exSheet.Cells[rows, 1] = i + 1;
                DON_KHACHHANG donkh = DAL.C_DonKhachHang.findBySHS(hskh.SHS);
                if (donkh.SOHO > 1)
                {
                    exSheet.Cells[rows, 5] = donkh.SONHA + "(ĐD " + donkh.SOHO + " Hộ)";//NHA
                }
                else {
                    exSheet.Cells[rows, 5] = donkh.SONHA;//NHA
                }
                if (i == 0)
                {
                    exSheet.Cells[rows, 14] = "CN TÂN HÒA";
                }
                else {
                    exSheet.Cells[rows, 14] = "--nt--";
                }
                exSheet.Cells[rows, 6] = donkh.DUONG;//DUONG
                exSheet.Cells[rows, 7] = DAL.C_Phuong.finbyPhuong(donkh.QUAN,donkh.PHUONG).TENPHUONG;//PHUONG
               ///copy bang ve  
                Utilities.Files.CopyFile(arrFile, donkh.SHS, "209/2011".Replace("/", "_"), donkh.SHS);
                exSheet.Cells[rows, 12] = donkh.SHS + ".dwg";
                exSheet.Cells[rows, 13] = Utilities.Files.createFile;
               

                if (mucdichdao.Equals(hskh.MUCDICHDD)) {
                    exSheet.Cells[rows, 15] = "--nt--";// MUC DICH DAO
                }
                else
                {
                    exSheet.Cells[rows, 15] = hskh.MUCDICHDD;// MUC DICH DAO
                    mucdichdao = hskh.MUCDICHDD;
                }

                if (phuongphapdao.Equals(hskh.PHUONGPHAPDD))
                {
                    exSheet.Cells[rows, 16] = "--nt--"; // PHUONG PHAP DAO
                }
                else
                {
                    exSheet.Cells[rows, 16] = hskh.PHUONGPHAPDD; // PHUONG PHAP DAO
                    phuongphapdao = hskh.PHUONGPHAPDD;
                }
               
                exSheet.Cells[rows, 17] = "6g";// DAO TU GIO
                exSheet.Cells[rows, 18] = "21g";// DAO DIEN GIO
                exSheet.Cells[rows, 19] = ""; // DAO TU NGAY
                exSheet.Cells[rows, 20] = "";// DAO DEN NGAY

                if (dvtl.Equals(hskh.DVITAILAPDD))
                {
                    exSheet.Cells[rows, 21] = "--nt--"; // PHUONG PHAP DAO
                }
                else
                {
                    exSheet.Cells[rows, 21] = hskh.DVITAILAPDD;// DON VI TAI LAP
                    dvtl = hskh.DVITAILAPDD;
                }
               

               
                exSheet.Cells[rows, 22] = "6g";// TU TAI LAP
                exSheet.Cells[rows, 23] = "21g";// DEN TAI LAP
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
                if (inde) {
                    rows++;
                }
            }
            ExcelCOM.Range tR;
            tR = exSheet.get_Range("X11", "X" + (rows - 1));
            tR.VerticalAlignment = ExcelCOM.XlVAlign.xlVAlignCenter;
            tR.ShrinkToFit = false;
            tR.MergeCells = true;
            tR.Value2 = "Sau khi thi công xong(chậm nhất là 48 giờ tính từ khi bắt đầu khởi công)";
            tR.BorderAround(ExcelCOM.XlLineStyle.xlContinuous, ExcelCOM.XlBorderWeight.xlThin, ExcelCOM.XlColorIndex.xlColorIndexAutomatic, 0);
            exApp.Visible = false;
            string path =Utilities.Files.localSave+ "\\209/2011".Replace("/", "_")+"\\BANGXINPHEPDD.xls";
            exBook.SaveAs(path.Replace("\\\\","\\"), ExcelCOM.XlFileFormat.xlWorkbookNormal,
                null, null, false, false,
                ExcelCOM.XlSaveAsAccessMode.xlExclusive,
                false, false, false, false, false);
            exBook.Close(false, false, false);
            exApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);

            MessageBox.Show("Đã export ra file " + workbookPath);
        }

        private void SOHOSO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                DON_KHACHHANG donkh = DAL.C_DonKhachHang.findBySHS(this.SOHOSO.Text);
                if (donkh != null) {
                    NHA.Text = donkh.SONHA;
                    DUONG.Text = donkh.DUONG;
                    PHUONG.Text = DAL.C_Phuong.finbyPhuong(donkh.QUAN, donkh.PHUONG).TENPHUONG;

                    GRI.DataSource = DAL.C_BG_KichThuocPhuiDao.getListBySHS(donkh.SHS);
                }
            }
        }
    }
}
