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
            string sql = " SELECT ID, STT, DOTQT, NHATHAU, TONGSODHN, QUYETTOAN, THANHTOAN, SOHOSO, TENKH, SONHA, TENDUONG, PHUONG, QUAN ";
            sql += " , SODHN,convert(varchar,convert(decimal(20,2), CATDA)) as 'CATDA', convert(varchar,convert(decimal(20,2), NHANCONG)) as 'NHANCONG' ,convert(varchar,convert(decimal(20,2), CPNC)) as 'CPNC' ,";
            sql += " convert(varchar,convert(decimal(20,2), CP_NHANCONG)) as 'CP_NHANCONG' , convert(varchar,convert(decimal(20,2), MAYTC)) as 'MAYTC'  ,convert(varchar,convert(decimal(20,2), MAYTHICONG)) as 'MAYTHICONG'  ,";
            sql += " convert(varchar,convert(decimal(20,2), CP_MAYTC)) as 'CP_MAYTC'  , convert(varchar,convert(decimal(20,2), CHIPHICHUNG)) as 'CHIPHICHUNG' ,  convert(varchar,convert(decimal(20,2), CP_CHUNG)) as 'CP_CHUNG'  ";
            sql += " ,  convert(varchar,convert(decimal(20,2), THUNHAPCHUITHUE)) as 'THUNHAPCHUITHUE'  , convert(varchar,convert(decimal(20,2), CP_TNCTTT)) as 'CP_TNCTTT'  , convert(varchar,convert(decimal(20,2), GXLTT)) as 'GXLTT',convert(varchar,convert(decimal(20,2), THUE)) as 'THUE' ,convert(varchar,convert(decimal(20,2), SAUTHUE)) as 'SAUTHUE' , GHICHU ";
            sql += "FROM KTTC_QUYETTOAN_GANDHN  ";
            sql += "WHERE DOTQT ='" + madot + "'";
            sql += "ORDER BY STT ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            db.Connection.Close();
            return table;
        
        }

        static TanHoaDataContext db = new TanHoaDataContext();
        public static KTTC_QUYETTOAN_GANDHN findByQuyetToan(int _id)
        {
            var obj = from dd in db.KTTC_QUYETTOAN_GANDHNs where dd.ID == _id select dd;
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