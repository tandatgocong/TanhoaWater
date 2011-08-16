using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TanHoaWater.View.Users.HSKHACHHANG
{
    public partial class uct_NHANDONKH : UserControl
    {
        public uct_NHANDONKH()
        {
            InitializeComponent();
            formLoad();
        }

        private void txtghichukhan_MouseClick(object sender, MouseEventArgs e)
        {
            this.txtghichukhan.Text = null;

        }
        public void formLoad()
        {
            #region Load Quan
            this.cbQuan.DataSource = DAL.C_QUAN.getList();
            this.cbQuan.DisplayMember = "TENQUAN";
            this.cbQuan.ValueMember = "MAQUAN";
            #endregion
        }
    }
}
