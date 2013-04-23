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
                if (type == 1)
                {
                    sql = " SELECT hskh.MADOTTC,COUNT(hskh.SHS) as 'TLK', dvtc.TENCONGTY, ROUND(SUM(CPVATTU),0,0) as 'CPVATTU', ROUND(SUM(CPNHANCONG),0,0) as 'CPNHANCONG', ROUND(SUM(CPMAYTHICONG),0,0) as 'CPMAYTHICONG',ROUND(SUM(CHIPHITRUCTIEP),0,0) as 'CHIPHITRUCTIEP' ,ROUND(SUM(CHIPHICHUNG),0,0) as 'CHIPHICHUNG' ,ROUND(SUM(TAILAPMATDUONG),0,0) as 'TAILAPMATDUONG' ,ROUND(SUM(TONGIATRI),0,0) as 'TONGIATRI'  ,TUNGAY='', DENNGAY='', LOAIBANGKE=N'" + loaidon.ToUpper() + "' ";
                    sql += " FROM KH_HOSOKHACHHANG hskh,KH_DOTTHICONG dotc,KH_DONVITHICONG dvtc ";
                    sql += " WHERE dotc.MADOTTC=hskh.MADOTTC AND dotc.DONVITHICONG= dvtc.ID ";
                    sql += " AND LOAIBANGKE=N'" + loaidon + "' ";
                }
                else if (type == 2)
                {
                    sql = " SELECT hskh.MADOTTC,COUNT(hskh.SHS) as 'TLK', dvtc.TENCONGTY, ROUND(SUM(CPVATTU),0,0) as 'CPVATTU', ROUND(SUM(CPNHANCONG),0,0) as 'CPNHANCONG', ROUND(SUM(CPMAYTHICONG),0,0) as 'CPMAYTHICONG',ROUND(SUM(CHIPHITRUCTIEP),0,0) as 'CHIPHITRUCTIEP' ,ROUND(SUM(CHIPHICHUNG),0,0) as 'CHIPHICHUNG' ,ROUND(SUM(TAILAPMATDUONG),0,0) as 'TAILAPMATDUONG' ,ROUND(SUM(TONGIATRI),0,0) as 'TONGIATRI'  ,TUNGAY='" + tungay + "', DENNGAY='" + denngay + "', LOAIBANGKE=N'" + loaidon.ToUpper() + "' ";
                    sql += " FROM KH_HOSOKHACHHANG hskh,KH_DOTTHICONG dotc,KH_DONVITHICONG dvtc ";
                    sql += " WHERE dotc.MADOTTC=hskh.MADOTTC AND dotc.DONVITHICONG= dvtc.ID ";
                    sql += " AND LOAIBANGKE=N'" + loaidon + "' ";
                    sql += " AND CONVERT(DATETIME,dotc.NGAYLAP,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";
                }
                else if (type == 3)
                {
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


        public static DataSet BC_TONGKET(string loaidon, int type, string maphuong, string maquan, string tungay, string denngay)
        {
            try
            {



                string sqltongket = " SELECT COUNT(KH_SHS) as 'HOSO', ";
                sqltongket += " 	COUNT(TTK_SHS) as 'GIAOKT',";
                sqltongket += " 		COUNT(CASE WHEN HOANTATTK =1  AND (TRONGAITHIETKE IS NULL OR TRONGAITHIETKE=0) THEN 1 ELSE NULL END) as 'HOANTATTK',";
                sqltongket += " 		COUNT(CASE WHEN TRONGAITHIETKE =1  THEN 1 ELSE NULL END ) as 'TRONGAITHIETKE',";
                sqltongket += " 		COUNT(KH_SHS) - (COUNT(CASE WHEN HOANTATTK =1  AND (TRONGAITHIETKE IS NULL OR TRONGAITHIETKE=0) THEN 1 ELSE NULL END) + COUNT(CASE WHEN TRONGAITHIETKE =1  THEN 1 ELSE NULL END )) as 'TONTK',  ";
                sqltongket += " 		COUNT(CASE WHEN NGAYDONGTIEN  IS NOT NULL  THEN 1 ELSE NULL END  ) as 'DONGTIEN',  ";
                sqltongket += " 		COUNT(CASE WHEN NGAYDONGTIEN  IS  NULL  AND MADOTTC <> '' THEN 1 ELSE NULL END  ) as 'MIENPHI',";
                sqltongket += " 		COUNT(CASE WHEN MADOTTC <> ''  THEN 1 ELSE NULL END ) as 'CHUYENTC', ";
                sqltongket += " 		COUNT(SHS) - COUNT(CASE WHEN MADOTTC <> ''  THEN 1 ELSE NULL END ) as 'TONTC',  ";
                sqltongket += " 		COUNT(CASE WHEN HOANCONG <> ''  THEN 1 ELSE NULL END ) as 'HOANCONG'  ";
                sqltongket += " FROM ";
                sqltongket += " (SELECT *";
                sqltongket += " FROM (";
                sqltongket += " 	SELECT LOAIHOSO,DON_KHACHHANG.NGAYNHAN as 'NHANHOSO',";
                sqltongket += " 		DON_KHACHHANG.PHUONG,DON_KHACHHANG.QUAN, DON_KHACHHANG.SHS as 'KH_SHS',";
                sqltongket += " 		TOTHIETKE.SHS as'TTK_SHS' ,TOTHIETKE.HOANTATTK,TOTHIETKE.TRONGAITHIETKE,DON_KHACHHANG.NGAYDONGTIEN FROM  DON_KHACHHANG  ";
                sqltongket += " 	LEFT JOIN TOTHIETKE ";
                sqltongket += " 	ON DON_KHACHHANG.SHS = TOTHIETKE.SHS) AS T1";
                sqltongket += " LEFT JOIN KH_HOSOKHACHHANG AS T2";
                sqltongket += " ON T1.TTK_SHS = T2.SHS";
                sqltongket += "  ) as T9";

                string sql = "SELECT * FROM W_KH_BCTONGKET ";

                if ("BT".Equals(loaidon))
                {
                    sql += " WHERE SHS LIKE N'%BT%' AND CONVERT(DATETIME,NGAYNHAN,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";
                    sqltongket += " WHERE KH_SHS LIKE N'%BT%'  AND CONVERT(DATETIME,NHANHOSO,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";
                }
                else    if ("DD".Equals(loaidon))
                    {
                        sql += " WHERE SHS LIKE N'%D%' AND CONVERT(DATETIME,NGAYNHAN,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";
                        sqltongket += " WHERE KH_SHS LIKE N'%D%' AND CONVERT(DATETIME,NHANHOSO,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";
                    }
                    else
                    {
                        sql += " WHERE LOAIHOSO=N'" + loaidon + "' AND CONVERT(DATETIME,NGAYNHAN,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";
                        sqltongket += " WHERE LOAIHOSO=N'" + loaidon + "' AND CONVERT(DATETIME,NHANHOSO,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";
                    }


                if (type == 2)
                {
                    sql += " AND  QUAN='" + maquan + "' AND PHUONG='" + maphuong + "' ";
                    sqltongket += " AND  QUAN='" + maquan + "' AND PHUONG='" + maphuong + "' ";
                }
                else
                {
                    sql += " AND  QUAN='" + maquan + "'";
                    sqltongket += " AND  QUAN='" + maquan + "'";
                }
                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                DataTable table = new DataTable("W_KH_BCTONGKET");
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        string shs = table.Rows[i]["SHS"].ToString();
                        TOTHIETKE ttk = DAL.C_ToThietKe.findBySHS(shs);
                        if (ttk != null && ttk.NGAYHOANTATTK != null)
                        {
                            table.Rows[i]["HOANTATTK"] = Utilities.DateToString.NgayVN(ttk.NGAYHOANTATTK.Value);
                        }
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

                DataSet dataset = new DataSet();
                sql = " SELECT * FROM KH_TC_BAOCAO ";
                adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(dataset, "KH_TC_BAOCAO");

                adapter = new SqlDataAdapter(sqltongket.Replace(@"\t",""), db.Connection.ConnectionString);
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

