using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_Predicate_for_Names
{
    public class StartUp
    {
        public static void Main()
        {
            var nameLenght = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Predicate<string> predicate = name => name.Length <= nameLenght;

            Func<List<string>, Predicate<string>, List<string>> filtredName
                = (names, predicate) =>
                {
                    var tempList = new List<string>();

                    foreach (var item in names)
                    {
                        if (predicate(item))
                        {
                            tempList.Add(item);
                        }
                    }
                    return tempList;
                };

            var nameByCriteria = filtredName(names,predicate);

            Console.WriteLine(String.Join(Environment.NewLine,nameByCriteria));
        }
    }
}
