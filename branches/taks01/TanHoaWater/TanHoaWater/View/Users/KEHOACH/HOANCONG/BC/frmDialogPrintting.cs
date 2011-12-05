using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.KEHOACH.HOANCONG.BC;

namespace TanHoaWater.View.Users.HOANCONG.BC
{
    public partial class frmDialogPrintting : Form
    {
        string _madot = "";
        public frmDialogPrintting(string madot)
        {
            InitializeComponent();        
            _madot = madot;
            ReportDocument rp = new rpt_ChiPhiGanNhua();
            rp.SetDataSource(DAL.C_KH_HoanCong.BC_TACHPHIGANNHUA(madot));
            crystalReportViewer1.ReportSource = rp;
            this.WindowState = FormWindowState.Maximized;
        }

        //private void btPrint_Click(object sender, EventArgs e)
        //{
        //    panel1.Visible = false;
        //    string sql = "";
        //    if (this.theodot.Checked) {
        //        sql = "SELECT * FROM V_TACHPHIGANNHUA WHERE MADOTTC='" + _madot + "' ORDER BY MODIFYDATE";
        //    } else {
        //        sql = "SELECT * FROM V_TACHPHIGANNHUA WHERE SHS IN ('" + _madot + "') ORDER BY MODIFYDATE";
        //    }

            
        //}

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
