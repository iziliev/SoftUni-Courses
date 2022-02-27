using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Food_Shortage
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var iBuyer = new HashSet<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (input.Length==4)
                {
                    var citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    iBuyer.Add(citizen);
                }
                else if (input.Length == 3)
                {
                    var rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    iBuyer.Add(rebel);
                }
            }

            var inputArgs = string.Empty;
            while ((inputArgs = Console.ReadLine())!="End")
            {
                if (iBuyer.Any(x=>x.Name==inputArgs))
                {
                    iBuyer.FirstOrDefault(x => x.Name == inputArgs).BuyFood();
                }
            }

            Console.WriteLine(iBuyer.Sum(x=>x.Food));
        }
    }
}
