using _05_Birthday_Celebrations.Contracts;
using _05_Birthday_Celebrations.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_Birthday_Celebrations.Core
{
    public class Engine
    {
        public void Run()
        {
            var input = string.Empty;
            var birthdables = new List<IBirthdable>();
            
            while ((input=Console.ReadLine())!="End")
            {
                var inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs[0] == "Citizen")
                {
                    ICitizen citizen = new Citizen(inputArgs[1], int.Parse(inputArgs[2]), inputArgs[3], inputArgs[4]);
                    birthdables.Add(citizen);
                }
                else if (inputArgs[0] == "Pet")
                {
                    IPet pet = new Pet(inputArgs[1], inputArgs[2]);
                    birthdables.Add(pet);
                }
            }

            var check =Console.ReadLine();
            
            foreach (var items in birthdables)
            {
                if (items.Bithdate.EndsWith(check))
                {
                    Console.WriteLine(items.Bithdate);
                }
            }
        }
    }
}
