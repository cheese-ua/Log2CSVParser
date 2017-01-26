namespace Log2CSVParser.Utilities.Structures
{
    public class TickerEntry
    {
        public string Name { get; set; }
        public string Val { get; set; }
        public override string ToString()
        {
            return $"{Name}: {Val}";
        }
    }
}
