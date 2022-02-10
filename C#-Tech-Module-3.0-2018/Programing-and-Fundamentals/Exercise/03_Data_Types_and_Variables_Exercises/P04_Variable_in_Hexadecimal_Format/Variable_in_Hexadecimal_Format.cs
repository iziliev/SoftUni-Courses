using System;

namespace P04_Variable_in_Hexadecimal_Format
{
    class Variable_in_Hexadecimal_Format
    {
        static void Main()
        {
            string number = Console.ReadLine();
            var result = Convert.ToInt32(number, 16);
            Console.WriteLine(result);
        }
    }
}
