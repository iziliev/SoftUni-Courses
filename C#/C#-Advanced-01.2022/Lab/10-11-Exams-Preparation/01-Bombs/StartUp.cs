using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    public class StartUp
    {
        public static int[] bombValue = new int[]{ 40, 60, 120 };
        public static string[] bombString = new string[] { "Datura Bombs", "Cherry Bombs", "Smoke Decoy Bombs" };
        public static Dictionary<string, int> bombs = new Dictionary<string, int>()
        {
            {"Datura Bombs",0 },
            { "Cherry Bombs",0},
            {"Smoke Decoy Bombs",0 }
        };
        public static void Main()
        {
            var effects = new Queue<int>(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var casings = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            while (effects.Count>0&&casings.Count>0)
            {
                var currentEffect = effects.Peek();
                var currentCasing = casings.Peek();

                var bomb = currentCasing + currentEffect;

                if (bombValue.Contains(bomb))
                {
                    var index = Array.IndexOf(bombValue, bomb);
                    bombs[bombString[index]]++;
                    effects.Dequeue();
                    casings.Pop();
                }
                else
                {
                    casings.Push(casings.Pop()-5);
                }

                if (!bombs.Values.Any(x => x < 3))
                {
                    break;
                }
            }

            if (bombs.Values.Any(x=>x<3))
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            else
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }

            if (effects.Count==0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ",effects)}");
            }

            if (casings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
            }

            foreach (var bomb in bombs.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
