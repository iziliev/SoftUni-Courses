using System;
using System.Linq;

namespace CustomComparator
{
    public class StartUp
    {
        public static void Main()
        {
            var number = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> func = (num1, num2)
                  => (num1 % 2 == 0 && num2 % 2 != 0) ? -1 :
                  (num1 % 2 != 0 && num2 % 2 == 0) ? 1 :
                  num1.CompareTo(num2);

            Array.Sort(number, new Comparison<int>(func));

            Console.WriteLine(String.Join(" ", number));

        }
    }
}
