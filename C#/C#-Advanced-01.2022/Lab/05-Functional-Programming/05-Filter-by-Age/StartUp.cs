using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Filter_by_Age
{
    public class StartUp
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var peoples = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                var people = new Person();
                people.Name = input[0];
                people.Age = int.Parse(input[1]);
                peoples.Add(people);
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            Func<Person, bool> filter;

            if (condition == "older")
            {
                filter = p => p.Age >= age;
            }
            else
            {
                filter = p => p.Age < age;
            }

            var filtredPerson = peoples.Where(filter);

            Func<Person, string> print;

            if (format == "name age")
            {
                print = x => x.Name + " - " + x.Age;
            }
            else if (format == "name")
            {
                print = x => x.Name;
            }
            else
            {
                print = x => x.Age.ToString();
            }

            var printedPeople = filtredPerson
                .Select(print);

            foreach (var item in printedPeople)
            {
                Console.WriteLine(item);
            }
        }
    }
}
