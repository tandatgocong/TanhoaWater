using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace TanHoaWater.DAL
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
    }
}
