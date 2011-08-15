using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TanHoaWater.Database;
using System.Data.SqlClient;

namespace TanHoaWater.DAL
{
    public class DONKHACHHANG
    {
        public static DataTable  getListbyDot(string dot) {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT SOHOSO,HOTEN, (SONHA +' '+ DUONG +', P.'+p.TENPHUONG+', Q.'+ q.TENQUAN ) as 'DIACHI',NGAYNHAN, lkh.TENLOAI as 'LOAIDON' ";
            sql += " FROM DON_KHACHHANG kh,QUAN q,PHUONG p, LOAI_KHACHHANG lkh ";
            sql += " WHERE  kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND lkh.MALOAI=kh.LOAIKH";
            sql += " AND MADOT='" + dot + "'";
            sql += " ORDER BY NGAYNHAN DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        
        }
        public static DataTable BangKeNhanDon(string madot)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT * ";
            sql += " FROM V_DONKHACHHANG ";
            sql += " WHERE  MADOT='" + madot + "'";      
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;

        }
    }
}
