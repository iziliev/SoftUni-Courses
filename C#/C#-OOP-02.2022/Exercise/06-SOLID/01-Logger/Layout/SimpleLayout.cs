using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Logger.Layout
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
