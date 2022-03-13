using _01_Logger.Appender;
using _01_Logger.ReportLevel;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Logger.Loggers
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = new List<IAppender>(appenders);
            //this.Appenders.AddRange(appenders);
        }

        public List<IAppender> Appenders { get; }

        public void Critical(string dateTime, string message)
        {
            Log(dateTime,LogLevel.Critical, message);
        }

        public void Error(string dateTime,string message)
        {
            Log(dateTime, LogLevel.Error,message);
        }

        public void Fatal(string dateTime, string message)
        {
            Log(dateTime,LogLevel.Fatal,message);
        }

        public void Info(string dateTime, string message)
        {
            Log(dateTime, LogLevel.Info ,message);
        }

        public void Warning(string dateTime, string message)
        {
            Log(dateTime, LogLevel.Warning,message);
        }

        public string GetLoggerInfo()
        {
            var sb = new StringBuilder();
            foreach (var item in this.Appenders)
            {
                sb.AppendLine(item.GetAppenderInfo());
            }

            return sb.ToString().Trim();
        }

        private void Log(string dateTime, LogLevel level,string message)
        {
            foreach (IAppender appender in Appenders)
            {
                if (level>=appender.ReportLevel)
                {
                    appender.AppendMessage(dateTime, level, message);
                }
            }
        }


    }
}
