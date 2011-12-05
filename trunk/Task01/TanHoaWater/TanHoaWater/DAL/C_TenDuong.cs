using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using TanHoaWater.Utilities;
using log4net;

namespace TanHoaWater.DAL
{
    class C_TenDuong
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_TenDuong).Name);
        public static List<TENDUONG> getList()
        {

            TanHoaDataContext db = new TanHoaDataContext();
            var query = from duong in db.TENDUONGs select duong;
            return query.ToList();
        }
        public static DataTable getQuanPhuong(string tenduong)
        {

            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT DISTINCT p.TENPHUONG, q.TENQUAN ";
            sql += "  FROM TENDUONG d, PHUONG p, QUAN q ";
            sql += " WHERE d.MAPHUONG = p.MAPHUONG AND d.MAQUAN=q.MAQUAN AND q.MAQUAN =p.MAQUAN";
            sql += " AND replace(d.DUONG,' ','')=N'" + tenduong.Replace(" ", "") + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }
        public static ArrayList getPhuong()
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from phuong in db.PHUONGs select phuong;
            ArrayList list = new ArrayList();
            list.Add(new AddValueCombox("  Chọn Phường  ", ""));
            foreach (var a in data)
            {
                list.Add(new AddValueCombox(a.TENPHUONG, a.MAPHUONG));
            }
            return list;
        }
        public static ArrayList getQuan()
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from quan in db.QUANs select quan;
            ArrayList list = new ArrayList();
            list.Add(new AddValueCombox("  Chọn Quận  ", ""));
            foreach (var a in data)
            {
                list.Add(new AddValueCombox(a.TENQUAN, a.MAQUAN + ""));
            }
            return list;
        }
        public static DataTable getListDuong(string tenduong, string maphuong, string maquan, int FirstRow, int pageSize)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = "  SELECT STT, DUONG, TENPHUONG, TENQUAN ";
            sql += " FROM QUAN q, PHUONG p, TENDUONG d ";
            sql += " WHERE d.MAPHUONG=p.MAPHUONG AND p.MAQUAN=q.MAQUAN  AND d.MAQUAN=q.MAQUAN";
            if ("".Equals(tenduong) == false) {
                sql += " AND DUONG LIKE N'%" + tenduong + "%'";
            }
            if ("".Equals(maphuong) == false)
            {
                sql += " AND p.TENPHUONG LIKE N'%" + maphuong + "%'";
            
            }
            if ("".Equals(maquan) == false)
            {
                sql += " AND q.MAQUAN = '" + maquan.Trim() + "'";
            }
            sql += " ORDER BY TENPHUONG ASC ";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, FirstRow, pageSize, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];

        }

        public static int TotalListDuong(string tenduong, string maphuong, string maquan)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = "  SELECT COUNT(*) ";
            sql += " FROM QUAN q, PHUONG p, TENDUONG d ";
            sql += " WHERE d.MAPHUONG=p.MAPHUONG AND p.MAQUAN=q.MAQUAN  AND d.MAQUAN=q.MAQUAN";
            if ("".Equals(tenduong) == false)
            {
                sql += " AND DUONG LIKE N'%" + tenduong + "%'";
            }
            if ("".Equals(maphuong) == false)
            {
                sql += " AND p.TENPHUONG LIKE N'%" + maphuong + "%'";
            }
            if ("".Equals(maquan) == false)
            {
                sql += " AND q.MAQUAN ='" + maquan.Trim() + "'";
            }
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }
        public static TENDUONG findbyDuong(string tenduong, string maphuong, int maquan)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var query = from duong in db.TENDUONGs where duong.DUONG == tenduong && duong.MAPHUONG == maphuong && duong.MAQUAN == maquan select duong;
            return query.SingleOrDefault();
        }
        public static bool InsertDuong(TENDUONG duong)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.TENDUONGs.InsertOnSubmit(duong);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Them Ten Duong Loi " + ex.Message);                
            }
            return false;
        }
        public static bool UpdateDuong(int id, string tenduong, string maphuong, int maquan)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var query = from duong in db.TENDUONGs where duong.STT ==id select duong;
            TENDUONG tDuong = query.SingleOrDefault();
            if (tDuong != null)
            {
                try
                {
                    tDuong.DUONG = tenduong;
                    tDuong.MAPHUONG = maphuong;
                    tDuong.MAQUAN = maquan;
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    log.Error("Cap Nhat Ten Duong Loi " + ex.Message);
                }
            }
            return false;
        }
        public static bool Delete(int id)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var query = from duong in db.TENDUONGs where duong.STT == id select duong;
            TENDUONG tDuong = query.SingleOrDefault();
            if (tDuong != null)
            {
                try
                {
                    db.TENDUONGs.DeleteOnSubmit(tDuong);
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    log.Error("Xoa Ten Duong Loi " + ex.Message);                     
                }
            }
            return false;
        }
    }
}