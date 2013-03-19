using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace TanHoaWater.View.Users.KEHOACH.DOTTHICONG.BC
{
    public partial class reportValues : Form
    {
        int _flag = 0;
        string _madotc = "";
        string _ngaytk="";
        public reportValues(int flag, string madotc, string ngaytk)
        {
            InitializeComponent();
            _flag = flag;
            _madotc = madotc;
            _ngaytk = ngaytk;
            if (flag == 1) {
                this.labelX1.Text = "Nhập Mã Công Trình";
            }
            else if (flag == 2)
            {
                this.labelX1.Text = "Bồi Thường Kết Hợp Với:";
            }
            textBoxX1.Focus();
        }
        //MaCT
        //KETHOP
        public void print() {
            if (_flag == 1) {
                panel1.Visible = false;
                ReportDocument rp = new rpt_DanhSachHSTC_DOIMP();
                rp.SetDataSource(DAL.C_KH_DotThiCong.BC_DanhSachDotThiCong_OC(_madotc));
                rp.SetParameterValue("MaCT",this.textBoxX1.Text);
                rp.SetParameterValue("ngaytk", _ngaytk);
                crystalReportViewer1.ReportSource = rp;
                this.WindowState = FormWindowState.Maximized;
            }
            else if (_flag == 2)
            {
                panel1.Visible = false;
                ReportDocument rp = new rpt_DanhSachHSTC_BT_DOI();
                rp.SetDataSource(DAL.C_KH_DotThiCong.BC_DanhSachDotThiCong_OC(_madotc));
                rp.SetParameterValue("KETHOP", this.textBoxX1.Text);
                rp.SetParameterValue("ngaytk", _ngaytk);
                crystalReportViewer1.ReportSource = rp;
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void textBoxX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                print();
            }
        }
    }
}
