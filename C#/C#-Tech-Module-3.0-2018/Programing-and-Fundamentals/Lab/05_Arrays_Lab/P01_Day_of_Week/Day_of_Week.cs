using System;

namespace P01_Day_of_Week
{
    class Day_of_Week
    {
        static void Main()
        {
            int day = int.Parse(Console.ReadLine());

            string[] nameOfDay = new string[]
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            if (day>=1 && day<=7)
            {
                Console.WriteLine(nameOfDay[day - 1]);
            }
            else
            {
                Console.WriteLine("Invalid Day!");
            }
            
        }
    }
}
