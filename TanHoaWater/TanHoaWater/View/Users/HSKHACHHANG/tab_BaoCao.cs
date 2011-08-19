using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.HSKHACHHANG.Report;

namespace TanHoaWater.View.Users.HSKHACHHANG
{
    public partial class tab_BaoCao : UserControl
    {
        public tab_BaoCao()
        {
            InitializeComponent();
            this.BC_DotNhanDon.DataSource = DAL.C_DOTNHANDON.getListtMa_Dot();
            this.BC_DotNhanDon.ValueMember = "MADOT";
            this.BC_DotNhanDon.DisplayMember = "TEND";
            this.BC_QUAN.DataSource = DAL.C_QUAN.getList();
            this.BC_QUAN.ValueMember = "MAQUAN";
            this.BC_QUAN.DisplayMember = "TENQUAN";
        }

        private void cbLoaiBC_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.cbLoaiBC.SelectedIndex == 0)
            {
                this.BC_DotNhanDon.Enabled = true;
                this.BC_QUAN.Enabled = false;
            }
            else if (this.cbLoaiBC.SelectedIndex == 1)
            {
                this.BC_QUAN.Enabled = true;
                this.BC_DotNhanDon.Enabled = true;
            }
            else if (this.cbLoaiBC.SelectedIndex == 2)
            {
                this.BC_DotNhanDon.Enabled = true;
                this.BC_QUAN.Enabled = false;
            }
            else if (this.cbLoaiBC.SelectedIndex == 3)
            {
                this.BC_QUAN.Enabled = true;
                this.BC_DotNhanDon.Enabled = true;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (this.cbLoaiBC.SelectedIndex == 0)
            {
                this.BC_DotNhanDon.Enabled = true;
                this.BC_QUAN.Enabled =false;
            }
            else if (this.cbLoaiBC.SelectedIndex == 1)
            {
                this.BC_QUAN.Enabled = true;
                this.BC_DotNhanDon.Enabled = true;
            }
            else if (this.cbLoaiBC.SelectedIndex == 2)
            {
                this.BC_DotNhanDon.Enabled = true;
                this.BC_QUAN.Enabled =false;
            }
            else if (this.cbLoaiBC.SelectedIndex == 3)
            {
                this.BC_QUAN.Enabled = true;
                this.BC_DotNhanDon.Enabled = true;
            }
            ReportDocument rp = new prt_theoDotQuan();
            rp.SetDataSource(DAL.C_DONKHACHHANG.BangKeNhanDon("8995/6545"));
            crystalReportViewer1.ReportSource = rp;
        }
    }
}
