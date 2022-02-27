using System;
using System.Collections.Generic;

namespace _04_Border_Control
{
    public class StartUp
    {
        public static void Main()
        {
            var identifible = new List<IIdentifiable>();
            var input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                var args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (args.Length == 2)
                {
                    var robot = new Robot(args[0],args[1]);
                    identifible.Add(robot);
                }
                else if (args.Length == 3)
                {
                    var citizen = new Citizen(args[0],int.Parse(args[1]),args[2]);
                    identifible.Add(citizen);   
                }
            }
            var realIdArgs = Console.ReadLine();

            foreach (var identifi in identifible)
            {
                if (identifi.Id.EndsWith(realIdArgs))
                {
                    Console.WriteLine(identifi.Id);
                }
            }
        }
    }
}
