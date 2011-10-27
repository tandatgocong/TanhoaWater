using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using TanHoaWater.Database;
using System.Data.SqlClient;
using System.Data;

namespace TanHoaWater.DAL
{
    
    class C_KH_HoSoKhachHang
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_KH_HoSoKhachHang).Name);
       
        public static int TotalList(string sodotxp)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = " SELECT COUNT(*) ";
            sql += "  FROM DON_KHACHHANG DKH, PHUONG P, QUAN Q, KH_HOSOKHACHHANG HS ";
            sql += " WHERE DKH.PHUONG=P.MAPHUONG AND DKH.QUAN=Q.MAQUAN AND HS.SHS = DKH.SHS AND HS.MADOTDD='" + sodotxp + "'";       
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }

        public static DataTable getListHSbyDot(string sodotxp)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT DKH.SHS, HOTEN, SONHA + ' ' + DUONG as 'DIACHI', TENPHUONG, HS.GHICHU, N'Hủy' as 'HUY' ";
            sql += "  FROM DON_KHACHHANG DKH, PHUONG P, QUAN Q, KH_HOSOKHACHHANG HS ";
            sql += " WHERE DKH.QUAN = Q.MAQUAN AND Q.MAQUAN=P.MAQUAN AND DKH.PHUONG=p.MAPHUONG AND HS.SHS = DKH.SHS AND HS.MADOTDD='" + sodotxp + "'";
            sql += " ORDER BY DKH.NGAYNHAN DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }
        public static KH_HOSOKHACHHANG findBySHS(string shs) {
            TanHoaDataContext db = new TanHoaDataContext();
            var obj = from dd in db.KH_HOSOKHACHHANGs where dd.MADOT == shs select dd;
            return obj.SingleOrDefault();
        }
        public static bool Delete(string shs) {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var obj = from dd in db.KH_HOSOKHACHHANGs where dd.SHS == shs select dd;
                db.KH_HOSOKHACHHANGs.DeleteOnSubmit(obj.SingleOrDefault());
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Loi Xoa Ke Hoach Ho So Khach Hang " + ex.Message);

            }
            return false;
        }
        public static bool Insert(KH_HOSOKHACHHANG hs_kh) {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.KH_HOSOKHACHHANGs.InsertOnSubmit(hs_kh);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Loi Them Ke Hoach Ho So Khach Hang " + ex.Message);

            }
            return false;
        }
    }
}
