using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Logger.LogFiles
{
    public interface ILogFile
    {
        public int Size { get; }

        public void Write(string message);
    }
}
