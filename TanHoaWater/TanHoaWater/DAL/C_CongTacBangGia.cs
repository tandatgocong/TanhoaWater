using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using log4net;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using TanHoaWater.Utilities;
namespace TanHoaWater.DAL
{
    class C_CongTacBangGia
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_CongTacBangGia).Name);
        public static bool InsertCongTacBG(BG_CONGTACBANGIA dm)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.BG_CONGTACBANGIAs.InsertOnSubmit(dm);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Insert DANH SACH CONG TAC BANG GIA Loi. " + ex.Message);
            }
            return false;
        }
    }
}
