using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace TanHoaWater
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.panel1.Controls.Add(new tab_XinPhepDD24());
        }
    }
}
