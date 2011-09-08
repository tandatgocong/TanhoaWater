using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using System.Data;
using System.Data.SqlClient;

namespace TanHoaWater.DAL
{
    class C_TenDuong
    {
        public  static List<TENDUONG> getList(){
        
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
            sql += " AND replace(d.DUONG,' ','')=N'" + tenduong.Replace(" ","") + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }
    }
}
