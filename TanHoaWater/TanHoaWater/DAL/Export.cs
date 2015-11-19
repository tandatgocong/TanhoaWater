using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using ExcelCOM = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Text.RegularExpressions;
using aejw.Network;
using log4net;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms.VisualStyles;

namespace TanHoaWater.DAL
{
    class Export
    {
        public static string export(DataGridView dataGridView1)
        {
            ExcelCOM.Application exApp = new ExcelCOM.Application();
            string workbookPath = AppDomain.CurrentDomain.BaseDirectory + @"\DSKHACHHANG.xls";
            ExcelCOM.Workbook exBook = exApp.Workbooks.Open(workbookPath,
        0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
        true, false, 0, true, false, false);
            ExcelCOM.Worksheet exSheet = (ExcelCOM.Worksheet)exBook.Worksheets[1];

            //exSheet.Name = ky + "." + nam;
            //exSheet.Cells[4, 5] = "TP.Hồ Chí Minh, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            //exSheet.Cells[5, 1] = "BẢNG KÊ TỔNG HỢP DANH SÁCH KHÁCH HÀNG THAY ĐỒNG HỒ NƯỚC ĐỊNH KỲ QUÝ "+quy;
            int rows = 10;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string STT = (i + 1)+"";
                string G_TENKH = dataGridView1.Rows[i].Cells["c_HOTEN"].Value + "";
                string G_DIACHI = dataGridView1.Rows[i].Cells["c_DIACHI"].Value + "";
                string g_DOT = dataGridView1.Rows[i].Cells["C_MADOTTC"].Value + "";
                string G_DANHBO = dataGridView1.Rows[i].Cells["C_SODANHBO"].Value + "";
                string G_DONGHO = dataGridView1.Rows[i].Cells["C_HIEU"].Value + "-" + dataGridView1.Rows[i].Cells["C_CO"].Value + " Ly";
                string g_BB =g_DOT+"/" +dataGridView1.Rows[i].Cells["C_STT"].Value + "";
                string G_NGAYTHICONG = dataGridView1.Rows[i].Cells["G_NGAYTHICONG"].Value + "";
                            
                
                exSheet.Cells[rows, 2] = STT;
                exSheet.Cells[rows, 3] = G_TENKH;
                exSheet.Cells[rows, 4] = G_DIACHI;
                exSheet.Cells[rows, 5] = g_DOT;
                exSheet.Cells[rows, 6] = G_DANHBO;
                exSheet.Cells[rows, 7] = G_DONGHO;                
                exSheet.Cells[rows, 8] = g_BB;
                exSheet.Cells[rows, 9] = G_NGAYTHICONG;

                rows++;

            }

            string file = "DANH SÁCH KHÁCH HÀNG GẮN MỚI ĐỒNG HỒ NƯỚC ";
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

    }
}

