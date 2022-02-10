namespace P02_Number_Checker
{
    using System;
    class Number_Checker
    {
        static void Main()
        {
            string number = Console.ReadLine();

            if (number.Contains("."))
            {
                Console.WriteLine("floating-point");
            }
            else
            {
                Console.WriteLine("integer");
            }
        }
    }
}
