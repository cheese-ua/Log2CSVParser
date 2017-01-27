using System;
using System.Globalization;

namespace Log2CSVParser.Utilities.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime ToDateTimeUniversal(this string dateString)
        {
                DateTimeFormatInfo culture = new DateTimeFormatInfo {
                    FullDateTimePattern = "u",
                    LongDatePattern = "u",
                    ShortDatePattern = "u"
                };
                return DateTime.Parse(dateString, culture);
        }
    }
}
