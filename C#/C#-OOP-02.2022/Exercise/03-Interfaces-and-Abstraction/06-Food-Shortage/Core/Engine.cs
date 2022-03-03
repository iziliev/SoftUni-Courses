using _06_Food_Shortage.Contracts;
using _06_Food_Shortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06_Food_Shortage.Core
{
    public class Engine
    {
        public void Run()
        {
            var n = int.Parse(Console.ReadLine());

            var identifiables = new HashSet<IIdentifiable>();

            for (int i = 0; i < n; i++)
            {
                var inputArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (inputArgs.Length==3)
                {
                    IRebel rebel = new Rebel(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]);
                    identifiables.Add(rebel);
                }
                else
                {
                    ICitizen citizen = new Citizen(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2], inputArgs[3]);
                    identifiables.Add(citizen);
                }
            }

            var input = string.Empty;
            while ((input = Console.ReadLine())!="End")
            {
                var identifiable = identifiables.FirstOrDefault(x => x.Name == input);
                if (identifiable == null)
                {
                    continue;
                }

                identifiable.BuyFood();
            }

            Console.WriteLine(identifiables.Sum(x=>x.Food));
        }
    }
}
