namespace P08_Refactor_Volume_of_Pyramid
{
    using System;
    class Refactor_Volume_of_Pyramid
    {
        static void Main()
        {
            Console.Write("Side A: ");
            double sideA = double.Parse(Console.ReadLine());
            Console.Write("Side B: ");
            double sideB = double.Parse(Console.ReadLine());
            Console.Write("Heigth: ");
            double height = double.Parse(Console.ReadLine());
            double volume = (sideA * sideB * height) / 3;
            Console.WriteLine("Pyramid Volume: {0:F2}", volume);
        }
    }
}
