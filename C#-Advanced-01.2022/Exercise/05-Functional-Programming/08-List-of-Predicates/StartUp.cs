using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_List_of_Predicates
{
    public class StartUp
    {
        public static void Main()
        {
            var range = int.Parse(Console.ReadLine());

            var numbers = new List<int>();

            FillNumbers(range, numbers);

            var deviders = new HashSet<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Func<List<int>, HashSet<int>, List<int>> func
                = (numbers, deviders)
                =>
                {
                    var tempList = new List<int>();
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        tempList.Add(numbers[i]);
                    }

                    foreach (var item in deviders)
                    {
                        Predicate<int> predicate = x => x % item == 0;
                        tempList = tempList.FindAll(x=>predicate(x));
                    }

                    return tempList;
                };

            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));

            print(func(numbers, deviders));
        }

        private static void FillNumbers(int range, List<int> numbers)
        {
            for (int i = 0; i < range; i++)
            {
                numbers.Add(i + 1);
            }
        }
    }
}
