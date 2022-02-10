using System;
using System.Linq;

namespace P07_Sum_Arrays
{
    class Sum_Arrays
    {
        static void Main()
        {
            int[] arrayOne = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int[] arrayTwo = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int maxLenght = Math.Max(arrayOne.Length, arrayTwo.Length);

            int[] outputArray = new int[maxLenght];
            int[] newArrayOne = new int[maxLenght];
            int[] newArrayTwo = new int[maxLenght];

            if (arrayOne.Length < arrayTwo.Length)
            {
                int countOne = 0;
                for (int i = 0; i < maxLenght; i++)
                {
                    if (countOne >= arrayOne.Length)
                    {
                        countOne = 0;
                        i--;
                    }
                    else
                    {
                        newArrayOne[i] = arrayOne[countOne];
                        countOne++;
                    }
                }
                for (int i = 0; i < arrayTwo.Length; i++)
                {
                    newArrayTwo[i] = arrayTwo[i];
                }
            }
            else if (arrayOne.Length > arrayTwo.Length)
            {
                int countOne = 0;
                for (int i = 0; i < maxLenght; i++)
                {
                    if(countOne >= arrayTwo.Length)
                    {
                        countOne = 0;
                        i--;
                    }
                    else
                    {
                        newArrayTwo[i] = arrayTwo[countOne];
                        countOne++;
                    }
                }
                for (int i = 0; i < arrayOne.Length; i++)
                {
                    newArrayOne[i] = arrayOne[i];
                }
            }

            for (int i = 0; i < outputArray.Length; i++)
            {
                outputArray[i] = newArrayOne[i] + newArrayTwo[i];
            }
            Console.WriteLine(String.Join(" ",outputArray));
        }
    }
}