using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;
using TanHoaWater.View.Report;
using log4net;
using System.Data.SqlClient;

namespace TanHoaWater.DAL
{
    class C_KH_DotThiCong
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_KH_DotThiCong).Name);
        static  TanHoaDataContext db = new TanHoaDataContext();
        public static KH_DOTTHICONG findByMadot(string madot) {
            try
            {
                var query = from dottc in db.KH_DOTTHICONGs where dottc.MADOTTC == madot select dottc;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;   
        }
        
        public static bool InsertDotTC(KH_DOTTHICONG dottc) {
            try
            {
                db.KH_DOTTHICONGs.InsertOnSubmit(dottc);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }

        public static bool UpdateDotTC(KH_DOTTHICONG dottc) {
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }
        public static bool DeleteDotTC(KH_DOTTHICONG dottc)
        {
            try
            {
                db.KH_DOTTHICONGs.DeleteOnSubmit(dottc);
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }
        public static int TotalListDotThiCong()
        {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = " SELECT COUNT(*) FROM KH_DOTTHICONG";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }
        public static DataTable getListDotThiCong(int FirstRow, int pageSize)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT MADOTTC,NGAYLAP, LOAIBANGKE FROM KH_DOTTHICONG";
            sql += " ORDER BY NGAYLAP DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, FirstRow, pageSize, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }
    }
}
