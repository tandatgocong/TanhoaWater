using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using TanHoaWater.Database;

namespace TanHoaWater.DAL
{
    class C_KTTC_HeSoQT
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_KTTC_HeSoQT).Name);
        public static TanHoaDataContext db = new TanHoaDataContext();
        public static KTTC_HESOQUYETTOAN hsquyettoan()
        {
            
            var query = from q in db.KTTC_HESOQUYETTOANs  select q;
            if (query.ToList() != null) { 
              return  query.ToList()[0];
            }
            return null;
        }
        public static void Update() {
            db.SubmitChanges();
        }
    }
}
