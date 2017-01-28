namespace Log2CSVParser.Utilities
{
    public static class Config
    {
        public static string EmptyCellValue { get; set; }
        public static bool ReplaceZero { get; set; }

        static Config()
        {
            EmptyCellValue = "";
            ReplaceZero = false;
        }
    }
}
