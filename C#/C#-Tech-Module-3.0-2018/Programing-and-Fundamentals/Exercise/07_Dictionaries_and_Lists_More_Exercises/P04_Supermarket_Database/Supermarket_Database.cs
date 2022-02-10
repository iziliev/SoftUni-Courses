using System;
using System.Collections.Generic;

namespace P04_Supermarket_Database
{
    class Supermarket_Database
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, double> stockPrice = new Dictionary<string, double>();
            Dictionary<string, int> stockQuantuty = new Dictionary<string, int>();
            while (input != "stocked")
            {
                string[] data = input
                    .Split(' ');
                string nameOfStock = data[0];
                double priceOfStock = double.Parse(data[1]);
                int quantityOfStock = int.Parse(data[2]);

                if (!stockPrice.ContainsKey(nameOfStock) && 
                    !stockQuantuty.ContainsKey(nameOfStock))
                {
                    stockPrice.Add(nameOfStock, priceOfStock);
                    stockQuantuty.Add(nameOfStock, quantityOfStock);
                }
                else
                {
                    stockPrice[nameOfStock] = priceOfStock;
                    stockQuantuty[nameOfStock] += quantityOfStock;
                }
                input = Console.ReadLine();
            }
            double sum = 0.00;
            foreach (var item in stockPrice)
            {
                foreach (var items in stockQuantuty)
                {
                    if (item.Key == items.Key)
                    {
                        Console.WriteLine($"{item.Key}: ${item.Value:F2} * {items.Value} = ${(item.Value*items.Value):F2}");
                        sum += item.Value * items.Value;
                    }
                }
            }
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Grand Total: ${sum:f2}");
        }
    }
}
