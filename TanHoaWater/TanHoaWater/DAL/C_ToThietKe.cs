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
    }
}