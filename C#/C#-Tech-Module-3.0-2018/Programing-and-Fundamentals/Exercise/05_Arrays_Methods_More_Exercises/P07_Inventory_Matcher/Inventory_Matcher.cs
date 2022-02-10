using System;
using System.Linq;

namespace P07_Inventory_Matcher
{
    class Inventory_Matcher
    {
        static void Main()
        {
            string[] product = Console.ReadLine()
                .Split(' ');
            string[] quantity = Console.ReadLine()
                .Split(' ');
            string[] price = Console.ReadLine()
                .Split(' ');

            string command = Console.ReadLine();

            while (command != "done")
            {
                int index = Array.IndexOf(product, command);

                Console.WriteLine($"{product[index]} costs: {price[index]}; Available quantity: {quantity[index]}");
                
                command = Console.ReadLine();
            }
        }
    }
}
