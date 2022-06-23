using System;
using System.Numerics;
using System.Text;

namespace P01_Convert_BaseN_to_Base10
{
    class Convert_BaseN_to_Base10
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split();

            int baseNumber = int.Parse(input[0]);
            string numbers = input[1];

            BigInteger sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                string num = numbers[numbers.Length - 1 - i].ToString();
                int pow = (int)Math.Pow(baseNumber, i);
                sum += int.Parse(num) * pow;
            }
            Console.WriteLine(sum);
        }
    }
}
