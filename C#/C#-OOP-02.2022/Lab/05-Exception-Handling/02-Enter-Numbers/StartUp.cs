using System;
using System.Collections.Generic;

namespace _02_Enter_Numbers
{
    public class StartUp
    {
        public static void Main()
        {

            var list = new List<int>();


            while (list.Count < 10)
            {
                try
                {
                    var end = Console.ReadLine();

                    if (list.Count == 0)
                    {
                        list.Add(ReadNumber(1, end));
                    }
                    else
                    {
                        list.Add(ReadNumber(list[list.Count - 1], end));
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(String.Join(", ", list));

        }

        private static int ReadNumber(int start, string end)
        {
            var numEnd = int.TryParse(end, out int result);

            if (!numEnd)
            {
                throw new ArgumentException($"Invalid Number!");
            }
            else if (start >= result)
            {
                throw new ArgumentException($"Your number is not in range ({start} - 100)");
            }

            return result;
        }
    }
}
