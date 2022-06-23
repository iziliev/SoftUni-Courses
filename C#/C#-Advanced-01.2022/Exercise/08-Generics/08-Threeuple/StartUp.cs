using System;
using System.Linq;

namespace Threeuple
{
    public class StartUp
    {
        public static void Main()
        {
            var nameTown = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var name = string.Join(" ", nameTown.Take(2));
            var address = nameTown[2];
            var city = string.Join(" ", nameTown.Skip(3));
            var nameTownTuple = new CustomTuple<string, string, string>(name, address, city);

            var nameBeer = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var drunk = nameBeer[2] == "drunk" ?
                true : false;

            var nameBeerTuple = new CustomTuple<string, int, bool>(nameBeer[0], int.Parse(nameBeer[1]), drunk);

            var stringDouble = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var stringDoubleTuple = new CustomTuple<string, double, string>(stringDouble[0], double.Parse(stringDouble[1]), stringDouble[2]);

            Console.WriteLine(nameTownTuple);
            Console.WriteLine(nameBeerTuple);
            Console.WriteLine(stringDoubleTuple);
        }
    }
}
