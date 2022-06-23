using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class StartUp
    {
        static void Main()
        {
            var input = string.Empty;

            var students = new Dictionary<string, List<string>>();
            var languages = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "exam finished")
            {
                var data = input
                        .Split("-", StringSplitOptions.RemoveEmptyEntries);

                var userName = data[0];

                if (!input.Contains("banned"))
                {
                    var language = data[1];
                    var points = int.Parse(data[2]);

                    if (!students.ContainsKey(data[0]))
                    {
                        students[userName] = new List<string>() { language, points.ToString() };
                    }
                    else
                    {
                        if (int.Parse(students[userName][1]) < points)
                        {
                            students[userName][0] = language;
                            students[userName][1] = points.ToString();
                        }
                    }

                    if (!languages.ContainsKey(language))
                    {
                        languages[language] = 0;
                    }

                    languages[language]++;
                }
                else
                {
                    foreach (var item in students)
                    {
                        if (item.Key == userName)
                        {
                            students[userName][1] = "banned";

                        }
                    }
                }
            }

            var notBannedStudents = students
                .Where(x => x.Value[1] != "banned")
                .OrderByDescending(x => x.Value[1])
                .ThenBy(x => x.Key);

            Console.WriteLine("Results:");

            foreach (var item in notBannedStudents)
            {
                Console.WriteLine($"{item.Key} | {item.Value[1]}");
            }

            Console.WriteLine("Submissions:");

            foreach (var item in languages.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
