using System;

namespace P01_Poke_Mon
{
    class Poke_Mon
    {
        static void Main()
        {
            uint n = uint.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            byte y = byte.Parse(Console.ReadLine());

            int count = 0;
            uint sum = n;
            while (sum >= m)
            {
                sum -= (uint)m;
                if (sum * 2 == n && y > 0)
                {
                    sum /= y;
                }

                count++;
            }
            Console.WriteLine(sum);
            Console.WriteLine(count);
        }
    }
}
