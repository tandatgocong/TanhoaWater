using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using TanHoaWater.Utilities;

namespace TanHoaWater.DAL
{
    class C_TenDuong
    {
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
            string sql = "  SELECT DUONG, TENPHUONG, TENQUAN ";
            sql += " FROM QUAN q, PHUONG p, TENDUONG d ";
            sql += " WHERE d.MAPHUONG=p.MAPHUONG AND p.MAQUAN=q.MAQUAN  AND d.MAQUAN=q.MAQUAN";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, FirstRow, pageSize, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];

        }
    }
}