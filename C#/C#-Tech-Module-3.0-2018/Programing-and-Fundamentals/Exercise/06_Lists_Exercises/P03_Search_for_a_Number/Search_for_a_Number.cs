using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Search_for_a_Number
{
    class Search_for_a_Number
    {
        static void Main()
        {
            List<int> inputList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int[] inputArray = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            List<int> output = new List<int>();

            int takeNumbers = inputArray[0];
            int deleteNumbers = inputArray[1];
            int number = inputArray[2];

            output = inputList.Take(takeNumbers).ToList();
            output = output.Skip(deleteNumbers).ToList();
            bool check = true;

            for (int i = 0; i < output.Count; i++)
            {
                if (output[i] == number)
                {
                    Console.WriteLine("YES!");
                    return;
                }
            }
            Console.WriteLine("NO!");
        }
    }
}
