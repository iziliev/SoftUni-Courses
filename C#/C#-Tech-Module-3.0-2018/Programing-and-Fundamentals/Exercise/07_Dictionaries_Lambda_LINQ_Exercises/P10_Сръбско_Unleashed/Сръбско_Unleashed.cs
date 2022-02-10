using System;
using System.Collections.Generic;
using System.Linq;

namespace P10_Сръбско_Unleashed
{
    class Сръбско_Unleashed
    {
        static void Main()
        {
            string input = Console.ReadLine().Trim();

            Dictionary<string, Dictionary<string, long>> artists = new Dictionary<string, Dictionary<string, long>>();

            while (input != "End")
            {
                var lastIndexOfSingerName = input.IndexOf(" @");

                if (lastIndexOfSingerName > 0)
                {
                    var name = input.Substring(0, lastIndexOfSingerName);
                    var newInput = input.Substring(lastIndexOfSingerName + 2, input.Length - (lastIndexOfSingerName + 2));
                    var data = newInput.Split(' ');

                    int price = -1;
                    int quantity = -1;

                    for (int i = data.Length - 1; i >= 0; i++)
                    {
                        try
                        {
                            price = int.Parse(data[i - 1]);
                            quantity = int.Parse(data[i]);

                            if (price >= 0 && quantity >= 0)
                            {
                                var priceStr = price.ToString();
                                var indexOfPrice = input.IndexOf($"{priceStr}");
                                var city = input.Substring(lastIndexOfSingerName + 2, indexOfPrice - lastIndexOfSingerName - 3);

                                if (!artists.ContainsKey(city))
                                {
                                    artists.Add(city, new Dictionary<string, long>());
                                }
                                if (!artists[city].ContainsKey(name))
                                {
                                    artists[city].Add(name, price * quantity);
                                }
                                else
                                {
                                    artists[city][name] += price * quantity;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            break;
                        }
                        continue;
                    }
                }
                  
                input = Console.ReadLine().Trim();
            }
            foreach (var item in artists)
            {
                Console.WriteLine($"{item.Key}");

                foreach (var items in item.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {items.Key} -> {items.Value}");
                }
            }
        }
        
    }
}
