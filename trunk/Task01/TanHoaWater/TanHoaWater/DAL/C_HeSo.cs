using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using TanHoaWater.Database;

namespace TanHoaWater.DAL
{
    class C_HeSo
    {
        public static double _HSSuDungLai = 0.0;
        public static double _HSThuHoi = 0.0;
        private static readonly ILog log = LogManager.GetLogger(typeof(C_DanhMucVatTu).Name);
        public static void getHeSoBangGia()
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var hesokinhphi = from dm in db.BG_HESOBANGGIAs where dm.CHON == true select dm;
            Database.BG_HESOBANGGIA heso = hesokinhphi.SingleOrDefault();
            if (heso != null)
            {
                _HSSuDungLai = double.Parse(heso.HSSDL + "");
                _HSThuHoi = double.Parse(heso.HSTH + "");
            }


        }
        public static double _KL_NHUA12;
        public static double _DATC4_NHUA12;
        public static double _KL_NHUA10;
        public static double _DATC4_NHUA10;
        public static double _KL_BT10;
        public static double _DATC4_BT10;
        public static double _DATC4_DAXANH;
        public static double _DATC4_DADO;
        public static double _KLDA04_TNHA;
        public static double _CHISODD;
        public static double _KL_CONLAI;
        public static double _DATC4_CONLAI;

        public static void getHeSoPhuiDao()
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var hesokinhphi = from dm in db.BG_HESOPHUIDAOs where dm.CHON == true select dm;
            Database.BG_HESOPHUIDAO heso = hesokinhphi.SingleOrDefault();
            if (heso != null)
            {
                _KL_NHUA12 = double.Parse(heso.KL_NHUA12 + "");
                _DATC4_NHUA12 = double.Parse(heso.DATC4_NHUA12 + "");
                _KL_NHUA10 = double.Parse(heso.KL_NHUA10 + "");
                _DATC4_NHUA10 = double.Parse(heso.DATC4_NHUA10 + "");
                _KL_BT10 = double.Parse(heso.KL_BT10 + "");
                _DATC4_BT10 = double.Parse(heso.DATC4_BT10 + "");
                _DATC4_DAXANH = double.Parse(heso.DATC4_DAXANH + "");
                _DATC4_DADO = double.Parse(heso.DATC4_DADO + "");
                _KLDA04_TNHA = double.Parse(heso.KLDA04_TNHA + "");
                _CHISODD = double.Parse(heso.CHISODD + "");
                _KL_CONLAI = double.Parse(heso.KL_CONLAI + "");
                _DATC4_CONLAI = double.Parse(heso.DATC4_CONLAI + "");                
            }


        }
    }
}
