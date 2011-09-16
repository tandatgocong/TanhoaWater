using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace TanHoaWater.View.Users.Report
{
    public partial class rpt_Main : Form
    {
        public rpt_Main(ReportDocument rp)
        {
            InitializeComponent();          
            crystalReportViewer.ReportSource = rp;
        }
    }
}
