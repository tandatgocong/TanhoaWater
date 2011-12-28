using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.TinhDuToan.BGDieuChinh.report;
using TanHoaWater.Database;
using System.Data.SqlClient;

namespace TanHoaWater.View.Users.TinhDuToan.BGDieuChinh
{
    public partial class frm_VatTuDieuChinh : Form
    {
        public frm_VatTuDieuChinh()
        {
            InitializeComponent();
            ReportDocument rp = new rptVatTuDieuChinh();
            TanHoaDataContext db = new TanHoaDataContext();
            DataSet ds = new DataSet();
            db.Connection.Open();

            string sql = "SELECT distinct * FROM BG_CHITIETBG  WHERE SHS='" + "11000024" + "' AND NHOM <> 'XDCB' ";

            
            SqlDataAdapter dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            dond.Fill(ds, "VATTUTRUOCDC");

            sql = "SELECT distinct * FROM BG_CHITIETBG  WHERE SHS='" + "11000024" + "' AND NHOM = 'XDCB' ";
            dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            dond.Fill(ds, "XDCBTUOCDC");


            

            sql = "SELECT distinct * FROM BGDC_CHITIETBG  WHERE SHS='" + "11000024" + "' AND LAN='4' AND NHOM <> 'XDCB'";
            dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            dond.Fill(ds, "VATTUSAUDC");

            sql = "SELECT distinct * FROM BGDC_CHITIETBG  WHERE SHS='" + "11000024" + "' AND LAN='4' AND NHOM = 'XDCB' ";
            dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            dond.Fill(ds, "XDCBSAUDC");








            //LAY THONG TIN 
            DataTable VATTUTRUOCDC = ds.Tables["VATTUTRUOCDC"];
            DataTable XDCBTUOCDC = ds.Tables["XDCBTUOCDC"];




            sql = "SELECT distinct  * FROM BG_THONGTINKHACHANG  WHERE SHS='" + "11000024" + "'";
            dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            dond.Fill(ds, "BG_THONGTINKHACHANG");



            sql = "SELECT  distinct * FROM BG_REPORT ";
            dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            dond.Fill(ds, "BG_REPORT");

            sql = "SELECT distinct * FROM USERS  WHERE USERNAME='" + DAL.C_USERS._userName + "'";
            dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            dond.Fill(ds, "USERS");
            rp.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rp;
        }
    }
}
