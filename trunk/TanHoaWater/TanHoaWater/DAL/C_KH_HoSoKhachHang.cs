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
            sql += " WHERE DKH.QUAN = Q.MAQUAN AND Q.MAQUAN=P.MAQUAN AND DKH.PHUONG=p.MAPHUONG AND HS.SHS = DKH.SHS AND  HS.MADOTDD=REPLACE('" + sodotxp + "',' ','') ";
            sql += " ORDER BY DKH.NGAYNHAN DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }
        static  TanHoaDataContext db = new TanHoaDataContext();
        public static KH_HOSOKHACHHANG findBySHS(string shs)
        {
            
            var obj = from dd in db.KH_HOSOKHACHHANGs where dd.SHS == shs select dd;
            return obj.SingleOrDefault();
        }
        public static bool HuyDaoDuong(string shs) {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var obj = from dd in db.KH_HOSOKHACHHANGs where dd.SHS == shs select dd;
                KH_HOSOKHACHHANG hskh = obj.SingleOrDefault();
                if (hskh != null) {
                    hskh.MADOTDD = null;
                    hskh.CHOPHEP=null;
                    hskh.NGAYCOPHEP=null;
                
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Huy Dao Duong Loi" + ex.Message);

            }
            return false;
        }
        public static bool HuyDotTC(string shs)
        {
            try
            {
               
                var obj = from dd in db.KH_HOSOKHACHHANGs where dd.SHS == shs select dd;
                KH_HOSOKHACHHANG hskh = obj.SingleOrDefault();
                if (hskh != null)
                {
                    hskh.MADOTTC = null;
                    hskh.TRONGAI = null;
                    hskh.NOIDUNGTN = null;
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Huy Dao Duong Loi" + ex.Message);

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

        public static bool Update()
        {
            try
            {

               db.SubmitChanges();
               
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Loi Them Ke Hoach Ho So Khach Hang " + ex.Message);

            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sodotxp"></param>
        /// <returns></returns>
        /// 
        public static int countSoThanTLK(string sodotxp)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = " SELECT COUNT(*) ";
            sql += "  FROM DON_KHACHHANG  ";
            sql += " WHERE SOTHANTLK='" + sodotxp + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }

        public static int countSoHopDong(string sohopdong)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = " SELECT COUNT(*) ";
            sql += "  FROM KH_HOSOKHACHHANG  ";
            sql += " WHERE DHN_SOHOPDONG='" + sohopdong + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }



        public static List<KH_HOSOKHACHHANG> ListSoThanTLK(string sodotxp, string shs)
        {
            //SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            //conn.Open();
            //string sql = " SELECT COUNT(*) ";
            //sql += "  FROM KH_HOSOKHACHHANG  ";
            //sql += " WHERE SOTHANTLK='" + sodotxp + "' AND SHS <> '"+shs+"'";
            //SqlCommand cmd = new SqlCommand(sql, conn);
            //int result = Convert.ToInt32(cmd.ExecuteScalar());
            //conn.Close();
            //return result;

            var obj = from dd in db.KH_HOSOKHACHHANGs where dd.SHS == shs && dd.SOTHANTLK==sodotxp select dd;
            return obj.ToList();

        }
        
        public static int checkSoDanhBo(string sodanhbo)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = " SELECT COUNT(*) ";
            sql += "  FROM KH_HOSOKHACHHANG  ";
            sql += " WHERE DHN_SODANHBO='" + sodanhbo + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }

        public static int checkCoDotTC(string shs)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = " SELECT COUNT(*) FROM KH_HOSOKHACHHANG WHERE SHS='" + shs + "' AND (MADOTTC IS NOT NULL OR MADOTTC='') ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }
        

    }
}
