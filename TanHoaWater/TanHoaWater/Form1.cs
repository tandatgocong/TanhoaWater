using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.KEHOACH.Report;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
namespace TanHoaWater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         }

        private void button1_Click(object sender, EventArgs e)
        {
           
            ////rp.SaveAs(@"D:\tmp.pdf");

            //rp.PrintToPrinter(0, true, 0, 0);
            ReportDocument cryRpt = new crp_BIENNHAN();

            //TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            //TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            //ConnectionInfo crConnectionInfo = new ConnectionInfo();
            //Tables CrTables;

            //crConnectionInfo.ServerName = "YOUR SERVERNAME";
            //crConnectionInfo.DatabaseName = "DATABASE NAME";
            //crConnectionInfo.UserID = "USERID";
            //crConnectionInfo.Password = "PASSWORD";

            //CrTables = cryRpt.Database.Tables;
            //foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            //{
            //    crtableLogoninfo = CrTable.LogOnInfo;
            //    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
            //    CrTable.ApplyLogOnInfo(crtableLogoninfo);
            //}
            CrystalReportViewer r = new CrystalReportViewer();
            ReportDocument rp = new crp_BIENNHAN();
            rp.PrintOptions.PaperSize = PaperSize.Paper11x17;
            rp.SetDataSource(DAL.C_BienNhanDon.printBienNhan("1100000"));
            r.ReportSource = rp;
            
          //  r.PrintReport();
            //cryRpt.SetDataSource(DAL.C_BienNhanDon.printBienNhan("1100000"));
            //cryRpt.Refresh();
            //cryRpt.PrintToPrinter(2, true, 0, 0);
        }
    }
}