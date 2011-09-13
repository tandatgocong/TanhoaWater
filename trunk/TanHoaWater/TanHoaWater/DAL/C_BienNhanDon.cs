using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using TanHoaWater.Database;
using System.Data;
using System.Data.SqlClient;
namespace TanHoaWater.DAL
{
    class C_BienNhanDon
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_BienNhanDon).Name);
        public static void InsertBienNhanDon(BIENNHANDON bn) {
            TanHoaDataContext db = new TanHoaDataContext();
            db.BIENNHANDONs.InsertOnSubmit(bn);
            db.SubmitChanges();
        }
        public static DataSet printBienNhan(string soshs, string user) {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT * FROM V_BIENNHANDON ";
            sql += " WHERE SHS='" + soshs + "' AND USERNAME='" + user + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "V_BIENNHANDON");
            db.Connection.Close();
            return dataset;
        }
        public static BIENNHANDON finbyMaBienNhan(string mabn) {
            TanHoaDataContext db = new TanHoaDataContext();
            var query = from biennhan in db.BIENNHANDONs where biennhan.SHS== mabn select biennhan;
            return query.SingleOrDefault();
        }
        public static DataTable BaoCaoTinhHinhNhanDon(string tungay, string denngay) {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT TENQUAN,TENLOAI, COUNT(*) as 'SOHS' ";
            sql += " FROM BIENNHANDON bn, QUAN q,LOAI_NHANDON lhs ";
            sql += " WHERE bn.QUAN=q.MAQUAN AND lhs.LOAIDON=bn.LOAIDON ";
            sql += " AND CONVERT(DATETIME,NGAYNHAN,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";
            sql += " GROUP BY TENQUAN,TENLOAI ";
            sql += "ORDER BY TENQUAN DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];   
        }
        public static DataSet ViewBaoCao(string tungay, string denngay) {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT TENQUAN,TENLOAI, COUNT(*) as 'SOHS', TUNGAY='" + tungay + "', DENNGAY='" + denngay + "' ";
            sql += " FROM BIENNHANDON bn, QUAN q,LOAI_NHANDON lhs ";
            sql += " WHERE bn.QUAN=q.MAQUAN AND lhs.LOAIDON=bn.LOAIDON ";
            sql += " AND CONVERT(DATETIME,NGAYNHAN,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";
            sql += " GROUP BY TENQUAN,TENLOAI ";
            sql += "ORDER BY TENQUAN DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "V_BAOCAO_NHANDON");
            db.Connection.Close();
            return dataset;   
        }
        public static int totalDon(string tungay, string denngay)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = " SELECT COUNT(*) ";
            sql += " FROM BIENNHANDON bn, QUAN q,LOAI_NHANDON lhs ";
            sql += " WHERE bn.QUAN=q.MAQUAN AND lhs.LOAIDON=bn.LOAIDON ";
            sql += " AND CONVERT(DATETIME,NGAYNHAN,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";           
             SqlCommand cmd = new SqlCommand(sql, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }
    }
}
