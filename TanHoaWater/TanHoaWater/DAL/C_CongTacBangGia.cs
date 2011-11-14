using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using log4net;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using TanHoaWater.Utilities;
namespace TanHoaWater.DAL
{
    class C_CongTacBangGia
    {

        private static readonly ILog log = LogManager.GetLogger(typeof(C_CongTacBangGia).Name);
        
        public static bool InsertCongTacBG(BG_CONGTACBANGIA dm)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.BG_CONGTACBANGIAs.InsertOnSubmit(dm);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Insert DANH SACH CONG TAC BANG GIA Loi. " + ex.Message);
            }
            return false;
        }
        //public static List<BG_CONGTACBANGIA> getListBySHS(string shs)
        //{
        //    TanHoaDataContext db = new TanHoaDataContext();
        //    var query = from kt in db.BG_CONGTACBANGIAs where kt.SHS == shs select kt;
        //    return query.ToList();
        //}

        public static DataTable getListBySHS(string shs)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            //string sql = " SELECT MAHIEU, MAHDG, TENVT, DVT, NHOM as 'NHOMVT', LOAISN,CASE WHEN NHOM='XDCB' THEN KHOILUONG*1000 ELSE KHOILUONG END as 'KHOILUONG' , DONGIAVL, DONGIANC, DONGIAMTC ";
            string sql = " SELECT MAHIEU, MAHDG, TENVT, DVT, NHOM as 'NHOMVT', LOAISN, KHOILUONG , DONGIAVL, DONGIANC, DONGIAMTC ";
            sql += " FROM BG_CONGTACBANGIA ";
            sql += " WHERE  SHS='" + shs + "' ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];

        }
        

        public static double CPVATLIEU = 0.0;//@A FLOAT OUTPUT,
        public static double CPNHANCONG = 0.0;//@B FLOAT OUTPUT,
        public static double CPMAYTHICONG = 0.0;///@C FLOAT OUTPUT,
	    public static double CPCABA=0.0;//@CHIPHICABA FLOAT OUTPUT,	
        public static double THUE55 = 0.0;///@VAT FLOAT OUTPUT,
        public static double TONGTRUOCTHUE = 0.0;///@VAT FLOAT OUTPUT,
        public static double VAT = 0.0;///@VAT FLOAT OUTPUT,
	    public static double TONG=0.0;//@TOTAL FLOAT OUTPUT,
        public static double TLMDTRUOCTHUE = 0.0;
        public static double TAILAPMATDUONG = 0.0;
	    public static double  CHIPHITRUCTIEP= 0.0;
	    public static double CHIPHICHUNG= 0.0;
        public static double CPGAN = 0.0;
        public static double CPNHUA = 0.0;

        public static void TongKetChiPhi(string shs, bool _PHIC3,  bool _PHIGS,  bool _PHIQL ) {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);

            conn.Open();
            SqlCommand cmd = new SqlCommand("TONGKETCHIPHI", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter inparm = cmd.Parameters.Add("@shs", SqlDbType.VarChar);
            inparm.Direction = ParameterDirection.Input;
            inparm.Value = shs;

            SqlParameter PHIC3 = cmd.Parameters.Add("@PHIC3", SqlDbType.Bit);
            PHIC3.Direction = ParameterDirection.Input;
            PHIC3.Value = _PHIC3;

            SqlParameter PHIGS = cmd.Parameters.Add("@PHIGS", SqlDbType.Bit);
            PHIGS.Direction = ParameterDirection.Input;
            PHIGS.Value = _PHIGS;

            SqlParameter PHIQL = cmd.Parameters.Add("@PHIQL", SqlDbType.Bit);
            PHIQL.Direction = ParameterDirection.Input;
            PHIQL.Value = _PHIQL;


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

            SqlParameter _TAILAPMATDUONG = cmd.Parameters.Add("@TAILAPMATDUONG", SqlDbType.Float);
            _TAILAPMATDUONG.Direction = ParameterDirection.Output;

            SqlParameter _TLMDTRUOCTHUE = cmd.Parameters.Add("@TLMDTRUOCTHUE", SqlDbType.Float);
            _TLMDTRUOCTHUE.Direction = ParameterDirection.Output;

            SqlParameter _CPGAN = cmd.Parameters.Add("@CPGAN", SqlDbType.Float);
            _CPGAN.Direction = ParameterDirection.Output;

            SqlParameter _CPNHUA = cmd.Parameters.Add("@CPNHUA", SqlDbType.Float);
            _CPNHUA.Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            CPVATLIEU = double.Parse(cmd.Parameters["@A"].Value + "");
            CPNHANCONG = double.Parse(cmd.Parameters["@B1"].Value + "");
            CPMAYTHICONG = double.Parse(cmd.Parameters["@C1"].Value + "");
            CPCABA = double.Parse(cmd.Parameters["@CPCABA"].Value + "");
            THUE55 =  double.Parse(cmd.Parameters["@G"].Value + "");
            TONGTRUOCTHUE = double.Parse(cmd.Parameters["@H"].Value + "");
            TONG = double.Parse(cmd.Parameters["@TOTAL"].Value + "");
            VAT = double.Parse(cmd.Parameters["@VAT"].Value + "");
            TLMDTRUOCTHUE = double.Parse(cmd.Parameters["@TLMDTRUOCTHUE"].Value + "");
            TAILAPMATDUONG = double.Parse(cmd.Parameters["@TAILAPMATDUONG"].Value + "");
            CHIPHITRUCTIEP=double.Parse(cmd.Parameters["@D"].Value + "");
            CHIPHICHUNG = double.Parse(cmd.Parameters["@E"].Value + "");
            CPGAN = double.Parse(cmd.Parameters["@CPGAN"].Value + "");
            CPNHUA = double.Parse(cmd.Parameters["@CPNHUA"].Value + "");

            conn.Close();
        }

        public static void deleteData(string shs) {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);

            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETEDATABG", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter inparm = cmd.Parameters.Add("@shs", SqlDbType.VarChar);
            inparm.Direction = ParameterDirection.Input;
            inparm.Value = shs;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void updateghide(string shs,string note){
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var hs = from dm in db.BG_KHOILUONGXDCBs where dm.SHS== shs select dm;
                BG_KHOILUONGXDCB xdcb = hs.SingleOrDefault();
                if (xdcb != null)
                {
                    xdcb.BGLOG = xdcb.BGLOG + note;
                }
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

            }
           
        }
        public static string logBG(string shs )
        {
             
                TanHoaDataContext db = new TanHoaDataContext();
                var hs = from dm in db.BG_KHOILUONGXDCBs where dm.SHS == shs select dm;
                BG_KHOILUONGXDCB xdcb = hs.SingleOrDefault();
                if (xdcb != null)
                {
                     return xdcb.BGLOG;
                }
             return "";
        }
        public static void CapNhatHoanTatTK(string shs) {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var ttk = from query in db.TOTHIETKEs where query.SHS == shs select query;
                TOTHIETKE totk = ttk.SingleOrDefault();
                if (totk != null) {
                    totk.HOANTATTK = true;
                    totk.NGAYTKGD = DateTime.Now.Date;
                }
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error("Cap Nhat Hoan Tat Thiet Ke" + ex.Message);
            }
            
        }
    }
}
