using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using log4net;

namespace TanHoaWater.DAL
{
    class TestConection
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TestConection).Name);
        public static bool testConnection() {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                db.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Loi Ket Noi" + ex.Message);
            }
            return false;
            
        }
    }
}
