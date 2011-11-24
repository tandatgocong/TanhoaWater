using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TanHoaWater.Database;
using System.Data.SqlClient;

namespace TanHoaWater.DAL
{
    class C_TimKiemDonKhachHang
    {
        public static DataTable TimBienNhan(string shs, string hoten, string diachi)
        {
            string sql = "SELECT  biennhan.SHS, biennhan.HOTEN,( SONHA +'  '+DUONG+',  P.'+ p.TENPHUONG+',  Q.'+q.TENQUAN) as 'DIACHI',CONVERT(VARCHAR(20),biennhan.NGAYNHAN,103) AS 'NGAYNHAN',lhs.TENLOAI as 'LOAIHS' ";
            sql += " FROM QUAN q,PHUONG p,BIENNHANDON biennhan, LOAI_HOSO lhs ";
            sql += " WHERE biennhan.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN  AND biennhan.PHUONG=p.MAPHUONG AND lhs.MALOAI=biennhan.LOAIDON";
            if (!"".Equals(shs))
            {
                sql += " AND biennhan.SHS = '" + shs + "'";
            }
            if (!"".Equals(hoten))
            {
                sql += " AND HOTEN LIKE N'%" + hoten + "%'";
            }
            if (!"".Equals(diachi))
            {
                sql += " AND ( SONHA +'  '+DUONG+',  P.'+ p.TENPHUONG+',  Q.'+q.TENQUAN) LIKE N'%" + diachi + "%'";
            }
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            db.Connection.Close();
            return table;
        }
    }
}