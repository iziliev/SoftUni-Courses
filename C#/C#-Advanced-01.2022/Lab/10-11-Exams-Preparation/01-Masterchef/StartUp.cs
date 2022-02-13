using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    public class StartUp
    {
        public static int[] dishInt = new int[] { 150, 250, 300, 400 };
        public static string[] dishString = new string[] { "Dipping sauce", "Green salad", "Chocolate cake", "Lobster" };
        public static Dictionary<string,int> dishes = new Dictionary<string, int>()
            {
                { "Dipping sauce",0},
                { "Green salad",0},
                { "Chocolate cake",0},
                { "Lobster",0}
            };
        public static void Main()
        {
            var ingredient = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var freshness = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            while (ingredient.Count>0&&freshness.Count>0)
            {
                var currentIngredient = ingredient.Peek();

                if (currentIngredient == 0)
                {
                    ingredient.Dequeue();
                    continue;
                }

                var currentFreshness = freshness.Pop();

                var multiply = currentFreshness * currentIngredient;

                if (dishInt.Contains(multiply))
                {
                    var index = Array.IndexOf(dishInt, multiply);
                    var dish = dishString[index];
                    dishes[dish]++;
                    ingredient.Dequeue();
                }
                else
                {
                    ingredient.Enqueue(ingredient.Dequeue() + 5);
                }
            }

            if (dishes.Values.Any(x=>x==0))
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            else
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }

            if (ingredient.Count>0)
            {
                Console.WriteLine($"Ingredients left: {ingredient.Sum()}");
            }

            foreach (var dish in dishes.OrderBy(x=>x.Key).Where(x=>x.Value>0))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }
    }
}
