using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;

namespace TanHoaWater.DAL
{
    class C_DonViTinh
    {
        public static List<Database.DVT> getList() {
            TanHoaDataContext db = new TanHoaDataContext();
            var list = from dvt in db.DVTs select dvt;
            return list.ToList();
        }
    }
}
