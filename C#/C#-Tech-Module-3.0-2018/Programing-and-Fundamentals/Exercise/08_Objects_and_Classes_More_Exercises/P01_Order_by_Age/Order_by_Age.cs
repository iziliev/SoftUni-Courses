using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Order_by_Age
{
    class Ages
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public Ages(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }
    }

    class Order_by_Age
    {
        static void Main()
        {
            string input = Console.ReadLine();

            List<Ages> ageOfPeople = new List<Ages>();

            while (input !="End")
            {
                var data = input
                    .Split(' ');

                string name = data[0];
                string id = data[1];
                int age = int.Parse(data[2]);

                Ages ages = new Ages(name,id,age);

                ageOfPeople.Add(ages);

                input = Console.ReadLine();
            }

            foreach (var item in ageOfPeople.OrderBy(x=>x.Age))
            {
                Console.WriteLine($"{item.Name} with ID: {item.Id} is {item.Age} years old.");
            }
        }
    }
}
