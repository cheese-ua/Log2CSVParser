using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log2CSVParser.Utilities.Extensions
{
    public static class ListExtension
    {
        public static string ToStringWithDelimeter<T>(this List<T> list, string delimeter)
        {
            return list.ToStringWithDelimeter(delimeter, "");
        }
        public static string ToStringWithDelimeter<T>(this List<T> list, string delimeter, string emptyValue)
        {
            if (list == null || list.Count == 0)
                return emptyValue;
            StringBuilder str = new StringBuilder();
            foreach (T item in list) {
                if (str.Length > 0)
                    str.Append(delimeter);
                str.Append(item);
            }
            return str.ToString();
        }
    }
}
