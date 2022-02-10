using System;
using System.Text;

namespace P04_Character_Multiplier
{
    class Character_Multiplier
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(' ');
            var result = SumOfCharOfStrings(input);

            Console.WriteLine(result);
        }

        public static int SumOfCharOfStrings(string[] input)
        {
            string str1 = input[0];
            string str2 = input[1];
            int maxCount = Math.Max(str1.Length, str2.Length);
            int[] strOne = new int[maxCount];
            int[] strTwo = new int[maxCount];

            for (int i = 0; i < maxCount; i++)
            {
                if (i <= str1.Length - 1)
                {
                    strOne[i] = str1[i];
                }
                else
                {
                    strOne[i] = 1;
                }
                if (i <= str2.Length - 1)
                {
                    strTwo[i] = str2[i];
                }
                else
                {
                    strTwo[i] = 1;
                }
            }

            int minCount = Math.Min(strOne.Length, strTwo.Length);
            int sum = 0;
            for (int i = 0; i < minCount; i++)
            {
                sum += strOne[i] * strTwo[i];
            }
            return sum;
        }
    }
}
