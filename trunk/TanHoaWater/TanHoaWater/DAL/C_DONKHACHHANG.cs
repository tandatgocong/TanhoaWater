using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TanHoaWater.Database;
using System.Data.SqlClient;
using log4net;
using System.Collections;

namespace TanHoaWater.DAL
{
    public class C_DonKhachHang
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_DonKhachHang).Name);

        public static int TotalListByDot(string dot)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = " SELECT COUNT(*) ";
            sql += " FROM DON_KHACHHANG kh,QUAN q,PHUONG p, LOAI_KHACHHANG lkh ";
            sql += " WHERE  kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND lkh.MALOAI=kh.LOAIKH";
            sql += " AND MADOT='" + dot + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }

        public static DataTable getListbyDot(string dot, int FirstRow, int pageSize)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT SOHOSO,HOTEN, (SONHA +' '+ DUONG +', P.'+p.TENPHUONG+', Q.'+ q.TENQUAN ) as 'DIACHI',NGAYNHAN= CONVERT(VARCHAR(10),NGAYNHAN,103), lkh.TENLOAI as 'LOAIDON' ";
            sql += " FROM DON_KHACHHANG kh,QUAN q,PHUONG p, LOAI_KHACHHANG lkh ";
            sql += " WHERE  kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND lkh.MALOAI=kh.LOAIKH";
            sql += " AND MADOT='" + dot + "'";
            sql += " ORDER BY NGAYNHAN DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, FirstRow, pageSize, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];

        }

        public static DataTable getListbyDot(string dot)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT SHS,HOTEN, (SONHA +' '+ DUONG +', P.'+p.TENPHUONG+', Q.'+ q.TENQUAN ) as 'DIACHI',NGAYNHAN= CONVERT(VARCHAR(10),NGAYNHAN,103), lkh.TENLOAI as 'LOAIDON' ";
            sql += " FROM DON_KHACHHANG kh,QUAN q,PHUONG p, LOAI_KHACHHANG lkh ";
            sql += " WHERE  kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND lkh.MALOAI=kh.LOAIKH";
            sql += " AND MADOT='" + dot + "'";
            sql += " ORDER BY NGAYNHAN DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];

        }

        public static DON_KHACHHANG findBySOHOSO(string sohoso)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from don in db.DON_KHACHHANGs where don.SHS == sohoso select don;
            return data.SingleOrDefault();
        }
        public static DON_KHACHHANG searchTimKiemDon(string sohoso)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from don in db.DON_KHACHHANGs where don.SHS == sohoso || don.HOSOCHA == sohoso select don;
            return data.SingleOrDefault();
        }
        
        public static DON_KHACHHANG findBySOHOSO_(string sohoso)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from don in db.DON_KHACHHANGs where don.SOHOSO == sohoso select don;
            return data.SingleOrDefault();
        }

        public static void chuyenhs(string sohoso)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from don in db.DON_KHACHHANGs where don.SOHOSO == sohoso select don;
            DON_KHACHHANG donKH = data.SingleOrDefault();
            if (donKH != null)
            {
                donKH.CHUYEN_HOSO = true;
                donKH.NGAYCHUYEN_HOSO = DateTime.Now;
            }
            db.SubmitChanges();
        }

        public static void chuyenhs(string sohoso, string nguoichuyen, string pbchuyen)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from don in db.DON_KHACHHANGs where don.SOHOSO == sohoso select don;
            DON_KHACHHANG donKH = data.SingleOrDefault();
            if (donKH != null)
            {
                donKH.CHUYEN_HOSO = true;
                donKH.NGAYCHUYEN_HOSO = DateTime.Now;
                donKH.NGUOICHUYEN_HOSO = nguoichuyen;
                donKH.BOPHANCHUYEN = pbchuyen;
            }
            db.SubmitChanges();
        }

        public static void chuyenhsbydot(string sodot, string nguoichuyen, string pbchuyen)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = " UPDATE DON_KHACHHANG SET CHUYEN_HOSO='True' ";
            sql += ",BOPHANCHUYEN = '" + pbchuyen + "', NGUOICHUYEN_HOSO = '" + nguoichuyen + "', NGAYCHUYEN_HOSO='" + DateTime.Now + "'";
            sql += " WHERE MADOT='" + sodot + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            db.SubmitChanges();
        }

        public static bool InsertDonHK(DON_KHACHHANG donkh)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.DON_KHACHHANGs.InsertOnSubmit(donkh);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Insert Dot KHACH HANG LOI " + ex.Message);
            }
            return false;
        }

        public static bool UpdateDONKH(DON_KHACHHANG donkh)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Update Dot KHACH HANG LOI " + ex.Message);
            }
            return false;
        }

        public static bool updateDoninBienNhan(string shs, string hoten, string dienthoai, string sonha, string tenduong, string maphuong, int maquan)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var bb = from aa in db.DON_KHACHHANGs where aa.SHS == shs select aa;
            DON_KHACHHANG donkh = bb.SingleOrDefault();
            if (donkh != null)
            {
                try
                {
                    donkh.HOTEN = hoten;
                    donkh.DIENTHOAI = dienthoai;
                    donkh.SONHA = sonha;
                    donkh.DUONG = tenduong;
                    donkh.PHUONG = maphuong;
                    donkh.QUAN = maquan;
                    donkh.MODIFYBY = DAL.C_USERS._userName;
                    donkh.MODIFYDATE = DateTime.Now;
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    log.Error("" + ex.Message);
                    return false;
                }


            }
            return false;
        }

        public static bool DeleteDonKH(string donkh)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var ff = from aa in db.DON_KHACHHANGs where aa.SOHOSO == donkh select aa;
                db.DON_KHACHHANGs.DeleteOnSubmit(ff.SingleOrDefault());
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Delete Dot KHACH HANG LOI " + ex.Message);
            }
            return false;
        }

        public static DataTable BangKeNhanDon(string madot, string nguoilap)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT * ";
            sql += " FROM V_DONKHACHHANG ";
            sql += " WHERE  MADOT='" + madot + "' AND USERNAME='" + nguoilap + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            db.Connection.Close();
            return table;

        }

        public static bool findByAddressAndLoaiHS(string dot, string loaiHS, string sonha, string duong, string phuong, string quan)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            string sql = " SELECT SONHA = replace(SONHA,' ',''), DUONG = replace(DUONG,' ',''),PHUONG,QUAN ";
            sql += " FROM DON_KHACHHANG ";
            sql += " WHERE MADOT='" + dot + "' AND LOAIHOSO='" + loaiHS + "' AND SONHA='" + sonha + "' AND DUONG='" + duong + "' AND PHUONG='" + phuong + "' AND QUAN='" + quan + "' ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            db.Connection.Close();
            if (table.Rows.Count > 0)
                return true;

            return false;
        }

        public static DataTable search(string dotND, string mahs, string tenkh, string sonha, string tenduong, int FirstRow, int pageSize)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT MADOT,SOHOSO,HOTEN,(SONHA +' '+ DUONG +', P.'+p.TENPHUONG+', Q.'+ q.TENQUAN ) as 'DIACHI', NGAYNHAN= CONVERT(VARCHAR(10),NGAYNHAN,103), lhs.TENLOAI ";
            sql += " FROM DON_KHACHHANG kh,QUAN q,PHUONG p, LOAI_HOSO lhs ";
            sql += " WHERE  kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND lhs.MALOAI=kh.LOAIHOSO  ";

            if (dotND != null && !"".Equals(dotND))
            {
                sql += " AND MADOT='" + dotND + "'";
            }
            if (!"".Equals(mahs))
            {
                sql += " AND SHS='" + mahs + "'";
            }
            if (!"".Equals(tenkh))
            {
                sql += " AND HOTEN LIKE '%" + tenkh + "%'";
            }
            if (!"".Equals(sonha))
            {
                sql += " AND SONHA LIKE '%" + sonha + "%'";
            }
            if (!"".Equals(tenduong))
            {
                sql += " AND DUONG LIKE '%" + tenduong + "%'";
            }
            sql += " ORDER BY NGAYNHAN DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, FirstRow, pageSize, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }

        public static int TotalPageSearch(string dotND, string mahs, string tenkh, string sonha, string tenduong)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT MADOT,SOHOSO,HOTEN,(SONHA +' '+ DUONG +', P.'+p.TENPHUONG+', Q.'+ q.TENQUAN ) as 'DIACHI', NGAYNHAN= CONVERT(VARCHAR(10),NGAYNHAN,103), lhs.TENLOAI ";
            sql += " FROM DON_KHACHHANG kh,QUAN q,PHUONG p, LOAI_HOSO lhs ";
            sql += " WHERE  kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND lhs.MALOAI=kh.LOAIHOSO  ";

            if (dotND != null && !"".Equals(dotND))
            {
                sql += " AND MADOT='" + dotND + "'";
            }
            if (!"".Equals(mahs))
            {
                sql += " AND SHS='" + mahs + "'";
            }
            if (!"".Equals(tenkh))
            {
                sql += " AND HOTEN LIKE '%" + tenkh + "%'";
            }
            if (!"".Equals(sonha))
            {
                sql += " AND SONHA LIKE '%" + sonha + "%'";
            }
            if (!"".Equals(tenduong))
            {
                sql += " AND DUONG LIKE '%" + tenduong + "%'";
            }
            sql += " ORDER BY NGAYNHAN DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0].Rows.Count;
        }

        public static bool TroNgaiThietKe(string sohoso, string lydotrongai, string modifyby)
        {

            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var data = from don in db.DON_KHACHHANGs where don.SOHOSO == sohoso select don;
                DON_KHACHHANG donkh = data.SingleOrDefault();
                if (donkh != null)
                {
                    donkh.TRONGAITHIETKE = true;
                    donkh.NOIDUNGTRONGAI = lydotrongai;
                    donkh.MODIFYBY = DAL.C_USERS._userName;
                    donkh.MODIFYDATE = DateTime.Now.Date;
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Cap nhat tro ngai tk loi " + ex.Message);
            }
            return false;
        }

        public static bool HoSoTaiXet(string sohoso, string modifyby)
        {

            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var data = from don in db.DON_KHACHHANGs where don.SOHOSO == sohoso select don;
                DON_KHACHHANG donkh = data.SingleOrDefault();
                if (donkh != null)
                {
                    donkh.TRONGAITHIETKE = false;
                    donkh.NOIDUNGTRONGAI = "";
                    donkh.BOPHANCHUYEN = "TTK";
                    donkh.NGUOICHUYEN_HOSO = DAL.C_USERS._userName;
                    donkh.NGAYCHUYEN_HOSO = System.DateTime.Now.Date;
                    donkh.MODIFYBY = DAL.C_USERS._userName;
                    donkh.MODIFYDATE = DateTime.Now.Date;
                    #region Insert Tai Xet
                    TMP_TAIXET tx = new TMP_TAIXET();
                    tx.MAHOSO = donkh.SOHOSO;
                    tx.CHUYEN = false;
                    tx.CREATEDATE = DateTime.Now.Date;
                    db.TMP_TAIXETs.InsertOnSubmit(tx);
                    #endregion
                }

                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                log.Error("Cap nhat don tai xet loi " + ex.Message);
            }
            return false;
        }

        public static DataTable finbyDonKHTinhDuToan(string shs)
        {
            string sql = " SELECT ttk.MADOT, ttk.SHS, HOTEN, kh.DIENTHOAI,";
            sql += " SONHA,DUONG,p.TENPHUONG,q.TENQUAN,SOHO,lkh.TENLOAI,DANHBO,lhs.TENLOAI,FULLNAME, kh.TINHKHOAN,kh.LOAIMIENPHI ";// end 14
            sql += " FROM TOTHIETKE ttk, DON_KHACHHANG kh,QUAN q,PHUONG p, LOAI_HOSO lhs, USERS us, LOAI_KHACHHANG lkh ";
            sql += " WHERE kh.LOAIKH=lkh.MALOAI AND  kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND lhs.MALOAI=kh.LOAIHOSO AND ttk.SOHOSO=kh.SOHOSO AND us.USERNAME=ttk.SODOVIEN";
            sql += " AND ttk.SHS ='" + shs + "'";
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            db.Connection.Close();
            return table;
        }

        public static DataTable getListTaiXet()
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT SOHOSO,HOTEN, (SONHA +' '+ DUONG +', P.'+p.TENPHUONG+', Q.'+ q.TENQUAN ) as 'DIACHI',NGAYNHAN= CONVERT(VARCHAR(10),NGAYNHAN,103), lkh.TENLOAI as 'LOAIDON' ";
            sql += " FROM DON_KHACHHANG kh,QUAN q,PHUONG p, LOAI_KHACHHANG lkh, TMP_TAIXET taixet ";
            sql += " WHERE  taixet.MAHOSO=kh.SOHOSO AND taixet.CHUYEN='False' AND kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND lkh.MALOAI=kh.LOAIKH";
            sql += " ORDER BY NGAYNHAN DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];

        }

        public static TMP_TAIXET finbyDTX(string mahoso)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var query = from taixet in db.TMP_TAIXETs where taixet.MAHOSO == mahoso select taixet;
            return query.SingleOrDefault();
        }

        public static bool UpdateDonTX(string mahoso)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var data = from don in db.TMP_TAIXETs where don.MAHOSO == mahoso select don;
                TMP_TAIXET tx = data.SingleOrDefault();
                if (tx != null)
                {
                    tx.CHUYEN = false;
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Cap nhat don tai xet loi " + ex.Message);
            }
            return false;

        }

        public static void ChuyenHSTaiXet(string mahoso)
        {

            TanHoaDataContext db = new TanHoaDataContext();
            var data = from don in db.DON_KHACHHANGs where don.SOHOSO == mahoso select don;
            DON_KHACHHANG donkh = data.SingleOrDefault();
            if (donkh != null)
            {
                #region Cap Nhat TMP_TRONGAI
                var taixet = from don in db.TMP_TAIXETs where don.MAHOSO == mahoso select don;
                TMP_TAIXET donTaiXet = taixet.SingleOrDefault();
                if (donTaiXet != null)
                {
                    donTaiXet.CHUYEN = true;
                    donTaiXet.NGUOICHUYEN = DAL.C_USERS._userName;
                    donTaiXet.NGAYCHUYEN = DateTime.Now.Date;

                    #region CapnhatTTK
                    var totk = from don in db.TOTHIETKEs where don.SOHOSO == mahoso select don;
                    TOTHIETKE ttk = totk.SingleOrDefault();
                    if (ttk != null)
                    {
                        ttk.SODOVIEN = null;
                        ttk.NGAYNHAN = DateTime.Now.Date;
                        ttk.TRAHS = false;
                        ttk.TRONGAITHIETKE = false;
                    }
                    else
                    {
                        ttk = new TOTHIETKE();
                        ttk.MADOT = donkh.MADOT;
                        ttk.SOHOSO = donkh.SOHOSO;
                        ttk.SHS = donkh.SHS;
                        ttk.NGAYNHAN = DateTime.Now.Date;
                        DAL.C_ToThietKe.addNew(ttk);
                    }
                    #endregion
                }
                #endregion

                db.SubmitChanges();
            }

        }

        public static DataSet In_Dontaixet(string nguoiduyet)
        {

            DataSet ds = new DataSet();
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = "SELECT * FROM V_DONTAIXET WHERE  USERNAME='" + DAL.C_USERS._userName + "'";
            SqlDataAdapter dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            dond.Fill(ds, "V_DONTAIXET");

            string user = "SELECT USERNAME, UPPER(FULLNAME) AS 'FULLNAME' FROM USERS WHERE USERNAME='" + nguoiduyet + "'";
            SqlDataAdapter ct = new SqlDataAdapter(user, db.Connection.ConnectionString);
            ct.Fill(ds, "USERS");
            return ds;
        }

        public static void UpdateHoSoCon(string shs, string hscha)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var data = from don in db.DON_KHACHHANGs where don.SHS == shs select don;
                DON_KHACHHANG donkh = data.SingleOrDefault();
                if (donkh != null)
                {
                    donkh.HOSOCHA = hscha;
                }
                else
                {
                    log.Error(hscha + " Con :" + shs + "Cap Nhat Ho So Con Bi Loi.");
                }
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error("Cap Nhat Ho So Con Bi Loi." + ex.Message);
            }
        }

        public static bool UpdateHoSoCha(string shs, int soho)
        {

            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var data = from don in db.DON_KHACHHANGs where don.SHS == shs select don;
                DON_KHACHHANG donkh = data.SingleOrDefault();
                if (donkh != null)
                {
                    donkh.SOHO = soho;
                    donkh.HOTEN = donkh.HOTEN + " ( ĐD " + soho + " Hộ) ";
                    donkh.LOAIKH = "TT";
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Cap Nhat Ho So Cha Bi Loi." + ex.Message);
            }
            return false;
        }

        public static DataTable TimKiemDonKhachHang(string shs, string hoten, string diachi)
        {

            string sql = "SELECT ttk.MADOT, ttk.SHS,ttk.SOHOSO,kh.HOSOCHA, ";
            sql += " HOTEN, kh.DIENTHOAI,( SONHA +'  '+DUONG+',  P.'+ p.TENPHUONG+',  Q.'+q.TENQUAN) as 'DIACHI',SOHO, ";
            sql += " lkh.TENLOAI as 'LOAIKH',lhs.TENLOAI as 'LOAIHS', CONVERT(VARCHAR(20),kh.NGAYNHAN,103) AS 'NGAYNHAN', ";
            sql += " CONVERT(VARCHAR(20),ttk.NGAYNHAN,103) AS 'NGAYGIAOTTK_', SODOVIEN,CONVERT(VARCHAR(20),ttk.NGAYTKGD,103) as 'NGAYTKGD' , ttk.NGAYTRAHS,kh.TRONGAITHIETKE,kh.NOIDUNGTRONGAI ";
            sql += " FROM TOTHIETKE ttk, DON_KHACHHANG kh,QUAN q,PHUONG p ";
            sql += " , LOAI_HOSO lhs, LOAI_KHACHHANG lkh  ";
            sql += " WHERE kh.LOAIKH=lkh.MALOAI AND  kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN  ";
            sql += " AND kh.PHUONG=p.MAPHUONG AND lhs.MALOAI=kh.LOAIHOSO ";
            sql += " AND ttk.SOHOSO=kh.SOHOSO  ";
           
            if (!"".Equals(shs)) {
                sql += " AND (ttk.SHS = '" + shs + "' OR kh.HOSOCHA = '" + shs + "' )";
            }
            if (!"".Equals(hoten))
            {
                sql += " AND HOTEN LIKE N'%" + hoten + "%'";
            }
            if (!"".Equals(diachi))
            {
                sql += " AND ( SONHA +'  '+DUONG+',  P.'+ p.TENPHUONG+',  Q.'+q.TENQUAN) LIKE N'%" + diachi + "%'";
            }

            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            db.Connection.Close();
            return table;

        }

        public static void DongTienKH(string shs, DateTime ngaydong, string sohoadon) {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var data = from don in db.DON_KHACHHANGs where don.SHS == shs select don;
                DON_KHACHHANG donkh = data.SingleOrDefault();
                if (donkh != null)
                {
                    donkh.SOHOADON = sohoadon;
                    donkh.NGAYDONGTIEN = ngaydong;
                    donkh.MODIFYBY = DAL.C_USERS._userName;
                    donkh.MODIFYDATE = DateTime.Now;

                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
      
        
        public static DON_KHACHHANG findBySHSEdit(string sohoso)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from don in db.DON_KHACHHANGs where don.SHS == sohoso select don;
            return data.SingleOrDefault();
        }
        public static void SHSupdate(DON_KHACHHANG donkh)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = " UPDATE DON_KHACHHANG SET ";
            sql += " HOTEN = N'" + donkh.HOTEN + "'";
            sql += ", SOHO = N'" + donkh.SOHO + "'";
            sql += ", SONHA = N'" + donkh.SONHA + "'";
            sql += ", DUONG = N'" + donkh.DUONG + "'";
            sql += ", PHUONG = '" + donkh.PHUONG + "'";
            sql += ", QUAN = '" + donkh.QUAN + "'";
            sql += ", LOAIKH = '" + donkh.LOAIKH + "'";
            sql += ", DIENTHOAI = '" + donkh.DIENTHOAI + "'";
            sql += ", GHICHU = '" + donkh.GHICHU + "'";
            sql += ", MADOT = '" + donkh.MADOT + "'";
            sql += ", MODIFYBY = '" + donkh.MODIFYBY + "'";
            sql += ", MODIFYDATE = '" + donkh.MODIFYDATE + "'";
            sql += ", MODIFYLOG = N'" + donkh.MODIFYLOG + "'";
            sql += " WHERE SHS='" + donkh.SHS + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
        }
    }
}