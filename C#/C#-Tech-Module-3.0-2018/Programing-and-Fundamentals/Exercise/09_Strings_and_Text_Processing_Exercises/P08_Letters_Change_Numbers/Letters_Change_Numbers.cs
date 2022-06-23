using System;
using System.Linq;

namespace P08_Letters_Change_Numbers
{
    class Letters_Change_Numbers
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(" \t".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string strInput = input[i];
                char letterBeforeNumber = strInput[0];
                char letterAfterNumber = strInput[strInput.Length-1];

                var number = int.Parse(string.Concat(strInput.Skip(1).Take(strInput.Length - 2)));
                
                if (char.IsUpper(letterBeforeNumber))
                {
                    number /= letterBeforeNumber-64;
                }
                else if (char.IsLower(letterBeforeNumber))
                {
                    number *= letterBeforeNumber-96;
                }
                if (char.IsUpper(letterAfterNumber))
                {
                    number -= letterAfterNumber-64;
                }
                else if (char.IsLower(letterAfterNumber))
                {
                    number += letterAfterNumber-96;
                }
                sum += number;
            }
            Console.WriteLine($"{sum:F2}");
        }
    }
}
