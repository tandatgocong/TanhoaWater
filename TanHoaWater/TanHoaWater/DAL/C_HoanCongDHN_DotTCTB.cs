using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using TanHoaWater.Database;

namespace TanHoaWater.DAL
{
    static class C_HoanCongDHN_DotTCTB
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_HoanCongDHN_DotTCTB).Name);
        static TanHoaDataContext db = new TanHoaDataContext();

        public static KH_HOSOKHACHHANG findByHoSoHC(string shs)
        {
            var query = from q in db.KH_HOSOKHACHHANGs where q.SHS == shs select q;
            return query.SingleOrDefault();
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
                log.Error("Insert Danh Muc Vat Tu Loi. " + ex.Message);
            }
            return false;
        }
    }
}