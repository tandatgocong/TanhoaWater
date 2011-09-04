using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
namespace TanHoaWater.DAL
{
    class C_DanhMucBoVT
    {
        public static DANHMUCBOVATTU findBoVT(string mabovt, string mahieuvt) {
            TanHoaDataContext db = new TanHoaDataContext();
            var query = from q in db.DANHMUCBOVATTUs where q.MABOVT == mabovt && q.MAHIEU == mahieuvt select q;
            return query.SingleOrDefault();
        }
        public static List<DANHMUCBOVATTU> finbyMaBo(string mabovt) {
            TanHoaDataContext db = new TanHoaDataContext();
            var query = from q in db.DANHMUCBOVATTUs where q.MABOVT == mabovt select q;
            return query.ToList();
        }
    }
}
