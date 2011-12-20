using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using System.Data.SqlClient;
using log4net;
using System.Data;
namespace TanHoaWater.DAL
{
    class C_BGDC_KICHTHUOCPHUIDAO
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_BGDC_KICHTHUOCPHUIDAO).Name);
        static TanHoaDataContext db = new TanHoaDataContext();
        public static void InsertKTPD(BGDC_KICHTHUOCPHUIDAO ktpd) {          
            db.BGDC_KICHTHUOCPHUIDAOs.InsertOnSubmit(ktpd);
            db.SubmitChanges();
        }
        public static BGDC_KICHTHUOCPHUIDAO finbySTTAndSHS(int stt) {
            var query = from kt in db.BGDC_KICHTHUOCPHUIDAOs where kt.STT == stt select kt;
            return query.SingleOrDefault();
        }
        //public static List<BGDC_KICHTHUOCPHUIDAO> getListBySHS(string shs) {
        //    var query = from kt in db.BGDC_KICHTHUOCPHUIDAOs where kt.SHS == shs select kt;
        //    return query.ToList();
        //}
        public static DataTable getListBySHS(string shs, int lan)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT MADANHMUC, TENKETCAU, DVT, DAI, RONG, DOSAU, SOLUONG, KHOILUONG, CHUVI, THETICH, COTINHTL ";
            sql += " FROM BGDC_KICHTHUOCPHUIDAO ";
            sql += " WHERE  SHS='" + shs + "' AND LAN='"+ lan +"' ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];

        }

        public void DeleteByKTPD(BGDC_KICHTHUOCPHUIDAO kt) {
            db.BGDC_KICHTHUOCPHUIDAOs.DeleteOnSubmit(kt);
            db.SubmitChanges();        
        }
        public void DeleteBySHS(string shs) {
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = " DELETE BGDC_KICHTHUOCPHUIDAO WHERE SHS='"+ shs +"' ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
