using System;

namespace GenericScale
{
    public class StartUp
    {
        public static void Main()
        {
            var scale = new EqualityScale<string>("Ivan","Rvan");

            Console.WriteLine(scale.AreEqual());
        }
    }
}
