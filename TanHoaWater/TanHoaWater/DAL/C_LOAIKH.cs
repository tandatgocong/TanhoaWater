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
        public static LOAI_KHACHHANG finbyMaLoai(string loaiKH) {
            TanHoaDataContext data = new TanHoaDataContext();
            var loai_KH = from kh in data.LOAI_KHACHHANGs where kh.MALOAI == loaiKH  select kh;
            return loai_KH.SingleOrDefault();
        }
        public static LOAI_KHACHHANG finbyTenLoai(string tenLoai)
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var loai_KH = from kh in data.LOAI_KHACHHANGs where kh.TENLOAI == tenLoai select kh;
            return loai_KH.SingleOrDefault();
        }

    }
}
