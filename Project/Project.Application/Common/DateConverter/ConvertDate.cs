using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Common.DateConverter
{
    public class ConvertDate
    {
        public static DateTime ConvertPersianToGregorian(DateTime persianDate)
        {
            PersianCalendar persianCalendar = new();

            int persianYear = persianCalendar.GetYear(persianDate);
            int persianMonth = persianCalendar.GetMonth(persianDate);
            int persianDay = persianCalendar.GetDayOfMonth(persianDate);

            DateTime resultDate = persianCalendar.ToDateTime(persianYear, persianMonth, persianDay, 0, 0, 0, 0);

            return resultDate;
        }

        public static DateTime ConvertGregorianToPersian(DateTime gregorianDate)
        {
            PersianCalendar persianCalendar = new();

            int Year = persianCalendar.GetYear(gregorianDate);
            int Month = persianCalendar.GetMonth(gregorianDate);
            int Day = persianCalendar.GetDayOfMonth(gregorianDate);

            DateTime resultDate = persianCalendar.ToDateTime(Year, Month, Day, 0, 0, 0, 0);

            return resultDate;
        }
    }
}
