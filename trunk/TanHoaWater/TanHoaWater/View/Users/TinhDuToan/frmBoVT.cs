using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TanHoaWater.View.Users.TinhDuToan
{
    public partial class frmBoVT : Form
    {
     
        public frmBoVT()
        {
            InitializeComponent();
            tab_BoVatTuTaoSan bovt = new tab_BoVatTuTaoSan();
            panel1.Controls.Add(bovt);
        }
    }
}
