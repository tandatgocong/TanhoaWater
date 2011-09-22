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
        public static void InsertKTPD(KHOILUONGXDCB klxd)
        {
            db.KHOILUONGXDCBs.InsertOnSubmit(klxd);
            db.SubmitChanges();
        }
        public static KHOILUONGXDCB findBySHS(string shs)
        {
            var query = from kt in db.KHOILUONGXDCBs where kt.SHS == shs select kt;
            return query.SingleOrDefault();
        }
       
        public void DeleteByKTPD(KICHTHUOCPHUIDAO kt)
        {
            db.KICHTHUOCPHUIDAOs.DeleteOnSubmit(kt);
            db.SubmitChanges();
        }
        //public void DeleteBySHS(string shs)
        //{
        //    SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
        //    conn.Open();
        //    string sql = " DELETE KICHTHUOCPHUIDAO WHERE SHS='" + shs + "' ";
        //    SqlCommand cmd = new SqlCommand(sql, conn);
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //}
    }
}
