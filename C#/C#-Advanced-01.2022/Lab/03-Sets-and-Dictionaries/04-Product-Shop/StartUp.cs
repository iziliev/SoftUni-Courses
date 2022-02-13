using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Product_Shop
{
    class StartUp
    {
        static void Main()
        {
            var dict = new Dictionary<string, Dictionary<string, double>>();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "Revision")
            {
                var data = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (!dict.ContainsKey(data[0]))
                {
                    dict[data[0]] = new Dictionary<string, double>();
                }

                if (!dict[data[0]].ContainsKey(data[1]))
                {
                    dict[data[0]][data[1]] = 0;
                }

                dict[data[0]][data[1]] = double.Parse(data[2]);
            }

            foreach (var item in dict.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}->");

                foreach (var items in item.Value)
                {
                    Console.WriteLine($"Product: {items.Key}, Price: {items.Value}");
                }
            }
        }
    }
}
