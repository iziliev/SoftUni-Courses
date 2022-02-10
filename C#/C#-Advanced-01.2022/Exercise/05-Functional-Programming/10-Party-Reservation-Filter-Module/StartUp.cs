using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_Party_Reservation_Filter_Module
{
    public class StartUp
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var dict = new Dictionary<string, Predicate<string>>();

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "Print")
            {
                var commandArgs = input
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                var key = $"{commandArgs[1]}_{commandArgs[2]}";
                
                Predicate<string> getPredicate = GetPredicate(commandArgs[1], commandArgs[2]);

                if (commandArgs[0]=="Add filter")
                {
                    dict.Add(key, getPredicate);
                }
                else if (commandArgs[0]=="Remove filter")
                {
                    dict.Remove(key);
                }
            }

            foreach (var (key,predicate) in dict)
            {
                names.RemoveAll(x => predicate(x));
            }

            Console.WriteLine(String.Join(" ",names));

        }

        private static Predicate<string> GetPredicate(string command, string param)
        {
            if (command=="Starts with")
            {
                return x => x.StartsWith(param);
            }
            if (command == "Ends with")
            {
                return x => x.EndsWith(param);
            }
            if (command == "Lenght")
            {
                return x => x.Length == int.Parse(param);
            }
            return x => x.Contains(param);
        }
    }
}
