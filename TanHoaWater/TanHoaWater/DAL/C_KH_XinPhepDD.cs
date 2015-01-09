using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using System.Data;
using System.Data.SqlClient;
using log4net;
using System.Text.RegularExpressions;

namespace TanHoaWater.DAL
{
    class C_KH_XinPhepDD
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_KH_XinPhepDD).Name);
        static TanHoaDataContext db = new TanHoaDataContext();
        public static int TotalList(string sodot, string noicapphep, string ngaylap)
        {
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = " SELECT COUNT(*)";
            sql += " FROM KH_XINPHEPDAODUONG WHERE MADOT IS NOT NULL AND CREATEBY='" + DAL.C_USERS._userName + "' ";
            if (!"".Equals(sodot))
            {
                sql += " AND MADOT LIKE '%" + sodot + "%'";
            }
            if (!"".Equals(noicapphep))
            {
                sql += " AND NOICAPPHEP='" + noicapphep + "'";
            }
            if (!"".Equals(ngaylap))
            {
                sql += " AND CONVERT(VARCHAR(10),NGAYLAP,103)='" + ngaylap + "'";
            }
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }
     
        public static DataTable findByHSHT(string shs) {

           
            string sql = "  SELECT donkh.SHS,HOTEN, SONHA + ' ' + DUONG + ', P.' + TENPHUONG  as 'DIACHI' ";
            sql += " FROM DON_KHACHHANG donkh,PHUONG p, QUAN q ";
            sql += " WHERE donkh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND donkh.PHUONG=p.MAPHUONG ";
            sql += " AND donkh.SHS='" + shs + "'";


            return LinQConnection.getDataTable(sql);

       
        }
        public static List<KH_HOSOKHACHHANG> ListHSKHByDotTC(string dottc) {
            TanHoaDataContext db = new TanHoaDataContext();
            var obj = from dd in db.KH_HOSOKHACHHANGs where dd.MADOTDD==dottc select dd;
            return obj.ToList();
        }
        public static DataTable getList(string sodot, string noicapphep, string ngaylap, int FirstRow, int pageSize)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT MADOTXP,MADOT,NOICAPPHEP,NGAYLAP,MAQUANLY,NGAYCOPHEP";
            sql += " FROM KH_XINPHEPDAODUONG WHERE MADOT IS NOT NULL AND CREATEBY='"+ DAL.C_USERS._userName +"'";
            if (!"".Equals(sodot))
            {
                sql += " AND MADOT LIKE '%" + sodot + "%'";
            }
            if (!"".Equals(noicapphep))
            {
                sql += " AND NOICAPPHEP='" + noicapphep + "'";
            }
            if (!"".Equals(ngaylap))
            {
                sql += " AND CONVERT(VARCHAR(10),NGAYLAP,103)='" + ngaylap + "'";
            }
            sql += " ORDER BY NGAYLAP DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, FirstRow, pageSize, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }

        public static List<KH_NOICAPPHEP> getNoiXiPhep()
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var obj = from dd in db.KH_NOICAPPHEPs select dd;
            return obj.ToList();
        }
        public static KH_XINPHEPDAODUONG finbyMaDot(string madot) {
            var obj = from dd in db.KH_XINPHEPDAODUONGs where dd.MADOT == madot  select dd ;
            return obj.SingleOrDefault();
        }

        public static DA_XINPHEP finbyMaDotDA(string madot)
        {
            var obj = from dd in db.DA_XINPHEPs where dd.MADOT == madot select dd;
            return obj.SingleOrDefault();
        }

        public static bool InsertDA(DA_XINPHEP xpdd)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.DA_XINPHEPs.InsertOnSubmit(xpdd);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Insert Xin Phep Dao Duong Loi. " + ex.Message);
            }
            return false;
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
                log.Error("Insert Xin Phep Dao Duong Loi. " + ex.Message);
            }
            return false;
        }

        public static List<KH_XINPHEPDAODUONG> ListAllXinPhepDD()
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var obj = from dd in db.KH_XINPHEPDAODUONGs where dd.CREATEBY== DAL.C_USERS._userName orderby dd.NGAYLAP ascending  select dd;
            return obj.ToList();
        }
     
        public static bool Insert(KH_XINPHEPDAODUONG xpdd) {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.KH_XINPHEPDAODUONGs.InsertOnSubmit(xpdd);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Insert Xin Phep Dao Duong Loi. " + ex.Message);
            }
            return false;
        }

        public static bool InsertPhuiDao(KH_BAOCAOPHUIDAO xpdd)
        {
            try
            {
                db.KH_BAOCAOPHUIDAOs.InsertOnSubmit(xpdd);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Insert Xin Phep Dao Duong Loi. " + ex.Message);
            }
            return false;
        }
     
        public static bool Delete(string madot) { 
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var obj = from dd in db.KH_XINPHEPDAODUONGs where dd.MADOT == madot select dd;
                if (obj != null)
                    db.KH_XINPHEPDAODUONGs.DeleteOnSubmit(obj.SingleOrDefault());
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Delete Xin Phep Dao Duong Loi. " + ex.Message);
            }
            return false;
        }

        public static bool findBaoCaoPhuiDao(string shs) {
            TanHoaDataContext db = new TanHoaDataContext();
            var listPhui = from query in db.KH_BAOCAOPHUIDAOs where query.SHS == shs select query;
            if (listPhui.ToList().Count > 0)
                return true;
            return false;
        }
        
        public static List<KH_BAOCAOPHUIDAO> getListBCPhuiDao(string shs) {
            TanHoaDataContext db = new TanHoaDataContext();
            var listPhui = from query in db.KH_BAOCAOPHUIDAOs where query.SHS == shs select query;
            return listPhui.ToList();
        }
        
        public static void getPhuiDao(string shs) {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);

                conn.Open();
                SqlCommand cmd = new SqlCommand("TONGKETPHUIDAO", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter inparm = cmd.Parameters.Add("@shs", SqlDbType.VarChar);
                inparm.Direction = ParameterDirection.Input;
                inparm.Value = shs;

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            
        }

        public static void TinhPhuiDao(string shs) {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var listPhui = from query in db.KH_BAOCAOPHUIDAOs where query.SHS == shs select query;
                foreach (var item in listPhui.ToList())
                {

                    string kichthuoc = "";
                    double dai = 0;
                    var dataPhui = from query in db.BG_KICHTHUOCPHUIDAOs where query.SHS == shs && query.MADANHMUC == item.MADANHMUC select query;
                    bool status = true;
                    int k = 1;
                    foreach (var phui in dataPhui.ToList())
                    {
                        dai += phui.DAI.Value;

                        if (phui.SOLUONG > 1 && status == true)
                        {
                            kichthuoc += phui.SOLUONG;
                            status = false;
                        }
                        if (k > 1)
                        {
                            kichthuoc += " + ";
                        }
                        kichthuoc += "(" + Utilities.Strings.DoiDonViMet(phui.DAI.Value) + "x" + Utilities.Strings.DoiDonViMet(phui.RONG.Value) + ")m";

                        k++;
                    }
                    //if (DAL.C_DonKhachHang.findBySHS(shs).SOHO > 1) {
                    //    item.KICHTHUOC = DAL.C_DonKhachHang.findBySHS(shs).SOHO +""+ kichthuoc;
                    //} else {
                        item.KICHTHUOC = kichthuoc;
                    //}

                    
                    item.DAI = String.Format("{0:0.00}", dai);
                    item.SAU = "0.6";
                    if (item.MADANHMUC.Equals("N12B") || item.MADANHMUC.Equals("N12C") || item.MADANHMUC.Equals("N5") || item.MADANHMUC.Equals("NHUA10") || item.MADANHMUC.Equals("NHUA10-C3"))
                    {
                        item.TENKETCAU = "BÊ TÔNG NHỰA";
                        item.RONG = "0.3->0.8";
                    }
                    else  {
                        item.RONG = "0.3->0.6";
                    }
                }
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            
            
        }

        public static DataSet ReportxinPhepDD(string madot, string TUNGAY, string DENNGAY, string NGAYKHOICONGDAO, string NGAYHOANTATTL) {
            try
            {
                DataSet ds = new DataSet();
                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                
                string sql = "SELECT *,TUNGAY='" + TUNGAY + "',DENNGAY='" + DENNGAY + "',NGAYKHOICONGDAO='" + NGAYKHOICONGDAO + "',NGAYHOANTATTL='" + NGAYHOANTATTL + "' FROM V_XINPHEPDAODUONG  WHERE MADOTDD='"+ madot+"'";

                SqlDataAdapter dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                dond.Fill(ds, "V_XINPHEPDAODUONG");

                sql = "SELECT * FROM KH_BC_XINPHEPDD ";
                dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                dond.Fill(ds, "KH_BC_XINPHEPDD");

                return ds;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static bool UpdateCoPhep(string madot, DateTime ngaycophep)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                var obj = from dd in db.KH_XINPHEPDAODUONGs where dd.MADOT == madot select dd;
                if (obj.SingleOrDefault() != null)
                {
                    obj.SingleOrDefault().COPHEP = true;
                    obj.SingleOrDefault().NGAYCOPHEP = ngaycophep;
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            
            return false;
        }
       
        public static KH_BAOCAOPHUIDAO finbyBaoCaoPhuiDaoBySTT(int stt) {
            try
            {
                var obj = from dd in db.KH_BAOCAOPHUIDAOs where dd.STT == stt select dd;
                return obj.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

            return null;
        }
        public static void UpdatePhui()
        {
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
           
             
        }

    }
}
