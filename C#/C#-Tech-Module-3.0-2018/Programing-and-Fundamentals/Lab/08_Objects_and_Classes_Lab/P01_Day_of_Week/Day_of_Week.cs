using System;
using System.Globalization;

namespace P01_Day_of_Week
{
    class Day_of_Week
    {
        static void Main()
        {
            string input = Console.ReadLine();

            DateTime date = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var day = date.DayOfWeek;

            Console.WriteLine(day);
        }
    }
}
