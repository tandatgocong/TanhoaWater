using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TanHoaWater.DAL
{
    class DateToString
    {
        public static string NgayVN(DateTimePicker d1)
        {
            string kq = "";
            string ngay;
            string thang;
            string nam = d1.Value.Year.ToString();

            if (d1.Value.Day < 10)
            {
                ngay = "0" + d1.Value.Day.ToString();
            }
            else
            {
                ngay = d1.Value.Day.ToString();
            }
            if (d1.Value.Month < 10)
            {
                thang = "0" + d1.Value.Month.ToString();
            }
            else
            {
                thang = d1.Value.Month.ToString();
            }
            kq = kq + ngay + "/" + thang + "/" + nam;
            return kq;
        }
        public static string NgayVN(DateTime d1)
        {
            string kq = "";
            string ngay;
            string thang;
            string nam = d1.Year.ToString();

            if (d1.Day < 10)
            {
                ngay = "0" + d1.Day.ToString();
            }
            else
            {
                ngay = d1.Day.ToString();
            }
            if (d1.Month < 10)
            {
                thang = "0" + d1.Month.ToString();
            }
            else
            {
                thang = d1.Month.ToString();
            }
            kq = kq + ngay + "/" + thang + "/" + nam;
            return kq;
        }
    }
}
