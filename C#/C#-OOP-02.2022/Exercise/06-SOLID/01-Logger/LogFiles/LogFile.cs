using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_Logger.LogFiles
{
    public class LogFile : ILogFile
    {
        private StringBuilder sb;
        public LogFile()
        {
            this.sb = new StringBuilder();
        }

        public int Size 
            => this.sb
            .ToString()
            .Where(x=>char.IsLetter(x))
            .Sum(x=>x);

        public void Write(string messages)
        {
            sb.Append(messages);
        }
    }
}
