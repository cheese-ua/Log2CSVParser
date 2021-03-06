﻿using System;

namespace Log2CSVParser.Utilities.Log
{
    public interface ILogManager: IDisposable
    {
        void Debug(string message);
        void Error(string message);
        void Fatal(string message);
        void Info(string message);
        void Trace(string message);
        void Warn(string message);
        void Debug(string message, Exception ex);
        void Error(string message, Exception ex);
        void Fatal(string message, Exception ex);
        void Info(string message, Exception ex);
        void Trace(string message, Exception ex);
        void Warn(string message, Exception ex);
        void Debug(Exception ex);
        void Error(Exception ex);
        void Fatal(Exception ex);
        void Info(Exception ex);
        void Trace(Exception ex);
        void Warn(Exception ex);
    }
}