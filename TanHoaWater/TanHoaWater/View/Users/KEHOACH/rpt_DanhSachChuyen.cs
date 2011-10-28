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

namespace TanHoaWater.View.Users.KEHOACH
{
    public partial class rpt_DanhSachChuyen : Form
    {
        public rpt_DanhSachChuyen(string dotnd, string nguoilap, string nguoiduyet)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            ReportDocument rp = new rpt_DOT_QUAN();
            rp.SetDataSource(DAL.C_BAOCAO_VIEW.BC_CHUYENDON(dotnd,nguoilap,nguoiduyet));
            crystalReportViewer.ReportSource = rp;
        }
    }
}
