using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;

namespace TanHoaWater.DAL
{
    class C_LoaiSD
    {
        public static List<LOAISD> getList ()
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var query = from q in db.LOAISDs   select q;
            return query.ToList();
        }
    }
}
