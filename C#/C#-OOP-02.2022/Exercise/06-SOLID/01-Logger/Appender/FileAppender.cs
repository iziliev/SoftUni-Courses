using _01_Logger.Layout;
using _01_Logger.LogFiles;
using _01_Logger.ReportLevels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _01_Logger.Appender
{
    public class FileAppender : Appender
    {
        private const string path = "../../../log.txt";
        private ILogFile logFile;
        public FileAppender(ILayout layout, ILogFile logFile) 
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel level, string message)
        {
            this.Count++;
            this.logFile.Write(string.Format(Layout.Format, dateTime, level, message));
            File.AppendAllText(path, string.Format(Layout.Format, dateTime, level, message) + Environment.NewLine);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, File size: {this.logFile.Size}";
        }
    }
}
