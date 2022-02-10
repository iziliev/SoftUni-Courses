using System;

namespace P05_Diamond
{
    class Diamond
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            if (n <= 2)
            {
                Console.WriteLine("{0}", new string('*', n));
                return;
            }
            else
            {
                if (n % 2 == 0)
                {
                    Console.WriteLine("{0}{1}{0}",
                        new string('-', (n - 2) / 2),
                        new string('*', 2));

                    for (int i = 0; i < (n - 3) / 2; i++)
                    {
                        Console.WriteLine("{0}*{1}--{1}*{0}",
                            new string('-', (n - 4 - i) / 2),
                            new string('-', i));
                    }
                    Console.WriteLine("*{0}*",
                        new string('-', n - 2));
                    for (int i = (n - 3) / 2 - 1; i > 0; i--)
                    {
                        Console.WriteLine("{0}*{1}--{1}*{0}",
                            new string('-', (n - 4 - i) / 2),
                            new string('-', i));
                    }
                    Console.WriteLine("{0}{1}{0}",
                        new string('-', (n - 2) / 2),
                        new string('*', 2));
                }
                else
                {
                    Console.WriteLine("{0}{1}{0}",
                        new string('-', (n - 1) / 2),
                        new string('*', 1));

                    for (int i = 0; i < (n - 3) / 2; i++)
                    {
                        Console.WriteLine("{0}*{1}-{1}*{0}",
                            new string('-', (n - 3 - i-i) / 2),
                            new string('-', i));
                    }
                    Console.WriteLine("*{0}*",
                        new string('-', n - 2));
                    for (int i = (n - 3) / 2 - 1; i > 0; i--)
                    {
                        Console.WriteLine("{0}*{1}-{1}*{0}",
                            new string('-', (n - 3 - i-i) / 2),
                            new string('-', i));
                    }
                    Console.WriteLine("{0}{1}{0}",
                        new string('-', (n - 1) / 2),
                        new string('*', 1));
                }
            }
        }
    }
}
