using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using DevComponents.DotNetBar.Controls;
namespace TanHoaWater.Utilities
{
    public class DataGridV
    {
        public static void formatRows(DataGridView dview) {
            for (int i = 0; i < dview.Rows.Count; i++) {
                if (i % 2 == 0)
                {
                    dview.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(199)))), ((int)(((byte)(147))))); ;
                     
                }
                else {
                    dview.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
            }
        }
        public static string sohoso(string _sohoso) {
            _sohoso = _sohoso.Insert(4, ".");
            _sohoso = _sohoso.Insert(9, ".");
            return _sohoso;
        }
        public static void formatSoHoSo(DataGridView dview) {
            for (int i = 0; i < dview.Rows.Count; i++)
            {
                dview.Rows[i].Cells["G_SOHOSO"].Value = sohoso(dview.Rows[i].Cells["G_SOHOSO"].Value + ""); ;
            }
        }
        public static void formatSoHoSo(DataGridViewX dview)
        {
            for (int i = 0; i < dview.Rows.Count; i++)
            {
                dview.Rows[i].Cells["G_SOHOSO"].Value = sohoso(dview.Rows[i].Cells["G_SOHOSO"].Value + ""); ;
            }
        }
        
    }
}
