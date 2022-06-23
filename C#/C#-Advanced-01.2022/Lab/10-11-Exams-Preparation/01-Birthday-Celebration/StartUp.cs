using System;
using System.Collections.Generic;
using System.Linq;

namespace StreetRacing
{
    public class StartUp
    {
        public static void Main()
        {
            var guests = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray().Reverse());

            var plates = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var waste = 0;

            while (guests.Count > 0 && plates.Count > 0)
            {
                var currentGuest = guests.Peek();
                var currentPlate = plates.Pop();

                if (currentGuest <= currentPlate)
                {
                    waste += currentPlate - currentGuest;
                    guests.Pop();
                    continue;
                }

                if (currentGuest > currentPlate)
                {
                    guests.Push(guests.Pop() - currentPlate);
                }
            }

            if (guests.Count == 0 && plates.Count > 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }

            else if (guests.Count > 0 && plates.Count == 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }

            Console.WriteLine($"Wasted grams of food: {waste}");
        }
    }
}
