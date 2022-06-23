namespace P09_Multiplication_Table
{
    using System;
    class Multiplication_Table
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= 10; i++)
            {
                sum = number*i;
                Console.WriteLine($"{number} X {i} = {sum}");
            }
        }
    }
}
