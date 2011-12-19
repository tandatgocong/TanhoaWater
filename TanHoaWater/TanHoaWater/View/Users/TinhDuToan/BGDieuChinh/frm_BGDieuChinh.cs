using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using TanHoaWater.Database;
using System.Text.RegularExpressions;
using TanHoaWater.View.Users.BGDieuChinh;

namespace TanHoaWater.View.Users.TinhDuToan.BGDieuChinh
{
    public partial class frm_BGDieuChinh : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_BGDieuChinh).Name);
        public frm_BGDieuChinh()
        {
            InitializeComponent();
            panel2.Controls.Add(new tab_BangGiaDieuChinh());
        }

    }
}