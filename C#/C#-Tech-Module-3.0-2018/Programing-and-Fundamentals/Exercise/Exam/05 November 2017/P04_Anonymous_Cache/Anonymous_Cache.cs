using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Anonymous_Cache
{
    class Anonymous_Cache
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, Dictionary<string, long>> data = new Dictionary<string, Dictionary<string, long>>();

            Dictionary<string, Dictionary<string, long>> store = new Dictionary<string, Dictionary<string, long>>();
            

            while (input != "thetinggoesskrra")
            {
                string[] dataInput = input
                    .Split(" ->|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (dataInput.Length == 1)
                {
                    string dataSet = dataInput[0];
                    string dataKey = string.Empty;
                    long dataSize = 0;

                    if (store.ContainsKey(dataSet))
                    {
                        foreach (var item in store)
                        {
                            if (dataSet == item.Key)
                            {
                                var dict = item.Value;
                                foreach (var items in dict)
                                {
                                    dataKey = items.Key;
                                    dataSize = items.Value;
                                    if (!data.ContainsKey(dataSet))
                                    {
                                        data.Add(dataSet, new Dictionary<string, long>());
                                    }
                                    data[dataSet][dataKey] = dataSize;
                                }       
                            }
                        }
                        store.Remove(dataSet);
                    }
                    else
                    {
                        data.Add(dataSet, new Dictionary<string, long>());
                    }
                }
                else
                {
                    if (!data.ContainsKey(dataInput[2]))
                    {
                        string dataSet = dataInput[2];
                        string dataKey = dataInput[0];
                        int dataSize = int.Parse(dataInput[1]);

                        if (!store.ContainsKey(dataSet))
                        {
                            store.Add(dataSet, new Dictionary<string, long>());
                            store[dataSet][dataKey] = dataSize;
                        }

                        if (!store[dataSet].ContainsKey(dataKey))
                        {
                         store[dataSet][dataKey] = dataSize;
                        }
                    }
                    else
                    {
                        string dataSet = dataInput[2];
                        string dataKey = dataInput[0];
                        int dataSize = int.Parse(dataInput[1]);

                        foreach (var item in data)
                        {
                            if (item.Key == dataSet)
                            {
                                data[dataSet][dataKey] = dataSize;
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
            long maxSum = 0;

            foreach (var item in data.OrderByDescending(x=>x.Value.Values.Sum()))
            {
                var sum = item.Value.Values.Sum();

                if (maxSum < sum)
                {
                    maxSum = sum;
                }
                else
                {
                    data.Remove(item.Key);
                }
                
                if (data.Count == 1)
                {
                    break;
                }
            }

            foreach (var item in data)
            {
                Console.WriteLine($"Data Set: {item.Key}, Total Size: {maxSum}");

                foreach (var items in item.Value)
                {
                    Console.WriteLine($"$.{items.Key}");
                }
            }
        }
    }
}
