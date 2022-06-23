using _01_Logger.Appender;
using _01_Logger.ReportLevels;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Logger.Loggers
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public IAppender[] Appenders { get; private set; }

        public void Critical(string date, string message)
        {
            foreach (var appender in this.Appenders)
            {
                if (ReportLevel.Critical >= appender.ReportLevel)
                {
                    appender.Append(date, ReportLevel.Critical, message);
                }
            }
            
        }

        public void Error(string date, string message)
        {
            foreach (var appender in this.Appenders)
            {
                if (ReportLevel.Error >= appender.ReportLevel)
                {
                    appender.Append(date, ReportLevel.Error, message);
                }
            }
        }

        public void Fatal(string date, string message)
        {
            foreach (var appender in this.Appenders)
            {
                if (ReportLevel.Fatal >= appender.ReportLevel)
                {
                    appender.Append(date, ReportLevel.Fatal, message);
                }
                
            }
        }

        public void Info(string date, string message)
        {
            foreach (var appender in this.Appenders)
            {
                if (ReportLevel.Info >= appender.ReportLevel)
                {
                    appender.Append(date, ReportLevel.Info, message);
                }
            }
        }

        public void Warning(string date, string message)
        {
            foreach (var appender in this.Appenders)
            {
                if (ReportLevel.Warning >= appender.ReportLevel)
                {
                    appender.Append(date, ReportLevel.Warning, message);
                }
            }
        }
    }
}
