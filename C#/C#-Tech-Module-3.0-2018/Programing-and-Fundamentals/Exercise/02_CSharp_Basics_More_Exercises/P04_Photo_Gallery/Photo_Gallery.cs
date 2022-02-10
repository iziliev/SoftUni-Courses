namespace P04_Photo_Gallery
{
    using System;
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int hour = int.Parse(Console.ReadLine());
            int minute = int.Parse(Console.ReadLine());
            double size = double.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            Console.WriteLine($"Name: DSC_{number:D4}.jpg");
            Console.WriteLine($"Date Taken: {day:D2}/{month:D2}/{year} {hour:D2}:{minute:D2}");
            if (size >= 0 && size <= 999)
            {
                Console.WriteLine($"Size: {size}B");
            }
            else if (size > 999 && size <= 999999)
            {
                Console.WriteLine($"Size: {size/1000}KB");
            }
            else if (size > 999999)
            {
                Console.WriteLine($"Size: {size / 1000000}MB");
            }

            if (width > height)
            {
                Console.WriteLine($"Resolution: {width}x{height} (landscape)");
            }
            else if (width < height)
            {
                Console.WriteLine($"Resolution: {width}x{height} (portrait)");
            }
            else if (width == height)
            {
                Console.WriteLine($"Resolution: {width}x{height} (square)");
            }
        }
    }
}
