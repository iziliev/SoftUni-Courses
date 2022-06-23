namespace P03_Back_in_30_Minutes
{
    using System;
    class Back_in_30_Minutes
    {
        static void Main()
        {
            int hour = int.Parse(Console.ReadLine());
            int minute = int.Parse(Console.ReadLine());

            int sumMinutes = hour * 60 + minute + 30;

            int backHour = sumMinutes / 60;
            int backMinute = sumMinutes % 60;

            if (backHour>=24)
            {
                Console.WriteLine($"{backHour-24}:{backMinute:D2}");
            }
            else
            {
                Console.WriteLine($"{backHour}:{backMinute:D2}");
            }
        }
    }
}
