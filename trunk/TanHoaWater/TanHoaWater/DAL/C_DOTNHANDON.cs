using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using System.Data;
using System.Data.SqlClient;
using log4net;

namespace TanHoaWater.DAL
{
    public class C_DotNhanDon
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_DotNhanDon).Name);
        static TanHoaDataContext data = new TanHoaDataContext();
        public static DOT_NHAN_DON findByMaDot(string madot)
        {          
            var dotnhandon = from query in data.DOT_NHAN_DONs where query.MADOT == madot select query;
            return dotnhandon.SingleOrDefault();
        }

        public static void Update()
        {
            try
            {
                data.SubmitChanges();
            }
            catch (Exception ex)
            {
                 log.Error("Sua Dot Nhan Don Loi " + ex.Message ); 
            }
        }
        public static List<DOT_NHAN_DON> getALL()
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var dotnhandon = from query in data.DOT_NHAN_DONs orderby query.NGAYLAPDON ascending  select query;
            return dotnhandon.ToList();
        }
       
        public static bool InsertDot(DOT_NHAN_DON dnd)
        {
            try
            {
                TanHoaDataContext data = new TanHoaDataContext();
                data.DOT_NHAN_DONs.InsertOnSubmit(dnd);
                data.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            { log.Error("Insert Dot Loi " + ex.Message ); }

            return false;
        }

        public static bool DeleteDot(DOT_NHAN_DON dnd)
        {
            try
            {
                data.DOT_NHAN_DONs.DeleteOnSubmit(dnd);
                data.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            { log.Error("Delete Dot Loi " + ex.Message); }

            return false;
        }

        public static bool chuyendon(DOT_NHAN_DON dotnd)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var dotnhandon = from query in db.DOT_NHAN_DONs where query.MADOT == dotnd.MADOT  select query;
                DOT_NHAN_DON dot = dotnhandon.SingleOrDefault();
                if ( dot!= null) {
                    dot.CHUYENDON = dotnd.CHUYENDON;
                    dot.NGAYCHUYEN = dotnd.NGAYCHUYEN;
                    dot.BOPHANCHUYEN = dotnd.BOPHANCHUYEN;
                    dot.NGUOICHUYEN = dotnd.NGUOICHUYEN;
                   
                }
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                log.Error("Update Dot Loi " + ex.Message);
            }
            return false;
        }
        public static bool chuyendon(string madot, string nguoichuyen, string bpchuyen)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var dotnhandon = from query in db.DOT_NHAN_DONs where query.MADOT == madot select query;
                DOT_NHAN_DON dot = dotnhandon.SingleOrDefault();
                if (dot != null)
                {
                    dot.CHUYENDON = true;
                    dot.NGAYCHUYEN = DateTime.Now;
                    dot.BOPHANCHUYEN = bpchuyen;
                    dot.NGUOICHUYEN = nguoichuyen;

                }
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                log.Error("Update Dot Loi " + ex.Message);
            }
            return false;
        }
        public static DataTable getList11()
        {
           
            string sql = " SELECT MADOT , NGAYLAPDON= CONVERT(VARCHAR(10),NGAYLAPDON,103), TENLOAI,";
            sql += " CASE WHEN CHUYENDON='False' THEN N'Chưa chuyển'  WHEN CHUYENDON='True' THEN N'Đã chuyển' ELSE N'Chuyển 1 phần'   END as 'CHUYEN'";
            sql += " FROM DOT_NHAN_DON dot, LOAI_HOSO loai";
            sql += " WHERE loai.MALOAI = dot.LOAIDON";
            sql += " ORDER BY dot.CREATEDATE DESC ";
            return DAL.LinQConnection.getDataTable(sql); 
        }
        public static DataTable getList(int FirstRow, int pageSize)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT MADOT , NGAYLAPDON= CONVERT(VARCHAR(10),NGAYLAPDON,103), TENLOAI,";
            sql += " CASE WHEN CHUYENDON='False' THEN N'Chưa chuyển'  WHEN CHUYENDON='True' THEN N'Đã chuyển' ELSE N'Chuyển 1 phần'   END as 'CHUYEN', NGAYCHUYEN= CONVERT(VARCHAR(10),NGAYCHUYEN,103),NGAYTRAHS= CONVERT(VARCHAR(10),NGAYTRAHS,103), dot.CREATEBY ";
            sql += " FROM DOT_NHAN_DON dot, LOAI_HOSO loai";
            sql += " WHERE loai.MALOAI = dot.LOAIDON";
            sql += " ORDER BY dot.CREATEDATE DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, FirstRow, pageSize, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];

        }
        public static int TotalListByDotNhanDon()
        {
            string sql = " SELECT COUNT(*) ";
            sql += " FROM DOT_NHAN_DON dot, LOAI_HOSO loai";
            sql += " WHERE loai.MALOAI = dot.LOAIDON";
            //TanHoaDataContext db = new TanHoaDataContext();
            //SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            //conn.Open();
            //string sql = " SELECT COUNT(*) ";
            //sql += " FROM DOT_NHAN_DON dot, LOAI_HOSO loai";
            //sql += " WHERE loai.MALOAI = dot.LOAIDON";
            //SqlCommand cmd = new SqlCommand(sql, conn);
            //int result = Convert.ToInt32(cmd.ExecuteScalar());
            //conn.Close();
            //return result;
            return DAL.LinQConnection.ExecuteCommand(sql);
        }
        public static DataTable Search(string madot, DateTime ngaylap, string maloai)
        {
          
            string sql = " SELECT MADOT , NGAYLAPDON= CONVERT(VARCHAR(10),NGAYLAPDON,103), TENLOAI,";
            sql += " CASE WHEN CHUYENDON='False' THEN N'Chưa chuyển'  WHEN CHUYENDON='True' THEN N'Đã chuyển' ELSE N'Chuyển 1 phần'   END as 'CHUYEN', NGAYCHUYEN= CONVERT(VARCHAR(10),NGAYCHUYEN,103),NGAYTRAHS= CONVERT(VARCHAR(10),NGAYTRAHS,103), dot.CREATEBY";
            sql += " FROM DOT_NHAN_DON dot, LOAI_HOSO loai";
            sql += " WHERE loai.MALOAI = dot.LOAIDON";
            if (!"".Equals(madot))            {
                sql += " AND dot.MADOT LIKE '%" + madot + "%'";
            }
            if (!"1/1/0001".Equals(ngaylap.ToShortDateString()) && !"01/01/0001".Equals(ngaylap.ToShortDateString()) && !"01-01-0001".Equals(ngaylap.ToShortDateString()))
            {
                sql += " AND dot.NGAYLAPDON = '" + ngaylap.ToShortDateString() + "'";
            }
            if (!"".Equals(maloai)) {
                sql += " AND dot.LOAIDON = '" + maloai + "'";            
            }
            sql += " ORDER BY dot.CREATEDATE DESC ";
          //  log.Error(sql);
            return DAL.LinQConnection.getDataTable(sql); 
        }

        public static DataTable getListtMa_Dot()
        {
          
            string sql = " SELECT MADOT , (MADOT + '   '+  TENLOAI) as 'TEND'";            
            sql += " FROM DOT_NHAN_DON dot, LOAI_HOSO loai";
            sql += " WHERE loai.MALOAI = dot.LOAIDON";
            sql += " ORDER BY dot.CREATEDATE DESC ";

            return DAL.LinQConnection.getDataTable(sql); 
        }
        public static DataTable getListtMa_Dot_NoChuyen()
        {
          
            string sql = " SELECT MADOT , (MADOT + '   '+  TENLOAI) as 'TEND'";
            sql += " FROM DOT_NHAN_DON dot, LOAI_HOSO loai";
            sql += " WHERE loai.MALOAI = dot.LOAIDON AND CHUYENDON = 'False'";
            sql += " ORDER BY dot.CREATEDATE DESC ";

            return DAL.LinQConnection.getDataTable(sql); 
        }
        public static DataTable getListtMa_Dot_DaChuyen()
        {
            
            string sql = " SELECT MADOT , (MADOT + '   '+  TENLOAI) as 'TEND'";
            sql += " FROM DOT_NHAN_DON dot, LOAI_HOSO loai";
            sql += " WHERE loai.MALOAI = dot.LOAIDON AND CHUYENDON = 'True'";
            sql += " ORDER BY MADOT ASC ";
            return DAL.LinQConnection.getDataTable(sql); 
        }
        public static DataTable getListChuaChuyen()
        {
            
            string sql = " SELECT MADOT , NGAYLAPDON= CONVERT(VARCHAR(10),NGAYLAPDON,103), TENLOAI ";
            sql += " FROM DOT_NHAN_DON dot, LOAI_HOSO loai";
            sql += " WHERE loai.MALOAI = dot.LOAIDON AND CHUYENDON = 'False'";
            sql += " ORDER BY dot.CREATEDATE DESC";
            return DAL.LinQConnection.getDataTable(sql); 
        }
        
     }
}
