using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.KEHOACH.XINPHEPDD.BC;

namespace TanHoaWater.View.Users.KEHOACH.XINPHEPDD
{
    public partial class frmDialogPrintting : Form
    {
        public frmDialogPrintting(string madot)
        {
            InitializeComponent();

            this.cbMaDot.DataSource = DAL.C_KH_XinPhepDD.ListAllXinPhepDD();
            this.cbMaDot.ValueMember = "MADOT";
            this.cbMaDot.DisplayMember = "MADOT";
            cbMaDot.Text = madot;
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            
            ReportDocument rp = new rpt_KhongPhep();
            string TUNGAY = Utilities.DateToString.NgayVN(tungay);
            string DENNGAY = Utilities.DateToString.NgayVN(denngay);
            string NGAYKHOICONGDAO = Utilities.DateToString.NgayVN(ngaykhoicong);
            string NGAYHOANTATTL = Utilities.DateToString.NgayVN(ngaytailap);
            rp.SetDataSource(DAL.C_KH_XinPhepDD.ReportxinPhepDD(this.cbMaDot.Text, TUNGAY, DENNGAY, NGAYKHOICONGDAO, NGAYHOANTATTL));
            crystalReportViewer1.ReportSource = rp;
        }

        private void btExit_Click(object sender, EventArgs e)
        {

        }
    }
}
