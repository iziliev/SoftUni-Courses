using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_TriFunction
{
    public class StartUp
    {
        public static void Main()
        {
            var criteriaASCII = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, int, bool> getASCII = (name, criteriaASCII) => name.Sum(x => x) >= criteriaASCII;

            Func<List<string>, int, Func<string, int, bool>, List<string>> getName
                = (names, n, func) => names.Where(x => func(x, n)).ToList();

            Console.WriteLine(getName(names,criteriaASCII,getASCII).FirstOrDefault());
        }
    }
}