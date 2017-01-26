﻿using System;
using System.Collections.Generic;
using System.Linq;
using Log2CSVParser.Utilities.Log;
using SpreadsheetLight;

namespace Log2CSVParser.Utilities
{
    internal class ExcellExtension
    {

        static List<string> CreateEnumerator(char start)
        {
            int cnt = 0;
            List<string> list = new List<string>();
            for (char ch = start; ch<='Z';ch++){
                list.Add(ch.ToString());
                if(++cnt>1000)
                    throw new Exception("Incorrect cell name "+start);
            }
            return list;
        }

        public static List<string> CreateEnumeratorColumns(int size, ILogManager log)
        {
            List<string> list = CreateEnumeratorColumns("A", "ZZ", log);
            if(list.Count<size)
                throw new Exception("Unsupported columns count " + size);
            return list.GetRange(0, size);
        }


        public static List<string> CreateEnumeratorColumns(string start, string stop, ILogManager log)
        {
            try{
                List<string> res = new List<string>();

                string startUP = start.ToUpper().Trim();
                if (startUP.Length == 0 || startUP.Length > 2)
                    throw new Exception("Unsupported range " + startUP);

                string stopUP = stop.ToUpper().Trim();
                if (stopUP.Length == 0 || stopUP.Length > 2)
                    throw new Exception("Unsupported range " + stopUP);

                if (stopUP.Length < startUP.Length)
                    throw new Exception("Invalid range range " + stopUP);

                List<string> collection = CreateEnumerator('A');
                res.AddRange(collection);
                for (char char1 = startUP[0];char1 <= stopUP[0];char1++)
                    res.AddRange(collection.Select(char2 => $"{char1}{char2}"));

                while (true){
                    if(res[0]==startUP)
                        break;
                    res.RemoveAt(0);
                }
                while (true) {
                    if (res[res.Count-1] == stopUP)
                        break;
                    res.RemoveAt(res.Count - 1);
                }
                return res;
            } catch (Exception ex){
                log.Error(ex);
                throw;
            }   
        }

        static void Test(ILogManager log)
        {
            try{
                List<string> columns = CreateEnumeratorColumns("A", "zz", log);
                log.Info(columns+"");


                using (SLDocument sl = new SLDocument("E:\\Analyze\\UW\\CSV sample format - Copy.xlsx")) {
                    List<string> sheetNames = sl.GetSheetNames();
                    log.Info(sheetNames + "");
                    sl.SelectWorksheet(sheetNames[1]);
                    foreach (string column in columns){
                        for (int i = 0;i < 10;i++){
                            sl.SetCellValue(column + i, column + i+" "+DateTime.Now);
                        }
                    }
                    sl.Save();
                }
            } catch (Exception ex){
                log.Error(ex);
            }
        }
    }
}