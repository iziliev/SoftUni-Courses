using System;

namespace P01_Thea_the_Photographer
{
    class Thea_the_Photographer
    {
        static void Main()
        {
            long amountPicture = long.Parse(Console.ReadLine());
            long filterTime = long.Parse(Console.ReadLine());
            long filterFactor = long.Parse(Console.ReadLine());
            long uploadTime = long.Parse(Console.ReadLine());

            long filterSec = amountPicture * filterTime;
            long filterPictures = (long)Math.Ceiling(amountPicture * filterFactor / 100.0);
            long upTime = filterPictures * uploadTime;
            long all = filterSec + upTime;

            TimeSpan time = TimeSpan.FromSeconds(all);
            string result = time.ToString(@"d\:hh\:mm\:ss");
            Console.WriteLine(result);
        }
    }
}
