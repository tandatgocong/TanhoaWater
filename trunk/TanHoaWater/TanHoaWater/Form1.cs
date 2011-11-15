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
using TanHoaWater.View.Users.KEHOACH.DOTTHICONG.BC;

namespace TanHoaWater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //ReportDocument rp = new rpt_DanhSachHSTC_DOIMP();
            //rp.SetDataSource(DAL.C_KH_DotThiCong.BC_DanhSachDotThiCong_OC("QTP-TTT-/111"));
            //rp.SetParameterValue("MaCT", "toi va anh");
            //crystalReportViewer1.ReportSource = rp;
            //this.labelX1.Text = Utilities.Strings.convertToUnSign("Nguyễn Bình Lâm Thanh An, Bình, Quân, Hương, Việt, Nguyễn Bá Tuyển(c29), Nguyễn Trọng Tuyển");

        }
    }
}
