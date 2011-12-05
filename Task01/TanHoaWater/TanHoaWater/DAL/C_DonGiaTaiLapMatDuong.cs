using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using System.Data;
using System.Data.SqlClient;

namespace TanHoaWater.DAL
{
    class C_DonGiaTaiLapMatDuong
    {
        public static TanHoaDataContext db = new TanHoaDataContext();
        public static DataTable getListByMADANHMUC(string madanhmuc)
        {
            db.Connection.Open();
            string sql = "SELECT STT,MADANHMUC,DONGIA,DGVATLIEU,DGNHANCONG,DGMAYTHICONG,NGAYHIEULUC= CONVERT(VARCHAR(10),NGAYHIEULUC,103),CHON";
            sql += " FROM DONGIATAILAPMATDUONG ";
            sql += " WHERE MADANHMUC ='" + madanhmuc + "'";
            sql += " ORDER BY STT ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }
        public static DONGIATAILAPMATDUONG finbyDonGiaTLMD(int stt, string madanhmuc)
        {
            var query = from dg in db.DONGIATAILAPMATDUONGs where dg.STT == stt && dg.MADANHMUC == madanhmuc select dg;
            return query.SingleOrDefault();
        }
        public static DONGIATAILAPMATDUONG finbyDonGiaVTbyDanhMuc(string madanhmuc)
        {
            var query = from dg in db.DONGIATAILAPMATDUONGs where dg.CHON == true && dg.MADANHMUC == madanhmuc select dg;
            return query.SingleOrDefault();
        }
        public static void UpdateDGTL(DONGIATAILAPMATDUONG dgtl)
        {
            db.SubmitChanges();
        }
        public static void InsertDGTL(DONGIATAILAPMATDUONG dgtl)
        {
            db.DONGIATAILAPMATDUONGs.InsertOnSubmit(dgtl);
            db.SubmitChanges();
        }
        public static DONGIATAILAPMATDUONG getDonGia(string madanhmuc)
        {
            var query = from dg in db.DONGIATAILAPMATDUONGs where dg.CHON == true && dg.MADANHMUC == madanhmuc select dg;
            return query.SingleOrDefault();
        }
    }
}
