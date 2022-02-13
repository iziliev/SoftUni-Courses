using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Count_Uppercase_Words
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> func = UpperLetter();

            var upperWords = new List<string>();

            upperWords = input
                .Where(x => func(x))
                .ToList();

            Console.WriteLine(String.Join(Environment.NewLine, upperWords)); ;
        }

        private static Func<string, bool> UpperLetter()
        {
            return x => char.IsUpper(x[0]);
        }
    }
}
