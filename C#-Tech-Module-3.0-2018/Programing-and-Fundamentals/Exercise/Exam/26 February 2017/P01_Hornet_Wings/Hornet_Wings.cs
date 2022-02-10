using System;

namespace P01_Hornet_Wings
{
    class Hornet_Wings
    {
        static void Main()
        {
            int wingFlaps = int.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            int flapsBeforeStop = int.Parse(Console.ReadLine());

            double distance = (wingFlaps / 1000) * distanceInMeters;

            long hornetFlaps = wingFlaps / 100;
            long rest = ((wingFlaps / flapsBeforeStop) * 5) + hornetFlaps;

            Console.WriteLine($"{distance:f2} m.");
            Console.WriteLine($"{rest} s.");
        }
    }
}
