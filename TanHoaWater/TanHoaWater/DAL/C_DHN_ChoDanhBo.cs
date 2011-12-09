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
    class C_DHN_ChoDanhBo
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_DHN_ChoDanhBo).Name);
        static TanHoaDataContext db = new TanHoaDataContext();    
        public static DataTable getListHoanCong(string dottc, int flag)
        {
            //hosokh.COTLK,donkh.SOHOADON,donkh.NGAYDONGTIEN, CONVERT(varchar(50), hosokh.NGAYTHICONG,103) as 'NGAYTHICONG', hosokh.CHISO, hosokh.SOTHANTLK,hosokh.HOANCONG, hosokh.CPVATTU, hosokh.CPNHANCONG, hosokh.CPMAYTHICONG,hosokh.TAILAPMATDUONG
            string sql = "SELECT  DHN_SODOT,donkh.SHS,REPLACE(HOTEN,N'(ĐD '+CONVERT(VARCHAR(10),SOHO)+N' Hộ)',' ') AS 'HOTEN',(SONHA +' '+ DUONG+', P.'+TENPHUONG +', Q.'+TENQUAN) AS 'DIACHI',hosokh.COTLK,CONVERT(varchar(50), hosokh.NGAYTHICONG,103) as 'NGAYTHICONG', hosokh.CHISO, hosokh.SOTHANTLK, hosokh.HIEUDONGHO, hosokh.HOANCONG,hosokh.DHN_SOHOPDONG,hosokh.DHN_GIABIEU,hosokh.DHN_DMGOC,hosokh.DHN_DMCAPBU,hosokh.DHN_SODANHBO,hosokh.DHN_MADMA,hosokh.DHN_HIEULUC,hosokh.DHN_MAQUANPHUONG,hosokh.DHN_HSCONGTY,hosokh.DHN_MASOTHUE,hosokh.DHN_SOHO,hosokh.DHN_SONHANKHAU";
            sql += " FROM DON_KHACHHANG donkh, PHUONG p, QUAN q, KH_HOSOKHACHHANG hosokh ";
            sql += " WHERE donkh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND donkh.PHUONG=p.MAPHUONG  ";
            sql += "  AND donkh.SHS = hosokh.SHS AND hosokh.HOANCONG='True' AND hosokh.MADOTTC=N'" + dottc + "'";

            // flag = -1: chua hoan cong
            // flag = 1: da hoan cong
            // flag = 0: ta ca

            if (flag == -1)
                sql += " AND (hosokh.DHN_CHODB IS NULL OR hosokh.DHN_CHODB='False') ";
            else if (flag == 1)
                sql += " AND hosokh.DHN_CHODB='True'";

            db.Connection.Open();
            sql += " ORDER BY hosokh.MODIFYDATE";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }

        public static DataTable findByDotBangKe(string dotbangke)
        {
            //hosokh.COTLK,donkh.SOHOADON,donkh.NGAYDONGTIEN, CONVERT(varchar(50), hosokh.NGAYTHICONG,103) as 'NGAYTHICONG', hosokh.CHISO, hosokh.SOTHANTLK,hosokh.HOANCONG, hosokh.CPVATTU, hosokh.CPNHANCONG, hosokh.CPMAYTHICONG,hosokh.TAILAPMATDUONG
            string sql = "SELECT  DHN_SODOT,donkh.SHS,REPLACE(HOTEN,N'(ĐD '+CONVERT(VARCHAR(10),SOHO)+N' Hộ)',' ') AS 'HOTEN',(SONHA +' '+ DUONG+', P.'+TENPHUONG +', Q.'+TENQUAN) AS 'DIACHI',hosokh.COTLK,CONVERT(varchar(50), hosokh.NGAYTHICONG,103) as 'NGAYTHICONG', hosokh.CHISO, hosokh.SOTHANTLK,hosokh.HOANCONG,hosokh.DHN_SOHOPDONG,hosokh.DHN_GIABIEU,hosokh.DHN_DMGOC,hosokh.DHN_DMCAPBU,hosokh.DHN_SODANHBO,hosokh.DHN_MADMA,hosokh.DHN_HIEULUC,hosokh.DHN_MAQUANPHUONG,hosokh.DHN_HSCONGTY,hosokh.DHN_MASOTHUE,hosokh.DHN_SOHO,hosokh.DHN_SONHANKHAU";
            sql += " FROM DON_KHACHHANG donkh, PHUONG p, QUAN q, KH_HOSOKHACHHANG hosokh ";
            sql += " WHERE donkh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND donkh.PHUONG=p.MAPHUONG  ";
            sql += "  AND donkh.SHS = hosokh.SHS AND hosokh.DHN_SODOT=N'" + dotbangke + "'";
            db.Connection.Open();
            sql += " ORDER BY hosokh.MODIFYDATE";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }

        public static KH_HOSOKHACHHANG findbySHS(string shs) {
            try
            {
                var query = from q in db.KH_HOSOKHACHHANGs where q.SHS == shs select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error("" + ex.Message);
            }
            return null;
        }
        public static bool UpdateDB() {
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error("Cho So Danh Bo Bi Loi :" + ex.Message);
            }
            return false;
        }

        public static DataSet BC_CHODANHBO(string mabangke, string query)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            DataSet dataset = new DataSet();
            string sql = " SELECT * FROM DHN_BAOCAO ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            adapter.Fill(dataset, "DHN_BAOCAO");

            sql = "SELECT * FROM V_CHOSODANHBO WHERE DHN_SODOT=N'" + mabangke + "'  AND SHS IN (" + query + ") ORDER BY MODIFYDATE";
            adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            adapter.Fill(dataset, "V_CHOSODANHBO");

            sql = "SELECT * FROM V_DHN_MST WHERE DHN_SODOT='" + mabangke + "' ORDER BY MODIFYDATE";
            adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            adapter.Fill(dataset, "V_DHN_MST");

            db.Connection.Close();
            return dataset;
        }
        public static DataSet BC_DIEUCHINH(string mabangke, string query)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            DataSet dataset = new DataSet();
            string sql = " SELECT * FROM DHN_BAOCAO ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            adapter.Fill(dataset, "DHN_BAOCAO");

            sql = "SELECT * FROM V_CHOSODANHBO WHERE DHN_SODOT=N'" + mabangke + "' AND SHS IN (" + query + ")  AND DHN_DMGOC>0 ORDER BY MODIFYDATE";
            adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            adapter.Fill(dataset, "V_CHOSODANHBO");
            
            db.Connection.Close();
            return dataset;
        }

    }
}
