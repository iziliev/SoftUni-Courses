namespace P09_Refactor_Special_Numbers
{
    using System;
    class Refactor_Special_Numbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            bool check = false;

            for (int i = 1; i <= n; i++)
            {
                int number = i;

                while (number > 0)
                {
                    sum += number % 10;
                    number = number / 10;
                }
                if (sum == 5 || sum == 7 || sum == 11)
                {
                    check = true;
                    Console.WriteLine($"{i} -> {check}");
                }
                check = false;
                Console.WriteLine($"{i} -> {check}");
                sum = 0;
            }
        }
    }
}
