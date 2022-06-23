using System;
using System.Collections.Generic;

namespace P02_Append_Lists
{
    class Append_Lists
    {
        static void Main()
        {
            List<string> output = new List<string>();

            string[] arrayInput = Console.ReadLine()
                .Split('|');

            for (int i = arrayInput.Length - 1; i >= 0; i--)
            {
                var nums = arrayInput[i].Trim().Split(' ');

                for (int k = 0; k < nums.Length; k++)
                {
                    if (!nums[k].Equals(string.Empty))
                    {
                        output.Add(nums[k]);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", output));
        }
    }
}
