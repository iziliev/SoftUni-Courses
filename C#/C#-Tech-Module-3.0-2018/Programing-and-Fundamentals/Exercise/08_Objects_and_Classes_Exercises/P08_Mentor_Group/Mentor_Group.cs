using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace P08_Mentor_Group
{
    class Student
    {
        public string Name { get; set; }
        public List<string> Date { get; set; }
        public List<string> Comments { get; set; }

        public Student(string name)
        {
            Name = name;
            Date = new List<string>();
            Comments = new List<string>();
        }
    }

    class Mentor_Group
    {
        static void Main()
        {
            string input = Console.ReadLine();

            List<Student> group = new List<Student>();

            while (input != "end of dates")
            {
                string[] data = input
                    .Split(" ,".ToCharArray());

                string name = data[0];

                if (group.Any(x => x.Name == name))
                {
                    List<string> date = new List<string>();

                    for (int i = 1; i < data.Length; i++)
                    {
                        date.Add(data[i]);
                    }

                    foreach (var item in group.Where(x => x.Name == name))
                    {
                        foreach (var items in date)
                        {
                            item.Date.Add(items);
                        }
                    }
                }
                else
                {
                    Student students = new Student(name);
                    List<string> date = new List<string>();
                    List<string> comments = new List<string>();

                    for (int i = 1; i < data.Length; i++)
                    {
                        date.Add(data[i]);
                    }

                    students.Date = date;
                    students.Comments = comments;
                    group.Add(students);
                }


                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end of comments")
            {
                string[] data = input
                    .Split("-".ToCharArray());

                string name = data[0];

                if (!group.Any(x => x.Name == name))
                {
                    input = Console.ReadLine();
                    continue;
                }

                List<string> newComments = new List<string>();

                Student students = new Student(name);

                for (int i = 1; i < data.Length; i++)
                {
                    string newComm = data[i];
                    newComments.Add(newComm);
                }

                if (group.Any(x => x.Name == name))
                {
                    foreach (var item in group.Where(x => x.Name == name))
                    {
                        foreach (var items in newComments)
                        {
                            item.Comments.Add(items);
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var item in group.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{item.Name}");
                Console.WriteLine("Comments:");

                foreach (var items in item.Comments)
                {
                    Console.WriteLine($"- {items}");
                }
                Console.WriteLine("Dates attended:");

                foreach (var itemss in item.Date.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {itemss}");
                }
            }
        }
    }
}