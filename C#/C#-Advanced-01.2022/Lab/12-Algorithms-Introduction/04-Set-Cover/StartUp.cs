using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Set_Cover
{
    public class StartUp
    {
        public static void Main()
        {
            var universe = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var n = int.Parse(Console.ReadLine());

            var sets = new List<int[]>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                sets.Add(tokens);
            }

            var result = ChooseSets(sets, universe);

            Console.WriteLine($"Sets to take ({result.Count}):");

            foreach (var item in result)
            {
                Console.WriteLine($"{{ {string.Join(", ", item)} }}");
            }

        }
        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            var index = 0;
            var result = new List<int[]>();
            while (universe.Count>0)
            {
                var array = sets.OrderByDescending(x => x.Count(x => universe.Contains(x))).FirstOrDefault();
                result.Add(array);

                foreach (var item in array)
                {
                    universe.Remove(item);
                }

                index++;
            }
            return result;
        }
    }
}
