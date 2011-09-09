using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using TanHoaWater.Database;
namespace TanHoaWater.DAL
{
    class C_BienNhanDon
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_BienNhanDon).Name);
        public static void InsertBienNhanDon(BIENNHANDON bn) {
            TanHoaDataContext db = new TanHoaDataContext();
            db.BIENNHANDONs.InsertOnSubmit(bn);
            db.SubmitChanges();
        }
    }
}
