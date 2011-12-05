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


namespace TanHoaWater.View.Report
{
    public partial class rpt_View : Form
    {
        public rpt_View( string dotkh)
        {
            InitializeComponent();
            ReportDocument rp = new prt_BangKeNhanDon();
            rp.SetDataSource(DAL.C_DonKhachHang.BangKeNhanDon(dotkh, DAL.C_USERS._userName));
            crystalReportViewer.ReportSource = rp;
        }        
    }
}
