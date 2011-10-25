using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TanHoaWater.View.Users.KEHOACH.XINPHEPDD
{
    public partial class tab_CapNhatTheoDot : UserControl
    {
        public tab_CapNhatTheoDot(string madot)
        {
            InitializeComponent();
            this.cbMaDot.DataSource = DAL.C_KH_XinPhepDD.ListAllXinPhepDD();
            this.cbMaDot.ValueMember = "MADOT";
            this.cbMaDot.DisplayMember = "MADOT";
            cbMaDot.Text = madot;
        }

        private void checkLayBangGia_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLayBangGia.Checked)
            {
                this.GridViewPhuiDao.Visible = true;
            }
            else {
                this.GridViewPhuiDao.Visible = false;
            }
        }

        private void txtMaSHS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { 
            }
        }
    }
}
