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
 
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using TanHoaWater.View.Users.KEHOACH.Report;
using TanHoaWater.View.Users.TinhDuToan.report;
using System.Data.SqlClient;
namespace TanHoaWater
{
    public partial class Form1 : Form
    {
        double total = 0.0;
        public Form1()
        {
            InitializeComponent();
            DataSet ds = new DataSet();
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();

            string sql = "SELECT * FROM BG_CHITIETBG  WHERE SHS='11DD001'";
           
            SqlDataAdapter dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            dond.Fill(ds, "BG_CHITIETBG");


            string user = "SELECT * FROM BG_TAILAPMATDUONG  WHERE SHS='11DD001'";
            SqlDataAdapter ct = new SqlDataAdapter(user, db.Connection.ConnectionString);
            ct.Fill(ds, "BG_TAILAPMATDUONG");

            user = "SELECT * FROM W_HS ";
             ct = new SqlDataAdapter(user, db.Connection.ConnectionString);
             ct.Fill(ds, "BG_HESOBANGGIA");


            user = "SELECT * FROM BG_THONGTINKHACHANG  WHERE SHS='11DD001'";
            ct = new SqlDataAdapter(user, db.Connection.ConnectionString);
            ct.Fill(ds, "BG_THONGTINKHACHANG");

            user = "SELECT * FROM BG_SUMTAILAPMATDUONG  WHERE SHS='11DD001'";
            ct = new SqlDataAdapter(user, db.Connection.ConnectionString);
            ct.Fill(ds, "BG_SUMTAILAPMATDUONG");

            user = "SELECT * FROM BG_REPORT ";
            ct = new SqlDataAdapter(user, db.Connection.ConnectionString);
            ct.Fill(ds, "BG_REPORT");

            user = "SELECT * FROM USERS  WHERE USERNAME='"+ "thanhtrung" +"'";
            ct = new SqlDataAdapter(user, db.Connection.ConnectionString);
            ct.Fill(ds, "USERS");
                      
            ds.Tables.Add(TongKetChiPhi("11DD001"));
            
            double TongThanhTien = total + double.Parse(ds.Tables["BG_SUMTAILAPMATDUONG"].Rows[0][1].ToString());           
            CrystalReportViewer r = new CrystalReportViewer();
            ReportDocument rp = new CrystalReport1();

            //rp.Subreports["Subreport1"].SetParameterValue("Tienchu", Utilities.Doctien.ReadMoney(String.Format("{0:0}", TongThanhTien)));
            rp.SetDataSource(ds);
            rp.SetParameterValue("Tienchu", Utilities.Doctien.ReadMoney(String.Format("{0:0}", TongThanhTien)));
            rp.SetParameterValue("subTienchu", Utilities.Doctien.ReadMoney(String.Format("{0:0}", TongThanhTien)));
            
            crystalReportViewer1.ReportSource = rp;
         }


        public  DataTable TongKetChiPhi(string shs)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);

