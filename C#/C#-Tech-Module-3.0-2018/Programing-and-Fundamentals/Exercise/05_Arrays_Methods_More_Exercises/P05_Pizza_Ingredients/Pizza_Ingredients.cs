using System;
using System.Collections.Generic;

namespace P05_Pizza_Ingredients
{
    class Pizza_Ingredients
    {
        static void Main()
        {
            string[] array = Console.ReadLine()
                .Split(' ');
            int n = int.Parse(Console.ReadLine());

            int count = 0;

            List<string> addingIngredients = new List<string>();

            for (int i = 0; i < array.Length; i++)
            {
                string ingredients = array[i];

                if (ingredients.Length == n)
                {
                    Console.WriteLine($"Adding {ingredients}.");
                    addingIngredients.Add(ingredients);
                    count++;
                }
                if (count==10)
                {
                    break;
                }
            }
            Console.WriteLine($"Made pizza with total of {addingIngredients.Count} ingredients.");
            Console.WriteLine($"The ingredients are: {string.Join(", ",addingIngredients)}.");
        }
    }
}
