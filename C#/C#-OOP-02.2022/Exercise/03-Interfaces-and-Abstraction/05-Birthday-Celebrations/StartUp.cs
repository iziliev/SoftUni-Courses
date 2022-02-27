using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Birthday_Celebrations
{
    public class StartUp
    {
        public static void Main()
        {
            var iBirhthdable = new List<IBirthdable>();
            var input = string.Empty;
            while ((input = Console.ReadLine())!="End")
            {
                var inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs[0] == "Citizen")
                {
                    var citizen = new Citizen(inputArgs[1], int.Parse(inputArgs[2]), inputArgs[3], inputArgs[4]);
                    iBirhthdable.Add(citizen);
                }
                else if (inputArgs[0] == "Pet")
                {
                    var pet = new Pet(inputArgs[1], inputArgs[2]);
                    iBirhthdable.Add(pet);
                }
                else
                {
                    continue;
                }
            }

            var searchYear = Console.ReadLine();

            if (!iBirhthdable.Any(x=>x.BirthDate.EndsWith(searchYear)))
            {
                Console.WriteLine("<empty output>");
            }
            else
            {
                foreach (var ibirth in iBirhthdable)
                {
                    if (ibirth.BirthDate.EndsWith(searchYear))
                    {
                        Console.WriteLine(ibirth.BirthDate);
                    }
                }
            }
        }
    }
}
