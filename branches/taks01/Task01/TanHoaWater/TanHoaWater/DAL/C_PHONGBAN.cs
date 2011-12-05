using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TanHoaWater.Database;

namespace TanHoaWater.DAL
{
    public class C_PhongBan
    {
        public static List<PHONGBANDOI> getList()
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var phongab = from pb in data.PHONGBANDOIs orderby pb.TENPHONG descending select pb ;
            return phongab.ToList();
        }
        public static PHONGBANDOI findbyMaPhong(string maphong) {
            TanHoaDataContext data = new TanHoaDataContext();
            var phongab = from pb in data.PHONGBANDOIs where pb.MAPHONG==maphong select pb;
            return phongab.SingleOrDefault();
        }
        public static PHONGBANDOI findbyTenPhong(string tenphong)
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var phongab = from pb in data.PHONGBANDOIs where pb.TENPHONG == tenphong select pb;
            return phongab.SingleOrDefault();
        }
    }
}
