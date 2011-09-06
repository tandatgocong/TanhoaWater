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
    class C_DanhMucTaiLapMD
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_DanhMucVatTu).Name);
        public static List<DANHMUCTAILAPMATDUONG> getList()
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var list = from dm in db.DANHMUCTAILAPMATDUONGs select dm;
            return list.ToList();
        }
        public static DANHMUCTAILAPMATDUONG finbyMaDM(string madanhmuc)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var danhmuc = from dmvt in db.DANHMUCTAILAPMATDUONGs where dmvt.MADANHMUC == madanhmuc select dmvt;
            return danhmuc.SingleOrDefault();
        }
        public static bool InsertDanhMucTLMD(DANHMUCTAILAPMATDUONG dm)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.DANHMUCTAILAPMATDUONGs.InsertOnSubmit(dm);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Insert Danh Muc Tai Lap Mat Duong Loi. " + ex.Message);
            }
            return false;
        }
        public static bool UpdateDanhMucTLMD(string madanhmuc, string tenketcau, string dvt, double dongia, int sodongia, string modibyBy)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var query = from vt in db.DANHMUCTAILAPMATDUONGs where vt.MADANHMUC == madanhmuc select vt;
                DANHMUCTAILAPMATDUONG dmvt = query.SingleOrDefault();
                if (dmvt != null)
                {
                    dmvt.TENKETCAU = tenketcau;
                    dmvt.DVT = dvt;
                    dmvt.DONGIA = dongia;
                    dmvt.DONGIASO = sodongia;
                    dmvt.MODIFYBY = modibyBy;
                    dmvt.MODIFYDATE = DateTime.Now.Date;
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Update Danh Muc Tai Lap Mat Duong Loi Loi. " + ex.Message);
            }
            return false;
        }
        public static bool DeleteDanhMucTLMD(DANHMUCTAILAPMATDUONG vt)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var danhmuc = from dmvt in db.DANHMUCTAILAPMATDUONGs where dmvt.MADANHMUC == vt.MADANHMUC select dmvt;
                db.DANHMUCTAILAPMATDUONGs.DeleteOnSubmit(danhmuc.SingleOrDefault());
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Delete  Danh Muc Tai Lap Mat Duong Loi. " + ex.Message);
            }
            return false;
        }

        public static DataTable search(string madanhmuc, string tenketcau, string dvt,  int FirstRow, int pageSize)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT  MADANHMUC, TENKETCAU = UPPER(TENKETCAU)  , DVT, DONGIA, DONGIASO ";
            sql += " FROM DANHMUCTAILAPMATDUONG ";
            sql += " WHERE TENKETCAU IS NOT NULL ";

            if (!"".Equals(madanhmuc))
            {
                sql += " AND MADANHMUC = N'%" + madanhmuc + "%'";
            }
            if (!"".Equals(tenketcau))
            {
                sql += " AND TENKETCAU LIKE N'%" + tenketcau + "%'";
            }
            if (!"".Equals(dvt))
            {
                sql += " AND DVT = N'" + dvt + "'";
            }
            sql += " ORDER BY MADANHMUC ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, FirstRow, pageSize, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }

        public static int TotalSearch(string madanhmuc, string tenketcau, string dvt)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = " SELECT  COUNT(*) ";
            sql += " FROM DANHMUCTAILAPMATDUONG ";
            sql += " WHERE TENKETCAU IS NOT NULL ";

            if (!"".Equals(madanhmuc))
            {
                sql += " AND MADANHMUC = N'%" + madanhmuc + "%'";
            }
            if (!"".Equals(tenketcau))
            {
                sql += " AND TENKETCAU LIKE N'%" + tenketcau + "%'";
            }
            if (!"".Equals(dvt))
            {
                sql += " AND DVT = N'" + dvt + "'";
            }
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }
        public static DataTable getListDanhMucTLMD()
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT MADANHMUC , (MADANHMUC + ' ______ '+   UPPER(TENKETCAU) ) as 'TENKETCAU'";
            sql += " FROM DANHMUCTAILAPMATDUONG ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            db.Connection.Close();
            return table;
        }

    }
}