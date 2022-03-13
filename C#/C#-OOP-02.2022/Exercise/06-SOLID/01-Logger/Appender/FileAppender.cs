using _01_Logger.Layout;
using _01_Logger.LogFiles;
using _01_Logger.ReportLevel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _01_Logger.Appender
{
    public class FileAppender : Appender
    {
        private const string path = "../../../Output/log.txt";

        public FileAppender(ILayout layout, ILogFile logFile) 
            : base(layout)
        {
            this.LogFile = logFile;
        }

        public ILogFile LogFile { get; }

        public override void AppendMessage(string dateTime, LogLevel level, string message)
        {
            this.Count++;
            var appendMessage = String.Format(this.Layout.Format, dateTime, level, message);
            LogFile.Write(appendMessage);
            File.AppendAllText(path, appendMessage+Environment.NewLine);
        }
        public override string GetAppenderInfo()
        {
            return $"{base.GetAppenderInfo()}, File size: {this.LogFile.Size}";
        }
    }
}
