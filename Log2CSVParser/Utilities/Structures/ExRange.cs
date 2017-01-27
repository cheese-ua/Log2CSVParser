using System.Collections.Generic;
using Log2CSVParser.Utilities.Log;

namespace Log2CSVParser.Utilities.Structures
{
    public class ExRange
    {
        public List<string> source { get; set; }
        public List<string> dest { get; set; }

        public ExRange(List<string> source, List<string> dest)
        {
            this.source= source;
            this.dest=dest;
        }
    }
}
