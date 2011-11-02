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
        public static List<KH_DONVITAILAP> getDonViTaiLap()
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var list = from query in data.KH_DONVITAILAPs orderby query.ID ascending select query;
            return list.ToList();
        }

        public static List<KH_LOAIBANGKE> getLoaiBangKe()
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var list = from query in data.KH_LOAIBANGKEs orderby query.ID ascending select query;
            return list.ToList();
        }

    }
}
