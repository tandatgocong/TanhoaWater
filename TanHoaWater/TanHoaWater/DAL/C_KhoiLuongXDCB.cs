using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using TanHoaWater.Database;

namespace TanHoaWater.DAL
{
    class C_KhoiLuongXDCB
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_KhoiLuongXDCB).Name);
        static TanHoaDataContext db = new TanHoaDataContext();
        public static void InsertKTPD(BG_KHOILUONGXDCB klxd)
        {
            db.BG_KHOILUONGXDCBs.InsertOnSubmit(klxd);
            db.SubmitChanges();
        }
        public static BG_KHOILUONGXDCB findBySHS(string shs)
        {
            try
            {
                var query = from kt in db.BG_KHOILUONGXDCBs where kt.SHS == shs select kt;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error("Loi " + ex.Message);
            }
            return null;
        }
       
        public void DeleteByKTPD(BG_KICHTHUOCPHUIDAO kt)
        {
            db.BG_KICHTHUOCPHUIDAOs.DeleteOnSubmit(kt);
            db.SubmitChanges();
        }
        //public void DeleteBySHS(string shs)
        //{
        //    SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
        //    conn.Open();
        //    string sql = " DELETE BG_KICHTHUOCPHUIDAO WHERE SHS='" + shs + "' ";
        //    SqlCommand cmd = new SqlCommand(sql, conn);
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //}
    }
}
