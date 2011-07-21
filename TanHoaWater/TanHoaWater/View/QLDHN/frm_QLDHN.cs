using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TanHoaWater.View.QLDHN
{
    public partial class frm_QLDHN : Form
    {
        public frm_QLDHN()
        {
            InitializeComponent();
        }
           

        private void node1_NodeClick(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new controlAddLich());
        }

        private void node2_NodeClick(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new controlViewLich());
        }
    }
}
