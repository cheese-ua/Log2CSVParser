using System;
using System.Globalization;

namespace Log2CSVParser.Utilities.Extensions
{
    public static class ObjectExtension
    {
        public static float ToFloatOrDefault(this object item, float defaultValue)
        {
            try {
                return ToFloat(item);
            } catch {
                return defaultValue;
            }
        }

        public static float ToFloat(this object item)
        {
            if (string.IsNullOrEmpty(item?.ToString()))
                throw new ApplicationException("Неверный формат числа [" + item + "]");
            NumberFormatInfo nfi = new CultureInfo("ru-RU", false).NumberFormat;
            nfi.NumberDecimalSeparator = ".";
            return float.Parse(item.ToString().Replace(",", ".").Replace(" ", ""), NumberStyles.Number, nfi);
        }

    }
}
