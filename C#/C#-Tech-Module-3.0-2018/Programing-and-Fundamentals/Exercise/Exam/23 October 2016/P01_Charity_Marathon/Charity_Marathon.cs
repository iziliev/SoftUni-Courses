using System;

namespace P01_Charity_Marathon
{
    class Charity_Marathon
    {
        static void Main()
        {
            long lenghtMaratonDays = long.Parse(Console.ReadLine());
            long runners = long.Parse(Console.ReadLine());
            int laps = int.Parse(Console.ReadLine());
            long lenghtOfTracks = long.Parse(Console.ReadLine());
            int trackCapacity = int.Parse(Console.ReadLine());
            decimal moneyPerKm = decimal.Parse(Console.ReadLine());

            long maxRunners = trackCapacity * lenghtMaratonDays;
            runners = Math.Min(maxRunners, runners);

            long totalMeters = runners * laps * lenghtOfTracks;
            long totalKm = totalMeters / 1000;
            decimal sum = totalKm * moneyPerKm;


            Console.WriteLine($"Money raised: {sum:f2}");
        }
    }
}
