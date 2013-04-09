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
            sql += " AND donkh.SHS = hosokh.SHS AND hosokh.MADOTTC=N'" + dottc + "' ";
          
            if(chuyehoancong==false)
			    sql += " AND (hosokh.CHUYENHOANCONG IS NULL OR hosokh.CHUYENHOANCONG='False') ";
            else
                sql += " AND hosokh.CHUYENHOANCONG='True'";

            sql += "ORDER BY hosokh.STT ASC ";
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
            string sql = "SELECT  donkh.SHS,HOTEN,(SONHA +' '+ DUONG+', P.'+TENPHUONG +', Q.'+TENQUAN) AS 'DIACHI',hosokh.COTLK, CONVERT(varchar(50), hosokh.NGAYTHICONG,103) as 'NGAYTHICONG', hosokh.CHISO, hosokh.SOTHANTLK,hosokh.HIEUDONGHO,hosokh.HOANCONG,donkh.SOHOADON,donkh.NGAYDONGTIEN, hosokh.CPVATTU, hosokh.CPNHANCONG, hosokh.CPMAYTHICONG,hosokh.TONGIATRI ,DHN_NGAYKD ";
             sql += " FROM DON_KHACHHANG donkh, PHUONG p, QUAN q, KH_HOSOKHACHHANG hosokh ";
             sql += " WHERE donkh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND donkh.PHUONG=p.MAPHUONG  ";
             sql += "  AND donkh.SHS = hosokh.SHS AND hosokh.CHUYENHOANCONG='True' AND hosokh.MADOTTC=N'" + dottc + "'";
             
            // flag = -1: chua hoan cong
            // flag = 1: da hoan cong
            // flag = 0: ta ca

            if(flag==-1)
                sql += " AND (hosokh.HOANCONG IS NULL OR hosokh.HOANCONG='False') ";
            else if(flag==1)
                sql += " AND hosokh.HOANCONG='True'";            
           
            db.Connection.Open();
            sql += " ORDER BY hosokh.STT ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }

        public static DataTable getListHoanCong_(string dottc, int flag)
        {
            string sql = "SELECT  donkh.SHS,HOTEN,(SONHA +' '+ DUONG+', P.'+TENPHUONG +', Q.'+TENQUAN) AS 'DIACHI',hosokh.COTLK, CONVERT(varchar(50), hosokh.NGAYTHICONG,103) as 'NGAYTHICONG', hosokh.CHISO, hosokh.SOTHANTLK,hosokh.HIEUDONGHO,hosokh.HOANCONG,donkh.SOHOADON,donkh.NGAYDONGTIEN, hosokh.CPVATTU, hosokh.CPNHANCONG, hosokh.CPMAYTHICONG,hosokh.TONGIATRI ,DHN_NGAYKD ";
            sql += " FROM DON_KHACHHANG donkh, PHUONG p, QUAN q, KH_HOSOKHACHHANG hosokh ";
            sql += " WHERE donkh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND donkh.PHUONG=p.MAPHUONG  ";
            sql += "  AND donkh.SHS = hosokh.SHS  AND hosokh.MADOTTC=N'" + dottc + "'";

            // flag = -1: chua hoan cong
            // flag = 1: da hoan cong
            // flag = 0: ta ca

            if (flag == -1)
                sql += " AND (hosokh.HOANCONG IS NULL OR hosokh.HOANCONG='False') ";
            else if (flag == 1)
                sql += " AND hosokh.HOANCONG='True'";

            db.Connection.Open();
            sql += " ORDER BY hosokh.STT ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }
     

        public static DataTable getListHoanCongTroNgai(string dottc, int flag)
        {
            string sql = "SELECT  donkh.SHS,HOTEN,(SONHA +' '+ DUONG+', P.'+TENPHUONG +', Q.'+TENQUAN) AS 'DIACHI', hosokh.TRONGAI,hosokh.NOIDUNGTN ";
            sql += " FROM DON_KHACHHANG donkh, PHUONG p, QUAN q, KH_HOSOKHACHHANG hosokh ";
            sql += " WHERE donkh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND donkh.PHUONG=p.MAPHUONG  ";
            sql += "  AND donkh.SHS = hosokh.SHS AND hosokh.CHUYENHOANCONG='True' AND hosokh.MADOTTC=N'" + dottc + "'";

            // flag = -1: chua hoan cong
            // flag = 1: da hoan cong
            // flag = 0: ta ca

            if (flag == -1)
                sql += " AND (hosokh.HOANCONG IS NULL OR hosokh.HOANCONG='False') ";
            else if (flag == 1)
                sql += " AND hosokh.HOANCONG='True'";

            db.Connection.Open();
            sql += " ORDER BY hosokh.STT ASC";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }
        public static bool HoanCong(string shs, DateTime ngaytc, int chiso, int cotlk, string sotlk, string tendongho, bool hoancong, DateTime ngaykd) {
            try
            {
                var query = from q in db.KH_HOSOKHACHHANGs where q.SHS == shs select q;
                KH_HOSOKHACHHANG hosokh = query.SingleOrDefault();
                if (hosokh != null)
                {
                    hosokh.NGAYTHICONG = ngaytc;
                    hosokh.CHISO = chiso;
                    hosokh.COTLK = cotlk;
                    hosokh.SOTHANTLK = sotlk;
                    hosokh.HIEUDONGHO = tendongho;
                    if (hoancong == true)
                    {
                        hosokh.HOANCONG = true;
                        hosokh.NGAYHOANCONG = DateTime.Now.Date;
                    }
                    else {
                        hosokh.HOANCONG = false;
                        hosokh.NGAYHOANCONG = null;
                    }
                    if(!"1".Equals(ngaykd.Year.ToString())){
                        hosokh.DHN_NGAYKD = ngaykd;
                    }
                    
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Chuyen Hoan Cong :" + ex.Message);
            }
            return false;
        }

        public static void TroNgai(string shs,bool trongai, string noidungtrongai)
        {
            try
            {
                var query = from q in db.KH_HOSOKHACHHANGs where q.SHS == shs select q;
                KH_HOSOKHACHHANG hosokh = query.SingleOrDefault();
                if (hosokh != null)
                {
                    if (trongai == true)
                    {
                        hosokh.TRONGAI = true;
                        hosokh.NOIDUNGTN = noidungtrongai;
                    }
                    else
                    {
                        hosokh.TRONGAI = false;
                        hosokh.NOIDUNGTN = null;
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
        public static DataSet BC_TACHPHIGANNHUA(string query)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            DataSet dataset = new DataSet();
            string sql = " SELECT * FROM KH_TC_BAOCAO ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            adapter.Fill(dataset, "KH_TC_BAOCAO");
            sql = "SELECT * FROM V_TACHPHIGANNHUA WHERE SHS IN (" + query + ") ORDER BY MODIFYDATE";
            adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            adapter.Fill(dataset, "V_TACHPHIGANNHUA");

            db.Connection.Close();
            return dataset;
        }

        public static DataSet BC_HOANCONG(string madot, string query)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            DataSet dataset = new DataSet();
            string sql = " SELECT * FROM KH_TC_BAOCAO ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            adapter.Fill(dataset, "KH_TC_BAOCAO");

            sql = "SELECT * FROM V_HOANCONG WHERE MADOTTC=N'" + madot + "' AND SHS IN (" + query + ") ORDER BY STT ASC ";
            adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            adapter.Fill(dataset, "V_HOANCONG");

            sql = "SELECT * FROM V_HOANCONG_TRONGAI WHERE MADOTTC=N'" + madot + "' ORDER BY MODIFYDATE";
            adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            adapter.Fill(dataset, "V_HOANCONG_TRONGAI");

            db.Connection.Close();
            return dataset;
        }
        
        
    }
}
