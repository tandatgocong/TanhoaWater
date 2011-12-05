using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using log4net;

namespace TanHoaWater.DAL
{
    class C_Admin_BaoCao
    {
        static TanHoaDataContext db = new TanHoaDataContext();
        private static readonly ILog log = LogManager.GetLogger(typeof(C_Admin_BaoCao).Name);
        public static KH_BC_XINPHEPDD xinphepdaoduong() {
            try
            {
                var query = from q in db.KH_BC_XINPHEPDDs select q;
                return query.ToList()[0];
            }
            catch (Exception ex)
            {
                log.Error("lay xin phep dd loi " + ex.Message);
            }
            return null;
        }

        public static KH_TC_BAOCAO xinHoanCongAndDotTC()
        {
            try
            {
                var query = from q in db.KH_TC_BAOCAOs select q;
                return query.ToList()[0];
            }
            catch (Exception ex)
            {
                log.Error("lay tc loi " + ex.Message);
            }
            return null;
        }

        public static DHN_BAOCAO quanlydhn()
        {
            try
            {
                var query = from q in db.DHN_BAOCAOs select q;
                return query.ToList()[0];
            }
            catch (Exception ex)
            {
                log.Error("lay qldhn loi " + ex.Message);
            }
            return null;
        }

        public static void update() {
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error("cap nhat loi " + ex.Message);
            }
        }
       
    }
}
