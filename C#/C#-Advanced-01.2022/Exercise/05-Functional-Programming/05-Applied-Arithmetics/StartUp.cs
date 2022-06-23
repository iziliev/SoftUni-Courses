using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Applied_Arithmetics
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Action<List<int>> add = numbers =>
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i] += 1;
                }
            };
            Action<List<int>> multiply = numbers =>
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i] *= 2;
                }
            };
            Action<List<int>> subtract = numbers =>
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i] -= 1;
                }
            };
            Action<List<int>> print = numbers => Console.WriteLine(String.Join(" ",numbers));
           
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                switch (input)
                {
                    case "add":
                        add(numbers);
                        break;
                    case "multiply":
                        multiply(numbers);
                        break;
                    case "subtract":
                        subtract(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
