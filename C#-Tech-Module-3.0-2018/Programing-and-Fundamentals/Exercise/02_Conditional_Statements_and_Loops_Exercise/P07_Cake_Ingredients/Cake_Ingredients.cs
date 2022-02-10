namespace P07_Cake_Ingredients
{
    using System;
    class Cake_Ingredients
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int count = 0;
            while (input != "Bake!")
            {
                count++;
                Console.WriteLine($"Adding ingredient {input}.");
                input = Console.ReadLine();
            }
            Console.WriteLine($"Preparing cake with {count} ingredients.");
        }
    }
}
