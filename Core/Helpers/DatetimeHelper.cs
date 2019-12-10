using System;

namespace Core.Helpers
{
    public class DatetimeHelper
    {
        public static bool IsFromCurrentYear(DateTime toCampere)
        {
            return toCampere.Year == DateTime.Now.Year;
        }
    }
}