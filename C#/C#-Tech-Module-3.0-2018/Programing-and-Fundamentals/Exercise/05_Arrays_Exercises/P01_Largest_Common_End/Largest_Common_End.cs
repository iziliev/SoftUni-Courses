using System;
using System.Linq;

namespace P01_Largest_Common_End
{
    class Largest_Common_End
    {
        static void Main()
        {
            string[] arrayOne = Console.ReadLine()
                .Split(' ');
            string[] arrayTwo = Console.ReadLine()
                .Split(' ');

            int minLenght = Math.Min(arrayOne.Length, arrayTwo.Length);
            int countLeft = 0;
            int countRight = 0;

            for (int i = 0; i < minLenght; i++)
            {
                if (arrayOne[i] == arrayTwo[i])
                {
                    countLeft++;
                }
            }
            Array.Reverse(arrayOne);
            Array.Reverse(arrayTwo);

            for (int i = 0; i < minLenght; i++)
            {
                if (arrayOne[i] == arrayTwo[i])
                {
                    countRight++;
                }
            }

            if (countLeft>countRight)
            {
                Console.WriteLine(countLeft);
            }
            else
            {
                Console.WriteLine(countRight);
            }
        }
    }
}