using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace TanHoaWater.View.Users.To_ThietKe.Report
{
    public partial class rpt_View : Form
    {
        public rpt_View(DataSet ds)
        {
            InitializeComponent();
            ReportDocument rp = new rpt_DSHS_Giao_SDV();
            rp.SetDataSource(ds);
            crystalReportViewer.ReportSource = rp;
        }
    }
}
