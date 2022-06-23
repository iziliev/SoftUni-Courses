using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    public class StartUp
    {
        public static void Main()
        {
            var vowel = new Queue<char>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray());

            var consonant = new Stack<char>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray());

            var dict = new Dictionary<string, int[]>();

            var words = new string[4] { "pear", "flour", "pork", "olive" };

            for (int i = 0; i < words.Length; i++)
            {
                dict.Add(words[i], new int[words[i].Length]);
            }

            while (consonant.Count>0)
            {
                var currentVowel = vowel.Dequeue();
                var currentCnsonant = consonant.Pop();

                foreach (var item in dict)
                {
                    for (int i = 0; i < item.Key.Length; i++)
                    {
                        if (item.Key[i]==currentVowel)
                        {
                            dict[item.Key][i] = 1;
                        }
                        if (item.Key[i] == currentCnsonant)
                        {
                            dict[item.Key][i] = 1;
                        }
                    }
                }
                vowel.Enqueue(currentVowel);
            }

            var countWords = dict.Where(x => x.Value.Sum() == x.Key.Length).Count();

            Console.WriteLine($"Words found: {countWords}");
            foreach (var item in dict.Where(x=>x.Value.Sum()== x.Key.Length))
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
