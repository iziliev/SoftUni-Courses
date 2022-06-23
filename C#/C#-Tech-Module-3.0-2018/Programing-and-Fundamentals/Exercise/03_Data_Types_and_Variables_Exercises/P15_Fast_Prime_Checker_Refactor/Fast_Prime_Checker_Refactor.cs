namespace P15_Fast_Prime_Checker_Refactor
{
    using System;
    class Fast_Prime_Checker_Refactor
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 2; i <= number; i++)
            {
                bool check = true;

                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        check = false;
                        break;
                    }
                }
                Console.WriteLine($"{i} -> {check}");
            }
        }
    }
}
