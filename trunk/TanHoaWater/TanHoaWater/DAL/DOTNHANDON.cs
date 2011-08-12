using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using System.Data;
using System.Data.SqlClient;

namespace TanHoaWater.DAL
{
    public class DOTNHANDON
    {
        public static DOT_NHAN_DON findByMaDot(string madot)
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var dotnhandon = from query in data.DOT_NHAN_DONs where query.MADOT == madot select query;
            return dotnhandon.SingleOrDefault();
        }
        public static bool InsertDot(DOT_NHAN_DON dnd)
        {
            try
            {
                TanHoaDataContext data = new TanHoaDataContext();
                data.DOT_NHAN_DONs.InsertOnSubmit(dnd);
                data.SubmitChanges();
            }
            catch (Exception)
            { }

            return false;
        }
        public static DataTable getList()
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT MADOT , NGAYLAPDON, TENLOAI,";
            sql += " CASE WHEN CHUYENDON='False' THEN N'Chưa chuyển'  WHEN CHUYENDON='True' THEN N'Đã chuyển' ELSE N'Chuyển 1 phần'   END as 'CHUYEN'";
            sql += " FROM DOT_NHAN_DON dot, LOAI_HOSO loai";
            sql += " WHERE loai.MALOAI = dot.LOAIDON";           
            sql += " ORDER BY NGAYLAPDON DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public static DataTable Search(string madot, DateTime ngaylap, string maloai)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT MADOT , NGAYLAPDON, TENLOAI,";
            sql += " CASE WHEN CHUYENDON='False' THEN N'Chưa chuyển'  WHEN CHUYENDON='True' THEN N'Đã chuyển' ELSE N'Chuyển 1 phần'   END as 'CHUYEN'";
            sql += " FROM DOT_NHAN_DON dot, LOAI_HOSO loai";
            sql += " WHERE loai.MALOAI = dot.LOAIDON";
            if (madot.Length == 9) {
                sql += " AND dot.MADOT = '" + madot + "'";
            }
            if (!"1/1/0001".Equals(ngaylap.ToShortDateString())){
                sql += " AND dot.NGAYLAPDON = '" + ngaylap.ToShortDateString() + "'";
            }
            if (!"".Equals(maloai)) {
                sql += " AND dot.LOAIDON = '" + maloai + "'";            
            }
            
            sql += " ORDER BY NGAYLAPDON DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
