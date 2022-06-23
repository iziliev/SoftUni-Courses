using _01_Logger.Layout;
using _01_Logger.ReportLevels;
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

        public override void Append(string dateTime, ReportLevel level, string message)
        {
            this.Count++;
            Console.WriteLine(string.Format(Layout.Format, dateTime, level, message));
        }
    }
}
