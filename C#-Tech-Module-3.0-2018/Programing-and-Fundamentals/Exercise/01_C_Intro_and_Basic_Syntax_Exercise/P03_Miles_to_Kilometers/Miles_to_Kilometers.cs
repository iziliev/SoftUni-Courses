namespace P03_Miles_to_Kilometers
{
    using System;
    class Miles_to_Kilometers
    {
        static void Main()
        {
            double mile = double.Parse(Console.ReadLine());

            double kilometers = mile * 1.60934;

            Console.WriteLine($"{kilometers:F2}");
        }
    }
}
