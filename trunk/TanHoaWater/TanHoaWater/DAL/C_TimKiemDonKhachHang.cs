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
        public static DataTable TimBienNhan(string shs, string hoten, string diachi, int FirstRow, int pageSize)
        {
            string sql = "SELECT  biennhan.SHS, biennhan.HOTEN,( SONHA +'  '+DUONG+',  P.'+ p.TENPHUONG+',  Q.'+q.TENQUAN) as 'DIACHI', DIENTHOAI ,CONVERT(VARCHAR(20),biennhan.NGAYNHAN,103) AS 'NGAYNHAN',lhs.TENLOAI as 'LOAIHS' ";
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
                sql += " AND  replace(( SONHA +'  '+DUONG+',  P.'+ p.TENPHUONG+',  Q.'+q.TENQUAN),' ','')  LIKE N'%" + diachi.Replace(" ", "") + "%'";
            }
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, FirstRow, pageSize, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }

        public static int TotalRecord(string shs, string hoten, string diachi)
        {
            string sql = "SELECT COUNT(*) ";
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
                sql += " AND  replace(( SONHA +'  '+DUONG+',  P.'+ p.TENPHUONG+',  Q.'+q.TENQUAN),' ','')  LIKE N'%" + diachi.Replace(" ", "") + "%'";
            }
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
             
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }
        

        public static DataTable TimDonKH(string shs, string hoten, string diachi, int FirstRow, int pageSize)
        {
            string sql = "SELECT  biennhan.SHS, biennhan.HOTEN,( SONHA +'  '+DUONG+',  P.'+ p.TENPHUONG+',  Q.'+q.TENQUAN) as 'DIACHI',DIENTHOAI ,CONVERT(VARCHAR(20),biennhan.NGAYNHAN,103) AS 'NGAYNHAN',lhs.TENLOAI as 'LOAIHS' ";
            sql += " FROM QUAN q,PHUONG p,DON_KHACHHANG biennhan, LOAI_HOSO lhs ";
            sql += " WHERE biennhan.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN  AND biennhan.PHUONG=p.MAPHUONG AND lhs.MALOAI=biennhan.LOAIHOSO";
            if (!"".Equals(shs))
            {
              //  sql += " AND biennhan.SHS = '" + shs + "'";
                sql += " AND (biennhan.SHS = '" + shs + "' OR biennhan.HOSOCHA = '" + shs + "' )";
            }
            if (!"".Equals(hoten))
            {
                sql += " AND HOTEN LIKE N'%" + hoten + "%'";
            }
            if (!"".Equals(diachi))
            {
                sql += " AND  replace(( SONHA +'  '+DUONG+',  P.'+ p.TENPHUONG+',  Q.'+q.TENQUAN),' ','')  LIKE N'%" + diachi.Replace(" ", "") + "%'";
            }
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, FirstRow, pageSize, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }

        public static int TotalTimDonKH(string shs, string hoten, string diachi)
        {
            string sql = "SELECT COUNT(*) ";
            sql += " FROM QUAN q,PHUONG p,DON_KHACHHANG biennhan, LOAI_HOSO lhs ";
            sql += " WHERE biennhan.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN  AND biennhan.PHUONG=p.MAPHUONG AND lhs.MALOAI=biennhan.LOAIHOSO";
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
                sql += " AND  replace(( SONHA +'  '+DUONG+',  P.'+ p.TENPHUONG+',  Q.'+q.TENQUAN),' ','')  LIKE N'%" + diachi.Replace(" ","") + "%'";
            }
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }
    }
}