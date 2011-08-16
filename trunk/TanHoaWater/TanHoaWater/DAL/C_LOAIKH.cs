using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;

namespace TanHoaWater.DAL
{
    public class C_LOAIKH
    {
        public static List<LOAI_KHACHHANG> getList()
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var loaiKH = from item in data.LOAI_KHACHHANGs select item;
            return loaiKH.ToList();
        }

    }
}
