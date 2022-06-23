using System;
using System.Collections.Generic;
using System.Globalization;

namespace P01_Count_Working_Days
{
    class Count_Working_Days
    {
        static void Main()
        {
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            int coutWorkDays = 0;

            for (var i = startDate; i <= endDate; i=i.AddDays(1))
            {
                if (!i.DayOfWeek.Equals(DayOfWeek.Saturday) && 
                    !i.DayOfWeek.Equals(DayOfWeek.Sunday) &&
                    !(i.Month == 1 && i.Day == 1) &&
                    !(i.Month == 3 && i.Day == 3) &&
                    !(i.Month == 5 && i.Day == 1) &&
                    !(i.Month == 5 && i.Day == 6) &&
                    !(i.Month == 5 && i.Day == 24) &&
                    !(i.Month == 9 && i.Day == 6) &&
                    !(i.Month == 9 && i.Day == 22) &&
                    !(i.Month == 11 && i.Day == 1) &&
                    !(i.Month == 12 && i.Day == 25) &&
                    !(i.Month == 12 && i.Day == 26) &&
                    !(i.Month == 12 && i.Day == 24))

                {
                    coutWorkDays++;
                }
            }
            Console.WriteLine(coutWorkDays);
        }
    }
}
