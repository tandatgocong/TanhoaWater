using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using log4net;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using TanHoaWater.Class;
namespace TanHoaWater.DAL
{
    class C_DanhMucVatTu
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_DanhMucVatTu).Name);
        public static List<DANHMUCVATTU> getList() {
            TanHoaDataContext db = new TanHoaDataContext();
            var list = from dm in db.DANHMUCVATTUs select dm;
            return list.ToList();
        }
        public static DANHMUCVATTU finbyMaHieu(string mahieu) {
            TanHoaDataContext db = new TanHoaDataContext();
            var danhmuc = from dmvt in db.DANHMUCVATTUs where dmvt.MAHIEU == mahieu select dmvt;
            return danhmuc.SingleOrDefault();
        }
        public static bool InsertDanhMucVT(DANHMUCVATTU dm) {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.DANHMUCVATTUs.InsertOnSubmit(dm);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Insert Danh Muc Vat Tu Loi. " + ex.Message);
            }
            return false;
        }
        public static bool UpdateDanhMucVT(string mahieu, string mahDG, string tenvt, string dvt, double klbtcc, string nhomvt, bool bovt, string modibyBy) {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var query = from vt in db.DANHMUCVATTUs where vt.MAHIEU == mahieu select vt;
                DANHMUCVATTU dmvt = query.SingleOrDefault();
                if (dmvt != null)
                {
                    dmvt.MAHDG = mahDG;
                    dmvt.TENVT = tenvt;
                    dmvt.DVT = dvt;
                    dmvt.KLBTCC = klbtcc;
                    dmvt.NHOMVT = nhomvt;
                    dmvt.BOVT = bovt;
                    dmvt.MODIFYBY = modibyBy;
                    dmvt.MODIFYDATE = DateTime.Now.Date;
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Update Danh Muc Vat Tu Loi. " + ex.Message);
            }
            return false;
        }
        public static bool DeleteDanhMucVT(DANHMUCVATTU vt) {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.DANHMUCVATTUs.DeleteOnSubmit(vt);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Delete Danh Muc Vat Tu Loi. " + ex.Message);
            }
            return false;
        }
      
        public static DataTable search(string mahieu, string mhDonGia, string tenvt, string donvitinh, string nhomvt,   int FirstRow, int pageSize)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT MAHIEU,MAHDG,UPPER(TENVT) AS 'TENVT',DVT,NHOMVT,BOVT";
            sql += " FROM DANHMUCVATTU ";
            sql += " WHERE TENVT IS NOT NULL ";
            if (!"".Equals(mahieu))
            {
                sql += " AND MAHIEU LIKE'%" + mahieu + "%'";
            }
            if (!"".Equals(mhDonGia))
            {
                sql += " AND MAHDG LIKE'%" + mhDonGia + "%'";
            }
            if (!"".Equals(tenvt))
            {
                sql += " AND TENVT LIKE '%" + tenvt + "%'";
            }
            if (!"".Equals(donvitinh))
            {
                sql += " AND DVT = N'" + donvitinh + "'";
            }
            if (!"".Equals(nhomvt))
            {
                sql += " AND NHOMVT = N'" + nhomvt + "'";
            }
            sql += " ORDER BY MAHIEU ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, FirstRow, pageSize, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }
       
        public static int TotalSearch(string mahieu, string mhDonGia, string tenvt, string donvitinh, string nhomvt,  int FirstRow, int pageSize)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = " SELECT COUNT(*) ";
            sql += " FROM DANHMUCVATTU ";
            sql += " WHERE TENVT IS NOT NULL ";            

            if (!"".Equals(mahieu))
            {
                sql += " AND MAHIEU LIKE'%" + mahieu + "%'";
            }
            if (!"".Equals(mhDonGia))
            {
                sql += " AND MAHDG LIKE'%" + mhDonGia + "%'";
            }
            if (!"".Equals(tenvt))
            {
                sql += " AND TENVT LIKE '%" + tenvt + "%'";
            }
            if (!"".Equals(donvitinh))
            {
                sql += " AND DVT = N'" + donvitinh + "'";
            }
            if (!"".Equals(nhomvt))
            {
                sql += " AND NHOMVT = N'" + nhomvt + "'";
            }
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }
        public static DataTable getListDanhMucVatCombobox()
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT MAHIEU , (MAHIEU + ' ______ '+   UPPER(TENVT) ) as 'TENVT'";
            sql += " FROM DANHMUCVATTU ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            db.Connection.Close();
            return table;
        }

    }
}
