using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using System.Data.SqlClient;
using System.Data;
namespace TanHoaWater.DAL
{
    class C_DanhMucBoVT
    {
        public static DANHMUCBOVATTU findBoVT(string mabovt, string mahieuvt) {
            TanHoaDataContext db = new TanHoaDataContext();
            var query = from q in db.DANHMUCBOVATTUs where q.MABOVT == mabovt && q.MAHIEU == mahieuvt select q;
            return query.SingleOrDefault();
        }
        public static List<DANHMUCBOVATTU> finbyMaBo(string mabovt) {
            TanHoaDataContext db = new TanHoaDataContext();
            var query = from q in db.DANHMUCBOVATTUs where q.MABOVT == mabovt select q;
            return query.ToList();
        }
        public static void InsertBoVT(DANHMUCBOVATTU bovt) {
            TanHoaDataContext db = new TanHoaDataContext();
            db.DANHMUCBOVATTUs.InsertOnSubmit(bovt);
            db.SubmitChanges();
        }
        public static void deletebyMaBoVT(string mabovt)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = " DELETE FROM DANHMUCBOVATTU ";
            sql += " WHERE MABOVT='" + mabovt + "'";       
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static DataTable getByMaBoVT(string mabovt) {

            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT MABOVT,MAHIEU,TENVT, DM ";
            sql += " FROM DANHMUCBOVATTU  WHERE MABOVT='" + mabovt + "'";  
          
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }
    }
}
