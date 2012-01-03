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
            //ReportDocument rp = new rptVatTuDieuChinh();
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

            DataTable VATTUSAUDC = ds.Tables["VATTUSAUDC"];
            DataTable XDCBSAUDC = ds.Tables["XDCBSAUDC"];

            for (int i = 0; i < VATTUSAUDC.Rows.Count; i++)
            {
                string mahieuTDC = VATTUSAUDC.Rows[i]["MAHIEU"].ToString();
                string tenvtTDC = VATTUSAUDC.Rows[i]["TENVT"].ToString();
                string khoiluongTDC = VATTUSAUDC.Rows[i]["KHOILUONG"].ToString();
                string loaiSDTDC = VATTUSAUDC.Rows[i]["LOAISN"].ToString();
                for (int j = 0; j < VATTUTRUOCDC.Rows.Count; j++)
                {

                }
                MessageBox.Show(this, mahieuTDC + "--" + tenvtTDC + "----" + khoiluongTDC + "----" + loaiSDTDC);
            }

            dataGridView1.DataSource = VATTUTRUOCDC;
            dataGridView2.DataSource = XDCBTUOCDC;
            dataGridView3.DataSource = VATTUSAUDC;
            dataGridView4.DataSource = XDCBSAUDC;


            sql = "SELECT distinct  * FROM BG_THONGTINKHACHANG  WHERE SHS='" + "11000024" + "'";
            dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            dond.Fill(ds, "BG_THONGTINKHACHANG");



            sql = "SELECT  distinct * FROM BG_REPORT ";
            dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            dond.Fill(ds, "BG_REPORT");

            sql = "SELECT distinct * FROM USERS  WHERE USERNAME='" + DAL.C_USERS._userName + "'";
            dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            dond.Fill(ds, "USERS");
            //rp.SetDataSource(ds);
            //crystalReportViewer1.ReportSource = rp;
        }
    }
}
