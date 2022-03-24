using _01_Logger.Layout;
using _01_Logger.ReportLevels;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Logger.Appender
{
    public abstract class Appender : IAppender
    {
        public Appender(ILayout layout)
        {
            this.Layout = layout;
        }
        public ILayout Layout {get; private set;}

        public ReportLevel ReportLevel { get ; set ; }

        public int Count { get; protected set; }

        public abstract void Append(string dateTime, ReportLevel level, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.Count}";
        }

    }
}
