namespace P08_House_Builder
{
    using System;
    class House_Builder
    {
        static void Main()
        {
            long num1 = long.Parse(Console.ReadLine());
            long num2 = long.Parse(Console.ReadLine());

            long sum = 0;
            if (num1<num2)
            {
                sum = num1 * 4 + num2 * 10;
            }
            else
            {
                sum = num1 * 10 + num2 * 4;
            }
            Console.WriteLine(sum);
        }
    }
}
