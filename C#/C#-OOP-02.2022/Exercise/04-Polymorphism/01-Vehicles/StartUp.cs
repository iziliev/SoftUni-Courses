using _01_Vehicles.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Vehicles
{
    public static class StartUp
    {
        public static void Main()
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}