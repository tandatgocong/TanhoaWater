using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.KEHOACH.DOTTHICONG.BC;

namespace TanHoaWater.View.Users.KEHOACH.DOTTHICONG
{
    public partial class frmDialogPrintting : Form
    {
        string _madot = "";
        public frmDialogPrintting(string madot)
        {
            InitializeComponent();

            this.cbDonViGiamSat.DataSource = DAL.C_KH_DotThiCong.DonViGiamSat();
            this.cbDonViGiamSat.ValueMember = "TENDONVI";
            this.cbDonViGiamSat.DisplayMember = "TENDONVI";
 
            lbDotTC.Text = "Đợt Thi Công : " + madot;
            _madot = madot;
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;           
            ReportDocument rp = new rpt_QuyetDinhTC();  
            string NGAYKHOICONGDAO = Utilities.DateToString.NgayVN(ngaykhoicong);
            string NGAYHOANTATTL = Utilities.DateToString.NgayVN(ngaytailap);
            rp.SetDataSource(DAL.C_KH_DotThiCong.BC_QuyetDinhThiCong(_madot, this.cbDonViGiamSat.Text, NGAYKHOICONGDAO, NGAYHOANTATTL));
            crystalReportViewer1.ReportSource = rp;
            this.WindowState = FormWindowState.Maximized;
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
