using System;
using System.Linq;

namespace _03_Custom_Min_Function
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            
            Func<int[], int> minNumber = (x) =>
             {
                 var tempNum = int.MaxValue;

                 for (int i = 0; i < numbers.Length; i++)
                 {
                     if (tempNum>numbers[i])
                     {
                         tempNum = numbers[i];
                     }
                 }
                 return tempNum;
             };

            Console.Write(minNumber(numbers));
        }
    }
}
