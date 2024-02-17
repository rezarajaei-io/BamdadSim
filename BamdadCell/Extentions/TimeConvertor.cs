using System;
using System.Globalization;

namespace BamdadCell.Extentions
{
    public class TimeConvertor
    {
        public static string ToShamsi()
        {
            var now = DateTime.Now; // تاریخ و زمان فعلی
            var pc = new PersianCalendar();
            var result = pc.GetYear(now) + "/" + pc.GetMonth(now).ToString("00") + "/" +
                         pc.GetDayOfMonth(now).ToString("00") + " " +
                         pc.GetHour(now).ToString("00") + ":" + pc.GetMinute(now).ToString("00") + ":" +
                         pc.GetSecond(now).ToString("00");
            return result;
        }
    }
}