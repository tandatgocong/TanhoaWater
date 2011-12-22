using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using log4net;

namespace TanHoaWater.View.Users.Report
{
    public partial class rpt_ViewBangGiaDC : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(rpt_ViewBangGiaDC).Name);
        int _solandieuchinh = 0;
        string _shs = "";
        public rpt_ViewBangGiaDC(ReportDocument rp,string shs, int solandieuchinh)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            crystalReportViewer.ReportSource = rp;
            _solandieuchinh = solandieuchinh;
            _shs = shs;
        }

        private void rpt_ViewBangGiaDC_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DAL.C_BGDC_CongTacBangGia.deleteData(_shs, _solandieuchinh);
            }
            catch (Exception ex)
            {
                log.Error("Xoa Du Lieu Sau Khi Xem Bang Gia That Bai " + ex.Message);
            }
         
        }
    }
}
