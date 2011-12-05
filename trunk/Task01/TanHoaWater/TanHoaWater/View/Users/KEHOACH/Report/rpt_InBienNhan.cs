using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace TanHoaWater.View.Users.KEHOACH.Report
{
    public partial class rpt_InBienNhan : Form
    {
        public rpt_InBienNhan(ReportDocument rp)
        {
            InitializeComponent();
            this.crystalReportViewer1.ReportSource = rp;
        }
    }
}
