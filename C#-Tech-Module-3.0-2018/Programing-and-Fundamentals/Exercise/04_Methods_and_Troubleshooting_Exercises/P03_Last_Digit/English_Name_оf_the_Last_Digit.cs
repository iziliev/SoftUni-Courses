using System;

namespace P03_English_Name_оf_the_Last_Digit
{
    class English_Name_оf_the_Last_Digit
    {
        static void Main()
        {
            long number = long.Parse(Console.ReadLine());

            string lastDigt = LastDigit(Math.Abs(number));
            Console.WriteLine(lastDigt);
        }
        static string LastDigit(long number)
        {
            string last = String.Empty;
            long lastDigit = number % 10;

            switch (lastDigit)
            {
                case 0: last = "zero"; break;
                case 1: last = "one"; break;
                case 2: last = "two"; break;
                case 3: last = "three"; break;
                case 4: last = "four"; break;
                case 5: last = "five"; break;
                case 6: last = "six"; break;
                case 7: last = "seven"; break;
                case 8: last = "eight"; break;
                case 9: last = "nine"; break;
            }
            return last;
        }
    }
}