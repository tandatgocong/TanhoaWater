using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;
using TanHoaWater.View.Report;
using log4net;
using System.Data.SqlClient;

namespace TanHoaWater.DAL
{
    class C_KH_DotThiCong
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_KH_DotThiCong).Name);
        static TanHoaDataContext db = new TanHoaDataContext();
        public static string __dotthicong = "";
        public static KH_DOTTHICONG findByMadot(string madot)
        {
            try
            {
                var query = from dottc in db.KH_DOTTHICONGs where dottc.MADOTTC == madot select dottc;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }
        public static List<KH_DOTTHICONG> getListDTC()
        {
            try
            {
                var query = from dottc in db.KH_DOTTHICONGs where dottc.CREATEDATE.Value.Year==DateTime.Now.Year ||  dottc.CREATEDATE.Value.Year==(DateTime.Now.Year -1) orderby dottc.MADOTTC descending select dottc;
                return query.ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static KH_LOAIBANGKE getByTenLoaiBK(string tenloai) {
            try
            {
                var query = from dottc in db.KH_LOAIBANGKEs where dottc.TENBANGKE == tenloai select dottc;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static bool InsertDotTC(KH_DOTTHICONG dottc)
        {
            try
            {
                db.KH_DOTTHICONGs.InsertOnSubmit(dottc);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }

        public static bool InsertDotTC_BS(KH_HOSOKHACHHANG_BS dottc)
        {
            try
            {
                db.KH_HOSOKHACHHANG_BS.InsertOnSubmit(dottc);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }



        public static bool UpdateDotTC(KH_DOTTHICONG dottc)
        {
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }
        public static bool DeleteDotTC(KH_DOTTHICONG dottc)
        {
            try
            {
                db.KH_DOTTHICONGs.DeleteOnSubmit(dottc);
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }
        public static int TotalListDotThiCong()
        {
            //TanHoaDataContext db = new TanHoaDataContext();
            //SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            //conn.Open();
            string sql = " SELECT COUNT(*) FROM KH_DOTTHICONG";
            //SqlCommand cmd = new SqlCommand(sql, conn);
            //int result = Convert.ToInt32(cmd.ExecuteScalar());
            //conn.Close();
            //return result;
            return DAL.LinQConnection.ExecuteCommand(sql);
        }
        public static DataTable getListDotThiCong(int FirstRow, int pageSize)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT MADOTTC,NGAYLAP, LOAIBANGKE FROM KH_DOTTHICONG";
            sql += " ORDER BY LOAIBANGKE DESC,NGAYLAP DESC";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, FirstRow, pageSize, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }
        public static DataTable getListDotThiCongbyMaDot(string madot)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT MADOTTC,NGAYLAP, LOAIBANGKE FROM KH_DOTTHICONG WHERE MADOTTC LIKE N'%" + madot + "%'";
            sql += " ORDER BY NGAYLAP DESC  ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }
        public static List<KH_DOTTHICONG> AutoCompleteDotNhanDon()
        {

            try
            {
                var query = from dottc in db.KH_DOTTHICONGs orderby dottc.NGAYLAP descending select dottc;
                return query.ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static List<KH_DONVIGIAMSAT> DonViGiamSat()
        {

            try
            {
                var query = from dottc in db.KH_DONVIGIAMSATs orderby dottc.ID descending select dottc;
                return query.ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static DataTable findByHSHT(string shs)
        {

            try
            {

                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                string sql = " SELECT donkh.SHS,donkh.SOHOSO,HOTEN, SONHA + ' ' + DUONG,TENPHUONG,TENQUAN, NGAYDONGTIEN,SOHOADON,DANHBO,GHICHU ";
                sql += " FROM DON_KHACHHANG donkh, PHUONG p, QUAN q ";
                sql += " WHERE donkh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND donkh.PHUONG=p.MAPHUONG ";
                sql += " AND donkh.SHS='" + shs + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "TABLE");
                db.Connection.Close();
                return dataset.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error("Loi BC Danh Sach Thi Cong " + ex.Message);
            }
            return null;

        }

        public static DataTable getListDotThiCong(string madottc)
        {

            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                string sql = " SELECT HUY=N'Hủy', donkh.SHS,donkh.SOHOSO,donkh.MADOT, hosokh.STT , HOTEN,SONHA, DUONG,TENPHUONG,DIENTHOAI, hosokh.MADOTDD,hosokh.NGAYNHAN, NGAYDONGTIEN,SOHOADON,ROUND(TONGIATRI,0) as 'TONGIATRI',ROUND(TAILAPMATDUONG,0) as 'TAILAPMATDUONG',ROUND(TONGIATRI,0)+ROUND(TAILAPMATDUONG,0) as 'TONGTIEN',COTLK,donkh.GHICHU,donkh.DANHBO  ";
                sql += "  FROM DON_KHACHHANG donkh, PHUONG p, QUAN q, KH_HOSOKHACHHANG hosokh ";
                sql += " WHERE donkh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND donkh.PHUONG=p.MAPHUONG and donkh.SHS = hosokh.SHS ";
                sql += " AND hosokh.MADOTTC=N'" + madottc + "'";
                sql += " ORDER BY hosokh.STT ASC ";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "TABLE");
                db.Connection.Close();
                return dataset.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error("Loi BC Danh Sach Thi Cong " + ex.Message);
            }
            return null;
        }

        public static DataTable getListDotThiCong_BS(string madottc, string lan)
        {

            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                string sql = " SELECT HUY=N'Hủy', donkh.SHS,donkh.SOHOSO,donkh.MADOT, hosokh.STT , HOTEN,SONHA, DUONG,TENPHUONG,DIENTHOAI, hosokh.MADOTDD,hosokh.NGAYNHAN, NGAYDONGTIEN,SOHOADON,ROUND(TONGIATRI,0) as 'TONGIATRI',ROUND(TAILAPMATDUONG,0) as 'TAILAPMATDUONG',ROUND(TONGIATRI,0)+ROUND(TAILAPMATDUONG,0) as 'TONGTIEN',COTLK,donkh.GHICHU,donkh.DANHBO  ";
                sql += "  FROM DON_KHACHHANG donkh, PHUONG p, QUAN q, KH_HOSOKHACHHANG hosokh ";
                sql += " WHERE donkh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND donkh.PHUONG=p.MAPHUONG and donkh.SHS = hosokh.SHS ";
                sql += " AND hosokh.SHS IN (SELECT SHS FROM KH_HOSOKHACHHANG_BS WHERE MADOTTC='" + madottc + "' AND LANBOSUNG=" + lan;
                sql += ") ORDER BY hosokh.STT ASC ";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "TABLE");
                db.Connection.Close();
                return dataset.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error("Loi BC Danh Sach Thi Cong " + ex.Message);
            }
            return null;
        }

        public static DataTable getListHSbyBangKe(string bangke)
        {

            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                string sql = "SELECT HUY=N'Thêm', donkh.SHS,donkh.SOHOSO,donkh.MADOT,HOTEN, SONHA, DUONG,TENPHUONG,DIENTHOAI ";
                sql += "   FROM DON_KHACHHANG donkh, PHUONG p, QUAN q  ";
                sql += " WHERE donkh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND donkh.PHUONG=p.MAPHUONG ";
                sql += " AND donkh.MADOT LIKE N'%" + bangke + "%'";
                sql += " ORDER BY donkh.CREATEDATE  ";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "TABLE");
                db.Connection.Close();
                return dataset.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error("Loi BC Danh Sach Thi Cong " + ex.Message);
            }
            return null;
        }
        public static DataSet BC_QuyetDinhThiCong(string madot, string donvigiamsat, string ngaykhoicong, string ngayhoantat)
        {

            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                DataSet dataset = new DataSet();
                string sql = " SELECT * FROM KH_TC_BAOCAO ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(dataset, "KH_TC_BAOCAO");

                sql = " SELECT *,NGAYTHICONG='" + ngaykhoicong + "',NGAYHOANTAT='" + ngayhoantat + "' FROM V_QUYETDINHTHICONG WHERE MADOTTC=N'" + madot + "'";
                adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(dataset, "V_QUYETDINHTHICONG");

                db.Connection.Close();
                return dataset;
            }
            catch (Exception ex)
            {
                log.Error("Loi BC Danh Sach Thi Cong " + ex.Message);
            }
            return null;
        }
        public static DataSet BC_ThongBaoThiCong(string madot )
        {

            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                DataSet dataset = new DataSet();
                string sql = " SELECT * FROM KH_TC_BAOCAO ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(dataset, "KH_TC_BAOCAO");

                sql = " select N'- UBND PHƯỜNG '+ UPPER(p.TENPHUONG) as TENPHUONG from DON_KHACHHANG don,PHUONG p,KH_HOSOKHACHHANG hs ";
                sql+=" where don.QUAN=p.MAQUAN and don.PHUONG=p.MAPHUONG and don.SHS=hs.SHS and hs.MADOTTC=N'"+madot+"' GROUP BY p.TENPHUONG ";
                adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(dataset, "thongbao_phuong");


                sql = " SELECT *  FROM V_DANHSACHTHICONG WHERE MADOTTC=N'" + madot + "' ORDER BY STT ASC ";
                adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(dataset, "V_DANHSACHTHICONG");



                db.Connection.Close();
                return dataset;
            }
            catch (Exception ex)
            {
                log.Error("Loi BC Danh Sach Thi Cong " + ex.Message);
            }
            return null;
        }

        public static DataSet BC_DanhSachDotThiCong(string madot)
        {

            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                DataSet dataset = new DataSet();
                string sql = " SELECT * FROM KH_TC_BAOCAO ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(dataset, "KH_TC_BAOCAO");

                sql = " SELECT *  FROM V_DANHSACHTHICONG WHERE MADOTTC=N'" + madot + "' ORDER BY STT ASC ";
                adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(dataset, "V_DANHSACHTHICONG");

                db.Connection.Close();
                return dataset;
            }
            catch (Exception ex)
            {
                log.Error("Loi BC Danh Sach Thi Cong " + ex.Message);
            }
            return null;
        }

        public static DataSet BC_DanhSachDotThiCong_BS(string madot, string lan)
        {

            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                DataSet dataset = new DataSet();
                string sql = " SELECT * FROM KH_TC_BAOCAO ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(dataset, "KH_TC_BAOCAO");

                sql = "SELECT bs.SHS, SOHOSO, MADOT, HOTEN, DIENTHOAI, SONHA, DUONG, TENPHUONG, TENQUAN, MADOTDD, CHOPHEP, NGAYCOPHEP, bs.MADOTTC, TRONGAI, NOIDUNGTN, GHICHU, ";
                sql += "COTLK, CPVATTU, CPNHANCONG, CPMAYTHICONG, CPCABA, CHIPHITRUCTIEP, CHIPHICHUNG, bs.TAILAPMATDUONG, TLMDTRUOCTHUE, CONG1, THUE55, CONG3, THUEGTGT, bs.TONGIATRI, ";
                sql += "CREATEBY, CREATEDATE, MODIFYBY, MODIFYDATE, MODIFYLOG, TONGTIEN, NGAYLAP, SOLUONGTLK, DONVITHICONG, DONVITAILAP, NGAYCHUYENDVTC, CHUYENBUHANMUC, BANGKE, ";
                sql += "LOAIBANGKE, NGAYHC, GHICHUHC, SOLUONG_HCTLK, CONLAI_TLK, QUYETTOAN, NGAYCHUYENKT, NGAYTHANHTOAN, TRONGAITC, STT,CONVERT(varchar(20),bs.NGAYDONGTIEN,103) as 'NGAYDONGTIEN', bs.SOHOADON ";
                sql += "FROM V_DANHSACHTHICONG tc, KH_HOSOKHACHHANG_BS bs ";
                sql += "WHERE tc.SHS=bs.SHS AND bs.MADOTTC='" + madot + "' ";
                //  sql = " SELECT *  FROM V_DANHSACHTHICONG WHERE SHS IN (SELECT SHS FROM KH_HOSOKHACHHANG_BS WHERE MADOTTC='" + madot + "' AND LANBOSUNG='" + lan + "')  ORDER BY STT ASC ";
                adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(dataset, "V_DANHSACHTHICONG_OC");

                db.Connection.Close();
                return dataset;
            }
            catch (Exception ex)
            {
                log.Error("Loi BC Danh Sach Thi Cong " + ex.Message);
            }
            return null;
        }
  
        public static DataTable getListDotThiCongBT(string madottc)
        {

            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                string sql = " SELECT HUY=N'Hủy',donkh.SHS,donkh.SOHOSO,HOTEN, (SONHA + ' ' + DUONG + ', P.' +TENPHUONG+ ', Q.'+ q.TENQUAN) as 'DIACHI',NGAYDONGTIEN,donkh.SOTIEN,donkh.DANHBO,COTLK,donkh.GHICHU,DIENTHOAI";
                sql += " FROM DON_KHACHHANG donkh, PHUONG p, QUAN q, KH_HOSOKHACHHANG hosokh ";
                sql += " WHERE donkh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND donkh.PHUONG=p.MAPHUONG and donkh.SHS = hosokh.SHS ";
                sql += " AND hosokh.MADOTTC=N'" + madottc + "'";
                sql += " ORDER BY hosokh.STT ASC ";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "TABLE");
                db.Connection.Close();
                return dataset.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error("Loi BC Danh Sach Thi Cong " + ex.Message);
            }
            return null;
        }
        public static DataSet BC_DanhSachDotThiCong_BT(string madot)
        {

            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                DataSet dataset = new DataSet();
                string sql = " SELECT * FROM KH_TC_BAOCAO ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(dataset, "KH_TC_BAOCAO");

                sql = " SELECT *  FROM V_DANHSACHTHICONG_BT WHERE MADOTTC=N'" + madot + "' ORDER BY STT ASC ";
                adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(dataset, "V_DANHSACHTHICONG_BT");

                db.Connection.Close();
                return dataset;
            }
            catch (Exception ex)
            {
                log.Error("Loi BC Danh Sach Thi Cong " + ex.Message);
            }
            return null;
        }
        public static DataSet BC_DanhSachDotThiCong_OC(string madot)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                DataSet dataset = new DataSet();
                string sql = " SELECT * FROM KH_TC_BAOCAO ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(dataset, "KH_TC_BAOCAO");

                sql = " SELECT *  FROM V_DANHSACHTHICONG_OC WHERE MADOTTC=N'" + madot + "' ORDER BY STT ASC ";
                adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(dataset, "V_DANHSACHTHICONG_OC");
                db.Connection.Close();
                return dataset;
            }
            catch (Exception ex)
            {
                log.Error("Loi BC Danh Sach Thi Cong " + ex.Message);
            }
            return null;
        }
        public static void UpdateSTT(string shs, int stt)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                conn.Open();
                string sql = " UPDATE KH_HOSOKHACHHANG SET STT='" + stt + "' WHERE SHS='" + shs + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                log.Error(" Loi Update So TT " + ex.Message);
            }

        }
    }

}