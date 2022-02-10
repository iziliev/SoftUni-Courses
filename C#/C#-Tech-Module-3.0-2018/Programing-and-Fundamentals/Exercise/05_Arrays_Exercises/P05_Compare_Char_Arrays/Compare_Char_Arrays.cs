using System;
using System.Linq;

namespace P05_Compare_Char_Arrays
{
    class Compare_Char_Arrays
    {
        static void Main()
        {
            char[] arrayOne = Console.ReadLine()
                .Split(' ')
                .Select(char.Parse)
                .ToArray();
            char[] arrayTwo = Console.ReadLine()
                .Split(' ')
                .Select(char.Parse)
                .ToArray();

            int minLenght = Math.Min(arrayOne.Length, arrayTwo.Length);


            for (int i = 0; i < minLenght; i++)
            {
                if (arrayOne[i] <= arrayTwo[i] && arrayOne.Length <= arrayTwo.Length)
                {
                    Console.WriteLine(string.Join("", arrayOne));
                    Console.WriteLine(string.Join("", arrayTwo));
                    break;
                }
                else
                {
                    Console.WriteLine(string.Join("", arrayTwo));
                    Console.WriteLine(string.Join("", arrayOne));
                    break;
                }
            }

        }
    }
}
