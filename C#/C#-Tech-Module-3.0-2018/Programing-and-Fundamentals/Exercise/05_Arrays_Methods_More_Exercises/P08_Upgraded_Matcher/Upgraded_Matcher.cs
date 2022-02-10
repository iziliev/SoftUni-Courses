using System;
using System.Linq;

namespace P08_Upgraded_Matcher
{
    class Upgraded_Matcher
    {
        static void Main()
        {
            string[] product = Console.ReadLine()
                .Split(' ');

            int[] quantity = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            
            double[] price = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            string[] command = Console.ReadLine()
                .Split(' ');

            while (command[0] != "done")
            {
                int index = Array.IndexOf(product, command[0]);
                int quantityProduct = int.Parse(command[1]);

                if (index > quantity.Length-1)
                {
                    Console.WriteLine($"We do not have enough {command[0]}");
                }
                else
                {
                    if (quantity[index] >= quantityProduct)
                    {
                        Console.WriteLine($"{command[0]} x {command[1]} costs {quantityProduct * price[index]:F2}");
                        quantity[index] -= quantityProduct;
                    }
                    else
                    {
                        Console.WriteLine($"We do not have enough {command[0]}");
                    }
                }
                command = Console.ReadLine()
                .Split(' ');
            }
        }
    }
}
