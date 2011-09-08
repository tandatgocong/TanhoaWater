using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TanHoaWater.Database;
using System.Data.SqlClient;
using log4net;
using System.Collections;

namespace TanHoaWater.DAL
{
    public class C_DonKhachHang
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_DonKhachHang).Name);
        public static int TotalListByDot(string dot)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = " SELECT COUNT(*) ";
            sql += " FROM DON_KHACHHANG kh,QUAN q,PHUONG p, LOAI_KHACHHANG lkh ";
            sql += " WHERE  kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND lkh.MALOAI=kh.LOAIKH";
            sql += " AND MADOT='" + dot + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }
        public static DataTable getListbyDot(string dot, int FirstRow, int pageSize)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT SOHOSO,HOTEN, (SONHA +' '+ DUONG +', P.'+p.TENPHUONG+', Q.'+ q.TENQUAN ) as 'DIACHI',NGAYNHAN= CONVERT(VARCHAR(10),NGAYNHAN,103), lkh.TENLOAI as 'LOAIDON' ";
            sql += " FROM DON_KHACHHANG kh,QUAN q,PHUONG p, LOAI_KHACHHANG lkh ";
            sql += " WHERE  kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND lkh.MALOAI=kh.LOAIKH";
            sql += " AND MADOT='" + dot + "'";
            sql += " ORDER BY NGAYNHAN DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, FirstRow, pageSize, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];

        }
        public static DataTable getListbyDot(string dot)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT SOHOSO,HOTEN, (SONHA +' '+ DUONG +', P.'+p.TENPHUONG+', Q.'+ q.TENQUAN ) as 'DIACHI',NGAYNHAN= CONVERT(VARCHAR(10),NGAYNHAN,103), lkh.TENLOAI as 'LOAIDON' ";
            sql += " FROM DON_KHACHHANG kh,QUAN q,PHUONG p, LOAI_KHACHHANG lkh ";
            sql += " WHERE  kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND lkh.MALOAI=kh.LOAIKH";
            sql += " AND MADOT='" + dot + "'";
            sql += " ORDER BY NGAYNHAN DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];

        }
        public static DON_KHACHHANG findBySOHOSO(string sohoso)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from don in db.DON_KHACHHANGs where don.SHS == sohoso select don;
            return data.SingleOrDefault();
        }
        public static DON_KHACHHANG findBySOHOSO_(string sohoso)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from don in db.DON_KHACHHANGs where don.SOHOSO == sohoso select don;
            return data.SingleOrDefault();
        }
        public static void chuyenhs(string sohoso)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from don in db.DON_KHACHHANGs where don.SOHOSO == sohoso select don;
            DON_KHACHHANG donKH = data.SingleOrDefault();
            if (donKH != null)
            {
                donKH.CHUYEN_HOSO = true;
                donKH.NGAYCHUYEN_HOSO = DateTime.Now;
            }
            db.SubmitChanges();
        }
        public static void chuyenhs(string sohoso, string nguoichuyen, string pbchuyen)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from don in db.DON_KHACHHANGs where don.SOHOSO == sohoso select don;
            DON_KHACHHANG donKH = data.SingleOrDefault();
            if (donKH != null)
            {
                donKH.CHUYEN_HOSO = true;
                donKH.NGAYCHUYEN_HOSO = DateTime.Now;
                donKH.NGUOICHUYEN_HOSO = nguoichuyen;
                donKH.BOPHANCHUYEN = pbchuyen;
            }
            db.SubmitChanges();
        }
        public static void chuyenhsbydot(string sodot, string nguoichuyen, string pbchuyen)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = " UPDATE DON_KHACHHANG SET CHUYEN_HOSO='True' ";
            sql += ",BOPHANCHUYEN = '" + pbchuyen + "', NGUOICHUYEN_HOSO = '" + nguoichuyen + "', NGAYCHUYEN_HOSO='" + DateTime.Now + "'";
            sql += " WHERE MADOT='" + sodot + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            db.SubmitChanges();
        }

        public static bool InsertDonHK(DON_KHACHHANG donkh)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.DON_KHACHHANGs.InsertOnSubmit(donkh);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Insert Dot KHACH HANG LOI " + ex.Message);
            }
            return false;
        }

        public static bool UpdateDONKH(DON_KHACHHANG donkh)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Update Dot KHACH HANG LOI " + ex.Message);
            }
            return false;
        }
        public static bool DeleteDonKH(string donkh)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var ff = from aa in db.DON_KHACHHANGs where aa.SOHOSO == donkh select aa;
                db.DON_KHACHHANGs.DeleteOnSubmit(ff.SingleOrDefault());
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Delete Dot KHACH HANG LOI " + ex.Message);
            }
            return false;
        }
        public static DataTable BangKeNhanDon(string madot, string nguoilap)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT * ";
            sql += " FROM V_DONKHACHHANG ";
            sql += " WHERE  MADOT='" + madot + "' AND USERNAME='" + nguoilap + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            db.Connection.Close();
            return table;

        }

        public static bool findByAddressAndLoaiHS(string dot, string loaiHS, string sonha, string duong, string phuong, string quan)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            string sql = " SELECT SONHA = replace(SONHA,' ',''), DUONG = replace(DUONG,' ',''),PHUONG,QUAN ";
            sql += " FROM DON_KHACHHANG ";
            sql += " WHERE MADOT='" + dot + "' AND LOAIHOSO='" + loaiHS + "' AND SONHA='" + sonha + "' AND DUONG='" + duong + "' AND PHUONG='" + phuong + "' AND QUAN='" + quan + "' ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            db.Connection.Close();
            if (table.Rows.Count > 0)
                return true;

            return false;
        }

        public static DataTable search(string dotND, string mahs, string tenkh, string sonha, string tenduong, int FirstRow, int pageSize)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT MADOT,SOHOSO,HOTEN,(SONHA +' '+ DUONG +', P.'+p.TENPHUONG+', Q.'+ q.TENQUAN ) as 'DIACHI', NGAYNHAN= CONVERT(VARCHAR(10),NGAYNHAN,103), lhs.TENLOAI ";
            sql += " FROM DON_KHACHHANG kh,QUAN q,PHUONG p, LOAI_HOSO lhs ";
            sql += " WHERE  kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND lhs.MALOAI=kh.LOAIHOSO  ";

            if (dotND != null && !"".Equals(dotND))
            {
                sql += " AND MADOT='" + dotND + "'";
            }
            if (!"".Equals(mahs))
            {
                sql += " AND SHS='" + mahs + "'";
            }
            if (!"".Equals(tenkh))
            {
                sql += " AND HOTEN LIKE '%" + tenkh + "%'";
            }
            if (!"".Equals(sonha))
            {
                sql += " AND SONHA = '" + sonha + "'";
            }
            if (!"".Equals(tenduong))
            {
                sql += " AND DUONG = '" + tenduong + "'";
            }
            sql += " ORDER BY NGAYNHAN DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, FirstRow, pageSize, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }
        public static int TotalPageSearch(string dotND, string mahs, string tenkh, string sonha, string tenduong)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT MADOT,SOHOSO,HOTEN,(SONHA +' '+ DUONG +', P.'+p.TENPHUONG+', Q.'+ q.TENQUAN ) as 'DIACHI', NGAYNHAN= CONVERT(VARCHAR(10),NGAYNHAN,103), lhs.TENLOAI ";
            sql += " FROM DON_KHACHHANG kh,QUAN q,PHUONG p, LOAI_HOSO lhs ";
            sql += " WHERE  kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND lhs.MALOAI=kh.LOAIHOSO  ";

            if (dotND != null && !"".Equals(dotND))
            {
                sql += " AND MADOT='" + dotND + "'";
            }
            if (!"".Equals(mahs))
            {
                sql += " AND SHS='" + mahs + "'";
            }
            if (!"".Equals(tenkh))
            {
                sql += " AND HOTEN LIKE '%" + tenkh + "%'";
            }
            if (!"".Equals(sonha))
            {
                sql += " AND SONHA = '" + sonha + "'";
            }
            if (!"".Equals(tenduong))
            {
                sql += " AND DUONG = '" + tenduong + "'";
            }
            sql += " ORDER BY NGAYNHAN DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0].Rows.Count;
        }

        public static bool TroNgaiThietKe(string sohoso, string lydotrongai, string modifyby)
        {

            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var data = from don in db.DON_KHACHHANGs where don.SOHOSO == sohoso select don;
                DON_KHACHHANG donkh = data.SingleOrDefault();
                if (donkh != null)
                {
                    donkh.TRONGAITHIETKE = true;
                    donkh.NOIDUNGTRONGAI = lydotrongai;
                    donkh.MODIFYBY = DAL.C_USERS._userName;
                    donkh.MODIFYDATE = DateTime.Now.Date;
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Cap nhat tro ngai tk loi " + ex.Message);
            }
            return false;
        }

        public static DataTable finbyDonKHTinhDuToan(string shs)
        {
            string sql = " SELECT ttk.MADOT, ttk.SHS, HOTEN, kh.DIENTHOAI,";
            sql += " SONHA,DUONG,p.TENPHUONG,q.TENQUAN,SOHO,lkh.TENLOAI,DANHBO,lhs.TENLOAI,FULLNAME";// end 12
            sql += " FROM TOTHIETKE ttk, DON_KHACHHANG kh,QUAN q,PHUONG p, LOAI_HOSO lhs, USERS us, LOAI_KHACHHANG lkh ";
            sql += " WHERE kh.LOAIKH=lkh.MALOAI AND  kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND lhs.MALOAI=kh.LOAIHOSO AND ttk.SOHOSO=kh.SOHOSO AND us.USERNAME=ttk.SODOVIEN";
            sql += " AND ttk.SHS ='" + shs +"'";
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