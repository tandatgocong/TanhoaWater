using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TanHoaWater.Database;
using System.Data.SqlClient;
using log4net;

namespace TanHoaWater.DAL
{
    class C_KH_BAOCAO
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_KH_BAOCAO).Name);
        public static DataSet BC_KINHPHITHICONG(string loaidon, int type, string tungay, string denngay, string dvtc, string tctungay, string tcdenngay)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                DataSet dataset = new DataSet();
                string sql = " SELECT * FROM KH_TC_BAOCAO ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(dataset, "KH_TC_BAOCAO");
                //type==0 Tat Ca
                //type==1 Theo ngay
                //type==2 Theo dvtc
                if (type == 1) {
                    sql = " SELECT hskh.MADOTTC,COUNT(hskh.SHS) as 'TLK', dvtc.TENCONGTY, ROUND(SUM(CPVATTU),0,0) as 'CPVATTU', ROUND(SUM(CPNHANCONG),0,0) as 'CPNHANCONG', ROUND(SUM(CPMAYTHICONG),0,0) as 'CPMAYTHICONG',ROUND(SUM(CHIPHITRUCTIEP),0,0) as 'CHIPHITRUCTIEP' ,ROUND(SUM(CHIPHICHUNG),0,0) as 'CHIPHICHUNG' ,ROUND(SUM(TAILAPMATDUONG),0,0) as 'TAILAPMATDUONG' ,ROUND(SUM(TONGIATRI),0,0) as 'TONGIATRI'  ,TUNGAY='', DENNGAY='', LOAIBANGKE=N'" + loaidon.ToUpper() + "' ";
                    sql += " FROM KH_HOSOKHACHHANG hskh,KH_DOTTHICONG dotc,KH_DONVITHICONG dvtc ";
                    sql += " WHERE dotc.MADOTTC=hskh.MADOTTC AND dotc.DONVITHICONG= dvtc.ID ";
                    sql += " AND LOAIBANGKE=N'" + loaidon + "' ";
                } else if (type == 2) {
                    sql = " SELECT hskh.MADOTTC,COUNT(hskh.SHS) as 'TLK', dvtc.TENCONGTY, ROUND(SUM(CPVATTU),0,0) as 'CPVATTU', ROUND(SUM(CPNHANCONG),0,0) as 'CPNHANCONG', ROUND(SUM(CPMAYTHICONG),0,0) as 'CPMAYTHICONG',ROUND(SUM(CHIPHITRUCTIEP),0,0) as 'CHIPHITRUCTIEP' ,ROUND(SUM(CHIPHICHUNG),0,0) as 'CHIPHICHUNG' ,ROUND(SUM(TAILAPMATDUONG),0,0) as 'TAILAPMATDUONG' ,ROUND(SUM(TONGIATRI),0,0) as 'TONGIATRI'  ,TUNGAY='" + tungay + "', DENNGAY='" + denngay + "', LOAIBANGKE=N'" + loaidon.ToUpper() + "' ";
                    sql += " FROM KH_HOSOKHACHHANG hskh,KH_DOTTHICONG dotc,KH_DONVITHICONG dvtc ";
                    sql += " WHERE dotc.MADOTTC=hskh.MADOTTC AND dotc.DONVITHICONG= dvtc.ID ";
                    sql += " AND LOAIBANGKE=N'" + loaidon + "' ";
                    sql += " AND CONVERT(DATETIME,dotc.NGAYLAP,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";
                } else if (type == 3) {
                    sql = " SELECT hskh.MADOTTC,COUNT(hskh.SHS) as 'TLK', dvtc.TENCONGTY, ROUND(SUM(CPVATTU),0,0) as 'CPVATTU', ROUND(SUM(CPNHANCONG),0,0) as 'CPNHANCONG', ROUND(SUM(CPMAYTHICONG),0,0) as 'CPMAYTHICONG',ROUND(SUM(CHIPHITRUCTIEP),0,0) as 'CHIPHITRUCTIEP' ,ROUND(SUM(CHIPHICHUNG),0,0) as 'CHIPHICHUNG' ,ROUND(SUM(TAILAPMATDUONG),0,0) as 'TAILAPMATDUONG' ,ROUND(SUM(TONGIATRI),0,0) as 'TONGIATRI'  ,TUNGAY='" + tctungay + "', DENNGAY='" + tcdenngay + "', LOAIBANGKE=N'" + loaidon.ToUpper() + "' ";
                    sql += " FROM KH_HOSOKHACHHANG hskh,KH_DOTTHICONG dotc,KH_DONVITHICONG dvtc ";
                    sql += " WHERE dotc.MADOTTC=hskh.MADOTTC AND dotc.DONVITHICONG= dvtc.ID ";
                    sql += " AND LOAIBANGKE=N'" + loaidon + "' ";
                    sql += "AND DONVITHICONG='" + dvtc + "' AND CONVERT(DATETIME,dotc.NGAYLAP,103) BETWEEN CONVERT(DATETIME,'" + tctungay + "',103) AND CONVERT(DATETIME,'" + tcdenngay + "',103) ";
                }
                sql += " GROUP BY hskh.MADOTTC,dvtc.TENCONGTY";
                adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(dataset, "W_KH_BCKINHPHI");
                db.Connection.Close();
                return dataset;
            }
            catch (Exception ex)
            {
                log.Error("Loi BC Danh Sach Thi Cong " + ex.Message);
            }
            return null;
        }


        public static DataSet BC_TONGKET(string loaidon, int type, string maphuong, string maquan, string tungay,string denngay)
        {
            try
            {
                string sqltongket = "SELECT COUNT(KHVT.KH_SHS) as 'HOSO', COUNT(KHVT.TTK_SHS) as 'GIAOKT',  COUNT(KHVT.HOANTATTK) as 'HOANTATTK',  COUNT(KHVT.TRONGAITHIETKE) as 'TRONGAITHIETKE', ";
		        sqltongket +=" COUNT(KHVT.TTK_SHS) - (COUNT(KHVT.HOANTATTK)+COUNT(KHVT.TRONGAITHIETKE)) as 'TONTK',  COUNT(KHVT.NGAYDONGTIEN) as 'DONGTIEN', ";
		        sqltongket +=" COUNT(KHVT.HOANTATTK) - COUNT(KHVT.NGAYDONGTIEN) as 'MIENPHI', COUNT(KH_HOSOKHACHHANG.MADOTTC) as 'CHUYENTC',";
		        sqltongket +=" COUNT(KH_HOSOKHACHHANG.SHS)-COUNT(KH_HOSOKHACHHANG.MADOTTC) as 'TONTC',  COUNT(KH_HOSOKHACHHANG.HOANCONG) as 'HOANCONG' ";
                sqltongket +=" FROM (SELECT DON_KHACHHANG.LOAIHOSO,DON_KHACHHANG.NGAYNHAN,DON_KHACHHANG.PHUONG,DON_KHACHHANG.QUAN, DON_KHACHHANG.SHS as 'KH_SHS',TOTHIETKE.SHS as'TTK_SHS' ,TOTHIETKE.HOANTATTK,TOTHIETKE.TRONGAITHIETKE,DON_KHACHHANG.NGAYDONGTIEN ";
		        sqltongket +=" FROM  DON_KHACHHANG ";
                sqltongket +=" LEFT JOIN TOTHIETKE";
		        sqltongket +=" ON DON_KHACHHANG.SHS = TOTHIETKE.SHS ) as KHVT ";
                sqltongket +=" LEFT JOIN KH_HOSOKHACHHANG";
                sqltongket +=" ON KHVT.KH_SHS=KH_HOSOKHACHHANG.SHS";
                sqltongket += " WHERE KHVT.LOAIHOSO=N'" + loaidon + "' AND CONVERT(DATETIME,KHVT.NGAYNHAN,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";

                string sql = "SELECT * FROM W_KH_BCTONGKET ";
                sql += " WHERE LOAIHOSO=N'" + loaidon + "' AND CONVERT(DATETIME,NGAYNHAN,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";

                if (type == 2)
                {
                    sql += " AND  QUAN='" + maquan + "' AND PHUONG='" + maphuong + "' ";
                    sqltongket += " AND  KHVT.QUAN='" + maquan + "' AND KHVT.PHUONG='" + maphuong + "' ";
                }
                else {
                    sql += " AND  QUAN='" + maquan + "'";
                    sqltongket += " AND  KHVT.QUAN='" + maquan + "'";
                }
                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                DataTable table = new DataTable("W_KH_BCTONGKET");
                adapter.Fill(table);
                if (table.Rows.Count > 0) {
                    for (int i = 0; i < table.Rows.Count; i++) {
                        string shs = table.Rows[i]["SHS"].ToString();
                        TOTHIETKE ttk = DAL.C_ToThietKe.findBySHS(shs);
                        if (ttk != null && ttk.NGAYHOANTATTK!=null)
                        {
                            table.Rows[i]["HOANTATTK"] = Utilities.DateToString.NgayVN(ttk.NGAYHOANTATTK.Value);
                            if (!"".Equals(table.Rows[i]["DONVITHICONG"] + ""))
                            {
                                KH_DONVITHICONG bctc = DAL.C_KH_DonViTC.findDVTCbyID(int.Parse(table.Rows[i]["DONVITHICONG"] + ""));
                                if (bctc != null)
                                {
                                    table.Rows[i]["DONVITC"] = bctc.TENCONGTY.Replace("C.Ty", "").Replace("TNHH", "").Replace("Cổ Phần", ""); 
                                }
                            }
                        }
                    }
                }

                DataSet dataset = new DataSet();
                sql = " SELECT * FROM KH_TC_BAOCAO ";
                adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(dataset, "KH_TC_BAOCAO");

                adapter = new SqlDataAdapter(sqltongket, db.Connection.ConnectionString);
                adapter.Fill(dataset, "W_KH_BCTONGCONG");

                dataset.Tables.Add(table);

                db.Connection.Close();

                return dataset;

            }
            catch (Exception ex)
            {
                log.Error("Loi BC Danh Sach Thi Cong " + ex.Message);
            }
            return null;
        }

    }
}
