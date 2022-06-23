namespace P04_Beverage_Labels
{
    using System;
    class Beverage_Labels
    {
        static void Main()
        {
            string name = Console.ReadLine();
            int volume = int.Parse(Console.ReadLine());
            int energy = int.Parse(Console.ReadLine());
            int sugar = int.Parse(Console.ReadLine());

            double devide = 1.0 * volume / 100;
            double kcal = energy * devide;
            double sugars = sugar * devide;

            Console.WriteLine($"{volume}ml {name}:");
            Console.WriteLine($"{kcal}kcal, {sugars}g sugars");
        }
    }
}
