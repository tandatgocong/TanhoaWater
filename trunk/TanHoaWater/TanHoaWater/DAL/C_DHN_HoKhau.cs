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
    class C_DHN_HoKhau
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_DHN_HoKhau).Name);
        static TanHoaDataContext db = new TanHoaDataContext();
        public static List<DB_HOKHAU> finbySoHoKhau(string sohokhau)
        {
            var query = from p in db.DB_HOKHAUs where p.SOHOKHAU == sohokhau select p;
            return query.ToList();
        }

       
        public static DataTable finbySoDanhBo(string sodanhbo)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT  SOHOKHAU,SONHANKHAU, GHICHU FROM  DB_HOKHAU WHERE  SODANHBO='" + sodanhbo + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            db.Connection.Close();
            return table;
        }
        public static void Delete(string sodanhbo)
        { 
          
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = " DELETE FROM DB_HOKHAU WHERE SODANHBO='" + sodanhbo + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteScalar();
            conn.Close();
          
        }
        public static void Insert(DB_HOKHAU db_hk) {

            try
            {
                db.DB_HOKHAUs.InsertOnSubmit(db_hk);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error("" + ex.Message);
            }
        }
    }
}
