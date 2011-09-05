using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using System.Collections;
using TanHoaWater.Class;
namespace TanHoaWater.DAL
{
    class C_NhomVatTu
    {
        public static List<NHOMVATTU> getList() {
            TanHoaDataContext db = new TanHoaDataContext();
            var list = from nvt in db.NHOMVATTUs select nvt;
           return list.ToList();
        }
        public static ArrayList getNhomVT()
        {
            ArrayList list = new ArrayList();
            TanHoaDataContext db = new TanHoaDataContext();
            var dvt = from dm in db.NHOMVATTUs select dm;
            list.Add(new AddValueCombox("", ""));
            foreach (var a in dvt)
            {
                list.Add(new AddValueCombox(a.TENNHOMVT, a.TENNHOMVT));
            }
            return list;
        }
    }
}
