using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TanHoaWater.View.Administrators
{
    public partial class ut_HeThongDuong : UserControl
    {
        public ut_HeThongDuong()
        {
            InitializeComponent();
            fromLoad();
        }
        public void fromLoad() {
            this.cbPhuong.DataSource = DAL.C_TenDuong.getPhuong();
            this.cbPhuong.DisplayMember = "Display";
            this.cbPhuong.ValueMember = "Value";
            this.cbQuan.DataSource = DAL.C_TenDuong.getQuan();
            this.cbQuan.DisplayMember = "Display";
            this.cbQuan.ValueMember = "Value";
        }
             
    }
}
