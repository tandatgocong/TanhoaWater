using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TanHoaWater.Database;
using System.Data.SqlClient;
using log4net;

namespace TanHoaWater.DAL
{
    public class C_DONKHACHHANG
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_DONKHACHHANG).Name);
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
         public static DON_KHACHHANG findBySOHOSO(string sohoso)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from don in db.DON_KHACHHANGs where don.SOHOSO == sohoso select don;
            return data.SingleOrDefault();
        }
        public static bool InsertDonHK(DON_KHACHHANG donkh) {
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
