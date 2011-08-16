using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using System.Collections;
using TanHoaWater.Class;

namespace TanHoaWater.DAL
{
    public class C_LOAIHOSO
    {
        public static List<LOAI_HOSO> getList() {
            TanHoaDataContext data = new TanHoaDataContext();
            var loaihs = from lhs in data.LOAI_HOSOs select lhs;
            return loaihs.ToList();
        }
        public static ArrayList getListCombobox() {
            ArrayList list = new ArrayList();
            TanHoaDataContext data = new TanHoaDataContext();
            var loaihs = from lhs in data.LOAI_HOSOs select lhs;
            list.Add(new AddValueCombox("---------- Chọn Loại Hồ Sơ -----------", ""));
            foreach (var a in loaihs)
            {
                list.Add(new AddValueCombox(a.TENLOAI, a.MALOAI));
            }
            return list;
        }
    }
}
