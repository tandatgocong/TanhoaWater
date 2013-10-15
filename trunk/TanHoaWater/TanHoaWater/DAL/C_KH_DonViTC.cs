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
            var list = from query in data.KH_DONVITHICONGs where query.XOA != true orderby query.ID ascending select query;
            return list.ToList();
        }

        static TanHoaDataContext data = new TanHoaDataContext();
        public static KH_DONVITHICONG findDVTCbyID(int id) {           
            var list = from query in data.KH_DONVITHICONGs where query.ID == id select query;
            return list.SingleOrDefault();
        }

        public static KH_DONVIGIAMSAT findDVGiamSatID(int id)
        {
            var list = from query in data.KH_DONVIGIAMSATs where query.ID == id select query;
            return list.SingleOrDefault();
        }
        
        public static KH_DONVITHICONG findDVTCbyTENCTY(string name)
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var list = from query in data.KH_DONVITHICONGs where query.TENCONGTY == name select query;
            return list.SingleOrDefault();
        }

        public static KH_DONVIGIAMSATTL findDVGSTCbyName(string name)
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var list = from query in data.KH_DONVIGIAMSATTLs where query.TENCONGTY == name select query;
            return list.SingleOrDefault();
        }
        public static KH_DONVIGIAMSATTL findDVGSTCbyID(int id)
        {
            var list = from query in data.KH_DONVIGIAMSATTLs where query.ID == id select query;
            return list.SingleOrDefault();
        }

        public static List<KH_DONVITAILAP> getDonViTaiLap()
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var list = from query in data.KH_DONVITAILAPs where query.XOA != true orderby query.ID ascending select query;
            return list.ToList();
        }
        public static List<KH_DONVIGIAMSATTL> getDonViGiamSatTL()
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var list = from query in data.KH_DONVIGIAMSATTLs where query.XOA != true orderby query.ID ascending select query;
            return list.ToList();
        }
       
        public static KH_DONVITAILAP findDVTLbyID(int id)
        { 
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

        public static void AddDonViTC(KH_DONVITHICONG dvtc) {
            data.KH_DONVITHICONGs.InsertOnSubmit(dvtc);
            data.SubmitChanges();
        }

        public static void AddDonViGiamSat(KH_DONVIGIAMSAT dvtc)
        {
            data.KH_DONVIGIAMSATs.InsertOnSubmit(dvtc);
            data.SubmitChanges();
        }

        public static void AddDonViTLMD(KH_DONVITAILAP dvtl)
        {
            data.KH_DONVITAILAPs.InsertOnSubmit(dvtl);
            data.SubmitChanges();
        }

        public static void AddDonViGiamSatTL(KH_DONVIGIAMSATTL dvtl)
        {
            data.KH_DONVIGIAMSATTLs.InsertOnSubmit(dvtl);
            data.SubmitChanges();
        }


        
        public static void Update()
        {
            data.SubmitChanges();
        }
    }
}
