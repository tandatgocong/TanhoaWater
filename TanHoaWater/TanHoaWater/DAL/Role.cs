using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using System.Collections;
using TanHoaWater.Class;

namespace TanHoaWater.DAL
{
    class Role    
    {
        
        public static List<ROLE> getList()
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var roles = from p in data.ROLEs select p;
            return roles.ToList();
        }
        public static ArrayList comboxSearch()
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from role in db.ROLEs select role;
            ArrayList list = new ArrayList();
            list.Add(new AddValueCombox("  Chọn Quyền  ", ""));
            foreach (var a in data)
            {
                list.Add(new AddValueCombox(a.ROLENAME, a.ROLEID.ToString()));
            }
            return list;
        }


    }
}
