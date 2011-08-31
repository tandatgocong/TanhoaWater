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
    public partial class Admin_Main : UserControl
    {
        public Admin_Main()
        {
            InitializeComponent();
        }

        private void userAddNew_NodeClick(object sender, EventArgs e)
        {

        }
        private void users_NodeClick_1(object sender, EventArgs e)
        {
            this.adminPanel.Panel2.Controls.Clear();
            this.adminPanel.Panel2.Controls.Add(new uct_Users());
        }

        private void advTree1_Click(object sender, EventArgs e)
        {

        }
    }
}
