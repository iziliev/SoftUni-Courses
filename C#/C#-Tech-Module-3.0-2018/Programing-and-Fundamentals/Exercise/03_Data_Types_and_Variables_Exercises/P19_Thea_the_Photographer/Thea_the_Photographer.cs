namespace P19_Thea_the_Photographer
{
    using System;
    class Thea_the_Photographer
    {
        static void Main()
        {
            long pictures = long.Parse(Console.ReadLine());
            long secondPerPicture = long.Parse(Console.ReadLine());
            long filterPercent = long.Parse(Console.ReadLine());
            long uploadTimePerPicture = long.Parse(Console.ReadLine());


            long filterSeconds = pictures * secondPerPicture;
            long filterTips = (long)Math.Ceiling(filterPercent * pictures / 100.0);
            long uploadSeconsd = filterTips * uploadTimePerPicture;
            long totalSeconds = filterSeconds + uploadSeconsd;

            TimeSpan time = TimeSpan.FromSeconds(totalSeconds);
            string result = time.ToString(@"d\:hh\:mm\:ss");
            Console.WriteLine(result);
        }
    }
}
