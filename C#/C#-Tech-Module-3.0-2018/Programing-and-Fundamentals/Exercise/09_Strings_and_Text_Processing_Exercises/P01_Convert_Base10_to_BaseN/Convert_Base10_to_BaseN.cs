using System;
using System.Linq;
using System.Numerics;
using System.Text;

namespace P01_Convert_Base10_to_BaseN
{
    class Convert_Base10_to_BaseN
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(' ');

            int baseNumber = int.Parse(input[0]);
            BigInteger number = BigInteger.Parse(input[1]);

            StringBuilder sb = new StringBuilder();

            while (number > 0)
            {
                sb.Append(number % baseNumber);
                number /= baseNumber;
            }
            Console.WriteLine(string.Concat(sb.ToString().Reverse()));
        }
    }
}
