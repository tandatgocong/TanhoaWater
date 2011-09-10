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
        public static string fullCurrentNgay()
        {
            string dateofweek="";
            if (DateTime.Now.DayOfWeek.ToString().Trim().Contains("Mon") == true)
            {
                dateofweek = "Thứ 2,";
            }
            if (DateTime.Now.DayOfWeek.ToString().Trim().Contains("Tue") == true)
            {
                dateofweek = "Thứ 3,";
            }
            if (DateTime.Now.DayOfWeek.ToString().Trim().Contains("Wed") == true) 
            {
                dateofweek = "Thứ 4,";
            }
            if (DateTime.Now.DayOfWeek.ToString().Trim().Contains("Thu") == true)
            {
                dateofweek = "Thứ 5,";
            }
            if ("‎Friday".Equals(DateTime.Now.DayOfWeek.ToString()))
            {
                dateofweek = "Thứ 6,";
            }
            if (DateTime.Now.DayOfWeek.ToString().Trim().Contains("Satu") == true)
            {
                dateofweek = "Thứ 7,";
            }
            if (DateTime.Now.DayOfWeek.ToString().Trim().Contains("Sun") == true)
            {
                dateofweek = "Chủ nhật,";
            }
            string kq = "";
            string ngay;
            string thang;
            string nam = DateTime.Now.Year.ToString();

            if (DateTime.Now.Day < 10)
            {
                ngay = "0" + DateTime.Now.Day.ToString();
            }
            else
            {
                ngay = DateTime.Now.Day.ToString();
            }
            if (DateTime.Now.Month < 10)
            {
                thang = "0" + DateTime.Now.Month.ToString();
            }
            else
            {
                thang = DateTime.Now.Month.ToString();
            }
            kq = dateofweek + " Ngày " +  ngay + " tháng " + thang + " năm " + nam;
            return kq;
        }
    }
}