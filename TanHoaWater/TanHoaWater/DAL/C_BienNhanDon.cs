using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using TanHoaWater.Database;
using System.Data;
using System.Data.SqlClient;
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
        public static DataSet printBienNhan(string soshs) {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT * FROM V_BIENNHANDON ";
            sql += " WHERE SHS='" + soshs + "' AND USERNAME='thanhtrung'";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "V_BIENNHANDON");
            db.Connection.Close();
            return dataset;
        }
    }
}
