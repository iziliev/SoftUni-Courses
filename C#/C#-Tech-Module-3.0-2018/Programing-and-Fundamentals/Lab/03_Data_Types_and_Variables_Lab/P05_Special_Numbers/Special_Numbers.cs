namespace P05_Special_Numbers
{
    using System;
    class Special_Numbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i < n; i++)
            {
                int firstDigit = i / 10;
                int secondDigit = i % 10;

                if (firstDigit+secondDigit == 5 ||
                    firstDigit + secondDigit == 7 ||
                    firstDigit + secondDigit == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}
