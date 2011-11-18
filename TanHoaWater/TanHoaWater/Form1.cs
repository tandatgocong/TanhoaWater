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
using TanHoaWater.View.Users.DONGHONUOC.BC;

namespace TanHoaWater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ReportDocument rp = new rpt_DANHBO();
            rp.SetDataSource(DAL.C_DHN_ChoDanhBo.BC_CHODANHBO("TH001"));
            crystalReportViewer1.ReportSource = rp;
            //this.labelX1.Text = Utilities.Strings.convertToUnSign("Nguyễn Bình Lâm Thanh An, Bình, Quân, Hương, Việt, Nguyễn Bá Tuyển(c29), Nguyễn Trọng Tuyển");

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
