using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        public static void Main()
        {
            var persons = new List<Person>();

            var input = string.Empty;
            while ((input= Console.ReadLine())!="END")
            {
                var args = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var person = new Person(args[0], int.Parse(args[1]), args[2]);
                persons.Add(person);
            }

            var personCompare = persons[int.Parse(Console.ReadLine())-1];

            var equalPerson = 0;
            var notEqual = 0;

            foreach (var item in persons)
            {
                if (personCompare.CompareTo(item)==0)
                {
                    equalPerson++;
                }
                else
                {
                    notEqual++;
                }
            }

            var result = equalPerson != 1 ? $"{equalPerson} {notEqual} {equalPerson + notEqual}" : "No maches";

            Console.WriteLine(result);
        }
    }
}
