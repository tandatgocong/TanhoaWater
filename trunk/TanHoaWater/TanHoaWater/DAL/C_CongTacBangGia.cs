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
        public static double CPVATLIEU = 0.0;//@A FLOAT OUTPUT,
        public static double CPNHANCONG = 0.0;//@B FLOAT OUTPUT,
        public static double CPMAYTHICONG = 0.0;///@C FLOAT OUTPUT,
	    public static double CPCABA=0.0;//@CHIPHICABA FLOAT OUTPUT,	
	    public static double TONG=0.0;//@TOTAL FLOAT OUTPUT,
	    public static double VAT=0.0;///@VAT FLOAT OUTPUT,
        
        public static void TongKetChiPhi(string shs) {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);          

            conn.Open();
            SqlCommand cmd = new SqlCommand("TONGKETCHIPHI", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter inparm = cmd.Parameters.Add("@shs", SqlDbType.Float);
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

            CPVATLIEU = double.Parse(cmd.Parameters["@A"].Value + "");
            CPNHANCONG = double.Parse(cmd.Parameters["@B"].Value + "");
            CPMAYTHICONG = double.Parse(cmd.Parameters["@C"].Value + "");
            CPCABA = double.Parse(cmd.Parameters["@CPCABA"].Value + "");
            TONG = double.Parse(cmd.Parameters["@TOTAL"].Value + "");
            VAT = double.Parse(cmd.Parameters["@VAT"].Value + "");
            conn.Close();
        }

    }
}
