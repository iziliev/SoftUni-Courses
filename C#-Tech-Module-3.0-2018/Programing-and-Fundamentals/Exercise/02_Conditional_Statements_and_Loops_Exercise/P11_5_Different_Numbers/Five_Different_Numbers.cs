namespace P11_Five_Different_Numbers
{
    using System;
    class Five_Different_Numbers
    {
        static void Main()
        {
            int numberA = int.Parse(Console.ReadLine());
            int numberB = int.Parse(Console.ReadLine());

            int sum = numberB - numberA;

            if (sum >= 5)
            {
                for (int i = numberA; i <= numberB; i++)
                {
                    for (int j = i+1; j < numberB; j++)
                    {
                        for (int k = j+1; k < numberB; k++)
                        {
                            for (int l = k+1; l < numberB; l++)
                            {
                                for (int m = l+1; m <= numberB; m++)
                                {
                                    Console.WriteLine($"{i} {j} {k} {l} {m}");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
