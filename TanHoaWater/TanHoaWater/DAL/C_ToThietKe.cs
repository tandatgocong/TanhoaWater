using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using log4net;
using System.Data.SqlClient;
using System.Data;

namespace TanHoaWater.DAL
{
    public class C_ToThietKe
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_ToThietKe).Name);
        public static void addNew(TOTHIETKE ttk)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.TOTHIETKEs.InsertOnSubmit(ttk);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error("TTK Add New" + ex.Message);
            }

        }
        public static DataTable DanhSachChuyen(string dotND)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT ttk.MADOT,ttk.SOHOSO,HOTEN,(SONHA +' '+ DUONG +', P.'+p.TENPHUONG+', Q.'+ q.TENQUAN ) as 'DIACHI', NGAYNHAN= CONVERT(VARCHAR(10),kh.NGAYNHAN,103), lhs.TENLOAI ";
            sql += " FROM TOTHIETKE ttk, DON_KHACHHANG kh,QUAN q,PHUONG p, LOAI_HOSO lhs ";
            sql += " WHERE  kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND lhs.MALOAI=kh.LOAIHOSO AND ttk.SOHOSO=kh.SOHOSO ";
            sql += " AND ttk.MADOT='" + dotND + "'";        
            sql += " ORDER BY NGAYNHAN DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset,"TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }
        public static DataTable DachSachHoSoGiaoViec(string dotND, string ngaynhan, string SODOVIEN)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT ttk.MADOT,ttk.SHS,HOTEN,(SONHA +' '+ DUONG +', P.'+p.TENPHUONG+', Q.'+ q.TENQUAN ) as 'DIACHI', NGAYNHAN= CONVERT(VARCHAR(10),kh.NGAYNHAN,103), lhs.TENLOAI, p.TENPHUONG, q.TENQUAN, DUONG, SONHA  ";
            sql += " FROM TOTHIETKE ttk, DON_KHACHHANG kh,QUAN q,PHUONG p, LOAI_HOSO lhs ";
            sql += " WHERE  kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND lhs.MALOAI=kh.LOAIHOSO AND ttk.SOHOSO=kh.SOHOSO ";
            if (dotND != null) {
                sql += " AND ttk.MADOT='" + dotND + "'";
            }
            if (ngaynhan != null) {
                sql += " AND CONVERT(VARCHAR(10),ttk.NGAYNHAN,103)='" + ngaynhan + "'";
            }
            if (SODOVIEN != null)
            {
                sql += " AND ttk.SODOVIEN='" + SODOVIEN + "'";
            }
            else
            {
                sql += " AND ttk.SODOVIEN IS NULL ";
            }
            sql += " AND BOPHANCHUYEN='TTK'";
            sql += " ORDER BY q.TENQUAN,p.TENPHUONG,DUONG,SONHA DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }
        public static void giaoviecSDV(string sohs, string sodovien, string nguoigiao) {
            TanHoaDataContext db = new TanHoaDataContext();
            var giaoviec = from ttk in db.TOTHIETKEs where ttk.SHS == sohs select ttk;
            TOTHIETKE totk = giaoviec.SingleOrDefault();
            if (totk != null) {
                totk.SODOVIEN = sodovien;
                totk.NGAYGIAOSDV = DateTime.Now.Date;
                totk.MODIFYBY = nguoigiao;
                totk.MODIFYDATE = DateTime.Now;
                totk.TRAHS = false;
            }
            db.SubmitChanges();
        }
        public static DataSet BC_GIAOHS_SDV(string dotND, string ngaynhan, string SODOVIEN, string nguoilap)
        {

            DataSet ds = new DataSet();
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = "SELECT * FROM V_DANHSACH_HS_SDV ";
            sql += " WHERE SODOVIEN='" + SODOVIEN + "'";
            if (dotND != null)
            {
                sql += " AND MADOT='" + dotND + "'";
            }
            if (ngaynhan != null)
            {
                sql += " AND NGAYNHAN ='" + ngaynhan + "'";
            }
            sql += " ORDER BY QUAN,PHUONG,DUONG,SONHA DESC ";
            SqlDataAdapter dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            dond.Fill(ds, "V_DANHSACH_HS_SDV");

            string user = "SELECT USERNAME, UPPER(FULLNAME) AS 'FULLNAME' FROM USERS WHERE USERNAME='" + nguoilap + "'";
            SqlDataAdapter ct = new SqlDataAdapter(user, db.Connection.ConnectionString);
            ct.Fill(ds, "USERS");
            return ds;
        }

        public static bool TraHS(string sohoso, string noidungtrongai) {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var query = from ttk in db.TOTHIETKEs where ttk.SOHOSO == sohoso select ttk;
                TOTHIETKE totk = query.SingleOrDefault();
                if (totk != null) {
                    totk.TRAHS = true;
                    totk.NGAYTRAHS = DateTime.Now;
                    totk.TRONGAITHIETKE = true;
                    totk.NOIDUNGTRONGAI = noidungtrongai;
                    db.SubmitChanges();
                    return true;
                }
               
            }
            catch (Exception ex)
            {
                log.Error("Loi khi chuyen hs" + ex.Message);
                
            }
            return false;
        }

        public static TOTHIETKE findBySoHoSo(string sohoso) {
            TanHoaDataContext db = new TanHoaDataContext();
            var ttk = from query in db.TOTHIETKEs where query.SOHOSO == sohoso select query;
            return ttk.SingleOrDefault();
        }
        public static DataTable TinhHinhKSTK(string madot, string tungay, string denngay, string tensdv, bool tinhtrang) { 
        
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT ttk.MADOT,ttk.SHS,HOTEN,(SONHA +' '+ DUONG +', P.'+p.TENPHUONG+', Q.'+ q.TENQUAN ) as 'DIACHI', NGAYNHAN= CONVERT(VARCHAR(10),kh.NGAYNHAN,103), lhs.TENLOAI, p.TENPHUONG, q.TENQUAN, DUONG, SONHA  ";
            sql += " FROM TOTHIETKE ttk, DON_KHACHHANG kh,QUAN q,PHUONG p, LOAI_HOSO lhs ";
            sql += " WHERE  kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND lhs.MALOAI=kh.LOAIHOSO AND ttk.SOHOSO=kh.SOHOSO ";
            if (madot != null) {
                sql += " AND ttk.MADOT='" + madot + "'";
            }
            if (tungay != null)
            {
               // sql += " AND CONVERT(VARCHAR(10),ttk.NGAYGIAOSDV,103)>='" + tungay + "' AND CONVERT(VARCHAR(10),ttk.NGAYGIAOSDV,103)<='" + denngay + "' ";
                sql += " AND CONVERT(DATETIME,ttk.NGAYGIAOSDV,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";
            }
            if (tensdv != null)
            {
                sql += " AND ttk.SODOVIEN='" + tensdv + "'";
            }

            sql += " AND ttk.TRAHS='" + tinhtrang + "'";
            sql += " ORDER BY q.TENQUAN,p.TENPHUONG,DUONG,SONHA DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];        
        }
        public static int CountTinhHinhKSTK(string madot, string tungay, string denngay, string tensdv, bool tinhtrang)
        {
            string sql = " SELECT COUNT(*)  ";
            sql += " FROM TOTHIETKE ttk, DON_KHACHHANG kh,QUAN q,PHUONG p, LOAI_HOSO lhs ";
            sql += " WHERE  kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND lhs.MALOAI=kh.LOAIHOSO AND ttk.SOHOSO=kh.SOHOSO ";
            if (madot != null)
            {
                sql += " AND ttk.MADOT='" + madot + "'";
            }
            if (tungay != null)
            {
                sql += " AND CONVERT(DATETIME,ttk.NGAYGIAOSDV,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";
                //sql += " AND CONVERT(VARCHAR(10),ttk.NGAYGIAOSDV,103)>='" + tungay + "' AND CONVERT(VARCHAR(10),ttk.NGAYGIAOSDV,103)<='" + denngay + "' ";
            }
            if (tensdv != null)
            {
                sql += " AND ttk.SODOVIEN='" + tensdv + "'";
            }

            sql += " AND ttk.TRAHS='" + tinhtrang + "'";      
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();            
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }
        public static DataSet BC_TinhHinhKSTK(string madot, string tungay, string denngay, string tensdv, string nguoilap)
        {

            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT *, NGAYBT='" + tungay + "', NGAYKT='" + denngay + "'  ";
            sql += " FROM  V_BC_KSTK ";
            sql += " WHERE SODOVIEN='" + tensdv + "'";
            if (madot != null)
            {
                sql += " AND MADOT='" + madot + "'";
            }
            if (tungay != null)
            {
                //sql += " AND CONVERT(VARCHAR(10),NGAYGIAOSDV,103)>='" + tungay + "' AND CONVERT(VARCHAR(10),NGAYGIAOSDV,103)<='" + denngay + "' ";
                sql += " AND CONVERT(DATETIME,NGAYGIAOSDV,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";
            }
            
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "V_BC_KSTK");

            string user = "SELECT USERNAME, UPPER(FULLNAME) AS 'FULLNAME' FROM USERS WHERE USERNAME='" + nguoilap + "'";
            SqlDataAdapter ct = new SqlDataAdapter(user, db.Connection.ConnectionString);
            ct.Fill(dataset, "USERS");

            db.Connection.Close();
            return dataset;
        }
               
        public static DataTable  DANHSACHDOTNHANDON() { 
        
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = "  SELECT DISTINCT MADOT FROM TOTHIETKE ";            
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];        
        }

       
    }
}