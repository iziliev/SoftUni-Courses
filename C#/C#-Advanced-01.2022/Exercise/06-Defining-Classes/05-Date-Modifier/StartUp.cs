using System;

namespace DateModifier
{
    public class StartUp
    {
        public static void Main()
        {
            var startInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var endInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var startDate = new DateTime(int.Parse(startInput[0]), int.Parse(startInput[1]), int.Parse(startInput[2]));
            var endDate = new DateTime(int.Parse(endInput[0]), int.Parse(endInput[1]), int.Parse(endInput[2]));

            var date = new DateModifier(startDate, endDate);

            var days = date.CalculateDays();

            Console.WriteLine(days);
        }
    }
}
