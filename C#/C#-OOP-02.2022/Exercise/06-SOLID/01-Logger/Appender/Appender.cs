using _01_Logger.Layout;
using _01_Logger.ReportLevel;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Logger.Appender
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }

        public LogLevel ReportLevel { get ; set ; }

        public int Count {get; protected set; }

        public abstract void AppendMessage(string dateTime, LogLevel level, string message);

        public virtual string GetAppenderInfo()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel} Messages appended: {this.Count}";
        }
    }
}
