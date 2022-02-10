using System;
using System.Linq;

namespace P04_Triple_Sum
{
    class Triple_Sum
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            bool check = false;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    int sum = array[i] + array[j];
                    if (array.Contains(sum))
                    {
                        Console.WriteLine($"{array[i]} + {array[j]} = {sum}");
                        check = true;
                    }
                    
                }
            }
            if (check == false)
            {
                Console.WriteLine("No");
            }
        }
    }
}
