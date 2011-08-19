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
        public static QUAN finByMaQuan(int maquan) { 
             TanHoaDataContext data = new TanHoaDataContext();
             var quan = from q in data.QUANs where q.MAQUAN == maquan select q;
             return quan.SingleOrDefault();
        }
        public static QUAN finbyTenQuan(string tenquan) {
            TanHoaDataContext data = new TanHoaDataContext();
            var quan = from q in data.QUANs where q.TENQUAN == tenquan select q;
            return quan.SingleOrDefault();
        }
    }
}
