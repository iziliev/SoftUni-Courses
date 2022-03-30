using _01_Logger.Appender;
using _01_Logger.Layout;
using _01_Logger.LogFiles;
using _01_Logger.ReportLevels;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Logger.Factory
{
    public static class AppenderFactory
    {
        public static IAppender CreateAppender(string appenderType, ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
        {
            IAppender appender = appenderType switch
            {
                "ConsoleAppender" => new ConsoleAppender(layout),
                "FileAppender" => new FileAppender(layout, new LogFile()),
               _=> throw new InvalidOperationException("Missing type")
            };

            appender.ReportLevel = reportLevel;

            return appender;
        }
    }
}
