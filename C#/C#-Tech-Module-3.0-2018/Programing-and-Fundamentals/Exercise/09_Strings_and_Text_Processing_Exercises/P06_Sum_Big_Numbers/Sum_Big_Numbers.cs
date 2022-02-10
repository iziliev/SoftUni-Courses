using System;
using System.Linq;
using System.Text;

namespace P06_Sum_Big_Numbers
{
    class Sum_Big_Numbers
    {
        static void Main()
        {
            string numOne = Console.ReadLine();
            string numTwo = Console.ReadLine();

            if (numOne.Length < numTwo.Length)
            {
                numOne = numOne.PadLeft(numTwo.Length, '0');
            }
            else
            {
                numTwo = numTwo.PadLeft(numOne.Length, '0');
            }

            StringBuilder sb = new StringBuilder();
            int sum = 0;
            int reminder = 0;
            for (int i = numOne.Length-1; i >= 0; i--)
            {
                sum = numOne[i]-48 + numTwo[i]-48 + reminder;
                if (sum>9)
                {
                    reminder = 1;
                    sum %= 10;
                }
                else
                {
                    reminder = 0;
                }
                sb.Append(sum);
            }
            if (reminder==1)
            {
                Console.Write(reminder);
            }
            Console.WriteLine(string.Concat(sb.ToString().TrimEnd('0').Reverse()));
        }
    }
}
