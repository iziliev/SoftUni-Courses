using System;
using System.Linq;

namespace Tuple
{
    public class StartUp
    {
        public static void Main()
        {
            var nameTown = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var name = string.Join(" ",nameTown.Take(2));
            var city = string.Join(" ", nameTown.Skip(2));
            var nameTownTuple = new CustomTuple<string,string>(name,city);
            
            var nameBeer = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var nameBeerTuple = new CustomTuple<string, int>(nameBeer[0], int.Parse(nameBeer[1]));

            var intDouble = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var intDoubleTuple = new CustomTuple<int, double>(int.Parse(intDouble[0]), double.Parse(intDouble[1]));

            Console.WriteLine(nameTownTuple);
            Console.WriteLine(nameBeerTuple);
            Console.WriteLine(intDoubleTuple);
        }
    }
}
