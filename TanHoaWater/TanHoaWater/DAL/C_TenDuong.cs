using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;

namespace TanHoaWater.DAL
{
    class C_TenDuong
    {
        public  static List<TENDUONG> getList(){
        
            TanHoaDataContext db = new TanHoaDataContext();
            var query = from duong in db.TENDUONGs select duong;
            return query.ToList();            
        }
    }
}
