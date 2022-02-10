using System;

namespace P04_Numbers_in_Reversed_Order
{
    class Numbers_in_Reversed_Order
    {
        static void Main()
        {
            string number = Console.ReadLine();
            var word = PrintDigits(number);
            Console.WriteLine(word);
        }
        static string PrintDigits(string number)
        {
            string result = string.Empty;
            for (int i = number.Length-1; i >= 0; i--)
            {
                result += number[i];
            }
            return result;
        }
    }
}
