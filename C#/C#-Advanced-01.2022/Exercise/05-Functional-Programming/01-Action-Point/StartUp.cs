using System;

namespace _01_Action_Point
{
    public class StartUp
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> printNames = names => Console.WriteLine(string.Join(Environment.NewLine,names));

            printNames(names);
        }
    }
}
