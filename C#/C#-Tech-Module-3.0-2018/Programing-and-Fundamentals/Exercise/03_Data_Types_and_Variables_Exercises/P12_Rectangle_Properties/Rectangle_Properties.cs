namespace P12_Rectangle_Properties
{
    using System;
    class Rectangle_Properties
    {
        static void Main()
        {
            double widht = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double perimeter = 2 * widht + 2 * height;
            double area = widht * height;
            double diagonal = Math.Sqrt(Math.Pow(widht, 2) + Math.Pow(height, 2));

            Console.WriteLine($"{perimeter}");
            Console.WriteLine($"{area}");
            Console.WriteLine($"{diagonal}");
        }
    }
}
