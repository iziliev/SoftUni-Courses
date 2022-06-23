using System;

namespace _02_Knights_of_Honor
{
    public class StartUp
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = name =>Console.WriteLine($"Sir {name}");

            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}
