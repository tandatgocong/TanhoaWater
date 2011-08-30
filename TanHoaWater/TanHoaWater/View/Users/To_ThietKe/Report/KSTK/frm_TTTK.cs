using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace TanHoaWater.View.Users.To_ThietKe.Report.KSTK
{
    public partial class frm_TTTK : Form
    {
        public frm_TTTK(DataSet ds, int flag)
        {
            InitializeComponent();
            ReportDocument rp = new ReportDocument();
            if (flag == 1) {
                rp = new rpt_KSTK_byNgay();
            } else {
                rp = new rpt_KSTK_byDot();
            }
            
            rp.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rp;
        }
    }
}
