using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TanHoaWater.Database;
using System.Data.SqlClient;
using log4net;
using System.Collections;

namespace TanHoaWater.DAL
{
    class C_KH_DonViTC
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_KH_DonViTC).Name);

        public static List<KH_DONVITHICONG> getDonViThiCong() {
            TanHoaDataContext data = new TanHoaDataContext();
            var list = from query in data.KH_DONVITHICONGs orderby query.ID ascending select query;
            return list.ToList();
        }
        public static KH_DONVITHICONG findDVTCbyID(int id) {
            TanHoaDataContext data = new TanHoaDataContext();
            var list = from query in data.KH_DONVITHICONGs where query.ID == id select query;
            return list.SingleOrDefault();
        }
        public static KH_DONVITHICONG findDVTCbyTENCTY(string name)
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var list = from query in data.KH_DONVITHICONGs where query.TENCONGTY == name select query;
            return list.SingleOrDefault();
        }
        public static List<KH_DONVITAILAP> getDonViTaiLap()
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var list = from query in data.KH_DONVITAILAPs orderby query.ID ascending select query;
            return list.ToList();
        }
        public static KH_DONVITAILAP findDVTLbyID(int id)
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var list = from query in data.KH_DONVITAILAPs  where query.ID == id select query;
            return list.SingleOrDefault();
        }
        public static KH_DONVITAILAP findDVTLbyTENCTY(string name)
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var list = from query in data.KH_DONVITAILAPs where query.TENCONGTY == name select query;
            return list.SingleOrDefault();
        }
        public static List<KH_LOAIBANGKE> getLoaiBangKe()
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var list = from query in data.KH_LOAIBANGKEs orderby query.ID ascending select query;
            return list.ToList();
        }

    }
}
