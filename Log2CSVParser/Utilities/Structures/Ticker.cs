﻿using System;

namespace Log2CSVParser.Utilities.Structures
{
    public class Ticker
    {
        private static long counter;
        public long idx = ++counter;

        public DateTime date { get; set; } = DateTime.MinValue;
        public string TickerName { get; set; }
        public TickerEntry BuyEntry { get; set; }
        public TickerEntry SellEntry { get; set; }
        public string PT { get; set; }
        public string STP0 { get; set; }
        public string STP1 { get; set; }
        public string STP2 { get; set; }
        public string STP3 { get; set; }
        public string TRLSTP { get; set; }
        public string BXL { get; set; }
        public string SXL { get; set; }
        public string SIZE { get; set; }
        public string SARBUY { get; set; }
        public string SARSELL { get; set; }

        public bool Valid()
        {
            return !string.IsNullOrEmpty(TickerName)
                   && date.Ticks != DateTime.MinValue.Ticks;
        }

        public string GetValueEntry(string name)
        {
            string entry;
            if ((BuyEntry?.Name ?? Config.EmptyCellValue).Equals(name))
                entry =  BuyEntry?.Val ?? Config.EmptyCellValue;
            else if ((SellEntry?.Name ?? Config.EmptyCellValue).Equals(name))
                entry=SellEntry?.Val ?? Config.EmptyCellValue;
            else
                entry= Config.EmptyCellValue;
            if (entry.Length == 0)
                entry = Config.EmptyCellValue;
            return entry;
        }

    }
}