using _09_Explicit_Interfaces.Contracts;
using _09_Explicit_Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _09_Explicit_Interfaces.Core
{
    public class Engine
    {
        public void Run()
        {
            var input = string.Empty;
            while ((input = Console.ReadLine())!="End")
            {
                var inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IPerson citizen = new Citizen(inputArgs[0]);
                IResident resident = new Citizen(inputArgs[0]);
                Console.WriteLine(citizen.GetName());
                Console.WriteLine(resident.GetName());

            }
        }
    }
}
