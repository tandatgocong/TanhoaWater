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
        public frm_VatTuDieuChinh(string _shs, int lan)
        {
            InitializeComponent();
            VATTUDIEUCHINH(_shs, lan);
            ////ReportDocument rp = new rptVatTuDieuChinh();
            //TanHoaDataContext db = new TanHoaDataContext();
            //DataSet ds = new DataSet();
            //db.Connection.Open();

            //string sql = "SELECT distinct * FROM BG_CHITIETBG  WHERE SHS='" + "11000024" + "' AND NHOM <> 'XDCB' ";

            
            //SqlDataAdapter dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            //dond.Fill(ds, "VATTUTRUOCDC");

            //sql = "SELECT distinct * FROM BG_CHITIETBG  WHERE SHS='" + "11000024" + "' AND NHOM = 'XDCB' ";
            //dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            //dond.Fill(ds, "XDCBTUOCDC");


            

            //sql = "SELECT distinct * FROM BGDC_CHITIETBG  WHERE SHS='" + "11000024" + "' AND LAN='4' AND NHOM <> 'XDCB'";
            //dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            //dond.Fill(ds, "VATTUSAUDC");

            //sql = "SELECT distinct * FROM BGDC_CHITIETBG  WHERE SHS='" + "11000024" + "' AND LAN='4' AND NHOM = 'XDCB' ";
            //dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            //dond.Fill(ds, "XDCBSAUDC");








            ////LAY THONG TIN 
            //DataTable VATTUTRUOCDC = ds.Tables["VATTUTRUOCDC"];
            //DataTable XDCBTUOCDC = ds.Tables["XDCBTUOCDC"];

            //DataTable VATTUSAUDC = ds.Tables["VATTUSAUDC"];
            //DataTable XDCBSAUDC = ds.Tables["XDCBSAUDC"];

            //for (int i = 0; i < VATTUSAUDC.Rows.Count; i++)
            //{
            //    string mahieuTDC = VATTUSAUDC.Rows[i]["MAHIEU"].ToString();
            //    string tenvtTDC = VATTUSAUDC.Rows[i]["TENVT"].ToString();
            //    string khoiluongTDC = VATTUSAUDC.Rows[i]["KHOILUONG"].ToString();
            //    string loaiSDTDC = VATTUSAUDC.Rows[i]["LOAISN"].ToString();
            //    for (int j = 0; j < VATTUTRUOCDC.Rows.Count; j++)
            //    {

            //    }
            //    MessageBox.Show(this, mahieuTDC + "--" + tenvtTDC + "----" + khoiluongTDC + "----" + loaiSDTDC);
            //}

            //dataGridView1.DataSource = VATTUTRUOCDC;
            //dataGridView2.DataSource = XDCBTUOCDC;
            //dataGridView3.DataSource = VATTUSAUDC;
            //dataGridView4.DataSource = XDCBSAUDC;


            //sql = "SELECT distinct  * FROM BG_THONGTINKHACHANG  WHERE SHS='" + "11000024" + "'";
            //dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            //dond.Fill(ds, "BG_THONGTINKHACHANG");



            //sql = "SELECT  distinct * FROM BG_REPORT ";
            //dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            //dond.Fill(ds, "BG_REPORT");

            //sql = "SELECT distinct * FROM USERS  WHERE USERNAME='" + DAL.C_USERS._userName + "'";
            //dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            //dond.Fill(ds, "USERS");
            ////rp.SetDataSource(ds);
            ////crystalReportViewer1.ReportSource = rp;
        }

        public void VATTUDIEUCHINH(string _shs, int lan)
        {
            //try
            //{
            TanHoaDataContext db = new TanHoaDataContext();
            DataSet ds = new DataSet();
            db.Connection.Open();

            string sql = "SELECT distinct * FROM BGDC_CHITIETBG  WHERE SHS='" + _shs + "' AND LAN='" + lan + "' AND NHOM = 'XDCB'  ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable xdcbtmp = new DataTable("XDCBTMP");
            adapter.Fill(xdcbtmp);

            DataTable xdcb = new DataTable("XDCB");
            xdcb.Columns.Add("SHS", typeof(string));
            xdcb.Columns.Add("MAHIEU", typeof(string));
            xdcb.Columns.Add("MAHDG", typeof(string));
            xdcb.Columns.Add("TENVT", typeof(string));
            xdcb.Columns.Add("DVT", typeof(string));
            xdcb.Columns.Add("NHOM", typeof(string));
            xdcb.Columns.Add("LOAISN", typeof(string));
            xdcb.Columns.Add("KHOILUONG", typeof(double));

            for (int i = 0; i < xdcbtmp.Rows.Count; i++)
            {
               //MessageBox.Show(this, xdcbtmp.Rows[i]["SUDUNGLAI"].ToString() + "__" + xdcbtmp.Rows[i]["CAPMOI"].ToString() + "__" + xdcbtmp.Rows[i]["THUHOI"].ToString());
                if (!"0".Equals(xdcbtmp.Rows[i]["SUDUNGLAI"].ToString()) )
                {
                    DataRow myDataRow = xdcb.NewRow();
                    myDataRow["SHS"] = xdcbtmp.Rows[i]["SUDUNGLAI"];
                    myDataRow["MAHIEU"] = xdcbtmp.Rows[i]["MAHIEU"];
                    myDataRow["MAHDG"] = xdcbtmp.Rows[i]["MAHDG"];
                    myDataRow["TENVT"] = xdcbtmp.Rows[i]["TENVT"];
                    myDataRow["DVT"] = xdcbtmp.Rows[i]["DVT"];
                    myDataRow["NHOM"] = xdcbtmp.Rows[i]["NHOM"];
                    myDataRow["LOAISN"] = "SDL";
                    myDataRow["KHOILUONG"] = xdcbtmp.Rows[i]["SUDUNGLAI"];
                    xdcb.Rows.Add(myDataRow);
                }
                if (!"0".Equals(xdcbtmp.Rows[i]["CAPMOI"].ToString()) )
                {
                    DataRow myDataRow = xdcb.NewRow();
                    myDataRow["SHS"] = xdcbtmp.Rows[i]["SUDUNGLAI"];
                    myDataRow["MAHIEU"] = xdcbtmp.Rows[i]["MAHIEU"];
                    myDataRow["MAHDG"] = xdcbtmp.Rows[i]["MAHDG"];
                    myDataRow["TENVT"] = xdcbtmp.Rows[i]["TENVT"];
                    myDataRow["DVT"] = xdcbtmp.Rows[i]["DVT"];
                    myDataRow["NHOM"] = xdcbtmp.Rows[i]["NHOM"];
                    myDataRow["LOAISN"] = "CM";
                    myDataRow["KHOILUONG"] = xdcbtmp.Rows[i]["CAPMOI"];
                    xdcb.Rows.Add(myDataRow);
                }
                if (!"0".Equals(xdcbtmp.Rows[i]["THUHOI"].ToString()) )
                {
                    DataRow myDataRow = xdcb.NewRow();
                    myDataRow["SHS"] = xdcbtmp.Rows[i]["SUDUNGLAI"];
                    myDataRow["MAHIEU"] = xdcbtmp.Rows[i]["MAHIEU"];
                    myDataRow["MAHDG"] = xdcbtmp.Rows[i]["MAHDG"];
                    myDataRow["TENVT"] = xdcbtmp.Rows[i]["TENVT"];
                    myDataRow["DVT"] = xdcbtmp.Rows[i]["DVT"];
                    myDataRow["NHOM"] = xdcbtmp.Rows[i]["NHOM"];
                    myDataRow["LOAISN"] = "TH";
                    myDataRow["KHOILUONG"] = xdcbtmp.Rows[i]["THUHOI"];
                    xdcb.Rows.Add(myDataRow);
                }
            }

            //for (int i = 0; i < xdcb.Rows.Count; i++)
            //{
            //    MessageBox.Show(this, xdcb.Rows[i]["MAHIEU"].ToString());
            //}
            sql = "SELECT distinct * FROM BGDC_CHITIETBG  WHERE SHS='" + _shs + "' AND LAN='" + lan + "' AND NHOM <> 'XDCB'  ";
            adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable vattuTMP = new DataTable("VATTUTMP");
            adapter.Fill(vattuTMP);

            DataTable vattu = new DataTable("VATTU");
            vattu.Columns.Add("SHS", typeof(string));
            vattu.Columns.Add("MAHIEU", typeof(string));
            vattu.Columns.Add("MAHDG", typeof(string));
            vattu.Columns.Add("TENVT", typeof(string));
            vattu.Columns.Add("DVT", typeof(string));
            vattu.Columns.Add("NHOM", typeof(string));
            vattu.Columns.Add("LOAISN", typeof(string));
            vattu.Columns.Add("KHOILUONG", typeof(double));

            for (int i = 0; i < vattuTMP.Rows.Count; i++)
            {
                if (!"0".Equals(vattuTMP.Rows[i]["SUDUNGLAI"].ToString())  )
                {
                    DataRow myDataRow = vattu.NewRow();
                    myDataRow["SHS"] = vattuTMP.Rows[i]["SUDUNGLAI"];
                    myDataRow["MAHIEU"] = vattuTMP.Rows[i]["MAHIEU"];
                    myDataRow["MAHDG"] = vattuTMP.Rows[i]["MAHDG"];
                    myDataRow["TENVT"] = vattuTMP.Rows[i]["TENVT"];
                    myDataRow["DVT"] = vattuTMP.Rows[i]["DVT"];
                    myDataRow["NHOM"] = vattuTMP.Rows[i]["NHOM"];
                    myDataRow["LOAISN"] = "SDL";
                    myDataRow["KHOILUONG"] = vattuTMP.Rows[i]["SUDUNGLAI"];
                    vattu.Rows.Add(myDataRow);
                }
                if (!"0".Equals(vattuTMP.Rows[i]["CAPMOI"].ToString())  )
                {
                    DataRow myDataRow = vattu.NewRow();
                    myDataRow["SHS"] = vattuTMP.Rows[i]["SUDUNGLAI"];
                    myDataRow["MAHIEU"] = vattuTMP.Rows[i]["MAHIEU"];
                    myDataRow["MAHDG"] = vattuTMP.Rows[i]["MAHDG"];
                    myDataRow["TENVT"] = vattuTMP.Rows[i]["TENVT"];
                    myDataRow["DVT"] = vattuTMP.Rows[i]["DVT"];
                    myDataRow["NHOM"] = vattuTMP.Rows[i]["NHOM"];
                    myDataRow["LOAISN"] = "CM";
                    myDataRow["KHOILUONG"] = vattuTMP.Rows[i]["CAPMOI"];
                    vattu.Rows.Add(myDataRow);
                }
                if (!"0".Equals(vattuTMP.Rows[i]["THUHOI"].ToString())  )
                {
                    DataRow myDataRow = vattu.NewRow();
                    myDataRow["SHS"] = vattuTMP.Rows[i]["SUDUNGLAI"];
                    myDataRow["MAHIEU"] = vattuTMP.Rows[i]["MAHIEU"];
                    myDataRow["MAHDG"] = vattuTMP.Rows[i]["MAHDG"];
                    myDataRow["TENVT"] = vattuTMP.Rows[i]["TENVT"];
                    myDataRow["DVT"] = vattuTMP.Rows[i]["DVT"];
                    myDataRow["NHOM"] = vattuTMP.Rows[i]["NHOM"];
                    myDataRow["LOAISN"] = "TH";
                    myDataRow["KHOILUONG"] = vattuTMP.Rows[i]["THUHOI"];
                    vattu.Rows.Add(myDataRow);
                }
            }


            ds.Tables.Add(xdcb);
            ds.Tables.Add(vattu);


            string user = "SELECT distinct * FROM BGDC_TAILAPMATDUONG  WHERE SHS='" + _shs + "' AND LAN='" + lan + "'";
            SqlDataAdapter ct = new SqlDataAdapter(user, db.Connection.ConnectionString);
            ct.Fill(ds, "BG_TAILAPMATDUONG");

            user = "SELECT distinct * FROM W_HS ";
            ct = new SqlDataAdapter(user, db.Connection.ConnectionString);
            ct.Fill(ds, "BG_HESOBANGGIA");


            user = "SELECT distinct  * FROM BG_THONGTINKHACHANG  WHERE SHS='" + _shs + "'";
            ct = new SqlDataAdapter(user, db.Connection.ConnectionString);
            ct.Fill(ds, "BG_THONGTINKHACHANG");

            user = "SELECT distinct * FROM BGDC_SUMTAILAPMATDUONG  WHERE SHS='" + _shs + "' AND LAN='" + lan + "'";
            ct = new SqlDataAdapter(user, db.Connection.ConnectionString);
            ct.Fill(ds, "BG_SUMTAILAPMATDUONG");

            user = "SELECT  distinct * FROM BG_REPORT ";
            ct = new SqlDataAdapter(user, db.Connection.ConnectionString);
            ct.Fill(ds, "BG_REPORT");

            user = "SELECT distinct * FROM USERS  WHERE USERNAME='" + DAL.C_USERS._userName + "'";
            ct = new SqlDataAdapter(user, db.Connection.ConnectionString);
            ct.Fill(ds, "USERS");

            ReportDocument rp = new rptVatTuDieuChinh(); 
            
            rp.SetDataSource(ds);
            rp.SetParameterValue("solan", lan);
             crystalReportViewer1.ReportSource = rp;
            //}
            //catch (Exception ex)
            //{
            //    log.Error("Loi Tao Bang Gia " + ex.Message);
            //}

        }
    }
}
