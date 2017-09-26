using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.Report;

namespace TanHoaWater.View.Users.KEHOACH.DOTTHICONG.BC
{
    public partial class frmThongBaoThiCong : Form
    {
        public frmThongBaoThiCong(string dot)
        {
            InitializeComponent();
            this.txtDot.Text = dot;
            tcTuNgay.Value = tcDenNgay.Value = dCoPhep.Value = DateTime.Now.Date;
        }


        private void btIN_Click(object sender, EventArgs e)
        {
           
            ReportDocument rp = new rpt_ThongBaoKhoiCong();
            if(checkDinhKem.Checked==true)
                rp = new rpt_ThongBaoKhoiCong_dsdk();
            //if (DAL.C_KH_DonViTC.findDVTLbyTENCTY(this.cbDonViTaiLapMD.Text).ID == 17 || DAL.C_KH_DonViTC.findDVTLbyTENCTY(this.cbDonViTaiLapMD.Text).ID == 19)
            //{
            //    rp = new rpt_QuyetDinhTCKoDVTL();
            //}
            rp.SetDataSource(DAL.C_KH_DotThiCong.BC_ThongBaoThiCong(this.txtDot.Text));

            string ngaytc = Utilities.DateToString.NgayVN(tcTuNgay.Value);
            string ngayden = Utilities.DateToString.NgayVN(tcDenNgay.Value);
            string ngayphep = Utilities.DateToString.NgayVN(dCoPhep.Value);
            rp.SetParameterValue("sodottc", this.txtDot.Text);
            rp.SetParameterValue("sophepdd", this.txtSoGiayPhep.Text);
            rp.SetParameterValue("ngayxp", ngayphep);
            rp.SetParameterValue("tungay", ngaytc);
            rp.SetParameterValue("dennay", ngayden);
            crystalReportViewer1.ReportSource = rp;
            this.WindowState = FormWindowState.Maximized;
            this.panel1.Visible = false;
        }
    }
}
