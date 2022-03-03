using _04_Border_Control.Contracts;
using _04_Border_Control.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Border_Control.Core
{
    public class Engine
    {
        public void Run()
        {
            var input = string.Empty;
            var identifiable = new List<IIdentifiable>();
            
            while ((input=Console.ReadLine())!="End")
            {
                var inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs.Length == 3)
                {
                    ICitizen citizen = new Citizen(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]);
                    identifiable.Add(citizen);
                }
                else if (inputArgs.Length == 2)
                {
                    IRobot robot = new Robot(inputArgs[0], inputArgs[1]);
                    identifiable.Add(robot);
                }
            }

            var check =Console.ReadLine();
            
            foreach (var items in identifiable)
            {
                if (items.Id.EndsWith(check))
                {
                    Console.WriteLine(items.Id);
                }
            }
        }
    }
}
