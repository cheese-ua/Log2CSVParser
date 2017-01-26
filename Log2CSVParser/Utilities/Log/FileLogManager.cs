using System;
using System.IO;
using System.Threading;
using Log2CSVParser.Utilities.Extensions;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Log2CSVParser.Utilities.Log
{
    public class FileLogManager : ILogManager
    {
        public readonly string FileName;
        private readonly Logger _logger;
        public int MaxMessageSize { get; set; }

        static FileLogManager()
        {
            FileTarget target = new FileTarget{
                Layout = "[${threadname}] ${message}",
                FileName = "${logger}",
                ArchiveFileName =
                    "${event-context:item=arch_dir}/${date:format=yyyyMMddHHmmss}_${event-context:item=file_name_we}_{#}.arch",
                ArchiveEvery = FileArchivePeriod.None,
                ArchiveNumbering = ArchiveNumberingMode.Rolling,
                MaxArchiveFiles = int.MaxValue,
                ArchiveAboveSize = 1024*1024*25,
                ConcurrentWrites = true
            };

            LogLevel writelevel = LogLevel.Info;
            SimpleConfigurator.ConfigureForTargetLogging(target, writelevel);
        }

        public FileLogManager(string FileName)
        {
            try{
                this.FileName = Path.GetFullPath(FileName);
                _logger = LogManager.GetLogger(this.FileName);
                MaxMessageSize = int.MaxValue;
            } catch (Exception ex){
                throw new Exception("Log create error " + FileName, ex);
            }
        }

        private void WriteLog(string line, LogLevel logLevel)
        {
            try{
                _WriteToLogger(line, logLevel);
            } catch{
            }
        }



        private void _WriteToLogger(string line, LogLevel level)
        {
            if (string.IsNullOrEmpty(line))
                line = "";
            if (MaxMessageSize > 0 && line.Length > MaxMessageSize){
                line = line.Substring(0, MaxMessageSize) + " ...";
            }
            string startLine = $"\n[{Thread.CurrentThread.Name}] {DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} ";
            string message = $"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} {line.Replace("\n", startLine)}";

            LogEventInfo logEvent = new LogEventInfo(level, _logger.Name, message);
            _logger.Log(typeof (LogManager), logEvent);
        }



        public void Debug(string message)
        {
            WriteLog(message, LogLevel.Debug);
        }

        public void Error(string message)
        {
            WriteLog(message, LogLevel.Error);
        }

        public void Fatal(string message)
        {
            WriteLog(message, LogLevel.Fatal);
        }

        public void Info(string message)
        {
            WriteLog(message, LogLevel.Info);
        }

        public void Trace(string message)
        {
            WriteLog(message, LogLevel.Trace);
        }

        public void Warn(string message)
        {
            WriteLog(message, LogLevel.Warn);
        }

        public void Debug(string message, Exception ex)
        {
            WriteLog(message, LogLevel.Debug);
            WriteLog(ex.ToStringSimple(), LogLevel.Debug);
        }

        public void Error(string message, Exception ex)
        {
            WriteLog(message, LogLevel.Error);
            WriteLog(ex.ToStringSimple(), LogLevel.Error);
        }

        public void Fatal(string message, Exception ex)
        {
            WriteLog(message, LogLevel.Fatal);
            WriteLog(ex.ToStringSimple(), LogLevel.Fatal);
        }

        public void Info(string message, Exception ex)
        {
            WriteLog(message, LogLevel.Info);
            WriteLog(ex.ToStringSimple(), LogLevel.Info);
        }

        public void Trace(string message, Exception ex)
        {
            WriteLog(message, LogLevel.Trace);
            WriteLog(ex.ToStringSimple(), LogLevel.Trace);
        }

        public void Warn(string message, Exception ex)
        {
            WriteLog(message, LogLevel.Warn);
            WriteLog(ex.ToStringSimple(), LogLevel.Warn);
        }

        public void Debug(Exception ex)
        {
            WriteLog(ex.ToStringSimple(), LogLevel.Debug);
        }

        public void Error(Exception ex)
        {
            WriteLog(ex.ToStringSimple(), LogLevel.Error);
        }

        public void Fatal(Exception ex)
        {
            WriteLog(ex.ToStringSimple(), LogLevel.Fatal);
        }

        public void Info(Exception ex)
        {
            WriteLog(ex.ToStringSimple(), LogLevel.Info);
        }

        public void Trace(Exception ex)
        {
            WriteLog(ex.ToStringSimple(), LogLevel.Trace);
        }

        public void Warn(Exception ex)
        {
            WriteLog(ex.ToStringSimple(), LogLevel.Warn);
        }

        public void Dispose()
        {
        }

    }
}