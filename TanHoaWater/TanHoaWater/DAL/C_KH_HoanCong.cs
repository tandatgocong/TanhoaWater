using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using TanHoaWater.Database;
using System.Data;
using System.Data.SqlClient;

namespace TanHoaWater.DAL
{
    class C_KH_HoanCong
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_KH_HoanCong).Name);
        static TanHoaDataContext db = new TanHoaDataContext();       
        
        public static DataTable getListThiCongbyDot(string dottc, bool chuyehoancong)
        {
            db.Connection.Open();
            string sql = " SELECT  donkh.SHS,HOTEN,(SONHA +' '+ DUONG+', P.'+TENPHUONG +', Q.'+TENQUAN) AS 'DIACHI' ";
	        sql += " FROM DON_KHACHHANG donkh, PHUONG p, QUAN q, KH_HOSOKHACHHANG hosokh";
            sql += " WHERE donkh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND donkh.PHUONG=p.MAPHUONG  ";
            sql += " AND donkh.SHS = hosokh.SHS AND hosokh.MADOTTC='" + dottc + "' ";
          
            if(chuyehoancong==false)
			    sql += " AND (hosokh.CHUYENHOANCONG IS NULL OR hosokh.CHUYENHOANCONG='False') ";
            else
                sql += " AND hosokh.CHUYENHOANCONG='True'";

            sql += "ORDER BY hosokh.MODIFYDATE ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset,  "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }

        public static void UpdateChuyenHC(string shs) {

            try
            {
                var query = from q in db.KH_HOSOKHACHHANGs where q.SHS == shs select q;
                KH_HOSOKHACHHANG hosokh = query.SingleOrDefault();
                if (hosokh != null)
                {
                    hosokh.CHUYENHOANCONG = true;
                    hosokh.NGAYCHUYENHC = DateTime.Now.Date;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                log.Error("Chuyen Hoan Cong :" + ex.Message);
            }
           
                 
        }

        public static DataTable getListHoanCong(string dottc, int flag)
        {
            string sql = "SELECT  donkh.SHS,HOTEN,(SONHA +' '+ DUONG+', P.'+TENPHUONG +', Q.'+TENQUAN) AS 'DIACHI',hosokh.COTLK,donkh.SOHOADON,donkh.NGAYDONGTIEN, CONVERT(varchar(50), hosokh.NGAYTHICONG,103) as 'NGAYTHICONG', hosokh.CHISO, hosokh.SOTHANTLK,hosokh.HOANCONG, hosokh.CPVATTU, hosokh.CPNHANCONG, hosokh.CPMAYTHICONG,hosokh.TAILAPMATDUONG  ";
             sql += " FROM DON_KHACHHANG donkh, PHUONG p, QUAN q, KH_HOSOKHACHHANG hosokh ";
             sql += " WHERE donkh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND donkh.PHUONG=p.MAPHUONG  ";
             sql += "  AND donkh.SHS = hosokh.SHS AND hosokh.CHUYENHOANCONG='True' AND hosokh.MADOTTC='" + dottc + "'";
             
            // flag = -1: chua hoan cong
            // flag = 1: da hoan cong
            // flag = 0: ta ca

            if(flag==-1)
                sql += " AND (hosokh.HOANCONG IS NULL OR hosokh.HOANCONG='False') ";
            else if(flag==1)
                sql += " AND hosokh.HOANCONG='True'";            
           
            db.Connection.Open();
            sql += " ORDER BY hosokh.MODIFYDATE";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }
        public static void HoanCong(string shs, DateTime ngaytc, int chiso, string sotlk, bool hoancong) {
            try
            {
                var query = from q in db.KH_HOSOKHACHHANGs where q.SHS == shs select q;
                KH_HOSOKHACHHANG hosokh = query.SingleOrDefault();
                if (hosokh != null)
                {
                    hosokh.NGAYTHICONG = ngaytc;
                    hosokh.CHISO = chiso;
                    hosokh.SOTHANTLK = sotlk;
                    if (hoancong == true)
                    {
                        hosokh.HOANCONG = true;
                        hosokh.NGAYHOANCONG = DateTime.Now.Date;
                    }
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                log.Error("Chuyen Hoan Cong :" + ex.Message);
            }
        }
        public static void CapNhat()
        {
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error("Chuyen Hoan Cong :" + ex.Message);
            }
        }
        
    }
}
