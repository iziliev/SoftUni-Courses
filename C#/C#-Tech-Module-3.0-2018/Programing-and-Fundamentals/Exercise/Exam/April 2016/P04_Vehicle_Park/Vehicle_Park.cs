using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Vehicle_Park
{
    class Vehicle_Park
    {
        static void Main()
        {
            List<string> park = Console.ReadLine()
                .Split(' ')
                .ToList();

            string input = Console.ReadLine();
            int count = 0;
            while (input != "End of customers!")
            {
                string[] data = input
                    .ToLower()
                    .Split(' ');

                string seats = data[0][0] + data[2];
                bool check = false;
                for (int i = 0; i < park.Count; i++)
                {
                    if (seats == park[i])
                    {
                        string seat = seats.Substring(1);
                        int sum = seats[0] * int.Parse(seat);
                        Console.WriteLine($"Yes, sold for {sum}$");
                        count++;
                        park.Remove(park[i]);
                        check = true;
                        break;
                    }
                }
                if (check== false)
                {
                    Console.WriteLine("No");
                }

                input = Console.ReadLine();
            }
            Console.Write("Vehicles left: ");
            Console.WriteLine(string.Join(", ",park));
            Console.WriteLine($"Vehicles sold {count}");
        }
    }
}
