using System;
using System.Linq;

namespace _04_Add_VAT
{
    public class StartUp
    {
        public static void Main()
        {
            var prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x=>x*1.2)
                .ToArray();

            foreach (var price in prices)
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
