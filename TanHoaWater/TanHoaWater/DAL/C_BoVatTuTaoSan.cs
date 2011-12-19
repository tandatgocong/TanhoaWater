using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using TanHoaWater.Database;
using System.Data.SqlClient;
using System.Data;

namespace TanHoaWater.DAL
{
    class C_BoVatTuTaoSan
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_BoVatTuTaoSan).Name);
        public static string mabovt = "";
        public static bool InsertVTTS(BOVATTAOSAN dm)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.BOVATTAOSANs.InsertOnSubmit(dm);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Loi Them DMVT Tao San. " + ex.Message);
            }
            return false;
        }

        public static bool InsertChiTiet(CHITIETBOVATTAOSAN dm)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.CHITIETBOVATTAOSANs.InsertOnSubmit(dm);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Loi Them CHITIETBOVATTAOSAN . " + ex.Message);
            }
            return false;
        }

        public static List<BOVATTAOSAN> listBoVT(){
         
            TanHoaDataContext db = new TanHoaDataContext();
            var query = from q in db.BOVATTAOSANs   select q; 
            return query.ToList();
        }

        public static BOVATTAOSAN findByMaBo(string mabo) {
            TanHoaDataContext db = new TanHoaDataContext();
            var query = from q in db.BOVATTAOSANs where q.MABOVT == mabo select q;
            return query.SingleOrDefault();
        }

        public static void DeleteDMVT(string mabovt) {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            // string sql = " MVT";
            string sql = " DELETE FROM CHITIETBOVATTAOSAN ";
            sql += " WHERE MABOVT ='" + mabovt + "'";
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            db.Connection.Close();
        }
        public static DataTable getDanhMucVatTu(string mabovt)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            // string sql = " MVT";
            string sql = " SELECT MAHIEU,UPPER(TENVT) AS 'TENVT',DVT,NHOM as 'NHOMVT','CM' as 'LOAISN','1' as 'KHOILUONG', CHON";
            sql += " FROM CHITIETBOVATTAOSAN ";
            sql += " WHERE MABOVT ='" + mabovt + "'";
            sql += " ORDER BY CREATEDATE ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }
        public static List<CHITIETBOVATTAOSAN> getChiTietVT(string mabovt, bool chon) {
            TanHoaDataContext db = new TanHoaDataContext();
            var query = from q in db.CHITIETBOVATTAOSANs where q.MABOVT==mabovt && q.CHON==chon  select q;
            return query.ToList();
        }
    }
}
