using System;
using System.Globalization;

namespace P02_Softuni_Coffee_Orders
{
    class Softuni_Coffee_Orders
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            decimal bill = 0M;

            for (int i = 0; i < n; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                int capsuleCount = int.Parse(Console.ReadLine());

                int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);

                decimal orderPrice = ((daysInMonth * capsuleCount) * pricePerCapsule);
                bill += orderPrice;
                Console.WriteLine($"The price for the coffee is: ${orderPrice:f2}");
            }
            Console.WriteLine($"Total: ${bill:f2}");
        }
    }
}
