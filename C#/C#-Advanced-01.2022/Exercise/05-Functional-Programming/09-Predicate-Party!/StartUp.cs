using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_Predicate_Party_
{
    public class StartUp
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "Party!")
            {
                var commandArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Predicate<string> getNames = GetNames(commandArgs[1], commandArgs[2]);

                if (commandArgs[0] == "Remove")
                {
                    names.RemoveAll(x => getNames(x));
                }
                else if (commandArgs[0]== "Double")
                {
                    var tempList = names.FindAll(x => getNames(x));

                    if (!tempList.Any())
                    {
                        continue;
                    }
                    var index = names.FindIndex(x => getNames(x));
                    names.InsertRange(index, tempList);
                }
            }

            if (!names.Any())
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Action<List<string>> print = names=>Console.WriteLine(string.Join(", ",names) + " are going to the party!");
                print(names);
            }

        }

        private static Predicate<string> GetNames(string command, string param)
        {
            if (command=="StartsWith")
            {
                return x => x.StartsWith(param);
            }
            if (command=="EndsWith")
            {
                return x => x.EndsWith(param);
            }
            return x => x.Length == int.Parse(param);
        }
    }
}
