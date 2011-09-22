using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using System.Data.SqlClient;
using log4net;
namespace TanHoaWater.DAL
{
    class C_KichThuocPhuiDao
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_KichThuocPhuiDao).Name);
        static TanHoaDataContext db = new TanHoaDataContext();
        public static void InsertKTPD(KICHTHUOCPHUIDAO ktpd) {          
            db.KICHTHUOCPHUIDAOs.InsertOnSubmit(ktpd);
            db.SubmitChanges();
        }
        public static KICHTHUOCPHUIDAO finbySTTAndSHS(int stt) {
            var query = from kt in db.KICHTHUOCPHUIDAOs where kt.STT == stt select kt;
            return query.SingleOrDefault();
        }
        public static List<KICHTHUOCPHUIDAO> getListBySHS(string shs) {
            var query = from kt in db.KICHTHUOCPHUIDAOs where kt.SHS == shs select kt;
            return query.ToList();
        }
        public void DeleteByKTPD(KICHTHUOCPHUIDAO kt) {
            db.KICHTHUOCPHUIDAOs.DeleteOnSubmit(kt);
            db.SubmitChanges();        
        }
        public void DeleteBySHS(string shs) {
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = " DELETE KICHTHUOCPHUIDAO WHERE SHS='"+ shs +"' ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
