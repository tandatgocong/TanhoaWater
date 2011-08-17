using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
namespace TanHoaWater.DAL
{
    public class C_PHUONG
    {
        public static List<PHUONG> getListByQuan(int maquan) {
            TanHoaDataContext data = new TanHoaDataContext();
            var lisPhuong = from phuong in data.PHUONGs where phuong.MAQUAN == maquan select phuong;
            return lisPhuong.ToList();
        }

    }
}
