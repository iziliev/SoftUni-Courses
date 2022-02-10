using System;

namespace P01_Choose_a_Drink
{
    class Choose_a_Drink
    {
        static void Main()
        {
            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "athlete":
                    Console.WriteLine("Water");
                    break;
                case "businessman":
                case "businesswoman":
                    Console.WriteLine("Coffee");
                    break;
                case "softuni student":
                    Console.WriteLine("Beer");
                    break;
                default:
                    Console.WriteLine("Tea");
                    break;
            }
        }
    }
}
