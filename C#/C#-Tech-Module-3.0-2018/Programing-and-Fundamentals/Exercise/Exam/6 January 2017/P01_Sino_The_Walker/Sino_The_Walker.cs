using System;

namespace P01_Sino_The_Walker
{
    class Sino_The_Walker
    {
        static void Main()
        {
            string[] time = Console.ReadLine()
                .Split(':');
            int numberSteps = int.Parse(Console.ReadLine());
            int timeInSeconds = int.Parse(Console.ReadLine());

            ulong timeToHomeSec = (ulong)(numberSteps) * (ulong)(timeInSeconds);

            ulong hours = ulong.Parse(time[0]);
            ulong minutes = ulong.Parse(time[1]);
            ulong seconds = ulong.Parse(time[2]);

            ulong allTimeInSec = seconds + minutes * 60 + hours * 60 * 60;

            ulong sumSeconds = allTimeInSec + timeToHomeSec;

            ulong secondsResult = sumSeconds % 60;
            ulong minutesResult = sumSeconds / 60 % 60;
            ulong hoursResult = sumSeconds / 3600 % 24;

            if (secondsResult > 59)
            {
                secondsResult -= 60;
                minutesResult += 1;
            }
            if (minutesResult > 59)
            {
                minutesResult -= 60;
                hoursResult += 1;
            }

            if (hoursResult > 23)
            {
                hoursResult -= 24;
            }

            Console.WriteLine($"Time Arrival: {hoursResult:D2}:{minutesResult:D2}:{secondsResult:D2}");
        }
    }
}
