using System;
using System.Linq;
using System.Text;

namespace P07_Multiply_Big_Number
{
    class Multiply_Big_Number
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            int num = 0;
            int reminder = 0;

            for (int i = input.Length - 1; i >= 0 ; i--)
            {
                num = int.Parse(input[i].ToString()) * n + reminder;

                if (num / 10 > 0)
                {
                    reminder = num / 10;
                    sb.Append(num % 10);
                }
                else
                {
                    reminder = 0;
                    sb.Append(num % 10);
                }
            }
            if (reminder>0)
            {
                sb.Append(reminder);
            }
            Console.WriteLine(string.Concat(sb.ToString().Reverse()));
        }
    }
}
