using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Ranking
{
    internal class StartUp
    {
        static void Main()
        {
            var input = string.Empty;

            var exam = new Dictionary<string, string>();
            var students = new Dictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "end of contests")
            {
                var data = input
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);

                if (!exam.ContainsKey(data[0]))
                {
                    exam[data[0]] = data[1];
                }
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                var data = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                if (exam.ContainsKey(data[0]) && exam[data[0]] == data[1])
                {
                    if (!students.ContainsKey(data[2]))
                    {
                        students[data[2]] = new Dictionary<string, int>();

                    }

                    if (!students[data[2]].ContainsKey(data[0]))
                    {
                        students[data[2]][data[0]] = 0;
                    }

                    if (students[data[2]][data[0]] < int.Parse(data[3]))
                    {
                        students[data[2]][data[0]] = int.Parse(data[3]);
                    }
                }
                
            }

            Dictionary<string, int> usernameTotalPoints = new Dictionary<string, int>();
            
            foreach (var item in students)
            {
                usernameTotalPoints[item.Key] = item.Value.Values.Sum();
            }
            
            string bestName = usernameTotalPoints
                .Keys
                .Max();
            int bestPoints = usernameTotalPoints
                .Values
                .Max();

            foreach (var kvp in usernameTotalPoints)
            {
                if (kvp.Value == bestPoints)
                {
                    Console.WriteLine($"Best candidate is {kvp.Key} with total {kvp.Value} points.");

                }
            }
            
            Console.WriteLine("Ranking:");
            foreach (var item in students.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}");

                foreach (var items in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {items.Key} -> {items.Value}");
                }
            }
        }
    }
}
