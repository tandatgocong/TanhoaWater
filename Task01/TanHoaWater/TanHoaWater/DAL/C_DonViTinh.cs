using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using System.Collections;
using TanHoaWater.Utilities;

namespace TanHoaWater.DAL
{
    class C_DonViTinh
    {
        public static List<Database.DVT> getList() {
            TanHoaDataContext db = new TanHoaDataContext();
            var list = from dvt in db.DVTs select dvt;
            return list.ToList();
        }
        public static ArrayList getDVT()
        {
            ArrayList list = new ArrayList();
            TanHoaDataContext db = new TanHoaDataContext();
            var dvt = from dm in db.DVTs select dm;
            list.Add(new AddValueCombox("", ""));
            foreach (var a in dvt)
            {
                list.Add(new AddValueCombox(a.DONVI, a.DONVI));
            }
            return list;
        }
    }
}
