using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    public class StartUp
    {
        public static void Main()
        {
            var foodsAmount = new int[] { 25, 50, 75, 100 };

            var liquids = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var ingredients = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var food = new Dictionary<string, int>()
            {
                { "Bread",0 },
                { "Cake",0 },
                { "Pastry",0 },
                { "Fruit Pie",0 }
            };

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                var currentLiquid = liquids.Dequeue();
                var currentIngredient = ingredients.Peek();

                var getAmountIndex = Array.IndexOf(foodsAmount, currentLiquid + currentIngredient);

                if (getAmountIndex != -1)
                {
                    switch (getAmountIndex)
                    {
                        case 0:
                            food["Bread"]++;
                            break;
                        case 1:
                            food["Cake"]++;
                            break;
                        case 2:
                            food["Pastry"]++;
                            break;
                        case 3:
                            food["Fruit Pie"]++;
                            break;
                        default:
                            break;
                    }
                    ingredients.Pop();
                }
                else
                {
                    ingredients.Push(ingredients.Pop() + 3);
                }
            }

            if (!food.ContainsValue(0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }

            foreach (var item in food.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
