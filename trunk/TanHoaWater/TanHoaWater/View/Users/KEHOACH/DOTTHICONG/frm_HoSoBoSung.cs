using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TanHoaWater.View.Users.KEHOACH.DOTTHICONG
{
    public partial class frm_HoSoBoSung : Form
    {
        public frm_HoSoBoSung(string madot)
        {
            InitializeComponent();

            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(new tab_CapNhatDanhSachBoSung(madot));
        }
    }
}
