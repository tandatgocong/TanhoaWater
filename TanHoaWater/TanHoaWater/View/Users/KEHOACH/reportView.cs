using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace TanHoaWater.View.Users.KEHOACH
{
    public partial class reportView : Form
    {
        public reportView(ReportDocument rp)
        {
            InitializeComponent();
            this.crystalReportViewer1.ReportSource = rp;
            
        }
    }
}
