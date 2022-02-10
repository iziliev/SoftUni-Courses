using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Hogwarts_Sorting
{
    class Hogwarts_Sorting
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var data = new Dictionary<string, List<string>>();
            data.Add("Gryffindor", new List<string>());
            data.Add("Slytherin", new List<string>());
            data.Add("Ravenclaw", new List<string>());
            data.Add("Hufflepuff", new List<string>());

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine().Split(' ');
                int sum = 0;

                for (int j = 0; j < name.Length; j++)
                {
                    for (int k = 0; k < name[j].Length; k++)
                    {
                        sum += name[j][k];
                    }
                }

                string names = sum.ToString() + name[0][0] + name[1][0];

                if (sum % 4 == 0)
                {
                    data["Gryffindor"].Add(names);
                }
                else if (sum % 4 == 1)
                {
                    data["Slytherin"].Add(names);
                }
                else if (sum % 4 == 2)
                {
                    data["Ravenclaw"].Add(names);
                }
                else if (sum % 4 == 3)
                {
                    data["Hufflepuff"].Add(names);
                }
                
            }
            foreach (var item in data)
            {
                if (item.Value.Count !=0)
                {
                    foreach (var items in item.Value)
                    {
                        Console.WriteLine($"{item.Key} {items}");
                    }
                }
            }
            foreach (var item in data)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
            }
        }
    }
}
