using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Log2CSVParser.Utilities;
using Log2CSVParser.Utilities.Extensions;
using Log2CSVParser.Utilities.Log;
using Log2CSVParser.Utilities.Structures;
using SpreadsheetLight;

namespace Log2CSVParser
{
    public class Parser
    {
        private const string orderParamIdent = "Order Parameters: ";
        private const string tickerIdent = "Ticker ";

        private readonly string fileSource;
        private readonly string fileResult;
        private readonly bool needSorting;
        private readonly ILogManager log;
        private bool hasErrors;
        private Ticker ticker = new Ticker();
        private List<Ticker> tickerList;
        private readonly List<string> validTickersName;
        private readonly bool onlyBuySell;
        public int percent { get; private set; }
        public int blankRows;


        public Parser(string fileSource, string fileResult, bool needSorting, bool onlyBuySell, List<string> validTickersName, int blankRows, ILogManager log)
        {
            this.fileSource = Path.GetFullPath(fileSource);
            this.fileResult = Path.GetFullPath(fileResult);
            this.validTickersName = validTickersName ?? new List<string>();
            this.validTickersName.RemoveAll(string.IsNullOrEmpty);
            this.needSorting = needSorting;
            this.onlyBuySell = onlyBuySell;
            this.blankRows = blankRows;
            this.log = log;
        }

        public SimpleProcessResponse Start()
        {
            try{
                if (!File.Exists(fileSource))
                    return SimpleProcessResponse.Fail("File " + fileSource + " not exist");

                if (string.IsNullOrEmpty(fileResult))
                    return SimpleProcessResponse.Fail("File " + fileResult + " is empty");

                tickerList = new List<Ticker>();
                percent = 0;

                if(File.Exists(fileResult))
                    File.Delete(fileResult);

                using (StreamReader sr = new StreamReader(fileSource))
                using (SLDocument excell = new SLDocument())
                {

                    long allSize = sr.BaseStream.Length;
                    long current = 0;
                    string readLine;
                    while (null != (readLine = sr.ReadLine())) {
                        current += readLine.Length;
                        percent = allSize == 0 ? 0 : (int)(current * 100 / (decimal)allSize);
                        ProcessLine(readLine);
                        Application.DoEvents();
                    }
                    SaveCurrentTicker();

                    if (validTickersName.Any())
                        tickerList.RemoveAll(t => validTickersName.FirstOrDefault(vt => vt.Equals(t.TickerName)) == null);
                    List<Ticker> sortedResult = needSorting
                        ? (from t in tickerList
                           orderby t.TickerName, t.idx
                           select t).ToList()
                        : tickerList;
                    if (onlyBuySell) {
                        FileFormat_BuySellColumns_Excell(sortedResult, excell, needSorting ? blankRows : 0);
                    } else {
                        FileFormat_AllColumns_Excell(sortedResult, excell, needSorting ? blankRows : 0);
                    }
                    excell.SaveAs(fileResult);
                }


                return hasErrors ? SimpleProcessResponse.Fail("See application log file for details.") : SimpleProcessResponse.Success("OK");
            } catch (Exception ex){
                log.Error(ex);
                return SimpleProcessResponse.Fail("System error. " + ex.Message);
            }
        }

