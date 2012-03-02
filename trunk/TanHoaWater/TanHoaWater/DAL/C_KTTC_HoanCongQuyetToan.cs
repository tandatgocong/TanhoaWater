using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using TanHoaWater.Database;
using System.Data.SqlClient;
using System.Data;

namespace TanHoaWater.DAL
{
    class C_KTTC_HoanCongQuyetToan
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_KTTC_HoanCongQuyetToan).Name);

        public static KTTC_HOSOKHACHHANG findBySHS(string shs)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var obj = from dd in db.KTTC_HOSOKHACHHANGs where dd.SHS == shs select dd;
            return obj.SingleOrDefault();
        }

        public static DataTable getList(string madot) {

            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT STT,DOTQT,NHATHAU,TONGSODHN,QUYETTOAN ,THANHTOAN ,SOHOSO ,TENKH,SONHA,TENDUONG ,PHUONG ,QUAN ,SODHN ";
		    sql += ",CATDA ,NHANCONG ,CP_NHANCONG ,MAYTC ,CP_MAYTC ,CHIPHICHUNG ,CP_CHUNG ";
		    sql += ",THUNHAPCHUITHUE ,	CP_TNCTTT ,	GXLTT ,	THUE ,	SAUTHUE ,	GHICHU ";
            sql += "FROM KTTC_QUYETTOAN_GANDHN  ";
            sql += "WHERE DOTQT ='" + madot + "'";
            sql += "ORDER BY STT DESC";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            db.Connection.Close();
            return table;
        
        }

        static TanHoaDataContext db = new TanHoaDataContext();
        public static KTTC_QUYETTOAN_GANDHN findByQuyetToan(string _SOHOSO)
        {
            var obj = from dd in db.KTTC_QUYETTOAN_GANDHNs where dd.SOHOSO == _SOHOSO select dd;
            return obj.SingleOrDefault();
        }
        public static bool Update() {

            try
            {
                 db.SubmitChanges();
                 return true;
            }
            catch (Exception ex)
            {
                log.Error("Them Hoan Cong QT Loi " + ex.Message);
            }
            return false;
        }

        public static bool Insert(KTTC_QUYETTOAN_GANDHN hskh)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.KTTC_QUYETTOAN_GANDHNs.InsertOnSubmit(hskh);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Them Hoan Cong QT Loi " + ex.Message);
            }
            return false;
        }
        //public static bool
    }
}