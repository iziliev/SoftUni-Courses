using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Remove_Negatives_and_Reverse
{
    class Remove_Negatives_and_Reverse
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            List<int> possitiveNumbers = new List<int>();
            bool check = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i]>0)
                {
                    possitiveNumbers.Add(numbers[i]);
                    check = true;
                }
            }
            
            if (check==true)
            {
                possitiveNumbers.Reverse();
                Console.WriteLine(string.Join(" ",possitiveNumbers));
            }
            else
            {
                Console.WriteLine("empty");
            }

        }
    }
}
