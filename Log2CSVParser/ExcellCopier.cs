using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Log2CSVParser.Utilities;
using Log2CSVParser.Utilities.Extensions;
using Log2CSVParser.Utilities.Log;
using Log2CSVParser.Utilities.Structures;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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
                log.Info($"Copy cell from [file: \"{sourceFile}\", worksheet: {sourceFileWorksheet}, range: {rangesSource.Select(r => r[0] + ":" + r[r.Count - 1]).ToList().ToStringWithDelimeter(";")}] to [file: \"{templateFile}\", worksheet: {templateFileWorksheet}, range: {rangesTemplate.Select(r => r[0] + ":" + r[r.Count - 1]).ToList().ToStringWithDelimeter(";")}]");
                string excellNewFile = Path.Combine(Path.GetDirectoryName(templateFile) ?? "", Path.GetFileNameWithoutExtension(templateFile) + "_" + DateTime.Now.ToString("MMddyyyy_HHmmss") + ".xlsx");
                File.Copy(templateFile, excellNewFile);
                log.Info("Create new file: " + excellNewFile);
                int allColumn = rangesSource.Sum(r => r.Count);
                int currColumn = 1;
                using (ExcelPackage source = new ExcelPackage(new FileInfo(sourceFile)))
                using (ExcelPackage newFile = new ExcelPackage(new FileInfo(excellNewFile))){
                    var sourceWS = source.Workbook.Worksheets.First(w => w.Name.Equals(sourceFileWorksheet));
                    var temlateWS = newFile.Workbook.Worksheets.First(w => w.Name.Equals(templateFileWorksheet));
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
                            CopyAllLines(sourceWS, temlateWS, colNameSource, colNameTemplate, log);
                        }
                        log.Info("Begin save file");
                        newFile.Save();
                        log.Info("Saving completed");
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

        private static void CopyAllLines(ExcelWorksheet srcFile, ExcelWorksheet tmplFile, string colNameSource, string colNameTemplate, ILogManager log)
        {
            try{
                int emptyCount = 0;
                for (int line = 1;line < 10000;line++){
                    string srcName = $"{colNameSource}{line}";
                    string tmplName = $"{colNameTemplate}{line}";
                    srcFile.Cells[srcName].Copy(tmplFile.Cells[tmplName]);
                    string data = (srcFile.Cells[srcName].Value ?? "").ToString();
                    tmplFile.SetCellValue_Custom(tmplName, data);
                    //ApplyStyle(srcFile.Cells[srcName], tmplFile.Cells[tmplName]);
                    //log.Info($"{colNameSource}{line} => {colNameTemplate}{line}: "+ data);
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

        private static void ApplyStyle(ExcelRange src, ExcelRange tmpl)
        {
            tmpl.Style.Fill.PatternType = src.Style.Fill.PatternType;
            SetColor(tmpl.Style.Fill.BackgroundColor, src.Style.Fill.BackgroundColor) ;
            //tmpl.Style.Font = src.Style.Font;
            SetColor(tmpl.Style.Font.Color, src.Style.Font.Color);
            tmpl.Style.Border = src.Style.Border;
        }

        private static void SetColor(ExcelColor tmplColor, ExcelColor excelColor)
        {
            string rgb = excelColor.Rgb;
            if (string.IsNullOrEmpty(rgb) || rgb.Length!=8)
                return;
            int a = Byte.Parse(rgb.Substring(0, 2), NumberStyles.HexNumber);
            int r = Byte.Parse(rgb.Substring(2, 2), NumberStyles.HexNumber);
            int g = Byte.Parse(rgb.Substring(4, 2), NumberStyles.HexNumber);
            int b = Byte.Parse(rgb.Substring(6, 2), NumberStyles.HexNumber);

            tmplColor.SetColor(Color.FromArgb(a, r, g, b));
        }
    }


}