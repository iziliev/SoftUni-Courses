namespace P14_Integer_to_Hex_and_Binary
{
    using System;
    class Integer_to_Hex_and_Binary
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var hex = number.ToString("X").ToUpper();
            var binary = Convert.ToString(number,2).ToUpper();
            Console.WriteLine(hex);
            Console.WriteLine(binary);
        }
    }
}
