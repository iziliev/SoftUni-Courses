namespace P03_Megapixels
{
    using System;
    class Megapixels
    {
        static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double megaPx = width * height / 1000000;

            Console.WriteLine($"{width}x{height} => {Math.Round(megaPx,1)}MP");
        }
    }
}
