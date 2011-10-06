using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TanHoaWater.Database;

namespace TanHoaWater.DAL
{
    class C_DonGiaVatTu
    {
        public static TanHoaDataContext db = new TanHoaDataContext();
        public static DataTable GetDonGiaVTbyMaHieu(string mahieu)
        {

            db.Connection.Open();
            string sql = "SELECT STT,MAHIEUDG, DGVATLIEU,DGNHANCONG,DGMAYTHICONG,NGAYHIEULUC= CONVERT(VARCHAR(10),NGAYHIEULUC,103),CHON";
            sql += " FROM DONGIAVATTU ";
            sql += " WHERE MAHIEUDG ='" + mahieu + "'";
            sql += " ORDER BY STT ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }
        public static DONGIAVATTU finbyDonGiaVT(int stt, string mahieudg)
        {
            var query = from dg in db.DONGIAVATTUs where dg.STT == stt && dg.MAHIEUDG == mahieudg select dg;
            return query.SingleOrDefault();
        }
        public static DONGIAVATTU finbyDonGiaVTbyMahieu(string mahieudg)
        {
            var query = from dg in db.DONGIAVATTUs where dg.CHON == true && dg.MAHIEUDG == mahieudg select dg;
            return query.SingleOrDefault();
        }
        public static void UpdateDGVT(DONGIAVATTU dgvt)
        {
            db.SubmitChanges();
        }
        public static void InsertDGVT(DONGIAVATTU dgvt)
        {
            db.DONGIAVATTUs.InsertOnSubmit(dgvt);
            db.SubmitChanges();
        }
        public static DONGIAVATTU getDonGia(string mahieudg)
        {
            var query = from dg in db.DONGIAVATTUs where dg.CHON == true && dg.MAHIEUDG == mahieudg select dg;
            return query.SingleOrDefault();
        }
        public static DataTable getDonGiaBoVT(string mahieudg)
        {
            string sql = "select SUM(DGVATLIEU*DM),SUM(DGNHA NCONG*DM),SUM(DGMAYTHICONG*DM) ";
            sql += " FROM DANHMUCVATTU dmvt,DONGIAVATTU dg,DANHMUCBOVATTU bovt  ";
            sql += " WHERE dmvt.MAHIEU= bovt.MAHIEU AND dmvt.MAHIEU=dg.MAHIEUDG AND dg.CHON='True' AND dmvt.MAHIEU='" + mahieudg + "'";
            TanHoaDataContext db = new TanHoaDataContext();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            db.Connection.Close();
            return table;
        }
    }
}