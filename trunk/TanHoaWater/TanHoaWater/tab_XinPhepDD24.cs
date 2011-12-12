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
namespace TanHoaWater
{
    public partial class tab_XinPhepDD24 : UserControl
    {
        public tab_XinPhepDD24()
        {
            InitializeComponent();
        }

        private void bnExportExl_Click(object sender, EventArgs e)
        {
            ExcelCOM.Application exApp = new ExcelCOM.Application();
            string workbookPath = "E:\\XINPHEPDAODUONG.xls";
            ExcelCOM.Workbook exBook = exApp.Workbooks.Open(workbookPath,
        0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
        true, false, 0, true, false, false);
            ExcelCOM.Worksheet exSheet = (ExcelCOM.Worksheet)exBook.Worksheets[1];

            exSheet.Name = "TAN HOA - XIN PHEP DAO DUONG";
            exSheet.Cells[4, 12] = "TP.Hồ Chí Minh, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            exSheet.Cells[6, 7] = "Danh sách đào đường đợt : " + this.txtDotDD.Text.ToUpper() + "-QTP/CNTH";
            exSheet.Cells[11, 1] = 1;
            exSheet.Cells[11, 2] = "CTY TNHH MTV CẤP NƯỚC TÂN HÒA";
            exSheet.Cells[11, 3] = this.SOCONGVAN.Text;
            exSheet.Cells[11, 4] = Utilities.DateToString.NgayVN(NGAYCONGVAN);
            exSheet.Cells[11, 5] = NHA.Text;
            exSheet.Cells[11, 6] = DUONG.Text;
            exSheet.Cells[11, 7] = PHUONG.Text;
            int rows=11;
            for (int i = 0; i < GRI.Rows.Count; i++) { 
                if(!"TNHA".Equals(GRI.Rows[i].Cells["MADANHMUC"].Value)){
                    
                    exSheet.Cells[rows, 8]=GRI.Rows[i].Cells["DAI"].Value;
                    exSheet.Cells[rows, 9]=GRI.Rows[i].Cells["RONG"].Value;
                    exSheet.Cells[rows, 10]=GRI.Rows[i].Cells["DOSAU"].Value;
                    exSheet.Cells[rows, 11]=GRI.Rows[i].Cells["TENKETCAU"].Value;
                    rows++;
                }
              
            }
            rows = rows - 1;
            exSheet.Cells[11, 12] = BANGVE.Text;
            exSheet.Cells[11, 13] = Utilities.DateToString.NgayVN(NGAYVE);
            exSheet.Cells[11, 14] = DONVILAP.Text;
            exSheet.Cells[11, 15] = MUCDICHDAO.Text;
            exSheet.Cells[11, 16] = PHUONGPHAPDAO.Text;
            exSheet.Cells[11, 17] = this.DAOTUGIO.Text;
            exSheet.Cells[11, 18] = DAODENGIO.Text;
            exSheet.Cells[11, 19] = Utilities.DateToString.NgayVN(TUNGAYDAO);
            exSheet.Cells[11, 20] = Utilities.DateToString.NgayVN(DENNGAYDAO);
            exSheet.Cells[11, 21] = DONVILAP.Text;
            exSheet.Cells[11, 22] = TUTAILAP.Text;
            exSheet.Cells[11, 23] = DENTAILAP.Text;

            /////////
            
            exSheet.Cells[rows, 1] = 2;
            exSheet.Cells[rows, 2] = "CTY TNHH MTV CẤP NƯỚC TÂN HÒA";
            exSheet.Cells[rows, 3] = this.SOCONGVAN.Text;
            exSheet.Cells[rows, 4] = Utilities.DateToString.NgayVN(NGAYCONGVAN);
            exSheet.Cells[rows, 5] = NHA.Text;
            exSheet.Cells[rows, 6] = DUONG.Text;
            exSheet.Cells[rows, 7] = PHUONG.Text;
            int flag = rows;
            for (int i = 0; i < GRI.Rows.Count; i++)
            {
                if (!"TNHA".Equals(GRI.Rows[i].Cells["MADANHMUC"].Value))
                {
                    
                    exSheet.Cells[flag, 8] = GRI.Rows[i].Cells["DAI"].Value;
                    exSheet.Cells[flag, 9] = GRI.Rows[i].Cells["RONG"].Value;
                    exSheet.Cells[flag, 10] = GRI.Rows[i].Cells["DOSAU"].Value;
                    exSheet.Cells[flag, 11] = GRI.Rows[i].Cells["TENKETCAU"].Value;
                    flag++;
                }

            }
            exSheet.Cells[rows, 12] = BANGVE.Text;
            exSheet.Cells[rows, 13] = Utilities.DateToString.NgayVN(NGAYVE);
            exSheet.Cells[rows, 14] = DONVILAP.Text;
            exSheet.Cells[rows, 15] = MUCDICHDAO.Text;
            exSheet.Cells[rows, 16] = PHUONGPHAPDAO.Text;
            exSheet.Cells[rows, 17] = this.DAOTUGIO.Text;
            exSheet.Cells[rows, 18] = DAODENGIO.Text;
            exSheet.Cells[rows, 19] = Utilities.DateToString.NgayVN(TUNGAYDAO);
            exSheet.Cells[rows, 20] = Utilities.DateToString.NgayVN(DENNGAYDAO);
            exSheet.Cells[rows, 21] = DONVILAP.Text;
            exSheet.Cells[rows, 22] = TUTAILAP.Text;
            exSheet.Cells[rows, 23] = DENTAILAP.Text;
            

            //string path = "C:\\" + txtFileName.Text;

            exApp.Visible = false;
            exBook.SaveAs("C:\\XINPHEPDAODUONG.xls", ExcelCOM.XlFileFormat.xlWorkbookNormal,
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
