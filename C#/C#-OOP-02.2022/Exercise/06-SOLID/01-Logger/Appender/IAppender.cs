using _01_Logger.Layout;
using _01_Logger.ReportLevel;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Logger.Appender
{
    public interface IAppender
    {
        public ILayout Layout { get; }

        public int Count { get; }

        public LogLevel ReportLevel { get; set; }

        string GetAppenderInfo();

        public void AppendMessage(string dateTime, LogLevel level, string message);

    }
}
