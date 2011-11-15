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
    class C_DHN_ChoDanhBo
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_DHN_ChoDanhBo).Name);
        static TanHoaDataContext db = new TanHoaDataContext();    
        public static DataTable getListHoanCong(string dottc, int flag)
        {
            //hosokh.COTLK,donkh.SOHOADON,donkh.NGAYDONGTIEN, CONVERT(varchar(50), hosokh.NGAYTHICONG,103) as 'NGAYTHICONG', hosokh.CHISO, hosokh.SOTHANTLK,hosokh.HOANCONG, hosokh.CPVATTU, hosokh.CPNHANCONG, hosokh.CPMAYTHICONG,hosokh.TAILAPMATDUONG
            string sql = "SELECT  donkh.SHS,REPLACE(HOTEN,N'(ĐD '+CONVERT(VARCHAR(10),SOHO)+N' Hộ)',' ') AS 'HOTEN',(SONHA +' '+ DUONG+', P.'+TENPHUONG +', Q.'+TENQUAN) AS 'DIACHI',hosokh.COTLK,CONVERT(varchar(50), hosokh.NGAYTHICONG,103) as 'NGAYTHICONG', hosokh.CHISO, hosokh.SOTHANTLK,hosokh.HOANCONG,hosokh.DHN_SOHOPDONG,hosokh.DHN_GIABIEU,hosokh.DHN_DMGOC,hosokh.DHN_DMCAPBU,hosokh.DHN_SODANHBO,hosokh.DHN_MADMA,hosokh.DHN_HIEULUC,hosokh.DHN_MAQUANPHUONG,hosokh.DHN_HSCONGTY,hosokh.DHN_MASOTHUE,hosokh.DHN_SOHO,hosokh.DHN_SONHANKHAU";
            sql += " FROM DON_KHACHHANG donkh, PHUONG p, QUAN q, KH_HOSOKHACHHANG hosokh ";
            sql += " WHERE donkh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND donkh.PHUONG=p.MAPHUONG  ";
            sql += "  AND donkh.SHS = hosokh.SHS AND hosokh.CHUYENHOANCONG='True' AND hosokh.MADOTTC='" + dottc + "'";

            // flag = -1: chua hoan cong
            // flag = 1: da hoan cong
            // flag = 0: ta ca

            if (flag == -1)
                sql += " AND (hosokh.HOANCONG IS NULL OR hosokh.HOANCONG='False') ";
            else if (flag == 1)
                sql += " AND hosokh.HOANCONG='True'";

            db.Connection.Open();
            sql += " ORDER BY hosokh.MODIFYDATE";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }
    }
}
