namespace P02_Choose_a_Drink_2_0
{
    using System;
    class Choose_a_Drink_2_0
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int quantitry = int.Parse(Console.ReadLine());
            double price = 0.00;

            switch (input)
            {
                case "Athlete":
                    price = quantitry * 0.70;
                    Console.WriteLine($"The {input} has to pay {price:f2}.");
                    break;
                case "Businessman":
                case "Businesswoman":
                    price = quantitry * 1.00;
                    Console.WriteLine($"The {input} has to pay {price:f2}.");
                    break;
                case "SoftUni Student":
                    price = quantitry * 1.70;
                    Console.WriteLine($"The {input} has to pay {price:f2}.");
                    break;
                default:
                    price = quantitry * 1.20;
                    Console.WriteLine($"The {input} has to pay {price:f2}.");
                    break;
            }
        }
    }
}
