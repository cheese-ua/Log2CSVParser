using System.Collections;
using System.Linq;

namespace Log2CSVParser.Utilities.Extensions
{
    public static class HashtableExtension
    {
        public static Hashtable ToHashtable(this string inStr, char separatorLine, char separatorKeyVal)
        {
            Hashtable hash = new Hashtable();
            string[] lines = inStr.Split(separatorLine);
            foreach (string[] param in lines
                .Select(line => line.Split(separatorKeyVal))
                .Where(param => param.Length == 2)) {
                hash[param[0].Trim()] = param[1].Trim();
            }
            return hash;
        }
    }
}
