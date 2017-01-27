using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Log2CSVParser.Utilities;
using Log2CSVParser.Utilities.Extensions;
using Log2CSVParser.Utilities.Log;
using Log2CSVParser.Utilities.Structures;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing;
using SpreadsheetLight;
using static System.Single;

namespace Log2CSVParser
{
    internal class ExcellCopier
    {
        public int progress { get; private set; }

        public SimpleProcessResponse Copy(string sourceFile, string sourceFileWorksheet, List<List<string>> rangesSource, string templateFile, string templateFileWorksheet, List<List<string>> rangesTemplate, ILogManager log)
        {
            try{
                log.Info("");
                log.Info($"Copy cell from [file: \"{sourceFile}\", worksheet: {sourceFileWorksheet}, range: {rangesSource.Select(r => r.ToStringWithDelimeter(":")).ToList().ToStringWithDelimeter(";")}] to [file: \"{templateFile}\", worksheet: {templateFileWorksheet}, range: {rangesTemplate.Select(r => r.ToStringWithDelimeter(":")).ToList().ToStringWithDelimeter(";")}]");
                string excellNewFile = Path.Combine(Path.GetDirectoryName(templateFile) ?? "", Path.GetFileNameWithoutExtension(templateFile) + "_" + DateTime.Now.ToString("MMddyyyy_HHmmss") + ".xlsx");
                File.Copy(templateFile, excellNewFile);
                log.Info("Create new file: " + excellNewFile);
                int allColumn = rangesSource.Sum(r => r.Count);
                int currColumn = 1;
                using (SLDocument source = new SLDocument(sourceFile))
                using (SLDocument newFile = new SLDocument(excellNewFile)){
                    source.SelectWorksheet(sourceFileWorksheet);
                    newFile.SelectWorksheet(templateFileWorksheet);
                    for (int rangeIdx = 0;rangeIdx < rangesSource.Count;rangeIdx++){
                        var colSource = rangesSource[rangeIdx];
                        var colTemplate = rangesTemplate[rangeIdx];
                        int rangeSize = colSource.Count;
                        for (int columnsIdx = 0;columnsIdx < rangeSize;columnsIdx++){
                            currColumn++;
                            progress = (int)(currColumn*100/(decimal)allColumn);
                            Application.DoEvents();
                            string colNameSource = colSource[columnsIdx];
                            string colNameTemplate = colTemplate[columnsIdx];
                            CopyAllLines(source, newFile, colNameSource, colNameTemplate, log);
                        }
                        newFile.Save();
                    }
                }
                return SimpleProcessResponse.Success(excellNewFile);
            } catch (Exception ex){
                log.Error(ex);
                return SimpleProcessResponse.Fail("System error: " + ex.Message);
            } finally{
                log.Info("End copy process");
            }
        }

        private static void CopyAllLines(SLDocument source, SLDocument newFile, string colNameSource, string colNameTemplate, ILogManager log)
        {
            try{
                int emptyCount = 0;
                for (int line = 1;line < 10000;line++){
                    string data = source.GetCellValueAsString($"{colNameSource}{line}");
                    newFile.SetCellValue_Custom($"{colNameTemplate}{line}", data);
                    log.Info($"{colNameSource}{line} => {colNameTemplate}{line}: "+ data);
                    if (!string.IsNullOrEmpty(data))
                        emptyCount = 0;
                    else
                        ++emptyCount;
                    if (emptyCount > 30)
                        break;
                }
            } catch (Exception ex){
                log.Error(ex);
            }
        }

        public static void Test()
        {
            FileInfo newFile = new FileInfo("E:\\Analyze\\UW\\!Template_2.xlsx");
            using (ExcelPackage pck = new ExcelPackage(newFile)){
                using (ExcelWorksheets ws = pck.Workbook.Worksheets) {
                    ExcelWorksheet worksheet = ws.First();
                    worksheet.Cells["A1"].Value = "1000";
                    pck.Save();
                }
            }
        }

    }
}