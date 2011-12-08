using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using TanHoaWater.Database;

namespace TanHoaWater.DAL
{
    class C_DHN_TENDONGHO
    {
         private static readonly ILog log = LogManager.GetLogger(typeof(C_DHN_TENDONGHO).Name);

         public static List<DHN_DONGHO> ListDanhSachDongHo()
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var query = from q in db.DHN_DONGHOs select q;
            return query.ToList();

        }

        
    }
}
