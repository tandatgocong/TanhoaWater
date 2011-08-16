using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;

namespace TanHoaWater.DAL
{
    public class C_QUAN
    {
        public static List<QUAN> getList(){
            TanHoaDataContext data = new TanHoaDataContext();
            var quan = from p in data.QUANs select p;
           return quan.ToList();
        }
          
    }
}