            conn.Open();
            SqlCommand cmd = new SqlCommand("TONGKETCHIPHI", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter inparm = cmd.Parameters.Add("@shs", SqlDbType.VarChar);
            inparm.Direction = ParameterDirection.Input;
            inparm.Value = shs;

            SqlParameter _A = cmd.Parameters.Add("@A", SqlDbType.Float);
            _A.Direction = ParameterDirection.Output;

            SqlParameter _B = cmd.Parameters.Add("@B", SqlDbType.Float);
            _B.Direction = ParameterDirection.Output;

            SqlParameter _C = cmd.Parameters.Add("@C", SqlDbType.Float);
            _C.Direction = ParameterDirection.Output;

            SqlParameter _CHIPHICABA = cmd.Parameters.Add("@CPCABA", SqlDbType.Float);
            _CHIPHICABA.Direction = ParameterDirection.Output;

            SqlParameter _TONG = cmd.Parameters.Add("@TOTAL", SqlDbType.Float);
            _TONG.Direction = ParameterDirection.Output;

            SqlParameter _VAT = cmd.Parameters.Add("@VAT", SqlDbType.Float);
            _VAT.Direction = ParameterDirection.Output;

            SqlParameter B1 = cmd.Parameters.Add("@B1", SqlDbType.Float);
            B1.Direction = ParameterDirection.Output;

            SqlParameter C1 = cmd.Parameters.Add("@C1", SqlDbType.Float);
            C1.Direction = ParameterDirection.Output;

            SqlParameter C2 = cmd.Parameters.Add("@C2", SqlDbType.Float);
            C2.Direction = ParameterDirection.Output;

            SqlParameter D = cmd.Parameters.Add("@D", SqlDbType.Float);
            D.Direction = ParameterDirection.Output;

            SqlParameter E = cmd.Parameters.Add("@E", SqlDbType.Float);
            E.Direction = ParameterDirection.Output;

            SqlParameter F = cmd.Parameters.Add("@F", SqlDbType.Float);
            F.Direction = ParameterDirection.Output;

            SqlParameter G = cmd.Parameters.Add("@G", SqlDbType.Float);
            G.Direction = ParameterDirection.Output;

            SqlParameter H = cmd.Parameters.Add("@H", SqlDbType.Float);
            H.Direction = ParameterDirection.Output;

            SqlParameter I = cmd.Parameters.Add("@I", SqlDbType.Float);
            I.Direction = ParameterDirection.Output;

            SqlParameter J = cmd.Parameters.Add("@J", SqlDbType.Float);
            J.Direction = ParameterDirection.Output;

            SqlParameter K = cmd.Parameters.Add("@K", SqlDbType.Float);
            K.Direction = ParameterDirection.Output;

            SqlParameter L = cmd.Parameters.Add("@L", SqlDbType.Float);
            L.Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            DataTable table = new DataTable("TONGKETKINHPHI");
            table.Columns.Add("SHS", typeof(string));
            table.Columns.Add("A", typeof(double));
            table.Columns.Add("B", typeof(double));
            table.Columns.Add("C", typeof(double));
            table.Columns.Add("CPCABA", typeof(double));
            table.Columns.Add("TOTAL", typeof(double));
            table.Columns.Add("VAT", typeof(double));
            table.Columns.Add("B1", typeof(double));
            table.Columns.Add("C1", typeof(double));
            table.Columns.Add("C2", typeof(double));
            table.Columns.Add("D", typeof(double));
            table.Columns.Add("E", typeof(double));
            table.Columns.Add("F", typeof(double));
            table.Columns.Add("G", typeof(double));
            table.Columns.Add("H", typeof(double));
            table.Columns.Add("I", typeof(double));
            table.Columns.Add("J", typeof(double));
            table.Columns.Add("K", typeof(double));
            table.Columns.Add("L", typeof(double));

            DataRow myDataRow = table.NewRow();
            total = double.Parse(cmd.Parameters["@TOTAL"].Value + ""); 
            myDataRow["SHS"]=shs;
            myDataRow["A"]=double.Parse(cmd.Parameters["@A"].Value + "");
            myDataRow["B"] = double.Parse(cmd.Parameters["@B"].Value + ""); 
            myDataRow["C"] = double.Parse(cmd.Parameters["@C"].Value + ""); 
            myDataRow["CPCABA"] = double.Parse(cmd.Parameters["@CPCABA"].Value + "");
            myDataRow["TOTAL"] = total;
            myDataRow["VAT"] = double.Parse(cmd.Parameters["@VAT"].Value + ""); 
            myDataRow["B1"] = double.Parse(cmd.Parameters["@B1"].Value + ""); 
            myDataRow["C1"] = double.Parse(cmd.Parameters["@C1"].Value + ""); 
            myDataRow["C2"] = double.Parse(cmd.Parameters["@C2"].Value + "");
            myDataRow["D"] = double.Parse(cmd.Parameters["@D"].Value + ""); ;
            myDataRow["E"] = double.Parse(cmd.Parameters["@E"].Value + ""); ;
            myDataRow["F"] = double.Parse(cmd.Parameters["@F"].Value + ""); ;
            myDataRow["G"] = double.Parse(cmd.Parameters["@G"].Value + ""); ;
            myDataRow["H"] = double.Parse(cmd.Parameters["@H"].Value + ""); ;
            myDataRow["I"] = double.Parse(cmd.Parameters["@I"].Value + ""); ;
            myDataRow["J"]=double.Parse(cmd.Parameters["@J"].Value + "");
            myDataRow["K"]=double.Parse(cmd.Parameters["@K"].Value + "");
            myDataRow["L"]=double.Parse(cmd.Parameters["@L"].Value + "");
            table.Rows.Add(myDataRow);
            conn.Close();
            return table;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            ////rp.SaveAs(@"D:\tmp.pdf");

            //rp.PrintToPrinter(0, true, 0, 0);
           // ReportDocument cryRpt = new crp_BIENNHAN();

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
            //CrystalReportViewer r = new CrystalReportViewer();
            //ReportDocument rp = new crp_BIENNHAN();           
         ////   rp.SetDataSource(DAL.C_BienNhanDon.printBienNhan("1100000"));
         //   r.ReportSource = rp;
         //   crystalReportViewer1.ReportSource = rp;

            
          //  r.PrintReport();
            //cryRpt.SetDataSource(DAL.C_BienNhanDon.printBienNhan("1100000"));
            //cryRpt.Refresh();
            //cryRpt.PrintToPrinter(2, true, 0, 0);
        }
    }
}