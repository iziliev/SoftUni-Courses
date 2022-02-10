using System;
using System.Numerics;

namespace P01_Anonymous_Downsite
{
    class Anonymous_Downsite
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger key = BigInteger.Parse(Console.ReadLine());

            decimal siteLost = 0;
            BigInteger pow = 0;

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ');

                string site = input[0];
                uint visits = uint.Parse(input[1]);
                decimal pricePerVisit = decimal.Parse(input[2]);

                siteLost += visits * pricePerVisit;
                Console.WriteLine(site);
            }
            Console.WriteLine($"Total Loss: {siteLost:F20}");
            Console.WriteLine($"Security Token: {BigInteger.Pow(key,n)}");
        }
    }
}
