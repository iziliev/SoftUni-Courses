using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Endurance_Rally
{
    class Endurance_Rally
    {
        static void Main()
        {
            string[] drivers = Console.ReadLine()
                .Split(' ');

            double[] road = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            int[] checkPoints = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int lastzone = 0;

            for (int i = 0; i < drivers.Length; i++)
            {
                bool isFinish = true;
                var fuelLeft = (double)(drivers[i][0]);

                for (int j = 0; j < road.Length; j++)
                {
                    if (checkPoints.Contains(j))
                    {
                        fuelLeft += road[j];
                    }
                    else
                    {
                        fuelLeft -= road[j];
                    }

                    if (fuelLeft<=0)
                    {
                        lastzone = j;
                        isFinish = false;
                        break;
                    }
                }
                if (isFinish)
                {
                    Console.WriteLine($"{drivers[i]} - fuel left {fuelLeft:F2}");
                }
                else
                {
                    Console.WriteLine($"{drivers[i]} - reached {lastzone}");
                }
            }
            
        }
    }
}
