using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;


namespace TanHoaWater.DAL
{
    class C_LoaiNhanDon
    {
        public static List<LOAI_NHANDON> getList() {
            TanHoaDataContext db = new TanHoaDataContext();
            var query = from lhs in db.LOAI_NHANDONs select lhs;
            return query.ToList();
        }
    }
}
