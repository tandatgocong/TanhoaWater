using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TanHoaWater.Database;

namespace TanHoaWater.DAL
{
    public class C_PHONGBAN
    {
        public static List<PHONGBANDOI> getList()
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var phongab = from pb in data.PHONGBANDOIs select pb;
            return phongab.ToList();
        }
    }
}
