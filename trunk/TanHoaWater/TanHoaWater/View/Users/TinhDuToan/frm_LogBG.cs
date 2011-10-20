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
    public partial class frm_LogBG : Form
    {
        public frm_LogBG(string _shs)
        {
            InitializeComponent();
            this.shs.Text = _shs;
            this.log.Text = DAL.C_CongTacBangGia.logBG(_shs);
        }
    }
}
