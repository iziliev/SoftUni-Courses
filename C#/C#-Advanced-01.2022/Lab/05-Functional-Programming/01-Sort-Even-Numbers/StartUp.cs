using System;
using System.Linq;

namespace _01_Sort_Even_Numbers
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x=>x%2==0)
                .OrderBy(x=>x)
                .ToArray();

            Console.WriteLine(String.Join(", ",input)); 
        }
    }
}
