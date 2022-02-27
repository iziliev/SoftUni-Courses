using System;
using System.Collections.Generic;

namespace _09_Explicit_Interfaces
{
    public class StartUp
    {
        public static void Main()
        {
            var citizens = new List<Citizen>();
            var input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                var args = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var citizen = new Citizen(args[0], args[1], int.Parse(args[2]));
                citizens.Add(citizen);
            }

            foreach (var item in citizens)
            {
                IPerson iperson = item;
                IResident iresident = item;
                Console.WriteLine(iperson.GetName());
                Console.WriteLine(iresident.GetName());
            }
        }
    }
}
