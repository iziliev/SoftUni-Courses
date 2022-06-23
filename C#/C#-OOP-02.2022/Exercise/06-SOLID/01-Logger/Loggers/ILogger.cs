using _01_Logger.Appender;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Logger.Loggers
{
    public interface ILogger
    {
        public IAppender[] Appenders { get; }

        public void Info(string date, string message);

        public void Warning(string date, string message);

        public void Error(string date, string message);

        public void Critical(string date, string message);

        public void Fatal(string date, string message);

    }
}
