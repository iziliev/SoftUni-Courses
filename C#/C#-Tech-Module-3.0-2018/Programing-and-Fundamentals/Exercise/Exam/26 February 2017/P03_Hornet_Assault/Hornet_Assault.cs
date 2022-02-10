using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Hornet_Assault
{
    class Hornet_Assault
    {
        static void Main()
        {
            List<int> bees = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> hornetsPower = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < bees.Count; i++)
            {
                int sumPower = hornetsPower.Sum();

                if (bees[i] < sumPower)
                {
                    bees.Remove(bees[i]);
                    i--;
                }
                else
                {
                    if (i < bees.Count - 1)
                    {
                        hornetsPower.Remove(hornetsPower[0]);
                        bees[i] = bees[i] - sumPower;
                        if (bees[i] <= 0)
                        {
                            bees.Remove(bees[i]);
                            i--;
                        }
                    }
                    else
                    {
                        hornetsPower.Clear();
                        bees[i] = bees[i] - sumPower;
                    }
                }
            }
            if (bees.Count == 0)
            {
                Console.WriteLine(String.Join(" ", hornetsPower));
            }
            else
            {
                Console.WriteLine(String.Join(" ", bees));
            }
        }
    }
}
