using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using TanHoaWater.Database;

namespace TanHoaWater.DAL
{
    class C_BGDC_KhoiLuongXDCB
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_KhoiLuongXDCB).Name);
        static TanHoaDataContext db = new TanHoaDataContext();
        public static void InsertKTPD(BGDC_KHOILUONGXDCB klxd)
        {
            db.BGDC_KHOILUONGXDCBs.InsertOnSubmit(klxd);
            db.SubmitChanges();
        }
        public static BGDC_KHOILUONGXDCB findBySHS(string shs, int lan)
        {
            try
            {
                var query = from kt in db.BGDC_KHOILUONGXDCBs where kt.SHS == shs && kt.LAN ==lan select kt;
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
        public static List<BGDC_KHOILUONGXDCB> getListBGDCBySHS(string shs) {
            var query = from q in db.BGDC_KHOILUONGXDCBs where q.SHS == shs orderby q.LAN ascending select q;
            return query.ToList();

        }
    }
}
