using System;
using System.Text;

namespace Log2CSVParser.Utilities.Extensions
{
    public static class ExceptionException
    {
        public static string ToStringSimple(this Exception ex)
        {
            return GetExceptionInfo(ex, "", "");
        }

        private static string GetExceptionInfo(Exception ex, string prefix, string prev_value)
        {
            if (ex == null)
                return prev_value;
            StringBuilder str = new StringBuilder();
            str.Append(Environment.NewLine).Append("".PadLeft(20, '-'));
            str.AppendFormat(prefix + "Source: {0} ({1})", ex.Source, ex.GetType().Name).Append(Environment.NewLine);
            str.AppendFormat(prefix + "Message: {0}", ex.Message).Append(Environment.NewLine);
            str.AppendFormat(prefix + "TargetSite: {0}", ex.TargetSite).Append(Environment.NewLine);
            str.AppendFormat(prefix + "StackTrace: {0}", (ex.StackTrace ?? "").Replace("\n", "\n" + prefix)).Append(Environment.NewLine);
            return GetExceptionInfo(ex.InnerException, prefix + "---", prev_value + str);
        }
    }
}
