using System;

namespace P01_Snowballs
{
    class Snowballs
    {
        static void Main()
        {
            byte n = byte.Parse(Console.ReadLine());

            long snowballMaxValue = long.MinValue;
            long snowballMaxSnow = 0;
            long snowballMaxTime = 0;
            byte snowballMaxQuality = 0;

            for (int i = 0; i < n; i++)
            {
                long snowballSnow = long.Parse(Console.ReadLine());
                long snowballTime = long.Parse(Console.ReadLine());
                byte snowballQuality = byte.Parse(Console.ReadLine());

                long snowballValue = (long)(Math.Pow(snowballSnow / snowballTime, snowballQuality));

                if (snowballMaxValue < snowballValue)
                {
                    snowballMaxValue = snowballValue;
                    snowballMaxSnow = snowballSnow;
                    snowballMaxTime = snowballTime;
                    snowballMaxQuality = snowballQuality;
                }
            }
            Console.WriteLine($"{snowballMaxSnow} : {snowballMaxTime} = {snowballMaxValue} ({snowballMaxQuality})");
        }
    }
}
