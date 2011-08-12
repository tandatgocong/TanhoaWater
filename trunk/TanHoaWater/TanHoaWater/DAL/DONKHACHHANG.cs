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
        public DataTable  getListbyDot(string dot) {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT SOHOSO , NGAYLAPDON, TENLOAI,";           
            sql += " FROM DOT_NHAN_DON dot, LOAI_HOSO loai";
            sql += " WHERE loai.MALOAI = dot.LOAIDON";
            sql += " ORDER BY NGAYLAPDON DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        
        }
    }
}