        private void FileFormat_AllColumns_Excell(List<Ticker> sortedResult, SLDocument excell, int rows)
        {
            Hashtable entriesName = CreateAllEntries(sortedResult);
            List<string> keys = entriesName.Keys.Cast<string>().OrderBy(k => k).ToList();
            int columnsCount = keys.Count + 13;

            List<string> columns = ExcellExtension.CreateEnumeratorColumns(columnsCount, log);
            excell.SetCellValue(columns[0] + "1", "Date");
            excell.SetCellValue(columns[1] + "1", "Ticker");
            int pos = 2;
            keys.ForEach(k => { excell.SetCellValue(columns[pos++] + "1", k); });
            excell.SetCellValue(columns[keys.Count+2] + "1", "PT");
            excell.SetCellValue(columns[keys.Count + 3] + "1", "STP0");
            excell.SetCellValue(columns[keys.Count + 4] + "1", "STP1");
            excell.SetCellValue(columns[keys.Count + 5] + "1", "STP2");
            excell.SetCellValue(columns[keys.Count + 6] + "1", "STP3");
            excell.SetCellValue(columns[keys.Count + 7] + "1", "TRLSTP");
            excell.SetCellValue(columns[keys.Count + 8] + "1", "BXL");
            excell.SetCellValue(columns[keys.Count + 9] + "1", "SXL");
            excell.SetCellValue(columns[keys.Count + 10] + "1", "SIZE");
            excell.SetCellValue(columns[keys.Count + 11] + "1", "SARBUY");
            excell.SetCellValue(columns[keys.Count + 12] + "1", "SARSELL");

            string prevTickerName = "";
            int currentRow = 2;
            foreach (Ticker oneTicker in sortedResult) {
                if (rows > 0 && prevTickerName.Length > 0 && !prevTickerName.Equals(oneTicker.TickerName)){
                    PrintEmptyLines_Excell(excell, rows, columns, currentRow);
                    currentRow += rows;
                }

                excell.SetCellValue(columns[0] + currentRow, oneTicker.date.ToString("yyyy-MM-dd HH:mm:ss"));
                excell.SetCellValue(columns[1] + currentRow, oneTicker.TickerName);
                log.Info(columns[1] + currentRow+" => "+ oneTicker.TickerName);
                pos = 2;
                keys.ForEach(k => { excell.SetCellValue_Custom(columns[pos++] + currentRow, oneTicker.GetValueEntry(k)); });
                excell.SetCellValue_Custom(columns[keys.Count + 2] + currentRow, oneTicker.PT ?? Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[keys.Count + 3] + currentRow, oneTicker.STP0 ?? Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[keys.Count + 4] + currentRow, oneTicker.STP1 ?? Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[keys.Count + 5] + currentRow, oneTicker.STP2 ?? Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[keys.Count + 6] + currentRow, oneTicker.STP3 ?? Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[keys.Count + 7] + currentRow, oneTicker.TRLSTP ?? Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[keys.Count + 8] + currentRow, oneTicker.BXL ?? Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[keys.Count + 9] + currentRow, oneTicker.SXL ?? Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[keys.Count + 10] + currentRow, oneTicker.SIZE ?? Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[keys.Count + 11] + currentRow, oneTicker.SARBUY ?? Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[keys.Count + 12] + currentRow, oneTicker.SARSELL ?? Ticker.emptyCell);

                prevTickerName = oneTicker.TickerName;
                currentRow++;
            }
        }

        private void PrintEmptyLines_Excell(SLDocument excell, int rowCount, List<string> columns, int startRow)
        {
            for (int i = 0;i < rowCount;i++){
                foreach (string column in columns){
                    excell.SetCellValue(column + (startRow+i), "");
                }
                log.Info("ROW" + (startRow + i) + " => clear");
            }
        }

        private void FileFormat_BuySellColumns_Excell(List<Ticker> sortedResult, SLDocument excell, int rows)
        {
            List<string> columns = ExcellExtension.CreateEnumeratorColumns(15, log);
            excell.SetCellValue(columns[0] + "1", "Date");
            excell.SetCellValue(columns[1] + "1", "Ticker");
            excell.SetCellValue(columns[2] + "1", "Buy Entry");
            excell.SetCellValue(columns[3] + "1", "Sell Entry");
            excell.SetCellValue(columns[4] + "1", "PT");
            excell.SetCellValue(columns[5] + "1", "STP0");
            excell.SetCellValue(columns[6] + "1", "STP1");
            excell.SetCellValue(columns[7] + "1", "STP2");
            excell.SetCellValue(columns[8] + "1", "STP3");
            excell.SetCellValue(columns[9] + "1", "TRLSTP");
            excell.SetCellValue(columns[10] + "1", "BXL");
            excell.SetCellValue(columns[11] + "1", "SXL");
            excell.SetCellValue(columns[12] + "1", "SIZE");
            excell.SetCellValue(columns[13] + "1", "SARBUY");
            excell.SetCellValue(columns[14] + "1", "SARSELL");

            string prevTickerName = "";
            int currentRow = 2;
            foreach (Ticker oneTicker in sortedResult) {
                if (rows > 0 && prevTickerName.Length > 0 && !prevTickerName.Equals(oneTicker.TickerName)) {
                    PrintEmptyLines_Excell(excell, rows, columns, currentRow);
                    currentRow += rows;
                }

                excell.SetCellValue(columns[0] + currentRow, oneTicker.date.ToString("yyyy-MM-dd HH:mm:ss"));
                excell.SetCellValue(columns[1] + currentRow, oneTicker.TickerName);
                excell.SetCellValue_Custom(columns[2] + currentRow, oneTicker.BuyEntry?.Val ??  Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[3] + currentRow, oneTicker.SellEntry?.Val ?? Ticker.emptyCell);

                excell.SetCellValue_Custom(columns[4] + currentRow, oneTicker.PT ?? Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[5] + currentRow, oneTicker.STP0 ?? Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[6] + currentRow, oneTicker.STP1 ?? Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[7] + currentRow, oneTicker.STP2 ?? Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[8] + currentRow, oneTicker.STP3 ?? Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[9] + currentRow, oneTicker.TRLSTP ?? Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[10] + currentRow, oneTicker.BXL ?? Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[11] + currentRow, oneTicker.SXL ?? Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[12] + currentRow, oneTicker.SIZE ?? Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[13] + currentRow, oneTicker.SARBUY ?? Ticker.emptyCell);
                excell.SetCellValue_Custom(columns[14] + currentRow, oneTicker.SARSELL ?? Ticker.emptyCell);

                prevTickerName = oneTicker.TickerName;
                currentRow++;
            }

        }

