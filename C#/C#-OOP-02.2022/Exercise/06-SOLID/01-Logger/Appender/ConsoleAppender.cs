using _01_Logger.Layout;
using _01_Logger.ReportLevel;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Logger.Appender
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void AppendMessage(string dateTime, LogLevel level, string message)
        {
            this.Count++;
            var appendMessage = string.Format(this.Layout.Format, dateTime, level, message);
            Console.WriteLine(appendMessage);
        }

    }
}
