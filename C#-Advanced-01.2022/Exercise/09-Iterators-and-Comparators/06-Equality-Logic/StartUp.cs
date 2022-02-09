using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var sortSet = new SortedSet<Person>();
            var hashSet = new HashSet<Person>();

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var person = new Person(args[0], int.Parse(args[1]));

                sortSet.Add(person);
                hashSet.Add(person);
            }

            Console.WriteLine(sortSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
