using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_Key_Revolver
{
    class StartUp
    {
        static void Main()
        {
            var bulletPrice = int.Parse(Console.ReadLine());

            var sizeGunBarrel = int.Parse(Console.ReadLine());

            var bullets = new Stack<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var locks = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var value = int.Parse(Console.ReadLine());
            var count = 0;
            var countBullets = 0;

            while (bullets.Count>0 && locks.Count>0)
            {
                if (bullets.Pop()<=locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                    count++;
                    countBullets++;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    count++;
                    countBullets++;
                }

                if (bullets.Count>0 && count == sizeGunBarrel)
                {
                    Console.WriteLine("Reloading!");
                    count = 0;
                }
            }

            if (locks.Count>0 )
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${value - (countBullets * bulletPrice)}");
            }
        }
    }
}
