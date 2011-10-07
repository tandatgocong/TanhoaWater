using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using System.Data.SqlClient;
using log4net;
namespace TanHoaWater.DAL
{
    class C_BG_KICHTHUOCPHUIDAO
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_BG_KICHTHUOCPHUIDAO).Name);
        static TanHoaDataContext db = new TanHoaDataContext();
        public static void InsertKTPD(BG_KICHTHUOCPHUIDAO ktpd) {          
            db.BG_KICHTHUOCPHUIDAOs.InsertOnSubmit(ktpd);
            db.SubmitChanges();
        }
        public static BG_KICHTHUOCPHUIDAO finbySTTAndSHS(int stt) {
            var query = from kt in db.BG_KICHTHUOCPHUIDAOs where kt.STT == stt select kt;
            return query.SingleOrDefault();
        }
        public static List<BG_KICHTHUOCPHUIDAO> getListBySHS(string shs) {
            var query = from kt in db.BG_KICHTHUOCPHUIDAOs where kt.SHS == shs select kt;
            return query.ToList();
        }
        public void DeleteByKTPD(BG_KICHTHUOCPHUIDAO kt) {
            db.BG_KICHTHUOCPHUIDAOs.DeleteOnSubmit(kt);
            db.SubmitChanges();        
        }
        public void DeleteBySHS(string shs) {
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = " DELETE BG_KICHTHUOCPHUIDAO WHERE SHS='"+ shs +"' ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
