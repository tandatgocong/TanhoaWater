using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using log4net;

namespace TanHoaWater.DAL
{
    class C_HeSoBangGia
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_HeSoBangGia).Name);
        static TanHoaDataContext db = new TanHoaDataContext();
        public static BG_HESOBANGGIA getHeSoBangGia()
        {
            
            var banggia = from hs in db.BG_HESOBANGGIAs where hs.CHON == true select hs;
            return banggia.SingleOrDefault();
        }
        public static bool UpdateHeSoBangGia() {
            try
            {
                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                log.Error("Cap Nha Thong So Bang Gia Loi " + ex.Message);
            }
            return false;
        }
        public static BG_REPORT getReport()
        {
            var banggia = from hs in db.BG_REPORTs where hs.STT == 1 select hs;
            return banggia.SingleOrDefault();
        }
        
    }
}
