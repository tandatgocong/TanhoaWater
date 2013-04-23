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
    static class C_HoanCongDHN_DotTCTB
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_HoanCongDHN_DotTCTB).Name);
        static TanHoaDataContext db = new TanHoaDataContext();

        public static KH_HOSOKHACHHANG findByHoSoHC(string shs)
        {
            var query = from q in db.KH_HOSOKHACHHANGs where q.SHS == shs select q;
            return query.SingleOrDefault();
        }
        public static bool Update()
        {
            try
            {

                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Insert Danh Muc Vat Tu Loi. " + ex.Message);
            }
            return false;
        }
        public static TCTB_TONGKEVATTU findTongKetVTHC(string dottc)
        {
            var query = from q in db.TCTB_TONGKEVATTUs where q.MADOTTC == dottc select q;
            return query.SingleOrDefault();
        }
        public static bool Insert(TCTB_TONGKEVATTU  tc)
        {
            try
            {
                db.TCTB_TONGKEVATTUs.InsertOnSubmit(tc);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Insert Danh Muc Vat Tu Loi. " + ex.Message);
            }
            return false;
        }
        public static  double getTongCPVatTu(string dottc){        
          var query = from q in db.KH_HOSOKHACHHANGs where q.MADOTTC == dottc  select new {q.TCTB_CPVATTU };
            var sum = query.ToList().Select(c=>c.TCTB_CPVATTU).Sum();
           return sum.Value;
        }
        public static DataSet BC_HOANCONG_TCTB(string madot)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            DataSet dataset = new DataSet();
            string sql = " SELECT * FROM TCTB_HESOHOANCONG ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            adapter.Fill(dataset, "TCTB_HESOHOANCONG");

            sql = "SELECT MADOTTC, SHS, HOTEN, DIACHI, COTLK,CONVERT(VARCHAR(8), NGAYTHICONG, 3) as 'NGAYTHICONG', CHISO, SOTHANTLK, SOHOADON, NGAYDONGTIEN, HIEUDONGHO, TCTB_TONGGIATRI, TCTB_CPNHANCONG, TCTB_CPVATTU, ONG20, ONG50, ONG100, ONG150, ONGKHAC, DHN_NGAYKIEMDINH, ONG25, DANHBO, STT FROM V_HOANGCONGTCTB WHERE MADOTTC=N'" + madot + "' AND (TRONGAI = 'False' OR TRONGAI IS NULL )  ORDER BY STT ASC ";
            adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            adapter.Fill(dataset, "V_HOANGCONGTCTB");

            sql = "SELECT * FROM V_HOANCONG_TRONGAI WHERE MADOTTC=N'" + madot + "' ";
            adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            adapter.Fill(dataset, "V_HOANCONG_TRONGAI");

            sql = "SELECT * FROM TCTB_TONGKEVATTU WHERE MADOTTC=N'" + madot + "' ";
            adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            adapter.Fill(dataset, "TCTB_TONGKEVATTU");

            db.Connection.Close();
            return dataset;
        }
        
    }
}