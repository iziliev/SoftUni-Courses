using System;
using System.Linq;

namespace P08_Most_Frequent_Number
{
    class Most_Frequent_Number
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int count = 1;
            int maxCount = 0;
            int number = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }
                    if (maxCount < count)
                    {
                        maxCount = count;
                        number = array[i];
                    }
                }
            }
            Console.WriteLine(number);
        }
    }
}
