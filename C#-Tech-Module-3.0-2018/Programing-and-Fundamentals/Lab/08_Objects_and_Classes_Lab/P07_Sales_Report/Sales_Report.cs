using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_Sales_Report
{
    class Sale
    {
        public string Town { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public double Quantity { get; set; }

        public Sale(string town, string product, decimal price, double quantity)
        {
            Town = town;
            Product = product;
            Price = price;
            Quantity = quantity;
        }
        
    }
    class Sales_Report
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            SortedDictionary<string, List<Sale>> sales = new SortedDictionary<string, List<Sale>>();
            List<Sale> listOfSales = new List<Sale>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ');

                string town = input[0];
                string product = input[1];
                decimal price = decimal.Parse(input[2]);
                double quantity = double.Parse(input[3]);

                
                Sale salesGroup = new Sale(town,product,price,quantity);
                

                if (!sales.ContainsKey(town))
                {
                    sales.Add(town, new List<Sale>());
                    sales[town].Add(salesGroup);
                }
                else
                {
                    sales[town].Add(salesGroup);
                }
                
            }

            foreach (var item in sales)
            {
                var town = item.Key;
                var sum = item.Value.Sum(s => s.Price * (decimal)s.Quantity);

                Console.WriteLine($"{town} -> {sum:F2}");
            }
        }
    }
}
