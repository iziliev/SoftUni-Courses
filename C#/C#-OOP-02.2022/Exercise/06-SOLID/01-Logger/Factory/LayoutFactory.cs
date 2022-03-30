using _01_Logger.Layout;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Logger.Factory
{
    public static class LayoutFactory
    {
        public static ILayout CreateLayout(string layoutType)
        {
            switch (layoutType)
            {
                case "SimpleLayout":
                    return new SimpleLayout();
                case "XmlLayout":
                    return new XmlLayout();
                default:
                    return null;
            }
        }
    }
}