        private static Hashtable CreateAllEntries(List<Ticker> sortedResult)
        {
            Hashtable ttt = new Hashtable();
            sortedResult.ForEach(r =>{
                                     if (!string.IsNullOrEmpty(r.SellEntry?.Name)){
                                         ttt[r.SellEntry?.Name] = 1;
                                     }
                                     if (!string.IsNullOrEmpty(r.BuyEntry?.Name)){
                                         ttt[r.BuyEntry?.Name] = 1;
                                     }
                                 });
            return ttt;
        }

        private void ProcessLine(string line)
        {
            try{
                if (IsTicketNameLine(line)){
                    SaveCurrentTicker();
                    string name = GetTickerName(line);
                    if (string.IsNullOrEmpty(name)){
                        hasErrors = true;
                        log.Error("Ticker without name in line: " + line);
                        return;
                    }
                    ticker.TickerName = name;
                    ticker.date = GetDate(line);
                    if (ticker.date.Ticks == DateTime.MinValue.Ticks){
                        hasErrors = true;
                        log.Error("Date parsing error in line: " + line);
                        return;
                    }
                    return;
                }


                if (IsTickerEntry("Buy", line)){
                    ticker.BuyEntry = GetTickerEntry("Buy", line);
                    if (ticker.BuyEntry == null){
                        hasErrors = true;
                        log.Error("Error for parsing buy entry in line: " + line);
                        return;
                    }
                    return;
                }

                if (IsTickerEntry("Sell", line)){
                    ticker.SellEntry = GetTickerEntry("Sell", line);
                    if (ticker.SellEntry == null){
                        hasErrors = true;
                        log.Error("Error for parsing sell entry in line: " + line);
                        return;
                    }
                    return;
                }

                if (IsOrderParameters(line))
                    ApplyOrderParams(line);

            } catch (Exception ex){
                log.Error("Error on line: " + line);
                log.Error(ex);
                hasErrors = true;
            }
        }

        private void ApplyOrderParams(string line)
        {
            try{
                string paramsLine = line.Substring(26 + orderParamIdent.Length);
                if (paramsLine.IndexOf(", STP1") < 0)
                    paramsLine = paramsLine.Replace(" STP1", ", STP1");
                Hashtable table = paramsLine.ToHashtable(',', ':');
                Type type = typeof (Ticker);
                foreach (PropertyInfo info in type.GetProperties()){
                    if (table.ContainsKey(info.Name))
                        info.SetValue(ticker, table[info.Name], null);
                }
            } catch (Exception ex){
                log.Error(ex);
            }
        }

        private bool IsOrderParameters(string line)
        {
            return line.IndexOf(orderParamIdent) == 26;
        }

        private bool IsTickerEntry(string name, string line)
        {
            return line.IndexOf(GetEntryIdent(name)) == 26;
        }

        private static string GetEntryIdent(string name)
        {
            return name + " entry";
        }

        private TickerEntry GetTickerEntry(string name, string line)
        {
            try{
                string entry = line.Substring(26 + GetEntryIdent(name).Length + 2);
                string[] kv = entry.Split(':');
                if (kv.Length != 2){
                    log.Error("Invalid entry format in line: " + line);
                    return null;
                }
                return new TickerEntry{Name = kv[0].Trim(), Val = kv[1].Trim()};
            } catch (Exception ex){
                log.Error(ex);
                return null;
            }
        }

        private DateTime GetDate(string line)
        {
            try{
                var dateStr = $"{line.Substring(0, 19)}.{line.Substring(20, 3)}";

                return dateStr.ToDateTimeUniversal();
            } catch (Exception ex){
                log.Error(ex);
                return DateTime.MinValue;
            }
        }

        private static bool IsTicketNameLine(string line)
        {
            return line.IndexOf(tickerIdent) == 25 && line.IndexOf(":", 32) > 0;
        }


        private void SaveCurrentTicker()
        {
            if (ticker.Valid())
                tickerList.Add(ticker);
            ticker = new Ticker();
        }

        private string GetTickerName(string line)
        {
            try{
                return line.Substring(25 + tickerIdent.Length).Replace(":", "");
            } catch (Exception ex){
                log.Error(ex);
                return null;
            }
        }
    }
}