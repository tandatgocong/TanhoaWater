using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.KEHOACH.Report;
using TanHoaWater.View.Users.KEHOACH.DOTTHICONG;

namespace TanHoaWater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ReportDocument rp = new rpt_DanhSachHSTC();
            rp.SetDataSource(DAL.C_KH_DotThiCong.BC_DanhSachDotThiCong("QTP-TTT-/111"));
            crystalReportViewer1.ReportSource = rp;

        }
    }
}
