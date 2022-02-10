namespace P10_Multiplication_Table_2_0
{
    using System;
    class Multiplication_Table_2_0
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int fromNumber = int.Parse(Console.ReadLine());
            int sum = 0;

            if (fromNumber<=10)
            {
                for (int i = fromNumber; i <= 10; i++)
                {
                    sum = number * i;
                    Console.WriteLine($"{number} X {i} = {sum}");
                }
            }
            else
            {
                sum = number * fromNumber;
                Console.WriteLine($"{number} X {fromNumber} = {sum}");
            }
        }
    }
}
