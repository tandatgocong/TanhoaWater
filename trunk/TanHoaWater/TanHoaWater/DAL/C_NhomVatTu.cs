using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
namespace TanHoaWater.DAL
{
    class C_NhomVatTu
    {
        public static List<NHOMVATTU> getList() {
            TanHoaDataContext db = new TanHoaDataContext();
            var list = from nvt in db.NHOMVATTUs select nvt;
           return list.ToList();
        }
    }
}
