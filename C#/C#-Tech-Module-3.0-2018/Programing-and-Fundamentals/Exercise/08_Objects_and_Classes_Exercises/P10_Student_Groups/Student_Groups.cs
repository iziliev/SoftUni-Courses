using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace P09_Student_Groups
{
    class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }

        public Student(string name, string email, DateTime registrationDate)
        {
            Name = name;
            Email = email;
            RegistrationDate = registrationDate;
        }
    }

    class Town
    {
        public string Name { get; set; }
        public int SeatsCount { get; set; }
        public List<Student> Students { get; set; }

        public Town(string name, int seatsCount)
        {
            Name = name;
            SeatsCount = seatsCount;
            Students = new List<Student>();
        }
    }

    class Student_Groups
    {
        static void Main()
        {
            string input = Console.ReadLine();

            List<Town> towns = new List<Town>();
            List<Student> studentsAll = new List<Student>();

            string cityName = "";

            while (input != "End")
            {
                if (input.Contains("seats"))
                {
                    string[] inputs = input
                        .Split("=>".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    string name = inputs[0].Trim();
                    cityName = name;
                    string[] second = inputs[1]
                        .Trim()
                        .Split(' ');

                    int seatsCount = int.Parse(second[0].Trim());

                    Town towsIn = new Town(name, seatsCount);

                    studentsAll = new List<Student>();

                    towns.Add(towsIn);
                }
                else
                {
                    string[] inputs = input
                        .Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    string name = inputs[0];
                    string email = inputs[1].Trim();
                    string date = inputs[2].Trim();
                    DateTime registrationDate = DateTime.ParseExact(date, "d-MMM-yyyy", CultureInfo.InvariantCulture);

                    Student students = new Student(name, email, registrationDate);

                    studentsAll.Add(students);

                    foreach (var item in towns.Where(x => x.Name == cityName))
                    {
                        item.Students.Add(students);
                    }
                }

                input = Console.ReadLine();
            }
            double groups = 0;
            
            foreach (var item in towns)
            {
                if (item.Students.Count > item.SeatsCount)
                {
                    groups += Math.Ceiling((double)item.Students.Count / item.SeatsCount);
                }
                else
                {
                    groups = 1;
                }
            }

            Console.WriteLine($"Created {groups} groups in {towns.Count} towns:");

            foreach (var item in towns.OrderBy(x => x.Name))
            {
                var broi = item.SeatsCount;

                List<string> list = new List<string>();
                foreach (var items in item.Students.OrderBy(x => x.RegistrationDate).ThenBy(x => x.Email))
                {
                    list.Add(items.Email);
                }

                while (list.Count > 0)
                {
                    int count = 0;
                    var result = new List<string>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (count != item.SeatsCount)
                        {
                            count++;
                            result.Add(list[i]);
                            list.Remove(list[i]);
                            if (list.Count == 0)
                            {
                                Console.Write($"{item.Name} => ");
                                Console.WriteLine(String.Join(", ", result));
                                continue;
                            }
                            i--;
                        }
                        else
                        {
                            Console.Write($"{item.Name} => ");
                            Console.WriteLine(String.Join(", ", result));
                            result.Clear();
                            count = 0;
                            i--;
                            continue;
                        }

                    }
                }
            }
        }
    }
}