namespace Log2CSVParser.Utilities
{
    public static class Config
    {
        public static string EmptyCellValue { get; set; }

        static Config()
        {
            EmptyCellValue = "";
        }
    }
}
