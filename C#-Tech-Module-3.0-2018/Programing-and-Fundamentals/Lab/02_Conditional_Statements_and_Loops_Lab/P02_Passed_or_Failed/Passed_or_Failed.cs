namespace P02_Passed_or_Failed
{
    using System;
    class Passed_or_Failed
    {
        static void Main()
        {
            double grade = double.Parse(Console.ReadLine());

            if (grade > 2.99)
            {
                Console.WriteLine("Passed!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }
        }
    }
}
