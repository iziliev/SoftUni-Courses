using _01_Logger.Layout;
using _01_Logger.ReportLevels;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Logger.Appender
{
    public interface IAppender
    {
        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public int Count { get; }

        public void Append(string dateTime,ReportLevel level, string message);
    }
}
